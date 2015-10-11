using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Groups logic for model validation. Needs to be extended in the actual instance to provide
    /// method infos based on model types (to increase performance).
    /// </summary>
    public abstract class ModelValidationController
    {
        private List<IValidationMessage> currentValidationMessages;
        /// <summary>
        /// Validation Map Dictionary.
        /// </summary>
        public readonly Dictionary<Type, Dictionary<System.Reflection.MethodInfo, ModelValidationCategories>> ValidationMap = new Dictionary<Type, Dictionary<System.Reflection.MethodInfo, ModelValidationCategories>>();

        /// <summary>
        /// Validation IsEnabled Dictionary.
        /// </summary>
        public readonly Dictionary<Type, bool> ValidationIsEnabled = new Dictionary<Type, bool>();

        /// <summary>
        /// Constructor.
        /// </summary>
        protected ModelValidationController()
        {
            currentValidationMessages = new List<IValidationMessage>();
        }

        /// <summary>
        /// Initializes a type.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="type"></param>
        protected static void InitializeType(ModelValidationController controller, System.Type type)
        {
            object[] attr = type.GetCustomAttributes(typeof(ModelValidationStateAttribute), false);

            bool isEnabled = false;
            foreach (ModelValidationStateAttribute attribute in attr)
                if (attribute.ValidationState == ModelValidationState.Enabled)
                {
                    isEnabled = true;
                    break;
                }
            if (isEnabled)
                controller.ValidationIsEnabled.Add(type, isEnabled);

            // continue with methods
            if (isEnabled)
            {
                System.Collections.Generic.Dictionary<System.Reflection.MethodInfo, ModelValidationCategories> dictionary = new System.Collections.Generic.Dictionary<System.Reflection.MethodInfo, ModelValidationCategories>();
                System.Reflection.MethodInfo[] methodInfoArr = type.GetMethods(System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
                for (int i = 0; i < methodInfoArr.Length; i++)
                {
                    System.Reflection.MethodInfo methodInfo = methodInfoArr[i];
                    object[] objArr = methodInfo.GetCustomAttributes(typeof(ModelValidationMethodAttribute), false);
                    if ((objArr != null) && (objArr.Length != 0))
                    {
                        dictionary.Add(methodInfo, (objArr[0] as ModelValidationMethodAttribute).Categories);
                    }
                }
                controller.ValidationMap.Add(type, dictionary);
            }
        }

        /*
        /// <summary>
        /// Initializes the static Validation map as well as the Validation is enabled fields in the actual instance of this class.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Initializes the static Validation map as well as the Validation is enabled fields in the actual instance of this class.
        /// </summary>
        /// <param name="controller">Controller to initalize</param>
        /// <param name="discardController">Validation controllers to discard.</param>
        public abstract void Initialize(ModelValidationController controller, List<IDomainModelServices> discardController);*/

        /// <summary>
        /// Do validation for a set of elements based on the validation categories
        /// </summary>
        /// <param name="subjects">The list of subjects to validate.</param>
        /// <param name="categories">Categories</param>
        /// <returns>Returns true if no error/warning/message are found.</returns>
        public virtual bool Validate(IEnumerable<ModelElement> subjects, ModelValidationCategories categories)
        {
            ModelValidationContext validationContext = new ModelValidationContext(categories, subjects);
            return Validate(validationContext);
        }

        /// <summary>
        /// Do validation for a single element.
        /// </summary>
        /// <param name="subject">The subject to validate.</param>
        /// <param name="categories">Categories.</param>
        /// <returns>Returns true if no error/warning/message are found.</returns>
        public bool Validate(ModelElement subject, ModelValidationCategories categories)
        {
            List<ModelElement> list = new List<ModelElement>(1);
            list.Add(subject);
            return Validate(list, categories);
        }

        /// <summary>
        /// Validate the whole store.
        /// </summary>
        /// <param name="Store">Store to validate.</param>
        /// <param name="categories">Categories.</param>
        /// <returns>Returns true if no error/warning/message are found.</returns>
        public bool Validate(Store Store, ModelValidationCategories categories)
        {
            return Validate(Store.ElementDirectory.AllElements, categories);
        }

        /// <summary>
        /// Validate using the given validation context.
        /// </summary>
        /// <param name="context">Validation context</param>
        /// <returns>Returns true if no error/warning/message are found.</returns>
        private bool Validate(ModelValidationContext context)
        {
            currentValidationMessages = DoValidation(context);
            if( currentValidationMessages == null )
                currentValidationMessages = new List<IValidationMessage>();

            return currentValidationMessages.Count == 0;
        }

        private List<IValidationMessage> DoValidation(ModelValidationContext context)
        {
            if (context != null)
            {
                IList<ModelElement> ilist = context.ValidationSubjects;
                for (int i = 0; i < ilist.Count; i++)
                {
                    InternalValidate(ilist[i], context);
                }
                return context.CollectedViolations;
            }
            return null;
        }
        private void InternalValidate(ModelElement element, ModelValidationContext context)
        {
            try
            {
                // collect methods on those classes (main class and base classes), where validation is enabled
                List<System.Reflection.MethodInfo> list = new List<System.Reflection.MethodInfo>();

                Type type = element.GetType();
                while (type != null)
                {
                    if (ValidationIsEnabled.Keys.Contains(type))
                    {
                        bool isEnabled = ValidationIsEnabled[type];

                        // collect methods
                        Dictionary<System.Reflection.MethodInfo, ModelValidationCategories> methods = ValidationMap[type];
                        foreach (System.Reflection.MethodInfo methodInfo in methods.Keys)
                        {
                            ModelValidationCategories cat = methods[methodInfo];
                            if ((cat & context.Categories) != 0)
                            {
                                list.Add(methodInfo);
                            }
                        }
                    }
                    type = type.BaseType;
                }

                // invoke methods
                foreach (System.Reflection.MethodInfo methodInfo in list)
                {
                    try
                    {
                        methodInfo.Invoke(element, new object[] { context });
                    }
                    catch (Exception ex)
                    {
                        context.AddMessage(new ValidationMessage(ModelValidationMessageIds.ValidationIvokeMethodExceptionErrorId, ModelValidationViolationType.Error, ex.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                context.AddMessage(new ValidationMessage(ModelValidationMessageIds.ValidationExceptionErrorId, ModelValidationViolationType.Error, ex.Message));
            }


            /*

            // see if validation is enabled on the class or on any of the base classes.
            object[] attr = type.GetCustomAttributes(typeof(ModelValidationStateAttribute), true);
            if (attr.Length == 0)
                return;

            bool isEnabled = false;
            foreach(ModelValidationStateAttribute attribute in attr)
                if (attribute.ValidationState == ModelValidationState.Enabled)
                {
                    isEnabled = true;
                    break;
                }
            if (!isEnabled)
                return;

            // collect methods on those classes (main class and base classes), where validation is enabled
            List<System.Reflection.MethodInfo> list = new List<System.Reflection.MethodInfo>();

            while (type != null)
            {
                // see if validation enabled on the current level
                attr = type.GetCustomAttributes(typeof(ModelValidationStateAttribute), false);
                if (attr.Length > 0)
                {
                    ModelValidationStateAttribute attribute = attr[0] as ModelValidationStateAttribute;
                    if( attribute.ValidationState != ModelValidationState.Disabled )
                    {
                        // collect methods
                        System.Reflection.MethodInfo[] methodInfoArr = type.GetMethods(System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
                        for (int i = 0; i < methodInfoArr.Length; i++)
                        {
                            System.Reflection.MethodInfo methodInfo = methodInfoArr[i];
                            object[] objArr = methodInfo.GetCustomAttributes(typeof(ModelValidationMethodAttribute), false);
                            if ((objArr != null) && (objArr.Length != 0))
                            {
                                object[] methodAttr = methodInfo.GetCustomAttributes(typeof(ModelValidationMethodAttribute), false);
                                if (methodAttr.Length > 0)
                                {
                                    ModelValidationMethodAttribute methodAttribute = methodAttr[0] as ModelValidationMethodAttribute;
                                    if( (methodAttribute.Categories & context.Categories) != 0 )
                                        list.Add(methodInfo);
                                }
                            }
                        }
                    }
                }

                type = type.BaseType;
            }

            // invoke methods
            foreach (System.Reflection.MethodInfo methodInfo in list)
            {
                try
                {
                    methodInfo.Invoke(element, new object[] { context });
                }
                catch (Exception ex)
                {
                    context.AddMessage(new ModelValidationMessage(ModelValidationMessageIds.ValidationExceptionErrorId, ModelValidationViolationType.Error, ex.Message, null));
                }
            }
            */
        }

        /// <summary>
        /// Clears all messages.
        /// </summary>
        public virtual void ClearMessages()
        {
            currentValidationMessages.Clear();
        }

        /// <summary>
        /// Collects active messages of a given type.
        /// </summary>
        /// <param name="searchTypes">Types of messages to collect.</param>
        /// <returns>Set of collected messages.</returns>
        private ReadOnlyCollection<IValidationMessage> CollectMessages(ModelValidationViolationType searchTypes)
        {
            List<IValidationMessage> list = new List<IValidationMessage>();
            foreach (IValidationMessage validationMessage in currentValidationMessages)
            {
                if ((validationMessage.Type & searchTypes) != 0)
                    list.Add(validationMessage);
            }
            return list.AsReadOnly();
        }

        /// <summary>
        /// Gets a copy of all the active error and fatal messages.
        /// </summary>
        public ReadOnlyCollection<IValidationMessage> ErrorMessages
        {
            get
            {
                return CollectMessages(ModelValidationViolationType.Error | ModelValidationViolationType.Fatal);
            }
        }

        /// <summary>
        /// Gets a copy of all the active fatal messages.
        /// </summary>
        public ReadOnlyCollection<IValidationMessage> FatalMessages
        {
            get
            {
                return CollectMessages(ModelValidationViolationType.Fatal);
            }
        }

        /// <summary>
        /// Gets a copy of all the active informational messages.
        /// </summary>
        public ReadOnlyCollection<IValidationMessage> InformationalMessages
        {
            get
            {
                return CollectMessages(ModelValidationViolationType.Message);
            }
        }

        /// <summary>
        /// Gets a copy of all the active error/warning/message messages.
        /// </summary>
        public ReadOnlyCollection<IValidationMessage> ValidationMessages
        {
            get
            {
                return currentValidationMessages.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets a copy of all the active warning messages.
        /// </summary>
        public ReadOnlyCollection<IValidationMessage> WarningMessages
        {
            get
            {
                return CollectMessages(ModelValidationViolationType.Warning);
            }
        }
    }
}

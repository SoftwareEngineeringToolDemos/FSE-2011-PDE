using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public abstract partial class SerializationClass
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateSerializationClass(ValidationContext context)
        {
            // Only one property's serialization representation type can be declared as "inner value" per element.
            bool bHasInnerValueAttribute = false;
            foreach (SerializationAttributeElement element in this.Attributes)
            {
                if( element is SerializedDomainProperty )
                {
                    SerializedDomainProperty p = element as SerializedDomainProperty;
                    if (p.SerializationRepresentationType == SerializationRepresentationType.InnerValue)
                    {
                        if (!bHasInnerValueAttribute)
                        {
                            bHasInnerValueAttribute = true;

                            if (this is SerializedDomainClass)
                            {
                                // Abstract classes can not have a property with serialization representation type set to "inner value".
                                if( (this as SerializedDomainClass).DomainClass.InheritanceModifier == InheritanceModifier.Abstract)
                                    context.LogError("Abstract classes can not have a property with serialization representation type set to 'inner value'. Error on " + this.SerializationName, "InnerValuePropertyOnAbstractElement", null); //this);
                            }
                            else if (this is SerializedReferenceRelationship)
                            {
                                // Abstract classes can not have a property with serialization representation type set to "inner value".
                                if ((this as SerializedReferenceRelationship).ReferenceRelationship.InheritanceModifier == InheritanceModifier.Abstract)
                                    context.LogError("Abstract classes can not have a property with serialization representation type set to 'inner value'. Error on " + this.SerializationName, "InnerValuePropertyOnAbstractElement", null); //this);
                            }
                            else if (this is SerializedEmbeddingRelationship)
                            {
                                // Abstract classes can not have a property with serialization representation type set to "inner value".
                                if ((this as SerializedEmbeddingRelationship).EmbeddingRelationship.InheritanceModifier == InheritanceModifier.Abstract)
                                    context.LogError("Abstract classes can not have a property with serialization representation type set to 'inner value'. Error on " + this.SerializationName, "InnerValuePropertyOnAbstractElement", null); //this);
                            }
                        }
                        else
                        {
                            context.LogError("Only one property's serialization representation type can be declared as 'inner value' per element. Error on " + this.SerializationName, "MultipleInnerValueProperties", null); //this);
                        }
                    }
                }
            }
        }
    }
}

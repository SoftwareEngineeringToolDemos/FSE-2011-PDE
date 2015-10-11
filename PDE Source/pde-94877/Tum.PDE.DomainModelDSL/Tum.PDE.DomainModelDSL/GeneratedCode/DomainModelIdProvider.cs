 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.TestLanguage
{
	/// <summary>
	/// This class provides an id generator to be used in the domain model.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public partial class TestLanguageDomainModelIdProvider : TestLanguageDomainModelIdProviderBase
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static TestLanguageDomainModelIdProvider instance;
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
		public static TestLanguageDomainModelIdProvider Instance
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (TestLanguageDomainModelIdProvider.instance == null)
					TestLanguageDomainModelIdProvider.instance = new TestLanguageDomainModelIdProvider();
				return TestLanguageDomainModelIdProvider.instance;
			}
		}
		private TestLanguageDomainModelIdProvider(){}
		#endregion
	}
	
	/// <summary>
	/// This class provides an id generator to be used in the domain model.
	/// This is the abstract base of the double-derived implementation.
	/// </summary>
	public abstract class TestLanguageDomainModelIdProviderBase : DslEditorModeling::IModelElementIdProvider
	{
		private System.Collections.Generic.List<System.Guid> IDList;
		private System.Collections.Generic.List<System.Guid> ExcludedIDList;
	
		/// <summary>
		/// Constructor.
		/// </summary>
		protected TestLanguageDomainModelIdProviderBase()
		{
			IDList = new System.Collections.Generic.List<System.Guid>();		
			ExcludedIDList = new System.Collections.Generic.List<System.Guid>();		
		}
		
		/// <summary>
        /// Generates a new unique key.
        /// </summary>
        /// <returns>New Key as a System.Guid.</returns>
		public virtual System.Guid GenerateNewKey()
        {
            System.Guid guid = System.Guid.NewGuid();
            while (HasKey(guid))
            {
                System.Windows.MessageBox.Show("!!! ID already used !!! New id will be generated");
                guid = System.Guid.NewGuid();
            }
            // IDList.Add(guid);  // no need to add here, just generate new key

            return guid;
        }

        /// <summary>
        /// Adds a new key to the ID list. 
        /// </summary>
        /// <param name="modelElement">Domain model element to add the Id for.</param>
        public virtual void AddKey(DslModeling::ModelElement modelElement)
        {
        	//if( HasKey(modelElement.Id ))
            //    throw new System.ArgumentException("Duplicate ID: modelElementId already in IDList for " + modelElement.ToString());
			
			if( modelElement is DslEditorModeling::IDableElement )            
            	IDList.Add(modelElement.Id);
        }
		
        /// <summary>
        /// Removes a specific key.
        /// </summary>
        /// <param name="modelElement">Domain model element to remove the key for.</param>
        public virtual void RemoveKey(DslModeling::ModelElement modelElement)
		{
			RemoveKey(modelElement, new System.Collections.Generic.List<DslEditorModeling::IDomainModelServices>());
		}
		
        /// <summary>
        /// Removes a specific key.
        /// </summary>
        /// <param name="modelElement">Domain model element to remove the key for.</param>
        /// <param name="servicesToDiscard">Services to ignore.</param>
        public virtual bool RemoveKey(DslModeling::ModelElement modelElement, System.Collections.Generic.List<DslEditorModeling::IDomainModelServices> servicesToDiscard)
		{
			//if( IDList.Contains(modelElement.Id) )
			//	IDList.Remove(modelElement.Id);
			try
			{
				if( modelElement is DslEditorModeling::IDableElement )			
					IDList.Remove(modelElement.Id);
					
				return true;
			}
			catch{}		
			
			// extern services
			System.Collections.Generic.List<DslEditorModeling::IDomainModelServices> discard = new System.Collections.Generic.List<DslEditorModeling::IDomainModelServices>();
			discard.AddRange(servicesToDiscard);
			discard.Add(TestLanguageDomainModelServices.Instance);

			foreach(DslEditorModeling::IDomainModelServices externService in TestLanguageDomainModelExtensionServices.Instance.ExternServices)
			{
				if( discard.Contains(externService) )
					continue;
			
				bool bRemoved = externService.ElementIdProvider.RemoveKey(modelElement, discard);
				if( bRemoved )
					return true;
			}
		
			return false;
		}
		
		 /// <summary>
        /// Gets whether a certain key has already been assigned.
        /// </summary>
        /// <param name="modelElementId">Domain model element Id.</param>
        /// <returns>True if the given id has already been assigned; false otherwise.</returns>
        public virtual bool HasKey(System.Guid modelElementId)
		{
			return HasKey(modelElementId, new System.Collections.Generic.List<DslEditorModeling::IDomainModelServices>());
		}
		
        /// <summary>
        /// Gets whether a certain key has already been assigned.
        /// </summary>
        /// <param name="modelElementId">Domain model element Id.</param>
        /// <param name="servicesToDiscard">Services to ignore.</param>
        /// <returns>True if the given id has already been assigned; false otherwise.</returns>
        public virtual bool HasKey(System.Guid modelElementId, System.Collections.Generic.List<DslEditorModeling::IDomainModelServices> servicesToDiscard)
		{
			if( IDList.Contains(modelElementId) )
				return true;
				
			if( ExcludedIDList.Contains(modelElementId) )
				return true;
		
			// extern services
			System.Collections.Generic.List<DslEditorModeling::IDomainModelServices> discard = new System.Collections.Generic.List<DslEditorModeling::IDomainModelServices>();
			discard.AddRange(servicesToDiscard);
			discard.Add(TestLanguageDomainModelServices.Instance);

			foreach(DslEditorModeling::IDomainModelServices externService in TestLanguageDomainModelExtensionServices.Instance.ExternServices)
			{
				if( discard.Contains(externService) )
					continue;
			
				bool bHasKey = externService.ElementIdProvider.HasKey(modelElementId, discard);
				if( bHasKey )
					return true;
			}
		
			return false;
		}
		
		/// <summary>
        /// Resets the id provider.
        /// </summary>
        public virtual void Reset()
		{
			Reset(new System.Collections.Generic.List<DslEditorModeling::IDomainModelServices>());
		}
		
        /// <summary>
        /// Resets the id provider.
        /// </summary>
        /// <param name="servicesToDiscard">Services to ignore.</param>
        public virtual void Reset(System.Collections.Generic.List<DslEditorModeling::IDomainModelServices> servicesToDiscard)
		{
			IDList.Clear();
			
			// extern services
			System.Collections.Generic.List<DslEditorModeling::IDomainModelServices> discard = new System.Collections.Generic.List<DslEditorModeling::IDomainModelServices>();
			discard.AddRange(servicesToDiscard);
			discard.Add(TestLanguageDomainModelServices.Instance);

			foreach(DslEditorModeling::IDomainModelServices externService in TestLanguageDomainModelExtensionServices.Instance.ExternServices)
			{
				if( discard.Contains(externService) )
					continue;
			
				externService.ElementIdProvider.Reset(discard);
			}
		}
		
		/// <summary>
        /// Adds a property assignment containing the new id value if there is non yet in the array.
        /// </summary>
        /// <param name="propertyAssignments">Element property assignments.</param>
        /// <returns>Element property assignments containing an id property assignment.</returns>
        public virtual DslModeling::PropertyAssignment[] AssignId(DslModeling::PropertyAssignment[] propertyAssignments)
        {
            bool bHasKey = false;
            if (propertyAssignments != null)
                foreach (DslModeling::PropertyAssignment p in propertyAssignments)
                    if (p.PropertyId == DslModeling::ElementFactory.IdPropertyAssignment)
                    {
                        bHasKey = true;
                        break;
                    }

            if (!bHasKey)
            {
                int length = 1;
                if (propertyAssignments != null)
                    length += propertyAssignments.Length;

                DslModeling::PropertyAssignment[] propertyAssignmentsWithKey = new DslModeling::PropertyAssignment[length];
                propertyAssignmentsWithKey[length-1] = new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment,
                    GenerateNewKey());

                if (propertyAssignments != null)
                    for (int i = 0; i < propertyAssignments.Length; ++i)
                        propertyAssignmentsWithKey[i] = propertyAssignments[i];

                return propertyAssignmentsWithKey;
            }
            else
                return propertyAssignments;
        }
		
		        /// <summary>
        /// Adds a property assignment containing the new id value if there is non yet in the array.
        /// </summary>
        /// <returns>Element property assignments containing an id property assignment.</returns>
        public virtual DslModeling::PropertyAssignment[] CreateId()
		{
			DslModeling::PropertyAssignment[] propertyAssignmentsWithKey = new DslModeling::PropertyAssignment[1];
            propertyAssignmentsWithKey[0] = new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment,
                    GenerateNewKey());
			return propertyAssignmentsWithKey;
		}
	}
}


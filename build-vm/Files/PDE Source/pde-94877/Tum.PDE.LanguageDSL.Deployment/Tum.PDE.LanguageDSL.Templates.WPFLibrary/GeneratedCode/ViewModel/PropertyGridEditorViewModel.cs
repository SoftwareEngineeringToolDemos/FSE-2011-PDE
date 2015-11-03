 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorViewModelPGrid = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;
using DslEditorViewModelServices = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using DslEditorViewModelDeletion = global:: Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Deletion;

namespace Tum.VModellXT
{		
    /// <summary>
    /// ReferencedModelRoleViewModel for ReferenzmodellHasVModell.VModell.
	///
	/// Double derived to allow easier customization.
    /// </summary>
	public partial class ReferenzmodellHasVModellVModellRMRViewModel : ReferenzmodellHasVModellVModellRMRViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public ReferenzmodellHasVModellVModellRMRViewModel(DslEditorViewModelData::ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            
        }
		#endregion
	}
	
    /// <summary>
    /// ReferencedModelRoleViewModel for ReferenzmodellHasVModell.VModell.
	///
	/// This is the base abstract class.
    /// </summary>
	public abstract partial class ReferenzmodellHasVModellVModellRMRViewModelBase : Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Path.ReferencedModelRoleViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public ReferenzmodellHasVModellVModellRMRViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            
        }
		#endregion	
		
		#region Properties
        /// <summary>
        /// Gets whether a model is referenced in this reference model or not.
        /// </summary>
        public override bool IsReferencedModelSet
        {
            get
            {
                if ((this.Elements[0] as global::Tum.VModellXT.Referenzmodell).VModell != null)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets the filter string for the open/save file dialog.
        /// </summary>
        public override string FileDialogFilter
        {
            get
			{
				return "VModell files|*.xml|All files|*.*";
			}
        }		
		#endregion
		
		#region Methods
		/// <summary>
        /// Converts the property value and returns the converted value.
        /// </summary>
        /// <returns>Converted property value.</returns>
        public override object GetPropertyValue()
        {
			global::Tum.VModellXT.Referenzmodell model = this.Elements[0] as global::Tum.VModellXT.Referenzmodell;
			
			if( model.VModell == null )
				return "";
			
			DslEditorModeling::IParentModelElement parent = model.GetDomainModelServices().ElementParentProvider.GetParentModelElement(model);
            if (parent == null)
                throw new System.ArgumentNullException("Parent of element " + model.ToString() + " can not be null");
			
			string path = parent.DomainFilePath;
            string vModellDirectory = new System.IO.FileInfo(path).DirectoryName;
				
			global::Tum.VModellXT.VModell refModel = model.VModell;
            string curPath = Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Path.PathHelper.EvaluateRelativePath(
				vModellDirectory, (refModel as DslEditorModeling::IParentModelElement).DomainFilePath);
			return curPath;
		}
		
        /// <summary>
        /// Loads the model from the given file path and sets it to its appropriate element.
        /// </summary>
        /// <param name="filePath">File path to load the model from. Can be null to indicate that there is no referenced domain model.</param>
        protected override void SetReferencedModel(string filePath)
		{
			using (new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
				global::Tum.VModellXT.Referenzmodell model = this.Elements[0] as global::Tum.VModellXT.Referenzmodell;
                string file = filePath;

                DslEditorModeling::IParentModelElement parent = model.GetDomainModelServices().ElementParentProvider.GetParentModelElement(model);
                if (parent == null)
                    throw new System.ArgumentNullException("Parent of element " + model.ToString() + " can not be null");
				
				string path = parent.DomainFilePath;
                string vModellDirectory = new System.IO.FileInfo(path).DirectoryName;
                //string curPath = Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Path.PathHelper.EvaluateRelativePath(
				//	vModellDirectory, file);

                // load model
                try
                {
					if (!System.IO.File.Exists(file))
                    {
                        System.IO.FileStream s = System.IO.File.Create(file);
                        s.Close();
                    }
				
                    using (DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set referenced model"))
                    {
						global::Tum.VModellXT.VModellXTDocumentData data = this.ViewModelStore.ModelData as global::Tum.VModellXT.VModellXTDocumentData;
                        global::Tum.VModellXT.VModell referenceModel = data.ModelContextVModellXT.LoadInternal(file) as  global::Tum.VModellXT.VModell;
                        model.VModell = referenceModel;

                        transaction.Commit();

                    }
                }
                catch (System.Exception ex)
                {
                    DslEditorViewModelServices::IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<DslEditorViewModelServices::IMessageBoxService>();
                    messageBox.ShowError(ex.Message);
                }

                this.ModelData.FlushUndoRedoStacks();
            }			
		}

        /// <summary>
        /// Ensures that the user truly wants to remove a reference to a domain model.
        /// </summary>
        /// <returns>True to remove; False otherwise.</returns>
        protected override bool EnsureClosing()
		{
			if (!IsReferencedModelSet)
                return true;

			global::Tum.VModellXT.Referenzmodell refModel = this.Elements[0] as global::Tum.VModellXT.Referenzmodell;
            
			// we need to gather references that will be deleted if the referenced model is removed
            
            // 1. gather excluded domain models
            System.Collections.Generic.List<DslModeling::ModelElement> excludedDomainModels = new System.Collections.Generic.List<DslModeling::ModelElement>();
			foreach(DslModeling::ModelElement domainModel in this.Store.ElementDirectory.FindElements(global::Tum.VModellXT.Referenzmodell.DomainClassId))
			{
				if( domainModel == refModel )
					continue;
			
				DslModeling::ModelElement parent = domainModel;
				while(parent != null )
				{			
					parent = VModellXTElementParentProvider.Instance.GetParentModelElement(parent) as DslModeling::ModelElement;
					if( parent == refModel )
					{
						excludedDomainModels.Add(parent);
						break;
					}
				}					
			}
            
            // 2. add elements of those excluded domain models to get existing dependencies on them to 
            // the actual domain models
            System.Collections.Generic.List<DslModeling::ModelElement> elements = VModellXTElementChildrenProvider.Instance.GetChildren(refModel.VModell, false);

            // 3. ensure user wants to continue
            using( DslEditorViewModelDeletion::DeletionViewModel vm = new DslEditorViewModelDeletion::DeletionViewModel(this.ViewModelStore) )
			{
        	    vm.Set(elements, new RetrivalOptions(excludedDomainModels));
        	    vm.Description = "Attention: This deletion can not be undone! \r\n \r\n" + vm.Description;

        	    bool? result = this.GlobalServiceProvider.Resolve<DslEditorViewModelServices::IUIVisualizerService>().ShowDialog("DeleteElementsPopup", vm);
        	    if (!result == true)
        	        return false;

        	    }
            System.GC.Collect();

            // 4. delete referenced model and flush undo/redo stacks
            using (new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
                using (DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Delete referenced model"))
                {
                    refModel.VModell.Delete();
                    transaction.Commit();
                }
            }
            this.ModelData.FlushUndoRedoStacks();

            return true;
		}

        /// <summary>
        /// Ensures that the user can open the selected file and refence the domain model.
        /// </summary>
        /// <returns>True to reference; False otherwise.</returns>
        protected override bool EnsureOpening(string filePath)
		{
			try
            {
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.Load(filePath);

                HtmlAgilityPack.HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//@id");

                // verify that none of the ids is present at the moment
                if (nodes != null)
                    foreach (HtmlAgilityPack.HtmlNode node in nodes)
                    {
                        string value = node.Attributes["id"].Value;
                        if (VModellXTDomainModelIdProvider.Instance.HasVModellKey(value))
                        {
                            DslEditorViewModelServices::IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<DslEditorViewModelServices::IMessageBoxService>();
                            messageBox.ShowInformation("Can not reference the selected model because some of its elements are already included in the currently opened model. (Failed on element '" + node.Name + "').\r\n\r\nHint: This could also be caused by a referenced model in the domain model selected to be referenced.");

                            return false;
                        }
                    }

                // proceed with referenced models
                HtmlAgilityPack.HtmlNode refNode = htmlDocument.DocumentNode.SelectSingleNode("//v-modellvariante/referenzmodell");
                if (refNode != null)
                    foreach (HtmlAgilityPack.HtmlNode n in refNode.ChildNodes)
                    {
                        if (n.Name != "xi:include")
                            continue;

                        string href = n.Attributes["href"].Value;
                        string curPath = href;
                        if (!curPath.Contains(System.IO.Path.VolumeSeparatorChar.ToString()))
                        {
                            curPath = new System.IO.FileInfo(filePath).DirectoryName + System.IO.Path.DirectorySeparatorChar + curPath;
                        }

                        if (System.IO.File.Exists(curPath))
                            if (!EnsureOpening(curPath))
                                return false;
                    }
            }
            catch(System.Exception ex)
            {
                DslEditorViewModelServices::IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<DslEditorViewModelServices::IMessageBoxService>();
                messageBox.ShowInformation("Couldnt parse file: " + ex.Message);

                return false;
            }
            return true;
		}
		#endregion
		
		#region Helper Class
		private class RetrivalOptions : DslEditorModeling::DependenciesRetrivalOptions
		{
			System.Collections.Generic.List<DslModeling::ModelElement> excludedDomainModels;
			
			/// <summary>
        	/// Constructor.
        	/// </summary>
			/// <param name="excludedDomainModels">Excluded domain models </param>
        	public RetrivalOptions(System.Collections.Generic.List<DslModeling::ModelElement> excludedDomainModels) : base()
			{
				this.excludedDomainModels = excludedDomainModels;
			}
			
			/// <summary>
    	    /// Verifies if a specific model element should be excluded or not.
    	    /// </summary>
    	    /// <param name="modelElement">Model element to verify</param>
    	    /// <returns>True if the specified element should be excluded; False otherwise.</returns>
    	    public override bool ShouldExcludeDomainClass(DslModeling::ModelElement modelElement)
    	    {
    	        DslModeling::ModelElement parent = VModellXTElementParentProvider.Instance.GetParentModelElement(modelElement) as DslModeling::ModelElement;								
				if( parent == null )
					return false;
					
				if( excludedDomainModels.Contains(parent) )
					return true;

    	        return false;
    	    }			
			
		}
		#endregion
	}
}
namespace Tum.VModellXT
{		
    /// <summary>
    /// ReferencedModelRoleViewModel for MusterbibliothekHasVModell.VModell.
	///
	/// Double derived to allow easier customization.
    /// </summary>
	public partial class MusterbibliothekHasVModellVModellRMRViewModel : MusterbibliothekHasVModellVModellRMRViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public MusterbibliothekHasVModellVModellRMRViewModel(DslEditorViewModelData::ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            
        }
		#endregion
	}
	
    /// <summary>
    /// ReferencedModelRoleViewModel for MusterbibliothekHasVModell.VModell.
	///
	/// This is the base abstract class.
    /// </summary>
	public abstract partial class MusterbibliothekHasVModellVModellRMRViewModelBase : Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Path.ReferencedModelRoleViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public MusterbibliothekHasVModellVModellRMRViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            
        }
		#endregion	
		
		#region Properties
        /// <summary>
        /// Gets whether a model is referenced in this reference model or not.
        /// </summary>
        public override bool IsReferencedModelSet
        {
            get
            {
                if ((this.Elements[0] as global::Tum.VModellXT.Musterbibliothek).VModell != null)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets the filter string for the open/save file dialog.
        /// </summary>
        public override string FileDialogFilter
        {
            get
			{
				return "VModell files|*.xml|All files|*.*";
			}
        }		
		#endregion
		
		#region Methods
		/// <summary>
        /// Converts the property value and returns the converted value.
        /// </summary>
        /// <returns>Converted property value.</returns>
        public override object GetPropertyValue()
        {
			global::Tum.VModellXT.Musterbibliothek model = this.Elements[0] as global::Tum.VModellXT.Musterbibliothek;
			
			if( model.VModell == null )
				return "";
			
			DslEditorModeling::IParentModelElement parent = model.GetDomainModelServices().ElementParentProvider.GetParentModelElement(model);
            if (parent == null)
                throw new System.ArgumentNullException("Parent of element " + model.ToString() + " can not be null");
			
			string path = parent.DomainFilePath;
            string vModellDirectory = new System.IO.FileInfo(path).DirectoryName;
				
			global::Tum.VModellXT.VModell refModel = model.VModell;
            string curPath = Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Path.PathHelper.EvaluateRelativePath(
				vModellDirectory, (refModel as DslEditorModeling::IParentModelElement).DomainFilePath);
			return curPath;
		}
		
        /// <summary>
        /// Loads the model from the given file path and sets it to its appropriate element.
        /// </summary>
        /// <param name="filePath">File path to load the model from. Can be null to indicate that there is no referenced domain model.</param>
        protected override void SetReferencedModel(string filePath)
		{
			using (new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
				global::Tum.VModellXT.Musterbibliothek model = this.Elements[0] as global::Tum.VModellXT.Musterbibliothek;
                string file = filePath;

                DslEditorModeling::IParentModelElement parent = model.GetDomainModelServices().ElementParentProvider.GetParentModelElement(model);
                if (parent == null)
                    throw new System.ArgumentNullException("Parent of element " + model.ToString() + " can not be null");
				
				string path = parent.DomainFilePath;
                string vModellDirectory = new System.IO.FileInfo(path).DirectoryName;
                //string curPath = Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Path.PathHelper.EvaluateRelativePath(
				//	vModellDirectory, file);

                // load model
                try
                {
					if (!System.IO.File.Exists(file))
                    {
                        System.IO.FileStream s = System.IO.File.Create(file);
                        s.Close();
                    }
				
                    using (DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set referenced model"))
                    {
						global::Tum.VModellXT.VModellXTDocumentData data = this.ViewModelStore.ModelData as global::Tum.VModellXT.VModellXTDocumentData;
                        global::Tum.VModellXT.VModell referenceModel = data.ModelContextVModellXT.LoadInternal(file) as  global::Tum.VModellXT.VModell;
                        model.VModell = referenceModel;

                        transaction.Commit();

                    }
                }
                catch (System.Exception ex)
                {
                    DslEditorViewModelServices::IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<DslEditorViewModelServices::IMessageBoxService>();
                    messageBox.ShowError(ex.Message);
                }

                this.ModelData.FlushUndoRedoStacks();
            }			
		}

        /// <summary>
        /// Ensures that the user truly wants to remove a reference to a domain model.
        /// </summary>
        /// <returns>True to remove; False otherwise.</returns>
        protected override bool EnsureClosing()
		{
			if (!IsReferencedModelSet)
                return true;

			global::Tum.VModellXT.Musterbibliothek refModel = this.Elements[0] as global::Tum.VModellXT.Musterbibliothek;
            
			// we need to gather references that will be deleted if the referenced model is removed
            
            // 1. gather excluded domain models
            System.Collections.Generic.List<DslModeling::ModelElement> excludedDomainModels = new System.Collections.Generic.List<DslModeling::ModelElement>();
			foreach(DslModeling::ModelElement domainModel in this.Store.ElementDirectory.FindElements(global::Tum.VModellXT.Musterbibliothek.DomainClassId))
			{
				if( domainModel == refModel )
					continue;
			
				DslModeling::ModelElement parent = domainModel;
				while(parent != null )
				{			
					parent = VModellXTElementParentProvider.Instance.GetParentModelElement(parent) as DslModeling::ModelElement;
					if( parent == refModel )
					{
						excludedDomainModels.Add(parent);
						break;
					}
				}					
			}
            
            // 2. add elements of those excluded domain models to get existing dependencies on them to 
            // the actual domain models
            System.Collections.Generic.List<DslModeling::ModelElement> elements = VModellXTElementChildrenProvider.Instance.GetChildren(refModel.VModell, false);

            // 3. ensure user wants to continue
            using( DslEditorViewModelDeletion::DeletionViewModel vm = new DslEditorViewModelDeletion::DeletionViewModel(this.ViewModelStore) )
			{
        	    vm.Set(elements, new RetrivalOptions(excludedDomainModels));
        	    vm.Description = "Attention: This deletion can not be undone! \r\n \r\n" + vm.Description;

        	    bool? result = this.GlobalServiceProvider.Resolve<DslEditorViewModelServices::IUIVisualizerService>().ShowDialog("DeleteElementsPopup", vm);
        	    if (!result == true)
        	        return false;

        	    }
            System.GC.Collect();

            // 4. delete referenced model and flush undo/redo stacks
            using (new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
                using (DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Delete referenced model"))
                {
                    refModel.VModell.Delete();
                    transaction.Commit();
                }
            }
            this.ModelData.FlushUndoRedoStacks();

            return true;
		}

        /// <summary>
        /// Ensures that the user can open the selected file and refence the domain model.
        /// </summary>
        /// <returns>True to reference; False otherwise.</returns>
        protected override bool EnsureOpening(string filePath)
		{
			try
            {
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.Load(filePath);

                HtmlAgilityPack.HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//@id");

                // verify that none of the ids is present at the moment
                if (nodes != null)
                    foreach (HtmlAgilityPack.HtmlNode node in nodes)
                    {
                        string value = node.Attributes["id"].Value;
                        if (VModellXTDomainModelIdProvider.Instance.HasVModellKey(value))
                        {
                            DslEditorViewModelServices::IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<DslEditorViewModelServices::IMessageBoxService>();
                            messageBox.ShowInformation("Can not reference the selected model because some of its elements are already included in the currently opened model. (Failed on element '" + node.Name + "').\r\n\r\nHint: This could also be caused by a referenced model in the domain model selected to be referenced.");

                            return false;
                        }
                    }

                // proceed with referenced models
                HtmlAgilityPack.HtmlNode refNode = htmlDocument.DocumentNode.SelectSingleNode("//v-modellvariante/referenzmodell");
                if (refNode != null)
                    foreach (HtmlAgilityPack.HtmlNode n in refNode.ChildNodes)
                    {
                        if (n.Name != "xi:include")
                            continue;

                        string href = n.Attributes["href"].Value;
                        string curPath = href;
                        if (!curPath.Contains(System.IO.Path.VolumeSeparatorChar.ToString()))
                        {
                            curPath = new System.IO.FileInfo(filePath).DirectoryName + System.IO.Path.DirectorySeparatorChar + curPath;
                        }

                        if (System.IO.File.Exists(curPath))
                            if (!EnsureOpening(curPath))
                                return false;
                    }
            }
            catch(System.Exception ex)
            {
                DslEditorViewModelServices::IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<DslEditorViewModelServices::IMessageBoxService>();
                messageBox.ShowInformation("Couldnt parse file: " + ex.Message);

                return false;
            }
            return true;
		}
		#endregion
		
		#region Helper Class
		private class RetrivalOptions : DslEditorModeling::DependenciesRetrivalOptions
		{
			System.Collections.Generic.List<DslModeling::ModelElement> excludedDomainModels;
			
			/// <summary>
        	/// Constructor.
        	/// </summary>
			/// <param name="excludedDomainModels">Excluded domain models </param>
        	public RetrivalOptions(System.Collections.Generic.List<DslModeling::ModelElement> excludedDomainModels) : base()
			{
				this.excludedDomainModels = excludedDomainModels;
			}
			
			/// <summary>
    	    /// Verifies if a specific model element should be excluded or not.
    	    /// </summary>
    	    /// <param name="modelElement">Model element to verify</param>
    	    /// <returns>True if the specified element should be excluded; False otherwise.</returns>
    	    public override bool ShouldExcludeDomainClass(DslModeling::ModelElement modelElement)
    	    {
    	        DslModeling::ModelElement parent = VModellXTElementParentProvider.Instance.GetParentModelElement(modelElement) as DslModeling::ModelElement;								
				if( parent == null )
					return false;
					
				if( excludedDomainModels.Contains(parent) )
					return true;

    	        return false;
    	    }			
			
		}
		#endregion
	}
}

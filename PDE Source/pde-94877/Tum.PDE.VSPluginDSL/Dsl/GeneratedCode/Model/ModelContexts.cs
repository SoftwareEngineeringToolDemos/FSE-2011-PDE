 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class DefaultContextModelContext : DefaultContextModelContextBase
	{
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData"></param>
        public DefaultContextModelContext(DslEditorModeling::ModelData modelData) 
			: base(modelData)
        {
        }	
	}
	
	/// <summary>
	/// Class which represents a model context.
	/// </summary>
	public abstract partial class DefaultContextModelContextBase : DslEditorModeling::ModelContext
	{
		private System.Text.Encoding encodingXml;
		//private DslEditorModeling::ModelValidationController validationController;
		private DslEditorModeling::SerializationResult serializationResult;
        private DslEditorDiagrams::DiagramsModel diagramsModel = null;		

		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData"></param>
        public DefaultContextModelContextBase(DslEditorModeling::ModelData modelData) 
			: base(modelData)
        {
			encodingXml = System.Text.Encoding.GetEncoding("ISO-8859-1");
			
			//validationController = VSPluginDSLValidationController.Instance;
			//validationController.Initialize();			
			serializationResult = new DslEditorModeling::SerializationResult();
        }
		
		/// <summary>
        /// Domain Class ID.
        /// </summary>
		public static readonly System.Guid DomainClassId = new System.Guid("15ae33c0-6c1f-41c0-b1d8-7cddfb0aca13");
		
		/// <summary>
        /// Gets the model context id.
        /// </summary>
        public override System.Guid ModelContextId
        {
            get
			{
				return DomainClassId;
			}
        }
		
		/// <summary>
        /// Gets the name of this model context.
        /// </summary>
        public override string Name
		{
            get
			{
				return "DefaultContext";
			}
        }

        /// <summary>
        /// Gets the titel of the model context.
        /// </summary>
        public override string Titel
        {
            get
			{
				return "Default Context";
			}
        }

        /// <summary>
        /// Gets whether this model context is the default context or not.
        /// </summary>
        public override bool IsDefault
        {
            get
			{
				return true;
			}
        }		
		
		/// <summary>
        /// Gets the current validation controller.
        /// </summary>
        public override DslEditorModeling::ModelValidationController CurrentValidationController 
		{ 
			get{ return VSPluginDSLValidationController.Instance; }
		}		

		/// <summary>
        /// Serialization result.
        /// </summary>
        public override DslEditorModeling::SerializationResult SerializationResult 
		{ 
			get{ return this.serializationResult; }
		}
		
        /// <summary>
        /// Gets or sets the encoding that this doc data is persisted in
		/// </summary>	
        public virtual System.Text.Encoding Encoding 
		{ 
			get
			{
				return encodingXml;
			}
			set
			{
				encodingXml = value;
			}
		}
		
		#region Serialization
		/// <summary>
        /// Loads the domain model from a specified file.
        /// </summary>
		/// <param name="fileName">Filename to load the domain model from.</param>
		/// <param name="isReload"></param>
        protected override void LoadDocument(string fileName, bool isReload)
		{
			this.rootModelElement = null;

			serializationResult = new DslEditorModeling::SerializationResult();
			DslModeling::SerializationResult result = new DslModeling.SerializationResult();
			global::Tum.PDE.VSPluginDSL.DomainModel modelRoot = null;

			// reset post process info
			VSPluginDSLSerializationPostProcessor.Instance.Reset();

			DslModeling::Transaction transaction = this.ModelData.Store.TransactionManager.BeginTransaction("Load model", true);
			try
			{
				modelRoot = global::Tum.PDE.VSPluginDSL.VSPluginDSLSerializationHelper.Instance.LoadModelDomainModel(result, this.ModelData.GetModelPartition(), fileName, null, null, null);

				// post process
				if( modelRoot != null && !serializationResult.Failed)
				{
					VSPluginDSLSerializationPostProcessor.Instance.DoPostProcess(new System.Collections.Generic.List<string>(), result, modelRoot.Store);

				}


				if( !serializationResult.Failed )
					// start validation because UseLoad=true
					ValidateAll();

				// load diagramsModel
				string diagramsFileName = GetDiagramsFileName(fileName);
				if(System.IO.File.Exists(diagramsFileName) )
					diagramsModel = VSPluginDSLDiagramsDSLSerializationHelper.Instance.LoadModel(result, this.ModelData.GetModelPartition(), GetDiagramsFileName(fileName), null, null, null);
				
				if( diagramsModel == null )
					diagramsModel = new DslEditorDiagrams::DiagramsModel(this.ModelData.Store);

				if( !diagramsModel.ContainsDiagram("DesignerDiagram") )
				{
					DesignerDiagram diagramDesignerDiagram = new DesignerDiagram(this.ModelData.Store);
					diagramDesignerDiagram.Name = "DesignerDiagram";
				
					diagramsModel.Diagrams.Add(diagramDesignerDiagram);
				}
				diagramsModel.GetDiagram("DesignerDiagram").Initialize();
				OnPropertyChanged("DesignerDiagram");
				if( !diagramsModel.ContainsDiagram("SpecificElementsDiagramTemplate") )
				{
					SpecificElementsDiagramTemplate diagramSpecificElementsDiagramTemplate = new SpecificElementsDiagramTemplate(this.ModelData.Store);
					diagramSpecificElementsDiagramTemplate.Name = "SpecificElementsDiagramTemplate";
				
					diagramsModel.Diagrams.Add(diagramSpecificElementsDiagramTemplate);
				}
				diagramsModel.GetDiagram("SpecificElementsDiagramTemplate").Initialize();
				OnPropertyChanged("SpecificElementsDiagramTemplate");

				if( result.Failed )
					transaction.Rollback();	
				else
					transaction.Commit();
			}
			catch (System.Exception ex)
			{
                serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(
					VSPluginDSLValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error,
                    ex.Message, fileName, 0, 0));
				transaction.Rollback();	
			}
			// copy messages
			bool bHasMessages = false;
			foreach (DslModeling::SerializationMessage m in result)
        	{
				bHasMessages = true;
			
        	    DslEditorModeling.ModelValidationViolationType kind = DslEditorModeling.ModelValidationViolationType.Error;
        	    if( m.Kind == DslModeling.SerializationMessageKind.Info )
        	        kind = DslEditorModeling.ModelValidationViolationType.Message;
        	    else if( m.Kind == DslModeling.SerializationMessageKind.Warning )
        	        kind = DslEditorModeling.ModelValidationViolationType.Warning;

        	    DslEditorModeling::SerializationMessage message = new DslEditorModeling.SerializationMessage(
        	        VSPluginDSLValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
        	    serializationResult.AddMessage(message);
        	}	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
        	    serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VSPluginDSLValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
        	        VSPluginDSLDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"), fileName, 0, 0));
			}
			else
			{
				this.rootModelElement = modelRoot;
			}
			
			if( !serializationResult.Failed && !bHasMessages )
				// start validation because UseOpen=true
				ValidateAll();
			
		}

        /// <summary>
        /// Loads the domain model from a specified file.  This will not replace the currently loaded domain model.
        /// </summary>
        protected override DslModeling::ModelElement LoadDocumentInternal(string fileName)
		{
			serializationResult = new DslEditorModeling::SerializationResult();
			DslModeling::SerializationResult result = new DslModeling.SerializationResult();
			
			// reset post process info
			VSPluginDSLSerializationPostProcessor.Instance.Reset();

			global::Tum.PDE.VSPluginDSL.DomainModel modelRoot = null;
			modelRoot = global::Tum.PDE.VSPluginDSL.VSPluginDSLSerializationHelper.Instance.LoadModelDomainModel(result, this.ModelData.GetModelPartition(), fileName, null, null, null);

			// post process
			if( modelRoot != null && !serializationResult.Failed)
			{
				VSPluginDSLSerializationPostProcessor.Instance.DoPostProcess(new System.Collections.Generic.List<string>(), result, modelRoot.Store);
			}

			// copy messages
			foreach (DslModeling::SerializationMessage m in result)
            {
                DslEditorModeling.ModelValidationViolationType kind = DslEditorModeling.ModelValidationViolationType.Error;
                if( m.Kind == DslModeling.SerializationMessageKind.Info )
                    kind = DslEditorModeling.ModelValidationViolationType.Message;
                else if( m.Kind == DslModeling.SerializationMessageKind.Warning )
                    kind = DslEditorModeling.ModelValidationViolationType.Warning;

                DslEditorModeling::SerializationMessage message = new DslEditorModeling.SerializationMessage(
                    VSPluginDSLValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
                serializationResult.AddMessage(message);
            }	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
                serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VSPluginDSLValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
                    VSPluginDSLDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"), fileName, 0, 0));
					
				return null;
			}
			else
			{
				return modelRoot;
			}
		}

		/// <summary>
        /// Saves the domain model to a specified filename.
        /// </summary>
        /// <param name="fileName">Filename to save the domain model to.</param>
        protected override void SaveDocument(string fileName)
		{
			serializationResult = new DslEditorModeling::SerializationResult();
			DslModeling::SerializationResult result = new DslModeling.SerializationResult();
			
			global::Tum.PDE.VSPluginDSL.DomainModel modelRoot = (global::Tum.PDE.VSPluginDSL.DomainModel)this.RootElement;
			global::Tum.PDE.VSPluginDSL.VSPluginDSLSerializationHelper.Instance.SaveModelDomainModel(result, modelRoot, fileName, this.Encoding, false);

			// Save Diagrams
			if( this.diagramsModel != null )
			{
				string diagramsFileName = GetDiagramsFileName(fileName);
				if( this.diagramsModel.Diagrams.Count > 0 )
				{
					VSPluginDSLDiagramsDSLSerializationHelper.Instance.SaveModel(result, this.diagramsModel, diagramsFileName, this.Encoding, false);
				}
				else if(System.IO.File.Exists(diagramsFileName) )
					System.IO.File.Delete(diagramsFileName);
			}

			// copy messages
			foreach (DslModeling::SerializationMessage m in result)
            {
                DslEditorModeling.ModelValidationViolationType kind = DslEditorModeling.ModelValidationViolationType.Error;
                if( m.Kind == DslModeling.SerializationMessageKind.Info )
                    kind = DslEditorModeling.ModelValidationViolationType.Message;
                else if( m.Kind == DslModeling.SerializationMessageKind.Warning )
                    kind = DslEditorModeling.ModelValidationViolationType.Warning;

                DslEditorModeling::SerializationMessage message = new DslEditorModeling.SerializationMessage(
                   VSPluginDSLValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
                serializationResult.AddMessage(message);
            }	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Save failed.
				 serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VSPluginDSLValidationMessageIds.SerializationSaveErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
                    VSPluginDSLDomainModel.SingletonResourceManager.GetString("CannotSaveDocument"), fileName, 0, 0));
			}
		}
		
		/// <summary>
        /// Return the model in XML format (SerializationMode.InternalToString).
        /// </summary>
		public override string SerializedModel
		{
			get
			{
				global::Tum.PDE.VSPluginDSL.DomainModel modelRoot = this.RootElement as global::Tum.PDE.VSPluginDSL.DomainModel;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::Tum.PDE.VSPluginDSL.VSPluginDSLSerializationHelper.Instance.GetSerializedModelStringDomainModel(modelRoot, this.Encoding, DslEditorModeling::SerializationMode.InternalToString);
				}
				return modelFile;
			}
		}
		
		/// <summary>
        /// Return the model in XML format (SerializationMode.InternalFullToString).
        /// </summary>
		public override string SerializedFullModel
		{
			get
			{
				global::Tum.PDE.VSPluginDSL.DomainModel modelRoot = this.RootElement as global::Tum.PDE.VSPluginDSL.DomainModel;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::Tum.PDE.VSPluginDSL.VSPluginDSLSerializationHelper.Instance.GetSerializedModelStringDomainModel(modelRoot, this.Encoding, DslEditorModeling::SerializationMode.InternalFullToString);
				}
				return modelFile;
			}
		}		
		
        /// <summary>
        /// Saves the domain model to a specified filename. This serialization is treated as temporarly and as such does
        /// not change the default saving location of the current domain model.
        /// </summary>
        /// <param name="fileName">Filename to save the domain model to.</param>
        protected override void SaveDocumentTemporarly(string fileName)
        {
            DslModeling::SerializationResult result = new DslModeling.SerializationResult();
            global::Tum.PDE.VSPluginDSL.DomainModel modelRoot = (global::Tum.PDE.VSPluginDSL.DomainModel)this.RootElement;
            VSPluginDSLSerializationHelper.Instance.TemporarlySaveModelDomainModel(result, modelRoot, fileName, this.Encoding, false);
        }		
		
		/// <summary>
        /// Computes the fileName to save the diagrams model to from the model file name.
        /// </summary>
        /// <param name="modelFileName">Model file name.</param>
		protected virtual string GetDiagramsFileName(string modelFileName)
		{
			System.IO.FileInfo info = new System.IO.FileInfo(modelFileName);
            return info.FullName.Substring(0, info.FullName.Length - info.Extension.Length) + ".diagrams"; ;
		}		
		#endregion
		
		/// <summary>
        /// Reset.
        /// </summary>
        public override void Reset()
		{
			this.diagramsModel = null;
			
			base.Reset();
		}

		#region Diagrams
		/// <summary>
        /// Gets a specific diagram.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override Microsoft.VisualStudio.Modeling.ModelElement GetDiagram(string name)
		{
            if (diagramsModel == null)
                return null;

			return diagramsModel.GetDiagram(name);
		}
		
	
		/// <summary>
        /// Gets the DesignerDiagram Diagram.
        /// </summary>
		public DesignerDiagram DesignerDiagram
		{
			get
			{
            	if (diagramsModel == null)
                	return null;

				return diagramsModel.GetDiagram("DesignerDiagram") as DesignerDiagram;
			}
			/*set
			{
				this.DesignerDiagramStorage = value;
				OnPropertyChanged("DesignerDiagram");
			}*/
		}		
		
	
		/// <summary>
        /// Gets the SpecificElementsDiagramTemplate Diagram.
        /// </summary>
		public SpecificElementsDiagramTemplate SpecificElementsDiagramTemplate
		{
			get
			{
            	if (diagramsModel == null)
                	return null;

				return diagramsModel.GetDiagram("SpecificElementsDiagramTemplate") as SpecificElementsDiagramTemplate;
			}
			/*set
			{
				this.SpecificElementsDiagramTemplateStorage = value;
				OnPropertyChanged("SpecificElementsDiagramTemplate");
			}*/
		}		
		
		#endregion
	
	}
}

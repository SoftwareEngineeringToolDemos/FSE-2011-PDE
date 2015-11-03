 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.StateMachineDSL
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
			
			//validationController = StateMachineLanguageValidationController.Instance;
			//validationController.Initialize();			
			serializationResult = new DslEditorModeling::SerializationResult();
        }
		
		/// <summary>
        /// Domain Class ID.
        /// </summary>
		public static readonly System.Guid DomainClassId = new System.Guid("9c585556-0578-491d-8f04-2503f6e087e9");
		
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
			get{ return StateMachineLanguageValidationController.Instance; }
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
			global::Tum.StateMachineDSL.StateMachineDomainModel modelRoot = null;

			// reset post process info
			StateMachineLanguageSerializationPostProcessor.Instance.Reset();

			DslModeling::Transaction transaction = this.ModelData.Store.TransactionManager.BeginTransaction("Load model", true);
			try
			{
				modelRoot = global::Tum.StateMachineDSL.StateMachineLanguageSerializationHelper.Instance.LoadModelStateMachineDomainModel(result, this.ModelData.GetModelPartition(), fileName, null, null, null);

				// post process
				if( modelRoot != null && !serializationResult.Failed)
				{
					StateMachineLanguageSerializationPostProcessor.Instance.DoPostProcess(new System.Collections.Generic.List<string>(), result, modelRoot.Store);

				}


				if( !serializationResult.Failed )
					// start validation because UseLoad=true
					ValidateAll();

				// load diagramsModel
				string diagramsFileName = GetDiagramsFileName(fileName);
				if(System.IO.File.Exists(diagramsFileName) )
					diagramsModel = StateMachineLanguageDiagramsDSLSerializationHelper.Instance.LoadModel(result, this.ModelData.GetModelPartition(), GetDiagramsFileName(fileName), null, null, null);
				
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

				if( result.Failed )
					transaction.Rollback();	
				else
					transaction.Commit();
			}
			catch (System.Exception ex)
			{
                serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(
					StateMachineLanguageValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error,
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
        	        StateMachineLanguageValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
        	    serializationResult.AddMessage(message);
        	}	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
        	    serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(StateMachineLanguageValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
        	        StateMachineLanguageDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"), fileName, 0, 0));
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
			StateMachineLanguageSerializationPostProcessor.Instance.Reset();

			global::Tum.StateMachineDSL.StateMachineDomainModel modelRoot = null;
			modelRoot = global::Tum.StateMachineDSL.StateMachineLanguageSerializationHelper.Instance.LoadModelStateMachineDomainModel(result, this.ModelData.GetModelPartition(), fileName, null, null, null);

			// post process
			if( modelRoot != null && !serializationResult.Failed)
			{
				StateMachineLanguageSerializationPostProcessor.Instance.DoPostProcess(new System.Collections.Generic.List<string>(), result, modelRoot.Store);
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
                    StateMachineLanguageValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
                serializationResult.AddMessage(message);
            }	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
                serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(StateMachineLanguageValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
                    StateMachineLanguageDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"), fileName, 0, 0));
					
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
			
			global::Tum.StateMachineDSL.StateMachineDomainModel modelRoot = (global::Tum.StateMachineDSL.StateMachineDomainModel)this.RootElement;
			global::Tum.StateMachineDSL.StateMachineLanguageSerializationHelper.Instance.SaveModelStateMachineDomainModel(result, modelRoot, fileName, this.Encoding, false);

			// Save Diagrams
			if( this.diagramsModel != null )
			{
				string diagramsFileName = GetDiagramsFileName(fileName);
				if( this.diagramsModel.Diagrams.Count > 0 )
				{
					StateMachineLanguageDiagramsDSLSerializationHelper.Instance.SaveModel(result, this.diagramsModel, diagramsFileName, this.Encoding, false);
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
                   StateMachineLanguageValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
                serializationResult.AddMessage(message);
            }	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Save failed.
				 serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(StateMachineLanguageValidationMessageIds.SerializationSaveErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
                    StateMachineLanguageDomainModel.SingletonResourceManager.GetString("CannotSaveDocument"), fileName, 0, 0));
			}
		}
		
		/// <summary>
        /// Return the model in XML format (SerializationMode.InternalToString).
        /// </summary>
		public override string SerializedModel
		{
			get
			{
				global::Tum.StateMachineDSL.StateMachineDomainModel modelRoot = this.RootElement as global::Tum.StateMachineDSL.StateMachineDomainModel;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::Tum.StateMachineDSL.StateMachineLanguageSerializationHelper.Instance.GetSerializedModelStringStateMachineDomainModel(modelRoot, this.Encoding, DslEditorModeling::SerializationMode.InternalToString);
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
				global::Tum.StateMachineDSL.StateMachineDomainModel modelRoot = this.RootElement as global::Tum.StateMachineDSL.StateMachineDomainModel;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::Tum.StateMachineDSL.StateMachineLanguageSerializationHelper.Instance.GetSerializedModelStringStateMachineDomainModel(modelRoot, this.Encoding, DslEditorModeling::SerializationMode.InternalFullToString);
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
            global::Tum.StateMachineDSL.StateMachineDomainModel modelRoot = (global::Tum.StateMachineDSL.StateMachineDomainModel)this.RootElement;
            StateMachineLanguageSerializationHelper.Instance.TemporarlySaveModelStateMachineDomainModel(result, modelRoot, fileName, this.Encoding, false);
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
		
		#endregion
	
	}
}

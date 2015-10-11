 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.VModellXT
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTModelContext : VModellXTModelContextBase
	{
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData"></param>
        public VModellXTModelContext(DslEditorModeling::ModelData modelData) 
			: base(modelData)
        {
        }	
	}
	
	/// <summary>
	/// Class which represents a model context.
	/// </summary>
	public abstract partial class VModellXTModelContextBase : DslEditorModeling::ModelContext
	{
		private System.Text.Encoding encodingXml;
		//private DslEditorModeling::ModelValidationController validationController;
		private DslEditorModeling::SerializationResult serializationResult;
        private DslEditorDiagrams::DiagramsModel diagramsModel = null;		

		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData"></param>
        public VModellXTModelContextBase(DslEditorModeling::ModelData modelData) 
			: base(modelData)
        {
			encodingXml = System.Text.Encoding.GetEncoding("ISO-8859-1");
			
			//validationController = VModellXTValidationController.Instance;
			//validationController.Initialize();			
			serializationResult = new DslEditorModeling::SerializationResult();
        }
		
		/// <summary>
        /// Domain Class ID.
        /// </summary>
		public static readonly System.Guid DomainClassId = new System.Guid("293cbc4e-78cb-4927-801a-a75d0af64d5b");
		
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
				return "VModellXT";
			}
        }

        /// <summary>
        /// Gets the titel of the model context.
        /// </summary>
        public override string Titel
        {
            get
			{
				return "V-Modell XT";
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
			get{ return VModellXTValidationController.Instance; }
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
			global::Tum.VModellXT.VModell modelRoot = null;

			// reset post process info
			VModellXTSerializationPostProcessor.Instance.Reset();

			DslModeling::Transaction transaction = this.ModelData.Store.TransactionManager.BeginTransaction("Load model", true);
			try
			{
				modelRoot = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.LoadModelVModell(result, this.ModelData.GetModelPartition(), fileName, null, null, null);

				// post process
				if( modelRoot != null && !serializationResult.Failed)
				{
					VModellXTSerializationPostProcessor.Instance.DoPostProcess(new System.Collections.Generic.List<string>(), result, modelRoot.Store);

				}


				if( !serializationResult.Failed )
					// start validation because UseLoad=true
					ValidateAll();

				// load diagramsModel
				string diagramsFileName = GetDiagramsFileName(fileName);
				if(System.IO.File.Exists(diagramsFileName) )
					diagramsModel = VModellXTDiagramsDSLSerializationHelper.Instance.LoadModel(result, this.ModelData.GetModelPartition(), GetDiagramsFileName(fileName), null, null, null);
				
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
				if( !diagramsModel.ContainsDiagram("GeneralGrDependencyTemplate") )
				{
					GeneralGrDependencyTemplate diagramGeneralGrDependencyTemplate = new GeneralGrDependencyTemplate(this.ModelData.Store);
					diagramGeneralGrDependencyTemplate.Name = "GeneralGrDependencyTemplate";
				
					diagramsModel.Diagrams.Add(diagramGeneralGrDependencyTemplate);
				}
				diagramsModel.GetDiagram("GeneralGrDependencyTemplate").Initialize();
				OnPropertyChanged("GeneralGrDependencyTemplate");
				if( !diagramsModel.ContainsDiagram("RolleDependencyTemplate") )
				{
					RolleDependencyTemplate diagramRolleDependencyTemplate = new RolleDependencyTemplate(this.ModelData.Store);
					diagramRolleDependencyTemplate.Name = "RolleDependencyTemplate";
				
					diagramsModel.Diagrams.Add(diagramRolleDependencyTemplate);
				}
				diagramsModel.GetDiagram("RolleDependencyTemplate").Initialize();
				OnPropertyChanged("RolleDependencyTemplate");
				if( !diagramsModel.ContainsDiagram("DisziplinGrDependencyTemplate") )
				{
					DisziplinGrDependencyTemplate diagramDisziplinGrDependencyTemplate = new DisziplinGrDependencyTemplate(this.ModelData.Store);
					diagramDisziplinGrDependencyTemplate.Name = "DisziplinGrDependencyTemplate";
				
					diagramsModel.Diagrams.Add(diagramDisziplinGrDependencyTemplate);
				}
				diagramsModel.GetDiagram("DisziplinGrDependencyTemplate").Initialize();
				OnPropertyChanged("DisziplinGrDependencyTemplate");
				if( !diagramsModel.ContainsDiagram("ErzAbhGrDependencyTemplate") )
				{
					ErzAbhGrDependencyTemplate diagramErzAbhGrDependencyTemplate = new ErzAbhGrDependencyTemplate(this.ModelData.Store);
					diagramErzAbhGrDependencyTemplate.Name = "ErzAbhGrDependencyTemplate";
				
					diagramsModel.Diagrams.Add(diagramErzAbhGrDependencyTemplate);
				}
				diagramsModel.GetDiagram("ErzAbhGrDependencyTemplate").Initialize();
				OnPropertyChanged("ErzAbhGrDependencyTemplate");

				if( !diagramsModel.ContainsDiagram("TailoringSED") )
				{
					Tum.VModellXT.Anpassung.TailoringSED diagramTailoringSED = new Tum.VModellXT.Anpassung.TailoringSED(this.ModelData.Store);
					diagramTailoringSED.Name = "TailoringSED";
				
					diagramsModel.Diagrams.Add(diagramTailoringSED);
				}
				diagramsModel.GetDiagram("TailoringSED").Initialize();
				OnPropertyChanged("TailoringSED");

				if( result.Failed )
					transaction.Rollback();	
				else
					transaction.Commit();
			}
			catch (System.Exception ex)
			{
                serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(
					VModellXTValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error,
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
        	        VModellXTValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
        	    serializationResult.AddMessage(message);
        	}	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
        	    serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VModellXTValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
        	        VModellXTDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"), fileName, 0, 0));
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
			VModellXTSerializationPostProcessor.Instance.Reset();

			global::Tum.VModellXT.VModell modelRoot = null;
			modelRoot = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.LoadModelVModell(result, this.ModelData.GetModelPartition(), fileName, null, null, null);

			// post process
			if( modelRoot != null && !serializationResult.Failed)
			{
				VModellXTSerializationPostProcessor.Instance.DoPostProcess(new System.Collections.Generic.List<string>(), result, modelRoot.Store);
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
                    VModellXTValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
                serializationResult.AddMessage(message);
            }	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
                serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VModellXTValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
                    VModellXTDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"), fileName, 0, 0));
					
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
			
			global::Tum.VModellXT.VModell modelRoot = (global::Tum.VModellXT.VModell)this.RootElement;
			global::Tum.VModellXT.VModellXTSerializationHelper.Instance.SaveModelVModell(result, modelRoot, fileName, this.Encoding, false);

			// Save Diagrams
			if( this.diagramsModel != null )
			{
				string diagramsFileName = GetDiagramsFileName(fileName);
				if( this.diagramsModel.Diagrams.Count > 0 )
				{
					VModellXTDiagramsDSLSerializationHelper.Instance.SaveModel(result, this.diagramsModel, diagramsFileName, this.Encoding, false);
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
                   VModellXTValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
                serializationResult.AddMessage(message);
            }	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Save failed.
				 serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VModellXTValidationMessageIds.SerializationSaveErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
                    VModellXTDomainModel.SingletonResourceManager.GetString("CannotSaveDocument"), fileName, 0, 0));
			}
		}
		
		/// <summary>
        /// Return the model in XML format (SerializationMode.InternalToString).
        /// </summary>
		public override string SerializedModel
		{
			get
			{
				global::Tum.VModellXT.VModell modelRoot = this.RootElement as global::Tum.VModellXT.VModell;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.GetSerializedModelStringVModell(modelRoot, this.Encoding, DslEditorModeling::SerializationMode.InternalToString);
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
				global::Tum.VModellXT.VModell modelRoot = this.RootElement as global::Tum.VModellXT.VModell;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.GetSerializedModelStringVModell(modelRoot, this.Encoding, DslEditorModeling::SerializationMode.InternalFullToString);
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
            global::Tum.VModellXT.VModell modelRoot = (global::Tum.VModellXT.VModell)this.RootElement;
            VModellXTSerializationHelper.Instance.TemporarlySaveModelVModell(result, modelRoot, fileName, this.Encoding, false);
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
        /// Gets the GeneralGrDependencyTemplate Diagram.
        /// </summary>
		public GeneralGrDependencyTemplate GeneralGrDependencyTemplate
		{
			get
			{
            	if (diagramsModel == null)
                	return null;

				return diagramsModel.GetDiagram("GeneralGrDependencyTemplate") as GeneralGrDependencyTemplate;
			}
			/*set
			{
				this.GeneralGrDependencyTemplateStorage = value;
				OnPropertyChanged("GeneralGrDependencyTemplate");
			}*/
		}		
		
	
		/// <summary>
        /// Gets the RolleDependencyTemplate Diagram.
        /// </summary>
		public RolleDependencyTemplate RolleDependencyTemplate
		{
			get
			{
            	if (diagramsModel == null)
                	return null;

				return diagramsModel.GetDiagram("RolleDependencyTemplate") as RolleDependencyTemplate;
			}
			/*set
			{
				this.RolleDependencyTemplateStorage = value;
				OnPropertyChanged("RolleDependencyTemplate");
			}*/
		}		
		
	
		/// <summary>
        /// Gets the DisziplinGrDependencyTemplate Diagram.
        /// </summary>
		public DisziplinGrDependencyTemplate DisziplinGrDependencyTemplate
		{
			get
			{
            	if (diagramsModel == null)
                	return null;

				return diagramsModel.GetDiagram("DisziplinGrDependencyTemplate") as DisziplinGrDependencyTemplate;
			}
			/*set
			{
				this.DisziplinGrDependencyTemplateStorage = value;
				OnPropertyChanged("DisziplinGrDependencyTemplate");
			}*/
		}		
		
	
		/// <summary>
        /// Gets the ErzAbhGrDependencyTemplate Diagram.
        /// </summary>
		public ErzAbhGrDependencyTemplate ErzAbhGrDependencyTemplate
		{
			get
			{
            	if (diagramsModel == null)
                	return null;

				return diagramsModel.GetDiagram("ErzAbhGrDependencyTemplate") as ErzAbhGrDependencyTemplate;
			}
			/*set
			{
				this.ErzAbhGrDependencyTemplateStorage = value;
				OnPropertyChanged("ErzAbhGrDependencyTemplate");
			}*/
		}		
		

		/// <summary>
        /// Gets the TailoringSED Diagram.
        /// </summary>
		public Tum.VModellXT.Anpassung.TailoringSED TailoringSED
		{
			get
			{
				return diagramsModel.GetDiagram("TailoringSED") as Tum.VModellXT.Anpassung.TailoringSED;
			}
		}

		#endregion
	
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTMustertexteModelContext : VModellXTMustertexteModelContextBase
	{
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData"></param>
        public VModellXTMustertexteModelContext(DslEditorModeling::ModelData modelData) 
			: base(modelData)
        {
        }	
	}
	
	/// <summary>
	/// Class which represents a model context.
	/// </summary>
	public abstract partial class VModellXTMustertexteModelContextBase : DslEditorModeling::ModelContext
	{
		private System.Text.Encoding encodingXml;
		//private DslEditorModeling::ModelValidationController validationController;
		private DslEditorModeling::SerializationResult serializationResult;
        private DslEditorDiagrams::DiagramsModel diagramsModel = null;		

		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData"></param>
        public VModellXTMustertexteModelContextBase(DslEditorModeling::ModelData modelData) 
			: base(modelData)
        {
			encodingXml = System.Text.Encoding.GetEncoding("ISO-8859-1");
			
			//validationController = VModellXTValidationController.Instance;
			//validationController.Initialize();			
			serializationResult = new DslEditorModeling::SerializationResult();
        }
		
		/// <summary>
        /// Domain Class ID.
        /// </summary>
		public static readonly System.Guid DomainClassId = new System.Guid("757ad01b-407e-4a5e-99c7-f66acc367ec0");
		
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
				return "VModellXTMustertexte";
			}
        }

        /// <summary>
        /// Gets the titel of the model context.
        /// </summary>
        public override string Titel
        {
            get
			{
				return "V-Modell XT Mustertexte";
			}
        }

        /// <summary>
        /// Gets whether this model context is the default context or not.
        /// </summary>
        public override bool IsDefault
        {
            get
			{
				return false;
			}
        }		
		
		/// <summary>
        /// Gets the current validation controller.
        /// </summary>
        public override DslEditorModeling::ModelValidationController CurrentValidationController 
		{ 
			get{ return VModellXTValidationController.Instance; }
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
			global::Tum.VModellXT.Musterbibliothek modelRoot = null;

			// reset post process info
			VModellXTSerializationPostProcessor.Instance.Reset();

			DslModeling::Transaction transaction = this.ModelData.Store.TransactionManager.BeginTransaction("Load model", true);
			try
			{
				modelRoot = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.LoadModelMusterbibliothek(result, this.ModelData.GetModelPartition(), fileName, null, null, null);

				// post process
				if( modelRoot != null && !serializationResult.Failed)
				{
					VModellXTSerializationPostProcessor.Instance.DoPostProcess(new System.Collections.Generic.List<string>(), result, modelRoot.Store);

				}


				if( !serializationResult.Failed )
					// start validation because UseLoad=true
					ValidateAll();

				// load diagramsModel
				string diagramsFileName = GetDiagramsFileName(fileName);
				if(System.IO.File.Exists(diagramsFileName) )
					diagramsModel = VModellXTDiagramsDSLSerializationHelper.Instance.LoadModel(result, this.ModelData.GetModelPartition(), GetDiagramsFileName(fileName), null, null, null);
				
				if( diagramsModel == null )
					diagramsModel = new DslEditorDiagrams::DiagramsModel(this.ModelData.Store);

				if( !diagramsModel.ContainsDiagram("DesignerDiagramMustertexte") )
				{
					DesignerDiagramMustertexte diagramDesignerDiagramMustertexte = new DesignerDiagramMustertexte(this.ModelData.Store);
					diagramDesignerDiagramMustertexte.Name = "DesignerDiagramMustertexte";
				
					diagramsModel.Diagrams.Add(diagramDesignerDiagramMustertexte);
				}
				diagramsModel.GetDiagram("DesignerDiagramMustertexte").Initialize();
				OnPropertyChanged("DesignerDiagramMustertexte");

				if( result.Failed )
					transaction.Rollback();	
				else
					transaction.Commit();
			}
			catch (System.Exception ex)
			{
                serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(
					VModellXTValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error,
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
        	        VModellXTValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
        	    serializationResult.AddMessage(message);
        	}	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
        	    serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VModellXTValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
        	        VModellXTDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"), fileName, 0, 0));
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
			VModellXTSerializationPostProcessor.Instance.Reset();

			global::Tum.VModellXT.Musterbibliothek modelRoot = null;
			modelRoot = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.LoadModelMusterbibliothek(result, this.ModelData.GetModelPartition(), fileName, null, null, null);

			// post process
			if( modelRoot != null && !serializationResult.Failed)
			{
				VModellXTSerializationPostProcessor.Instance.DoPostProcess(new System.Collections.Generic.List<string>(), result, modelRoot.Store);
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
                    VModellXTValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
                serializationResult.AddMessage(message);
            }	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
                serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VModellXTValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
                    VModellXTDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"), fileName, 0, 0));
					
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
			
			global::Tum.VModellXT.Musterbibliothek modelRoot = (global::Tum.VModellXT.Musterbibliothek)this.RootElement;
			global::Tum.VModellXT.VModellXTSerializationHelper.Instance.SaveModelMusterbibliothek(result, modelRoot, fileName, this.Encoding, false);

			// Save Diagrams
			if( this.diagramsModel != null )
			{
				string diagramsFileName = GetDiagramsFileName(fileName);
				if( this.diagramsModel.Diagrams.Count > 0 )
				{
					VModellXTDiagramsDSLSerializationHelper.Instance.SaveModel(result, this.diagramsModel, diagramsFileName, this.Encoding, false);
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
                   VModellXTValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
                serializationResult.AddMessage(message);
            }	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Save failed.
				 serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VModellXTValidationMessageIds.SerializationSaveErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
                    VModellXTDomainModel.SingletonResourceManager.GetString("CannotSaveDocument"), fileName, 0, 0));
			}
		}
		
		/// <summary>
        /// Return the model in XML format (SerializationMode.InternalToString).
        /// </summary>
		public override string SerializedModel
		{
			get
			{
				global::Tum.VModellXT.Musterbibliothek modelRoot = this.RootElement as global::Tum.VModellXT.Musterbibliothek;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.GetSerializedModelStringMusterbibliothek(modelRoot, this.Encoding, DslEditorModeling::SerializationMode.InternalToString);
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
				global::Tum.VModellXT.Musterbibliothek modelRoot = this.RootElement as global::Tum.VModellXT.Musterbibliothek;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.GetSerializedModelStringMusterbibliothek(modelRoot, this.Encoding, DslEditorModeling::SerializationMode.InternalFullToString);
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
            global::Tum.VModellXT.Musterbibliothek modelRoot = (global::Tum.VModellXT.Musterbibliothek)this.RootElement;
            VModellXTSerializationHelper.Instance.TemporarlySaveModelMusterbibliothek(result, modelRoot, fileName, this.Encoding, false);
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
        /// Gets the DesignerDiagramMustertexte Diagram.
        /// </summary>
		public DesignerDiagramMustertexte DesignerDiagramMustertexte
		{
			get
			{
            	if (diagramsModel == null)
                	return null;

				return diagramsModel.GetDiagram("DesignerDiagramMustertexte") as DesignerDiagramMustertexte;
			}
			/*set
			{
				this.DesignerDiagramMustertexteStorage = value;
				OnPropertyChanged("DesignerDiagramMustertexte");
			}*/
		}		
		
		#endregion
	
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VariantenkonfigModelContext : VariantenkonfigModelContextBase
	{
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData"></param>
        public VariantenkonfigModelContext(DslEditorModeling::ModelData modelData) 
			: base(modelData)
        {
        }	
	}
	
	/// <summary>
	/// Class which represents a model context.
	/// </summary>
	public abstract partial class VariantenkonfigModelContextBase : DslEditorModeling::ModelContext
	{
		private System.Text.Encoding encodingXml;
		//private DslEditorModeling::ModelValidationController validationController;
		private DslEditorModeling::SerializationResult serializationResult;
        private DslEditorDiagrams::DiagramsModel diagramsModel = null;		

		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData"></param>
        public VariantenkonfigModelContextBase(DslEditorModeling::ModelData modelData) 
			: base(modelData)
        {
			encodingXml = System.Text.Encoding.GetEncoding("ISO-8859-1");
			
			//validationController = VModellXTValidationController.Instance;
			//validationController.Initialize();			
			serializationResult = new DslEditorModeling::SerializationResult();
        }
		
		/// <summary>
        /// Domain Class ID.
        /// </summary>
		public static readonly System.Guid DomainClassId = new System.Guid("dffe13c9-c778-4b4c-b11f-6c7519f2f2f0");
		
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
				return "Variantenkonfig";
			}
        }

        /// <summary>
        /// Gets the titel of the model context.
        /// </summary>
        public override string Titel
        {
            get
			{
				return "Variantenkonfig";
			}
        }

        /// <summary>
        /// Gets whether this model context is the default context or not.
        /// </summary>
        public override bool IsDefault
        {
            get
			{
				return false;
			}
        }		
		
		/// <summary>
        /// Gets the current validation controller.
        /// </summary>
        public override DslEditorModeling::ModelValidationController CurrentValidationController 
		{ 
			get{ return VModellXTValidationController.Instance; }
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
			global::Tum.VModellXT.Varianten modelRoot = null;

			// reset post process info
			VModellXTSerializationPostProcessor.Instance.Reset();

			DslModeling::Transaction transaction = this.ModelData.Store.TransactionManager.BeginTransaction("Load model", true);
			try
			{
				modelRoot = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.LoadModelVarianten(result, this.ModelData.GetModelPartition(), fileName, null, null, null);

				// post process
				if( modelRoot != null && !serializationResult.Failed)
				{
					VModellXTSerializationPostProcessor.Instance.DoPostProcess(new System.Collections.Generic.List<string>(), result, modelRoot.Store);

				}


				if( !serializationResult.Failed )
					// start validation because UseLoad=true
					ValidateAll();

				// load diagramsModel
				string diagramsFileName = GetDiagramsFileName(fileName);
				if(System.IO.File.Exists(diagramsFileName) )
					diagramsModel = VModellXTDiagramsDSLSerializationHelper.Instance.LoadModel(result, this.ModelData.GetModelPartition(), GetDiagramsFileName(fileName), null, null, null);
				
				if( diagramsModel == null )
					diagramsModel = new DslEditorDiagrams::DiagramsModel(this.ModelData.Store);

				if( !diagramsModel.ContainsDiagram("DesignerDiagramVariantenkonfig") )
				{
					DesignerDiagramVariantenkonfig diagramDesignerDiagramVariantenkonfig = new DesignerDiagramVariantenkonfig(this.ModelData.Store);
					diagramDesignerDiagramVariantenkonfig.Name = "DesignerDiagramVariantenkonfig";
				
					diagramsModel.Diagrams.Add(diagramDesignerDiagramVariantenkonfig);
				}
				diagramsModel.GetDiagram("DesignerDiagramVariantenkonfig").Initialize();
				OnPropertyChanged("DesignerDiagramVariantenkonfig");

				if( result.Failed )
					transaction.Rollback();	
				else
					transaction.Commit();
			}
			catch (System.Exception ex)
			{
                serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(
					VModellXTValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error,
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
        	        VModellXTValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
        	    serializationResult.AddMessage(message);
        	}	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
        	    serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VModellXTValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
        	        VModellXTDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"), fileName, 0, 0));
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
			VModellXTSerializationPostProcessor.Instance.Reset();

			global::Tum.VModellXT.Varianten modelRoot = null;
			modelRoot = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.LoadModelVarianten(result, this.ModelData.GetModelPartition(), fileName, null, null, null);

			// post process
			if( modelRoot != null && !serializationResult.Failed)
			{
				VModellXTSerializationPostProcessor.Instance.DoPostProcess(new System.Collections.Generic.List<string>(), result, modelRoot.Store);
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
                    VModellXTValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
                serializationResult.AddMessage(message);
            }	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Load failed, can't open the file.
                serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VModellXTValidationMessageIds.SerializationLoadErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
                    VModellXTDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"), fileName, 0, 0));
					
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
			
			global::Tum.VModellXT.Varianten modelRoot = (global::Tum.VModellXT.Varianten)this.RootElement;
			global::Tum.VModellXT.VModellXTSerializationHelper.Instance.SaveModelVarianten(result, modelRoot, fileName, this.Encoding, false);

			// Save Diagrams
			if( this.diagramsModel != null )
			{
				string diagramsFileName = GetDiagramsFileName(fileName);
				if( this.diagramsModel.Diagrams.Count > 0 )
				{
					VModellXTDiagramsDSLSerializationHelper.Instance.SaveModel(result, this.diagramsModel, diagramsFileName, this.Encoding, false);
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
                   VModellXTValidationMessageIds.SerializationMessageId, kind, m.Message, m.Location, m.Line, m.Column);
                serializationResult.AddMessage(message);
            }	
			serializationResult.Failed = result.Failed;

			if (serializationResult.Failed)
			{	
				// Save failed.
				 serializationResult.AddMessage(new DslEditorModeling::SerializationMessage(VModellXTValidationMessageIds.SerializationSaveErrorId, DslEditorModeling::ModelValidationViolationType.Error, 
                    VModellXTDomainModel.SingletonResourceManager.GetString("CannotSaveDocument"), fileName, 0, 0));
			}
		}
		
		/// <summary>
        /// Return the model in XML format (SerializationMode.InternalToString).
        /// </summary>
		public override string SerializedModel
		{
			get
			{
				global::Tum.VModellXT.Varianten modelRoot = this.RootElement as global::Tum.VModellXT.Varianten;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.GetSerializedModelStringVarianten(modelRoot, this.Encoding, DslEditorModeling::SerializationMode.InternalToString);
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
				global::Tum.VModellXT.Varianten modelRoot = this.RootElement as global::Tum.VModellXT.Varianten;
				string modelFile = string.Empty;
				if (modelRoot != null)
				{
					modelFile = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.GetSerializedModelStringVarianten(modelRoot, this.Encoding, DslEditorModeling::SerializationMode.InternalFullToString);
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
            global::Tum.VModellXT.Varianten modelRoot = (global::Tum.VModellXT.Varianten)this.RootElement;
            VModellXTSerializationHelper.Instance.TemporarlySaveModelVarianten(result, modelRoot, fileName, this.Encoding, false);
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
        /// Gets the DesignerDiagramVariantenkonfig Diagram.
        /// </summary>
		public DesignerDiagramVariantenkonfig DesignerDiagramVariantenkonfig
		{
			get
			{
            	if (diagramsModel == null)
                	return null;

				return diagramsModel.GetDiagram("DesignerDiagramVariantenkonfig") as DesignerDiagramVariantenkonfig;
			}
			/*set
			{
				this.DesignerDiagramVariantenkonfigStorage = value;
				OnPropertyChanged("DesignerDiagramVariantenkonfig");
			}*/
		}		
		
		#endregion
	
	}
}

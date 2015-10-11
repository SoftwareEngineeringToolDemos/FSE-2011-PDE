 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.VModellXT
{
	/// <summary>
    /// Groups logic for model validation.
    /// </summary>
	public partial class VModellXTValidationController : DslEditorModeling::ModelValidationController
	{
		#region Singleton Instance
		private static VModellXTValidationController validationController = null;
        private static object domainModelValidationLock = new object();
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTValidationController Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
				lock(domainModelValidationLock)
				{
					if( validationController == null )
					{
						validationController = new VModellXTValidationController();
						
						// initialize
						VModellXTValidationController.Initialize(validationController, new System.Collections.Generic.List<string>());
					}
				}
				
				return validationController;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>		
		private VModellXTValidationController() : base()
		{	
		}
        #endregion
	
		#region Initialization		
        /// <summary>
        /// Initializes the static Validation map as well as the Validation is enabled fields in the actual instance of this class.
        /// </summary>
        /// <param name="controller">Controller to initalize</param>
        /// <param name="discardController">Validation controllers to discard.</param>
        public static void Initialize(DslEditorModeling::ModelValidationController controller, System.Collections.Generic.List<string> discardController)
		{
			InitializeType(controller, typeof(global::Tum.VModellXT.VModell));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvariante));
			InitializeType(controller, typeof(global::Tum.VModellXT.Referenzmodell));
			InitializeType(controller, typeof(global::Tum.VModellXT.Musterbibliothek));
			InitializeType(controller, typeof(global::Tum.VModellXT.Mustergruppe));
			InitializeType(controller, typeof(global::Tum.VModellXT.Themenmuster));
			InitializeType(controller, typeof(global::Tum.VModellXT.Mustertext));
			InitializeType(controller, typeof(global::Tum.VModellXT.Zusatzthema));
			InitializeType(controller, typeof(global::Tum.VModellXT.Varianten));
			InitializeType(controller, typeof(global::Tum.VModellXT.Variante));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellHasVModellvariante));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasVModellStruktur));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasTextbausteine));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasRollen));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasAblaufbausteine));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasProjekttypen));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasVortailoring));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasProjektmerkmale));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasGlossar));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasAbkuerzungen));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasQuellen));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen));
			InitializeType(controller, typeof(global::Tum.VModellXT.VModellvarianteHasReferenzmodell));
			InitializeType(controller, typeof(global::Tum.VModellXT.ReferenzmodellHasVModell));
			InitializeType(controller, typeof(global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante));
			InitializeType(controller, typeof(global::Tum.VModellXT.MusterbibliothekHasMustergruppe));
			InitializeType(controller, typeof(global::Tum.VModellXT.MustergruppeHasThemenmuster));
			InitializeType(controller, typeof(global::Tum.VModellXT.ThemenmusterReferencesThema));
			InitializeType(controller, typeof(global::Tum.VModellXT.ThemenmusterReferencesUnterthema));
			InitializeType(controller, typeof(global::Tum.VModellXT.ThemenmusterHasMustertext));
			InitializeType(controller, typeof(global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget));
			InitializeType(controller, typeof(global::Tum.VModellXT.ThemenmusterHasZusatzthema));
			InitializeType(controller, typeof(global::Tum.VModellXT.ZusatzthemaHasMustertext));
			InitializeType(controller, typeof(global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget));
			InitializeType(controller, typeof(global::Tum.VModellXT.MusterbibliothekHasVModell));
			InitializeType(controller, typeof(global::Tum.VModellXT.VariantenHasVariante));
			InitializeType(controller, typeof(global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget));

			// extern controller
			discardController.Add("global::Tum.VModellXT.VModellXT");

			if( !discardController.Contains("global::Tum.VModellXT.Basis.VModellXTBasis") )
				global::Tum.VModellXT.Basis.VModellXTBasisValidationController.Initialize(controller, discardController);
			
			if( !discardController.Contains("global::Tum.VModellXT.Statik.VModellXTStatik") )
				global::Tum.VModellXT.Statik.VModellXTStatikValidationController.Initialize(controller, discardController);
			
			if( !discardController.Contains("global::Tum.VModellXT.Dynamik.VModellXTDynamik") )
				global::Tum.VModellXT.Dynamik.VModellXTDynamikValidationController.Initialize(controller, discardController);
			
			if( !discardController.Contains("global::Tum.VModellXT.Anpassung.VModellXTAnpassung") )
				global::Tum.VModellXT.Anpassung.VModellXTAnpassungValidationController.Initialize(controller, discardController);
			
			if( !discardController.Contains("global::Tum.VModellXT.Konventionsabbildungen.VModellXTKonventionsabbildungen") )
				global::Tum.VModellXT.Konventionsabbildungen.VModellXTKonventionsabbildungenValidationController.Initialize(controller, discardController);
			
			if( !discardController.Contains("global::Tum.VModellXT.Aenderungsoperationen.VModellXTAenderungesoperationen") )
				global::Tum.VModellXT.Aenderungsoperationen.VModellXTAenderungesoperationenValidationController.Initialize(controller, discardController);
			
		}
		#endregion
	}
}

namespace Tum.VModellXT
{
	/// <summary>
    /// Ids identifying model validation messages.
    /// </summary>
	public partial class VModellXTValidationMessageIds : DslEditorModeling::ModelValidationMessageIds
	{
		#region Property Ids
		/// <summary>
    	/// VModellvariante_Name error ID
    	/// </summary>
		public const string VModellvariante_Name = "VModellvariante.Name";
		/// <summary>
    	/// VModellvariante_Version error ID
    	/// </summary>
		public const string VModellvariante_Version = "VModellvariante.Version";
		/// <summary>
    	/// VModellvariante_VersionIntern error ID
    	/// </summary>
		public const string VModellvariante_VersionIntern = "VModellvariante.VersionIntern";
		/// <summary>
    	/// VModellvariante_CopyrightKurz error ID
    	/// </summary>
		public const string VModellvariante_CopyrightKurz = "VModellvariante.CopyrightKurz";
		/// <summary>
    	/// VModellvariante_CopyrightLang error ID
    	/// </summary>
		public const string VModellvariante_CopyrightLang = "VModellvariante.CopyrightLang";
		/// <summary>
    	/// Mustergruppe_Name error ID
    	/// </summary>
		public const string Mustergruppe_Name = "Mustergruppe.Name";
		/// <summary>
    	/// Themenmuster_Name error ID
    	/// </summary>
		public const string Themenmuster_Name = "Themenmuster.Name";
		/// <summary>
    	/// Mustertext_Name error ID
    	/// </summary>
		public const string Mustertext_Name = "Mustertext.Name";
		/// <summary>
    	/// Mustertext_Standardauswahl error ID
    	/// </summary>
		public const string Mustertext_Standardauswahl = "Mustertext.Standardauswahl";
		/// <summary>
    	/// Mustertext_Text error ID
    	/// </summary>
		public const string Mustertext_Text = "Mustertext.Text";
		/// <summary>
    	/// Zusatzthema_Name error ID
    	/// </summary>
		public const string Zusatzthema_Name = "Zusatzthema.Name";
		/// <summary>
    	/// Zusatzthema_Standardauswahl error ID
    	/// </summary>
		public const string Zusatzthema_Standardauswahl = "Zusatzthema.Standardauswahl";
		/// <summary>
    	/// Variante_Name error ID
    	/// </summary>
		public const string Variante_Name = "Variante.Name";
		/// <summary>
    	/// Variante_Verzeichnis error ID
    	/// </summary>
		public const string Variante_Verzeichnis = "Variante.Verzeichnis";
		/// <summary>
    	/// Variante_Dateiname error ID
    	/// </summary>
		public const string Variante_Dateiname = "Variante.Dateiname";
		#endregion
		
		#region Relationship Ids
		/// <summary>
    	/// VModellvarianteHasVModellStruktur_VModellStruktur error ID
    	/// </summary>
		public const string VModellvarianteHasVModellStruktur_VModellStruktur = "VModellvarianteHasVModellStruktur.VModellStruktur";
		/// <summary>
    	/// VModellvarianteHasTextbausteine_Textbausteine error ID
    	/// </summary>
		public const string VModellvarianteHasTextbausteine_Textbausteine = "VModellvarianteHasTextbausteine.Textbausteine";
		/// <summary>
    	/// VModellvarianteHasVorgehensbausteine_Vorgehensbausteine error ID
    	/// </summary>
		public const string VModellvarianteHasVorgehensbausteine_Vorgehensbausteine = "VModellvarianteHasVorgehensbausteine.Vorgehensbausteine";
		/// <summary>
    	/// VModellvarianteHasRollen_Rollen error ID
    	/// </summary>
		public const string VModellvarianteHasRollen_Rollen = "VModellvarianteHasRollen.Rollen";
		/// <summary>
    	/// VModellvarianteHasPDSSpezifikationen_PDSSpezifikationen error ID
    	/// </summary>
		public const string VModellvarianteHasPDSSpezifikationen_PDSSpezifikationen = "VModellvarianteHasPDSSpezifikationen.PDSSpezifikationen";
		/// <summary>
    	/// VModellvarianteHasAblaufbausteine_Ablaufbausteine error ID
    	/// </summary>
		public const string VModellvarianteHasAblaufbausteine_Ablaufbausteine = "VModellvarianteHasAblaufbausteine.Ablaufbausteine";
		/// <summary>
    	/// VModellvarianteHasAblaufbausteinspezifikationen_Ablaufbausteinspezifikationen error ID
    	/// </summary>
		public const string VModellvarianteHasAblaufbausteinspezifikationen_Ablaufbausteinspezifikationen = "VModellvarianteHasAblaufbausteinspezifikationen.Ablaufbausteinspezifikationen";
		/// <summary>
    	/// VModellvarianteHasProjekttypen_Projekttypen error ID
    	/// </summary>
		public const string VModellvarianteHasProjekttypen_Projekttypen = "VModellvarianteHasProjekttypen.Projekttypen";
		/// <summary>
    	/// VModellvarianteHasProjekttypvarianten_Projekttypvarianten error ID
    	/// </summary>
		public const string VModellvarianteHasProjekttypvarianten_Projekttypvarianten = "VModellvarianteHasProjekttypvarianten.Projekttypvarianten";
		/// <summary>
    	/// VModellvarianteHasVortailoring_Vortailoring error ID
    	/// </summary>
		public const string VModellvarianteHasVortailoring_Vortailoring = "VModellvarianteHasVortailoring.Vortailoring";
		/// <summary>
    	/// VModellvarianteHasEntscheidungspunkte_Entscheidungspunkte error ID
    	/// </summary>
		public const string VModellvarianteHasEntscheidungspunkte_Entscheidungspunkte = "VModellvarianteHasEntscheidungspunkte.Entscheidungspunkte";
		/// <summary>
    	/// VModellvarianteHasProjektmerkmale_Projektmerkmale error ID
    	/// </summary>
		public const string VModellvarianteHasProjektmerkmale_Projektmerkmale = "VModellvarianteHasProjektmerkmale.Projektmerkmale";
		/// <summary>
    	/// VModellvarianteHasKonventionsabbildungen_Konventionsabbildungen error ID
    	/// </summary>
		public const string VModellvarianteHasKonventionsabbildungen_Konventionsabbildungen = "VModellvarianteHasKonventionsabbildungen.Konventionsabbildungen";
		/// <summary>
    	/// VModellvarianteHasMethodenreferenzen_Methodenreferenzen error ID
    	/// </summary>
		public const string VModellvarianteHasMethodenreferenzen_Methodenreferenzen = "VModellvarianteHasMethodenreferenzen.Methodenreferenzen";
		/// <summary>
    	/// VModellvarianteHasWerkzeugreferenzen_Werkzeugreferenzen error ID
    	/// </summary>
		public const string VModellvarianteHasWerkzeugreferenzen_Werkzeugreferenzen = "VModellvarianteHasWerkzeugreferenzen.Werkzeugreferenzen";
		/// <summary>
    	/// VModellvarianteHasGlossar_Glossar error ID
    	/// </summary>
		public const string VModellvarianteHasGlossar_Glossar = "VModellvarianteHasGlossar.Glossar";
		/// <summary>
    	/// VModellvarianteHasAbkuerzungen_Abkuerzungen error ID
    	/// </summary>
		public const string VModellvarianteHasAbkuerzungen_Abkuerzungen = "VModellvarianteHasAbkuerzungen.Abkuerzungen";
		/// <summary>
    	/// VModellvarianteHasQuellen_Quellen error ID
    	/// </summary>
		public const string VModellvarianteHasQuellen_Quellen = "VModellvarianteHasQuellen.Quellen";
		/// <summary>
    	/// VModellvarianteHasAenderungsoperationen_Aenderungsoperationen error ID
    	/// </summary>
		public const string VModellvarianteHasAenderungsoperationen_Aenderungsoperationen = "VModellvarianteHasAenderungsoperationen.Aenderungsoperationen";
		/// <summary>
    	/// VModellvarianteHasReferenzmodell_Referenzmodell error ID
    	/// </summary>
		public const string VModellvarianteHasReferenzmodell_Referenzmodell = "VModellvarianteHasReferenzmodell.Referenzmodell";
		/// <summary>
    	/// ReferenzmodellHasVModell_VModell error ID
    	/// </summary>
		public const string ReferenzmodellHasVModell_VModell = "ReferenzmodellHasVModell.VModell";
		/// <summary>
    	/// ReferenzmodellReferencesVModellvariante_VModellvariante error ID
    	/// </summary>
		public const string ReferenzmodellReferencesVModellvariante_VModellvariante = "ReferenzmodellReferencesVModellvariante.VModellvariante";
		/// <summary>
    	/// MusterbibliothekHasVModell_VModell error ID
    	/// </summary>
		public const string MusterbibliothekHasVModell_VModell = "MusterbibliothekHasVModell.VModell";
		/// <summary>
    	/// VarianteSourceReferencesVarianteTarget_VarianteTarget error ID
    	/// </summary>
		public const string VarianteSourceReferencesVarianteTarget_VarianteTarget = "VarianteSourceReferencesVarianteTarget.VarianteTarget";
		#endregion		
	}
}

namespace Tum.VModellXT
{
	/// <summary>
    /// Partial class used to validate VModellvariante.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class VModellvariante
	{
		#region Validate
		/// <summary>
   		/// Automatically validates VModellvariante.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateVModellvariante(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvariante_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
			// validate required attribute Version
			if( System.String.IsNullOrEmpty(this.Version) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvariante_Version, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Version' has no value although it is required", this));
			}
			// validate required attribute VersionIntern
			if( System.String.IsNullOrEmpty(this.VersionIntern) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvariante_VersionIntern, DslEditorModeling::ModelValidationViolationType.Error, "Property 'VersionIntern' has no value although it is required", this));
			}
			// validate required attribute CopyrightKurz
			if( System.String.IsNullOrEmpty(this.CopyrightKurz) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvariante_CopyrightKurz, DslEditorModeling::ModelValidationViolationType.Error, "Property 'CopyrightKurz' has no value although it is required", this));
			}
			// validate required attribute CopyrightLang
			if( this.CopyrightLang == null )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvariante_CopyrightLang, DslEditorModeling::ModelValidationViolationType.Error, "Property 'CopyrightLang' has no value although it is required", this));
			}

			// validate embedding relationship from VModellvariante to VModellStruktur
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasVModellStruktur> allMVModellvarianteHasVModellStrukturInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVModellStruktur>(this, global::Tum.VModellXT.VModellvarianteHasVModellStruktur.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasVModellStrukturInstances0.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasVModellStruktur_VModellStruktur, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type VModellStruktur is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Textbausteine
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasTextbausteine> allMVModellvarianteHasTextbausteineInstances1 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasTextbausteine>(this, global::Tum.VModellXT.VModellvarianteHasTextbausteine.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasTextbausteineInstances1.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasTextbausteine_Textbausteine, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Textbausteine is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Vorgehensbausteine
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine> allMVModellvarianteHasVorgehensbausteineInstances2 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine>(this, global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasVorgehensbausteineInstances2.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasVorgehensbausteine_Vorgehensbausteine, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Vorgehensbausteine is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Rollen
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasRollen> allMVModellvarianteHasRollenInstances3 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasRollen>(this, global::Tum.VModellXT.VModellvarianteHasRollen.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasRollenInstances3.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasRollen_Rollen, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Rollen is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to PDSSpezifikationen
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen> allMVModellvarianteHasPDSSpezifikationenInstances4 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen>(this, global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasPDSSpezifikationenInstances4.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasPDSSpezifikationen_PDSSpezifikationen, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type PDSSpezifikationen is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Ablaufbausteine
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine> allMVModellvarianteHasAblaufbausteineInstances5 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine>(this, global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasAblaufbausteineInstances5.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasAblaufbausteine_Ablaufbausteine, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Ablaufbausteine is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Ablaufbausteinspezifikationen
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen> allMVModellvarianteHasAblaufbausteinspezifikationenInstances6 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen>(this, global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasAblaufbausteinspezifikationenInstances6.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasAblaufbausteinspezifikationen_Ablaufbausteinspezifikationen, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Ablaufbausteinspezifikationen is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Projekttypen
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasProjekttypen> allMVModellvarianteHasProjekttypenInstances7 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjekttypen>(this, global::Tum.VModellXT.VModellvarianteHasProjekttypen.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasProjekttypenInstances7.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasProjekttypen_Projekttypen, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Projekttypen is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Projekttypvarianten
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten> allMVModellvarianteHasProjekttypvariantenInstances8 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten>(this, global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasProjekttypvariantenInstances8.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasProjekttypvarianten_Projekttypvarianten, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Projekttypvarianten is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Vortailoring
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasVortailoring> allMVModellvarianteHasVortailoringInstances9 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVortailoring>(this, global::Tum.VModellXT.VModellvarianteHasVortailoring.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasVortailoringInstances9.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasVortailoring_Vortailoring, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Vortailoring is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Entscheidungspunkte
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte> allMVModellvarianteHasEntscheidungspunkteInstances10 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte>(this, global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasEntscheidungspunkteInstances10.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasEntscheidungspunkte_Entscheidungspunkte, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Entscheidungspunkte is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Projektmerkmale
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale> allMVModellvarianteHasProjektmerkmaleInstances11 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale>(this, global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasProjektmerkmaleInstances11.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasProjektmerkmale_Projektmerkmale, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Projektmerkmale is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Konventionsabbildungen
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen> allMVModellvarianteHasKonventionsabbildungenInstances12 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen>(this, global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasKonventionsabbildungenInstances12.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasKonventionsabbildungen_Konventionsabbildungen, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Konventionsabbildungen is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Methodenreferenzen
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen> allMVModellvarianteHasMethodenreferenzenInstances13 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen>(this, global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasMethodenreferenzenInstances13.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasMethodenreferenzen_Methodenreferenzen, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Methodenreferenzen is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Werkzeugreferenzen
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen> allMVModellvarianteHasWerkzeugreferenzenInstances14 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen>(this, global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasWerkzeugreferenzenInstances14.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasWerkzeugreferenzen_Werkzeugreferenzen, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Werkzeugreferenzen is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Glossar
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasGlossar> allMVModellvarianteHasGlossarInstances15 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasGlossar>(this, global::Tum.VModellXT.VModellvarianteHasGlossar.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasGlossarInstances15.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasGlossar_Glossar, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Glossar is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Abkuerzungen
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen> allMVModellvarianteHasAbkuerzungenInstances16 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen>(this, global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasAbkuerzungenInstances16.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasAbkuerzungen_Abkuerzungen, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Abkuerzungen is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Quellen
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasQuellen> allMVModellvarianteHasQuellenInstances17 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasQuellen>(this, global::Tum.VModellXT.VModellvarianteHasQuellen.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasQuellenInstances17.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasQuellen_Quellen, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Quellen is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Aenderungsoperationen
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen> allMVModellvarianteHasAenderungsoperationenInstances18 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen>(this, global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasAenderungsoperationenInstances18.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasAenderungsoperationen_Aenderungsoperationen, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type Aenderungsoperationen is missing, although it is required.", this));
			}

			// validate embedding relationship from VModellvariante to Referenzmodell
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasReferenzmodell> allMVModellvarianteHasReferenzmodellInstances19 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasReferenzmodell>(this, global::Tum.VModellXT.VModellvarianteHasReferenzmodell.VModellvarianteDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMVModellvarianteHasReferenzmodellInstances19.Count > 1 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VModellvarianteHasReferenzmodell_Referenzmodell, DslEditorModeling::ModelValidationViolationType.Error, "Multiple Embedded elements of type Referenzmodell found, although only one is allowed.", this));
			}
		}
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
    /// Partial class used to validate Referenzmodell.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Referenzmodell
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Referenzmodell.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateReferenzmodell(DslEditorModeling::ModelValidationContext context)
		{

			// validate embedding relationship from Referenzmodell to VModell
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ReferenzmodellHasVModell> allMReferenzmodellHasVModellInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ReferenzmodellHasVModell>(this, global::Tum.VModellXT.ReferenzmodellHasVModell.ReferenzmodellDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMReferenzmodellHasVModellInstances0.Count > 1 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.ReferenzmodellHasVModell_VModell, DslEditorModeling::ModelValidationViolationType.Error, "Multiple Embedded elements of type VModell found, although only one is allowed.", this));
			}

			// validate reference relationship from Referenzmodell to VModellvariante (Side: Referenzmodell)
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante> allMReferenzmodellReferencesVModellvarianteInstances1 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante>(this, global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.ReferenzmodellDomainRoleId);
			// validate reference relationships --> see if cardinality constraints are met
			if( allMReferenzmodellReferencesVModellvarianteInstances1.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.ReferenzmodellReferencesVModellvariante_VModellvariante, DslEditorModeling::ModelValidationViolationType.Error, "Reference to element of type V-Modellvariante is missing, although it is required. Role name: + VModellvarianteRef", this));
			}
		}
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
    /// Partial class used to validate Musterbibliothek.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Musterbibliothek
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Musterbibliothek.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateMusterbibliothek(DslEditorModeling::ModelValidationContext context)
		{

			// validate embedding relationship from Musterbibliothek to VModell
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.MusterbibliothekHasVModell> allMMusterbibliothekHasVModellInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MusterbibliothekHasVModell>(this, global::Tum.VModellXT.MusterbibliothekHasVModell.MusterbibliothekDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMMusterbibliothekHasVModellInstances0.Count > 1 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.MusterbibliothekHasVModell_VModell, DslEditorModeling::ModelValidationViolationType.Error, "Multiple Embedded elements of type VModell found, although only one is allowed.", this));
			}
		}
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
    /// Partial class used to validate Mustergruppe.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Mustergruppe
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Mustergruppe.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateMustergruppe(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.Mustergruppe_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
    /// Partial class used to validate Themenmuster.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Themenmuster
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Themenmuster.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateThemenmuster(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.Themenmuster_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
    /// Partial class used to validate Mustertext.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Mustertext
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Mustertext.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateMustertext(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.Mustertext_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
			// validate required attribute Standardauswahl
			if( this.Standardauswahl == null )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.Mustertext_Standardauswahl, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Standardauswahl' has no value although it is required", this));
			}
			// validate required attribute Text
			if( this.Text == null )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.Mustertext_Text, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Text' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
    /// Partial class used to validate Zusatzthema.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Zusatzthema
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Zusatzthema.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateZusatzthema(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.Zusatzthema_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
			// validate required attribute Standardauswahl
			if( this.Standardauswahl == null )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.Zusatzthema_Standardauswahl, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Standardauswahl' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
    /// Partial class used to validate Variante.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Variante
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Variante.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateVariante(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.Variante_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
			// validate required attribute Verzeichnis
			if( System.String.IsNullOrEmpty(this.Verzeichnis) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.Variante_Verzeichnis, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Verzeichnis' has no value although it is required", this));
			}
			// validate required attribute Dateiname
			if( System.String.IsNullOrEmpty(this.Dateiname) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.Variante_Dateiname, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Dateiname' has no value although it is required", this));
			}

			// validate reference relationship from VarianteSource to VarianteTarget (Side: VarianteSource)
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget> allMVarianteSourceReferencesVarianteTargetInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget>(this, global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.VarianteSourceDomainRoleId);
			// validate reference relationships --> see if cardinality constraints are met
			if( allMVarianteSourceReferencesVarianteTargetInstances0.Count > 1 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.VModellXT.VModellXTValidationMessageIds.VarianteSourceReferencesVarianteTarget_VarianteTarget, DslEditorModeling::ModelValidationViolationType.Error, "There are multiple references to elements of type Variante, although only one is allowed. Role name: + Referenzvariante", this));
			}
		}
		#endregion
	}
}

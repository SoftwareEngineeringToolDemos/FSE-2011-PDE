 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;

using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.VModellXT
{
	/// <summary>
	/// DomainModel VModellXTDomainModel
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellXTDomainModel.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellXTDomainModel.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.CoreDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Tum.VModellXT.Basis.VModellXTBasisDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Tum.VModellXT.Statik.VModellXTStatikDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Tum.VModellXT.Dynamik.VModellXTDynamikDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Tum.VModellXT.Anpassung.VModellXTAnpassungDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Tum.VModellXT.Konventionsabbildungen.VModellXTKonventionsabbildungenDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Tum.VModellXT.Aenderungsoperationen.VModellXTAenderungesoperationenDomainModel))]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
	[DslModeling::DomainObjectId("6a98d181-c155-4c2b-b6b0-dc6c929dba4a")]
	[DslModeling::DependsOnDomainModel(typeof(DslEditorDiagrams::DiagramsDSLDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(DslEditorModeling::DomainModelDslEditorModeling))]
	public partial class VModellXTDomainModel : DslEditorModeling::DomainModelBase
	{
		#region Constructor, domain model Id

		/// <summary>
		/// VModellXTDomainModel domain model Id.
		/// </summary>
		public static readonly new global::System.Guid DomainModelId = new System.Guid("6a98d181-c155-4c2b-b6b0-dc6c929dba4a");

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public VModellXTDomainModel(DslModeling::Store store)
			: base(store, DomainModelId)
		{
			// Call the partial method to allow any required serialization setup to be done.
			this.InitializeSerialization(store);		
		}
	

		///<Summary>
		/// Defines a partial method that will be called from the constructor to
		/// allow any necessary serialization setup to be done.
		///</Summary>
		///<remarks>
		/// For a DSL created with the DSL Designer wizard, an implementation of this 
		/// method will be generated in the GeneratedCode\SerializationHelper.cs class.
		///</remarks>
		partial void InitializeSerialization(DslModeling::Store store);
		#endregion	
		#region Domain model reflection
		
		/// <summary>
		/// Gets the list of generated domain model types (classes, rules, relationships).
		/// </summary>
		/// <returns>List of types.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override global::System.Type[] GetGeneratedDomainModelTypes()
		{
			return new global::System.Type[]
			{
				typeof(VModell),
				typeof(VModellvariante),
				typeof(Referenzmodell),
				typeof(RolleDependencyShape),
				typeof(DisziplinDependencyShape),
				typeof(ErzAbhDependencyShape),
				typeof(VModellHasVModellvariante),
				typeof(VModellvarianteHasVModellStruktur),
				typeof(VModellvarianteHasTextbausteine),
				typeof(VModellvarianteHasVorgehensbausteine),
				typeof(VModellvarianteHasRollen),
				typeof(VModellvarianteHasPDSSpezifikationen),
				typeof(VModellvarianteHasAblaufbausteine),
				typeof(VModellvarianteHasAblaufbausteinspezifikationen),
				typeof(VModellvarianteHasProjekttypen),
				typeof(VModellvarianteHasProjekttypvarianten),
				typeof(VModellvarianteHasVortailoring),
				typeof(VModellvarianteHasEntscheidungspunkte),
				typeof(VModellvarianteHasProjektmerkmale),
				typeof(VModellvarianteHasKonventionsabbildungen),
				typeof(VModellvarianteHasMethodenreferenzen),
				typeof(VModellvarianteHasWerkzeugreferenzen),
				typeof(VModellvarianteHasGlossar),
				typeof(VModellvarianteHasAbkuerzungen),
				typeof(VModellvarianteHasQuellen),
				typeof(VModellvarianteHasAenderungsoperationen),
				typeof(VModellvarianteHasReferenzmodell),
				typeof(ReferenzmodellHasVModell),
				typeof(ReferenzmodellReferencesVModellvariante),
				typeof(Musterbibliothek),
				typeof(Mustergruppe),
				typeof(Themenmuster),
				typeof(Mustertext),
				typeof(Zusatzthema),
				typeof(MusterbibliothekHasMustergruppe),
				typeof(MustergruppeHasThemenmuster),
				typeof(ThemenmusterReferencesThema),
				typeof(ThemenmusterReferencesUnterthema),
				typeof(ThemenmusterHasMustertext),
				typeof(ThemenmusterSourceHasThemenmusterTarget),
				typeof(ThemenmusterHasZusatzthema),
				typeof(ZusatzthemaHasMustertext),
				typeof(ZusatzthemaSourceHasZusatzthemaTarget),
				typeof(MusterbibliothekHasVModell),
				typeof(Varianten),
				typeof(Variante),
				typeof(VariantenHasVariante),
				typeof(VarianteSourceReferencesVarianteTarget),
				typeof(DesignerDiagram),
				typeof(GeneralGrDependencyTemplate),
				typeof(RolleDependencyTemplate),
				typeof(DisziplinGrDependencyTemplate),
				typeof(ErzAbhGrDependencyTemplate),
				typeof(DesignerDiagramMustertexte),
				typeof(DesignerDiagramVariantenkonfig),
			};
		}
		/// <summary>
		/// Gets the list of generated domain properties.
		/// </summary>
		/// <returns>List of property data.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override DomainMemberInfo[] GetGeneratedDomainProperties()
		{
			return new DomainMemberInfo[]
			{
				new DomainMemberInfo(typeof(VModell), "Master", VModell.MasterDomainPropertyId, typeof(VModell.MasterPropertyHandler)),
				new DomainMemberInfo(typeof(VModellvariante), "Name", VModellvariante.NameDomainPropertyId, typeof(VModellvariante.NamePropertyHandler)),
				new DomainMemberInfo(typeof(VModellvariante), "Version", VModellvariante.VersionDomainPropertyId, typeof(VModellvariante.VersionPropertyHandler)),
				new DomainMemberInfo(typeof(VModellvariante), "VersionIntern", VModellvariante.VersionInternDomainPropertyId, typeof(VModellvariante.VersionInternPropertyHandler)),
				new DomainMemberInfo(typeof(VModellvariante), "CopyrightKurz", VModellvariante.CopyrightKurzDomainPropertyId, typeof(VModellvariante.CopyrightKurzPropertyHandler)),
				new DomainMemberInfo(typeof(VModellvariante), "CopyrightLang", VModellvariante.CopyrightLangDomainPropertyId, typeof(VModellvariante.CopyrightLangPropertyHandler)),
				new DomainMemberInfo(typeof(Mustergruppe), "Name", Mustergruppe.NameDomainPropertyId, typeof(Mustergruppe.NamePropertyHandler)),
				new DomainMemberInfo(typeof(Themenmuster), "Name", Themenmuster.NameDomainPropertyId, typeof(Themenmuster.NamePropertyHandler)),
				new DomainMemberInfo(typeof(Mustertext), "Name", Mustertext.NameDomainPropertyId, typeof(Mustertext.NamePropertyHandler)),
				new DomainMemberInfo(typeof(Mustertext), "Standardauswahl", Mustertext.StandardauswahlDomainPropertyId, typeof(Mustertext.StandardauswahlPropertyHandler)),
				new DomainMemberInfo(typeof(Mustertext), "Text", Mustertext.TextDomainPropertyId, typeof(Mustertext.TextPropertyHandler)),
				new DomainMemberInfo(typeof(Zusatzthema), "Name", Zusatzthema.NameDomainPropertyId, typeof(Zusatzthema.NamePropertyHandler)),
				new DomainMemberInfo(typeof(Zusatzthema), "Standardauswahl", Zusatzthema.StandardauswahlDomainPropertyId, typeof(Zusatzthema.StandardauswahlPropertyHandler)),
				new DomainMemberInfo(typeof(Variante), "Name", Variante.NameDomainPropertyId, typeof(Variante.NamePropertyHandler)),
				new DomainMemberInfo(typeof(Variante), "Verzeichnis", Variante.VerzeichnisDomainPropertyId, typeof(Variante.VerzeichnisPropertyHandler)),
				new DomainMemberInfo(typeof(Variante), "Dateiname", Variante.DateinameDomainPropertyId, typeof(Variante.DateinamePropertyHandler)),
			};
		}
		/// <summary>
		/// Gets the list of generated domain roles.
		/// </summary>
		/// <returns>List of role data.</returns>
		protected sealed override DomainRolePlayerInfo[] GetGeneratedDomainRoles()
		{
			return new DomainRolePlayerInfo[]
			{
				new DomainRolePlayerInfo(typeof(VModellHasVModellvariante), "VModell", VModellHasVModellvariante.VModellDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellHasVModellvariante), "VModellvariante", VModellHasVModellvariante.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasVModellStruktur), "VModellvariante", VModellvarianteHasVModellStruktur.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasVModellStruktur), "VModellStruktur", VModellvarianteHasVModellStruktur.VModellStrukturDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasTextbausteine), "VModellvariante", VModellvarianteHasTextbausteine.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasTextbausteine), "Textbausteine", VModellvarianteHasTextbausteine.TextbausteineDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasVorgehensbausteine), "VModellvariante", VModellvarianteHasVorgehensbausteine.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasVorgehensbausteine), "Vorgehensbausteine", VModellvarianteHasVorgehensbausteine.VorgehensbausteineDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasRollen), "VModellvariante", VModellvarianteHasRollen.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasRollen), "Rollen", VModellvarianteHasRollen.RollenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasPDSSpezifikationen), "VModellvariante", VModellvarianteHasPDSSpezifikationen.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasPDSSpezifikationen), "PDSSpezifikationen", VModellvarianteHasPDSSpezifikationen.PDSSpezifikationenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasAblaufbausteine), "VModellvariante", VModellvarianteHasAblaufbausteine.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasAblaufbausteine), "Ablaufbausteine", VModellvarianteHasAblaufbausteine.AblaufbausteineDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasAblaufbausteinspezifikationen), "VModellvariante", VModellvarianteHasAblaufbausteinspezifikationen.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasAblaufbausteinspezifikationen), "Ablaufbausteinspezifikationen", VModellvarianteHasAblaufbausteinspezifikationen.AblaufbausteinspezifikationenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasProjekttypen), "VModellvariante", VModellvarianteHasProjekttypen.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasProjekttypen), "Projekttypen", VModellvarianteHasProjekttypen.ProjekttypenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasProjekttypvarianten), "VModellvariante", VModellvarianteHasProjekttypvarianten.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasProjekttypvarianten), "Projekttypvarianten", VModellvarianteHasProjekttypvarianten.ProjekttypvariantenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasVortailoring), "VModellvariante", VModellvarianteHasVortailoring.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasVortailoring), "Vortailoring", VModellvarianteHasVortailoring.VortailoringDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasEntscheidungspunkte), "VModellvariante", VModellvarianteHasEntscheidungspunkte.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasEntscheidungspunkte), "Entscheidungspunkte", VModellvarianteHasEntscheidungspunkte.EntscheidungspunkteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasProjektmerkmale), "VModellvariante", VModellvarianteHasProjektmerkmale.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasProjektmerkmale), "Projektmerkmale", VModellvarianteHasProjektmerkmale.ProjektmerkmaleDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasKonventionsabbildungen), "VModellvariante", VModellvarianteHasKonventionsabbildungen.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasKonventionsabbildungen), "Konventionsabbildungen", VModellvarianteHasKonventionsabbildungen.KonventionsabbildungenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasMethodenreferenzen), "VModellvariante", VModellvarianteHasMethodenreferenzen.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasMethodenreferenzen), "Methodenreferenzen", VModellvarianteHasMethodenreferenzen.MethodenreferenzenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasWerkzeugreferenzen), "VModellvariante", VModellvarianteHasWerkzeugreferenzen.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasWerkzeugreferenzen), "Werkzeugreferenzen", VModellvarianteHasWerkzeugreferenzen.WerkzeugreferenzenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasGlossar), "VModellvariante", VModellvarianteHasGlossar.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasGlossar), "Glossar", VModellvarianteHasGlossar.GlossarDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasAbkuerzungen), "VModellvariante", VModellvarianteHasAbkuerzungen.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasAbkuerzungen), "Abkuerzungen", VModellvarianteHasAbkuerzungen.AbkuerzungenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasQuellen), "VModellvariante", VModellvarianteHasQuellen.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasQuellen), "Quellen", VModellvarianteHasQuellen.QuellenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasAenderungsoperationen), "VModellvariante", VModellvarianteHasAenderungsoperationen.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasAenderungsoperationen), "Aenderungsoperationen", VModellvarianteHasAenderungsoperationen.AenderungsoperationenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasReferenzmodell), "VModellvariante", VModellvarianteHasReferenzmodell.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VModellvarianteHasReferenzmodell), "Referenzmodell", VModellvarianteHasReferenzmodell.ReferenzmodellDomainRoleId),
				new DomainRolePlayerInfo(typeof(ReferenzmodellHasVModell), "Referenzmodell", ReferenzmodellHasVModell.ReferenzmodellDomainRoleId),
				new DomainRolePlayerInfo(typeof(ReferenzmodellHasVModell), "VModell", ReferenzmodellHasVModell.VModellDomainRoleId),
				new DomainRolePlayerInfo(typeof(ReferenzmodellReferencesVModellvariante), "Referenzmodell", ReferenzmodellReferencesVModellvariante.ReferenzmodellDomainRoleId),
				new DomainRolePlayerInfo(typeof(ReferenzmodellReferencesVModellvariante), "VModellvariante", ReferenzmodellReferencesVModellvariante.VModellvarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(MusterbibliothekHasMustergruppe), "Musterbibliothek", MusterbibliothekHasMustergruppe.MusterbibliothekDomainRoleId),
				new DomainRolePlayerInfo(typeof(MusterbibliothekHasMustergruppe), "Mustergruppe", MusterbibliothekHasMustergruppe.MustergruppeDomainRoleId),
				new DomainRolePlayerInfo(typeof(MustergruppeHasThemenmuster), "Mustergruppe", MustergruppeHasThemenmuster.MustergruppeDomainRoleId),
				new DomainRolePlayerInfo(typeof(MustergruppeHasThemenmuster), "Themenmuster", MustergruppeHasThemenmuster.ThemenmusterDomainRoleId),
				new DomainRolePlayerInfo(typeof(ThemenmusterReferencesThema), "Themenmuster", ThemenmusterReferencesThema.ThemenmusterDomainRoleId),
				new DomainRolePlayerInfo(typeof(ThemenmusterReferencesThema), "Thema", ThemenmusterReferencesThema.ThemaDomainRoleId),
				new DomainRolePlayerInfo(typeof(ThemenmusterReferencesUnterthema), "Themenmuster", ThemenmusterReferencesUnterthema.ThemenmusterDomainRoleId),
				new DomainRolePlayerInfo(typeof(ThemenmusterReferencesUnterthema), "Unterthema", ThemenmusterReferencesUnterthema.UnterthemaDomainRoleId),
				new DomainRolePlayerInfo(typeof(ThemenmusterHasMustertext), "Themenmuster", ThemenmusterHasMustertext.ThemenmusterDomainRoleId),
				new DomainRolePlayerInfo(typeof(ThemenmusterHasMustertext), "Mustertext", ThemenmusterHasMustertext.MustertextDomainRoleId),
				new DomainRolePlayerInfo(typeof(ThemenmusterSourceHasThemenmusterTarget), "ThemenmusterSource", ThemenmusterSourceHasThemenmusterTarget.ThemenmusterSourceDomainRoleId),
				new DomainRolePlayerInfo(typeof(ThemenmusterSourceHasThemenmusterTarget), "ThemenmusterTarget", ThemenmusterSourceHasThemenmusterTarget.ThemenmusterTargetDomainRoleId),
				new DomainRolePlayerInfo(typeof(ThemenmusterHasZusatzthema), "Themenmuster", ThemenmusterHasZusatzthema.ThemenmusterDomainRoleId),
				new DomainRolePlayerInfo(typeof(ThemenmusterHasZusatzthema), "Zusatzthema", ThemenmusterHasZusatzthema.ZusatzthemaDomainRoleId),
				new DomainRolePlayerInfo(typeof(ZusatzthemaHasMustertext), "Zusatzthema", ZusatzthemaHasMustertext.ZusatzthemaDomainRoleId),
				new DomainRolePlayerInfo(typeof(ZusatzthemaHasMustertext), "Mustertext", ZusatzthemaHasMustertext.MustertextDomainRoleId),
				new DomainRolePlayerInfo(typeof(ZusatzthemaSourceHasZusatzthemaTarget), "ZusatzthemaSource", ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaSourceDomainRoleId),
				new DomainRolePlayerInfo(typeof(ZusatzthemaSourceHasZusatzthemaTarget), "ZusatzthemaTarget", ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaTargetDomainRoleId),
				new DomainRolePlayerInfo(typeof(MusterbibliothekHasVModell), "Musterbibliothek", MusterbibliothekHasVModell.MusterbibliothekDomainRoleId),
				new DomainRolePlayerInfo(typeof(MusterbibliothekHasVModell), "VModell", MusterbibliothekHasVModell.VModellDomainRoleId),
				new DomainRolePlayerInfo(typeof(VariantenHasVariante), "Varianten", VariantenHasVariante.VariantenDomainRoleId),
				new DomainRolePlayerInfo(typeof(VariantenHasVariante), "Variante", VariantenHasVariante.VarianteDomainRoleId),
				new DomainRolePlayerInfo(typeof(VarianteSourceReferencesVarianteTarget), "VarianteSource", VarianteSourceReferencesVarianteTarget.VarianteSourceDomainRoleId),
				new DomainRolePlayerInfo(typeof(VarianteSourceReferencesVarianteTarget), "VarianteTarget", VarianteSourceReferencesVarianteTarget.VarianteTargetDomainRoleId),
			};
		}
		#endregion
		#region Domain model advanced reflection
		/// <summary>
        /// Gets domain classes advanced reflection information.
        /// </summary>
        public override DslEditorModeling::DomainClassAdvancedInfo[] GetDomainClassAdvancedInfo()
		{
			return new DslEditorModeling::DomainClassAdvancedInfo[]
			{
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.VModellXT.VModell.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.VModellXT.VModellvariante.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.VModellXT.Referenzmodell.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.VModellXT.Musterbibliothek.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.VModellXT.Mustergruppe.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.VModellXT.Themenmuster.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.VModellXT.Mustertext.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.VModellXT.Zusatzthema.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.VModellXT.Varianten.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.VModellXT.Variante.DomainClassId)
				{
					IsAbstract = false
				}
				,
	
			};
		}
		
        /// <summary>
        /// Gets domain relationships advanced reflection information.
        /// </summary>
        public override DslEditorModeling::DomainRelationshipAdvancedInfo[] GetDomainRelationshipAdvancedInfo()
		{
			return new DslEditorModeling::DomainRelationshipAdvancedInfo[]
			{
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellHasVModellvariante.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModell.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellHasVModellvariante.VModellDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellHasVModellvariante.VModellvarianteDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasVModellStruktur.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Basis.VModellStruktur.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasVModellStruktur.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasVModellStruktur.VModellStrukturDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasTextbausteine.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Basis.Textbausteine.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasTextbausteine.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasTextbausteine.TextbausteineDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Statik.Vorgehensbausteine.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.VorgehensbausteineDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasRollen.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Statik.Rollen.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasRollen.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasRollen.RollenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Dynamik.PDSSpezifikationen.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.PDSSpezifikationenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Dynamik.Ablaufbausteine.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.AblaufbausteineDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.AblaufbausteinspezifikationenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasProjekttypen.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Anpassung.Projekttypen.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasProjekttypen.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasProjekttypen.ProjekttypenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Anpassung.Projekttypvarianten.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.ProjekttypvariantenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasVortailoring.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Anpassung.Vortailoring.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasVortailoring.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasVortailoring.VortailoringDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Statik.Entscheidungspunkte.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.EntscheidungspunkteDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Anpassung.Projektmerkmale.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.ProjektmerkmaleDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.KonventionsabbildungenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Basis.Methodenreferenzen.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.MethodenreferenzenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Basis.Werkzeugreferenzen.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.WerkzeugreferenzenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasGlossar.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Basis.Glossar.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasGlossar.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasGlossar.GlossarDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Basis.Abkuerzungen.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.AbkuerzungenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasQuellen.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Basis.Quellen.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasQuellen.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasQuellen.QuellenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.AenderungsoperationenDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VModellvarianteHasReferenzmodell.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Referenzmodell.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VModellvarianteHasReferenzmodell.VModellvarianteDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VModellvarianteHasReferenzmodell.ReferenzmodellDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.ReferenzmodellHasVModell.DomainClassId, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Referenzmodell.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.VModell.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.ReferenzmodellHasVModell.ReferenzmodellDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.ReferenzmodellHasVModell.VModellDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Referenzmodell.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.VModellvariante.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.ReferenzmodellDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.VModellvarianteDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = false,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.MusterbibliothekHasMustergruppe.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Musterbibliothek.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Mustergruppe.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.MusterbibliothekHasMustergruppe.MusterbibliothekDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.MusterbibliothekHasMustergruppe.MustergruppeDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.MustergruppeHasThemenmuster.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Mustergruppe.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Themenmuster.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.MustergruppeHasThemenmuster.MustergruppeDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.MustergruppeHasThemenmuster.ThemenmusterDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.VModellXT.ThemenmusterReferencesThema.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Themenmuster.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Statik.Thema.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.ThemenmusterReferencesThema.ThemenmusterDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.ThemenmusterReferencesThema.ThemaDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.VModellXT.ThemenmusterReferencesUnterthema.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Themenmuster.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Statik.Unterthema.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.ThemenmusterReferencesUnterthema.ThemenmusterDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.ThemenmusterReferencesUnterthema.UnterthemaDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.ThemenmusterHasMustertext.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Themenmuster.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Mustertext.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.ThemenmusterHasMustertext.ThemenmusterDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.ThemenmusterHasMustertext.MustertextDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Themenmuster.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Themenmuster.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.ThemenmusterSourceDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.ThemenmusterTargetDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.ThemenmusterHasZusatzthema.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Themenmuster.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Zusatzthema.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.ThemenmusterHasZusatzthema.ThemenmusterDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.ThemenmusterHasZusatzthema.ZusatzthemaDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.ZusatzthemaHasMustertext.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Zusatzthema.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Mustertext.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.ZusatzthemaHasMustertext.ZusatzthemaDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.ZusatzthemaHasMustertext.MustertextDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Zusatzthema.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Zusatzthema.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaSourceDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaTargetDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.MusterbibliothekHasVModell.DomainClassId, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Musterbibliothek.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.VModell.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.MusterbibliothekHasVModell.MusterbibliothekDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.MusterbibliothekHasVModell.VModellDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = false,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.VModellXT.VariantenHasVariante.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Varianten.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Variante.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VariantenHasVariante.VariantenDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VariantenHasVariante.VarianteDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.VModellXT.Variante.DomainClassId,
					TargetElementDomainClassId = global::Tum.VModellXT.Variante.DomainClassId,
					SourceRoleId = global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.VarianteSourceDomainRoleId,
					TargetRoleId = global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.VarianteTargetDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = false,
				}
				,
	
			};
		}
		
        /// <summary>
        /// Gets the embedding relationships order information (parent-child mappings in the order of the serialization model).
        /// </summary>
        public override DslEditorModeling::EmbeddingRelationshipOrderInfo[] GetEmbeddingRelationshipOrderInfo()
		{
			return new DslEditorModeling::EmbeddingRelationshipOrderInfo[] 
			{
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.VModellXT.VModell.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.VModellXT.VModellHasVModellvariante.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.VModellXT.VModellvariante.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.VModellXT.VModellvarianteHasVModellStruktur.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasTextbausteine.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasRollen.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasProjekttypen.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasVortailoring.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasGlossar.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasQuellen.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.DomainClassId,
						global::Tum.VModellXT.VModellvarianteHasReferenzmodell.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.VModellXT.Referenzmodell.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.VModellXT.ReferenzmodellHasVModell.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
						global::Tum.VModellXT.ReferenzmodellHasVModell.DomainClassId,
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.VModellXT.Musterbibliothek.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.VModellXT.MusterbibliothekHasMustergruppe.DomainClassId,
						global::Tum.VModellXT.MusterbibliothekHasVModell.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
						global::Tum.VModellXT.MusterbibliothekHasVModell.DomainClassId,
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.VModellXT.Mustergruppe.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.VModellXT.MustergruppeHasThemenmuster.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.VModellXT.Themenmuster.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.VModellXT.ThemenmusterHasMustertext.DomainClassId,
						global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.DomainClassId,
						global::Tum.VModellXT.ThemenmusterHasZusatzthema.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.VModellXT.Mustertext.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.VModellXT.Zusatzthema.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.VModellXT.ZusatzthemaHasMustertext.DomainClassId,
						global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.VModellXT.Varianten.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.VModellXT.VariantenHasVariante.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.VModellXT.Variante.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
			};
		}

        /// <summary>
        /// Gets the model context informations.
        /// </summary>
        public override DslEditorModeling::ModelContextInfo[] GetModelContextInfo()
		{
			return new DslEditorModeling::ModelContextInfo[] 
			{
				new DslEditorModeling::ModelContextInfo(VModellXTModelContext.DomainClassId, global::Tum.VModellXT.VModell.DomainClassId),
				new DslEditorModeling::ModelContextInfo(VModellXTMustertexteModelContext.DomainClassId, global::Tum.VModellXT.Musterbibliothek.DomainClassId),
				new DslEditorModeling::ModelContextInfo(VariantenkonfigModelContext.DomainClassId, global::Tum.VModellXT.Varianten.DomainClassId),
	
			};
		}
		#endregion
		#region Diagrams model advanced reflection
		private class VModellXTDiagramDomainDataDirectory : DslEditorDiagrams::DiagramDomainDataDirectory
		{
			/// <summary>
        	/// Gets the diagram class information.
        	/// </summary>
        	/// <returns>Diagram class info.</returns>
        	public override DslEditorDiagrams::DiagramClassInfo[] GetDiagramClassInfo()
			{
				return new DslEditorDiagrams::DiagramClassInfo[]
				{
					new DslEditorDiagrams::DiagramClassInfo(Tum.VModellXT.DesignerDiagram.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Extended),
					new DslEditorDiagrams::DiagramClassInfo(Tum.VModellXT.GeneralGrDependencyTemplate.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Extended),
					new DslEditorDiagrams::DiagramClassInfo(Tum.VModellXT.RolleDependencyTemplate.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Extended),
					new DslEditorDiagrams::DiagramClassInfo(Tum.VModellXT.DisziplinGrDependencyTemplate.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Extended),
					new DslEditorDiagrams::DiagramClassInfo(Tum.VModellXT.ErzAbhGrDependencyTemplate.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Extended),
					new DslEditorDiagrams::DiagramClassInfo(Tum.VModellXT.DesignerDiagramMustertexte.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Extended),
					new DslEditorDiagrams::DiagramClassInfo(Tum.VModellXT.DesignerDiagramVariantenkonfig.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Extended),
				};
			}

			/// <summary>
        	/// Gets the shape class information.
        	/// </summary>
        	/// <returns>Shape class info.</returns>
        	public override DslEditorDiagrams::ShapeClassInfo[] GetShapeClassInfo()
			{
				return new DslEditorDiagrams::ShapeClassInfo[]
				{
					new DslEditorDiagrams::ShapeClassInfo(Tum.VModellXT.RolleDependencyTemplate.DomainClassId, global::Tum.VModellXT.RolleDependencyShape.DomainClassId, global::Tum.VModellXT.Statik.Rolle.DomainClassId, true)
					{
					},
					new DslEditorDiagrams::ShapeClassInfo(Tum.VModellXT.DisziplinGrDependencyTemplate.DomainClassId, global::Tum.VModellXT.DisziplinDependencyShape.DomainClassId, global::Tum.VModellXT.Statik.Disziplin.DomainClassId, true)
					{
					},
					new DslEditorDiagrams::ShapeClassInfo(Tum.VModellXT.ErzAbhGrDependencyTemplate.DomainClassId, global::Tum.VModellXT.ErzAbhDependencyShape.DomainClassId, global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit.DomainClassId, true)
					{
					},
				
				};
			}

        	/// <summary>
        	/// Gets the rs shape class information.
        	/// </summary>
        	/// <returns>RSShape class info.</returns>
        	public override DslEditorDiagrams::RelationshipShapeInfo[] GetRelationshipShapeInfo()
			{
				return new DslEditorDiagrams::RelationshipShapeInfo[]
				{
				
				};
			}
			
        	/// <summary>
        	/// Gets the mapping rs shape class information.
        	/// </summary>
        	/// <returns>MappingRSShape class info.</returns>
        	public override DslEditorDiagrams::MappingRelationshipShapeInfo[] GetMappingRelationshipShapeInfo()
			{
				return new DslEditorDiagrams::MappingRelationshipShapeInfo[]
				{
					
				};
			}
			
        	/// <summary>
        	/// Gets the shape class information.
        	/// </summary>
        	/// <returns>Shape class info.</returns>
        	public override System.Guid[] GetClassesRelevantForSM()
			{
				return new System.Guid[]
				{
					global::Tum.VModellXT.Statik.Rolle.DomainClassId,
					global::Tum.VModellXT.Statik.Disziplin.DomainClassId,
					global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit.DomainClassId,
					
				};
			}
		}
		
		/// <summary>
        /// Gets data extensions.
        /// </summary>
        /// <returns>List of data extensions or null.</returns>
		public override DslEditorModeling::IDomainDataExtensionDirectory[] GetDataExtensions()
        {
            return new DslEditorModeling::IDomainDataExtensionDirectory[]
			{
				new VModellXTDiagramDomainDataDirectory()
			};
        }
		#endregion
		#region Factory methods
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementMap;

		/// <summary>
		/// Creates an element of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementType">Element type which belongs to this domain model.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		public sealed override DslModeling::ModelElement CreateElement(DslModeling::Partition partition, global::System.Type elementType, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementType == null) throw new global::System.ArgumentNullException("elementType");
			
			if (createElementMap == null)
			{
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(13);
				createElementMap.Add(typeof(VModell), 0);
				createElementMap.Add(typeof(VModellvariante), 1);
				createElementMap.Add(typeof(Referenzmodell), 2);
				createElementMap.Add(typeof(RolleDependencyShape), 3);
				createElementMap.Add(typeof(DisziplinDependencyShape), 4);
				createElementMap.Add(typeof(ErzAbhDependencyShape), 5);
				createElementMap.Add(typeof(Musterbibliothek), 6);
				createElementMap.Add(typeof(Mustergruppe), 7);
				createElementMap.Add(typeof(Themenmuster), 8);
				createElementMap.Add(typeof(Mustertext), 9);
				createElementMap.Add(typeof(Zusatzthema), 10);
				createElementMap.Add(typeof(Varianten), 11);
				createElementMap.Add(typeof(Variante), 12);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				// construct exception error message		
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Tum.VModellXT.VModellXTDomainModel.SingletonResourceManager.GetString("UnrecognizedElementType"),
								elementType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementType");
			}
			switch (index)
			{
				case 0: return new VModell(partition, propertyAssignments);
				case 1: return new VModellvariante(partition, propertyAssignments);
				case 2: return new Referenzmodell(partition, propertyAssignments);
				case 3: return new RolleDependencyShape(partition, propertyAssignments);
				case 4: return new DisziplinDependencyShape(partition, propertyAssignments);
				case 5: return new ErzAbhDependencyShape(partition, propertyAssignments);
				case 6: return new Musterbibliothek(partition, propertyAssignments);
				case 7: return new Mustergruppe(partition, propertyAssignments);
				case 8: return new Themenmuster(partition, propertyAssignments);
				case 9: return new Mustertext(partition, propertyAssignments);
				case 10: return new Zusatzthema(partition, propertyAssignments);
				case 11: return new Varianten(partition, propertyAssignments);
				case 12: return new Variante(partition, propertyAssignments);
				default: return null;
			}
		}

		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementLinkMap;

		/// <summary>
		/// Creates an element link of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementLinkType">Element link type which belongs to this domain model.</param>
		/// <param name="roleAssignments">List of relationship role assignments for the new link.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element link.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		public sealed override DslModeling::ElementLink CreateElementLink(DslModeling::Partition partition, global::System.Type elementLinkType, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementLinkType == null) throw new global::System.ArgumentNullException("elementLinkType");
			if (roleAssignments == null) throw new global::System.ArgumentNullException("roleAssignments");
			
			if (createElementLinkMap == null)
			{
				createElementLinkMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(0);
				createElementLinkMap.Add(typeof(VModellHasVModellvariante), 0);
				createElementLinkMap.Add(typeof(VModellvarianteHasVModellStruktur), 1);
				createElementLinkMap.Add(typeof(VModellvarianteHasTextbausteine), 2);
				createElementLinkMap.Add(typeof(VModellvarianteHasVorgehensbausteine), 3);
				createElementLinkMap.Add(typeof(VModellvarianteHasRollen), 4);
				createElementLinkMap.Add(typeof(VModellvarianteHasPDSSpezifikationen), 5);
				createElementLinkMap.Add(typeof(VModellvarianteHasAblaufbausteine), 6);
				createElementLinkMap.Add(typeof(VModellvarianteHasAblaufbausteinspezifikationen), 7);
				createElementLinkMap.Add(typeof(VModellvarianteHasProjekttypen), 8);
				createElementLinkMap.Add(typeof(VModellvarianteHasProjekttypvarianten), 9);
				createElementLinkMap.Add(typeof(VModellvarianteHasVortailoring), 10);
				createElementLinkMap.Add(typeof(VModellvarianteHasEntscheidungspunkte), 11);
				createElementLinkMap.Add(typeof(VModellvarianteHasProjektmerkmale), 12);
				createElementLinkMap.Add(typeof(VModellvarianteHasKonventionsabbildungen), 13);
				createElementLinkMap.Add(typeof(VModellvarianteHasMethodenreferenzen), 14);
				createElementLinkMap.Add(typeof(VModellvarianteHasWerkzeugreferenzen), 15);
				createElementLinkMap.Add(typeof(VModellvarianteHasGlossar), 16);
				createElementLinkMap.Add(typeof(VModellvarianteHasAbkuerzungen), 17);
				createElementLinkMap.Add(typeof(VModellvarianteHasQuellen), 18);
				createElementLinkMap.Add(typeof(VModellvarianteHasAenderungsoperationen), 19);
				createElementLinkMap.Add(typeof(VModellvarianteHasReferenzmodell), 20);
				createElementLinkMap.Add(typeof(ReferenzmodellHasVModell), 21);
				createElementLinkMap.Add(typeof(ReferenzmodellReferencesVModellvariante), 22);
				createElementLinkMap.Add(typeof(MusterbibliothekHasMustergruppe), 23);
				createElementLinkMap.Add(typeof(MustergruppeHasThemenmuster), 24);
				createElementLinkMap.Add(typeof(ThemenmusterReferencesThema), 25);
				createElementLinkMap.Add(typeof(ThemenmusterReferencesUnterthema), 26);
				createElementLinkMap.Add(typeof(ThemenmusterHasMustertext), 27);
				createElementLinkMap.Add(typeof(ThemenmusterSourceHasThemenmusterTarget), 28);
				createElementLinkMap.Add(typeof(ThemenmusterHasZusatzthema), 29);
				createElementLinkMap.Add(typeof(ZusatzthemaHasMustertext), 30);
				createElementLinkMap.Add(typeof(ZusatzthemaSourceHasZusatzthemaTarget), 31);
				createElementLinkMap.Add(typeof(MusterbibliothekHasVModell), 32);
				createElementLinkMap.Add(typeof(VariantenHasVariante), 33);
				createElementLinkMap.Add(typeof(VarianteSourceReferencesVarianteTarget), 34);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				// construct exception error message
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Tum.VModellXT.VModellXTDomainModel.SingletonResourceManager.GetString("UnrecognizedElementLinkType"),
								elementLinkType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementLinkType");
		
			}
			switch (index)
			{
				case 0: return new VModellHasVModellvariante(partition, roleAssignments, propertyAssignments);
				case 1: return new VModellvarianteHasVModellStruktur(partition, roleAssignments, propertyAssignments);
				case 2: return new VModellvarianteHasTextbausteine(partition, roleAssignments, propertyAssignments);
				case 3: return new VModellvarianteHasVorgehensbausteine(partition, roleAssignments, propertyAssignments);
				case 4: return new VModellvarianteHasRollen(partition, roleAssignments, propertyAssignments);
				case 5: return new VModellvarianteHasPDSSpezifikationen(partition, roleAssignments, propertyAssignments);
				case 6: return new VModellvarianteHasAblaufbausteine(partition, roleAssignments, propertyAssignments);
				case 7: return new VModellvarianteHasAblaufbausteinspezifikationen(partition, roleAssignments, propertyAssignments);
				case 8: return new VModellvarianteHasProjekttypen(partition, roleAssignments, propertyAssignments);
				case 9: return new VModellvarianteHasProjekttypvarianten(partition, roleAssignments, propertyAssignments);
				case 10: return new VModellvarianteHasVortailoring(partition, roleAssignments, propertyAssignments);
				case 11: return new VModellvarianteHasEntscheidungspunkte(partition, roleAssignments, propertyAssignments);
				case 12: return new VModellvarianteHasProjektmerkmale(partition, roleAssignments, propertyAssignments);
				case 13: return new VModellvarianteHasKonventionsabbildungen(partition, roleAssignments, propertyAssignments);
				case 14: return new VModellvarianteHasMethodenreferenzen(partition, roleAssignments, propertyAssignments);
				case 15: return new VModellvarianteHasWerkzeugreferenzen(partition, roleAssignments, propertyAssignments);
				case 16: return new VModellvarianteHasGlossar(partition, roleAssignments, propertyAssignments);
				case 17: return new VModellvarianteHasAbkuerzungen(partition, roleAssignments, propertyAssignments);
				case 18: return new VModellvarianteHasQuellen(partition, roleAssignments, propertyAssignments);
				case 19: return new VModellvarianteHasAenderungsoperationen(partition, roleAssignments, propertyAssignments);
				case 20: return new VModellvarianteHasReferenzmodell(partition, roleAssignments, propertyAssignments);
				case 21: return new ReferenzmodellHasVModell(partition, roleAssignments, propertyAssignments);
				case 22: return new ReferenzmodellReferencesVModellvariante(partition, roleAssignments, propertyAssignments);
				case 23: return new MusterbibliothekHasMustergruppe(partition, roleAssignments, propertyAssignments);
				case 24: return new MustergruppeHasThemenmuster(partition, roleAssignments, propertyAssignments);
				case 25: return new ThemenmusterReferencesThema(partition, roleAssignments, propertyAssignments);
				case 26: return new ThemenmusterReferencesUnterthema(partition, roleAssignments, propertyAssignments);
				case 27: return new ThemenmusterHasMustertext(partition, roleAssignments, propertyAssignments);
				case 28: return new ThemenmusterSourceHasThemenmusterTarget(partition, roleAssignments, propertyAssignments);
				case 29: return new ThemenmusterHasZusatzthema(partition, roleAssignments, propertyAssignments);
				case 30: return new ZusatzthemaHasMustertext(partition, roleAssignments, propertyAssignments);
				case 31: return new ZusatzthemaSourceHasZusatzthemaTarget(partition, roleAssignments, propertyAssignments);
				case 32: return new MusterbibliothekHasVModell(partition, roleAssignments, propertyAssignments);
				case 33: return new VariantenHasVariante(partition, roleAssignments, propertyAssignments);
				case 34: return new VarianteSourceReferencesVarianteTarget(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion	
		#region Resource manager
	
		private static global::System.Resources.ResourceManager resourceManager;
	
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "Tum.VModellXT.GeneratedCode.DomainModelResx";
	
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return VModellXTDomainModel.SingletonResourceManager;
			}
		}

		/// <summary>
		/// Gets the Singleton ResourceManager for this domain model.
		/// </summary>
		public static global::System.Resources.ResourceManager SingletonResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (VModellXTDomainModel.resourceManager == null)
				{
					VModellXTDomainModel.resourceManager = new global::System.Resources.ResourceManager(
                        ResourceBaseName, typeof(VModellXTDomainModel).Assembly);
				}
				return VModellXTDomainModel.resourceManager;
			}
		}
		#endregion
		#region Copy/Remove closures
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter copyClosure;
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter removeClosure;
		/// <summary>
		/// Returns an IElementVisitorFilter that corresponds to the ClosureType.
		/// </summary>
		/// <param name="type">closure type</param>
		/// <param name="rootElements">collection of root elements</param>
		/// <returns>IElementVisitorFilter or null</returns>
		public override DslModeling::IElementVisitorFilter GetClosureFilter(DslModeling::ClosureType type, global::System.Collections.Generic.ICollection<DslModeling::ModelElement> rootElements)
		{
			switch (type)
			{
				case DslModeling::ClosureType.CopyClosure:
					return VModellXTDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return VModellXTDomainModel.DeleteClosure;
			}
			return base.GetClosureFilter(type, rootElements);
		}
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter CopyClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (VModellXTDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new VModellXTCopyClosure());
					
					VModellXTDomainModel.copyClosure = copyFilter;
				}
				return VModellXTDomainModel.copyClosure;
			}
		}
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter DeleteClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (VModellXTDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new VModellXTDeleteClosure());
		
					VModellXTDomainModel.removeClosure = removeFilter;
				}
				return VModellXTDomainModel.removeClosure;
			}
		}
		#endregion
	}
	
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	public partial class VModellXTDeleteClosure : VModellXTDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VModellXTDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	public partial class VModellXTDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public VModellXTDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::Tum.VModellXT.VModellHasVModellvariante.VModellvarianteDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasVModellStruktur.VModellStrukturDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasTextbausteine.TextbausteineDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.VorgehensbausteineDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasRollen.RollenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.PDSSpezifikationenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.AblaufbausteineDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.AblaufbausteinspezifikationenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasProjekttypen.ProjekttypenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.ProjekttypvariantenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasVortailoring.VortailoringDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.EntscheidungspunkteDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.ProjektmerkmaleDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.KonventionsabbildungenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.MethodenreferenzenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.WerkzeugreferenzenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasGlossar.GlossarDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.AbkuerzungenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasQuellen.QuellenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.AenderungsoperationenDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VModellvarianteHasReferenzmodell.ReferenzmodellDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.ReferenzmodellHasVModell.VModellDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.MusterbibliothekHasMustergruppe.MustergruppeDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.MustergruppeHasThemenmuster.ThemenmusterDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.ThemenmusterHasMustertext.MustertextDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.ThemenmusterTargetDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.ThemenmusterHasZusatzthema.ZusatzthemaDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.ZusatzthemaHasMustertext.MustertextDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaTargetDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.MusterbibliothekHasVModell.VModellDomainRoleId, true);
			DomainRoles.Add(global::Tum.VModellXT.VariantenHasVariante.VarianteDomainRoleId, true);
			#endregion
		}
		/// <summary>
		/// Called to ask the filter if a particular relationship from a source element should be included in the traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
		/// <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
		/// <param name="targetRelationship">Relationship in question</param>
		/// <returns>Yes if the relationship should be traversed</returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRelationship(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::DomainRoleInfo sourceRoleInfo, DslModeling::DomainRelationshipInfo domainRelationshipInfo, DslModeling::ElementLink targetRelationship)
		{
			return DslModeling::VisitorFilterResult.Yes;
		}
		/// <summary>
		/// Called to ask the filter if a particular role player should be Visited during traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
		/// <param name="targetDomainRole">DomainRoleInfo of the target role</param>
		/// <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
		/// <returns></returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRolePlayer(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::ElementLink elementLink, DslModeling::DomainRoleInfo targetDomainRole, DslModeling::ModelElement targetRolePlayer)
		{
			if (targetDomainRole == null) throw new global::System.ArgumentNullException("targetDomainRole");
			return this.DomainRoles.Contains(targetDomainRole.Id) ? DslModeling::VisitorFilterResult.Yes : DslModeling::VisitorFilterResult.DoNotCare;
		}
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary DomainRoles
		{
			get
			{
				if (this.domainRoles == null)
				{
					this.domainRoles = new global::System.Collections.Specialized.HybridDictionary();
				}
				return this.domainRoles;
			}
		}
	
	}
	/// <summary>
	/// Copy closure visitor filter
	/// </summary>
	public partial class VModellXTCopyClosure : VModellXTCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VModellXTCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	public partial class VModellXTCopyClosureBase : DslModeling::CopyClosureFilter, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VModellXTCopyClosureBase():base()
		{
		}
	}
	#endregion	
}

namespace Tum.VModellXT
{
	/// <summary>
	/// DomainEnumeration: TypStandard
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(TypStandardEnumConverter))]
	public enum TypStandard
	{
		/// <summary>
		/// Ja
		/// </summary>
		[DslDesign::DescriptionResource("Tum.VModellXT.TypStandard/Ja.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		Ja,
		/// <summary>
		/// Nein
		/// </summary>
		[DslDesign::DescriptionResource("Tum.VModellXT.TypStandard/Nein.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		Nein,
	}
	/// <summary>
	/// Type converter for TypStandard enumeration.
	/// </summary>
	public class TypStandardEnumConverter : System.ComponentModel.EnumConverter
	{
		System.Collections.Generic.Dictionary<TypStandard, string> dictionary;
		
		/// <summary>
	    /// Constructor.
	    /// </summary>
	    public TypStandardEnumConverter() : base(typeof(TypStandard))
	    {
	        // create lookup dictionary
	        dictionary = new System.Collections.Generic.Dictionary<TypStandard, string>();
			dictionary.Add(TypStandard.Ja, global::Tum.VModellXT.VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.TypStandard/Ja.DisplayName"));
			dictionary.Add(TypStandard.Nein, global::Tum.VModellXT.VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.TypStandard/Nein.DisplayName"));
	    }
	
		/// <summary>
	    /// Converts the specified value object to TypStandard.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value">The System.Object to convert.</param>
	    /// <returns>TypStandard object that represents the converted value.</returns>
	    public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
	    {
			string strValue = value as string;
			if( strValue != null )
			{
				foreach(TypStandard d in dictionary.Keys )
				{
					if( dictionary[d] == strValue )
						return d;
				}
	
			}
	        return base.ConvertFrom(context, culture, value);
	    }
	
		/// <summary>
	    /// Converts the given value object to the specified destination type.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value"> System.Object to convert.</param>
	    /// <param name="destinationType">The System.Type to convert the value to.</param>
	    /// <returns>An System.Object that represents the converted value.</returns>
	    public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
	    {
			TypStandard? strValue = value as TypStandard?;
			if( strValue != null )
			{
				return dictionary[strValue.Value];
			}
	
	        return base.ConvertTo(context, culture, value, destinationType);
	    }
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainEnumeration: DomainEnumeration1
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(DomainEnumeration1EnumConverter))]
	[global::System.Flags]
	public enum DomainEnumeration1
	{
		/// <summary>
		/// EnumerationLiteral1
		/// </summary>
		[DslDesign::DescriptionResource("Tum.VModellXT.DomainEnumeration1/EnumerationLiteral1.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		EnumerationLiteral1 = 1,
		/// <summary>
		/// EnumerationLiteral2
		/// </summary>
		[DslDesign::DescriptionResource("Tum.VModellXT.DomainEnumeration1/EnumerationLiteral2.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		EnumerationLiteral2 = 2,
	}
	/// <summary>
	/// Type converter for DomainEnumeration1 enumeration.
	/// </summary>
	public class DomainEnumeration1EnumConverter : System.ComponentModel.EnumConverter
	{
		System.Collections.Generic.Dictionary<DomainEnumeration1, string> dictionary;
		
		/// <summary>
	    /// Constructor.
	    /// </summary>
	    public DomainEnumeration1EnumConverter() : base(typeof(DomainEnumeration1))
	    {
	        // create lookup dictionary
	        dictionary = new System.Collections.Generic.Dictionary<DomainEnumeration1, string>();
			dictionary.Add(DomainEnumeration1.EnumerationLiteral1, global::Tum.VModellXT.VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.DomainEnumeration1/EnumerationLiteral1.DisplayName"));
			dictionary.Add(DomainEnumeration1.EnumerationLiteral2, global::Tum.VModellXT.VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.DomainEnumeration1/EnumerationLiteral2.DisplayName"));
	    }
	
		/// <summary>
	    /// Converts the specified value object to DomainEnumeration1.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value">The System.Object to convert.</param>
	    /// <returns>DomainEnumeration1 object that represents the converted value.</returns>
	    public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
	    {
			string strValue = value as string;
			if( strValue != null )
			{
				foreach(DomainEnumeration1 d in dictionary.Keys )
				{
					if( dictionary[d] == strValue )
						return d;
				}
	
			}
	        return base.ConvertFrom(context, culture, value);
	    }
	
		/// <summary>
	    /// Converts the given value object to the specified destination type.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value"> System.Object to convert.</param>
	    /// <param name="destinationType">The System.Type to convert the value to.</param>
	    /// <returns>An System.Object that represents the converted value.</returns>
	    public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
	    {
			DomainEnumeration1? strValue = value as DomainEnumeration1?;
			if( strValue != null )
			{
				return dictionary[strValue.Value];
			}
	
	        return base.ConvertTo(context, culture, value, destinationType);
	    }
	}
}


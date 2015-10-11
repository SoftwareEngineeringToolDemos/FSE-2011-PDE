<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="048f1124-7dd7-4dde-b754-95e15f9b5fe6" Description="Description for Tum.PDE.LanguageDSL" Name="LanguageDSL" DisplayName="LanguageDSL" Namespace="Tum.PDE.LanguageDSL" ProductName="LanguageDSL" CompanyName="Tum" PackageGuid="121cb910-4e04-45ac-93bc-2ae09819a245" PackageNamespace="Tum.PDE.LanguageDSL" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="069a8f33-3e79-4a97-906a-baf6c3754a2a" Description="Description for Tum.PDE.LanguageDSL.MetaModel" Name="MetaModel" DisplayName="Meta Model" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="BaseMetaModel" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="4404d1f6-c147-4719-b041-54a5f38b7b1a" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Name" Name="Name" DisplayName="Name" DefaultValue="DslEditor" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="00e062c0-9ce2-4c54-9bb1-e6d26a37eb3b" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Company Name" Name="CompanyName" DisplayName="Company Name" DefaultValue="Tum" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="bb2dfdf6-58f6-4570-bf2b-5f5c283a7d3a" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Namespace" Name="Namespace" DisplayName="Namespace" DefaultValue="DslEditor.Model" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="96871066-0f5f-429d-b7cc-2a95cec4fc5c" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Product Name" Name="ProductName" DisplayName="Product Name" DefaultValue="DslEditor" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e3790368-9d95-474b-8d29-5d69c02b7df6" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Description" Name="Description" DisplayName="Description" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="dd9da2be-b61b-49b9-94c2-a4812fb05a24" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Build" Name="Build" DisplayName="Build" Category="Version">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9b83379e-cf19-4ad8-851f-b204b33c7f59" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Major Version" Name="MajorVersion" DisplayName="Major Version" Category="Version">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b747472e-effe-42a9-a539-e187547f7d87" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Minor Version" Name="MinorVersion" DisplayName="Minor Version" Category="Version">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="0416f14c-5315-479a-8801-ba184a5e4493" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Revision" Name="Revision" DisplayName="Revision" Category="Version">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6d531740-99b0-4090-b781-4e0537b50582" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Display Name" Name="DisplayName" DisplayName="Display Name" DefaultValue="Meta Model DSL" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ff755c86-1b30-4f70-accd-5ce9b0f5cb32" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Application Name" Name="ApplicationName" DisplayName="Application Name" DefaultValue="DslEditor" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e23ab9af-5d11-41da-b47f-43711fb11b3e" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Layout Embedded Path" Name="LayoutEmbeddedPath" DisplayName="Layout Embedded Path" DefaultValue="GeneratedCode.ViewModel.WPFApplication.LayoutManagerLayout.xml" Category="Layout">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="4c489cb6-965b-4405-9fff-786eb75ea6b0" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Layout DVEmbedded Path" Name="LayoutDVEmbeddedPath" DisplayName="Layout DVEmbedded Path" DefaultValue="GeneratedCode.ViewModel.WPFApplication.LayoutManagerDV.txt" Category="Layout">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8d67bcee-8dcb-45d2-85e4-fd84c2c93fd3" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Package Guid" Name="PackageGuid" DisplayName="Package Guid" Category="Generate" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6c7e3201-b89a-435e-b148-ac443a9bddf8" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Custom Extension Guid" Name="CustomExtensionGuid" DisplayName="Custom Extension Guid" Category="Generate" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="197d2b7e-7f9b-4abd-aeea-7f99ea8ddb35" Description="This is only relevant for the VS-Plugin DSL." Name="CustomExtension" DisplayName="Custom Extension" DefaultValue="vsdsl" Category="VS-Plugin">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7ea79e37-95eb-4567-80dc-7580527b6083" Description="Description for Tum.PDE.LanguageDSL.MetaModel.Language Type" Name="LanguageType" DisplayName="Language Type" DefaultValue="WPFEditor" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="LanguageType" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DomainType" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>MetaModelHasDomainTypes.DomainTypes</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Validation" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>MetaModelHasValidation.Validation</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="AdditionalInformation" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>MetaModelHasAdditionalInformation.AdditionalInformation</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="MetaModelLibrary" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>MetaModelHasMetaModelLibraries.MetaModelLibraries</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="View" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>MetaModelHasView.View</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="BaseModelContext" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>MetaModelHasModelContexts.ModelContexts</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="PropertyGridEditor" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>MetaModelHasPropertyGridEditors.PropertyGridEditors</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="a7d39201-2729-4434-a67f-89643bfe6c3e" Description="Description for Tum.PDE.LanguageDSL.DomainElement" Name="DomainElement" DisplayName="Domain Element" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL" />
    <DomainClass Id="ec2ab13c-ad0b-41f1-acda-a7833553b261" Description="Description for Tum.PDE.LanguageDSL.NamedDomainElement" Name="NamedDomainElement" DisplayName="Named Domain Element" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="DomainElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="40c61eba-bc04-4d16-a89b-471c5c5c03c0" Description="Description for Tum.PDE.LanguageDSL.NamedDomainElement.Display Name" Name="DisplayName" DisplayName="Display Name" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="1860af85-15c6-49bb-bdde-2d0d14236496" Description="Description for Tum.PDE.LanguageDSL.NamedDomainElement.Is Display Name Tracking" Name="IsDisplayNameTracking" DisplayName="Is Display Name Tracking" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="02323aec-38b2-4f36-8e7f-00199da6d2ab" Description="Description for Tum.PDE.LanguageDSL.NamedDomainElement.Description" Name="Description" DisplayName="Description" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="29d0bfa5-62ea-426d-8267-d070be057422" Description="Description for Tum.PDE.LanguageDSL.NamedDomainElement.Name" Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="e088f1ce-75dc-4c05-a45a-6fa6a70d873c" Description="Description for Tum.PDE.LanguageDSL.AttributedDomainElement" Name="AttributedDomainElement" DisplayName="Attributed Domain Element" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="GeneratedDomainElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="82f19fe6-a238-42d9-b93e-ba2b15f77987" Description="Description for Tum.PDE.LanguageDSL.AttributedDomainElement.Serialization Name" Name="SerializationName" DisplayName="Serialization Name" Category="Serialization">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="cdad5669-46d0-4fcf-ab58-413707206496" Description="Description for Tum.PDE.LanguageDSL.AttributedDomainElement.Is Serialization Name Tracking" Name="IsSerializationNameTracking" DisplayName="Is Serialization Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DomainProperty" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>AttributedDomainElementHasProperties.Properties</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="d3d48011-2bc5-4e02-89a2-3150d8f3bdb6" Description="Description for Tum.PDE.LanguageDSL.DomainProperty" Name="DomainProperty" DisplayName="Domain Property" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="DomainElement" />
      </BaseClass>
      <CustomTypeDescriptor>
        <DomainTypeDescriptor CustomCoded="true" />
      </CustomTypeDescriptor>
      <Properties>
        <DomainProperty Id="011eafd4-f427-4bd9-8434-fdaa5e33a36a" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Name" Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="a60ea574-66fd-4f3d-8172-1793efa43afa" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Is Element Name" Name="IsElementName" DisplayName="Is Element Name" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="edeeac86-1648-4eda-9224-2d4e060aa191" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Is Required" Name="IsRequired" DisplayName="Is Required" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="fc123db7-231d-4dc8-aad5-e3a187bc0036" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Display Name" Name="DisplayName" DisplayName="Display Name" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="4b36beef-2ff1-45d2-8df8-204162aa38a6" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Description" Name="Description" DisplayName="Description" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f1066200-22e0-44b7-aab3-12a97e2db984" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Default Value" Name="DefaultValue" DisplayName="Default Value" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="0646a058-6c73-4ec5-b5c3-c647f9b9b4bb" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Category" Name="Category" DisplayName="Category" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="afab82e3-bba3-47a2-8c10-f1d21b838c8e" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Is Browsable" Name="IsBrowsable" DisplayName="Is Browsable" DefaultValue="true" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6665911e-04a9-4b53-a987-200e0dd870f7" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Getter Access Modifier" Name="GetterAccessModifier" DisplayName="Getter Access Modifier" DefaultValue="Public" Category="Code">
          <Type>
            <DomainEnumerationMoniker Name="AccessModifier" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f9a95e42-dd8e-46b9-b8d5-7a5bc63ae907" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Setter Access Modifier" Name="SetterAccessModifier" DisplayName="Setter Access Modifier" DefaultValue="Public" Category="Code">
          <Type>
            <DomainEnumerationMoniker Name="AccessModifier" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e15b49f3-2f0b-4ea9-bf44-9630295d9557" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Is Display Name Tracking" Name="IsDisplayNameTracking" DisplayName="Is Display Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="15bccd7b-eb87-4683-a722-b315a66ac923" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Serialization Name" Name="SerializationName" DisplayName="Serialization Name" Category="Serialization">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="acc470bf-9d84-4d89-8bf7-41e0f332e9cc" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Is Serialization Name Tracking" Name="IsSerializationNameTracking" DisplayName="Is Serialization Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="3d056f9b-d398-4cdb-ba57-d83605737cae" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Serialization Type" Name="SerializationRepresentationType" DisplayName="Serialization Type" DefaultValue="Attribute" Category="Serialization">
          <Type>
            <DomainEnumerationMoniker Name="SerializationRepresentationType" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ee7a0d53-6273-406c-b3be-a4c3abe3da4a" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Is UI Read Only" Name="IsUIReadOnly" DisplayName="Is UI Read Only" DefaultValue="false" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="bb95b928-f230-48c1-996d-eeec470acd52" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Property Kind" Name="PropertyKind" DisplayName="Property Kind" DefaultValue="Normal" Category="Definition">
          <Type>
            <DomainEnumerationMoniker Name="PropertyKind" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="03ee8d12-ddaa-4b3f-8315-65a73d81de76" Description="Description for Tum.PDE.LanguageDSL.DomainProperty.Is Custom Created" Name="IsCustomCreated" DisplayName="Is Custom Created" DefaultValue="false" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="646849d9-dee7-4dd7-afeb-4b60bb94584a" Description="Description for Tum.PDE.LanguageDSL.DomainRelationship" Name="DomainRelationship" DisplayName="Domain Relationship" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="AttributedDomainElement" />
      </BaseClass>
      <CustomTypeDescriptor>
        <DomainTypeDescriptor CustomCoded="true" />
      </CustomTypeDescriptor>
      <Properties>
        <DomainProperty Id="6a2b2a62-0c08-4481-a1e6-cffe79f86019" Description="Description for Tum.PDE.LanguageDSL.DomainRelationship.Is Name Tracking" Name="IsNameTracking" DisplayName="Is Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="1a3b837e-fc87-4702-8395-65c36af9ba02" Description="Description for Tum.PDE.LanguageDSL.DomainRelationship.Allows Duplicates" Name="AllowsDuplicates" DisplayName="Allows Duplicates" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DomainRole" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DomainRelationshipHasRoles.Roles</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="ae4eb892-dc73-435c-964b-187b543455bb" Description="Description for Tum.PDE.LanguageDSL.DomainClass" Name="DomainClass" DisplayName="Domain Class" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="AttributedDomainElement" />
      </BaseClass>
      <CustomTypeDescriptor>
        <DomainTypeDescriptor CustomCoded="true" />
      </CustomTypeDescriptor>
      <Properties>
        <DomainProperty Id="56ba89cc-fcb7-4290-b3a8-9eba7860e643" Description="Description for Tum.PDE.LanguageDSL.DomainClass.Is Domain Model" Name="IsDomainModel" DisplayName="Is Domain Model" DefaultValue="false" Category="Debug" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7b005976-c84b-4925-8112-7a48b38c8c8b" Description="Description for Tum.PDE.LanguageDSL.DomainClass.Can Copy" Name="CanCopy" DisplayName="Can Copy" DefaultValue="true" Category="Copy and Paste">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9dadec56-6cf1-4d98-b340-5bbbb444cf34" Description="Description for Tum.PDE.LanguageDSL.DomainClass.Can Move" Name="CanMove" DisplayName="Can Move" DefaultValue="true" Category="Copy and Paste">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="87268f1f-acd0-4865-a355-3bbf8f3401a4" Description="Description for Tum.PDE.LanguageDSL.DomainClass.Can Paste" Name="CanPaste" DisplayName="Can Paste" DefaultValue="true" Category="Copy and Paste">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8b4fa0b3-2157-4957-b7eb-636a4eda174f" Description="Description for Tum.PDE.LanguageDSL.DomainClass.Generate Specific View Model" Name="GenerateSpecificViewModel" DisplayName="Generate Specific View Model" DefaultValue="false" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="64857d34-ab1d-4d0a-b5d7-eb2cfda1b3bb" Description="Description for Tum.PDE.LanguageDSL.DomainClass.Generate Specific View Model Properties" Name="GenerateSpecificViewModelProperties" DisplayName="Generate Specific View Model Properties" DefaultValue="true" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="39c485b1-11b4-4c36-9402-eaa6e06815da" Description="Description for Tum.PDE.LanguageDSL.DomainClass.Generate Specific View Model References" Name="GenerateSpecificViewModelReferences" DisplayName="Generate Specific View Model References" DefaultValue="true" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d9de7618-d9a1-490d-a5ef-416451f2ebe6" Description="Description for Tum.PDE.LanguageDSL.DomainClass.Generate Specific View Model Embeddings" Name="GenerateSpecificViewModelEmbeddings" DisplayName="Generate Specific View Model Embeddings" DefaultValue="true" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="cded9af2-4fdc-4178-a8a4-9585cedaa78a" Description="Description for Tum.PDE.LanguageDSL.DomainClass.Generate Specific View Model Opposite References" Name="GenerateSpecificViewModelOppositeReferences" DisplayName="Generate Specific View Model Opposite References" DefaultValue="false" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="49e74ec6-6331-4e1e-8c50-6dfa774e17ea" Description="Description for Tum.PDE.LanguageDSL.DomainRole" Name="DomainRole" DisplayName="Domain Role" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="NamedDomainElement" />
      </BaseClass>
      <CustomTypeDescriptor>
        <DomainTypeDescriptor CustomCoded="true" />
      </CustomTypeDescriptor>
      <Properties>
        <DomainProperty Id="13d00637-432f-44a7-8da0-29bcca0b90d8" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Multiplicity" Name="Multiplicity" DisplayName="Multiplicity" DefaultValue="ZeroMany" Category="Definition">
          <Type>
            <DomainEnumerationMoniker Name="Multiplicity" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="2f1b915b-5af0-4e60-ac00-d2ba9186883f" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Property Name" Name="PropertyName" DisplayName="Property Name" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9c51a91e-8301-4085-b360-4aec576f6932" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Property Display Name" Name="PropertyDisplayName" DisplayName="Property Display Name" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="375a598b-7909-40f6-bdc6-7e90d8d2a790" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Is Property Name Tracking" Name="IsPropertyNameTracking" DisplayName="Is Property Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e819177a-b7f4-448b-9c74-a8c1232d1252" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Is Property Display Name Tracking" Name="IsPropertyDisplayNameTracking" DisplayName="Is Property Display Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="4331c932-2aba-4e47-9e17-95ff8ccf8350" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Category" Name="Category" DisplayName="Category" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9d7bae03-7e29-4413-880e-591cdf5755b4" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Property Getter Access Modifier" Name="PropertyGetterAccessModifier" DisplayName="Property Getter Access Modifier" DefaultValue="Public" Category="Code">
          <Type>
            <DomainEnumerationMoniker Name="AccessModifier" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="78f53368-eb27-4a5f-913a-97d4dafd78d9" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Property Setter Access Modifier" Name="PropertySetterAccessModifier" DisplayName="Property Setter Access Modifier" DefaultValue="Public" Category="Code">
          <Type>
            <DomainEnumerationMoniker Name="AccessModifier" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="33a8d594-1aab-4965-8ad0-b8d2b5914c78" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Is Property Browsable" Name="IsPropertyBrowsable" DisplayName="Is Property Browsable" DefaultValue="true" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e740b39a-0aa3-4348-a681-27193d5cfa9a" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Is Property Generator" Name="IsPropertyGenerator" DisplayName="Is Property Generator" DefaultValue="true" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6b4ae336-924c-4fca-a227-7bd8f2d7a607" Description="If True, an element playing this role in a link is deleted when the link is deleted." Name="PropagatesDelete" DisplayName="Propagates Delete" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="43dd086f-2a69-4970-8bb2-3076f73d0195" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Is Name Tracking" Name="IsNameTracking" DisplayName="Is Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c8d25682-99e8-4d3d-9ba3-534c54e9a018" Description="Description for Tum.PDE.LanguageDSL.DomainRole.Is Property UI Read Only" Name="IsPropertyUIReadOnly" DisplayName="Is Property UI Read Only" DefaultValue="false" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="3e569f62-2995-477f-9f68-514268e1c9c0" Description="Description for Tum.PDE.LanguageDSL.EmbeddingRelationship" Name="EmbeddingRelationship" DisplayName="Embedding Relationship" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="DomainRelationship" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="a981b88e-d83d-49e0-9964-57088535f758" Description="Description for Tum.PDE.LanguageDSL.EmbeddingRelationship.Propagates Copy To Child" Name="PropagatesCopyToChild" DisplayName="Propagates Copy To Child" DefaultValue="true" Category="Copy and Paste">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="7ce64682-be80-4515-83e5-2eed688e8cd7" Description="Description for Tum.PDE.LanguageDSL.ReferenceRelationship" Name="ReferenceRelationship" DisplayName="Reference Relationship" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="DomainRelationship" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="c85d2d0f-4828-4428-a41d-098758d09656" Description="Description for Tum.PDE.LanguageDSL.ReferenceRelationship.Serialization Attribute Name" Name="SerializationAttributeName" DisplayName="Serialization Attribute Name" DefaultValue="link" Category="Serialization">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ba52bf04-f96d-4062-b3a0-36da3d8b7220" Description="Description for Tum.PDE.LanguageDSL.ReferenceRelationship.Serialization Target Name" Name="SerializationTargetName" DisplayName="Serialization Target Name" DefaultValue="TargetRef" Category="Serialization">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="524aed9b-b8b5-4c2c-9320-d87820d62cda" Description="Description for Tum.PDE.LanguageDSL.ReferenceRelationship.Serialization Source Name" Name="SerializationSourceName" DisplayName="Serialization Source Name" DefaultValue="SourceRef" Category="Serialization">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="2686aa09-14a5-4015-9ad9-18c6274d8ba2" Description="Description for Tum.PDE.LanguageDSL.ReferenceRelationship.Propagates Copy To Target" Name="PropagatesCopyToTarget" DisplayName="Propagates Copy To Target" DefaultValue="true" Category="Copy and Paste">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="2588218f-ca28-4aec-af92-9ab01cf5acd4" Description="Description for Tum.PDE.LanguageDSL.ReferenceRelationship.Propagates Copy To Source" Name="PropagatesCopyToSource" DisplayName="Propagates Copy To Source" DefaultValue="false" Category="Copy and Paste">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="0f3bc43f-8ea7-4048-9d0b-27ee48bf29b1" Description="Description for Tum.PDE.LanguageDSL.ReferenceRelationship.Propagates Copy On Denied Element Copy" Name="PropagatesCopyOnDeniedElementCopy" DisplayName="Propagates Copy On Denied Element Copy" DefaultValue="true" Category="Copy and Paste">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ab5f339d-8692-434e-81f6-3278c3fce0a2" Description="Description for Tum.PDE.LanguageDSL.ReferenceRelationship.Is Serialization Target Name Tracking" Name="IsSerializationTargetNameTracking" DisplayName="Is Serialization Target Name Tracking" DefaultValue="False" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e20ec2e6-2817-4789-9558-3e8ce2cc61a2" Description="Description for Tum.PDE.LanguageDSL.ReferenceRelationship.Is Serialization Source Name Tracking" Name="IsSerializationSourceNameTracking" DisplayName="Is Serialization Source Name Tracking" DefaultValue="False" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="f8164594-4d3c-4671-83c8-7ccb19fcbc1d" Description="Description for Tum.PDE.LanguageDSL.DomainModelTreeView" Name="DomainModelTreeView" DisplayName="Domain Model Tree View" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="ModelTreeNode" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DomainModelTreeViewHasModelTreeNodes.ModelTreeNodes</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="9357c0b3-5d2e-4b0f-8eb0-2c078dbd912d" Description="Description for Tum.PDE.LanguageDSL.RootNode" Name="RootNode" DisplayName="Root Node" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="TreeNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="4dc441a0-16e7-4cc6-886d-a52caf556213" Description="Description for Tum.PDE.LanguageDSL.TreeNode" Name="TreeNode" DisplayName="Tree Node" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="ModelTreeNode" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="16c4eb6a-01be-41f6-9ae8-70a02e26c7e2" Description="Description for Tum.PDE.LanguageDSL.TreeNode.Is Embedding Tree Expanded" Name="IsEmbeddingTreeExpanded" DisplayName="Is Embedding Tree Expanded" DefaultValue="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="01cb77e1-9f33-4948-b274-ffdc3fc52fc0" Description="Description for Tum.PDE.LanguageDSL.TreeNode.Is Inheritance Tree Expanded" Name="IsInheritanceTreeExpanded" DisplayName="Is Inheritance Tree Expanded" DefaultValue="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="5507a915-7660-44d1-b527-67a8aeff6772" Description="Description for Tum.PDE.LanguageDSL.TreeNode.Is Reference Tree Expanded" Name="IsReferenceTreeExpanded" DisplayName="Is Reference Tree Expanded" DefaultValue="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="53064547-dad8-47a8-a762-4a7c5c9a510c" Description="Description for Tum.PDE.LanguageDSL.TreeNode.Is Shape Mapping Tree Expanded" Name="IsShapeMappingTreeExpanded" DisplayName="Is Shape Mapping Tree Expanded" DefaultValue="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="05edb8ab-451a-4de5-b33d-798746cf4fe6" Description="Description for Tum.PDE.LanguageDSL.TreeNode.Is Element Holder" Name="IsElementHolder" DisplayName="Is Element Holder" DefaultValue="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="4b568a54-91db-44fc-a3a0-aa8c4e69d846" Description="Description for Tum.PDE.LanguageDSL.TreeNode.Is Expanded" Name="IsExpanded" DisplayName="Is Expanded" DefaultValue="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="1bb74086-f9b8-44df-b85d-130a3153a1a8" Description="Description for Tum.PDE.LanguageDSL.EmbeddingRSNode" Name="EmbeddingRSNode" DisplayName="Embedding RSNode" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="ModelTreeNode" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="3560d0c8-caf3-4180-ba2f-b802e0907e0b" Description="Description for Tum.PDE.LanguageDSL.EmbeddingRSNode.Is Expanded" Name="IsExpanded" DisplayName="Is Expanded" DefaultValue="false" Category="Debug">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="09745d7b-25bc-41e8-8208-386f82c528ae" Description="Description for Tum.PDE.LanguageDSL.EmbeddingNode" Name="EmbeddingNode" DisplayName="Embedding Node" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="TreeNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="936f2196-dd2a-4fea-a586-691400918b70" Description="Description for Tum.PDE.LanguageDSL.InheritanceNode" Name="InheritanceNode" DisplayName="Inheritance Node" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="TreeNode" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="37515607-5e17-43ed-beba-13699d7fc406" Description="Description for Tum.PDE.LanguageDSL.InheritanceNode.Inh Relationship Id" Name="InhRelationshipId" DisplayName="Inh Relationship Id">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="b499418c-c05f-4cab-bb3c-f17a40a401c5" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNode" Name="ReferenceRSNode" DisplayName="Reference RSNode" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="ModelTreeNode" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="3a380724-63a5-4d3f-a83d-2f9cf0458936" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNode.Is Shape Mapping Tree Expanded" Name="IsShapeMappingTreeExpanded" DisplayName="Is Shape Mapping Tree Expanded" DefaultValue="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="2e456735-06e9-4cf2-a06f-5f6f1b048d2c" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNode.Is Expanded" Name="IsExpanded" DisplayName="Is Expanded" DefaultValue="false">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="27dc98d4-1a96-4d84-8958-abd13dbbb771" Description="Description for Tum.PDE.LanguageDSL.ReferenceNode" Name="ReferenceNode" DisplayName="Reference Node" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="TreeNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="fae8225e-f874-421b-9336-3b3ef6c382b2" Description="Description for Tum.PDE.LanguageDSL.ShapeClassNode" Name="ShapeClassNode" DisplayName="Shape Class Node" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="ModelTreeNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="ac6e7bf0-0b2b-4764-a333-0d7f229bde43" Description="Description for Tum.PDE.LanguageDSL.ShapeRelationshipNode" Name="ShapeRelationshipNode" DisplayName="Shape Relationship Node" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="ModelTreeNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="7d9d4097-7342-48ec-af25-787df6595c6a" Description="Description for Tum.PDE.LanguageDSL.DomainType" Name="DomainType" DisplayName="Domain Type" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <CustomTypeDescriptor>
        <DomainTypeDescriptor CustomCoded="true" />
      </CustomTypeDescriptor>
      <Properties>
        <DomainProperty Id="6b5516e6-257d-4242-aca7-3c230ff00c46" Description="Description for Tum.PDE.LanguageDSL.DomainType.Namespace" Name="Namespace" DisplayName="Namespace" DefaultValue="" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="3f836ca9-c006-4732-a72a-5385cc7ee009" Description="Description for Tum.PDE.LanguageDSL.DomainType.Serialization Style" Name="SerializationStyle" DisplayName="Serialization Style" DefaultValue="Normal" Category="Serialization">
          <Type>
            <DomainEnumerationMoniker Name="SerializationStyle" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="243bd4da-9b66-4a8b-9e1d-8a2f2eccc3e3" Description="Description for Tum.PDE.LanguageDSL.DomainType.Name" Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c923b222-c0fc-44c7-9863-a39f5e3227dd" Description="Description for Tum.PDE.LanguageDSL.DomainType.Description" Name="Description" DisplayName="Description" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="98f0d5cb-ecc3-43c4-ad97-b4d88aca0c63" Description="Description for Tum.PDE.LanguageDSL.DomainType.Display Name" Name="DisplayName" DisplayName="Display Name" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="000db4dc-1cc7-4ab3-9543-0929541e3cf1" Description="Description for Tum.PDE.LanguageDSL.DomainType.Is Display Name Tracking" Name="IsDisplayNameTracking" DisplayName="Is Display Name Tracking" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d9b1f45e-1d2c-46cc-93ff-99bd103005a3" Description="Description for Tum.PDE.LanguageDSL.DomainType.Requires Serialization Conversion" Name="RequiresSerializationConversion" DisplayName="Requires Serialization Conversion" DefaultValue="false" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="b438e655-8a4e-458f-87e4-4c1ba55b8483" Description="Description for Tum.PDE.LanguageDSL.ExternalType" Name="ExternalType" DisplayName="External Type" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="DomainType" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="21eb35bf-2b56-4fee-8f44-872eaef72259" Description="Description for Tum.PDE.LanguageDSL.DomainEnumeration" Name="DomainEnumeration" DisplayName="Domain Enumeration" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="DomainType" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="6b6bd2a1-d780-4280-bbde-3f69c994dfe2" Description="Description for Tum.PDE.LanguageDSL.DomainEnumeration.Access Modifier" Name="AccessModifier" DisplayName="Access Modifier" DefaultValue="Public" Category="Code">
          <Type>
            <DomainEnumerationMoniker Name="AccessModifier" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ae314cb0-488e-4144-9548-a9931d0ee539" Description="Description for Tum.PDE.LanguageDSL.DomainEnumeration.Is Flags" Name="IsFlags" DisplayName="Is Flags" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="EnumerationLiteral" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DomainEnumerationHasLiterals.Literals</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="21833341-940d-4e08-917a-6f562772b29f" Description="Description for Tum.PDE.LanguageDSL.EnumerationLiteral" Name="EnumerationLiteral" DisplayName="Enumeration Literal" Namespace="Tum.PDE.LanguageDSL">
      <Properties>
        <DomainProperty Id="a164078a-adfe-4528-b6d6-14f4b9c44fb3" Description="Description for Tum.PDE.LanguageDSL.EnumerationLiteral.Name" Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="235cde82-6b28-4a67-a538-9899a2152286" Description="Description for Tum.PDE.LanguageDSL.EnumerationLiteral.Description" Name="Description" DisplayName="Description" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="be07da5b-ebb7-482d-a7c9-c35dd2ce01b2" Description="Description for Tum.PDE.LanguageDSL.EnumerationLiteral.Value" Name="Value" DisplayName="Value" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="0ef6bd4d-501e-4833-b9ac-7e4cf1556b62" Description="Description for Tum.PDE.LanguageDSL.EnumerationLiteral.Display Name" Name="DisplayName" DisplayName="Display Name" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9bc33ccf-2aec-420d-bb98-2ada1204ec36" Description="Description for Tum.PDE.LanguageDSL.EnumerationLiteral.Is Display Name Tracking" Name="IsDisplayNameTracking" DisplayName="Is Display Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="06d17f35-3a86-49ad-8bfd-4e6456b42dda" Description="Description for Tum.PDE.LanguageDSL.EnumerationLiteral.Serialization Name" Name="SerializationName" DisplayName="Serialization Name" Category="Serialization">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d3fab988-0812-499e-9e0b-9fd2604c05ee" Description="Description for Tum.PDE.LanguageDSL.EnumerationLiteral.Is Serialization Name Tracking" Name="IsSerializationNameTracking" DisplayName="Is Serialization Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="062ecb95-5e81-4ca8-b43d-b0505202603b" Description="Description for Tum.PDE.LanguageDSL.DiagramClass" Name="DiagramClass" DisplayName="Diagram Class" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <Properties>
        <DomainProperty Id="aba80568-a75a-4152-8b07-16aeaf85941a" Description="Description for Tum.PDE.LanguageDSL.DiagramClass.Name" Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="960eb93f-2e08-48b2-b6e0-6ef1fd0f470a" Description="Description for Tum.PDE.LanguageDSL.DiagramClass.Title" Name="Title" DisplayName="Title" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="27fd4b35-2e59-48d9-bd0d-4036f23a88c4" Description="Description for Tum.PDE.LanguageDSL.DiagramClass.Is Custom" Name="IsCustom" DisplayName="Is Custom" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d2d714af-4270-4ddf-8f13-425396a4ea41" Description="Description for Tum.PDE.LanguageDSL.DiagramClass.Visualization Behavior" Name="VisualizationBehavior" DisplayName="Visualization Behavior" DefaultValue="Extended" Category="Definition">
          <Type>
            <DomainEnumerationMoniker Name="DiagramVisualizationBehavior" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="PresentationElementClass" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DiagramClassHasPresentationElements.PresentationElements</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="8d6eb420-78c9-47b5-8c01-e44e09895fed" Description="Description for Tum.PDE.LanguageDSL.DiagramClassView" Name="DiagramClassView" DisplayName="Diagram Class View" Namespace="Tum.PDE.LanguageDSL">
      <Properties>
        <DomainProperty Id="c4606acf-80fe-4624-9e18-eea563e557c2" Description="Description for Tum.PDE.LanguageDSL.DiagramClassView.Is Expanded" Name="IsExpanded" DisplayName="Is Expanded" DefaultValue="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="RootDiagramNode" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DiagramClassViewHasRootDiagramNodes.RootDiagramNodes</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="316511e2-97f6-494c-9e5b-39cd91f50f6f" Description="Description for Tum.PDE.LanguageDSL.PresentationElementClass" Name="PresentationElementClass" DisplayName="Presentation Element Class" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="AttributedDomainElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="c51f1744-2190-4356-b070-f43b62e36757" Description="Description for Tum.PDE.LanguageDSL.PresentationElementClass.Generate Properties VM" Name="GeneratePropertiesVM" DisplayName="Generate Properties VM" DefaultValue="true" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="3e7b67ce-afa2-400b-b7fd-909d9e0cff3c" Description="Description for Tum.PDE.LanguageDSL.PresentationElementClass.Generate Shape Properties VM" Name="GenerateShapePropertiesVM" DisplayName="Generate Shape Properties VM" DefaultValue="false" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="f2a50461-68e0-434b-8041-76cb95f1c8e5" Description="Description for Tum.PDE.LanguageDSL.ShapeClass" Name="ShapeClass" DisplayName="Shape Class" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="PresentationDomainClassElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="b0e8f0c7-fa14-43fe-9805-0639075b036f" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Default Width" Name="DefaultWidth" DisplayName="Default Width" DefaultValue="150" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="37949dfb-8351-411b-93a3-f6abe004620c" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Default Height" Name="DefaultHeight" DisplayName="Default Height" DefaultValue="50" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="55ab9bac-2caa-4f62-bee2-59bd03e521f9" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Is Fixed Width" Name="IsFixedWidth" DisplayName="Is Fixed Width" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="1060a8a2-169c-4bd3-9427-b613e48d8acc" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Is Fixed Height" Name="IsFixedHeight" DisplayName="Is Fixed Height" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f2d4acef-aa56-4d55-aea2-06406ed344d3" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Is Relative Child" Name="IsRelativeChild" DisplayName="Is Relative Child" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="a2d1b5f5-2039-45f7-9b19-a43e6a6ffcc7" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Relative Child Behaviour" Name="RelativeChildBehaviour" DisplayName="Relative Child Behaviour" DefaultValue="PositionRelativeToParent" Category="Definition">
          <Type>
            <DomainEnumerationMoniker Name="RelativeChildBehaviour" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7ea8e7d1-b300-4bc3-8c57-3af78e83a0a4" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Is Auto Generated" Name="IsAutoGenerated" DisplayName="Is Auto Generated" DefaultValue="true" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="dba80fc8-813e-46b1-bff7-4e53a0e7baf6" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Border Thickness" Name="BorderThickness" DisplayName="Border Thickness" DefaultValue="1.0" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="381b9e50-d93b-4c20-bb71-17d53b7d7d99" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Background Brush" Name="BackgroundBrush" DisplayName="Background Brush" DefaultValue="White" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System.Drawing/Color" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="3c94a1b2-7fdf-4bde-b796-c63b4efc5e86" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Border Brush" Name="BorderBrush" DisplayName="Border Brush" DefaultValue="Black" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System.Drawing/Color" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b779f807-e8ba-4763-b9c7-b2bc0cd25791" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Border Outer Brush" Name="BorderOuterBrush" DisplayName="Border Outer Brush" DefaultValue="White" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System.Drawing/Color" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="162a361f-22ba-4815-841a-bba6ee83d056" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Border Outer Size" Name="BorderOuterSize" DisplayName="Border Outer Size" DefaultValue="3.0" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="853fdcb1-1724-4808-9062-3da9e2bea6a6" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Border Corner Radius" Name="BorderCornerRadius" DisplayName="Border Corner Radius" DefaultValue="1.0" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="65e2afd6-fb6a-4e3e-87e0-72fa2fc60c95" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Border Is Hit Test Visible" Name="BorderIsHitTestVisible" DisplayName="Border Is Hit Test Visible" DefaultValue="true" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="a0baa39d-44bf-4529-b0b3-9ed802eae63f" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Border Focusable" Name="BorderFocusable" DisplayName="Border Focusable" DefaultValue="true" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="dacf000b-0a55-4d33-8c10-9139e35e8c85" Description="Absolute Uri to an menu icon that should be used in the insert menu bar to represent this shape." Name="MenuIconUri" DisplayName="Menu Icon Uri" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="1d5817ea-af7c-4d99-8353-dbc7689d87f0" Description="Description for Tum.PDE.LanguageDSL.ShapeClass.Use In Dependency View" Name="UseInDependencyView" DisplayName="Use In Dependency View" DefaultValue="false" Category="Dependency View">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="ba10b812-d4f3-4048-8b4f-1df5ce5a85b7" Description="Description for Tum.PDE.LanguageDSL.RelationshipShapeClass" Name="RelationshipShapeClass" DisplayName="Relationship Shape Class" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="PresentationElementClass" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="3516b91f-f90d-4878-9c15-9b3b63bd3ddb" Description="Description for Tum.PDE.LanguageDSL.RelationshipShapeClass.Is Auto Generated" Name="IsAutoGenerated" DisplayName="Is Auto Generated" DefaultValue="true" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="dadf5124-cd8e-4bab-aedf-669020f10a5e" Description="Description for Tum.PDE.LanguageDSL.RelationshipShapeClass.Start Anchor Style" Name="StartAnchorStyle" DisplayName="Start Anchor Style" DefaultValue="None" Category="Visualization">
          <Type>
            <DomainEnumerationMoniker Name="AnchorStyle" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="02315616-34d9-4957-9432-9af4c3d573be" Description="Description for Tum.PDE.LanguageDSL.RelationshipShapeClass.End Anchor Style" Name="EndAnchorStyle" DisplayName="End Anchor Style" DefaultValue="None" Category="Visualization">
          <Type>
            <DomainEnumerationMoniker Name="AnchorStyle" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c1dc003e-81ef-402f-886b-032ea3de2e6f" Description="Description for Tum.PDE.LanguageDSL.RelationshipShapeClass.Stroke Thickness" Name="StrokeThickness" DisplayName="Stroke Thickness" DefaultValue="1.0" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e844a992-1deb-4cd0-81be-cae1d47cfd86" Description="Description for Tum.PDE.LanguageDSL.RelationshipShapeClass.Stroke" Name="Stroke" DisplayName="Stroke" DefaultValue="Gray" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System.Drawing/Color" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="150e1bd7-0f5d-4852-899a-021ed03fefe9" Description="Description for Tum.PDE.LanguageDSL.GeneratedDomainElement" Name="GeneratedDomainElement" DisplayName="Generated Domain Element" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="NamedDomainElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="428af4d6-ac29-4f26-8862-9e06dcaf937c" Description="Description for Tum.PDE.LanguageDSL.GeneratedDomainElement.Generates Double Derived" Name="GeneratesDoubleDerived" DisplayName="Generates Double Derived" DefaultValue="false" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f3504032-1129-46a2-a263-26053ae31e62" Description="Description for Tum.PDE.LanguageDSL.GeneratedDomainElement.Has Custom Constructor" Name="HasCustomConstructor" DisplayName="Has Custom Constructor" DefaultValue="false" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9554f9b3-8587-4aeb-9a67-6780b30905bd" Description="Description for Tum.PDE.LanguageDSL.GeneratedDomainElement.Access Modifier" Name="AccessModifier" DisplayName="Access Modifier" DefaultValue="Public" Category="Code">
          <Type>
            <DomainEnumerationMoniker Name="AccessModifier" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c55506b1-10fc-45ca-b949-19b084f4bb85" Description="Description for Tum.PDE.LanguageDSL.GeneratedDomainElement.Inheritance Modifier" Name="InheritanceModifier" DisplayName="Inheritance Modifier" DefaultValue="None" Category="Code">
          <Type>
            <DomainEnumerationMoniker Name="InheritanceModifier" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="3afd39f2-7ca6-44bb-a865-264143285683" Description="Description for Tum.PDE.LanguageDSL.GeneratedDomainElement.Namespace" Name="Namespace" DisplayName="Namespace" DefaultValue="DslEditor.Model" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="6547e247-bfa9-456c-b540-bbf76a10e1be" Description="Description for Tum.PDE.LanguageDSL.RootDiagramNode" Name="RootDiagramNode" DisplayName="Root Diagram Node" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="EmbeddingDiagramNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="e96b96b0-0b4b-44dd-8087-d1881990f523" Description="Description for Tum.PDE.LanguageDSL.EmbeddingDiagramNode" Name="EmbeddingDiagramNode" DisplayName="Embedding Diagram Node" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="DiagramTreeNode" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="e870b0b5-1c52-4443-b8f2-44f995cdf785" Description="Description for Tum.PDE.LanguageDSL.EmbeddingDiagramNode.Is Expanded" Name="IsExpanded" DisplayName="Is Expanded" DefaultValue="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="3196632d-5c75-4bb3-a72d-b7c69777b981" Description="Description for Tum.PDE.LanguageDSL.EmbeddingDiagramNode.Is Children Tree Expanded" Name="IsChildrenTreeExpanded" DisplayName="Is Children Tree Expanded" DefaultValue="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="EmbeddingDiagramNode" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>EmbeddingDiagramNodeHasEmbeddingDiagramNodes.EmbeddingDiagramNodes</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="62549bd8-1786-49ef-b98b-920372813c22" Description="Description for Tum.PDE.LanguageDSL.DiagramTreeNode" Name="DiagramTreeNode" DisplayName="Diagram Tree Node" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL" />
    <DomainClass Id="ea32ef79-30e2-47b4-90f5-2bc013322097" Description="Description for Tum.PDE.LanguageDSL.SerializationModel" Name="SerializationModel" DisplayName="Serialization Model" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <Properties>
        <DomainProperty Id="e3c25fae-f05c-4b06-a8dd-02493529cf39" Description="Description for Tum.PDE.LanguageDSL.SerializationModel.Serialized Id Attribute Name" Name="SerializedIdAttributeName" DisplayName="Serialized Id Attribute Name" DefaultValue="Id" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="SerializedDomainModel" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>SerializationModelHasSerializedDomainModel.SerializedDomainModel</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="SerializationClass" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>SerializationModelHasChildren.Children</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="9499bc53-1fb1-472b-97c5-04e23ad51469" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainModel" Name="SerializedDomainModel" DisplayName="Serialized Domain Model" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="SerializedDomainClass" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="00edea64-8ff8-4fd2-8dfc-ad11fd38a7bc" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainModel.Serialized Id Attribute Name" Name="SerializedIdAttributeName" DisplayName="Serialized Id Attribute Name" DefaultValue="Id" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="e2bd4f79-e74f-48da-b444-8a9971a92e2a" Description="Description for Tum.PDE.LanguageDSL.SerializationElement" Name="SerializationElement" DisplayName="Serialization Element" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL" />
    <DomainClass Id="03dadad3-8ebe-4324-90d7-34ba072ca27d" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainClass" Name="SerializedDomainClass" DisplayName="Serialized Domain Class" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="SerializationClass" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="0a44ab79-f97d-443f-913d-a9033954c3b1" Description="Description for Tum.PDE.LanguageDSL.SerializedEmbeddingRelationship" Name="SerializedEmbeddingRelationship" DisplayName="Serialized Embedding Relationship" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="SerializedRelationship" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="99127341-3123-4bdc-af42-ab29f9d6faf9" Description="If true, the target is expected to be a domain model which is included in a different file by using the xi:include tag" Name="IsTargetIncludedSubmodel" DisplayName="Is Target Included Submodel" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="614567aa-6f74-4ed9-9d2c-029d4c177cf9" Description="Description for Tum.PDE.LanguageDSL.SerializedReferenceRelationship" Name="SerializedReferenceRelationship" DisplayName="Serialized Reference Relationship" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="SerializedRelationship" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="a0f7f048-2974-469d-9016-5537b30ffa82" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainProperty" Name="SerializedDomainProperty" DisplayName="Serialized Domain Property" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="SerializationAttributeElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="e940daf7-9728-497f-a561-1c4da012ca30" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainProperty.Serialization Name" Name="SerializationName" DisplayName="Serialization Name" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9620e25d-cb33-4b42-b153-c3422998c466" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainProperty.Serialization Representation Type" Name="SerializationRepresentationType" DisplayName="Serialization Representation Type" Category="Definition">
          <Type>
            <DomainEnumerationMoniker Name="SerializationRepresentationType" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="924f2d34-32b9-4bc0-87d9-3b208f41761e" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainProperty.Is Serialization Name Tracking" Name="IsSerializationNameTracking" DisplayName="Is Serialization Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6b25dcc0-b592-4807-aecf-3d5f71329f3c" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainProperty.Omit Property" Name="OmitProperty" DisplayName="Omit Property" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="5252df02-8fb4-4255-971d-4cd79317724c" Description="Description for Tum.PDE.LanguageDSL.SerializationClass" Name="SerializationClass" DisplayName="Serialization Class" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="SerializationElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="a5715976-e41c-4d24-ba3c-64ff66ab9e64" Description="Description for Tum.PDE.LanguageDSL.SerializationClass.Is Serialization Name Tracking" Name="IsSerializationNameTracking" DisplayName="Is Serialization Name Tracking" DefaultValue="True" Category="Debug" IsUIReadOnly="true">
          <Type>
            <DomainEnumerationMoniker Name="TrackingEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="a4275bed-deff-4d01-8e75-477a43ee2fb3" Description="Description for Tum.PDE.LanguageDSL.SerializationClass.Serialization Name" Name="SerializationName" DisplayName="Serialization Name" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="SerializedIdProperty" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>SerializationClassHasIdProperty.IdProperty</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="SerializedDomainProperty" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>SerializationClassHasProperties.Properties</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="f47aabf7-6d3d-4b0e-95f3-c714ad611cf4" Description="Description for Tum.PDE.LanguageDSL.SerializedIdProperty" Name="SerializedIdProperty" DisplayName="Serialized Id Property" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="SerializationAttributeElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="f8c74823-186d-48a9-a3f0-8b94843359f3" Description="Description for Tum.PDE.LanguageDSL.SerializedIdProperty.Name" Name="Name" DisplayName="Name" DefaultValue="Id" Category="Definition" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7ac6784f-2b81-4c89-95b6-5f7c605a5bc1" Description="Description for Tum.PDE.LanguageDSL.SerializedIdProperty.Serialization Name" Name="SerializationName" DisplayName="Serialization Name" DefaultValue="Id" Category="Definition" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="be9b0871-6566-44ed-af05-02ec1600d0cf" Description="Description for Tum.PDE.LanguageDSL.SerializedIdProperty.Omit Id Property" Name="OmitIdProperty" DisplayName="Omit Id Property" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="f44c1d91-023c-4c98-9b8e-d1fc680e4f89" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainRole" Name="SerializedDomainRole" DisplayName="Serialized Domain Role" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="SerializationElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="d074d7f6-b45b-4c27-a424-7342294be0d4" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainRole.Serialization Name" Name="SerializationName" DisplayName="Serialization Name" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="5fe764d1-0df6-4294-b674-427881c7975e" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainRole.Serialization Attribute Name" Name="SerializationAttributeName" DisplayName="Serialization Attribute Name" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="78c96b19-33b3-4c04-ae9f-fe024805251b" Description="Description for Tum.PDE.LanguageDSL.SerializationAttributeElement" Name="SerializationAttributeElement" DisplayName="Serialization Attribute Element" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="SerializationElement" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="69e03ca4-2947-4651-9220-67707c7f0f7d" Description="Description for Tum.PDE.LanguageDSL.Validation" Name="Validation" DisplayName="Validation" Namespace="Tum.PDE.LanguageDSL">
      <Properties>
        <DomainProperty Id="dd1eb631-9a07-4341-b63e-d69da89ae12b" Description="Description for Tum.PDE.LanguageDSL.Validation.Use Load" Name="UseLoad" DisplayName="Use Load" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b0a7015d-8f23-4994-b381-44e0392fb5dd" Description="Description for Tum.PDE.LanguageDSL.Validation.Use Menu" Name="UseMenu" DisplayName="Use Menu" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="5d3af6e4-587a-47af-acfe-73bd4c38421e" Description="Description for Tum.PDE.LanguageDSL.Validation.Use Open" Name="UseOpen" DisplayName="Use Open" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c36dc085-3bc1-4470-807b-f3dacfb9e8bf" Description="Description for Tum.PDE.LanguageDSL.Validation.Use Save" Name="UseSave" DisplayName="Use Save" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b2f0d280-0cbe-400b-9df6-733f292632e2" Description="Description for Tum.PDE.LanguageDSL.Validation.Use Auto Validation" Name="UseAutoValidation" DisplayName="Use Auto Validation" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="c0cd6878-c5a2-4671-8dd4-61c425d0158a" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClass" Name="MappingRelationshipShapeClass" DisplayName="Mapping Relationship Shape Class" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="PresentationDomainClassElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="1c56fe5e-9398-45ad-ae90-8515af0387ed" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClass.Is Auto Generated" Name="IsAutoGenerated" DisplayName="Is Auto Generated" DefaultValue="true" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="45ec85ce-e4e2-4449-b39a-2da70101d72c" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClass.Start Anchor Style" Name="StartAnchorStyle" DisplayName="Start Anchor Style" DefaultValue="None" Category="Visualization">
          <Type>
            <DomainEnumerationMoniker Name="AnchorStyle" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="75bd252c-9594-474a-bdd2-69516d70cd54" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClass.End Anchor Style" Name="EndAnchorStyle" DisplayName="End Anchor Style" DefaultValue="None" Category="Visualization">
          <Type>
            <DomainEnumerationMoniker Name="AnchorStyle" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="549a1b96-8065-4ab2-9d73-9c7a309aced2" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClass.Stroke Thickness" Name="StrokeThickness" DisplayName="Stroke Thickness" DefaultValue="1.0" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System/Double" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9e008b40-c515-4acd-9292-56eda0205f95" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClass.Stroke" Name="Stroke" DisplayName="Stroke" DefaultValue="Gray" Category="Visualization">
          <Type>
            <ExternalTypeMoniker Name="/System.Drawing/Color" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="fd257395-3eb9-4164-b513-00783afd0c85" Description="Description for Tum.PDE.LanguageDSL.DiagramView" Name="DiagramView" DisplayName="Diagram View" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DiagramClassView" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DiagramViewHasDiagramClassViews.DiagramClassViews</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="59ed98b4-8bde-4eec-9495-69aac65fa96e" Description="Description for Tum.PDE.LanguageDSL.DesignerDiagramClass" Name="DesignerDiagramClass" DisplayName="Designer Diagram Class" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="DiagramClass" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="23c03dd2-1dff-497d-988b-3d63afe009ed" Description="Description for Tum.PDE.LanguageDSL.PresentationDomainClassElement" Name="PresentationDomainClassElement" DisplayName="Presentation Domain Class Element" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="PresentationElementClass" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="24804ce0-051d-42a8-a89e-3e4babd873bf" Description="Description for Tum.PDE.LanguageDSL.ModelTreeNode" Name="ModelTreeNode" DisplayName="Model Tree Node" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL" />
    <DomainClass Id="49fa41f1-ee46-4690-bc17-b9cf1bc79bea" Description="Description for Tum.PDE.LanguageDSL.SerializedRelationship" Name="SerializedRelationship" DisplayName="Serialized Relationship" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="SerializationClass" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="c909e8c4-7687-454a-ad75-4c6b5ed7a3a7" Description="Description for Tum.PDE.LanguageDSL.SerializedRelationship.Is In Full Serialization" Name="IsInFullSerialization" DisplayName="Is In Full Serialization" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="949216d0-29a1-458c-bd98-716d2cf0805b" Description="Description for Tum.PDE.LanguageDSL.SerializedRelationship.Omit Relationship" Name="OmitRelationship" DisplayName="Omit Relationship" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="SerializedDomainRole" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>SerializedRelationshipHasSerializedDomainRoles.SerializedDomainRoles</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="850d43f8-8f27-4f58-950e-2fce7c28ed90" Description="Description for Tum.PDE.LanguageDSL.Credits" Name="Credits" DisplayName="Credits" Namespace="Tum.PDE.LanguageDSL">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="CreditItem" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>CreditsHasCreditItems.CreditItems</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="919a50f9-8f28-47a5-9fff-40608be6b966" Description="Description for Tum.PDE.LanguageDSL.CreditItem" Name="CreditItem" DisplayName="Credit Item" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="LinkItem" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="350cc410-17a7-4819-8cfd-7a2dd57276c9" Description="Description for Tum.PDE.LanguageDSL.AdditionalInformation" Name="AdditionalInformation" DisplayName="Additional Information" Namespace="Tum.PDE.LanguageDSL">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Credits" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>AdditionalInformationHasCredits.Credits</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="FurtherInformation" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>AdditionalInformationHasFurtherInformation.FurtherInformation</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="00524ba8-7dde-4fff-896b-b8489fdce375" Description="Description for Tum.PDE.LanguageDSL.FurtherInformation" Name="FurtherInformation" DisplayName="Further Information" Namespace="Tum.PDE.LanguageDSL">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="InformationItem" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>FurtherInformationHasInformationItems.InformationItems</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="dc872f5b-4941-40c8-b665-b5f5a22430c6" Description="Description for Tum.PDE.LanguageDSL.InformationItem" Name="InformationItem" DisplayName="Information Item" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="LinkItem" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="40d03eb0-f578-425e-a3c0-bdc15c8d223d" Description="Description for Tum.PDE.LanguageDSL.LinkItem" Name="LinkItem" DisplayName="Link Item" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <Properties>
        <DomainProperty Id="8ad74ca9-a901-4b53-b3f9-0ec44f6169e0" Description="Description for Tum.PDE.LanguageDSL.LinkItem.Title" Name="Title" DisplayName="Title" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="17d8ffbd-af05-416e-bdaa-5c14e7faf189" Description="Description for Tum.PDE.LanguageDSL.LinkItem.Description" Name="Description" DisplayName="Description" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="dd88473a-0b8f-4c82-ae72-b59491c84eb8" Description="Description for Tum.PDE.LanguageDSL.LinkItem.Link" Name="Link" DisplayName="Link" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="35507d23-2bf2-47be-a1bd-4c336e3513e0" Description="Description for Tum.PDE.LanguageDSL.LinkItem.Category" Name="Category" DisplayName="Category" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="d532721c-6815-4ffe-9d94-fff466a53b89" Description="Description for Tum.PDE.LanguageDSL.MetaModelLibrary" Name="MetaModelLibrary" DisplayName="Meta Model Library" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <Properties>
        <DomainProperty Id="83fea363-08e6-4bfb-ac40-8e8c985e22bd" Description="Description for Tum.PDE.LanguageDSL.MetaModelLibrary.File Path" Name="FilePath" DisplayName="File Path" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(Tum.PDE.LanguageDSL.Design.MetaModelLibraryImportEditor)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="82746305-cc3f-476b-b897-5ee5f9c5f35c" Description="Description for Tum.PDE.LanguageDSL.MetaModelLibrary.Name" Name="Name" DisplayName="Name" Category="Definition" IsElementName="true" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="BaseMetaModel" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>MetaModelLibraryHasImportedLibrary.ImportedLibrary</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="3fbc33af-0d43-4ca5-99a8-1f4f7110a6b5" Description="Description for Tum.PDE.LanguageDSL.BaseMetaModel" Name="BaseMetaModel" DisplayName="Base Meta Model" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL" />
    <DomainClass Id="47bdd9c3-8ea1-490f-911c-b230eef810f6" Description="Description for Tum.PDE.LanguageDSL.ViewContext" Name="ViewContext" DisplayName="View Context" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="BaseViewContext" />
      </BaseClass>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DomainModelTreeView" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ViewContextHasDomainModelTreeView.DomainModelTreeView</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DiagramView" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ViewContextHasDiagramView.DiagramView</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="1d8ee4be-55f8-43cd-9bce-9c38d098ed97" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContext" Name="LibraryModelContext" DisplayName="Library Model Context" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="BaseModelContext" />
      </BaseClass>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DomainClass" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>LibraryModelContextHasClasses.Classes</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DiagramClass" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>LibraryModelContextHasDiagramClasses.DiagramClasses</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DomainRelationship" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>LibraryModelContextHasRelationships.Relationships</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="SerializationModel" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>LibraryModelContextHasSerializationModel.SerializationModel</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="6bd20701-c129-4c93-a2b5-2fb8a6ac563c" Description="Description for Tum.PDE.LanguageDSL.View" Name="View" DisplayName="View" Namespace="Tum.PDE.LanguageDSL">
      <Properties>
        <DomainProperty Id="38fca617-178c-4641-b54d-b20e7f21bcbc" Description="Description for Tum.PDE.LanguageDSL.View.Create Model Tree" Name="CreateModelTree" DisplayName="Create Model Tree" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ed20157c-8654-40a4-92d2-c473ea07e5f3" Description="Description for Tum.PDE.LanguageDSL.View.Create Property Grid" Name="CreatePropertyGrid" DisplayName="Create Property Grid" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="536b48a4-a5e2-4875-ae99-6fe7019ed14a" Description="Description for Tum.PDE.LanguageDSL.View.Create Error List" Name="CreateErrorList" DisplayName="Create Error List" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="a0e5225c-6e49-4d41-ad2e-454d049a10d7" Description="Description for Tum.PDE.LanguageDSL.View.Create Dependencies View" Name="CreateDependenciesView" DisplayName="Create Dependencies View" DefaultValue="true" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ec738e6c-68f7-40a2-8d81-1f30e1abc23c" Description="Description for Tum.PDE.LanguageDSL.View.Model Tree Id" Name="ModelTreeId" DisplayName="Model Tree Id" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c231a15a-feac-4c23-818d-6c9cdf62136b" Description="Description for Tum.PDE.LanguageDSL.View.Property Grid Id" Name="PropertyGridId" DisplayName="Property Grid Id" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="02421f5c-598c-45cb-ae57-273aa6925f77" Description="Description for Tum.PDE.LanguageDSL.View.Error List Id" Name="ErrorListId" DisplayName="Error List Id" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="4f0004bc-bc65-487f-989c-4c78651d7d98" Description="Description for Tum.PDE.LanguageDSL.View.Dependencies View Id" Name="DependenciesViewId" DisplayName="Dependencies View Id" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="4cc15b2e-59fe-4454-9c69-1c3511fef5b5" Description="Description for Tum.PDE.LanguageDSL.View.Search Id" Name="SearchId" DisplayName="Search Id" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="84fa93a8-cf68-456f-9732-92444b1bd390" Description="Description for Tum.PDE.LanguageDSL.View.Search Result Id" Name="SearchResultId" DisplayName="Search Result Id" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="30774d16-c743-40ea-944d-d7733630b635" Description="Description for Tum.PDE.LanguageDSL.View.Plugin Window Id" Name="PluginWindowId" DisplayName="Plugin Window Id" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="BaseViewContext" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ViewHasViewContexts.ViewContexts</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="ModelTree" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ViewHasModelTree.ModelTree</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="63c0544d-fab1-4d2d-b274-87af605239b3" Description="Description for Tum.PDE.LanguageDSL.PropertyGridEditor" Name="PropertyGridEditor" DisplayName="Property Grid Editor" Namespace="Tum.PDE.LanguageDSL" GeneratesDoubleDerived="true">
      <Properties>
        <DomainProperty Id="50b4c8b9-55bd-4880-a9d1-279ce2c00054" Description="Description for Tum.PDE.LanguageDSL.PropertyGridEditor.Name" Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="35936433-dac1-4a93-95de-016d205658c1" Description="Description for Tum.PDE.LanguageDSL.PropertyGridEditor.Namespace" Name="Namespace" DisplayName="Namespace" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6a631f55-5f85-4a00-8355-4bef8f58565f" Description="Description for Tum.PDE.LanguageDSL.PropertyGridEditor.Should Be Generated" Name="ShouldBeGenerated" DisplayName="Should Be Generated" DefaultValue="true" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7e447735-d33e-4bbd-9633-15039987bbdf" Description="Only relevant if Should Be Generated is set to true." Name="EditorBaseType" DisplayName="Editor Base Type" DefaultValue="PropertyEditorViewModel" Category="Code">
          <Type>
            <DomainEnumerationMoniker Name="EditorBaseType" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d330a44f-9088-4759-b600-b81ea36d1893" Description="Description for Tum.PDE.LanguageDSL.PropertyGridEditor.Requires Context Menu Bar" Name="RequiresContextMenuBar" DisplayName="Requires Context Menu Bar" DefaultValue="false" Category="Code">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="8c56384f-c8dc-4845-a6fb-c434a2303c60" Description="Description for Tum.PDE.LanguageDSL.BaseModelContext" Name="BaseModelContext" DisplayName="Base Model Context" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="NamedDomainElement" />
      </BaseClass>
      <CustomTypeDescriptor>
        <DomainTypeDescriptor CustomCoded="true" />
      </CustomTypeDescriptor>
      <Properties>
        <DomainProperty Id="65c0689e-877f-486d-a29e-e4bf9a908e94" Description="Description for Tum.PDE.LanguageDSL.BaseModelContext.Is Default" Name="IsDefault" DisplayName="Is Default" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="0b6e862a-e43e-4274-95dc-9c0d808df0fa" Description="Description for Tum.PDE.LanguageDSL.ExternModelContext" Name="ExternModelContext" DisplayName="Extern Model Context" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="BaseModelContext" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="a62634e4-bb49-466a-a2e1-683c0adaab7a" Description="Description for Tum.PDE.LanguageDSL.BaseViewContext" Name="BaseViewContext" DisplayName="Base View Context" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL" />
    <DomainClass Id="4347ae81-063c-40af-8ebe-161005a6c535" Description="Description for Tum.PDE.LanguageDSL.ExternViewContext" Name="ExternViewContext" DisplayName="Extern View Context" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="BaseViewContext" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="538c7984-6aa4-461e-bdaf-4078eba01fcd" Description="Description for Tum.PDE.LanguageDSL.ModelContext" Name="ModelContext" DisplayName="Model Context" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="LibraryModelContext" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="0342973e-d5c0-41ad-8e6a-34d2b1d402ab" Description="Description for Tum.PDE.LanguageDSL.ModelTree" Name="ModelTree" DisplayName="Model Tree" Namespace="Tum.PDE.LanguageDSL">
      <Properties>
        <DomainProperty Id="38aeb98d-e5bd-421b-af34-0f4bd1f0a740" Description="Description for Tum.PDE.LanguageDSL.ModelTree.Sorting Behavior" Name="SortingBehavior" DisplayName="Sorting Behavior" DefaultValue="Alphabetical" Category="Definition">
          <Type>
            <DomainEnumerationMoniker Name="SortingBehavior" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="47c39782-ce0d-442c-b43f-8bbfb84f5a54" Description="Description for Tum.PDE.LanguageDSL.ModelTree.Can Move Elements" Name="CanMoveElements" DisplayName="Can Move Elements" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="ebcfc0db-1594-4bc1-9486-7d06d990703e" Description="Description for Tum.PDE.LanguageDSL.TemplatedDiagramClass" Name="TemplatedDiagramClass" DisplayName="Templated Diagram Class" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="DiagramClass" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="a80e588f-20eb-4dbd-9775-d4357dd99b03" Description="Description for Tum.PDE.LanguageDSL.TemplatedDiagramClass.Unique Id" Name="UniqueId" DisplayName="Unique Id" Category="Definition" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="89385e34-86e0-4239-b33d-5eb473eb9f17" Description="Description for Tum.PDE.LanguageDSL.TemplatedDiagramClass.Description" Name="Description" DisplayName="Description" Category="Resources">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="ae2c9e8c-ca1e-488d-b87a-0d81e0cebb61" Description="Description for Tum.PDE.LanguageDSL.DependencyDiagram" Name="DependencyDiagram" DisplayName="Dependency Diagram" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="TemplatedDiagramClass" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="73c57370-316c-45b9-ae42-8325b0e6febd" Description="Description for Tum.PDE.LanguageDSL.SpecificDependencyDiagram" Name="SpecificDependencyDiagram" DisplayName="Specific Dependency Diagram" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="DependencyDiagram" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="e1f665f3-6684-4416-8a0c-ab1e7f86b916" Description="Description for Tum.PDE.LanguageDSL.ModalDiagram" Name="ModalDiagram" DisplayName="Modal Diagram" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="RestorableTemplatedDiagramVMOnly" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="d78e47ec-a3bd-4a4e-9879-39ac34c1d145" Description="Description for Tum.PDE.LanguageDSL.SpecificElementsDiagram" Name="SpecificElementsDiagram" DisplayName="Specific Elements Diagram" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="RestorableChildlessDiagram" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="34c2336e-bd25-40b2-b85f-f34483daa6e0" Description="Description for Tum.PDE.LanguageDSL.DesignerSurfaceDiagram" Name="DesignerSurfaceDiagram" DisplayName="Designer Surface Diagram" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="ChildlessDiagram" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="c1aa13e2-e584-49ba-8d0a-cdc64dcae654" Description="Description for Tum.PDE.LanguageDSL.ChildlessDiagram" Name="ChildlessDiagram" DisplayName="Childless Diagram" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="TemplatedDiagramClass" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="04825602-1d28-4b0f-9d1e-3c4a1aa914cc" Description="Description for Tum.PDE.LanguageDSL.TemplatedDiagramViewModelOnly" Name="TemplatedDiagramViewModelOnly" DisplayName="Templated Diagram View Model Only" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="ChildlessDiagram" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="d269770e-517f-47a2-846b-b355f1462588" Description="Description for Tum.PDE.LanguageDSL.RestorableChildlessDiagram" Name="RestorableChildlessDiagram" DisplayName="Restorable Childless Diagram" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="ChildlessDiagram" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="db0ad9be-41c5-41b5-951e-1c53df6d2325" Description="Description for Tum.PDE.LanguageDSL.RestorableTemplatedDiagramVMOnly" Name="RestorableTemplatedDiagramVMOnly" DisplayName="Restorable Templated Diagram VMOnly" InheritanceModifier="Abstract" Namespace="Tum.PDE.LanguageDSL">
      <BaseClass>
        <DomainClassMoniker Name="TemplatedDiagramViewModelOnly" />
      </BaseClass>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="1ca3e3d2-6711-4d10-a58c-1d6a44eb02a7" Description="Description for Tum.PDE.LanguageDSL.AttributedDomainElementHasProperties" Name="AttributedDomainElementHasProperties" DisplayName="Attributed Domain Element Has Properties" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="0176d1b0-fbd0-49b0-8929-1054d7c6bc7f" Description="Description for Tum.PDE.LanguageDSL.AttributedDomainElementHasProperties.DomainElement" Name="DomainElement" DisplayName="Domain Element" PropertyName="Properties" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Properties">
          <RolePlayer>
            <DomainClassMoniker Name="AttributedDomainElement" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="71da984f-3481-4158-bbe9-9c25b082e594" Description="Description for Tum.PDE.LanguageDSL.AttributedDomainElementHasProperties.DomainProperty" Name="DomainProperty" DisplayName="Domain Property" PropertyName="Element" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Element">
          <RolePlayer>
            <DomainClassMoniker Name="DomainProperty" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="19cffaef-872a-4edf-ae86-d012bfdd4524" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipHasRoles" Name="DomainRelationshipHasRoles" DisplayName="Domain Relationship Has Roles" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="19161800-bfae-4ee8-ae8e-cbc0dd637848" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipHasRoles.Relationship" Name="Relationship" DisplayName="Relationship" PropertyName="Roles" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" Category="Definition" IsPropertyBrowsable="false" PropertyDisplayName="Roles">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRelationship" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="6d597525-7c55-4b68-a63c-019bc8645d9a" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipHasRoles.Role" Name="Role" DisplayName="Role" PropertyName="Relationship" Multiplicity="One" PropagatesDelete="true" Category="Definition" IsPropertyBrowsable="false" PropertyDisplayName="Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRole" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="1ff930fb-9d9e-4289-b686-a532cc839ed5" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipReferencesSource" Name="DomainRelationshipReferencesSource" DisplayName="Domain Relationship References Source" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="958d1f01-c506-4b4c-a023-0b31c4defc4a" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipReferencesSource.Relationship" Name="Relationship" DisplayName="Relationship" PropertyName="Source" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" IsPropertyBrowsable="false" IsPropertyUIReadOnly="true" PropertyDisplayName="Source">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRelationship" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="47c3fd3c-4afc-4833-9a25-b1ec97712620" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipReferencesSource.Role" Name="Role" DisplayName="Role" PropertyName="Relationship" Multiplicity="One" IsPropertyGenerator="false" IsPropertyBrowsable="false" PropertyDisplayName="Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRole" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="7775cbde-70c8-47c4-b6eb-f63cffd86718" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipReferencesTarget" Name="DomainRelationshipReferencesTarget" DisplayName="Domain Relationship References Target" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="642bb33b-05dc-4f22-ab85-fdd87c6d1177" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipReferencesTarget.Relationship" Name="Relationship" DisplayName="Relationship" PropertyName="Target" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" IsPropertyBrowsable="false" IsPropertyUIReadOnly="true" PropertyDisplayName="Target">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRelationship" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="c6d4bde4-df8c-4c4e-b3a9-d60057e9d3f8" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipReferencesTarget.Role" Name="Role" DisplayName="Role" PropertyName="Relationship" Multiplicity="One" IsPropertyGenerator="false" IsPropertyBrowsable="false" PropertyDisplayName="Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRole" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="1b825453-62db-4322-90d4-43e91e5d7f1f" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNodeReferencesReferenceRelationship" Name="ReferenceRSNodeReferencesReferenceRelationship" DisplayName="Reference RSNode References Reference Relationship" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="e39964ef-2551-4bcb-b81c-437a7be113fe" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNodeReferencesReferenceRelationship.ReferenceRSNode" Name="ReferenceRSNode" DisplayName="Reference RSNode" PropertyName="ReferenceRelationship" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Reference Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="ReferenceRSNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="248583f9-3165-4e5b-b166-5c02d27e2469" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNodeReferencesReferenceRelationship.ReferenceRelationship" Name="ReferenceRelationship" DisplayName="Reference Relationship" PropertyName="ReferenceRSNode" Multiplicity="One" PropertyDisplayName="Reference RSNode">
          <RolePlayer>
            <DomainClassMoniker Name="ReferenceRelationship" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="73d9de27-a1f7-4f5f-be7a-8d7407425b11" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasDomainTypes" Name="MetaModelHasDomainTypes" DisplayName="Meta Model Has Domain Types" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="faee37a4-cdca-4b01-8881-dce0d4354cae" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasDomainTypes.MetaModel" Name="MetaModel" DisplayName="Meta Model" PropertyName="DomainTypes" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Domain Types">
          <RolePlayer>
            <DomainClassMoniker Name="MetaModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="2d11c2a8-3256-474e-86a8-e0e729c2aaa2" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasDomainTypes.DomainType" Name="DomainType" DisplayName="Domain Type" PropertyName="MetaModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Meta Model">
          <RolePlayer>
            <DomainClassMoniker Name="DomainType" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="8f8f4505-99ac-4081-b0a9-cc5956012fff" Description="Description for Tum.PDE.LanguageDSL.DomainEnumerationHasLiterals" Name="DomainEnumerationHasLiterals" DisplayName="Domain Enumeration Has Literals" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="cadec460-46d8-422a-8ac6-fec13f3961b5" Description="Description for Tum.PDE.LanguageDSL.DomainEnumerationHasLiterals.DomainEnumeration" Name="DomainEnumeration" DisplayName="Domain Enumeration" PropertyName="Literals" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Literals">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEnumeration" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="a9c39750-864d-4381-958c-c90b5cd7151c" Description="Description for Tum.PDE.LanguageDSL.DomainEnumerationHasLiterals.EnumerationLiteral" Name="EnumerationLiteral" DisplayName="Enumeration Literal" PropertyName="DomainEnumeration" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Domain Enumeration">
          <RolePlayer>
            <DomainClassMoniker Name="EnumerationLiteral" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="69532f97-690e-44d2-92ff-2041ace9e248" Description="Description for Tum.PDE.LanguageDSL.DomainPropertyReferencesType" Name="DomainPropertyReferencesType" DisplayName="Domain Property References Type" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="5d3c3e12-fc4a-48b3-9395-1ce2dee9a432" Description="Description for Tum.PDE.LanguageDSL.DomainPropertyReferencesType.DomainProperty" Name="DomainProperty" DisplayName="Domain Property" PropertyName="Type" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" PropertyDisplayName="Type">
          <RolePlayer>
            <DomainClassMoniker Name="DomainProperty" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="d1381052-42cf-4fed-8385-5f50376e358a" Description="Description for Tum.PDE.LanguageDSL.DomainPropertyReferencesType.DomainType" Name="DomainType" DisplayName="Domain Type" PropertyName="DomainProperties" IsPropertyGenerator="false" PropertyDisplayName="Domain Properties">
          <RolePlayer>
            <DomainClassMoniker Name="DomainType" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="dfb8dc1a-715d-4bbb-bb11-76fe3badf8ac" Description="Description for Tum.PDE.LanguageDSL.DiagramClassViewReferencesDiagramClass" Name="DiagramClassViewReferencesDiagramClass" DisplayName="Diagram Class View References Diagram Class" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="8c8a1c7d-9378-42cd-a323-e29aaa50a19e" Description="Description for Tum.PDE.LanguageDSL.DiagramClassViewReferencesDiagramClass.DiagramClassView" Name="DiagramClassView" DisplayName="Diagram Class View" PropertyName="DiagramClass" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Diagram Class">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramClassView" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="481b30b3-83ac-4298-bfe5-6637ac62d174" Description="Description for Tum.PDE.LanguageDSL.DiagramClassViewReferencesDiagramClass.DiagramClass" Name="DiagramClass" DisplayName="Diagram Class" PropertyName="DiagramClassView" Multiplicity="One" PropertyDisplayName="Diagram Class View">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="f69b2f23-dbc5-4924-ae59-c9b2b71f0584" Description="Description for Tum.PDE.LanguageDSL.DiagramClassHasPresentationElements" Name="DiagramClassHasPresentationElements" DisplayName="Diagram Class Has Presentation Elements" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="7400568b-9f1d-488e-89c5-577753005633" Description="Description for Tum.PDE.LanguageDSL.DiagramClassHasPresentationElements.DiagramClass" Name="DiagramClass" DisplayName="Diagram Class" PropertyName="PresentationElements" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Presentation Elements">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="4c55de6d-ac35-413f-9024-f1dbf9bf7bd1" Description="Description for Tum.PDE.LanguageDSL.DiagramClassHasPresentationElements.PresentationElementClass" Name="PresentationElementClass" DisplayName="Presentation Element Class" PropertyName="DiagramClass" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Diagram Class">
          <RolePlayer>
            <DomainClassMoniker Name="PresentationElementClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="047e58ed-a0bb-40fe-96a3-a72a154b4f5e" Description="Description for Tum.PDE.LanguageDSL.DomainClassReferencesBaseClass" Name="DomainClassReferencesBaseClass" DisplayName="Domain Class References Base Class" Namespace="Tum.PDE.LanguageDSL">
      <Properties>
        <DomainProperty Id="38e68277-c397-4e3e-afba-51250075b8f6" Description="Workaround, as we can not reference relationships.." Name="InhNodeId" DisplayName="Inh Node Id" IsBrowsable="false" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
      </Properties>
      <Source>
        <DomainRole Id="65f85012-b6ff-4caf-ae79-95b32d07aa97" Description="Description for Tum.PDE.LanguageDSL.DomainClassReferencesBaseClass.DerivedClass" Name="DerivedClass" DisplayName="Derived Class" PropertyName="BaseClass" Multiplicity="ZeroOne" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" PropertyDisplayName="Base Class">
          <RolePlayer>
            <DomainClassMoniker Name="DomainClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="2b13c053-6711-441c-8d99-8ed4fed19ed5" Description="Description for Tum.PDE.LanguageDSL.DomainClassReferencesBaseClass.BaseClass" Name="BaseClass" DisplayName="Base Class" PropertyName="DerivedClasses" PropertyDisplayName="Derived Classes">
          <RolePlayer>
            <DomainClassMoniker Name="DomainClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="292b4721-40ee-4f45-9968-12c133338615" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipReferencesBaseRelationship" Name="DomainRelationshipReferencesBaseRelationship" DisplayName="Domain Relationship References Base Relationship" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="2a8528b9-068b-4c3b-9e25-9e0b832ccaf1" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipReferencesBaseRelationship.DerivedRelationship" Name="DerivedRelationship" DisplayName="Derived Relationship" PropertyName="BaseRelationship" Multiplicity="ZeroOne" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" PropertyDisplayName="Base Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRelationship" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="b78f591d-b74b-49e3-9448-0d994803c3a8" Description="Description for Tum.PDE.LanguageDSL.DomainRelationshipReferencesBaseRelationship.BaseRelationship" Name="BaseRelationship" DisplayName="Base Relationship" PropertyName="DerivedRelationships" PropertyDisplayName="Derived Relationships">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRelationship" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="aa98ed1b-9ca3-41e1-a7b9-d997c8b979a8" Description="Description for Tum.PDE.LanguageDSL.DomainRoleReferencesOpposite" Name="DomainRoleReferencesOpposite" DisplayName="Domain Role References Opposite" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="8dbb213b-475b-47c0-ba7d-17a0f763cf3c" Description="Description for Tum.PDE.LanguageDSL.DomainRoleReferencesOpposite.SourceDomainRole" Name="SourceDomainRole" DisplayName="Source Domain Role" PropertyName="Opposite" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" IsPropertyBrowsable="false" PropertyDisplayName="Opposite">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRole" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="5cc8da5f-2738-4000-a16a-9ca0e7eff59d" Description="Description for Tum.PDE.LanguageDSL.DomainRoleReferencesOpposite.TargetDomainRole" Name="TargetDomainRole" DisplayName="Target Domain Role" PropertyName="SourceDomainRoles" IsPropertyGenerator="false" IsPropertyBrowsable="false" PropertyDisplayName="Source Domain Roles">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRole" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="6d10d7dc-3e5e-4d94-9215-26fd9a3b1801" Description="Description for Tum.PDE.LanguageDSL.EmbeddingRSNodeReferencesRelationship" Name="EmbeddingRSNodeReferencesRelationship" DisplayName="Embedding RSNode References Relationship" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="93a7c7be-0202-4aec-a569-c71dafea134d" Description="Description for Tum.PDE.LanguageDSL.EmbeddingRSNodeReferencesRelationship.EmbeddingRSNode" Name="EmbeddingRSNode" DisplayName="Embedding RSNode" PropertyName="Relationship" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="EmbeddingRSNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="1d42630f-beae-407a-8e00-64524151f84a" Description="Description for Tum.PDE.LanguageDSL.EmbeddingRSNodeReferencesRelationship.DomainRelationship" Name="DomainRelationship" DisplayName="Domain Relationship" PropertyName="EmbeddingRSNode" Multiplicity="One" PropertyDisplayName="Embedding RSNode">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRelationship" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="fea32e61-72fd-4a61-96c2-c3fa3b836729" Description="Description for Tum.PDE.LanguageDSL.DomainRoleReferencesRolePlayer" Name="DomainRoleReferencesRolePlayer" DisplayName="Domain Role References Role Player" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="394cfccc-057a-4e47-a0b6-d52134ba1591" Description="Description for Tum.PDE.LanguageDSL.DomainRoleReferencesRolePlayer.DomainRole" Name="DomainRole" DisplayName="Domain Role" PropertyName="RolePlayer" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" IsPropertyBrowsable="false" PropertyDisplayName="Role Player">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRole" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="f5320f6e-f0fa-4a32-b926-f5945b338c69" Description="Description for Tum.PDE.LanguageDSL.DomainRoleReferencesRolePlayer.AttributedDomainElement" Name="AttributedDomainElement" DisplayName="Attributed Domain Element" PropertyName="RolesPlayed" IsPropertyBrowsable="false" PropertyDisplayName="Roles Played">
          <RolePlayer>
            <DomainClassMoniker Name="AttributedDomainElement" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="8364bf94-b298-4a56-a930-99a3dd40bd59" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesDomainElement" Name="TreeNodeReferencesDomainElement" DisplayName="Tree Node References Domain Element" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="90968612-eee3-4792-ac4e-97cb2726d619" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesDomainElement.TreeNode" Name="TreeNode" DisplayName="Tree Node" PropertyName="DomainElement" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Domain Element">
          <RolePlayer>
            <DomainClassMoniker Name="TreeNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="35bf32c7-572b-4753-b766-75eebe4c9f59" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesDomainElement.AttributedDomainElement" Name="AttributedDomainElement" DisplayName="Attributed Domain Element" PropertyName="DomainModelTreeNodes" PropertyDisplayName="Domain Model Tree Nodes">
          <RolePlayer>
            <DomainClassMoniker Name="AttributedDomainElement" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="9a7cd033-ff1c-46e6-81f6-7a5a0189624e" Description="Description for Tum.PDE.LanguageDSL.ShapeClassReferencesChildren" Name="ShapeClassReferencesChildren" DisplayName="Shape Class References Children" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="93028c32-890c-443a-a8a3-92c897183b0f" Description="Description for Tum.PDE.LanguageDSL.ShapeClassReferencesChildren.Parent" Name="Parent" DisplayName="Parent" PropertyName="Children" IsPropertyBrowsable="false" PropertyDisplayName="Children">
          <RolePlayer>
            <DomainClassMoniker Name="ShapeClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="3fbf1f11-3be9-4036-a7d1-85344090e7f1" Description="Description for Tum.PDE.LanguageDSL.ShapeClassReferencesChildren.Child" Name="Child" DisplayName="Child" PropertyName="Parent" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Parent">
          <RolePlayer>
            <DomainClassMoniker Name="ShapeClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="3d6d27b8-ca30-4b49-8ff3-9dafedec4dd9" Description="Description for Tum.PDE.LanguageDSL.DiagramClassViewHasRootDiagramNodes" Name="DiagramClassViewHasRootDiagramNodes" DisplayName="Diagram Class View Has Root Diagram Nodes" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="05c95da8-d38b-4ef6-989c-79e534bbe9fe" Description="Description for Tum.PDE.LanguageDSL.DiagramClassViewHasRootDiagramNodes.DiagramClassView" Name="DiagramClassView" DisplayName="Diagram Class View" PropertyName="RootDiagramNodes" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Root Diagram Nodes">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramClassView" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="79290138-0397-402f-9b61-f69e0f67a332" Description="Description for Tum.PDE.LanguageDSL.DiagramClassViewHasRootDiagramNodes.RootDiagramNode" Name="RootDiagramNode" DisplayName="Root Diagram Node" PropertyName="DiagramClassView" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Diagram Class View">
          <RolePlayer>
            <DomainClassMoniker Name="RootDiagramNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="0c0e962b-fade-4db8-9341-163b359212b8" Description="Description for Tum.PDE.LanguageDSL.SerializationClassReferencesChildren" Name="SerializationClassReferencesChildren" DisplayName="Serialization Class References Children" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="312d2c8a-3fcc-47ba-b419-a9a7f605b8bc" Description="Description for Tum.PDE.LanguageDSL.SerializationClassReferencesChildren.Parent" Name="Parent" DisplayName="Parent" PropertyName="Children" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Children">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="62f6345e-7c53-4d8a-979c-f241ef9495ee" Description="Description for Tum.PDE.LanguageDSL.SerializationClassReferencesChildren.Child" Name="Child" DisplayName="Child" PropertyName="ParentEmbeddedElements" PropertyDisplayName="Parent Embedded Elements">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationElement" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="9edcf94e-9c66-4b23-a7a8-6f2d80372ab9" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainRoleReferencesDomainRole" Name="SerializedDomainRoleReferencesDomainRole" DisplayName="Serialized Domain Role References Domain Role" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="d179b78f-ed93-4363-8104-4cb22934a629" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainRoleReferencesDomainRole.SerializedDomainRole" Name="SerializedDomainRole" DisplayName="Serialized Domain Role" PropertyName="DomainRole" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Domain Role">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedDomainRole" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="dffe2ef8-69e6-4634-ab8e-72a009870952" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainRoleReferencesDomainRole.DomainRole" Name="DomainRole" DisplayName="Domain Role" PropertyName="SerializedDomainRoles" IsPropertyBrowsable="false" PropertyDisplayName="Serialized Domain Roles">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRole" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="f3850520-b427-4881-96cd-444e826ff2be" Description="Description for Tum.PDE.LanguageDSL.SerializationClassReferencesAttributes" Name="SerializationClassReferencesAttributes" DisplayName="Serialization Class References Attributes" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="ce1d4039-86e8-43aa-a1fa-42b775aa693f" Description="Description for Tum.PDE.LanguageDSL.SerializationClassReferencesAttributes.Element" Name="Element" DisplayName="Element" PropertyName="Attributes" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Attributes">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="ccdbf11b-c1ba-47dd-a0be-5095bd86f528" Description="Description for Tum.PDE.LanguageDSL.SerializationClassReferencesAttributes.Child" Name="Child" DisplayName="Child" PropertyName="ParentAttributedElements" PropertyDisplayName="Parent Attributed Elements">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationAttributeElement" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="59f43b2b-c188-4ffb-be89-ea0273db2f24" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasValidation" Name="MetaModelHasValidation" DisplayName="Meta Model Has Validation" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="8a6317f2-664c-43a2-a411-916f09eb299b" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasValidation.MetaModel" Name="MetaModel" DisplayName="Meta Model" PropertyName="Validation" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Validation">
          <RolePlayer>
            <DomainClassMoniker Name="MetaModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="bed7ef1d-7b2f-4faa-b924-9d8bfe0438d5" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasValidation.Validation" Name="Validation" DisplayName="Validation" PropertyName="MetaModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Meta Model">
          <RolePlayer>
            <DomainClassMoniker Name="Validation" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="89458e4e-325f-4349-a63f-d563ad6f5827" Description="Description for Tum.PDE.LanguageDSL.DomainModelTreeViewReferencesRootNodes" Name="DomainModelTreeViewReferencesRootNodes" DisplayName="Domain Model Tree View References Root Nodes" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="0e43bdf0-e6b8-49ed-bf08-8921cf0b7887" Description="Description for Tum.PDE.LanguageDSL.DomainModelTreeViewReferencesRootNodes.DomainModelTreeView" Name="DomainModelTreeView" DisplayName="Domain Model Tree View" PropertyName="RootNodes" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Root Nodes">
          <RolePlayer>
            <DomainClassMoniker Name="DomainModelTreeView" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="a9255ca5-0f43-4685-9a51-25b2f4ae2203" Description="Description for Tum.PDE.LanguageDSL.DomainModelTreeViewReferencesRootNodes.RootNode" Name="RootNode" DisplayName="Root Node" PropertyName="DomainModelTreeView" Multiplicity="One" PropertyDisplayName="Domain Model Tree View">
          <RolePlayer>
            <DomainClassMoniker Name="RootNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="6d2a7896-17d3-4c67-9900-60c57a2baa71" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesEmbeddingRSNodes" Name="TreeNodeReferencesEmbeddingRSNodes" DisplayName="Tree Node References Embedding RSNodes" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="b4272d7d-50d8-4027-a5a9-218418cca099" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesEmbeddingRSNodes.TreeNode" Name="TreeNode" DisplayName="Tree Node" PropertyName="EmbeddingRSNodes" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Embedding RSNodes">
          <RolePlayer>
            <DomainClassMoniker Name="TreeNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="323e88be-f638-4100-a271-8af4dad3bdaf" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesEmbeddingRSNodes.EmbeddingRSNode" Name="EmbeddingRSNode" DisplayName="Embedding RSNode" PropertyName="TreeNode" Multiplicity="One" PropertyDisplayName="Tree Node">
          <RolePlayer>
            <DomainClassMoniker Name="EmbeddingRSNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="10be6552-ffbc-424d-8b86-5189ff3fc1ec" Description="Description for Tum.PDE.LanguageDSL.EmbeddingRSNodeReferencesEmbeddingNode" Name="EmbeddingRSNodeReferencesEmbeddingNode" DisplayName="Embedding RSNode References Embedding Node" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="82218ca0-e059-4767-9a52-30398f3d24ce" Description="Description for Tum.PDE.LanguageDSL.EmbeddingRSNodeReferencesEmbeddingNode.EmbeddingRSNode" Name="EmbeddingRSNode" DisplayName="Embedding RSNode" PropertyName="EmbeddingNode" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Embedding Node">
          <RolePlayer>
            <DomainClassMoniker Name="EmbeddingRSNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="6fc773cf-324b-49af-b3e7-5a3cf9a38b83" Description="Description for Tum.PDE.LanguageDSL.EmbeddingRSNodeReferencesEmbeddingNode.EmbeddingNode" Name="EmbeddingNode" DisplayName="Embedding Node" PropertyName="EmbeddingRSNode" Multiplicity="One" PropertyDisplayName="Embedding RSNode">
          <RolePlayer>
            <DomainClassMoniker Name="EmbeddingNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="e1c72fae-28a0-4f5c-b1d9-0696a5034720" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesInheritanceNodes" Name="TreeNodeReferencesInheritanceNodes" DisplayName="Tree Node References Inheritance Nodes" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="ee52e6b1-7789-4d5a-b97c-81f621cd95ab" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesInheritanceNodes.TreeNode" Name="TreeNode" DisplayName="Tree Node" PropertyName="InheritanceNodes" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Inheritance Nodes">
          <RolePlayer>
            <DomainClassMoniker Name="TreeNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="64c38b59-ba61-4ace-a2e3-87285c6d257d" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesInheritanceNodes.InheritanceNode" Name="InheritanceNode" DisplayName="Inheritance Node" PropertyName="TreeNode" Multiplicity="One" PropertyDisplayName="Tree Node">
          <RolePlayer>
            <DomainClassMoniker Name="InheritanceNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="9754f610-96b5-4421-a0f7-6b8a1ec85f93" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesReferenceRSNodes" Name="TreeNodeReferencesReferenceRSNodes" DisplayName="Tree Node References Reference RSNodes" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="94dce324-cfbb-45f5-ac45-28c5bb37eccb" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesReferenceRSNodes.TreeNode" Name="TreeNode" DisplayName="Tree Node" PropertyName="ReferenceRSNodes" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Reference RSNodes">
          <RolePlayer>
            <DomainClassMoniker Name="TreeNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="43d81392-13cb-403b-8d62-2a26b87e2dbe" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesReferenceRSNodes.ReferenceRSNode" Name="ReferenceRSNode" DisplayName="Reference RSNode" PropertyName="TreeNode" Multiplicity="One" PropertyDisplayName="Tree Node">
          <RolePlayer>
            <DomainClassMoniker Name="ReferenceRSNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="7e157ffe-7f6c-407f-93b3-0340f6b683a1" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNodeReferencesReferenceNode" Name="ReferenceRSNodeReferencesReferenceNode" DisplayName="Reference RSNode References Reference Node" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="880b9e0e-bb7e-41c3-88ca-4e7dd878c096" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNodeReferencesReferenceNode.ReferenceRSNode" Name="ReferenceRSNode" DisplayName="Reference RSNode" PropertyName="ReferenceNode" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Reference Node">
          <RolePlayer>
            <DomainClassMoniker Name="ReferenceRSNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="a5acec03-25c5-4e67-910d-3b51221d2f16" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNodeReferencesReferenceNode.ReferenceNode" Name="ReferenceNode" DisplayName="Reference Node" PropertyName="ReferenceRSNode" Multiplicity="One" PropertyDisplayName="Reference RSNode">
          <RolePlayer>
            <DomainClassMoniker Name="ReferenceNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="d38b9281-3531-424b-b07d-354d67aebc1d" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesShapeClassNodes" Name="TreeNodeReferencesShapeClassNodes" DisplayName="Tree Node References Shape Class Nodes" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="c58499b1-a286-4e1c-9ef0-54c59f074820" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesShapeClassNodes.TreeNode" Name="TreeNode" DisplayName="Tree Node" PropertyName="ShapeClassNodes" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Shape Class Nodes">
          <RolePlayer>
            <DomainClassMoniker Name="TreeNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="c2dec63f-8892-46e7-891c-d9b2548aa550" Description="Description for Tum.PDE.LanguageDSL.TreeNodeReferencesShapeClassNodes.ShapeClassNode" Name="ShapeClassNode" DisplayName="Shape Class Node" PropertyName="TreeNode" Multiplicity="One" PropertyDisplayName="Tree Node">
          <RolePlayer>
            <DomainClassMoniker Name="ShapeClassNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="d50bd683-678e-4527-870e-d70c1ca3ec1f" Description="Description for Tum.PDE.LanguageDSL.DiagramViewHasDiagramClassViews" Name="DiagramViewHasDiagramClassViews" DisplayName="Diagram View Has Diagram Class Views" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="4a97e277-eb76-4821-a839-15bc75d6022c" Description="Description for Tum.PDE.LanguageDSL.DiagramViewHasDiagramClassViews.DiagramView" Name="DiagramView" DisplayName="Diagram View" PropertyName="DiagramClassViews" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Diagram Class Views">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramView" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="69021cd6-23f9-4537-8fcb-30cf591a6611" Description="Description for Tum.PDE.LanguageDSL.DiagramViewHasDiagramClassViews.DiagramClassView" Name="DiagramClassView" DisplayName="Diagram Class View" PropertyName="DiagramView" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Diagram View">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramClassView" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="15b18815-804b-46c8-8e75-82f3507e3bd1" Description="Description for Tum.PDE.LanguageDSL.DiagramTreeNodeReferencesPresentationElementClass" Name="DiagramTreeNodeReferencesPresentationElementClass" DisplayName="Diagram Tree Node References Presentation Element Class" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="c166be4b-f810-4f28-b86d-d397f9450864" Description="Description for Tum.PDE.LanguageDSL.DiagramTreeNodeReferencesPresentationElementClass.DiagramTreeNode" Name="DiagramTreeNode" DisplayName="Diagram Tree Node" PropertyName="PresentationElementClass" Multiplicity="ZeroOne" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Presentation Element Class">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramTreeNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="da37610b-e501-4fee-b47e-e67b7775520d" Description="Description for Tum.PDE.LanguageDSL.DiagramTreeNodeReferencesPresentationElementClass.PresentationElementClass" Name="PresentationElementClass" DisplayName="Presentation Element Class" PropertyName="DiagramTreeNode" Multiplicity="ZeroOne" PropertyDisplayName="Diagram Tree Node">
          <RolePlayer>
            <DomainClassMoniker Name="PresentationElementClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="b33486e1-ca79-4c57-a725-5efadc23f36d" Description="Description for Tum.PDE.LanguageDSL.EmbeddingDiagramNodeHasEmbeddingDiagramNodes" Name="EmbeddingDiagramNodeHasEmbeddingDiagramNodes" DisplayName="Embedding Diagram Node Has Embedding Diagram Nodes" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="7a2c04d4-d3f5-49de-af33-f041a4db5727" Description="Description for Tum.PDE.LanguageDSL.EmbeddingDiagramNodeHasEmbeddingDiagramNodes.SourceEmbeddingDiagramNode" Name="SourceEmbeddingDiagramNode" DisplayName="Source Embedding Diagram Node" PropertyName="EmbeddingDiagramNodes" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Embedding Diagram Nodes">
          <RolePlayer>
            <DomainClassMoniker Name="EmbeddingDiagramNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="b074fcc1-5a69-4be6-9b0a-65a2b03fa6e8" Description="Description for Tum.PDE.LanguageDSL.EmbeddingDiagramNodeHasEmbeddingDiagramNodes.TargetEmbeddingDiagramNode" Name="TargetEmbeddingDiagramNode" DisplayName="Target Embedding Diagram Node" PropertyName="SourceEmbeddingDiagramNode" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Source Embedding Diagram Node">
          <RolePlayer>
            <DomainClassMoniker Name="EmbeddingDiagramNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="db980dac-886b-4d2f-a3c1-3f2cd68217bb" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClassReferencesSource" Name="MappingRelationshipShapeClassReferencesSource" DisplayName="Mapping Relationship Shape Class References Source" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="74fb747f-364a-44b0-acf4-92e708e95518" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClassReferencesSource.MappingRelationshipShapeClass" Name="MappingRelationshipShapeClass" DisplayName="Mapping Relationship Shape Class" PropertyName="Source" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" PropertyDisplayName="Source">
          <RolePlayer>
            <DomainClassMoniker Name="MappingRelationshipShapeClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="cb161474-e33a-4ac5-93bd-806053904e36" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClassReferencesSource.ReferenceRelationship" Name="ReferenceRelationship" DisplayName="Reference Relationship" PropertyName="MappingRelationshipShapeClasses" IsPropertyGenerator="false" PropertyDisplayName="Mapping Relationship Shape Classes">
          <RolePlayer>
            <DomainClassMoniker Name="ReferenceRelationship" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="7691ad7f-5adb-454b-8685-fb595a575553" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClassReferencesTarget" Name="MappingRelationshipShapeClassReferencesTarget" DisplayName="Mapping Relationship Shape Class References Target" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="2a33bad6-7a87-4a04-b1fe-127863774ac2" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClassReferencesTarget.MappingRelationshipShapeClass" Name="MappingRelationshipShapeClass" DisplayName="Mapping Relationship Shape Class" PropertyName="Target" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" PropertyDisplayName="Target">
          <RolePlayer>
            <DomainClassMoniker Name="MappingRelationshipShapeClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="c79eb4ef-412c-448e-be8e-4ee56a6dff58" Description="Description for Tum.PDE.LanguageDSL.MappingRelationshipShapeClassReferencesTarget.ReferenceRelationship" Name="ReferenceRelationship" DisplayName="Reference Relationship" PropertyName="MappingRelationshipShapeClasses" IsPropertyGenerator="false" PropertyDisplayName="Mapping Relationship Shape Classes">
          <RolePlayer>
            <DomainClassMoniker Name="ReferenceRelationship" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="23051d10-d60e-41ed-901e-cd35859d3073" Description="Description for Tum.PDE.LanguageDSL.ShapeRelationshipNodeReferencesRelationshipShapeClass" Name="ShapeRelationshipNodeReferencesRelationshipShapeClass" DisplayName="Shape Relationship Node References Relationship Shape Class" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="3069d73d-a5d9-44c7-a168-bb51e01ebc59" Description="Description for Tum.PDE.LanguageDSL.ShapeRelationshipNodeReferencesRelationshipShapeClass.ShapeRelationshipNode" Name="ShapeRelationshipNode" DisplayName="Shape Relationship Node" PropertyName="RelationshipShapeClass" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Relationship Shape Class">
          <RolePlayer>
            <DomainClassMoniker Name="ShapeRelationshipNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="4444cb78-dec6-4539-a794-e4dbce337a26" Description="Description for Tum.PDE.LanguageDSL.ShapeRelationshipNodeReferencesRelationshipShapeClass.RelationshipShapeClass" Name="RelationshipShapeClass" DisplayName="Relationship Shape Class" PropertyName="ShapeRelationshipNode" Multiplicity="One" PropertyDisplayName="Shape Relationship Node">
          <RolePlayer>
            <DomainClassMoniker Name="RelationshipShapeClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="55bc437f-b862-4e4d-8d53-a184870509e9" Description="Description for Tum.PDE.LanguageDSL.DomainModelTreeViewHasModelTreeNodes" Name="DomainModelTreeViewHasModelTreeNodes" DisplayName="Domain Model Tree View Has Model Tree Nodes" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="bf66fc54-0a13-4766-865d-3e1990f59adf" Description="Description for Tum.PDE.LanguageDSL.DomainModelTreeViewHasModelTreeNodes.DomainModelTreeView" Name="DomainModelTreeView" DisplayName="Domain Model Tree View" PropertyName="ModelTreeNodes" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Model Tree Nodes">
          <RolePlayer>
            <DomainClassMoniker Name="DomainModelTreeView" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="b953332a-bb2d-4a82-b26c-4e9273a34a03" Description="Description for Tum.PDE.LanguageDSL.DomainModelTreeViewHasModelTreeNodes.ModelTreeNode" Name="ModelTreeNode" DisplayName="Model Tree Node" PropertyName="EmbeddingModelTreeViewModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Embedding Model Tree View Model">
          <RolePlayer>
            <DomainClassMoniker Name="ModelTreeNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="c32a3277-4171-48c4-9022-702e540389dc" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNodeReferencesShapeRelationshipNodes" Name="ReferenceRSNodeReferencesShapeRelationshipNodes" DisplayName="Reference RSNode References Shape Relationship Nodes" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="74d2c9f4-0eea-4458-91d4-1905ac7c0f7a" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNodeReferencesShapeRelationshipNodes.ReferenceRSNode" Name="ReferenceRSNode" DisplayName="Reference RSNode" PropertyName="ShapeRelationshipNodes" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Shape Relationship Nodes">
          <RolePlayer>
            <DomainClassMoniker Name="ReferenceRSNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="0643f7de-c7f5-4585-8c75-b2b771065e61" Description="Description for Tum.PDE.LanguageDSL.ReferenceRSNodeReferencesShapeRelationshipNodes.ShapeRelationshipNode" Name="ShapeRelationshipNode" DisplayName="Shape Relationship Node" PropertyName="ReferenceRSNode" Multiplicity="One" PropertyDisplayName="Reference RSNode">
          <RolePlayer>
            <DomainClassMoniker Name="ShapeRelationshipNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="3031942f-a8e9-4801-9ece-27c2f90c630e" Description="Description for Tum.PDE.LanguageDSL.ShapeClassReferencesDomainClass" Name="ShapeClassReferencesDomainClass" DisplayName="Shape Class References Domain Class" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="1f0822ad-0dde-4b49-bd8e-e4188f7ee076" Description="Description for Tum.PDE.LanguageDSL.ShapeClassReferencesDomainClass.ShapeClass" Name="ShapeClass" DisplayName="Shape Class" PropertyName="DomainClass" Multiplicity="ZeroOne" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" PropertyDisplayName="Domain Class">
          <RolePlayer>
            <DomainClassMoniker Name="PresentationDomainClassElement" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="92a82cdf-1f88-427d-a856-440ae388a6a9" Description="Description for Tum.PDE.LanguageDSL.ShapeClassReferencesDomainClass.DomainClass" Name="DomainClass" DisplayName="Domain Class" PropertyName="ShapeClasses" Category="Definition" PropertyDisplayName="Shape Classes">
          <RolePlayer>
            <DomainClassMoniker Name="DomainClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="4942cd8a-4858-4c55-b3b7-db478d3e304e" Description="Description for Tum.PDE.LanguageDSL.ShapeClassNodeReferencesShapeClass" Name="ShapeClassNodeReferencesShapeClass" DisplayName="Shape Class Node References Shape Class" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="d1cf1b78-81c4-44b5-b691-eedf6ddbeb5b" Description="Description for Tum.PDE.LanguageDSL.ShapeClassNodeReferencesShapeClass.ShapeClassNode" Name="ShapeClassNode" DisplayName="Shape Class Node" PropertyName="ShapeClass" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Shape Class">
          <RolePlayer>
            <DomainClassMoniker Name="ShapeClassNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="729c7c50-78d7-485e-8425-c2f4f1dca1ca" Description="Description for Tum.PDE.LanguageDSL.ShapeClassNodeReferencesShapeClass.ShapeClass" Name="ShapeClass" DisplayName="Shape Class" PropertyName="ShapeClassNode" Multiplicity="One" PropertyDisplayName="Shape Class Node">
          <RolePlayer>
            <DomainClassMoniker Name="PresentationDomainClassElement" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="911605ee-fa77-4f17-abc6-5b7c9af6aa9d" Description="Description for Tum.PDE.LanguageDSL.SerializationModelHasSerializedDomainModel" Name="SerializationModelHasSerializedDomainModel" DisplayName="Serialization Model Has Serialized Domain Model" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="8a1350bd-7441-4556-b194-8793a5d79bf1" Description="Description for Tum.PDE.LanguageDSL.SerializationModelHasSerializedDomainModel.SerializationModel" Name="SerializationModel" DisplayName="Serialization Model" PropertyName="SerializedDomainModel" Multiplicity="ZeroOne" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Serialized Domain Model">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="12700d9b-d15e-48cb-85e0-59df3696ec34" Description="Description for Tum.PDE.LanguageDSL.SerializationModelHasSerializedDomainModel.SerializedDomainModel" Name="SerializedDomainModel" DisplayName="Serialized Domain Model" PropertyName="Model" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Model">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedDomainModel" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="9d6b1eb9-c9fd-400e-814f-7b404a8cd684" Description="Description for Tum.PDE.LanguageDSL.SerializationClassHasIdProperty" Name="SerializationClassHasIdProperty" DisplayName="Serialization Class Has Id Property" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="ed4d4b8f-ad48-4664-a519-86a7104ecec6" Description="Description for Tum.PDE.LanguageDSL.SerializationClassHasIdProperty.SerializationClass" Name="SerializationClass" DisplayName="Serialization Class" PropertyName="IdProperty" Multiplicity="ZeroOne" PropertyDisplayName="Id Property">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="e071cbb3-4070-4901-8038-299371f010d4" Description="Description for Tum.PDE.LanguageDSL.SerializationClassHasIdProperty.SerializedIdProperty" Name="SerializedIdProperty" DisplayName="Serialized Id Property" PropertyName="SerializationClass" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Serialization Class">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedIdProperty" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="b780f88c-fedb-4b5a-85cd-6ce9618bb866" Description="Description for Tum.PDE.LanguageDSL.SerializedRelationshipHasSerializedDomainRoles" Name="SerializedRelationshipHasSerializedDomainRoles" DisplayName="Serialized Relationship Has Serialized Domain Roles" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="d6dae9d9-7d00-46e4-9f70-b90f6ff5bae1" Description="Description for Tum.PDE.LanguageDSL.SerializedRelationshipHasSerializedDomainRoles.SerializedRelationship" Name="SerializedRelationship" DisplayName="Serialized Relationship" PropertyName="SerializedDomainRoles" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Serialized Domain Roles">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedRelationship" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="7c28be3a-a0ee-4e45-b792-4e0e16cc33c1" Description="Description for Tum.PDE.LanguageDSL.SerializedRelationshipHasSerializedDomainRoles.SerializedDomainRole" Name="SerializedDomainRole" DisplayName="Serialized Domain Role" PropertyName="SerializedRelationship" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Serialized Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedDomainRole" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="33634d38-17e4-4f6d-889e-84bc2e910a12" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainClassReferencesDomainClass" Name="SerializedDomainClassReferencesDomainClass" DisplayName="Serialized Domain Class References Domain Class" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="a87347ad-bf33-4c31-a21b-1d1c2a858999" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainClassReferencesDomainClass.SerializedDomainClass" Name="SerializedDomainClass" DisplayName="Serialized Domain Class" PropertyName="DomainClass" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Domain Class">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedDomainClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="acc2027a-77cf-4d93-8480-b52496d26350" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainClassReferencesDomainClass.DomainClass" Name="DomainClass" DisplayName="Domain Class" PropertyName="SerializedDomainClass" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Serialized Domain Class">
          <RolePlayer>
            <DomainClassMoniker Name="DomainClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="af7e80d4-b14a-4917-ab68-a857899946bf" Description="Description for Tum.PDE.LanguageDSL.SerializedEmbeddingRelationshipReferencesEmbeddingRelationship" Name="SerializedEmbeddingRelationshipReferencesEmbeddingRelationship" DisplayName="Serialized Embedding Relationship References Embedding Relationship" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="b4926cd6-a94a-4c74-8813-27e9917897ca" Description="Description for Tum.PDE.LanguageDSL.SerializedEmbeddingRelationshipReferencesEmbeddingRelationship.SerializedEmbeddingRelationship" Name="SerializedEmbeddingRelationship" DisplayName="Serialized Embedding Relationship" PropertyName="EmbeddingRelationship" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Embedding Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedEmbeddingRelationship" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="055710e2-0d57-4cb9-8b51-62a68b7b0d80" Description="Description for Tum.PDE.LanguageDSL.SerializedEmbeddingRelationshipReferencesEmbeddingRelationship.EmbeddingRelationship" Name="EmbeddingRelationship" DisplayName="Embedding Relationship" PropertyName="SerializedEmbeddingRelationship" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Serialized Embedding Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="EmbeddingRelationship" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="4727780c-970d-4ae6-aeac-c5f5d1488acb" Description="Description for Tum.PDE.LanguageDSL.SerializedReferenceRelationshipReferencesReferenceRelationship" Name="SerializedReferenceRelationshipReferencesReferenceRelationship" DisplayName="Serialized Reference Relationship References Reference Relationship" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="06e5a9d7-4cf8-4452-ac21-1a33d38c841e" Description="Description for Tum.PDE.LanguageDSL.SerializedReferenceRelationshipReferencesReferenceRelationship.SerializedReferenceRelationship" Name="SerializedReferenceRelationship" DisplayName="Serialized Reference Relationship" PropertyName="ReferenceRelationship" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Reference Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedReferenceRelationship" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="10ef763a-5205-497e-8b09-68fe93e6c9fc" Description="Description for Tum.PDE.LanguageDSL.SerializedReferenceRelationshipReferencesReferenceRelationship.ReferenceRelationship" Name="ReferenceRelationship" DisplayName="Reference Relationship" PropertyName="SerializedReferenceRelationship" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Serialized Reference Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="ReferenceRelationship" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="f4fdb6df-79a9-477f-97b3-9ed81c060246" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainPropertyReferencesDomainProperty" Name="SerializedDomainPropertyReferencesDomainProperty" DisplayName="Serialized Domain Property References Domain Property" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="7ee09536-675c-40d2-b308-5f8274a076f1" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainPropertyReferencesDomainProperty.SerializedDomainProperty" Name="SerializedDomainProperty" DisplayName="Serialized Domain Property" PropertyName="DomainProperty" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Domain Property">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedDomainProperty" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="80d922ee-cd4a-4217-9dc6-d3ad624c4e11" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainPropertyReferencesDomainProperty.DomainProperty" Name="DomainProperty" DisplayName="Domain Property" PropertyName="SerializedDomainProperty" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Serialized Domain Property">
          <RolePlayer>
            <DomainClassMoniker Name="DomainProperty" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="fe2ba1de-36c5-4736-8441-f4f887a89f37" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainRoleReferencesSerializationClass" Name="SerializedDomainRoleReferencesSerializationClass" DisplayName="Serialized Domain Role References Serialization Class" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="9106a54e-97a0-4ce4-93c0-7ff19c3a3409" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainRoleReferencesSerializationClass.SerializedDomainRole" Name="SerializedDomainRole" DisplayName="Serialized Domain Role" PropertyName="SerializationClass" Multiplicity="One" PropertyDisplayName="Serialization Class">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedDomainRole" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="1f0aa60f-7bc8-4669-be07-6543f0dc62eb" Description="Description for Tum.PDE.LanguageDSL.SerializedDomainRoleReferencesSerializationClass.SerializationClass" Name="SerializationClass" DisplayName="Serialization Class" PropertyName="SerializedDomainRole" Multiplicity="One" PropertyDisplayName="Serialized Domain Role">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="0bb261cd-b9ed-41c7-8702-7ce28306279e" Description="Description for Tum.PDE.LanguageDSL.SerializationModelHasChildren" Name="SerializationModelHasChildren" DisplayName="Serialization Model Has Children" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="83541948-ff66-436c-b22a-0cd5c02f6bee" Description="Description for Tum.PDE.LanguageDSL.SerializationModelHasChildren.SerializationModel" Name="SerializationModel" DisplayName="Serialization Model" PropertyName="Children" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Children">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="9c7ff85a-e697-4a43-a7cc-b0516dace51b" Description="Description for Tum.PDE.LanguageDSL.SerializationModelHasChildren.SerializationClass" Name="SerializationClass" DisplayName="Serialization Class" PropertyName="SerializationModel" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Serialization Model">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="418f5cc0-56be-4c93-8270-0725ef7d0558" Description="Description for Tum.PDE.LanguageDSL.SerializationClassHasProperties" Name="SerializationClassHasProperties" DisplayName="Serialization Class Has Properties" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="f0dd50f3-281f-45a2-bedb-5e855a477318" Description="Description for Tum.PDE.LanguageDSL.SerializationClassHasProperties.SerializationClass" Name="SerializationClass" DisplayName="Serialization Class" PropertyName="Properties" PropertyDisplayName="Properties">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="30dd8c4a-b599-4268-b140-41da77d59082" Description="Description for Tum.PDE.LanguageDSL.SerializationClassHasProperties.SerializedDomainProperty" Name="SerializedDomainProperty" DisplayName="Serialized Domain Property" PropertyName="SerializationClass" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Serialization Class">
          <RolePlayer>
            <DomainClassMoniker Name="SerializedDomainProperty" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="677d26fc-7c41-41ea-be43-b14598182255" Description="Description for Tum.PDE.LanguageDSL.CreditsHasCreditItems" Name="CreditsHasCreditItems" DisplayName="Credits Has Credit Items" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="734a93e0-0d7b-403f-8732-0353698fd8ed" Description="Description for Tum.PDE.LanguageDSL.CreditsHasCreditItems.Credits" Name="Credits" DisplayName="Credits" PropertyName="CreditItems" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Credit Items">
          <RolePlayer>
            <DomainClassMoniker Name="Credits" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="b6c01631-b5a1-4e48-9992-2ab595cf3cb9" Description="Description for Tum.PDE.LanguageDSL.CreditsHasCreditItems.CreditItem" Name="CreditItem" DisplayName="Credit Item" PropertyName="Credits" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Credits">
          <RolePlayer>
            <DomainClassMoniker Name="CreditItem" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="3da7c81b-2375-4ba0-9e87-090f3be7ee56" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasAdditionalInformation" Name="MetaModelHasAdditionalInformation" DisplayName="Meta Model Has Additional Information" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="8b2a965c-6143-4602-acff-f52f7f188ff6" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasAdditionalInformation.MetaModel" Name="MetaModel" DisplayName="Meta Model" PropertyName="AdditionalInformation" Multiplicity="ZeroOne" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Additional Information">
          <RolePlayer>
            <DomainClassMoniker Name="MetaModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="62c119a6-6331-4b19-9772-53e02ef1e8be" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasAdditionalInformation.AdditionalInformation" Name="AdditionalInformation" DisplayName="Additional Information" PropertyName="MetaModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Meta Model">
          <RolePlayer>
            <DomainClassMoniker Name="AdditionalInformation" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="91a91561-bd6d-4e90-a53e-4a09711db83f" Description="Description for Tum.PDE.LanguageDSL.AdditionalInformationHasCredits" Name="AdditionalInformationHasCredits" DisplayName="Additional Information Has Credits" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="8dc7dffd-4477-45ed-adb7-78131425dde6" Description="Description for Tum.PDE.LanguageDSL.AdditionalInformationHasCredits.AdditionalInformation" Name="AdditionalInformation" DisplayName="Additional Information" PropertyName="Credits" Multiplicity="ZeroOne" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Credits">
          <RolePlayer>
            <DomainClassMoniker Name="AdditionalInformation" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="ad89471f-22fc-4b96-a1ee-0da51e0186f2" Description="Description for Tum.PDE.LanguageDSL.AdditionalInformationHasCredits.Credits" Name="Credits" DisplayName="Credits" PropertyName="AdditionalInformation" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Additional Information">
          <RolePlayer>
            <DomainClassMoniker Name="Credits" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="1ac943d7-a449-4060-9eac-362093d051b1" Description="Description for Tum.PDE.LanguageDSL.AdditionalInformationHasFurtherInformation" Name="AdditionalInformationHasFurtherInformation" DisplayName="Additional Information Has Further Information" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="bd969ac0-67f2-4f5e-b30b-855b46b784e8" Description="Description for Tum.PDE.LanguageDSL.AdditionalInformationHasFurtherInformation.AdditionalInformation" Name="AdditionalInformation" DisplayName="Additional Information" PropertyName="FurtherInformation" Multiplicity="ZeroOne" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Further Information">
          <RolePlayer>
            <DomainClassMoniker Name="AdditionalInformation" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="8d0151c4-5f28-4aa4-a174-d22148196ab2" Description="Description for Tum.PDE.LanguageDSL.AdditionalInformationHasFurtherInformation.FurtherInformation" Name="FurtherInformation" DisplayName="Further Information" PropertyName="AdditionalInformation" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Additional Information">
          <RolePlayer>
            <DomainClassMoniker Name="FurtherInformation" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="3016196e-1148-49a2-ae3b-7fa914efee32" Description="Description for Tum.PDE.LanguageDSL.FurtherInformationHasInformationItems" Name="FurtherInformationHasInformationItems" DisplayName="Further Information Has Information Items" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="582303b9-41ec-4142-abf5-979689a28514" Description="Description for Tum.PDE.LanguageDSL.FurtherInformationHasInformationItems.FurtherInformation" Name="FurtherInformation" DisplayName="Further Information" PropertyName="InformationItems" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Information Items">
          <RolePlayer>
            <DomainClassMoniker Name="FurtherInformation" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="5d437ace-5bb1-4cdf-b693-4db189c4e433" Description="Description for Tum.PDE.LanguageDSL.FurtherInformationHasInformationItems.InformationItem" Name="InformationItem" DisplayName="Information Item" PropertyName="FurtherInformation" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Further Information">
          <RolePlayer>
            <DomainClassMoniker Name="InformationItem" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="7727aeab-b885-4792-b0e6-b6f816966a74" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasMetaModelLibraries" Name="MetaModelHasMetaModelLibraries" DisplayName="Meta Model Has Meta Model Libraries" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="b6c40eab-5fc5-4812-94bc-5617a4492b3b" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasMetaModelLibraries.MetaModel" Name="MetaModel" DisplayName="Meta Model" PropertyName="MetaModelLibraries" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Meta Model Libraries">
          <RolePlayer>
            <DomainClassMoniker Name="MetaModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="6f070745-ba9b-4032-b9e0-2234e009fb5e" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasMetaModelLibraries.MetaModelLibrary" Name="MetaModelLibrary" DisplayName="Meta Model Library" PropertyName="MetaModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Meta Model">
          <RolePlayer>
            <DomainClassMoniker Name="MetaModelLibrary" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="c32907d1-1267-4245-a9b0-b65ee48b13ef" Description="Description for Tum.PDE.LanguageDSL.MetaModelLibraryHasImportedLibrary" Name="MetaModelLibraryHasImportedLibrary" DisplayName="Meta Model Library Has Imported Library" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="b0382a54-c23c-4752-8b87-fddf7a35acf1" Description="Description for Tum.PDE.LanguageDSL.MetaModelLibraryHasImportedLibrary.MetaModelLibrary" Name="MetaModelLibrary" DisplayName="Meta Model Library" PropertyName="ImportedLibrary" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Imported Library">
          <RolePlayer>
            <DomainClassMoniker Name="MetaModelLibrary" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="f88be592-05ae-42f0-a74f-ee8f46cfef61" Description="Description for Tum.PDE.LanguageDSL.MetaModelLibraryHasImportedLibrary.BaseMetaModel" Name="BaseMetaModel" DisplayName="Base Meta Model" PropertyName="MetaModelLibrary" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Meta Model Library">
          <RolePlayer>
            <DomainClassMoniker Name="BaseMetaModel" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="7fd950ed-9e0c-41ab-95bf-989256c80c2f" Description="Description for Tum.PDE.LanguageDSL.ViewContextHasDomainModelTreeView" Name="ViewContextHasDomainModelTreeView" DisplayName="View Context Has Domain Model Tree View" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="3a17a0ea-1899-4faf-823c-f3a2da13857d" Description="Description for Tum.PDE.LanguageDSL.ViewContextHasDomainModelTreeView.ViewContext" Name="ViewContext" DisplayName="View Context" PropertyName="DomainModelTreeView" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Domain Model Tree View">
          <RolePlayer>
            <DomainClassMoniker Name="ViewContext" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="8424ef42-7d5b-443f-9d9c-b2453c8f956c" Description="Description for Tum.PDE.LanguageDSL.ViewContextHasDomainModelTreeView.DomainModelTreeView" Name="DomainModelTreeView" DisplayName="Domain Model Tree View" PropertyName="ViewContext" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="View Context">
          <RolePlayer>
            <DomainClassMoniker Name="DomainModelTreeView" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="7875a5f1-3d5e-4563-84c5-98bdec387c92" Description="Description for Tum.PDE.LanguageDSL.ViewContextHasDiagramView" Name="ViewContextHasDiagramView" DisplayName="View Context Has Diagram View" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="e4e0ced1-5e0f-403c-911c-84297c234243" Description="Description for Tum.PDE.LanguageDSL.ViewContextHasDiagramView.ViewContext" Name="ViewContext" DisplayName="View Context" PropertyName="DiagramView" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Diagram View">
          <RolePlayer>
            <DomainClassMoniker Name="ViewContext" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="0e373c0d-98c2-4fff-a782-2829e552f484" Description="Description for Tum.PDE.LanguageDSL.ViewContextHasDiagramView.DiagramView" Name="DiagramView" DisplayName="Diagram View" PropertyName="ViewContext" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="View Context">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramView" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="27bb056a-065c-4f7b-a6bd-15d0b3f70404" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasClasses" Name="LibraryModelContextHasClasses" DisplayName="Library Model Context Has Classes" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="b6a7eb19-d1c0-4cf9-8b3d-f31e9799fc8f" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasClasses.LibraryModelContext" Name="LibraryModelContext" DisplayName="Library Model Context" PropertyName="Classes" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Classes">
          <RolePlayer>
            <DomainClassMoniker Name="LibraryModelContext" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="4153ad18-ce62-488b-8b0c-8eb7a64fd642" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasClasses.DomainClass" Name="DomainClass" DisplayName="Domain Class" PropertyName="ModelContext" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Model Context">
          <RolePlayer>
            <DomainClassMoniker Name="DomainClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="46bf94fb-8ead-43d3-9ab8-868bcba8916d" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasDiagramClasses" Name="LibraryModelContextHasDiagramClasses" DisplayName="Library Model Context Has Diagram Classes" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="4d17db4d-b055-4e00-acd6-84187fbb2039" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasDiagramClasses.LibraryModelContext" Name="LibraryModelContext" DisplayName="Library Model Context" PropertyName="DiagramClasses" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Diagram Classes">
          <RolePlayer>
            <DomainClassMoniker Name="LibraryModelContext" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="55de9127-b40a-403b-a258-92be69faa8f1" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasDiagramClasses.DiagramClass" Name="DiagramClass" DisplayName="Diagram Class" PropertyName="ModelContext" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Model Context">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="d15a3055-2894-44ac-8044-d25cc5daae7e" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasRelationships" Name="LibraryModelContextHasRelationships" DisplayName="Library Model Context Has Relationships" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="d48222ad-572b-4dc8-baae-6bf2cf3a9055" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasRelationships.LibraryModelContext" Name="LibraryModelContext" DisplayName="Library Model Context" PropertyName="Relationships" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Relationships">
          <RolePlayer>
            <DomainClassMoniker Name="LibraryModelContext" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="2835ca5e-9653-4bdb-b560-e61d39c94a16" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasRelationships.DomainRelationship" Name="DomainRelationship" DisplayName="Domain Relationship" PropertyName="ModelContext" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Model Context">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRelationship" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="876f2d00-ec5c-4c42-83f0-9e4112f190b2" Description="Description for Tum.PDE.LanguageDSL.ViewContextReferencesModelContext" Name="ViewContextReferencesModelContext" DisplayName="View Context References Model Context" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="8459a243-37ac-45d9-8dc0-78b0821ff0c2" Description="Description for Tum.PDE.LanguageDSL.ViewContextReferencesModelContext.ViewContext" Name="ViewContext" DisplayName="View Context" PropertyName="ModelContext" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Model Context">
          <RolePlayer>
            <DomainClassMoniker Name="ViewContext" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="847f79a8-cd65-44d0-b47a-a9556e397016" Description="Description for Tum.PDE.LanguageDSL.ViewContextReferencesModelContext.LibraryModelContext" Name="LibraryModelContext" DisplayName="Library Model Context" PropertyName="ViewContext" Multiplicity="One" PropertyDisplayName="View Context">
          <RolePlayer>
            <DomainClassMoniker Name="LibraryModelContext" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="9cb643d7-f381-4391-a9c0-4001511b683c" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasView" Name="MetaModelHasView" DisplayName="Meta Model Has View" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="b84c70e9-1bcd-4e42-aaa9-75a52776aad9" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasView.MetaModel" Name="MetaModel" DisplayName="Meta Model" PropertyName="View" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="View">
          <RolePlayer>
            <DomainClassMoniker Name="MetaModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="be3738db-5734-4b0f-8617-d9aa78dcd5d0" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasView.View" Name="View" DisplayName="View" PropertyName="MetaModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Meta Model">
          <RolePlayer>
            <DomainClassMoniker Name="View" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="e1408dcb-7bc7-4a28-a311-3875b80adf63" Description="Description for Tum.PDE.LanguageDSL.DomainTypeReferencesPropertyGridEditor" Name="DomainTypeReferencesPropertyGridEditor" DisplayName="Domain Type References Property Grid Editor" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="b2028587-5bee-466f-a7cb-6ea98b9530fd" Description="Description for Tum.PDE.LanguageDSL.DomainTypeReferencesPropertyGridEditor.DomainType" Name="DomainType" DisplayName="Domain Type" PropertyName="PropertyGridEditor" Multiplicity="ZeroOne" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" PropertyDisplayName="Property Grid Editor">
          <RolePlayer>
            <DomainClassMoniker Name="DomainType" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="bba934f0-372f-4fad-bbc8-b22eb188aaf4" Description="Description for Tum.PDE.LanguageDSL.DomainTypeReferencesPropertyGridEditor.PropertyGridEditor" Name="PropertyGridEditor" DisplayName="Property Grid Editor" PropertyName="DomainTypes" IsPropertyGenerator="false" PropertyDisplayName="Domain Types">
          <RolePlayer>
            <DomainClassMoniker Name="PropertyGridEditor" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="43b775db-68d1-4b58-8e5d-6a5c5bef451f" Description="Description for Tum.PDE.LanguageDSL.DomainRoleReferencesCustomPropertyGridEditor" Name="DomainRoleReferencesCustomPropertyGridEditor" DisplayName="Domain Role References Custom Property Grid Editor" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="afb8ced2-f3cf-4f71-8f32-dff5a09a4b6e" Description="Description for Tum.PDE.LanguageDSL.DomainRoleReferencesCustomPropertyGridEditor.DomainRole" Name="DomainRole" DisplayName="Domain Role" PropertyName="CustomPropertyGridEditor" Multiplicity="ZeroOne" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" PropertyDisplayName="Custom Property Grid Editor">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRole" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="521f383a-5e18-4ec8-a263-1ef9aa7b0ae8" Description="Description for Tum.PDE.LanguageDSL.DomainRoleReferencesCustomPropertyGridEditor.PropertyGridEditor" Name="PropertyGridEditor" DisplayName="Property Grid Editor" PropertyName="DomainRoles" PropertyDisplayName="Domain Roles">
          <RolePlayer>
            <DomainClassMoniker Name="PropertyGridEditor" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="14bafde8-b8ff-4c90-90a5-9ef7be6b18ee" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasModelContexts" Name="MetaModelHasModelContexts" DisplayName="Meta Model Has Model Contexts" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="3516563e-6b5c-434e-9b14-ed57ce049aee" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasModelContexts.MetaModel" Name="MetaModel" DisplayName="Meta Model" PropertyName="ModelContexts" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Model Contexts">
          <RolePlayer>
            <DomainClassMoniker Name="MetaModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="9de0ada7-baac-4086-a5b6-f170f4260cd2" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasModelContexts.BaseModelContext" Name="BaseModelContext" DisplayName="Base Model Context" PropertyName="MetaModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Meta Model">
          <RolePlayer>
            <DomainClassMoniker Name="BaseModelContext" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="54a89a90-4d7e-42a6-94f1-916761910520" Description="Description for Tum.PDE.LanguageDSL.ViewHasViewContexts" Name="ViewHasViewContexts" DisplayName="View Has View Contexts" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="162677c8-6a55-4685-a4de-e8d1bcb65cdd" Description="Description for Tum.PDE.LanguageDSL.ViewHasViewContexts.View" Name="View" DisplayName="View" PropertyName="ViewContexts" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="View Contexts">
          <RolePlayer>
            <DomainClassMoniker Name="View" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="24af819a-ef09-4807-bc88-49d4471cd9e8" Description="Description for Tum.PDE.LanguageDSL.ViewHasViewContexts.BaseViewContext" Name="BaseViewContext" DisplayName="Base View Context" PropertyName="View" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="View">
          <RolePlayer>
            <DomainClassMoniker Name="BaseViewContext" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="8d54dc55-b1cf-4056-a902-2b4b41e40882" Description="Description for Tum.PDE.LanguageDSL.ExternViewContextReferencesExternModelContext" Name="ExternViewContextReferencesExternModelContext" DisplayName="Extern View Context References Extern Model Context" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="f2410fc8-c7f3-4dcb-acc2-2d08b2ff03de" Description="Description for Tum.PDE.LanguageDSL.ExternViewContextReferencesExternModelContext.ExternViewContext" Name="ExternViewContext" DisplayName="Extern View Context" PropertyName="ExternModelContext" Multiplicity="One" PropagatesCopy="PropagateCopyToLinkOnly" PropertyDisplayName="Extern Model Context">
          <RolePlayer>
            <DomainClassMoniker Name="ExternViewContext" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="708b5f77-1789-4436-8d0f-e342f17ff2e7" Description="Description for Tum.PDE.LanguageDSL.ExternViewContextReferencesExternModelContext.ExternModelContext" Name="ExternModelContext" DisplayName="Extern Model Context" PropertyName="ExternViewContext" Multiplicity="One" PropertyDisplayName="Extern View Context">
          <RolePlayer>
            <DomainClassMoniker Name="ExternModelContext" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="36dd1517-3a1d-400d-860f-001f29eaefcd" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasSerializationModel" Name="LibraryModelContextHasSerializationModel" DisplayName="Library Model Context Has Serialization Model" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="8e4274df-2039-4dcd-86c1-34377073efab" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasSerializationModel.LibraryModelContext" Name="LibraryModelContext" DisplayName="Library Model Context" PropertyName="SerializationModel" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Serialization Model">
          <RolePlayer>
            <DomainClassMoniker Name="LibraryModelContext" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="a99854cf-f7f0-487e-aac7-5faedd18aa74" Description="Description for Tum.PDE.LanguageDSL.LibraryModelContextHasSerializationModel.SerializationModel" Name="SerializationModel" DisplayName="Serialization Model" PropertyName="LibraryModelContext" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Library Model Context">
          <RolePlayer>
            <DomainClassMoniker Name="SerializationModel" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="b2c08e43-3d44-4cb1-8595-90973c5df655" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasPropertyGridEditors" Name="MetaModelHasPropertyGridEditors" DisplayName="Meta Model Has Property Grid Editors" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="bf1b2138-f6e6-4035-ac7a-247df992a72c" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasPropertyGridEditors.MetaModel" Name="MetaModel" DisplayName="Meta Model" PropertyName="PropertyGridEditors" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Property Grid Editors">
          <RolePlayer>
            <DomainClassMoniker Name="MetaModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="b34e3af0-9c30-40d8-a34c-c585f9808df0" Description="Description for Tum.PDE.LanguageDSL.MetaModelHasPropertyGridEditors.PropertyGridEditor" Name="PropertyGridEditor" DisplayName="Property Grid Editor" PropertyName="MetaModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Meta Model">
          <RolePlayer>
            <DomainClassMoniker Name="PropertyGridEditor" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="7dd20091-a9d4-4224-a113-006f8fe92f54" Description="Description for Tum.PDE.LanguageDSL.ViewHasModelTree" Name="ViewHasModelTree" DisplayName="View Has Model Tree" Namespace="Tum.PDE.LanguageDSL" IsEmbedding="true">
      <Source>
        <DomainRole Id="6ec00ac0-50d5-4ddc-b5f4-0eeb3cdf370a" Description="Description for Tum.PDE.LanguageDSL.ViewHasModelTree.View" Name="View" DisplayName="View" PropertyName="ModelTree" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Model Tree">
          <RolePlayer>
            <DomainClassMoniker Name="View" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="74075136-1ed2-4e0a-b6be-ba49a7799678" Description="Description for Tum.PDE.LanguageDSL.ViewHasModelTree.ModelTree" Name="ModelTree" DisplayName="Model Tree" PropertyName="View" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="View">
          <RolePlayer>
            <DomainClassMoniker Name="ModelTree" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="4dd60ab1-1d48-4f77-9b9b-9b7d1e16637c" Description="Description for Tum.PDE.LanguageDSL.ExternModelContextReferencesModelContext" Name="ExternModelContextReferencesModelContext" DisplayName="Extern Model Context References Model Context" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="68d0a394-9efd-408c-b07f-4aaeb0a05e29" Description="Description for Tum.PDE.LanguageDSL.ExternModelContextReferencesModelContext.ExternModelContext" Name="ExternModelContext" DisplayName="Extern Model Context" PropertyName="ModelContext" Multiplicity="ZeroOne" PropertyDisplayName="Model Context">
          <RolePlayer>
            <DomainClassMoniker Name="ExternModelContext" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="4af7d02a-cdca-4949-a8cb-89fb180bd783" Description="Description for Tum.PDE.LanguageDSL.ExternModelContextReferencesModelContext.ModelContext" Name="ModelContext" DisplayName="Model Context" PropertyName="ExternModelContexts" IsPropertyGenerator="false" PropertyDisplayName="Extern Model Contexts">
          <RolePlayer>
            <DomainClassMoniker Name="ModelContext" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="62c2e1f2-e1b4-476d-9b03-bfc5fac65b1b" Description="Description for Tum.PDE.LanguageDSL.DesignerDiagramClassReferencesImportedDiagramClasses" Name="DesignerDiagramClassReferencesImportedDiagramClasses" DisplayName="Designer Diagram Class References Imported Diagram Classes" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="3b69df8a-9162-4f3c-b2b8-cddffa5cf84d" Description="Description for Tum.PDE.LanguageDSL.DesignerDiagramClassReferencesImportedDiagramClasses.DesignerDiagramClass" Name="DesignerDiagramClass" DisplayName="Designer Diagram Class" PropertyName="ImportedDiagramClasses" PropertyDisplayName="Imported Diagram Classes">
          <RolePlayer>
            <DomainClassMoniker Name="DesignerDiagramClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="b8e5cd87-7ba8-462e-bcf5-b9fc593289ec" Description="Description for Tum.PDE.LanguageDSL.DesignerDiagramClassReferencesImportedDiagramClasses.DiagramClass" Name="DiagramClass" DisplayName="Diagram Class" PropertyName="IncludedDiagramClasses" IsPropertyGenerator="false" PropertyDisplayName="Included Diagram Classes">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="592b2aae-3563-4d9d-ad2b-4fb24a538ca5" Description="Description for Tum.PDE.LanguageDSL.ShapeClassReferencesBaseShape" Name="ShapeClassReferencesBaseShape" DisplayName="Shape Class References Base Shape" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="154c3e0d-e89e-4771-9ec2-0bdcf3d45a11" Description="Description for Tum.PDE.LanguageDSL.ShapeClassReferencesBaseShape.DerivedShape" Name="DerivedShape" DisplayName="Derived Shape" PropertyName="BaseShape" Multiplicity="ZeroOne" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" PropertyDisplayName="Base Shape">
          <RolePlayer>
            <DomainClassMoniker Name="ShapeClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="56b4849e-b7a9-46e9-917b-2c4c0d9870b1" Description="Description for Tum.PDE.LanguageDSL.ShapeClassReferencesBaseShape.BaseShape" Name="BaseShape" DisplayName="Base Shape" PropertyName="DerivedShapes" PropertyDisplayName="Derived Shapes">
          <RolePlayer>
            <DomainClassMoniker Name="ShapeClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="e041e861-868e-4bdb-9c72-82782f0bc3a7" Description="Description for Tum.PDE.LanguageDSL.DesignerDiagramClassReferencesIncludedDiagramClasses" Name="DesignerDiagramClassReferencesIncludedDiagramClasses" DisplayName="Designer Diagram Class References Included Diagram Classes" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="a35c4d2f-91d2-4c2c-b173-ad95ac61a932" Description="Description for Tum.PDE.LanguageDSL.DesignerDiagramClassReferencesIncludedDiagramClasses.DesignerDiagramClass" Name="DesignerDiagramClass" DisplayName="Designer Diagram Class" PropertyName="IncludedDiagramClasses" PropertyDisplayName="Included Diagram Classes">
          <RolePlayer>
            <DomainClassMoniker Name="DesignerDiagramClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="ff54c4fb-3d26-4795-99fa-b3b8626c1f1b" Description="Description for Tum.PDE.LanguageDSL.DesignerDiagramClassReferencesIncludedDiagramClasses.DiagramClass" Name="DiagramClass" DisplayName="Diagram Class" PropertyName="DesignerDiagramClasses" IsPropertyGenerator="false" PropertyDisplayName="Designer Diagram Classes">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="c22261c3-e92b-408c-a93e-9afa7a61424d" Description="Description for Tum.PDE.LanguageDSL.SpecificDependencyDiagramReferencesDomainClass" Name="SpecificDependencyDiagramReferencesDomainClass" DisplayName="Specific Dependency Diagram References Domain Class" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="0aab4e6a-0086-41c8-a710-e90e3f7d6fa7" Description="Description for Tum.PDE.LanguageDSL.SpecificDependencyDiagramReferencesDomainClass.SpecificDependencyDiagram" Name="SpecificDependencyDiagram" DisplayName="Specific Dependency Diagram" PropertyName="DomainClass" Multiplicity="One" Category="Definition" PropertyDisplayName="Domain Class">
          <RolePlayer>
            <DomainClassMoniker Name="SpecificDependencyDiagram" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="e35150ac-e548-43ff-b40e-1464024c2031" Description="Description for Tum.PDE.LanguageDSL.SpecificDependencyDiagramReferencesDomainClass.DomainClass" Name="DomainClass" DisplayName="Domain Class" PropertyName="SpecificDependencyDiagrams" IsPropertyGenerator="false" Category="Definition" PropertyDisplayName="Specific Dependency Diagrams">
          <RolePlayer>
            <DomainClassMoniker Name="DomainClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="b1281de8-e7ae-43be-aa39-42c5f6dfa0de" Description="Description for Tum.PDE.LanguageDSL.ModalDiagramReferencesDomainClass" Name="ModalDiagramReferencesDomainClass" DisplayName="Modal Diagram References Domain Class" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="24eab214-27f3-49a4-8f73-f02ea18a692b" Description="Description for Tum.PDE.LanguageDSL.ModalDiagramReferencesDomainClass.ModalDiagram" Name="ModalDiagram" DisplayName="Modal Diagram" PropertyName="DomainClass" Multiplicity="ZeroOne" Category="Definition" PropertyDisplayName="Domain Class">
          <RolePlayer>
            <DomainClassMoniker Name="ModalDiagram" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="ee827ab3-ebff-4338-9425-77eba5c5285b" Description="Description for Tum.PDE.LanguageDSL.ModalDiagramReferencesDomainClass.DomainClass" Name="DomainClass" DisplayName="Domain Class" PropertyName="ModalDiagrams" IsPropertyGenerator="false" Category="Definition" PropertyDisplayName="Modal Diagrams">
          <RolePlayer>
            <DomainClassMoniker Name="DomainClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="3b6a0554-30d5-4d4d-bd18-a39e603750c4" Description="Description for Tum.PDE.LanguageDSL.SpecificElementsDiagramReferencesDomainClasses" Name="SpecificElementsDiagramReferencesDomainClasses" DisplayName="Specific Elements Diagram References Domain Classes" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="37426f0b-b298-4feb-8353-99b210dd6c31" Description="Description for Tum.PDE.LanguageDSL.SpecificElementsDiagramReferencesDomainClasses.SpecificElementsDiagram" Name="SpecificElementsDiagram" DisplayName="Specific Elements Diagram" PropertyName="DomainClasses" PropertyDisplayName="Domain Classes">
          <RolePlayer>
            <DomainClassMoniker Name="SpecificElementsDiagram" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="cc1c7016-1e20-467a-8091-6adc6dc2d789" Description="Description for Tum.PDE.LanguageDSL.SpecificElementsDiagramReferencesDomainClasses.DomainClass" Name="DomainClass" DisplayName="Domain Class" PropertyName="SpecificElementsDiagrams" IsPropertyGenerator="false" PropertyDisplayName="Specific Elements Diagrams">
          <RolePlayer>
            <DomainClassMoniker Name="DomainClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="51e50240-c095-4136-9b76-2954739dbcf9" Description="Description for Tum.PDE.LanguageDSL.RelationshipShapeClassReferencesReferenceRelationship" Name="RelationshipShapeClassReferencesReferenceRelationship" DisplayName="Relationship Shape Class References Reference Relationship" Namespace="Tum.PDE.LanguageDSL">
      <Source>
        <DomainRole Id="f827d79f-8268-469a-9603-601144b30c52" Description="Description for Tum.PDE.LanguageDSL.RelationshipShapeClassReferencesReferenceRelationship.RelationshipShapeClass" Name="RelationshipShapeClass" DisplayName="Relationship Shape Class" PropertyName="ReferenceRelationship" Multiplicity="ZeroOne" PropagatesCopy="PropagateCopyToLinkOnly" Category="Definition" PropertyDisplayName="Reference Relationship">
          <RolePlayer>
            <DomainClassMoniker Name="RelationshipShapeClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="996850a1-8320-4910-8729-58c2846ad44c" Description="Description for Tum.PDE.LanguageDSL.RelationshipShapeClassReferencesReferenceRelationship.DomainRelationship" Name="DomainRelationship" DisplayName="Domain Relationship" PropertyName="RelationshipShapeClasses" Category="Definition" PropertyDisplayName="Relationship Shape Classes">
          <RolePlayer>
            <DomainClassMoniker Name="DomainRelationship" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
    <DomainEnumeration Name="AccessModifier" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.AccessModifier">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.AccessModifier.Public" Name="Public" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.AccessModifier.Assembly" Name="Assembly" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.AccessModifier.Private" Name="Private" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.AccessModifier.Family" Name="Family" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.AccessModifier.FamilyOrAssembly" Name="FamilyOrAssembly" Value="" />
      </Literals>
      <Attributes>
        <ClrAttribute Name="System.ComponentModel.TypeConverter">
          <Parameters>
            <AttributeParameter Value="typeof(Tum.PDE.LanguageDSL.Design.AccessModifierConverter)" />
          </Parameters>
        </ClrAttribute>
      </Attributes>
    </DomainEnumeration>
    <DomainEnumeration Name="TrackingEnum" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.TrackingEnum">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.TrackingEnum.True" Name="True" Value="0" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.TrackingEnum.False" Name="False" Value="1" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.TrackingEnum.IgnoreOnce" Name="IgnoreOnce" Value="2" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="InheritanceModifier" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.InheritanceModifier">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.InheritanceModifier.None" Name="None" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.InheritanceModifier.Abstract" Name="Abstract" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.InheritanceModifier.Sealed" Name="Sealed" Value="" />
      </Literals>
      <Attributes>
        <ClrAttribute Name="System.ComponentModel.TypeConverter">
          <Parameters>
            <AttributeParameter Value="typeof(Tum.PDE.LanguageDSL.Design.InheritanceModifierConverter)" />
          </Parameters>
        </ClrAttribute>
      </Attributes>
    </DomainEnumeration>
    <DomainEnumeration Name="Multiplicity" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.Multiplicity">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.Multiplicity.ZeroMany" Name="ZeroMany" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.Multiplicity.One" Name="One" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.Multiplicity.ZeroOne" Name="ZeroOne" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.Multiplicity.OneMany" Name="OneMany" Value="" />
      </Literals>
      <Attributes>
        <ClrAttribute Name="System.ComponentModel.TypeConverter">
          <Parameters>
            <AttributeParameter Value="typeof(Tum.PDE.LanguageDSL.Design.MultiplicityConverter)" />
          </Parameters>
        </ClrAttribute>
      </Attributes>
    </DomainEnumeration>
    <DomainEnumeration Name="SerializationRepresentationType" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.SerializationRepresentationType">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationRepresentationType.Attribute" Name="Attribute" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationRepresentationType.Element" Name="Element" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationRepresentationType.InnerValue" Name="InnerValue" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="PropertyGeneration" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.PropertyGeneration">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.PropertyGeneration.Automatic" Name="Automatic" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.PropertyGeneration.Manual" Name="Manual" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="SerializationStyle" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.SerializationStyle">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationStyle.Normal" Name="Normal" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationStyle.CDATA" Name="CDATA" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="SerializationElementType" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.SerializationElementType">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationElementType.DomainModel" Name="DomainModel" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationElementType.DomainClass" Name="DomainClass" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationElementType.EmbeddingRelationship" Name="EmbeddingRelationship" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationElementType.ReferenceRelationship" Name="ReferenceRelationship" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationElementType.DomainProperty" Name="DomainProperty" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationElementType.IdProperty" Name="IdProperty" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SerializationElementType.DomainRole" Name="DomainRole" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="RelativeChildBehaviour" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.RelativeChildBehaviour">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.RelativeChildBehaviour.None" Name="None" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.RelativeChildBehaviour.PositionRelativeToParent" Name="PositionRelativeToParent" Value="" />
        <EnumerationLiteral Description="Port like behaviour" Name="PositionOnEdgeOfParent" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="PropertyKind" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.PropertyKind">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.PropertyKind.Normal" Name="Normal" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.PropertyKind.Calculated" Name="Calculated" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.PropertyKind.CustomStorage" Name="CustomStorage" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="EditorBaseType" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.EditorBaseType">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.EditorBaseType.BooleanEditorViewModel" Name="BooleanEditorViewModel" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.EditorBaseType.EnumerationEditorViewModel" Name="EnumerationEditorViewModel" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.EditorBaseType.LookupListEditorViewModel" Name="LookupListEditorViewModel" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.EditorBaseType.MultipleRoleEditorViewModel" Name="MultipleRoleEditorViewModel" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.EditorBaseType.PropertyEditorViewModel" Name="PropertyEditorViewModel" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.EditorBaseType.RoleEditorViewModel" Name="RoleEditorViewModel" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.EditorBaseType.StringEditorViewModel" Name="StringEditorViewModel" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.EditorBaseType.UnaryRoleEditorViewModel" Name="UnaryRoleEditorViewModel" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="SortingBehavior" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.SortingBehavior">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SortingBehavior.None" Name="None" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.SortingBehavior.Alphabetical" Name="Alphabetical" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="DiagramVisualizationBehavior" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.DiagramVisualizationBehavior">
      <Literals>
        <EnumerationLiteral Description="Elements are deleted from the model as they are deleted from the diagram surface." Name="Normal" Value="" />
        <EnumerationLiteral Description="Elements are not deleted from the model as they are delted from the surface and therefore a selected visualization is possible." Name="Extended" Value="" />
      </Literals>
    </DomainEnumeration>
    <ExternalType Name="Color" Namespace="System.Drawing" />
    <DomainEnumeration Name="AnchorStyle" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.AnchorStyle">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.AnchorStyle.None" Name="None" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.AnchorStyle.Arrow" Name="Arrow" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.AnchorStyle.Diamond" Name="Diamond" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="LanguageType" Namespace="Tum.PDE.LanguageDSL" Description="Description for Tum.PDE.LanguageDSL.LanguageType">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.LanguageType.VMXEditor" Name="VMXEditor" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.LanguageType.VMXLibrary" Name="VMXLibrary" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.LanguageType.WPFEditor" Name="WPFEditor" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.LanguageType.WPFLibrary" Name="WPFLibrary" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.LanguageDSL.LanguageType.VSPlugin" Name="VSPlugin" Value="" />
      </Literals>
    </DomainEnumeration>
  </Types>
  <XmlSerializationBehavior Name="TestDslDefinitionSerializationBehavior" Namespace="Tum.PDE.LanguageDSL">
    <ClassData>
      <XmlClassData TypeName="MetaModel" MonikerAttributeName="name" SerializeId="true" MonikerElementName="metaModelMoniker" ElementName="MetaModel" MonikerTypeName="MetaModelMoniker">
        <DomainClassMoniker Name="MetaModel" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="MetaModel/Name" />
          </XmlPropertyData>
          <XmlRelationshipData RoleElementName="domainTypes">
            <DomainRelationshipMoniker Name="MetaModelHasDomainTypes" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="companyName">
            <DomainPropertyMoniker Name="MetaModel/CompanyName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="namespace">
            <DomainPropertyMoniker Name="MetaModel/Namespace" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="productName">
            <DomainPropertyMoniker Name="MetaModel/ProductName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="MetaModel/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="build">
            <DomainPropertyMoniker Name="MetaModel/Build" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="majorVersion">
            <DomainPropertyMoniker Name="MetaModel/MajorVersion" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="minorVersion">
            <DomainPropertyMoniker Name="MetaModel/MinorVersion" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="revision">
            <DomainPropertyMoniker Name="MetaModel/Revision" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="displayName">
            <DomainPropertyMoniker Name="MetaModel/DisplayName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="applicationName">
            <DomainPropertyMoniker Name="MetaModel/ApplicationName" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="validation">
            <DomainRelationshipMoniker Name="MetaModelHasValidation" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="layoutEmbeddedPath">
            <DomainPropertyMoniker Name="MetaModel/LayoutEmbeddedPath" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="layoutDVEmbeddedPath">
            <DomainPropertyMoniker Name="MetaModel/LayoutDVEmbeddedPath" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="additionalInformation">
            <DomainRelationshipMoniker Name="MetaModelHasAdditionalInformation" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="metaModelLibraries">
            <DomainRelationshipMoniker Name="MetaModelHasMetaModelLibraries" />
          </XmlRelationshipData>
          <XmlRelationshipData OmitElement="true" UseFullForm="true" RoleElementName="view">
            <DomainRelationshipMoniker Name="MetaModelHasView" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="modelContexts">
            <DomainRelationshipMoniker Name="MetaModelHasModelContexts" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="propertyGridEditors">
            <DomainRelationshipMoniker Name="MetaModelHasPropertyGridEditors" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="packageGuid">
            <DomainPropertyMoniker Name="MetaModel/PackageGuid" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="customExtensionGuid">
            <DomainPropertyMoniker Name="MetaModel/CustomExtensionGuid" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="customExtension">
            <DomainPropertyMoniker Name="MetaModel/CustomExtension" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="languageType">
            <DomainPropertyMoniker Name="MetaModel/LanguageType" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainElementMoniker" ElementName="domainElement" MonikerTypeName="DomainElementMoniker">
        <DomainClassMoniker Name="DomainElement" />
      </XmlClassData>
      <XmlClassData TypeName="NamedDomainElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="namedDomainElementMoniker" ElementName="namedDomainElement" MonikerTypeName="NamedDomainElementMoniker">
        <DomainClassMoniker Name="NamedDomainElement" />
        <ElementData>
          <XmlPropertyData XmlName="displayName">
            <DomainPropertyMoniker Name="NamedDomainElement/DisplayName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isDisplayNameTracking">
            <DomainPropertyMoniker Name="NamedDomainElement/IsDisplayNameTracking" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="NamedDomainElement/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="NamedDomainElement/Name" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="AttributedDomainElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="attributedDomainElementMoniker" ElementName="attributedDomainElement" MonikerTypeName="AttributedDomainElementMoniker">
        <DomainClassMoniker Name="AttributedDomainElement" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="properties">
            <DomainRelationshipMoniker Name="AttributedDomainElementHasProperties" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="serializationName">
            <DomainPropertyMoniker Name="AttributedDomainElement/SerializationName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isSerializationNameTracking">
            <DomainPropertyMoniker Name="AttributedDomainElement/IsSerializationNameTracking" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="AttributedDomainElementHasProperties" MonikerAttributeName="" SerializeId="true" MonikerElementName="attributedDomainElementHasPropertiesMoniker" ElementName="attributedDomainElementHasProperties" MonikerTypeName="AttributedDomainElementHasPropertiesMoniker">
        <DomainRelationshipMoniker Name="AttributedDomainElementHasProperties" />
      </XmlClassData>
      <XmlClassData TypeName="DomainProperty" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainPropertyMoniker" ElementName="domainProperty" MonikerTypeName="DomainPropertyMoniker">
        <DomainClassMoniker Name="DomainProperty" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="DomainProperty/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isElementName">
            <DomainPropertyMoniker Name="DomainProperty/IsElementName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isRequired">
            <DomainPropertyMoniker Name="DomainProperty/IsRequired" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="displayName">
            <DomainPropertyMoniker Name="DomainProperty/DisplayName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="DomainProperty/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="defaultValue">
            <DomainPropertyMoniker Name="DomainProperty/DefaultValue" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="category">
            <DomainPropertyMoniker Name="DomainProperty/Category" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isBrowsable">
            <DomainPropertyMoniker Name="DomainProperty/IsBrowsable" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="getterAccessModifier">
            <DomainPropertyMoniker Name="DomainProperty/GetterAccessModifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="setterAccessModifier">
            <DomainPropertyMoniker Name="DomainProperty/SetterAccessModifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isDisplayNameTracking">
            <DomainPropertyMoniker Name="DomainProperty/IsDisplayNameTracking" />
          </XmlPropertyData>
          <XmlRelationshipData RoleElementName="type">
            <DomainRelationshipMoniker Name="DomainPropertyReferencesType" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="serializationName">
            <DomainPropertyMoniker Name="DomainProperty/SerializationName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isSerializationNameTracking">
            <DomainPropertyMoniker Name="DomainProperty/IsSerializationNameTracking" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="serializationRepresentationType">
            <DomainPropertyMoniker Name="DomainProperty/SerializationRepresentationType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isUIReadOnly">
            <DomainPropertyMoniker Name="DomainProperty/IsUIReadOnly" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="propertyKind">
            <DomainPropertyMoniker Name="DomainProperty/PropertyKind" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isCustomCreated">
            <DomainPropertyMoniker Name="DomainProperty/IsCustomCreated" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainRelationshipMoniker" ElementName="domainRelationship" MonikerTypeName="DomainRelationshipMoniker">
        <DomainClassMoniker Name="DomainRelationship" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="roles">
            <DomainRelationshipMoniker Name="DomainRelationshipHasRoles" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="source">
            <DomainRelationshipMoniker Name="DomainRelationshipReferencesSource" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="target">
            <DomainRelationshipMoniker Name="DomainRelationshipReferencesTarget" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="baseRelationship">
            <DomainRelationshipMoniker Name="DomainRelationshipReferencesBaseRelationship" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="isNameTracking">
            <DomainPropertyMoniker Name="DomainRelationship/IsNameTracking" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="allowsDuplicates">
            <DomainPropertyMoniker Name="DomainRelationship/AllowsDuplicates" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainClassMoniker" ElementName="domainClass" MonikerTypeName="DomainClassMoniker">
        <DomainClassMoniker Name="DomainClass" />
        <ElementData>
          <XmlPropertyData XmlName="isDomainModel">
            <DomainPropertyMoniker Name="DomainClass/IsDomainModel" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="baseClass">
            <DomainRelationshipMoniker Name="DomainClassReferencesBaseClass" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="canCopy">
            <DomainPropertyMoniker Name="DomainClass/CanCopy" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="canMove">
            <DomainPropertyMoniker Name="DomainClass/CanMove" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="canPaste">
            <DomainPropertyMoniker Name="DomainClass/CanPaste" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="generateSpecificViewModel">
            <DomainPropertyMoniker Name="DomainClass/GenerateSpecificViewModel" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="generateSpecificViewModelProperties">
            <DomainPropertyMoniker Name="DomainClass/GenerateSpecificViewModelProperties" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="generateSpecificViewModelReferences">
            <DomainPropertyMoniker Name="DomainClass/GenerateSpecificViewModelReferences" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="generateSpecificViewModelEmbeddings">
            <DomainPropertyMoniker Name="DomainClass/GenerateSpecificViewModelEmbeddings" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="generateSpecificViewModelOppositeReferences">
            <DomainPropertyMoniker Name="DomainClass/GenerateSpecificViewModelOppositeReferences" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainRole" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainRoleMoniker" ElementName="domainRole" MonikerTypeName="DomainRoleMoniker">
        <DomainClassMoniker Name="DomainRole" />
        <ElementData>
          <XmlPropertyData XmlName="multiplicity">
            <DomainPropertyMoniker Name="DomainRole/Multiplicity" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="propertyName">
            <DomainPropertyMoniker Name="DomainRole/PropertyName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="propertyDisplayName">
            <DomainPropertyMoniker Name="DomainRole/PropertyDisplayName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isPropertyNameTracking">
            <DomainPropertyMoniker Name="DomainRole/IsPropertyNameTracking" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isPropertyDisplayNameTracking">
            <DomainPropertyMoniker Name="DomainRole/IsPropertyDisplayNameTracking" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="category">
            <DomainPropertyMoniker Name="DomainRole/Category" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="propertyGetterAccessModifier">
            <DomainPropertyMoniker Name="DomainRole/PropertyGetterAccessModifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="propertySetterAccessModifier">
            <DomainPropertyMoniker Name="DomainRole/PropertySetterAccessModifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isPropertyBrowsable">
            <DomainPropertyMoniker Name="DomainRole/IsPropertyBrowsable" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isPropertyGenerator">
            <DomainPropertyMoniker Name="DomainRole/IsPropertyGenerator" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="propagatesDelete">
            <DomainPropertyMoniker Name="DomainRole/PropagatesDelete" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isNameTracking">
            <DomainPropertyMoniker Name="DomainRole/IsNameTracking" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="opposite">
            <DomainRelationshipMoniker Name="DomainRoleReferencesOpposite" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="rolePlayer">
            <DomainRelationshipMoniker Name="DomainRoleReferencesRolePlayer" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="isPropertyUIReadOnly">
            <DomainPropertyMoniker Name="DomainRole/IsPropertyUIReadOnly" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="customPropertyGridEditor">
            <DomainRelationshipMoniker Name="DomainRoleReferencesCustomPropertyGridEditor" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EmbeddingRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="embeddingRelationshipMoniker" ElementName="embeddingRelationship" MonikerTypeName="EmbeddingRelationshipMoniker">
        <DomainClassMoniker Name="EmbeddingRelationship" />
        <ElementData>
          <XmlPropertyData XmlName="propagatesCopyToChild">
            <DomainPropertyMoniker Name="EmbeddingRelationship/PropagatesCopyToChild" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ReferenceRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="referenceRelationshipMoniker" ElementName="referenceRelationship" MonikerTypeName="ReferenceRelationshipMoniker">
        <DomainClassMoniker Name="ReferenceRelationship" />
        <ElementData>
          <XmlPropertyData XmlName="serializationAttributeName">
            <DomainPropertyMoniker Name="ReferenceRelationship/SerializationAttributeName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="serializationTargetName">
            <DomainPropertyMoniker Name="ReferenceRelationship/SerializationTargetName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="serializationSourceName">
            <DomainPropertyMoniker Name="ReferenceRelationship/SerializationSourceName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="propagatesCopyToTarget">
            <DomainPropertyMoniker Name="ReferenceRelationship/PropagatesCopyToTarget" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="propagatesCopyToSource">
            <DomainPropertyMoniker Name="ReferenceRelationship/PropagatesCopyToSource" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="propagatesCopyOnDeniedElementCopy">
            <DomainPropertyMoniker Name="ReferenceRelationship/PropagatesCopyOnDeniedElementCopy" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isSerializationTargetNameTracking">
            <DomainPropertyMoniker Name="ReferenceRelationship/IsSerializationTargetNameTracking" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isSerializationSourceNameTracking">
            <DomainPropertyMoniker Name="ReferenceRelationship/IsSerializationSourceNameTracking" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainRelationshipHasRoles" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainRelationshipHasRolesMoniker" ElementName="domainRelationshipHasRoles" MonikerTypeName="DomainRelationshipHasRolesMoniker">
        <DomainRelationshipMoniker Name="DomainRelationshipHasRoles" />
      </XmlClassData>
      <XmlClassData TypeName="DomainRelationshipReferencesSource" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainRelationshipReferencesSourceMoniker" ElementName="domainRelationshipReferencesSource" MonikerTypeName="DomainRelationshipReferencesSourceMoniker">
        <DomainRelationshipMoniker Name="DomainRelationshipReferencesSource" />
      </XmlClassData>
      <XmlClassData TypeName="DomainRelationshipReferencesTarget" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainRelationshipReferencesTargetMoniker" ElementName="domainRelationshipReferencesTarget" MonikerTypeName="DomainRelationshipReferencesTargetMoniker">
        <DomainRelationshipMoniker Name="DomainRelationshipReferencesTarget" />
      </XmlClassData>
      <XmlClassData TypeName="DomainModelTreeView" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainModelTreeViewMoniker" ElementName="domainModelTreeView" MonikerTypeName="DomainModelTreeViewMoniker">
        <DomainClassMoniker Name="DomainModelTreeView" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="rootNodes">
            <DomainRelationshipMoniker Name="DomainModelTreeViewReferencesRootNodes" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="modelTreeNodes">
            <DomainRelationshipMoniker Name="DomainModelTreeViewHasModelTreeNodes" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="RootNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="rootNodeMoniker" ElementName="rootNode" MonikerTypeName="RootNodeMoniker">
        <DomainClassMoniker Name="RootNode" />
      </XmlClassData>
      <XmlClassData TypeName="TreeNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="treeNodeMoniker" ElementName="treeNode" MonikerTypeName="TreeNodeMoniker">
        <DomainClassMoniker Name="TreeNode" />
        <ElementData>
          <XmlPropertyData XmlName="isEmbeddingTreeExpanded">
            <DomainPropertyMoniker Name="TreeNode/IsEmbeddingTreeExpanded" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isInheritanceTreeExpanded">
            <DomainPropertyMoniker Name="TreeNode/IsInheritanceTreeExpanded" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isReferenceTreeExpanded">
            <DomainPropertyMoniker Name="TreeNode/IsReferenceTreeExpanded" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isShapeMappingTreeExpanded">
            <DomainPropertyMoniker Name="TreeNode/IsShapeMappingTreeExpanded" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isElementHolder">
            <DomainPropertyMoniker Name="TreeNode/IsElementHolder" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isExpanded">
            <DomainPropertyMoniker Name="TreeNode/IsExpanded" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainElement">
            <DomainRelationshipMoniker Name="TreeNodeReferencesDomainElement" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="embeddingRSNodes">
            <DomainRelationshipMoniker Name="TreeNodeReferencesEmbeddingRSNodes" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="inheritanceNodes">
            <DomainRelationshipMoniker Name="TreeNodeReferencesInheritanceNodes" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="referenceRSNodes">
            <DomainRelationshipMoniker Name="TreeNodeReferencesReferenceRSNodes" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="shapeClassNodes">
            <DomainRelationshipMoniker Name="TreeNodeReferencesShapeClassNodes" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EmbeddingRSNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="embeddingRSNodeMoniker" ElementName="embeddingRSNode" MonikerTypeName="EmbeddingRSNodeMoniker">
        <DomainClassMoniker Name="EmbeddingRSNode" />
        <ElementData>
          <XmlPropertyData XmlName="isExpanded">
            <DomainPropertyMoniker Name="EmbeddingRSNode/IsExpanded" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="relationship">
            <DomainRelationshipMoniker Name="EmbeddingRSNodeReferencesRelationship" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="embeddingNode">
            <DomainRelationshipMoniker Name="EmbeddingRSNodeReferencesEmbeddingNode" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EmbeddingNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="embeddingNodeMoniker" ElementName="embeddingNode" MonikerTypeName="EmbeddingNodeMoniker">
        <DomainClassMoniker Name="EmbeddingNode" />
      </XmlClassData>
      <XmlClassData TypeName="InheritanceNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="inheritanceNodeMoniker" ElementName="inheritanceNode" MonikerTypeName="InheritanceNodeMoniker">
        <DomainClassMoniker Name="InheritanceNode" />
        <ElementData>
          <XmlPropertyData XmlName="inhRelationshipId">
            <DomainPropertyMoniker Name="InheritanceNode/InhRelationshipId" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ReferenceRSNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="referenceRSNodeMoniker" ElementName="referenceRSNode" MonikerTypeName="ReferenceRSNodeMoniker">
        <DomainClassMoniker Name="ReferenceRSNode" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="referenceRelationship">
            <DomainRelationshipMoniker Name="ReferenceRSNodeReferencesReferenceRelationship" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="isShapeMappingTreeExpanded">
            <DomainPropertyMoniker Name="ReferenceRSNode/IsShapeMappingTreeExpanded" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isExpanded">
            <DomainPropertyMoniker Name="ReferenceRSNode/IsExpanded" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="referenceNode">
            <DomainRelationshipMoniker Name="ReferenceRSNodeReferencesReferenceNode" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="shapeRelationshipNodes">
            <DomainRelationshipMoniker Name="ReferenceRSNodeReferencesShapeRelationshipNodes" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ReferenceNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="referenceNodeMoniker" ElementName="referenceNode" MonikerTypeName="ReferenceNodeMoniker">
        <DomainClassMoniker Name="ReferenceNode" />
      </XmlClassData>
      <XmlClassData TypeName="ReferenceRSNodeReferencesReferenceRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="referenceRSNodeReferencesReferenceRelationshipMoniker" ElementName="referenceRSNodeReferencesReferenceRelationship" MonikerTypeName="ReferenceRSNodeReferencesReferenceRelationshipMoniker">
        <DomainRelationshipMoniker Name="ReferenceRSNodeReferencesReferenceRelationship" />
      </XmlClassData>
      <XmlClassData TypeName="ShapeClassNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="shapeClassNodeMoniker" ElementName="shapeClassNode" MonikerTypeName="ShapeClassNodeMoniker">
        <DomainClassMoniker Name="ShapeClassNode" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="shapeClass">
            <DomainRelationshipMoniker Name="ShapeClassNodeReferencesShapeClass" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ShapeRelationshipNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="shapeRelationshipNodeMoniker" ElementName="shapeRelationshipNode" MonikerTypeName="ShapeRelationshipNodeMoniker">
        <DomainClassMoniker Name="ShapeRelationshipNode" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="relationshipShapeClass">
            <DomainRelationshipMoniker Name="ShapeRelationshipNodeReferencesRelationshipShapeClass" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="MetaModelHasDomainTypes" MonikerAttributeName="" MonikerElementName="metaModelHasDomainTypesMoniker" ElementName="metaModelHasDomainTypes" MonikerTypeName="MetaModelHasDomainTypesMoniker">
        <DomainRelationshipMoniker Name="MetaModelHasDomainTypes" />
      </XmlClassData>
      <XmlClassData TypeName="DomainType" MonikerAttributeName="name" MonikerElementName="domainTypeMoniker" ElementName="domainType" MonikerTypeName="DomainTypeMoniker">
        <DomainClassMoniker Name="DomainType" />
        <ElementData>
          <XmlPropertyData XmlName="namespace">
            <DomainPropertyMoniker Name="DomainType/Namespace" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="serializationStyle">
            <DomainPropertyMoniker Name="DomainType/SerializationStyle" />
          </XmlPropertyData>
          <XmlRelationshipData RoleElementName="propertyGridEditor">
            <DomainRelationshipMoniker Name="DomainTypeReferencesPropertyGridEditor" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="DomainType/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="DomainType/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="displayName">
            <DomainPropertyMoniker Name="DomainType/DisplayName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isDisplayNameTracking">
            <DomainPropertyMoniker Name="DomainType/IsDisplayNameTracking" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="requiresSerializationConversion">
            <DomainPropertyMoniker Name="DomainType/RequiresSerializationConversion" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ExternalType" MonikerAttributeName="" MonikerElementName="externalTypeMoniker" ElementName="externalType" MonikerTypeName="ExternalTypeMoniker">
        <DomainClassMoniker Name="ExternalType" />
      </XmlClassData>
      <XmlClassData TypeName="DomainEnumeration" MonikerAttributeName="" MonikerElementName="domainEnumerationMoniker" ElementName="domainEnumeration" MonikerTypeName="DomainEnumerationMoniker">
        <DomainClassMoniker Name="DomainEnumeration" />
        <ElementData>
          <XmlPropertyData XmlName="accessModifier">
            <DomainPropertyMoniker Name="DomainEnumeration/AccessModifier" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="literals">
            <DomainRelationshipMoniker Name="DomainEnumerationHasLiterals" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="isFlags">
            <DomainPropertyMoniker Name="DomainEnumeration/IsFlags" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainEnumerationHasLiterals" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainEnumerationHasLiteralsMoniker" ElementName="domainEnumerationHasLiterals" MonikerTypeName="DomainEnumerationHasLiteralsMoniker">
        <DomainRelationshipMoniker Name="DomainEnumerationHasLiterals" />
      </XmlClassData>
      <XmlClassData TypeName="EnumerationLiteral" MonikerAttributeName="" SerializeId="true" MonikerElementName="enumerationLiteralMoniker" ElementName="enumerationLiteral" MonikerTypeName="EnumerationLiteralMoniker">
        <DomainClassMoniker Name="EnumerationLiteral" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="EnumerationLiteral/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="EnumerationLiteral/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="value">
            <DomainPropertyMoniker Name="EnumerationLiteral/Value" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="displayName">
            <DomainPropertyMoniker Name="EnumerationLiteral/DisplayName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isDisplayNameTracking">
            <DomainPropertyMoniker Name="EnumerationLiteral/IsDisplayNameTracking" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="serializationName">
            <DomainPropertyMoniker Name="EnumerationLiteral/SerializationName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isSerializationNameTracking">
            <DomainPropertyMoniker Name="EnumerationLiteral/IsSerializationNameTracking" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainPropertyReferencesType" MonikerAttributeName="" MonikerElementName="domainPropertyReferencesTypeMoniker" ElementName="domainPropertyReferencesType" MonikerTypeName="DomainPropertyReferencesTypeMoniker">
        <DomainRelationshipMoniker Name="DomainPropertyReferencesType" />
      </XmlClassData>
      <XmlClassData TypeName="DiagramClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramClassMoniker" ElementName="diagramClass" MonikerTypeName="DiagramClassMoniker">
        <DomainClassMoniker Name="DiagramClass" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="presentationElements">
            <DomainRelationshipMoniker Name="DiagramClassHasPresentationElements" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="DiagramClass/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="title">
            <DomainPropertyMoniker Name="DiagramClass/Title" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isCustom">
            <DomainPropertyMoniker Name="DiagramClass/IsCustom" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="visualizationBehavior">
            <DomainPropertyMoniker Name="DiagramClass/VisualizationBehavior" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DiagramClassView" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramClassViewMoniker" ElementName="diagramClassView" MonikerTypeName="DiagramClassViewMoniker">
        <DomainClassMoniker Name="DiagramClassView" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="diagramClass">
            <DomainRelationshipMoniker Name="DiagramClassViewReferencesDiagramClass" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="rootDiagramNodes">
            <DomainRelationshipMoniker Name="DiagramClassViewHasRootDiagramNodes" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="isExpanded">
            <DomainPropertyMoniker Name="DiagramClassView/IsExpanded" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DiagramClassViewReferencesDiagramClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramClassViewReferencesDiagramClassMoniker" ElementName="diagramClassViewReferencesDiagramClass" MonikerTypeName="DiagramClassViewReferencesDiagramClassMoniker">
        <DomainRelationshipMoniker Name="DiagramClassViewReferencesDiagramClass" />
      </XmlClassData>
      <XmlClassData TypeName="DiagramClassHasPresentationElements" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramClassHasPresentationElementsMoniker" ElementName="diagramClassHasPresentationElements" MonikerTypeName="DiagramClassHasPresentationElementsMoniker">
        <DomainRelationshipMoniker Name="DiagramClassHasPresentationElements" />
      </XmlClassData>
      <XmlClassData TypeName="PresentationElementClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="presentationElementClassMoniker" ElementName="presentationElementClass" MonikerTypeName="PresentationElementClassMoniker">
        <DomainClassMoniker Name="PresentationElementClass" />
        <ElementData>
          <XmlPropertyData XmlName="generatePropertiesVM">
            <DomainPropertyMoniker Name="PresentationElementClass/GeneratePropertiesVM" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="generateShapePropertiesVM">
            <DomainPropertyMoniker Name="PresentationElementClass/GenerateShapePropertiesVM" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ShapeClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="shapeClassMoniker" ElementName="shapeClass" MonikerTypeName="ShapeClassMoniker">
        <DomainClassMoniker Name="ShapeClass" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="children">
            <DomainRelationshipMoniker Name="ShapeClassReferencesChildren" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="defaultWidth">
            <DomainPropertyMoniker Name="ShapeClass/DefaultWidth" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="defaultHeight">
            <DomainPropertyMoniker Name="ShapeClass/DefaultHeight" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isFixedWidth">
            <DomainPropertyMoniker Name="ShapeClass/IsFixedWidth" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isFixedHeight">
            <DomainPropertyMoniker Name="ShapeClass/IsFixedHeight" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isRelativeChild">
            <DomainPropertyMoniker Name="ShapeClass/IsRelativeChild" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="relativeChildBehaviour">
            <DomainPropertyMoniker Name="ShapeClass/RelativeChildBehaviour" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isAutoGenerated">
            <DomainPropertyMoniker Name="ShapeClass/IsAutoGenerated" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="borderThickness">
            <DomainPropertyMoniker Name="ShapeClass/BorderThickness" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="backgroundBrush">
            <DomainPropertyMoniker Name="ShapeClass/BackgroundBrush" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="borderBrush">
            <DomainPropertyMoniker Name="ShapeClass/BorderBrush" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="borderOuterBrush">
            <DomainPropertyMoniker Name="ShapeClass/BorderOuterBrush" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="borderOuterSize">
            <DomainPropertyMoniker Name="ShapeClass/BorderOuterSize" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="borderCornerRadius">
            <DomainPropertyMoniker Name="ShapeClass/BorderCornerRadius" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="borderIsHitTestVisible">
            <DomainPropertyMoniker Name="ShapeClass/BorderIsHitTestVisible" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="borderFocusable">
            <DomainPropertyMoniker Name="ShapeClass/BorderFocusable" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="menuIconUri">
            <DomainPropertyMoniker Name="ShapeClass/MenuIconUri" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="baseShape">
            <DomainRelationshipMoniker Name="ShapeClassReferencesBaseShape" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="useInDependencyView">
            <DomainPropertyMoniker Name="ShapeClass/UseInDependencyView" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="RelationshipShapeClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="relationshipShapeClassMoniker" ElementName="relationshipShapeClass" MonikerTypeName="RelationshipShapeClassMoniker">
        <DomainClassMoniker Name="RelationshipShapeClass" />
        <ElementData>
          <XmlPropertyData XmlName="isAutoGenerated">
            <DomainPropertyMoniker Name="RelationshipShapeClass/IsAutoGenerated" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="startAnchorStyle">
            <DomainPropertyMoniker Name="RelationshipShapeClass/StartAnchorStyle" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="endAnchorStyle">
            <DomainPropertyMoniker Name="RelationshipShapeClass/EndAnchorStyle" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="strokeThickness">
            <DomainPropertyMoniker Name="RelationshipShapeClass/StrokeThickness" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="stroke">
            <DomainPropertyMoniker Name="RelationshipShapeClass/Stroke" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="referenceRelationship">
            <DomainRelationshipMoniker Name="RelationshipShapeClassReferencesReferenceRelationship" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainClassReferencesBaseClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainClassReferencesBaseClassMoniker" ElementName="domainClassReferencesBaseClass" MonikerTypeName="DomainClassReferencesBaseClassMoniker">
        <DomainRelationshipMoniker Name="DomainClassReferencesBaseClass" />
        <ElementData>
          <XmlPropertyData XmlName="inhNodeId">
            <DomainPropertyMoniker Name="DomainClassReferencesBaseClass/InhNodeId" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainRelationshipReferencesBaseRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainRelationshipReferencesBaseRelationshipMoniker" ElementName="domainRelationshipReferencesBaseRelationship" MonikerTypeName="DomainRelationshipReferencesBaseRelationshipMoniker">
        <DomainRelationshipMoniker Name="DomainRelationshipReferencesBaseRelationship" />
      </XmlClassData>
      <XmlClassData TypeName="GeneratedDomainElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="generatedDomainElementMoniker" ElementName="generatedDomainElement" MonikerTypeName="GeneratedDomainElementMoniker">
        <DomainClassMoniker Name="GeneratedDomainElement" />
        <ElementData>
          <XmlPropertyData XmlName="generatesDoubleDerived">
            <DomainPropertyMoniker Name="GeneratedDomainElement/GeneratesDoubleDerived" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="hasCustomConstructor">
            <DomainPropertyMoniker Name="GeneratedDomainElement/HasCustomConstructor" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="accessModifier">
            <DomainPropertyMoniker Name="GeneratedDomainElement/AccessModifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="inheritanceModifier">
            <DomainPropertyMoniker Name="GeneratedDomainElement/InheritanceModifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="namespace">
            <DomainPropertyMoniker Name="GeneratedDomainElement/Namespace" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainRoleReferencesOpposite" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainRoleReferencesOppositeMoniker" ElementName="domainRoleReferencesOpposite" MonikerTypeName="DomainRoleReferencesOppositeMoniker">
        <DomainRelationshipMoniker Name="DomainRoleReferencesOpposite" />
      </XmlClassData>
      <XmlClassData TypeName="EmbeddingRSNodeReferencesRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="embeddingRSNodeReferencesRelationshipMoniker" ElementName="embeddingRSNodeReferencesRelationship" MonikerTypeName="EmbeddingRSNodeReferencesRelationshipMoniker">
        <DomainRelationshipMoniker Name="EmbeddingRSNodeReferencesRelationship" />
      </XmlClassData>
      <XmlClassData TypeName="DomainRoleReferencesRolePlayer" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainRoleReferencesRolePlayerMoniker" ElementName="domainRoleReferencesRolePlayer" MonikerTypeName="DomainRoleReferencesRolePlayerMoniker">
        <DomainRelationshipMoniker Name="DomainRoleReferencesRolePlayer" />
      </XmlClassData>
      <XmlClassData TypeName="TreeNodeReferencesDomainElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="treeNodeReferencesDomainElementMoniker" ElementName="treeNodeReferencesDomainElement" MonikerTypeName="TreeNodeReferencesDomainElementMoniker">
        <DomainRelationshipMoniker Name="TreeNodeReferencesDomainElement" />
      </XmlClassData>
      <XmlClassData TypeName="ShapeClassReferencesChildren" MonikerAttributeName="" SerializeId="true" MonikerElementName="shapeClassReferencesChildrenMoniker" ElementName="shapeClassReferencesChildren" MonikerTypeName="ShapeClassReferencesChildrenMoniker">
        <DomainRelationshipMoniker Name="ShapeClassReferencesChildren" />
      </XmlClassData>
      <XmlClassData TypeName="DiagramClassViewHasRootDiagramNodes" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramClassViewHasRootDiagramNodesMoniker" ElementName="diagramClassViewHasRootDiagramNodes" MonikerTypeName="DiagramClassViewHasRootDiagramNodesMoniker">
        <DomainRelationshipMoniker Name="DiagramClassViewHasRootDiagramNodes" />
      </XmlClassData>
      <XmlClassData TypeName="RootDiagramNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="rootDiagramNodeMoniker" ElementName="rootDiagramNode" MonikerTypeName="RootDiagramNodeMoniker">
        <DomainClassMoniker Name="RootDiagramNode" />
      </XmlClassData>
      <XmlClassData TypeName="EmbeddingDiagramNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="embeddingDiagramNodeMoniker" ElementName="embeddingDiagramNode" MonikerTypeName="EmbeddingDiagramNodeMoniker">
        <DomainClassMoniker Name="EmbeddingDiagramNode" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="embeddingDiagramNodes">
            <DomainRelationshipMoniker Name="EmbeddingDiagramNodeHasEmbeddingDiagramNodes" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="isExpanded">
            <DomainPropertyMoniker Name="EmbeddingDiagramNode/IsExpanded" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isChildrenTreeExpanded">
            <DomainPropertyMoniker Name="EmbeddingDiagramNode/IsChildrenTreeExpanded" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DiagramTreeNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramTreeNodeMoniker" ElementName="diagramTreeNode" MonikerTypeName="DiagramTreeNodeMoniker">
        <DomainClassMoniker Name="DiagramTreeNode" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="presentationElementClass">
            <DomainRelationshipMoniker Name="DiagramTreeNodeReferencesPresentationElementClass" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializationModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializationModelMoniker" ElementName="serializationModel" MonikerTypeName="SerializationModelMoniker">
        <DomainClassMoniker Name="SerializationModel" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="serializedDomainModel">
            <DomainRelationshipMoniker Name="SerializationModelHasSerializedDomainModel" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="children">
            <DomainRelationshipMoniker Name="SerializationModelHasChildren" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="serializedIdAttributeName">
            <DomainPropertyMoniker Name="SerializationModel/SerializedIdAttributeName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializedDomainModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedDomainModelMoniker" ElementName="serializedDomainModel" MonikerTypeName="SerializedDomainModelMoniker">
        <DomainClassMoniker Name="SerializedDomainModel" />
        <ElementData>
          <XmlPropertyData XmlName="serializedIdAttributeName">
            <DomainPropertyMoniker Name="SerializedDomainModel/SerializedIdAttributeName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializationElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializationElementMoniker" ElementName="serializationElement" MonikerTypeName="SerializationElementMoniker">
        <DomainClassMoniker Name="SerializationElement" />
      </XmlClassData>
      <XmlClassData TypeName="SerializedDomainClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedDomainClassMoniker" ElementName="serializedDomainClass" MonikerTypeName="SerializedDomainClassMoniker">
        <DomainClassMoniker Name="SerializedDomainClass" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainClass">
            <DomainRelationshipMoniker Name="SerializedDomainClassReferencesDomainClass" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializedEmbeddingRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedEmbeddingRelationshipMoniker" ElementName="serializedEmbeddingRelationship" MonikerTypeName="SerializedEmbeddingRelationshipMoniker">
        <DomainClassMoniker Name="SerializedEmbeddingRelationship" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="embeddingRelationship">
            <DomainRelationshipMoniker Name="SerializedEmbeddingRelationshipReferencesEmbeddingRelationship" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="isTargetIncludedSubmodel">
            <DomainPropertyMoniker Name="SerializedEmbeddingRelationship/IsTargetIncludedSubmodel" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializedReferenceRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedReferenceRelationshipMoniker" ElementName="serializedReferenceRelationship" MonikerTypeName="SerializedReferenceRelationshipMoniker">
        <DomainClassMoniker Name="SerializedReferenceRelationship" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="referenceRelationship">
            <DomainRelationshipMoniker Name="SerializedReferenceRelationshipReferencesReferenceRelationship" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializedDomainProperty" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedDomainPropertyMoniker" ElementName="serializedDomainProperty" MonikerTypeName="SerializedDomainPropertyMoniker">
        <DomainClassMoniker Name="SerializedDomainProperty" />
        <ElementData>
          <XmlPropertyData XmlName="serializationName">
            <DomainPropertyMoniker Name="SerializedDomainProperty/SerializationName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="serializationRepresentationType">
            <DomainPropertyMoniker Name="SerializedDomainProperty/SerializationRepresentationType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isSerializationNameTracking">
            <DomainPropertyMoniker Name="SerializedDomainProperty/IsSerializationNameTracking" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="omitProperty">
            <DomainPropertyMoniker Name="SerializedDomainProperty/OmitProperty" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainProperty">
            <DomainRelationshipMoniker Name="SerializedDomainPropertyReferencesDomainProperty" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializationClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializationClassMoniker" ElementName="serializationClass" MonikerTypeName="SerializationClassMoniker">
        <DomainClassMoniker Name="SerializationClass" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="children">
            <DomainRelationshipMoniker Name="SerializationClassReferencesChildren" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="isSerializationNameTracking">
            <DomainPropertyMoniker Name="SerializationClass/IsSerializationNameTracking" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="serializationName">
            <DomainPropertyMoniker Name="SerializationClass/SerializationName" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="attributes">
            <DomainRelationshipMoniker Name="SerializationClassReferencesAttributes" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="idProperty">
            <DomainRelationshipMoniker Name="SerializationClassHasIdProperty" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="properties">
            <DomainRelationshipMoniker Name="SerializationClassHasProperties" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializationClassReferencesChildren" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializationClassReferencesChildrenMoniker" ElementName="serializationClassReferencesChildren" MonikerTypeName="SerializationClassReferencesChildrenMoniker">
        <DomainRelationshipMoniker Name="SerializationClassReferencesChildren" />
      </XmlClassData>
      <XmlClassData TypeName="SerializedIdProperty" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedIdPropertyMoniker" ElementName="serializedIdProperty" MonikerTypeName="SerializedIdPropertyMoniker">
        <DomainClassMoniker Name="SerializedIdProperty" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="SerializedIdProperty/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="serializationName">
            <DomainPropertyMoniker Name="SerializedIdProperty/SerializationName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="omitIdProperty">
            <DomainPropertyMoniker Name="SerializedIdProperty/OmitIdProperty" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializedDomainRole" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedDomainRoleMoniker" ElementName="serializedDomainRole" MonikerTypeName="SerializedDomainRoleMoniker">
        <DomainClassMoniker Name="SerializedDomainRole" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainRole">
            <DomainRelationshipMoniker Name="SerializedDomainRoleReferencesDomainRole" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="serializationName">
            <DomainPropertyMoniker Name="SerializedDomainRole/SerializationName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="serializationAttributeName">
            <DomainPropertyMoniker Name="SerializedDomainRole/SerializationAttributeName" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="serializationClass">
            <DomainRelationshipMoniker Name="SerializedDomainRoleReferencesSerializationClass" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializedDomainRoleReferencesDomainRole" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedDomainRoleReferencesDomainRoleMoniker" ElementName="serializedDomainRoleReferencesDomainRole" MonikerTypeName="SerializedDomainRoleReferencesDomainRoleMoniker">
        <DomainRelationshipMoniker Name="SerializedDomainRoleReferencesDomainRole" />
      </XmlClassData>
      <XmlClassData TypeName="SerializationAttributeElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializationAttributeElementMoniker" ElementName="serializationAttributeElement" MonikerTypeName="SerializationAttributeElementMoniker">
        <DomainClassMoniker Name="SerializationAttributeElement" />
      </XmlClassData>
      <XmlClassData TypeName="SerializationClassReferencesAttributes" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializationClassReferencesAttributesMoniker" ElementName="serializationClassReferencesAttributes" MonikerTypeName="SerializationClassReferencesAttributesMoniker">
        <DomainRelationshipMoniker Name="SerializationClassReferencesAttributes" />
      </XmlClassData>
      <XmlClassData TypeName="MetaModelHasValidation" MonikerAttributeName="" SerializeId="true" MonikerElementName="metaModelHasValidationMoniker" ElementName="metaModelHasValidation" MonikerTypeName="MetaModelHasValidationMoniker">
        <DomainRelationshipMoniker Name="MetaModelHasValidation" />
      </XmlClassData>
      <XmlClassData TypeName="Validation" MonikerAttributeName="" SerializeId="true" MonikerElementName="validationMoniker" ElementName="validation" MonikerTypeName="ValidationMoniker">
        <DomainClassMoniker Name="Validation" />
        <ElementData>
          <XmlPropertyData XmlName="useLoad">
            <DomainPropertyMoniker Name="Validation/UseLoad" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="useMenu">
            <DomainPropertyMoniker Name="Validation/UseMenu" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="useOpen">
            <DomainPropertyMoniker Name="Validation/UseOpen" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="useSave">
            <DomainPropertyMoniker Name="Validation/UseSave" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="useAutoValidation">
            <DomainPropertyMoniker Name="Validation/UseAutoValidation" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainModelTreeViewReferencesRootNodes" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainModelTreeViewReferencesRootNodesMoniker" ElementName="domainModelTreeViewReferencesRootNodes" MonikerTypeName="DomainModelTreeViewReferencesRootNodesMoniker">
        <DomainRelationshipMoniker Name="DomainModelTreeViewReferencesRootNodes" />
      </XmlClassData>
      <XmlClassData TypeName="TreeNodeReferencesEmbeddingRSNodes" MonikerAttributeName="" SerializeId="true" MonikerElementName="treeNodeReferencesEmbeddingRSNodesMoniker" ElementName="treeNodeReferencesEmbeddingRSNodes" MonikerTypeName="TreeNodeReferencesEmbeddingRSNodesMoniker">
        <DomainRelationshipMoniker Name="TreeNodeReferencesEmbeddingRSNodes" />
      </XmlClassData>
      <XmlClassData TypeName="EmbeddingRSNodeReferencesEmbeddingNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="embeddingRSNodeReferencesEmbeddingNodeMoniker" ElementName="embeddingRSNodeReferencesEmbeddingNode" MonikerTypeName="EmbeddingRSNodeReferencesEmbeddingNodeMoniker">
        <DomainRelationshipMoniker Name="EmbeddingRSNodeReferencesEmbeddingNode" />
      </XmlClassData>
      <XmlClassData TypeName="TreeNodeReferencesInheritanceNodes" MonikerAttributeName="" SerializeId="true" MonikerElementName="treeNodeReferencesInheritanceNodesMoniker" ElementName="treeNodeReferencesInheritanceNodes" MonikerTypeName="TreeNodeReferencesInheritanceNodesMoniker">
        <DomainRelationshipMoniker Name="TreeNodeReferencesInheritanceNodes" />
      </XmlClassData>
      <XmlClassData TypeName="TreeNodeReferencesReferenceRSNodes" MonikerAttributeName="" SerializeId="true" MonikerElementName="treeNodeReferencesReferenceRSNodesMoniker" ElementName="treeNodeReferencesReferenceRSNodes" MonikerTypeName="TreeNodeReferencesReferenceRSNodesMoniker">
        <DomainRelationshipMoniker Name="TreeNodeReferencesReferenceRSNodes" />
      </XmlClassData>
      <XmlClassData TypeName="ReferenceRSNodeReferencesReferenceNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="referenceRSNodeReferencesReferenceNodeMoniker" ElementName="referenceRSNodeReferencesReferenceNode" MonikerTypeName="ReferenceRSNodeReferencesReferenceNodeMoniker">
        <DomainRelationshipMoniker Name="ReferenceRSNodeReferencesReferenceNode" />
      </XmlClassData>
      <XmlClassData TypeName="MappingRelationshipShapeClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="mappingRelationshipShapeClassMoniker" ElementName="mappingRelationshipShapeClass" MonikerTypeName="MappingRelationshipShapeClassMoniker">
        <DomainClassMoniker Name="MappingRelationshipShapeClass" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="source">
            <DomainRelationshipMoniker Name="MappingRelationshipShapeClassReferencesSource" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="target">
            <DomainRelationshipMoniker Name="MappingRelationshipShapeClassReferencesTarget" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="isAutoGenerated">
            <DomainPropertyMoniker Name="MappingRelationshipShapeClass/IsAutoGenerated" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="startAnchorStyle">
            <DomainPropertyMoniker Name="MappingRelationshipShapeClass/StartAnchorStyle" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="endAnchorStyle">
            <DomainPropertyMoniker Name="MappingRelationshipShapeClass/EndAnchorStyle" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="strokeThickness">
            <DomainPropertyMoniker Name="MappingRelationshipShapeClass/StrokeThickness" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="stroke">
            <DomainPropertyMoniker Name="MappingRelationshipShapeClass/Stroke" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="TreeNodeReferencesShapeClassNodes" MonikerAttributeName="" SerializeId="true" MonikerElementName="treeNodeReferencesShapeClassNodesMoniker" ElementName="treeNodeReferencesShapeClassNodes" MonikerTypeName="TreeNodeReferencesShapeClassNodesMoniker">
        <DomainRelationshipMoniker Name="TreeNodeReferencesShapeClassNodes" />
      </XmlClassData>
      <XmlClassData TypeName="DiagramView" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramViewMoniker" ElementName="diagramView" MonikerTypeName="DiagramViewMoniker">
        <DomainClassMoniker Name="DiagramView" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="diagramClassViews">
            <DomainRelationshipMoniker Name="DiagramViewHasDiagramClassViews" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DiagramViewHasDiagramClassViews" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramViewHasDiagramClassViewsMoniker" ElementName="diagramViewHasDiagramClassViews" MonikerTypeName="DiagramViewHasDiagramClassViewsMoniker">
        <DomainRelationshipMoniker Name="DiagramViewHasDiagramClassViews" />
      </XmlClassData>
      <XmlClassData TypeName="DesignerDiagramClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="designerDiagramClassMoniker" ElementName="designerDiagramClass" MonikerTypeName="DesignerDiagramClassMoniker">
        <DomainClassMoniker Name="DesignerDiagramClass" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="importedDiagramClasses">
            <DomainRelationshipMoniker Name="DesignerDiagramClassReferencesImportedDiagramClasses" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="includedDiagramClasses">
            <DomainRelationshipMoniker Name="DesignerDiagramClassReferencesIncludedDiagramClasses" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DiagramTreeNodeReferencesPresentationElementClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramTreeNodeReferencesPresentationElementClassMoniker" ElementName="diagramTreeNodeReferencesPresentationElementClass" MonikerTypeName="DiagramTreeNodeReferencesPresentationElementClassMoniker">
        <DomainRelationshipMoniker Name="DiagramTreeNodeReferencesPresentationElementClass" />
      </XmlClassData>
      <XmlClassData TypeName="EmbeddingDiagramNodeHasEmbeddingDiagramNodes" MonikerAttributeName="" SerializeId="true" MonikerElementName="embeddingDiagramNodeHasEmbeddingDiagramNodesMoniker" ElementName="embeddingDiagramNodeHasEmbeddingDiagramNodes" MonikerTypeName="EmbeddingDiagramNodeHasEmbeddingDiagramNodesMoniker">
        <DomainRelationshipMoniker Name="EmbeddingDiagramNodeHasEmbeddingDiagramNodes" />
      </XmlClassData>
      <XmlClassData TypeName="MappingRelationshipShapeClassReferencesSource" MonikerAttributeName="" SerializeId="true" MonikerElementName="mappingRelationshipShapeClassReferencesSourceMoniker" ElementName="mappingRelationshipShapeClassReferencesSource" MonikerTypeName="MappingRelationshipShapeClassReferencesSourceMoniker">
        <DomainRelationshipMoniker Name="MappingRelationshipShapeClassReferencesSource" />
      </XmlClassData>
      <XmlClassData TypeName="MappingRelationshipShapeClassReferencesTarget" MonikerAttributeName="" SerializeId="true" MonikerElementName="mappingRelationshipShapeClassReferencesTargetMoniker" ElementName="mappingRelationshipShapeClassReferencesTarget" MonikerTypeName="MappingRelationshipShapeClassReferencesTargetMoniker">
        <DomainRelationshipMoniker Name="MappingRelationshipShapeClassReferencesTarget" />
      </XmlClassData>
      <XmlClassData TypeName="PresentationDomainClassElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="presentationDomainClassElementMoniker" ElementName="presentationDomainClassElement" MonikerTypeName="PresentationDomainClassElementMoniker">
        <DomainClassMoniker Name="PresentationDomainClassElement" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainClass">
            <DomainRelationshipMoniker Name="ShapeClassReferencesDomainClass" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ShapeRelationshipNodeReferencesRelationshipShapeClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="shapeRelationshipNodeReferencesRelationshipShapeClassMoniker" ElementName="shapeRelationshipNodeReferencesRelationshipShapeClass" MonikerTypeName="ShapeRelationshipNodeReferencesRelationshipShapeClassMoniker">
        <DomainRelationshipMoniker Name="ShapeRelationshipNodeReferencesRelationshipShapeClass" />
      </XmlClassData>
      <XmlClassData TypeName="ModelTreeNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="modelTreeNodeMoniker" ElementName="modelTreeNode" MonikerTypeName="ModelTreeNodeMoniker">
        <DomainClassMoniker Name="ModelTreeNode" />
      </XmlClassData>
      <XmlClassData TypeName="DomainModelTreeViewHasModelTreeNodes" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainModelTreeViewHasModelTreeNodesMoniker" ElementName="domainModelTreeViewHasModelTreeNodes" MonikerTypeName="DomainModelTreeViewHasModelTreeNodesMoniker">
        <DomainRelationshipMoniker Name="DomainModelTreeViewHasModelTreeNodes" />
      </XmlClassData>
      <XmlClassData TypeName="ReferenceRSNodeReferencesShapeRelationshipNodes" MonikerAttributeName="" SerializeId="true" MonikerElementName="referenceRSNodeReferencesShapeRelationshipNodesMoniker" ElementName="referenceRSNodeReferencesShapeRelationshipNodes" MonikerTypeName="ReferenceRSNodeReferencesShapeRelationshipNodesMoniker">
        <DomainRelationshipMoniker Name="ReferenceRSNodeReferencesShapeRelationshipNodes" />
      </XmlClassData>
      <XmlClassData TypeName="ShapeClassReferencesDomainClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="shapeClassReferencesDomainClassMoniker" ElementName="shapeClassReferencesDomainClass" MonikerTypeName="ShapeClassReferencesDomainClassMoniker">
        <DomainRelationshipMoniker Name="ShapeClassReferencesDomainClass" />
      </XmlClassData>
      <XmlClassData TypeName="ShapeClassNodeReferencesShapeClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="shapeClassNodeReferencesShapeClassMoniker" ElementName="shapeClassNodeReferencesShapeClass" MonikerTypeName="ShapeClassNodeReferencesShapeClassMoniker">
        <DomainRelationshipMoniker Name="ShapeClassNodeReferencesShapeClass" />
      </XmlClassData>
      <XmlClassData TypeName="SerializationModelHasSerializedDomainModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializationModelHasSerializedDomainModelMoniker" ElementName="serializationModelHasSerializedDomainModel" MonikerTypeName="SerializationModelHasSerializedDomainModelMoniker">
        <DomainRelationshipMoniker Name="SerializationModelHasSerializedDomainModel" />
      </XmlClassData>
      <XmlClassData TypeName="SerializationClassHasIdProperty" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializationClassHasIdPropertyMoniker" ElementName="serializationClassHasIdProperty" MonikerTypeName="SerializationClassHasIdPropertyMoniker">
        <DomainRelationshipMoniker Name="SerializationClassHasIdProperty" />
      </XmlClassData>
      <XmlClassData TypeName="SerializedRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedRelationshipMoniker" ElementName="serializedRelationship" MonikerTypeName="SerializedRelationshipMoniker">
        <DomainClassMoniker Name="SerializedRelationship" />
        <ElementData>
          <XmlPropertyData XmlName="isInFullSerialization">
            <DomainPropertyMoniker Name="SerializedRelationship/IsInFullSerialization" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="omitRelationship">
            <DomainPropertyMoniker Name="SerializedRelationship/OmitRelationship" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="serializedDomainRoles">
            <DomainRelationshipMoniker Name="SerializedRelationshipHasSerializedDomainRoles" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SerializedRelationshipHasSerializedDomainRoles" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedRelationshipHasSerializedDomainRolesMoniker" ElementName="serializedRelationshipHasSerializedDomainRoles" MonikerTypeName="SerializedRelationshipHasSerializedDomainRolesMoniker">
        <DomainRelationshipMoniker Name="SerializedRelationshipHasSerializedDomainRoles" />
      </XmlClassData>
      <XmlClassData TypeName="SerializedDomainClassReferencesDomainClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedDomainClassReferencesDomainClassMoniker" ElementName="serializedDomainClassReferencesDomainClass" MonikerTypeName="SerializedDomainClassReferencesDomainClassMoniker">
        <DomainRelationshipMoniker Name="SerializedDomainClassReferencesDomainClass" />
      </XmlClassData>
      <XmlClassData TypeName="SerializedEmbeddingRelationshipReferencesEmbeddingRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedEmbeddingRelationshipReferencesEmbeddingRelationshipMoniker" ElementName="serializedEmbeddingRelationshipReferencesEmbeddingRelationship" MonikerTypeName="SerializedEmbeddingRelationshipReferencesEmbeddingRelationshipMoniker">
        <DomainRelationshipMoniker Name="SerializedEmbeddingRelationshipReferencesEmbeddingRelationship" />
      </XmlClassData>
      <XmlClassData TypeName="SerializedReferenceRelationshipReferencesReferenceRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedReferenceRelationshipReferencesReferenceRelationshipMoniker" ElementName="serializedReferenceRelationshipReferencesReferenceRelationship" MonikerTypeName="SerializedReferenceRelationshipReferencesReferenceRelationshipMoniker">
        <DomainRelationshipMoniker Name="SerializedReferenceRelationshipReferencesReferenceRelationship" />
      </XmlClassData>
      <XmlClassData TypeName="SerializedDomainPropertyReferencesDomainProperty" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedDomainPropertyReferencesDomainPropertyMoniker" ElementName="serializedDomainPropertyReferencesDomainProperty" MonikerTypeName="SerializedDomainPropertyReferencesDomainPropertyMoniker">
        <DomainRelationshipMoniker Name="SerializedDomainPropertyReferencesDomainProperty" />
      </XmlClassData>
      <XmlClassData TypeName="SerializedDomainRoleReferencesSerializationClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializedDomainRoleReferencesSerializationClassMoniker" ElementName="serializedDomainRoleReferencesSerializationClass" MonikerTypeName="SerializedDomainRoleReferencesSerializationClassMoniker">
        <DomainRelationshipMoniker Name="SerializedDomainRoleReferencesSerializationClass" />
      </XmlClassData>
      <XmlClassData TypeName="SerializationModelHasChildren" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializationModelHasChildrenMoniker" ElementName="serializationModelHasChildren" MonikerTypeName="SerializationModelHasChildrenMoniker">
        <DomainRelationshipMoniker Name="SerializationModelHasChildren" />
      </XmlClassData>
      <XmlClassData TypeName="SerializationClassHasProperties" MonikerAttributeName="" SerializeId="true" MonikerElementName="serializationClassHasPropertiesMoniker" ElementName="serializationClassHasProperties" MonikerTypeName="SerializationClassHasPropertiesMoniker">
        <DomainRelationshipMoniker Name="SerializationClassHasProperties" />
      </XmlClassData>
      <XmlClassData TypeName="Credits" MonikerAttributeName="" SerializeId="true" MonikerElementName="creditsMoniker" ElementName="credits" MonikerTypeName="CreditsMoniker">
        <DomainClassMoniker Name="Credits" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="creditItems">
            <DomainRelationshipMoniker Name="CreditsHasCreditItems" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="CreditsHasCreditItems" MonikerAttributeName="" SerializeId="true" MonikerElementName="creditsHasCreditItemsMoniker" ElementName="creditsHasCreditItems" MonikerTypeName="CreditsHasCreditItemsMoniker">
        <DomainRelationshipMoniker Name="CreditsHasCreditItems" />
      </XmlClassData>
      <XmlClassData TypeName="CreditItem" MonikerAttributeName="" SerializeId="true" MonikerElementName="creditItemMoniker" ElementName="creditItem" MonikerTypeName="CreditItemMoniker">
        <DomainClassMoniker Name="CreditItem" />
      </XmlClassData>
      <XmlClassData TypeName="MetaModelHasAdditionalInformation" MonikerAttributeName="" SerializeId="true" MonikerElementName="metaModelHasAdditionalInformationMoniker" ElementName="metaModelHasAdditionalInformation" MonikerTypeName="MetaModelHasAdditionalInformationMoniker">
        <DomainRelationshipMoniker Name="MetaModelHasAdditionalInformation" />
      </XmlClassData>
      <XmlClassData TypeName="AdditionalInformation" MonikerAttributeName="" SerializeId="true" MonikerElementName="additionalInformationMoniker" ElementName="additionalInformation" MonikerTypeName="AdditionalInformationMoniker">
        <DomainClassMoniker Name="AdditionalInformation" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="credits">
            <DomainRelationshipMoniker Name="AdditionalInformationHasCredits" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="furtherInformation">
            <DomainRelationshipMoniker Name="AdditionalInformationHasFurtherInformation" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="AdditionalInformationHasCredits" MonikerAttributeName="" SerializeId="true" MonikerElementName="additionalInformationHasCreditsMoniker" ElementName="additionalInformationHasCredits" MonikerTypeName="AdditionalInformationHasCreditsMoniker">
        <DomainRelationshipMoniker Name="AdditionalInformationHasCredits" />
      </XmlClassData>
      <XmlClassData TypeName="AdditionalInformationHasFurtherInformation" MonikerAttributeName="" SerializeId="true" MonikerElementName="additionalInformationHasFurtherInformationMoniker" ElementName="additionalInformationHasFurtherInformation" MonikerTypeName="AdditionalInformationHasFurtherInformationMoniker">
        <DomainRelationshipMoniker Name="AdditionalInformationHasFurtherInformation" />
      </XmlClassData>
      <XmlClassData TypeName="FurtherInformation" MonikerAttributeName="" SerializeId="true" MonikerElementName="furtherInformationMoniker" ElementName="furtherInformation" MonikerTypeName="FurtherInformationMoniker">
        <DomainClassMoniker Name="FurtherInformation" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="informationItems">
            <DomainRelationshipMoniker Name="FurtherInformationHasInformationItems" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="FurtherInformationHasInformationItems" MonikerAttributeName="" SerializeId="true" MonikerElementName="furtherInformationHasInformationItemsMoniker" ElementName="furtherInformationHasInformationItems" MonikerTypeName="FurtherInformationHasInformationItemsMoniker">
        <DomainRelationshipMoniker Name="FurtherInformationHasInformationItems" />
      </XmlClassData>
      <XmlClassData TypeName="InformationItem" MonikerAttributeName="" SerializeId="true" MonikerElementName="informationItemMoniker" ElementName="informationItem" MonikerTypeName="InformationItemMoniker">
        <DomainClassMoniker Name="InformationItem" />
      </XmlClassData>
      <XmlClassData TypeName="LinkItem" MonikerAttributeName="" SerializeId="true" MonikerElementName="linkItemMoniker" ElementName="linkItem" MonikerTypeName="LinkItemMoniker">
        <DomainClassMoniker Name="LinkItem" />
        <ElementData>
          <XmlPropertyData XmlName="title">
            <DomainPropertyMoniker Name="LinkItem/Title" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="LinkItem/Description" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="link">
            <DomainPropertyMoniker Name="LinkItem/Link" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="category">
            <DomainPropertyMoniker Name="LinkItem/Category" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="MetaModelHasMetaModelLibraries" MonikerAttributeName="" SerializeId="true" MonikerElementName="metaModelHasMetaModelLibrariesMoniker" ElementName="metaModelHasMetaModelLibraries" MonikerTypeName="MetaModelHasMetaModelLibrariesMoniker">
        <DomainRelationshipMoniker Name="MetaModelHasMetaModelLibraries" />
      </XmlClassData>
      <XmlClassData TypeName="MetaModelLibrary" MonikerAttributeName="" SerializeId="true" MonikerElementName="metaModelLibraryMoniker" ElementName="metaModelLibrary" MonikerTypeName="MetaModelLibraryMoniker">
        <DomainClassMoniker Name="MetaModelLibrary" />
        <ElementData>
          <XmlPropertyData XmlName="filePath" Representation="Element">
            <DomainPropertyMoniker Name="MetaModelLibrary/FilePath" />
          </XmlPropertyData>
          <XmlRelationshipData OmitElement="true" UseFullForm="true" RoleElementName="importedLibrary">
            <DomainRelationshipMoniker Name="MetaModelLibraryHasImportedLibrary" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="name" Representation="Element">
            <DomainPropertyMoniker Name="MetaModelLibrary/Name" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="BaseMetaModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="baseMetaModelMoniker" ElementName="baseMetaModel" MonikerTypeName="BaseMetaModelMoniker">
        <DomainClassMoniker Name="BaseMetaModel" />
      </XmlClassData>
      <XmlClassData TypeName="MetaModelLibraryHasImportedLibrary" MonikerAttributeName="" SerializeId="true" MonikerElementName="metaModelLibraryHasImportedLibraryMoniker" ElementName="metaModelLibraryHasImportedLibrary" MonikerTypeName="MetaModelLibraryHasImportedLibraryMoniker">
        <DomainRelationshipMoniker Name="MetaModelLibraryHasImportedLibrary" />
      </XmlClassData>
      <XmlClassData TypeName="ViewContext" MonikerAttributeName="" SerializeId="true" MonikerElementName="viewContextMoniker" ElementName="viewContext" MonikerTypeName="ViewContextMoniker">
        <DomainClassMoniker Name="ViewContext" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainModelTreeView">
            <DomainRelationshipMoniker Name="ViewContextHasDomainModelTreeView" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="diagramView">
            <DomainRelationshipMoniker Name="ViewContextHasDiagramView" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="modelContext">
            <DomainRelationshipMoniker Name="ViewContextReferencesModelContext" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ViewContextHasDomainModelTreeView" MonikerAttributeName="" SerializeId="true" MonikerElementName="viewContextHasDomainModelTreeViewMoniker" ElementName="viewContextHasDomainModelTreeView" MonikerTypeName="ViewContextHasDomainModelTreeViewMoniker">
        <DomainRelationshipMoniker Name="ViewContextHasDomainModelTreeView" />
      </XmlClassData>
      <XmlClassData TypeName="ViewContextHasDiagramView" MonikerAttributeName="" SerializeId="true" MonikerElementName="viewContextHasDiagramViewMoniker" ElementName="viewContextHasDiagramView" MonikerTypeName="ViewContextHasDiagramViewMoniker">
        <DomainRelationshipMoniker Name="ViewContextHasDiagramView" />
      </XmlClassData>
      <XmlClassData TypeName="LibraryModelContext" MonikerAttributeName="" SerializeId="true" MonikerElementName="libraryModelContextMoniker" ElementName="libraryModelContext" MonikerTypeName="LibraryModelContextMoniker">
        <DomainClassMoniker Name="LibraryModelContext" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="classes">
            <DomainRelationshipMoniker Name="LibraryModelContextHasClasses" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="diagramClasses">
            <DomainRelationshipMoniker Name="LibraryModelContextHasDiagramClasses" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="relationships">
            <DomainRelationshipMoniker Name="LibraryModelContextHasRelationships" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="serializationModel">
            <DomainRelationshipMoniker Name="LibraryModelContextHasSerializationModel" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="LibraryModelContextHasClasses" MonikerAttributeName="" SerializeId="true" MonikerElementName="libraryModelContextHasClassesMoniker" ElementName="libraryModelContextHasClasses" MonikerTypeName="LibraryModelContextHasClassesMoniker">
        <DomainRelationshipMoniker Name="LibraryModelContextHasClasses" />
      </XmlClassData>
      <XmlClassData TypeName="LibraryModelContextHasDiagramClasses" MonikerAttributeName="" SerializeId="true" MonikerElementName="libraryModelContextHasDiagramClassesMoniker" ElementName="libraryModelContextHasDiagramClasses" MonikerTypeName="LibraryModelContextHasDiagramClassesMoniker">
        <DomainRelationshipMoniker Name="LibraryModelContextHasDiagramClasses" />
      </XmlClassData>
      <XmlClassData TypeName="LibraryModelContextHasRelationships" MonikerAttributeName="" SerializeId="true" MonikerElementName="libraryModelContextHasRelationshipsMoniker" ElementName="libraryModelContextHasRelationships" MonikerTypeName="LibraryModelContextHasRelationshipsMoniker">
        <DomainRelationshipMoniker Name="LibraryModelContextHasRelationships" />
      </XmlClassData>
      <XmlClassData TypeName="ViewContextReferencesModelContext" MonikerAttributeName="" SerializeId="true" MonikerElementName="viewContextReferencesModelContextMoniker" ElementName="viewContextReferencesModelContext" MonikerTypeName="ViewContextReferencesModelContextMoniker">
        <DomainRelationshipMoniker Name="ViewContextReferencesModelContext" />
      </XmlClassData>
      <XmlClassData TypeName="MetaModelHasView" MonikerAttributeName="" SerializeId="true" MonikerElementName="metaModelHasViewMoniker" ElementName="metaModelHasView" MonikerTypeName="MetaModelHasViewMoniker">
        <DomainRelationshipMoniker Name="MetaModelHasView" />
      </XmlClassData>
      <XmlClassData TypeName="View" MonikerAttributeName="" SerializeId="true" MonikerElementName="viewMoniker" ElementName="view" MonikerTypeName="ViewMoniker">
        <DomainClassMoniker Name="View" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="viewContexts">
            <DomainRelationshipMoniker Name="ViewHasViewContexts" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="modelTree">
            <DomainRelationshipMoniker Name="ViewHasModelTree" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="createModelTree">
            <DomainPropertyMoniker Name="View/CreateModelTree" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="createPropertyGrid">
            <DomainPropertyMoniker Name="View/CreatePropertyGrid" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="createErrorList">
            <DomainPropertyMoniker Name="View/CreateErrorList" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="createDependenciesView">
            <DomainPropertyMoniker Name="View/CreateDependenciesView" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="modelTreeId">
            <DomainPropertyMoniker Name="View/ModelTreeId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="propertyGridId">
            <DomainPropertyMoniker Name="View/PropertyGridId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="errorListId">
            <DomainPropertyMoniker Name="View/ErrorListId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="dependenciesViewId">
            <DomainPropertyMoniker Name="View/DependenciesViewId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="searchId">
            <DomainPropertyMoniker Name="View/SearchId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="searchResultId">
            <DomainPropertyMoniker Name="View/SearchResultId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="pluginWindowId">
            <DomainPropertyMoniker Name="View/PluginWindowId" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="PropertyGridEditor" MonikerAttributeName="name" MonikerElementName="propertyGridEditorMoniker" ElementName="propertyGridEditor" MonikerTypeName="PropertyGridEditorMoniker">
        <DomainClassMoniker Name="PropertyGridEditor" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="PropertyGridEditor/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="namespace">
            <DomainPropertyMoniker Name="PropertyGridEditor/Namespace" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="shouldBeGenerated">
            <DomainPropertyMoniker Name="PropertyGridEditor/ShouldBeGenerated" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="editorBaseType">
            <DomainPropertyMoniker Name="PropertyGridEditor/EditorBaseType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="requiresContextMenuBar">
            <DomainPropertyMoniker Name="PropertyGridEditor/RequiresContextMenuBar" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainTypeReferencesPropertyGridEditor" MonikerAttributeName="" MonikerElementName="domainTypeReferencesPropertyGridEditorMoniker" ElementName="domainTypeReferencesPropertyGridEditor" MonikerTypeName="DomainTypeReferencesPropertyGridEditorMoniker">
        <DomainRelationshipMoniker Name="DomainTypeReferencesPropertyGridEditor" />
      </XmlClassData>
      <XmlClassData TypeName="DomainRoleReferencesCustomPropertyGridEditor" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainRoleReferencesCustomPropertyGridEditorMoniker" ElementName="domainRoleReferencesCustomPropertyGridEditor" MonikerTypeName="DomainRoleReferencesCustomPropertyGridEditorMoniker">
        <DomainRelationshipMoniker Name="DomainRoleReferencesCustomPropertyGridEditor" />
      </XmlClassData>
      <XmlClassData TypeName="MetaModelHasModelContexts" MonikerAttributeName="" SerializeId="true" MonikerElementName="metaModelHasModelContextsMoniker" ElementName="metaModelHasModelContexts" MonikerTypeName="MetaModelHasModelContextsMoniker">
        <DomainRelationshipMoniker Name="MetaModelHasModelContexts" />
      </XmlClassData>
      <XmlClassData TypeName="BaseModelContext" MonikerAttributeName="" SerializeId="true" MonikerElementName="baseModelContextMoniker" ElementName="baseModelContext" MonikerTypeName="BaseModelContextMoniker">
        <DomainClassMoniker Name="BaseModelContext" />
        <ElementData>
          <XmlPropertyData XmlName="isDefault">
            <DomainPropertyMoniker Name="BaseModelContext/IsDefault" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ExternModelContext" MonikerAttributeName="" SerializeId="true" MonikerElementName="externModelContextMoniker" ElementName="externModelContext" MonikerTypeName="ExternModelContextMoniker">
        <DomainClassMoniker Name="ExternModelContext" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="modelContext">
            <DomainRelationshipMoniker Name="ExternModelContextReferencesModelContext" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="BaseViewContext" MonikerAttributeName="" SerializeId="true" MonikerElementName="baseViewContextMoniker" ElementName="baseViewContext" MonikerTypeName="BaseViewContextMoniker">
        <DomainClassMoniker Name="BaseViewContext" />
      </XmlClassData>
      <XmlClassData TypeName="ExternViewContext" MonikerAttributeName="" SerializeId="true" MonikerElementName="externViewContextMoniker" ElementName="externViewContext" MonikerTypeName="ExternViewContextMoniker">
        <DomainClassMoniker Name="ExternViewContext" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="externModelContext">
            <DomainRelationshipMoniker Name="ExternViewContextReferencesExternModelContext" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ViewHasViewContexts" MonikerAttributeName="" SerializeId="true" MonikerElementName="viewHasViewContextsMoniker" ElementName="viewHasViewContexts" MonikerTypeName="ViewHasViewContextsMoniker">
        <DomainRelationshipMoniker Name="ViewHasViewContexts" />
      </XmlClassData>
      <XmlClassData TypeName="ExternViewContextReferencesExternModelContext" MonikerAttributeName="" SerializeId="true" MonikerElementName="externViewContextReferencesExternModelContextMoniker" ElementName="externViewContextReferencesExternModelContext" MonikerTypeName="ExternViewContextReferencesExternModelContextMoniker">
        <DomainRelationshipMoniker Name="ExternViewContextReferencesExternModelContext" />
      </XmlClassData>
      <XmlClassData TypeName="ModelContext" MonikerAttributeName="" SerializeId="true" MonikerElementName="modelContextMoniker" ElementName="modelContext" MonikerTypeName="ModelContextMoniker">
        <DomainClassMoniker Name="ModelContext" />
      </XmlClassData>
      <XmlClassData TypeName="LibraryModelContextHasSerializationModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="libraryModelContextHasSerializationModelMoniker" ElementName="libraryModelContextHasSerializationModel" MonikerTypeName="LibraryModelContextHasSerializationModelMoniker">
        <DomainRelationshipMoniker Name="LibraryModelContextHasSerializationModel" />
      </XmlClassData>
      <XmlClassData TypeName="MetaModelHasPropertyGridEditors" MonikerAttributeName="" MonikerElementName="metaModelHasPropertyGridEditorsMoniker" ElementName="metaModelHasPropertyGridEditors" MonikerTypeName="MetaModelHasPropertyGridEditorsMoniker">
        <DomainRelationshipMoniker Name="MetaModelHasPropertyGridEditors" />
      </XmlClassData>
      <XmlClassData TypeName="ViewHasModelTree" MonikerAttributeName="" SerializeId="true" MonikerElementName="viewHasModelTreeMoniker" ElementName="viewHasModelTree" MonikerTypeName="ViewHasModelTreeMoniker">
        <DomainRelationshipMoniker Name="ViewHasModelTree" />
      </XmlClassData>
      <XmlClassData TypeName="ModelTree" MonikerAttributeName="" SerializeId="true" MonikerElementName="modelTreeMoniker" ElementName="modelTree" MonikerTypeName="ModelTreeMoniker">
        <DomainClassMoniker Name="ModelTree" />
        <ElementData>
          <XmlPropertyData XmlName="sortingBehavior">
            <DomainPropertyMoniker Name="ModelTree/SortingBehavior" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="canMoveElements">
            <DomainPropertyMoniker Name="ModelTree/CanMoveElements" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ExternModelContextReferencesModelContext" MonikerAttributeName="" SerializeId="true" MonikerElementName="externModelContextReferencesModelContextMoniker" ElementName="externModelContextReferencesModelContext" MonikerTypeName="ExternModelContextReferencesModelContextMoniker">
        <DomainRelationshipMoniker Name="ExternModelContextReferencesModelContext" />
      </XmlClassData>
      <XmlClassData TypeName="DesignerDiagramClassReferencesImportedDiagramClasses" MonikerAttributeName="" SerializeId="true" MonikerElementName="designerDiagramClassReferencesImportedDiagramClassesMoniker" ElementName="designerDiagramClassReferencesImportedDiagramClasses" MonikerTypeName="DesignerDiagramClassReferencesImportedDiagramClassesMoniker">
        <DomainRelationshipMoniker Name="DesignerDiagramClassReferencesImportedDiagramClasses" />
      </XmlClassData>
      <XmlClassData TypeName="ShapeClassReferencesBaseShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="shapeClassReferencesBaseShapeMoniker" ElementName="shapeClassReferencesBaseShape" MonikerTypeName="ShapeClassReferencesBaseShapeMoniker">
        <DomainRelationshipMoniker Name="ShapeClassReferencesBaseShape" />
      </XmlClassData>
      <XmlClassData TypeName="DesignerDiagramClassReferencesIncludedDiagramClasses" MonikerAttributeName="" SerializeId="true" MonikerElementName="designerDiagramClassReferencesIncludedDiagramClassesMoniker" ElementName="designerDiagramClassReferencesIncludedDiagramClasses" MonikerTypeName="DesignerDiagramClassReferencesIncludedDiagramClassesMoniker">
        <DomainRelationshipMoniker Name="DesignerDiagramClassReferencesIncludedDiagramClasses" />
      </XmlClassData>
      <XmlClassData TypeName="TemplatedDiagramClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="templatedDiagramClassMoniker" ElementName="templatedDiagramClass" MonikerTypeName="TemplatedDiagramClassMoniker">
        <DomainClassMoniker Name="TemplatedDiagramClass" />
        <ElementData>
          <XmlPropertyData XmlName="uniqueId">
            <DomainPropertyMoniker Name="TemplatedDiagramClass/UniqueId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="TemplatedDiagramClass/Description" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DependencyDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="dependencyDiagramMoniker" ElementName="dependencyDiagram" MonikerTypeName="DependencyDiagramMoniker">
        <DomainClassMoniker Name="DependencyDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="SpecificDependencyDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="specificDependencyDiagramMoniker" ElementName="specificDependencyDiagram" MonikerTypeName="SpecificDependencyDiagramMoniker">
        <DomainClassMoniker Name="SpecificDependencyDiagram" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainClass">
            <DomainRelationshipMoniker Name="SpecificDependencyDiagramReferencesDomainClass" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SpecificDependencyDiagramReferencesDomainClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="specificDependencyDiagramReferencesDomainClassMoniker" ElementName="specificDependencyDiagramReferencesDomainClass" MonikerTypeName="SpecificDependencyDiagramReferencesDomainClassMoniker">
        <DomainRelationshipMoniker Name="SpecificDependencyDiagramReferencesDomainClass" />
      </XmlClassData>
      <XmlClassData TypeName="ModalDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="modalDiagramMoniker" ElementName="modalDiagram" MonikerTypeName="ModalDiagramMoniker">
        <DomainClassMoniker Name="ModalDiagram" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainClass">
            <DomainRelationshipMoniker Name="ModalDiagramReferencesDomainClass" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ModalDiagramReferencesDomainClass" MonikerAttributeName="" SerializeId="true" MonikerElementName="modalDiagramReferencesDomainClassMoniker" ElementName="modalDiagramReferencesDomainClass" MonikerTypeName="ModalDiagramReferencesDomainClassMoniker">
        <DomainRelationshipMoniker Name="ModalDiagramReferencesDomainClass" />
      </XmlClassData>
      <XmlClassData TypeName="SpecificElementsDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="specificElementsDiagramMoniker" ElementName="specificElementsDiagram" MonikerTypeName="SpecificElementsDiagramMoniker">
        <DomainClassMoniker Name="SpecificElementsDiagram" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainClasses">
            <DomainRelationshipMoniker Name="SpecificElementsDiagramReferencesDomainClasses" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DesignerSurfaceDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="designerSurfaceDiagramMoniker" ElementName="designerSurfaceDiagram" MonikerTypeName="DesignerSurfaceDiagramMoniker">
        <DomainClassMoniker Name="DesignerSurfaceDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="SpecificElementsDiagramReferencesDomainClasses" MonikerAttributeName="" SerializeId="true" MonikerElementName="specificElementsDiagramReferencesDomainClassesMoniker" ElementName="specificElementsDiagramReferencesDomainClasses" MonikerTypeName="SpecificElementsDiagramReferencesDomainClassesMoniker">
        <DomainRelationshipMoniker Name="SpecificElementsDiagramReferencesDomainClasses" />
      </XmlClassData>
      <XmlClassData TypeName="ChildlessDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="childlessDiagramMoniker" ElementName="childlessDiagram" MonikerTypeName="ChildlessDiagramMoniker">
        <DomainClassMoniker Name="ChildlessDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="TemplatedDiagramViewModelOnly" MonikerAttributeName="" SerializeId="true" MonikerElementName="templatedDiagramViewModelOnlyMoniker" ElementName="templatedDiagramViewModelOnly" MonikerTypeName="TemplatedDiagramViewModelOnlyMoniker">
        <DomainClassMoniker Name="TemplatedDiagramViewModelOnly" />
      </XmlClassData>
      <XmlClassData TypeName="RestorableChildlessDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="restorableChildlessDiagramMoniker" ElementName="restorableChildlessDiagram" MonikerTypeName="RestorableChildlessDiagramMoniker">
        <DomainClassMoniker Name="RestorableChildlessDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="RestorableTemplatedDiagramVMOnly" MonikerAttributeName="" SerializeId="true" MonikerElementName="restorableTemplatedDiagramVMOnlyMoniker" ElementName="restorableTemplatedDiagramVMOnly" MonikerTypeName="RestorableTemplatedDiagramVMOnlyMoniker">
        <DomainClassMoniker Name="RestorableTemplatedDiagramVMOnly" />
      </XmlClassData>
      <XmlClassData TypeName="RelationshipShapeClassReferencesReferenceRelationship" MonikerAttributeName="" SerializeId="true" MonikerElementName="relationshipShapeClassReferencesReferenceRelationshipMoniker" ElementName="relationshipShapeClassReferencesReferenceRelationship" MonikerTypeName="RelationshipShapeClassReferencesReferenceRelationshipMoniker">
        <DomainRelationshipMoniker Name="RelationshipShapeClassReferencesReferenceRelationship" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="LanguageDSLExplorerBehavior">
    <HiddenNodes>
      <DomainPath>SerializationModelHasSerializedDomainModel.SerializedDomainModel</DomainPath>
      <DomainPath>SerializationModelHasChildren.Children</DomainPath>
      <DomainPath>ViewHasViewContexts.ViewContexts</DomainPath>
    </HiddenNodes>
  </ExplorerBehavior>
  <ConnectionBuilders>
    <ConnectionBuilder Name="DomainRelationshipReferencesSourceBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainRelationshipReferencesSource" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRole" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DomainRelationshipReferencesTargetBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainRelationshipReferencesTarget" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRole" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ReferenceRSNodeReferencesReferenceRelationshipBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ReferenceRSNodeReferencesReferenceRelationship" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ReferenceRSNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ReferenceRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DomainPropertyReferencesTypeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainPropertyReferencesType" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainProperty" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainType" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DiagramClassViewReferencesDiagramClassBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DiagramClassViewReferencesDiagramClass" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DiagramClassView" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DiagramClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DomainClassReferencesBaseClassBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainClassReferencesBaseClass" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DomainRelationshipReferencesBaseRelationshipBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainRelationshipReferencesBaseRelationship" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DomainRoleReferencesOppositeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainRoleReferencesOpposite" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRole" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRole" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="EmbeddingRSNodeReferencesRelationshipBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="EmbeddingRSNodeReferencesRelationship" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="EmbeddingRSNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DomainRoleReferencesRolePlayerBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainRoleReferencesRolePlayer" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRole" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="AttributedDomainElement" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="TreeNodeReferencesDomainElementBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="TreeNodeReferencesDomainElement" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="TreeNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="AttributedDomainElement" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ShapeClassReferencesChildrenBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ShapeClassReferencesChildren" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ShapeClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ShapeClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SerializationClassReferencesChildrenBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SerializationClassReferencesChildren" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializationClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializationElement" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SerializedDomainRoleReferencesDomainRoleBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SerializedDomainRoleReferencesDomainRole" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializedDomainRole" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRole" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SerializationClassReferencesAttributesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SerializationClassReferencesAttributes" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializationClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializationAttributeElement" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DomainModelTreeViewReferencesRootNodesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainModelTreeViewReferencesRootNodes" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainModelTreeView" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="RootNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="TreeNodeReferencesEmbeddingRSNodesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="TreeNodeReferencesEmbeddingRSNodes" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="TreeNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="EmbeddingRSNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="EmbeddingRSNodeReferencesEmbeddingNodeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="EmbeddingRSNodeReferencesEmbeddingNode" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="EmbeddingRSNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="EmbeddingNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="TreeNodeReferencesInheritanceNodesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="TreeNodeReferencesInheritanceNodes" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="TreeNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="InheritanceNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="TreeNodeReferencesReferenceRSNodesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="TreeNodeReferencesReferenceRSNodes" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="TreeNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ReferenceRSNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ReferenceRSNodeReferencesReferenceNodeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ReferenceRSNodeReferencesReferenceNode" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ReferenceRSNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ReferenceNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="TreeNodeReferencesShapeClassNodesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="TreeNodeReferencesShapeClassNodes" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="TreeNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ShapeClassNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DiagramTreeNodeReferencesPresentationElementClassBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DiagramTreeNodeReferencesPresentationElementClass" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DiagramTreeNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="PresentationElementClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="MappingRelationshipShapeClassReferencesSourceBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="MappingRelationshipShapeClassReferencesSource" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="MappingRelationshipShapeClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ReferenceRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="MappingRelationshipShapeClassReferencesTargetBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="MappingRelationshipShapeClassReferencesTarget" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="MappingRelationshipShapeClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ReferenceRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ShapeRelationshipNodeReferencesRelationshipShapeClassBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ShapeRelationshipNodeReferencesRelationshipShapeClass" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ShapeRelationshipNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="RelationshipShapeClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ReferenceRSNodeReferencesShapeRelationshipNodesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ReferenceRSNodeReferencesShapeRelationshipNodes" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ReferenceRSNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ShapeRelationshipNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ShapeClassReferencesDomainClassBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ShapeClassReferencesDomainClass" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="PresentationDomainClassElement" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ShapeClassNodeReferencesShapeClassBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ShapeClassNodeReferencesShapeClass" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ShapeClassNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="PresentationDomainClassElement" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SerializedDomainClassReferencesDomainClassBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SerializedDomainClassReferencesDomainClass" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializedDomainClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SerializedEmbeddingRelationshipReferencesEmbeddingRelationshipBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SerializedEmbeddingRelationshipReferencesEmbeddingRelationship" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializedEmbeddingRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="EmbeddingRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SerializedReferenceRelationshipReferencesReferenceRelationshipBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SerializedReferenceRelationshipReferencesReferenceRelationship" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializedReferenceRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ReferenceRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SerializedDomainPropertyReferencesDomainPropertyBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SerializedDomainPropertyReferencesDomainProperty" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializedDomainProperty" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainProperty" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SerializedDomainRoleReferencesSerializationClassBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SerializedDomainRoleReferencesSerializationClass" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializedDomainRole" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SerializationClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ViewContextReferencesModelContextBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ViewContextReferencesModelContext" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ViewContext" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="LibraryModelContext" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DomainTypeReferencesPropertyGridEditorBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainTypeReferencesPropertyGridEditor" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainType" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="PropertyGridEditor" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DomainRoleReferencesCustomPropertyGridEditorBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainRoleReferencesCustomPropertyGridEditor" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRole" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="PropertyGridEditor" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ExternViewContextReferencesExternModelContextBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ExternViewContextReferencesExternModelContext" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ExternViewContext" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ExternModelContext" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ExternModelContextReferencesModelContextBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ExternModelContextReferencesModelContext" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ExternModelContext" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelContext" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DesignerDiagramClassReferencesImportedDiagramClassesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DesignerDiagramClassReferencesImportedDiagramClasses" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DesignerDiagramClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DiagramClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ShapeClassReferencesBaseShapeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ShapeClassReferencesBaseShape" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ShapeClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ShapeClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DesignerDiagramClassReferencesIncludedDiagramClassesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DesignerDiagramClassReferencesIncludedDiagramClasses" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DesignerDiagramClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DiagramClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SpecificDependencyDiagramReferencesDomainClassBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SpecificDependencyDiagramReferencesDomainClass" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SpecificDependencyDiagram" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="ModalDiagramReferencesDomainClassBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="ModalDiagramReferencesDomainClass" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModalDiagram" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SpecificElementsDiagramReferencesDomainClassesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SpecificElementsDiagramReferencesDomainClasses" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SpecificElementsDiagram" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="RelationshipShapeClassReferencesReferenceRelationshipBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="RelationshipShapeClassReferencesReferenceRelationship" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="RelationshipShapeClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainRelationship" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <CustomEditor FileExtension="lngdsl" EditorGuid="336d3936-2ad2-4f00-8605-8a8d405126e7">
    <RootClass>
      <DomainClassMoniker Name="MetaModel" />
    </RootClass>
    <XmlSerializationDefinition WriteOptionalPropertiesWithDefaultValue="true" CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="TestDslDefinitionSerializationBehavior" />
    </XmlSerializationDefinition>
    <Validation UsesMenu="true" UsesOpen="true" UsesSave="true" UsesLoad="false" />
  </CustomEditor>
  <Explorer ExplorerGuid="38024509-4a13-4aef-90fd-3bdce8fb6d31" Title="Process Development Environment Language Explorer">
    <ExplorerBehaviorMoniker Name="LanguageDSL/LanguageDSLExplorerBehavior" />
  </Explorer>
</Dsl>
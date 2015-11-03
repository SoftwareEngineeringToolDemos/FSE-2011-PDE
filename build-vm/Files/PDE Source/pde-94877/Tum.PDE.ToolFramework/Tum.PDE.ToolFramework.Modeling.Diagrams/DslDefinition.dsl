<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="41ca7a90-0d23-4e0c-b4c4-60e7c76d2c60" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramsDSL" Name="DiagramsDSL" DisplayName="DiagramsDSL" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" ProductName="DiagramsDSL" CompanyName="Tum" PackageGuid="fe6e1bc0-514c-48c3-a77e-8c80837643b3" PackageNamespace="Tum.PDE.ToolFramework.Modeling.Diagrams" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="65f6d301-e0b5-434e-a9cb-29e43eb66be7" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramsModel" Name="DiagramsModel" DisplayName="Diagrams Model" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" HasCustomConstructor="true">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Diagram" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DiagramsModelHasDiagrams.Diagrams</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="LayoutInfo" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DiagramsModelHasLayoutInfos.LayoutInfos</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="8cfc7fb9-03d2-4dde-b2c6-3d49c13cd9bb" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShape" Name="NodeShape" DisplayName="Node Shape" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" HasCustomConstructor="true" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="ShapeElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="0c94b389-55f1-4bd6-ab67-2a307d7a56ad" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShape.Resizing Behaviour" Name="ResizingBehaviour" DisplayName="Resizing Behaviour" DefaultValue="Normal" Kind="Calculated" Category="Behaviour">
          <Type>
            <DomainEnumerationMoniker Name="ShapeResizingBehaviour" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="dac91424-5ef2-4356-9ad1-5d64ecfd375a" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShape.Movement Behaviour" Name="MovementBehaviour" DisplayName="Movement Behaviour" DefaultValue="Normal" Kind="Calculated" Category="Behaviour">
          <Type>
            <DomainEnumerationMoniker Name="ShapeMovementBehaviour" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="521f8ebb-174e-401c-a1da-c9fb1762df1b" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShape.Is Relative Child Shape" Name="IsRelativeChildShape" DisplayName="Is Relative Child Shape" DefaultValue="false" Kind="Calculated" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="76ef146c-5948-44c0-bbfe-0d360fd0e367" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShape.Takes Part In Relationship" Name="TakesPartInRelationship" DisplayName="Takes Part In Relationship" DefaultValue="false" Kind="Calculated" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b04df7b8-1fcb-4d96-bf42-cb64239ff252" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShape.Location" Name="Location" DisplayName="Location" DefaultValue="" SetterAccessModifier="Assembly">
          <Type>
            <ExternalTypeMoniker Name="PointD" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="cf2bf0b3-0648-4fa7-ad45-0d3404f0c8c2" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShape.Size" Name="Size" DisplayName="Size" DefaultValue="" SetterAccessModifier="Assembly">
          <Type>
            <ExternalTypeMoniker Name="SizeD" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9a9808d2-c322-4626-9547-a60d94697701" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShape.Absolute Location" Name="AbsoluteLocation" DisplayName="Absolute Location" SetterAccessModifier="Assembly">
          <Type>
            <ExternalTypeMoniker Name="PointD" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="380b4fd4-15c5-4ffc-8a56-65179d3273bc" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShape.Placement Side" Name="PlacementSide" DisplayName="Placement Side">
          <Type>
            <DomainEnumerationMoniker Name="PortPlacement" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="NodeShape" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ShapeElementContainsChildShapes.InternalChildren</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="0fef1f12-2fe2-4587-9385-bcd7922588f3" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.Diagram" Name="Diagram" DisplayName="Diagram" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" HasCustomConstructor="true" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="ShapeElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="40aa6458-158d-40e6-a616-6554003e04b1" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.Diagram.Name" Name="Name" DisplayName="Name" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="NodeShape" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DiagramHasChildren.Children</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="LinkShape" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DiagramHasLinkShapes.LinkShapes</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Diagram" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DiagramHasIncludedDiagrams.IncludedDiagrams</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="3e757998-961c-42e5-880f-0e73264d076d" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShape" Name="LinkShape" DisplayName="Link Shape" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" HasCustomConstructor="true" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="ShapeElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="bc0e8612-29b6-4568-8cc6-5d1776e506b6" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShape.Edge Points" Name="EdgePoints" DisplayName="Edge Points">
          <Type>
            <ExternalTypeMoniker Name="EdgePointCollection" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="18b063f4-a36f-4c1b-960e-e2f74a2cf0d4" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShape.Dummy Property" Name="DummyProperty" DisplayName="Dummy Property" DefaultValue="Dummy property">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="5a6c9d6e-1597-4529-9b5a-8fb90e6e6cd2" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShape.Routing Mode" Name="RoutingMode" DisplayName="Routing Mode" DefaultValue="Orthogonal">
          <Type>
            <DomainEnumerationMoniker Name="RoutingMode" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="SourceAnchor" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>LinkShapeHasSourceAnchor.SourceAnchor</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="TargetAnchor" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>LinkShapeHasTargetAnchor.TargetAnchor</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="a7670c9f-e755-460f-9333-370c60268cd7" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeElement" Name="ShapeElement" DisplayName="Shape Element" InheritanceModifier="Abstract" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" GeneratesDoubleDerived="true">
      <Properties>
        <DomainProperty Id="c01901de-38ff-42b3-ad42-088796554898" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeElement.Internal Element Id" Name="InternalElementId" DisplayName="Internal Element Id" GetterAccessModifier="FamilyOrAssembly" SetterAccessModifier="FamilyOrAssembly">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="92ae8c5c-86ef-41fb-8024-6d590872e2b7" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LayoutInfo" Name="LayoutInfo" DisplayName="Layout Info" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Properties>
        <DomainProperty Id="6d3395ec-0b6a-4e27-963a-35170c8e199e" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LayoutInfo.Host Element Id" Name="HostElementId" DisplayName="Host Element Id">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="61f86fda-1438-4ce0-a575-1fb726edfc6e" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LayoutInfo.Size" Name="Size" DisplayName="Size">
          <Type>
            <ExternalTypeMoniker Name="SizeD" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="NodeShapeInfo" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>LayoutInfoHasChildrenInfos.ChildrenInfos</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="LinkShapeInfo" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>LayoutInfoHasLinkShapeInfos.LinkShapeInfos</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="876eb302-5ad9-492d-b825-0a9e8ffcf7a1" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.SourceAnchor" Name="SourceAnchor" DisplayName="Source Anchor" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <BaseClass>
        <DomainClassMoniker Name="Anchor" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="cfa90485-01cd-431a-a9f1-35188946607b" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.TargetAnchor" Name="TargetAnchor" DisplayName="Target Anchor" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <BaseClass>
        <DomainClassMoniker Name="Anchor" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="21d8aaf9-9abf-49fb-9e63-769132a1ec2e" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.Anchor" Name="Anchor" DisplayName="Anchor" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Properties>
        <DomainProperty Id="2a93ff48-af72-48be-a9eb-acccc9e9ca64" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.Anchor.Absolute Location" Name="AbsoluteLocation" DisplayName="Absolute Location">
          <Type>
            <ExternalTypeMoniker Name="PointD" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="fbb19920-a0cf-4ec4-bdcb-4e86cc60b0d0" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeInfo" Name="NodeShapeInfo" DisplayName="Node Shape Info" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Properties>
        <DomainProperty Id="057892d6-fd54-4abf-a576-da42b4663e2a" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeInfo.Size" Name="Size" DisplayName="Size">
          <Type>
            <ExternalTypeMoniker Name="SizeD" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="fee92e0a-2a0e-4458-bbbc-551846e4e3a5" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeInfo.Relative Location" Name="RelativeLocation" DisplayName="Relative Location">
          <Type>
            <ExternalTypeMoniker Name="PointD" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8eab5e4e-2f14-47d3-9cd3-23a832ad4caf" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeInfo.Element Id" Name="ElementId" DisplayName="Element Id">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="NodeShapeInfo" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>NodeShapeInfoHasChildrenInfos.ChildrenInfos</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="1eb4dc07-6078-4528-a0a6-5e82ba1baae5" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeInfo" Name="LinkShapeInfo" DisplayName="Link Shape Info" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Properties>
        <DomainProperty Id="7ed37ead-5b39-4570-bcf8-e328aeb1f2f1" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeInfo.Source Location" Name="SourceLocation" DisplayName="Source Location">
          <Type>
            <ExternalTypeMoniker Name="PointD" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="68470f3a-b314-4bb9-8f1d-3f0405afa686" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeInfo.Target Location" Name="TargetLocation" DisplayName="Target Location">
          <Type>
            <ExternalTypeMoniker Name="PointD" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ec4a9b3a-8f63-41f7-be53-030bdab39a48" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeInfo.Element Id" Name="ElementId" DisplayName="Element Id">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="89a01e24-ddb1-48b3-a349-9c6bd327a92c" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeInfo.Source Element Id" Name="SourceElementId" DisplayName="Source Element Id">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="1eb373a1-90d7-44be-8cdb-ffd6409392f8" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeInfo.Target Element Id" Name="TargetElementId" DisplayName="Target Element Id">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="5d93b55e-ed38-4690-bb45-720ff5477288" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeInfo.Link Domain Class Id" Name="LinkDomainClassId" DisplayName="Link Domain Class Id">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="0572b9bd-8dff-4ba0-ab6c-30a8f2ef5cd7" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeInfo.Routing Mode" Name="RoutingMode" DisplayName="Routing Mode">
          <Type>
            <DomainEnumerationMoniker Name="RoutingMode" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7f72c213-9822-4a99-9f4e-bcceb9867661" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeInfo.Edge Points" Name="EdgePoints" DisplayName="Edge Points">
          <Type>
            <ExternalTypeMoniker Name="EdgePointCollection" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="05507902-864b-41c9-93a9-12ac6056578f" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependenciesDiagram" Name="GraphicalDependenciesDiagram" DisplayName="Graphical Dependencies Diagram" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" HasCustomConstructor="true" GeneratesDoubleDerived="true">
      <BaseClass>
        <DomainClassMoniker Name="Diagram" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="eb44e89b-62cc-486b-9105-a9d85924768b" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyLinkShape" Name="GraphicalDependencyLinkShape" DisplayName="Graphical Dependency Link Shape" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <BaseClass>
        <DomainClassMoniker Name="LinkShape" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="446518b6-d194-45ef-a0b4-5231059cce4e" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyMainShape" Name="GraphicalDependencyMainShape" DisplayName="Graphical Dependency Main Shape" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <BaseClass>
        <DomainClassMoniker Name="NodeShape" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="674603c0-4810-45a5-9209-c902904a4549" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyShape" Name="GraphicalDependencyShape" DisplayName="Graphical Dependency Shape" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <BaseClass>
        <DomainClassMoniker Name="NodeShape" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="3ae80a2e-50f8-4307-b49f-34ca36140d50" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyShape.Relationship Name" Name="RelationshipName" DisplayName="Relationship Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="74f0876b-131c-4818-a01e-2cbab9a2088e" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyShape.Relationship Type Id" Name="RelationshipTypeId" DisplayName="Relationship Type Id">
          <Type>
            <ExternalTypeMoniker Name="/System/Guid" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="f80e3b51-ce79-43bb-a38f-3bdb331ba5ee" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyShape.Custom Info" Name="CustomInfo" DisplayName="Custom Info">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="e4cae64b-b252-4f77-9a77-3fa8fd286f32" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeElementContainsChildShapes" Name="ShapeElementContainsChildShapes" DisplayName="Shape Element Contains Child Shapes" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" IsEmbedding="true">
      <Source>
        <DomainRole Id="5b223ad0-ac16-468f-a767-b32a168aa2c6" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeElementContainsChildShapes.ParentShape" Name="ParentShape" DisplayName="Parent Shape" PropertyName="InternalChildren" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyGetterAccessModifier="Assembly" PropertySetterAccessModifier="Assembly" PropertyDisplayName="Internal Children">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="0696200f-158a-4315-a170-e1bdb8bf6b83" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeElementContainsChildShapes.ChildShape" Name="ChildShape" DisplayName="Child Shape" PropertyName="Parent" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Parent">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="0d02c162-d6a8-4180-89bc-145180179968" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramsModelHasDiagrams" Name="DiagramsModelHasDiagrams" DisplayName="Diagrams Model Has Diagrams" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" IsEmbedding="true">
      <Source>
        <DomainRole Id="27e1528b-3cf2-4e5c-9fae-decefa40bda5" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramsModelHasDiagrams.DiagramsModel" Name="DiagramsModel" DisplayName="Diagrams Model" PropertyName="Diagrams" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Diagrams">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramsModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="46ecd183-fed5-412b-a66e-3108526590d5" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramsModelHasDiagrams.Diagram" Name="Diagram" DisplayName="Diagram" PropertyName="DiagramsModel" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Diagrams Model">
          <RolePlayer>
            <DomainClassMoniker Name="Diagram" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="fdc6c2af-4fad-4394-8154-3654834de063" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramHasChildren" Name="DiagramHasChildren" DisplayName="Diagram Has Children" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" GeneratesDoubleDerived="true" IsEmbedding="true">
      <Source>
        <DomainRole Id="c216a77d-a53d-402c-82b3-6c41070d0cd3" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramHasChildren.Diagram" Name="Diagram" DisplayName="Diagram" PropertyName="Children" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Children">
          <RolePlayer>
            <DomainClassMoniker Name="Diagram" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="14501df3-3d1d-424a-942f-c3324835ab3c" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramHasChildren.ChildShape" Name="ChildShape" DisplayName="Child Shape" PropertyName="InternalDiagram" Multiplicity="One" PropagatesDelete="true" PropertyGetterAccessModifier="Assembly" PropertySetterAccessModifier="Assembly" PropertyDisplayName="Internal Diagram">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="68e7b240-afee-49e2-aba9-021c45caa053" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramHasLinkShapes" Name="DiagramHasLinkShapes" DisplayName="Diagram Has Link Shapes" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" GeneratesDoubleDerived="true" IsEmbedding="true">
      <Source>
        <DomainRole Id="0d5c914c-9ba6-483a-9e16-bab444fb6707" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramHasLinkShapes.Diagram" Name="Diagram" DisplayName="Diagram" PropertyName="LinkShapes" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Link Shapes">
          <RolePlayer>
            <DomainClassMoniker Name="Diagram" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="2bd12c47-09e8-48a3-b824-3bf81ff39213" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramHasLinkShapes.LinkShape" Name="LinkShape" DisplayName="Link Shape" PropertyName="Diagram" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Diagram">
          <RolePlayer>
            <DomainClassMoniker Name="LinkShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="b7f76233-3d2c-4256-a792-a7762b7cfb10" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeReferencesNestedChildren" Name="NodeShapeReferencesNestedChildren" DisplayName="Node Shape References Nested Children" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" GeneratesDoubleDerived="true">
      <Source>
        <DomainRole Id="f797a134-535e-4650-8051-03b25177ea15" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeReferencesNestedChildren.ParentShape" Name="ParentShape" DisplayName="Parent Shape" PropertyName="NestedChildren" PropertyDisplayName="Nested Children">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="df774730-0f99-4017-8344-848d80fab1f7" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeReferencesNestedChildren.ChildShape" Name="ChildShape" DisplayName="Child Shape" PropertyName="ParentShape" Multiplicity="ZeroOne" IsPropertyGenerator="false" PropertyDisplayName="Parent Shape">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="685481f1-92af-43db-a4c8-110f064b6942" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeReferencesRelativeChildren" Name="NodeShapeReferencesRelativeChildren" DisplayName="Node Shape References Relative Children" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" GeneratesDoubleDerived="true">
      <Source>
        <DomainRole Id="a21d0c88-99a0-467e-9a48-6c4b4140c844" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeReferencesRelativeChildren.ParentShape" Name="ParentShape" DisplayName="Parent Shape" PropertyName="RelativeChildren" PropertyDisplayName="Relative Children">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="bf24a8ba-28dd-4872-aec3-ae8a7dfe183b" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeReferencesRelativeChildren.ChildShape" Name="ChildShape" DisplayName="Child Shape" PropertyName="ParentShape" Multiplicity="ZeroOne" IsPropertyGenerator="false" PropertyDisplayName="Parent Shape">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="7b1335b6-b158-45f8-b319-703235333df5" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeHasSourceAnchor" Name="LinkShapeHasSourceAnchor" DisplayName="Link Shape Has Source Anchor" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" IsEmbedding="true">
      <Source>
        <DomainRole Id="105a84ac-5502-4055-8ad0-52d7b34aad37" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeHasSourceAnchor.LinkShape" Name="LinkShape" DisplayName="Link Shape" PropertyName="SourceAnchor" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Source Anchor">
          <RolePlayer>
            <DomainClassMoniker Name="LinkShape" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="8cce3acc-170c-447d-bd57-877ce8a2b74f" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeHasSourceAnchor.SourceAnchor" Name="SourceAnchor" DisplayName="Source Anchor" PropertyName="LinkShape" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Link Shape">
          <RolePlayer>
            <DomainClassMoniker Name="SourceAnchor" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="c1e46813-191c-4600-91af-95efc98baaa6" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeHasTargetAnchor" Name="LinkShapeHasTargetAnchor" DisplayName="Link Shape Has Target Anchor" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" IsEmbedding="true">
      <Source>
        <DomainRole Id="20470214-10a2-409f-86a5-2f247c239feb" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeHasTargetAnchor.LinkShape" Name="LinkShape" DisplayName="Link Shape" PropertyName="TargetAnchor" Multiplicity="One" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Target Anchor">
          <RolePlayer>
            <DomainClassMoniker Name="LinkShape" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="fb1ad2ca-550f-4ad4-bb32-59f04d881111" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkShapeHasTargetAnchor.TargetAnchor" Name="TargetAnchor" DisplayName="Target Anchor" PropertyName="LinkShape" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Link Shape">
          <RolePlayer>
            <DomainClassMoniker Name="TargetAnchor" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="d2b811e7-0604-4b38-b4ae-8b327dc8029b" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.SourceAnchorReferencesFromShape" Name="SourceAnchorReferencesFromShape" DisplayName="Source Anchor References From Shape" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Source>
        <DomainRole Id="9023ab11-46db-4996-b020-9a9a2c516c60" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.SourceAnchorReferencesFromShape.SourceAnchor" Name="SourceAnchor" DisplayName="Source Anchor" PropertyName="FromShape" Multiplicity="One" PropertyDisplayName="From Shape">
          <RolePlayer>
            <DomainClassMoniker Name="SourceAnchor" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="0e35669f-45e5-45d5-9e1a-6e10d32a5abf" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.SourceAnchorReferencesFromShape.NodeShape" Name="NodeShape" DisplayName="Node Shape" PropertyName="SourceAnchors" PropertyDisplayName="Source Anchors">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="92b644b9-916c-4bc4-999e-9cf4f9641caf" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.TargetAnchorReferencesToShape" Name="TargetAnchorReferencesToShape" DisplayName="Target Anchor References To Shape" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Source>
        <DomainRole Id="df396ad5-0225-4bb5-8bb7-9768cd9e1c14" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.TargetAnchorReferencesToShape.TargetAnchor" Name="TargetAnchor" DisplayName="Target Anchor" PropertyName="ToShape" Multiplicity="One" PropertyDisplayName="To Shape">
          <RolePlayer>
            <DomainClassMoniker Name="TargetAnchor" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="db602d19-2208-47ed-8ba9-c4955825f0b7" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.TargetAnchorReferencesToShape.NodeShape" Name="NodeShape" DisplayName="Node Shape" PropertyName="TargetAnchors" PropertyDisplayName="Target Anchors">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="1aca22db-a1fb-430e-a291-0b77ee0f02c0" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramHasIncludedDiagrams" Name="DiagramHasIncludedDiagrams" DisplayName="Diagram Has Included Diagrams" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" IsEmbedding="true">
      <Source>
        <DomainRole Id="e01a8458-e86e-4f8a-a991-b5c0d0118e49" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramHasIncludedDiagrams.SourceDiagram" Name="SourceDiagram" DisplayName="Source Diagram" PropertyName="IncludedDiagrams" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Included Diagrams">
          <RolePlayer>
            <DomainClassMoniker Name="Diagram" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="2b121843-72f1-48c9-85e8-2263b62d9f86" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramHasIncludedDiagrams.TargetDiagram" Name="TargetDiagram" DisplayName="Target Diagram" PropertyName="ParentDiagram" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyGetterAccessModifier="Assembly" PropertySetterAccessModifier="Assembly" PropertyDisplayName="Parent Diagram">
          <RolePlayer>
            <DomainClassMoniker Name="Diagram" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="94b30d68-b9fc-482b-a462-e365ee2eed96" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LayoutInfoHasChildrenInfos" Name="LayoutInfoHasChildrenInfos" DisplayName="Layout Info Has Children Infos" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" IsEmbedding="true">
      <Source>
        <DomainRole Id="82dd56c4-b8e2-4ac5-8cc0-ac728af5b9be" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LayoutInfoHasChildrenInfos.LayoutInfo" Name="LayoutInfo" DisplayName="Layout Info" PropertyName="ChildrenInfos" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Children Infos">
          <RolePlayer>
            <DomainClassMoniker Name="LayoutInfo" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="0711653d-e3ef-4056-a3ca-215275c1bc3b" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LayoutInfoHasChildrenInfos.NodeShapeInfo" Name="NodeShapeInfo" DisplayName="Node Shape Info" PropertyName="LayoutInfo" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Layout Info">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShapeInfo" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="62cce076-334a-4806-98ca-d185a27cb47e" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LayoutInfoHasLinkShapeInfos" Name="LayoutInfoHasLinkShapeInfos" DisplayName="Layout Info Has Link Shape Infos" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" IsEmbedding="true">
      <Source>
        <DomainRole Id="a0714924-91b3-4c58-8918-f6dd768dd557" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LayoutInfoHasLinkShapeInfos.LayoutInfo" Name="LayoutInfo" DisplayName="Layout Info" PropertyName="LinkShapeInfos" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Link Shape Infos">
          <RolePlayer>
            <DomainClassMoniker Name="LayoutInfo" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="d5faf004-bc53-4861-a97a-20a77cce2ee2" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LayoutInfoHasLinkShapeInfos.LinkShapeInfo" Name="LinkShapeInfo" DisplayName="Link Shape Info" PropertyName="LayoutInfo" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Layout Info">
          <RolePlayer>
            <DomainClassMoniker Name="LinkShapeInfo" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="ad91d0e8-a691-4c02-ab93-2b4d3c60bbc6" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramsModelHasLayoutInfos" Name="DiagramsModelHasLayoutInfos" DisplayName="Diagrams Model Has Layout Infos" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" IsEmbedding="true">
      <Source>
        <DomainRole Id="a8cb8098-f7ab-4a66-b431-08912653c4fc" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramsModelHasLayoutInfos.DiagramsModel" Name="DiagramsModel" DisplayName="Diagrams Model" PropertyName="LayoutInfos" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Layout Infos">
          <RolePlayer>
            <DomainClassMoniker Name="DiagramsModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="a1980703-2c39-4809-9948-f60865a1f9a2" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.DiagramsModelHasLayoutInfos.LayoutInfo" Name="LayoutInfo" DisplayName="Layout Info" PropertyName="DiagramsModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Diagrams Model">
          <RolePlayer>
            <DomainClassMoniker Name="LayoutInfo" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="8bb8b430-76d9-4838-9fa1-595d84c616c3" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeInfoHasChildrenInfos" Name="NodeShapeInfoHasChildrenInfos" DisplayName="Node Shape Info Has Children Infos" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" IsEmbedding="true">
      <Source>
        <DomainRole Id="dcde8432-2d76-4265-ba97-f9b2be07ac83" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeInfoHasChildrenInfos.SourceNodeShapeInfo" Name="SourceNodeShapeInfo" DisplayName="Source Node Shape Info" PropertyName="ChildrenInfos" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Children Infos">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShapeInfo" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="fea6bea8-c310-47cb-b72a-be478dcfd4cd" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.NodeShapeInfoHasChildrenInfos.TargetNodeShapeInfo" Name="TargetNodeShapeInfo" DisplayName="Target Node Shape Info" PropertyName="ParentInfo" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Parent Info">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShapeInfo" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="d611d073-0100-47f2-aa07-0d3b71966e6e" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependenciesDiagramReferencesSourceDependencyShapes" Name="GraphicalDependenciesDiagramReferencesSourceDependencyShapes" DisplayName="Graphical Dependencies Diagram References Source Dependency Shapes" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Source>
        <DomainRole Id="1360b591-fc74-431f-9549-1875085e49f0" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependenciesDiagramReferencesSourceDependencyShapes.GraphicalDependenciesDiagram" Name="GraphicalDependenciesDiagram" DisplayName="Graphical Dependencies Diagram" PropertyName="SourceDependencyShapes" PropertyDisplayName="Source Dependency Shapes">
          <RolePlayer>
            <DomainClassMoniker Name="GraphicalDependenciesDiagram" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="b0f55db3-0a66-4a32-9266-d751eb7a81b6" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependenciesDiagramReferencesSourceDependencyShapes.GraphicalDependencyShape" Name="GraphicalDependencyShape" DisplayName="Graphical Dependency Shape" PropertyName="GraphicalDependenciesDiagram" Multiplicity="ZeroOne" IsPropertyGenerator="false" PropertyDisplayName="Graphical Dependencies Diagram">
          <RolePlayer>
            <DomainClassMoniker Name="GraphicalDependencyShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="e1b063b1-5cf1-4045-ae0b-891f5fa87f9e" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependenciesDiagramReferencesTargetDependencyShapes" Name="GraphicalDependenciesDiagramReferencesTargetDependencyShapes" DisplayName="Graphical Dependencies Diagram References Target Dependency Shapes" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Source>
        <DomainRole Id="6b972466-6fc8-4f11-9910-e1cb09577735" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependenciesDiagramReferencesTargetDependencyShapes.GraphicalDependenciesDiagram" Name="GraphicalDependenciesDiagram" DisplayName="Graphical Dependencies Diagram" PropertyName="TargetDependencyShapes" PropertyDisplayName="Target Dependency Shapes">
          <RolePlayer>
            <DomainClassMoniker Name="GraphicalDependenciesDiagram" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="89e1ba4b-b250-41ed-85b0-0d115e421fcd" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependenciesDiagramReferencesTargetDependencyShapes.GraphicalDependencyShape" Name="GraphicalDependencyShape" DisplayName="Graphical Dependency Shape" PropertyName="GraphicalDependenciesDiagram" Multiplicity="ZeroOne" IsPropertyGenerator="false" PropertyDisplayName="Graphical Dependencies Diagram">
          <RolePlayer>
            <DomainClassMoniker Name="GraphicalDependencyShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="1176beaa-9980-466e-8a09-bcab05649a94" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyLinkShapeReferencesMainShape" Name="GraphicalDependencyLinkShapeReferencesMainShape" DisplayName="Graphical Dependency Link Shape References Main Shape" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Source>
        <DomainRole Id="c03d1b71-d350-4a4b-9a07-1dd77c23a38b" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyLinkShapeReferencesMainShape.GraphicalDependencyLinkShape" Name="GraphicalDependencyLinkShape" DisplayName="Graphical Dependency Link Shape" PropertyName="MainShape" Multiplicity="One" PropertyDisplayName="Main Shape">
          <RolePlayer>
            <DomainClassMoniker Name="GraphicalDependencyLinkShape" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="1efa32c9-cdf0-4894-837f-e67a88b077da" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyLinkShapeReferencesMainShape.NodeShape" Name="NodeShape" DisplayName="Node Shape" PropertyName="LinkShape" IsPropertyGenerator="false" PropertyDisplayName="Link Shape">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="53bba87c-12be-45c6-99f2-47f19a94723f" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependenciesDiagramReferencesMainElementShape" Name="GraphicalDependenciesDiagramReferencesMainElementShape" DisplayName="Graphical Dependencies Diagram References Main Element Shape" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Source>
        <DomainRole Id="14745916-d6a3-41c0-bcaa-cee6dae19306" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependenciesDiagramReferencesMainElementShape.GraphicalDependenciesDiagram" Name="GraphicalDependenciesDiagram" DisplayName="Graphical Dependencies Diagram" PropertyName="MainElementShape" Multiplicity="ZeroOne" PropertyDisplayName="Main Element Shape">
          <RolePlayer>
            <DomainClassMoniker Name="GraphicalDependenciesDiagram" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="ad0bdac9-0759-4c95-88ed-45b971f69286" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependenciesDiagramReferencesMainElementShape.NodeShape" Name="NodeShape" DisplayName="Node Shape" PropertyName="GraphicalDependenciesDiagram" Multiplicity="ZeroOne" IsPropertyGenerator="false" PropertyDisplayName="Graphical Dependencies Diagram">
          <RolePlayer>
            <DomainClassMoniker Name="NodeShape" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="3ce21aad-289d-41cc-8fb2-1ea0aa45e802" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyLinkShapeReferencesDependencyShape" Name="GraphicalDependencyLinkShapeReferencesDependencyShape" DisplayName="Graphical Dependency Link Shape References Dependency Shape" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
      <Source>
        <DomainRole Id="051a9d50-3fc2-4c18-9ad8-56fdd61aef59" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyLinkShapeReferencesDependencyShape.GraphicalDependencyLinkShape" Name="GraphicalDependencyLinkShape" DisplayName="Graphical Dependency Link Shape" PropertyName="DependencyShape" Multiplicity="One" PropertyDisplayName="Dependency Shape">
          <RolePlayer>
            <DomainClassMoniker Name="GraphicalDependencyLinkShape" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="5511dba2-3dcb-4a73-813d-90ddfd5040a1" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.GraphicalDependencyLinkShapeReferencesDependencyShape.GraphicalDependencyShape" Name="GraphicalDependencyShape" DisplayName="Graphical Dependency Shape" PropertyName="LinkShape" Multiplicity="One" PropertyDisplayName="Link Shape">
          <RolePlayer>
            <DomainClassMoniker Name="GraphicalDependencyShape" />
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
    <ExternalType Name="Object" Namespace="System" />
    <DomainEnumeration Name="ShapeMovementBehaviour" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeMovementBehaviour">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeMovementBehaviour.Normal" Name="Normal" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeMovementBehaviour.PositionRelativeToParent" Name="PositionRelativeToParent" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeMovementBehaviour.PositionOnEdgeOfParent" Name="PositionOnEdgeOfParent" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="ShapeResizingBehaviour" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeResizingBehaviour">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeResizingBehaviour.FixedHeight" Name="FixedHeight" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeResizingBehaviour.FixedWidth" Name="FixedWidth" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeResizingBehaviour.Fixed" Name="Fixed" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.ShapeResizingBehaviour.Normal" Name="Normal" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="PortPlacement" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.PortPlacement">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.PortPlacement.Left" Name="Left" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.PortPlacement.Right" Name="Right" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.PortPlacement.Top" Name="Top" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.PortPlacement.Bottom" Name="Bottom" Value="" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="LinkPlacement" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkPlacement">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkPlacement.Left" Name="Left" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkPlacement.Top" Name="Top" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkPlacement.Right" Name="Right" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.LinkPlacement.Bottom" Name="Bottom" Value="" />
      </Literals>
    </DomainEnumeration>
    <ExternalType Name="PointD" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" />
    <ExternalType Name="SizeD" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" />
    <ExternalType Name="RectangleD" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" />
    <DomainEnumeration Name="FixedGeometryPoints" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.FixedGeometryPoints">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.FixedGeometryPoints.Source" Name="Source" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.FixedGeometryPoints.Target" Name="Target" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.FixedGeometryPoints.SourceAndTarget" Name="SourceAndTarget" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.FixedGeometryPoints.None" Name="None" Value="" />
      </Literals>
    </DomainEnumeration>
    <ExternalType Name="EdgePointCollection" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" />
    <DomainEnumeration Name="RoutingMode" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams" Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.RoutingMode">
      <Literals>
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.RoutingMode.Orthogonal" Name="Orthogonal" Value="" />
        <EnumerationLiteral Description="Description for Tum.PDE.ToolFramework.Modeling.Diagrams.RoutingMode.Straight" Name="Straight" Value="" />
      </Literals>
    </DomainEnumeration>
  </Types>
  <XmlSerializationBehavior Name="TestDslDefinitionSerializationBehavior" Namespace="Tum.PDE.ToolFramework.Modeling.Diagrams">
    <ClassData>
      <XmlClassData TypeName="DiagramsModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramsModelMoniker" ElementName="diagramsModel" MonikerTypeName="DiagramsModelMoniker">
        <DomainClassMoniker Name="DiagramsModel" />
        <ElementData>
          <XmlRelationshipData RoleElementName="diagrams">
            <DomainRelationshipMoniker Name="DiagramsModelHasDiagrams" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="layoutInfos">
            <DomainRelationshipMoniker Name="DiagramsModelHasLayoutInfos" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="NodeShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="nodeShapeMoniker" ElementName="nodeShape" MonikerTypeName="NodeShapeMoniker">
        <DomainClassMoniker Name="NodeShape" />
        <ElementData>
          <XmlRelationshipData RoleElementName="internalChildren">
            <DomainRelationshipMoniker Name="ShapeElementContainsChildShapes" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="nestedChildren">
            <DomainRelationshipMoniker Name="NodeShapeReferencesNestedChildren" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="relativeChildren">
            <DomainRelationshipMoniker Name="NodeShapeReferencesRelativeChildren" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="resizingBehaviour" Representation="Ignore">
            <DomainPropertyMoniker Name="NodeShape/ResizingBehaviour" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="movementBehaviour" Representation="Ignore">
            <DomainPropertyMoniker Name="NodeShape/MovementBehaviour" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isRelativeChildShape" Representation="Ignore">
            <DomainPropertyMoniker Name="NodeShape/IsRelativeChildShape" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="takesPartInRelationship" Representation="Ignore">
            <DomainPropertyMoniker Name="NodeShape/TakesPartInRelationship" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="location">
            <DomainPropertyMoniker Name="NodeShape/Location" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="size">
            <DomainPropertyMoniker Name="NodeShape/Size" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="absoluteLocation">
            <DomainPropertyMoniker Name="NodeShape/AbsoluteLocation" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="placementSide">
            <DomainPropertyMoniker Name="NodeShape/PlacementSide" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ShapeElementContainsChildShapes" MonikerAttributeName="" MonikerElementName="shapeElementContainsChildShapesMoniker" ElementName="shapeElementContainsChildShapes" MonikerTypeName="ShapeElementContainsChildShapesMoniker">
        <DomainRelationshipMoniker Name="ShapeElementContainsChildShapes" />
      </XmlClassData>
      <XmlClassData TypeName="Diagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramMoniker" ElementName="diagram" MonikerTypeName="DiagramMoniker">
        <DomainClassMoniker Name="Diagram" />
        <ElementData>
          <XmlRelationshipData RoleElementName="children">
            <DomainRelationshipMoniker Name="DiagramHasChildren" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="linkShapes">
            <DomainRelationshipMoniker Name="DiagramHasLinkShapes" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="Diagram/Name" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="includedDiagrams">
            <DomainRelationshipMoniker Name="DiagramHasIncludedDiagrams" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DiagramsModelHasDiagrams" MonikerAttributeName="" MonikerElementName="diagramsModelHasDiagramsMoniker" ElementName="diagramsModelHasDiagrams" MonikerTypeName="DiagramsModelHasDiagramsMoniker">
        <DomainRelationshipMoniker Name="DiagramsModelHasDiagrams" />
      </XmlClassData>
      <XmlClassData TypeName="DiagramHasChildren" MonikerAttributeName="" MonikerElementName="diagramHasChildrenMoniker" ElementName="diagramHasChildren" MonikerTypeName="DiagramHasChildrenMoniker">
        <DomainRelationshipMoniker Name="DiagramHasChildren" />
      </XmlClassData>
      <XmlClassData TypeName="DiagramHasLinkShapes" MonikerAttributeName="" MonikerElementName="diagramHasLinkShapesMoniker" ElementName="diagramHasLinkShapes" MonikerTypeName="DiagramHasLinkShapesMoniker">
        <DomainRelationshipMoniker Name="DiagramHasLinkShapes" />
      </XmlClassData>
      <XmlClassData TypeName="LinkShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="linkShapeMoniker" ElementName="linkShape" MonikerTypeName="LinkShapeMoniker">
        <DomainClassMoniker Name="LinkShape" />
        <ElementData>
          <XmlPropertyData XmlName="edgePoints" Representation="Element">
            <DomainPropertyMoniker Name="LinkShape/EdgePoints" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="dummyProperty">
            <DomainPropertyMoniker Name="LinkShape/DummyProperty" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="sourceAnchor">
            <DomainRelationshipMoniker Name="LinkShapeHasSourceAnchor" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targetAnchor">
            <DomainRelationshipMoniker Name="LinkShapeHasTargetAnchor" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="routingMode">
            <DomainPropertyMoniker Name="LinkShape/RoutingMode" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ShapeElement" MonikerAttributeName="" SerializeId="true" MonikerElementName="shapeElementMoniker" ElementName="shapeElement" MonikerTypeName="ShapeElementMoniker">
        <DomainClassMoniker Name="ShapeElement" />
        <ElementData>
          <XmlPropertyData XmlName="internalElementId">
            <DomainPropertyMoniker Name="ShapeElement/InternalElementId" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="NodeShapeReferencesNestedChildren" MonikerAttributeName="" MonikerElementName="nodeShapeReferencesNestedChildrenMoniker" ElementName="nodeShapeReferencesNestedChildren" MonikerTypeName="NodeShapeReferencesNestedChildrenMoniker">
        <DomainRelationshipMoniker Name="NodeShapeReferencesNestedChildren" />
      </XmlClassData>
      <XmlClassData TypeName="NodeShapeReferencesRelativeChildren" MonikerAttributeName="" MonikerElementName="nodeShapeReferencesRelativeChildrenMoniker" ElementName="nodeShapeReferencesRelativeChildren" MonikerTypeName="NodeShapeReferencesRelativeChildrenMoniker">
        <DomainRelationshipMoniker Name="NodeShapeReferencesRelativeChildren" />
      </XmlClassData>
      <XmlClassData TypeName="LayoutInfo" MonikerAttributeName="" SerializeId="true" MonikerElementName="layoutInfoMoniker" ElementName="layoutInfo" MonikerTypeName="LayoutInfoMoniker">
        <DomainClassMoniker Name="LayoutInfo" />
        <ElementData>
          <XmlPropertyData XmlName="hostElementId">
            <DomainPropertyMoniker Name="LayoutInfo/HostElementId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="size">
            <DomainPropertyMoniker Name="LayoutInfo/Size" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="childrenInfos">
            <DomainRelationshipMoniker Name="LayoutInfoHasChildrenInfos" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="linkShapeInfos">
            <DomainRelationshipMoniker Name="LayoutInfoHasLinkShapeInfos" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="LinkShapeHasSourceAnchor" MonikerAttributeName="" MonikerElementName="linkShapeHasSourceAnchorMoniker" ElementName="linkShapeHasSourceAnchor" MonikerTypeName="LinkShapeHasSourceAnchorMoniker">
        <DomainRelationshipMoniker Name="LinkShapeHasSourceAnchor" />
      </XmlClassData>
      <XmlClassData TypeName="SourceAnchor" MonikerAttributeName="" SerializeId="true" MonikerElementName="sourceAnchorMoniker" ElementName="sourceAnchor" MonikerTypeName="SourceAnchorMoniker">
        <DomainClassMoniker Name="SourceAnchor" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="fromShape">
            <DomainRelationshipMoniker Name="SourceAnchorReferencesFromShape" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="LinkShapeHasTargetAnchor" MonikerAttributeName="" MonikerElementName="linkShapeHasTargetAnchorMoniker" ElementName="linkShapeHasTargetAnchor" MonikerTypeName="LinkShapeHasTargetAnchorMoniker">
        <DomainRelationshipMoniker Name="LinkShapeHasTargetAnchor" />
      </XmlClassData>
      <XmlClassData TypeName="TargetAnchor" MonikerAttributeName="" SerializeId="true" MonikerElementName="targetAnchorMoniker" ElementName="targetAnchor" MonikerTypeName="TargetAnchorMoniker">
        <DomainClassMoniker Name="TargetAnchor" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="toShape">
            <DomainRelationshipMoniker Name="TargetAnchorReferencesToShape" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SourceAnchorReferencesFromShape" MonikerAttributeName="" MonikerElementName="sourceAnchorReferencesFromShapeMoniker" ElementName="sourceAnchorReferencesFromShape" MonikerTypeName="SourceAnchorReferencesFromShapeMoniker">
        <DomainRelationshipMoniker Name="SourceAnchorReferencesFromShape" />
      </XmlClassData>
      <XmlClassData TypeName="TargetAnchorReferencesToShape" MonikerAttributeName="" MonikerElementName="targetAnchorReferencesToShapeMoniker" ElementName="targetAnchorReferencesToShape" MonikerTypeName="TargetAnchorReferencesToShapeMoniker">
        <DomainRelationshipMoniker Name="TargetAnchorReferencesToShape" />
      </XmlClassData>
      <XmlClassData TypeName="Anchor" MonikerAttributeName="" SerializeId="true" MonikerElementName="anchorMoniker" ElementName="anchor" MonikerTypeName="AnchorMoniker">
        <DomainClassMoniker Name="Anchor" />
        <ElementData>
          <XmlPropertyData XmlName="absoluteLocation">
            <DomainPropertyMoniker Name="Anchor/AbsoluteLocation" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DiagramHasIncludedDiagrams" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramHasIncludedDiagramsMoniker" ElementName="diagramHasIncludedDiagrams" MonikerTypeName="DiagramHasIncludedDiagramsMoniker">
        <DomainRelationshipMoniker Name="DiagramHasIncludedDiagrams" />
      </XmlClassData>
      <XmlClassData TypeName="LayoutInfoHasChildrenInfos" MonikerAttributeName="" SerializeId="true" MonikerElementName="layoutInfoHasChildrenInfosMoniker" ElementName="layoutInfoHasChildrenInfos" MonikerTypeName="LayoutInfoHasChildrenInfosMoniker">
        <DomainRelationshipMoniker Name="LayoutInfoHasChildrenInfos" />
      </XmlClassData>
      <XmlClassData TypeName="NodeShapeInfo" MonikerAttributeName="" SerializeId="true" MonikerElementName="nodeShapeInfoMoniker" ElementName="nodeShapeInfo" MonikerTypeName="NodeShapeInfoMoniker">
        <DomainClassMoniker Name="NodeShapeInfo" />
        <ElementData>
          <XmlPropertyData XmlName="size">
            <DomainPropertyMoniker Name="NodeShapeInfo/Size" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="relativeLocation">
            <DomainPropertyMoniker Name="NodeShapeInfo/RelativeLocation" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="elementId">
            <DomainPropertyMoniker Name="NodeShapeInfo/ElementId" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="childrenInfos">
            <DomainRelationshipMoniker Name="NodeShapeInfoHasChildrenInfos" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="LayoutInfoHasLinkShapeInfos" MonikerAttributeName="" SerializeId="true" MonikerElementName="layoutInfoHasLinkShapeInfosMoniker" ElementName="layoutInfoHasLinkShapeInfos" MonikerTypeName="LayoutInfoHasLinkShapeInfosMoniker">
        <DomainRelationshipMoniker Name="LayoutInfoHasLinkShapeInfos" />
      </XmlClassData>
      <XmlClassData TypeName="LinkShapeInfo" MonikerAttributeName="" SerializeId="true" MonikerElementName="linkShapeInfoMoniker" ElementName="linkShapeInfo" MonikerTypeName="LinkShapeInfoMoniker">
        <DomainClassMoniker Name="LinkShapeInfo" />
        <ElementData>
          <XmlPropertyData XmlName="sourceLocation">
            <DomainPropertyMoniker Name="LinkShapeInfo/SourceLocation" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="targetLocation">
            <DomainPropertyMoniker Name="LinkShapeInfo/TargetLocation" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="elementId">
            <DomainPropertyMoniker Name="LinkShapeInfo/ElementId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="sourceElementId">
            <DomainPropertyMoniker Name="LinkShapeInfo/SourceElementId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="targetElementId">
            <DomainPropertyMoniker Name="LinkShapeInfo/TargetElementId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="linkDomainClassId">
            <DomainPropertyMoniker Name="LinkShapeInfo/LinkDomainClassId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="routingMode">
            <DomainPropertyMoniker Name="LinkShapeInfo/RoutingMode" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="edgePoints" Representation="Element">
            <DomainPropertyMoniker Name="LinkShapeInfo/EdgePoints" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DiagramsModelHasLayoutInfos" MonikerAttributeName="" SerializeId="true" MonikerElementName="diagramsModelHasLayoutInfosMoniker" ElementName="diagramsModelHasLayoutInfos" MonikerTypeName="DiagramsModelHasLayoutInfosMoniker">
        <DomainRelationshipMoniker Name="DiagramsModelHasLayoutInfos" />
      </XmlClassData>
      <XmlClassData TypeName="NodeShapeInfoHasChildrenInfos" MonikerAttributeName="" SerializeId="true" MonikerElementName="nodeShapeInfoHasChildrenInfosMoniker" ElementName="nodeShapeInfoHasChildrenInfos" MonikerTypeName="NodeShapeInfoHasChildrenInfosMoniker">
        <DomainRelationshipMoniker Name="NodeShapeInfoHasChildrenInfos" />
      </XmlClassData>
      <XmlClassData TypeName="GraphicalDependenciesDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="graphicalDependenciesDiagramMoniker" ElementName="graphicalDependenciesDiagram" MonikerTypeName="GraphicalDependenciesDiagramMoniker">
        <DomainClassMoniker Name="GraphicalDependenciesDiagram" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="sourceDependencyShapes">
            <DomainRelationshipMoniker Name="GraphicalDependenciesDiagramReferencesSourceDependencyShapes" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targetDependencyShapes">
            <DomainRelationshipMoniker Name="GraphicalDependenciesDiagramReferencesTargetDependencyShapes" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="mainElementShape">
            <DomainRelationshipMoniker Name="GraphicalDependenciesDiagramReferencesMainElementShape" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="GraphicalDependencyLinkShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="graphicalDependencyLinkShapeMoniker" ElementName="graphicalDependencyLinkShape" MonikerTypeName="GraphicalDependencyLinkShapeMoniker">
        <DomainClassMoniker Name="GraphicalDependencyLinkShape" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="mainShape">
            <DomainRelationshipMoniker Name="GraphicalDependencyLinkShapeReferencesMainShape" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="dependencyShape">
            <DomainRelationshipMoniker Name="GraphicalDependencyLinkShapeReferencesDependencyShape" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="GraphicalDependencyMainShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="graphicalDependencyMainShapeMoniker" ElementName="graphicalDependencyMainShape" MonikerTypeName="GraphicalDependencyMainShapeMoniker">
        <DomainClassMoniker Name="GraphicalDependencyMainShape" />
      </XmlClassData>
      <XmlClassData TypeName="GraphicalDependencyShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="graphicalDependencyShapeMoniker" ElementName="graphicalDependencyShape" MonikerTypeName="GraphicalDependencyShapeMoniker">
        <DomainClassMoniker Name="GraphicalDependencyShape" />
        <ElementData>
          <XmlPropertyData XmlName="relationshipName">
            <DomainPropertyMoniker Name="GraphicalDependencyShape/RelationshipName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="relationshipTypeId">
            <DomainPropertyMoniker Name="GraphicalDependencyShape/RelationshipTypeId" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="customInfo">
            <DomainPropertyMoniker Name="GraphicalDependencyShape/CustomInfo" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="GraphicalDependenciesDiagramReferencesSourceDependencyShapes" MonikerAttributeName="" SerializeId="true" MonikerElementName="graphicalDependenciesDiagramReferencesSourceDependencyShapesMoniker" ElementName="graphicalDependenciesDiagramReferencesSourceDependencyShapes" MonikerTypeName="GraphicalDependenciesDiagramReferencesSourceDependencyShapesMoniker">
        <DomainRelationshipMoniker Name="GraphicalDependenciesDiagramReferencesSourceDependencyShapes" />
      </XmlClassData>
      <XmlClassData TypeName="GraphicalDependenciesDiagramReferencesTargetDependencyShapes" MonikerAttributeName="" SerializeId="true" MonikerElementName="graphicalDependenciesDiagramReferencesTargetDependencyShapesMoniker" ElementName="graphicalDependenciesDiagramReferencesTargetDependencyShapes" MonikerTypeName="GraphicalDependenciesDiagramReferencesTargetDependencyShapesMoniker">
        <DomainRelationshipMoniker Name="GraphicalDependenciesDiagramReferencesTargetDependencyShapes" />
      </XmlClassData>
      <XmlClassData TypeName="GraphicalDependencyLinkShapeReferencesMainShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="graphicalDependencyLinkShapeReferencesMainShapeMoniker" ElementName="graphicalDependencyLinkShapeReferencesMainShape" MonikerTypeName="GraphicalDependencyLinkShapeReferencesMainShapeMoniker">
        <DomainRelationshipMoniker Name="GraphicalDependencyLinkShapeReferencesMainShape" />
      </XmlClassData>
      <XmlClassData TypeName="GraphicalDependenciesDiagramReferencesMainElementShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="graphicalDependenciesDiagramReferencesMainElementShapeMoniker" ElementName="graphicalDependenciesDiagramReferencesMainElementShape" MonikerTypeName="GraphicalDependenciesDiagramReferencesMainElementShapeMoniker">
        <DomainRelationshipMoniker Name="GraphicalDependenciesDiagramReferencesMainElementShape" />
      </XmlClassData>
      <XmlClassData TypeName="GraphicalDependencyLinkShapeReferencesDependencyShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="graphicalDependencyLinkShapeReferencesDependencyShapeMoniker" ElementName="graphicalDependencyLinkShapeReferencesDependencyShape" MonikerTypeName="GraphicalDependencyLinkShapeReferencesDependencyShapeMoniker">
        <DomainRelationshipMoniker Name="GraphicalDependencyLinkShapeReferencesDependencyShape" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="DiagramsDSLExplorerBehavior" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="NodeShapeReferencesNestedChildrenBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="NodeShapeReferencesNestedChildren" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="NodeShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="NodeShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="NodeShapeReferencesRelativeChildrenBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="NodeShapeReferencesRelativeChildren" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="NodeShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="NodeShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="SourceAnchorReferencesFromShapeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SourceAnchorReferencesFromShape" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="SourceAnchor" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="NodeShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="TargetAnchorReferencesToShapeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="TargetAnchorReferencesToShape" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="TargetAnchor" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="NodeShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="GraphicalDependenciesDiagramReferencesSourceDependencyShapesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="GraphicalDependenciesDiagramReferencesSourceDependencyShapes" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="GraphicalDependenciesDiagram" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="GraphicalDependencyShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="GraphicalDependenciesDiagramReferencesTargetDependencyShapesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="GraphicalDependenciesDiagramReferencesTargetDependencyShapes" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="GraphicalDependenciesDiagram" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="GraphicalDependencyShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="GraphicalDependencyLinkShapeReferencesMainShapeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="GraphicalDependencyLinkShapeReferencesMainShape" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="GraphicalDependencyLinkShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="NodeShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="GraphicalDependenciesDiagramReferencesMainElementShapeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="GraphicalDependenciesDiagramReferencesMainElementShape" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="GraphicalDependenciesDiagram" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="NodeShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="GraphicalDependencyLinkShapeReferencesDependencyShapeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="GraphicalDependencyLinkShapeReferencesDependencyShape" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="GraphicalDependencyLinkShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="GraphicalDependencyShape" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <CustomEditor FileExtension="diagramsdsl" EditorGuid="74718f40-7533-45ff-88b7-9efb80c949d6">
    <RootClass>
      <DomainClassMoniker Name="DiagramsModel" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="TestDslDefinitionSerializationBehavior" />
    </XmlSerializationDefinition>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
  </CustomEditor>
  <Explorer ExplorerGuid="a4ee9c14-5fca-4f09-ad40-5e511c8962f7" Title="WpfDesigner Explorer">
    <ExplorerBehaviorMoniker Name="DiagramsDSL/DiagramsDSLExplorerBehavior" />
  </Explorer>
</Dsl>
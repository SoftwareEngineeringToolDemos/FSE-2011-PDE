using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

using Fluent;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel
{

    /// <summary>
    /// HtmlEditorViewModel.
    ///
    /// Double derived to allow easier customization.
    /// </summary>
    public partial class HtmlEditorViewModel : HtmlEditorViewModelBase
    {
        #region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public HtmlEditorViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {

        }
        #endregion

        /// <summary>
        /// Gets the visibility of the html editor menu.
        /// </summary>
        public bool IsHtmlEditorViewModelVisible
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets whether this property editor is the currently selected editor or not.
        /// </summary>
        public override bool IsSelected
        {
            get
            {
                return base.IsSelected;
            }
            set
            {
                base.IsSelected = value;
                if (value)
                    this.OnPropertyChanged("IsHtmlEditorViewModelVisible");
            }
        }
    }

    /// <summary>
    /// HtmlEditorViewModel.
    ///
    /// This is the base abstract class.
    /// </summary>
    public abstract partial class HtmlEditorViewModelBase : PropertyEditorViewModel
    {
        #region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected HtmlEditorViewModelBase(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
        #endregion	

        #region Ribbon Menu Bar
        /// <summary>
        /// Context menu bar creater for the html editor.
        /// </summary>
        public partial class HtmlEditorViewModelContextMenuBarCreater : ContextMenuBarCreater
        {
            #region Singleton Instance
            /// <summary>
            /// Singleton instance.
            /// </summary>
            private static HtmlEditorViewModelContextMenuBarCreater instance;
            /// <summary>
            /// Singleton instance.
            /// </summary>
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
            public static HtmlEditorViewModelContextMenuBarCreater Instance
            {
                [global::System.Diagnostics.DebuggerStepThrough]
                get
                {
                    if (HtmlEditorViewModelContextMenuBarCreater.instance == null)
                        HtmlEditorViewModelContextMenuBarCreater.instance = new HtmlEditorViewModelContextMenuBarCreater();
                    return HtmlEditorViewModelContextMenuBarCreater.instance;
                }
            }
            #endregion

            #region Constructor
            /// <summary>
            /// Constructor.
            /// </summary>			
            private HtmlEditorViewModelContextMenuBarCreater()
            {
            }
            #endregion			

            /// <summary>
            /// Creates the ribbon menu bar for the html editor.
            /// </summary>
            /// <param name="ribbonMenu">Main ribbon menu.</param>
            public override void CreateRibbonMenuBar(Fluent.Ribbon ribbonMenu)
            {
                foreach (RibbonContextualTabGroup t in ribbonMenu.ContextualGroups)
                    if (t.Name == "tabGroupHtml")
                        return;

                // add contextual items for the html editor
                RibbonContextualTabGroup contextualTG = new RibbonContextualTabGroup();
                contextualTG.Name = "tabGroupHtml";
                contextualTG.BorderBrush = new SolidColorBrush(Colors.Orange);
                contextualTG.Background = new SolidColorBrush(Colors.OrangeRed);
                contextualTG.Header = "Html-Editor";

                Binding visibilityBinding = new Binding("ActiveViewModel.SelectedEditorViewModel.IsHtmlEditorViewModelVisible");
                visibilityBinding.Converter = new BooleanToVisibilityConverter();
                visibilityBinding.Mode = BindingMode.OneWay;
                contextualTG.SetBinding(RibbonContextualTabGroup.VisibilityProperty, visibilityBinding);

                // add the html editor tab item
                RibbonTabItem tab = new RibbonTabItem();
                tab.Group = contextualTG;
                tab.Header = "Design";

                // font group box
                RibbonGroupBox fontGP = new RibbonGroupBox();
                fontGP.Header = "Font";
                tab.Groups.Add(fontGP);

                #region Button Bold
                Fluent.ToggleButton btnBold = new Fluent.ToggleButton();
                btnBold.Margin = new System.Windows.Thickness(2, 0, 0, 0);
                btnBold.SizeDefinition = "Large";
                btnBold.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/format-text-bold-32.png"));
                btnBold.Text = "Bold";

                Binding btnBoldCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlToggleBoldCommand");
                btnBoldCmdn.Mode = BindingMode.OneWay;
                btnBold.SetBinding(Fluent.ToggleButton.CommandProperty, btnBoldCmdn);

                Binding btnBoldIsChecked = new Binding("ActiveViewModel.SelectedEditorViewModel.IsSelectionTextBold");
                btnBoldIsChecked.Mode = BindingMode.TwoWay;
                btnBold.SetBinding(Fluent.ToggleButton.IsCheckedProperty, btnBoldIsChecked);

                fontGP.Items.Add(btnBold);
                #endregion

                #region Button Italic
                Fluent.ToggleButton btnItalic = new Fluent.ToggleButton();
                btnItalic.Margin = new System.Windows.Thickness(2, 0, 0, 0);
                btnItalic.SizeDefinition = "Large";
                btnItalic.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/format-text-italic-32.png"));
                btnItalic.Text = "Italic";

                Binding btnItalicCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlToggleItalicCommand");
                btnItalicCmdn.Mode = BindingMode.OneWay;
                btnItalic.SetBinding(Fluent.ToggleButton.CommandProperty, btnItalicCmdn);

                Binding btnItalicIsChecked = new Binding("ActiveViewModel.SelectedEditorViewModel.IsSelectionTextItalic");
                btnItalicIsChecked.Mode = BindingMode.TwoWay;
                btnItalic.SetBinding(Fluent.ToggleButton.IsCheckedProperty, btnItalicIsChecked);

                fontGP.Items.Add(btnItalic);
                #endregion

                #region Button Underline
                Fluent.ToggleButton btnUnderline = new Fluent.ToggleButton();
                btnUnderline.Margin = new System.Windows.Thickness(2, 0, 0, 0);
                btnUnderline.SizeDefinition = "Large";
                btnUnderline.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/format-text-underline-32.png"));
                btnUnderline.Text = "Underline";

                Binding btnUnderlineCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlToggleUnderlineCommand");
                btnUnderlineCmdn.Mode = BindingMode.OneWay;
                btnUnderline.SetBinding(Fluent.ToggleButton.CommandProperty, btnUnderlineCmdn);

                Binding btnUnderlineIsChecked = new Binding("ActiveViewModel.SelectedEditorViewModel.IsSelectionTextUnderlined");
                btnUnderlineIsChecked.Mode = BindingMode.TwoWay;
                btnUnderline.SetBinding(Fluent.ToggleButton.IsCheckedProperty, btnUnderlineIsChecked);

                fontGP.Items.Add(btnUnderline);
                #endregion

                // format group box
                RibbonGroupBox formatGP = new RibbonGroupBox();
                formatGP.Header = "Format";
                tab.Groups.Add(formatGP);

                #region Button Decrease Indent
                Fluent.Button btnDecIndent = new Fluent.Button();
                btnDecIndent.SizeDefinition = "Large";
                btnDecIndent.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/format-indent-less-32.png"));
                btnDecIndent.Text = "Decrease Indent";

                Binding btnDecIndentCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlIndentLessCommand");
                btnDecIndentCmdn.Mode = BindingMode.OneWay;
                btnDecIndent.SetBinding(Fluent.Button.CommandProperty, btnDecIndentCmdn);

                formatGP.Items.Add(btnDecIndent);
                #endregion

                #region Button Increase Indent
                Fluent.Button btnIncIndent = new Fluent.Button();
                btnIncIndent.SizeDefinition = "Large";
                btnIncIndent.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/format-indent-more-32.png"));
                btnIncIndent.Text = "Increase Indent";

                Binding btnIncIndentCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlIndentMoreCommand");
                btnIncIndentCmdn.Mode = BindingMode.OneWay;
                btnIncIndent.SetBinding(Fluent.Button.CommandProperty, btnIncIndentCmdn);

                formatGP.Items.Add(btnIncIndent);
                #endregion

                // alignment group box
                RibbonGroupBox alignGP = new RibbonGroupBox();
                alignGP.Header = "Alignment";
                tab.Groups.Add(alignGP);

                #region Button Align Left
                Fluent.ToggleButton btnLeft = new Fluent.ToggleButton();
                btnLeft.Margin = new System.Windows.Thickness(2, 0, 0, 0);
                btnLeft.SizeDefinition = "Large";
                btnLeft.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/format-justify-left-32.png"));
                btnLeft.Text = "Left";

                Binding btnLeftCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlAlignLeftCommand");
                btnLeftCmdn.Mode = BindingMode.OneWay;
                btnLeft.SetBinding(Fluent.ToggleButton.CommandProperty, btnLeftCmdn);

                Binding btnLeftIsChecked = new Binding("ActiveViewModel.SelectedEditorViewModel.IsSelectionAlignedLeft");
                btnLeftIsChecked.Mode = BindingMode.TwoWay;
                btnLeft.SetBinding(Fluent.ToggleButton.IsCheckedProperty, btnLeftIsChecked);

                alignGP.Items.Add(btnLeft);
                #endregion

                #region Button Align Center
                Fluent.ToggleButton btnCenter = new Fluent.ToggleButton();
                btnCenter.Margin = new System.Windows.Thickness(2, 0, 0, 0);
                btnCenter.SizeDefinition = "Large";
                btnCenter.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/format-justify-center-32.png"));
                btnCenter.Text = "Center";

                Binding btnCenterCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlAlignCenterCommand");
                btnCenterCmdn.Mode = BindingMode.OneWay;
                btnCenter.SetBinding(Fluent.ToggleButton.CommandProperty, btnCenterCmdn);

                Binding btnCenterIsChecked = new Binding("ActiveViewModel.SelectedEditorViewModel.IsSelectionAlignedCenter");
                btnCenterIsChecked.Mode = BindingMode.TwoWay;
                btnCenter.SetBinding(Fluent.ToggleButton.IsCheckedProperty, btnCenterIsChecked);

                alignGP.Items.Add(btnCenter);
                #endregion

                #region Button Align Right
                Fluent.ToggleButton btnRight = new Fluent.ToggleButton();
                btnRight.Margin = new System.Windows.Thickness(2, 0, 0, 0);
                btnRight.SizeDefinition = "Large";
                btnRight.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/format-justify-right-32.png"));
                btnRight.Text = "Right";

                Binding btnRightCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlAlignRightCommand");
                btnRightCmdn.Mode = BindingMode.OneWay;
                btnRight.SetBinding(Fluent.ToggleButton.CommandProperty, btnRightCmdn);

                Binding btnRightIsChecked = new Binding("ActiveViewModel.SelectedEditorViewModel.IsSelectionAlignedRight");
                btnRightIsChecked.Mode = BindingMode.TwoWay;
                btnRight.SetBinding(Fluent.ToggleButton.IsCheckedProperty, btnRightIsChecked);

                alignGP.Items.Add(btnRight);
                #endregion

                #region Button Align Justify
                Fluent.ToggleButton btnJustify = new Fluent.ToggleButton();
                btnJustify.Margin = new System.Windows.Thickness(2, 0, 0, 0);
                btnJustify.SizeDefinition = "Large";
                btnJustify.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/format-justify-fill-32.png"));
                btnJustify.Text = "Justify";

                Binding btnJustifyCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlAlignJustifyCommand");
                btnJustifyCmdn.Mode = BindingMode.OneWay;
                btnJustify.SetBinding(Fluent.ToggleButton.CommandProperty, btnJustifyCmdn);

                Binding btnJustifyIsChecked = new Binding("ActiveViewModel.SelectedEditorViewModel.IsSelectionAlignedJustified");
                btnJustifyIsChecked.Mode = BindingMode.TwoWay;
                btnJustify.SetBinding(Fluent.ToggleButton.IsCheckedProperty, btnJustifyIsChecked);

                alignGP.Items.Add(btnJustify);
                #endregion

                // insert group box
                RibbonGroupBox insertGP = new RibbonGroupBox();
                insertGP.Header = "Insert";
                tab.Groups.Add(insertGP);

                #region Button Hyperlink
                Fluent.Button btnHyperlink = new Fluent.Button();
                btnHyperlink.SizeDefinition = "Large";
                btnHyperlink.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/Hyperlink.ico"));
                btnHyperlink.Text = "Hyperlink";

                Binding btnHyperlinkCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlInsertHyperlinkCommand");
                btnHyperlinkCmdn.Mode = BindingMode.OneWay;
                btnHyperlink.SetBinding(Fluent.Button.CommandProperty, btnHyperlinkCmdn);

                insertGP.Items.Add(btnHyperlink);
                #endregion

                #region Button Image
                Fluent.Button btnImage = new Fluent.Button();
                btnImage.SizeDefinition = "Large";
                btnImage.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/insert-image-32.png"));
                btnImage.Text = "Image";

                Binding btnImageCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlInsertImageCommand");
                btnImageCmdn.Mode = BindingMode.OneWay;
                btnImage.SetBinding(Fluent.Button.CommandProperty, btnImageCmdn);

                insertGP.Items.Add(btnImage);
                #endregion

                #region Button List
                Fluent.SplitButton btnList = new SplitButton();
                btnList.SizeDefinition = "Large";
                btnList.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/list-32.png"));
                btnList.Text = "List";
                insertGP.Items.Add(btnList);

                Fluent.Button btnBulletedList = new Fluent.Button();
                btnBulletedList.SizeDefinition = "Middle";
                btnBulletedList.Icon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/List_BulletsHS.png"));
                btnBulletedList.Text = "Bulleted List";

                Binding btnBulletedListCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlInsertBulletListCommand");
                btnBulletedListCmdn.Mode = BindingMode.OneWay;
                btnBulletedList.SetBinding(Fluent.Button.CommandProperty, btnBulletedListCmdn);

                btnList.Items.Add(btnBulletedList);

                Fluent.Button btnNumberedList = new Fluent.Button();
                btnNumberedList.SizeDefinition = "Middle";
                btnNumberedList.Icon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/List_NumberedHS.png"));
                btnNumberedList.Text = "Numbered List";

                Binding btnNumberedListCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlInsertNumberListCommand");
                btnNumberedListCmdn.Mode = BindingMode.OneWay;
                btnNumberedList.SetBinding(Fluent.Button.CommandProperty, btnNumberedListCmdn);

                btnList.Items.Add(btnNumberedList);
                #endregion

                #region Button Table
                Fluent.Button btnTable = new Fluent.Button();
                btnTable.SizeDefinition = "Large";
                btnTable.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/HtmlEditor/table-32.png"));
                btnTable.Text = "Table";

                Binding btnTableCmdn = new Binding("ActiveViewModel.SelectedEditorViewModel.HtmlInsertTableCommand");
                btnTableCmdn.Mode = BindingMode.OneWay;
                btnTable.SetBinding(Fluent.Button.CommandProperty, btnTableCmdn);

                insertGP.Items.Add(btnTable);
                #endregion

                ribbonMenu.ContextualGroups.Add(contextualTG);
                ribbonMenu.Tabs.Add(tab);

                /*
                <fluent:RibbonGroupBox Header="Font">
                        <fluent:ToggleButton Text="Bold" Command="{Binding Path=HtmlToggleBoldCommand}" Margin="2,0,0,0" LargeIcon="/Resources/Images/HtmlEditor/format-text-bold-32.png" IsChecked="{Binding Path=IsSelectionTextBold, Mode=TwoWay}" SizeDefinition="Large"/>
                        <fluent:ToggleButton Text="Italic" Command="{Binding Path=HtmlToggleItalicCommand}" Margin="2,0,0,0" LargeIcon="/Resources/Images/HtmlEditor/format-text-italic-32.png" IsChecked="{Binding Path=IsSelectionTextItalic, Mode=TwoWay}" SizeDefinition="Large"/>
                        <fluent:ToggleButton Text="Underline" Command="{Binding Path=HtmlToggleUnderlineCommand}" Margin="2,0,0,0" LargeIcon="/Resources/Images/HtmlEditor/format-text-underline-32.png" IsChecked="{Binding Path=IsSelectionTextUnderlined, Mode=TwoWay}" SizeDefinition="Large"/>
                    </fluent:RibbonGroupBox>

                    <fluent:RibbonGroupBox Header="Format">
                        <fluent:Button Text="Decrease Indent" Command="{Binding Path=HtmlIndentLessCommand}" LargeIcon="/Resources/Images/HtmlEditor/format-indent-less-32.png"  SizeDefinition="Large"/>
                        <fluent:Button Text="Increase Indent" Command="{Binding Path=HtmlIndentMoreCommand}" LargeIcon="/Resources/Images/HtmlEditor/format-indent-more-32.png" SizeDefinition="Large"/>
                    </fluent:RibbonGroupBox>

                    <fluent:RibbonGroupBox Header="Font">
                        <fluent:ToggleButton Text="Left" Command="{Binding Path=HtmlAlignLeftCommand}" Margin="2,0,0,0" LargeIcon="/Resources/Images/HtmlEditor/format-justify-left-32.png" IsChecked="{Binding Path=IsSelectionAlignedLeft, Mode=TwoWay}" SizeDefinition="Large"/>
                        <fluent:ToggleButton Text="Center" Command="{Binding Path=HtmlAlignCenterCommand}" Margin="2,0,0,0" LargeIcon="/Resources/Images/HtmlEditor/format-justify-center-32.png" IsChecked="{Binding Path=IsSelectionAlignedCenter, Mode=TwoWay}" SizeDefinition="Large"/>
                        <fluent:ToggleButton Text="Right" Command="{Binding Path=HtmlAlignRightCommand}" Margin="2,0,0,0" LargeIcon="/Resources/Images/HtmlEditor/format-justify-right-32.png" IsChecked="{Binding Path=IsSelectionAlignedRight, Mode=TwoWay}" SizeDefinition="Large"/>
                        <fluent:ToggleButton Text="Justify" Command="{Binding Path=HtmlAlignJustifyCommand}" Margin="2,0,0,0" LargeIcon="/Resources/Images/HtmlEditor/format-justify-fill-32.png" IsChecked="{Binding Path=IsSelectionAlignedJustified, Mode=TwoWay}" SizeDefinition="Large"/>
                    </fluent:RibbonGroupBox>

                    <fluent:RibbonGroupBox Header="Insert">
                        <fluent:Button Text="Hyperlink" Command="{Binding Path=HtmlInsertHyperlinkCommand}" LargeIcon="/Resources/Images/Ico/Hyperlink.ico"  SizeDefinition="Large"/>
                        <fluent:Button Text="Image" Command="{Binding Path=HtmlInsertImageCommand}" LargeIcon="/Resources/Images/HtmlEditor/insert-image-32.png" SizeDefinition="Large"/>
                        <fluent:SplitButton Text="List" LargeIcon="/Resources/Images/HtmlEditor/list-32.png" SizeDefinition="Large">
                            <fluent:Button Text="Bulleted List" Command="{Binding Path=HtmlInsertBulletListCommand}" Icon="/Resources/Images/HtmlEditor/List_BulletsHS.png" SizeDefinition="Middle"/>
                            <fluent:Button Text="Numbered List" Command="{Binding Path=HtmlInsertNumberListCommand}" Icon="/Resources/Images/HtmlEditor/List_NumberedHS.png" SizeDefinition="Middle"/>
                        </fluent:SplitButton>
                        <fluent:Button Text="Table" Command="{Binding Path=HtmlInsertTableCommand}" LargeIcon="/Resources/Images/HtmlEditor/table-32.png" SizeDefinition="Large"/>
                    </fluent:RibbonGroupBox>
                */
            }
        }
        #endregion
    }
}

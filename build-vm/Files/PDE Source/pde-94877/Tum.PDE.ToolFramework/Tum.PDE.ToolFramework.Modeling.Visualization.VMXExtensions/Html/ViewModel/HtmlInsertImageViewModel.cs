using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

using System.IO;
using System.Windows.Media.Imaging;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel
{
    /// <summary>
    /// View model to insert images.
    /// </summary>
    public class HtmlInsertImageViewModel : BaseWindowViewModel
    {
        /// <summary>
        /// Directory to store images.
        /// </summary>
        public const string ImageDirectory = "images";

        private string title;

        private string referencePath;
        private string sourcePath;
        private string relativePath;
        private string alternativeText;
        private string imageId;

        private double? exportWidth;
        private double? exportHeight;

        private bool isInsertionValid = false;

        private DelegateCommand browseCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="referencePath">Reference path.</param>
        public HtmlInsertImageViewModel(ViewModelStore viewModelStore, string referencePath)
            : base(viewModelStore)
        {
            this.referencePath = referencePath;
            this.title = "Insert/Modify image";

            browseCommand = new DelegateCommand(BrowseCommand_Executed);
        }

        /// <summary>
        /// Gets or sets the title of the view model.
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the source path of the image.
        /// </summary>
        public string SourcePath
        {
            get
            {
                return sourcePath;
            }
            set
            {
                sourcePath = value;
                OnPropertyChanged("SourcePath");
            }
        }

        /// <summary>
        /// Gets or sets the relative path of the image.
        /// </summary>
        public string RelativePath
        {
            get
            {
                return relativePath;
            }
            set
            {
                relativePath = value;
                OnPropertyChanged("RelativePath");
            }

        }

        /// <summary>
        /// Gets or sets the alternative text of the image.
        /// </summary>
        public string AlternativeText
        {
            get
            {
                return alternativeText;
            }
            set
            {
                alternativeText = value;
                OnPropertyChanged("AlternativeText");
            }
        }

        /// <summary>
        /// Gets or sets the id of the image.
        /// </summary>
        public string ImageId
        {
            get
            {
                if (imageId == null)
                {
                    imageId = KeyGenerator.Instance.ConvertGuidToVModellID(this.ViewModelStore.GetDomainModelServices().ElementIdProvider.GenerateNewKey());
                }
                return imageId;
            }
            set
            {
                imageId = value;
                OnPropertyChanged("ImageId");
            }
        }

        /// <summary>
        /// Gets or sets the export width.
        /// </summary>
        public double? ExportWidth
        {
            get
            {
                return exportWidth;
            }
            set
            {
                exportWidth = value;
                OnPropertyChanged("ExportWidth");
            }
        }

        /// <summary>
        /// Gets or sets the export height.
        /// </summary>
        public double? ExportHeight
        {
            get
            {
                return exportHeight;
            }
            set
            {
                exportHeight = value;
                OnPropertyChanged("ExportHeight");
            }
        }

        /// <summary>
        /// Gets or sets whether the current insertion information valid or not.
        /// </summary>
        public bool IsInsertionValid
        {
            get
            {
                return isInsertionValid;
            }
            set
            {
                isInsertionValid = value;
                OnPropertyChanged("IsInsertionValid");
            }
        }

        /// <summary>
        /// Browse command.
        /// </summary>
        public DelegateCommand BrowseCommand
        {
            get
            {
                return browseCommand;
            }
        }

        /// <summary>
        /// Browse command executed.
        /// </summary>
        private void BrowseCommand_Executed()
        {
            IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
            IOpenFileService openFileService = this.GlobalServiceProvider.Resolve<IOpenFileService>();
            openFileService.Filter = "Image files (png, jpeg, gif)|*.png;*.jpg;*.jpeg;*.gif";
            if (openFileService.ShowDialog(null) == true)
            {
                // copy to images folder
                try
                {
                    string targetImagesDirectory = this.referencePath + "\\" + ImageDirectory;

                    // see if images directory exists
                    if (!Directory.Exists(targetImagesDirectory))
                        Directory.CreateDirectory(targetImagesDirectory);

                    // see if image is already in directory
                    FileInfo info = new FileInfo(openFileService.FileName);
                    if (info.DirectoryName == targetImagesDirectory)
                    {
                        // no need to do anything...
                    }
                    else
                    {
                        // see if file with the same name already exists
                        if (File.Exists(targetImagesDirectory + "\\" + info.Name))
                        {
                            if (messageBox.ShowYesNo("File " + info.Name + " already exists in " + targetImagesDirectory + ". Inserting the image would override the existing file. Do you want to continue?", CustomDialogIcons.Question) == CustomDialogResults.No)
                                return;
                        }
                    }

                    SourcePath = openFileService.FileName;
                    RelativePath = "images/" + info.Name;

                    this.IsInsertionValid = true;
                }
                catch (Exception ex)
                {
                    messageBox.ShowError("Error while inserting image: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Windows closing.
        /// </summary>
        public override void RaiseCloseRequest(bool? dialogResult)
        {
            if (dialogResult == true)
            {
                try
                {
                    string targetImagesDirectory = this.referencePath + "\\" + ImageDirectory;

                    FileInfo info = new FileInfo(SourcePath);
                    if (info.DirectoryName != targetImagesDirectory)
                    {
                        // we need to copy this file
                        File.Copy(SourcePath, targetImagesDirectory + "\\" + info.Name, true);
                    }

                }
                catch (Exception ex)
                {
                    IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
                    messageBox.ShowError("Error while inserting image: " + ex.Message);
                }
            }

            base.RaiseCloseRequest(dialogResult);
        }
    }
}

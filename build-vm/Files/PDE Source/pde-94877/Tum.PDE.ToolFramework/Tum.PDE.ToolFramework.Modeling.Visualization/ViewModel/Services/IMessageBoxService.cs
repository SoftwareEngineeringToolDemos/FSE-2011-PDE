using System;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services
{
    /// <summary>
    /// Available Button options. 
    /// Abstracted to allow some level of UI Agnosticness
    /// </summary>
    public enum CustomDialogButtons
    {
        /// <summary>
        /// Ok button.
        /// </summary>
        OK,

        /// <summary>
        /// Ok, Cancel buttons.
        /// </summary>
        OKCancel,

        /// <summary>
        /// Yes, No buttons.
        /// </summary>
        YesNo,

        /// <summary>
        /// Yes, No and Cancel buttons.
        /// </summary>
        YesNoCancel
    }

    /// <summary>
    /// Available Icon options.
    /// Abstracted to allow some level of UI Agnosticness
    /// </summary>
    public enum CustomDialogIcons
    {
        /// <summary>
        /// No icon.
        /// </summary>
        None,

        /// <summary>
        /// Information icon.
        /// </summary>
        Information,

        /// <summary>
        /// Question icon.
        /// </summary>
        Question,

        /// <summary>
        /// Exclamation icon.
        /// </summary>
        Exclamation,

        /// <summary>
        /// Stop icon.
        /// </summary>
        Stop,

        /// <summary>
        /// Warning icon.
        /// </summary>
        Warning
    }

    /// <summary>
    /// Available DialogResults options.
    /// Abstracted to allow some level of UI Agnosticness
    /// </summary>
    public enum CustomDialogResults
    {
        /// <summary>
        /// No dialog result.
        /// </summary>
        None,

        /// <summary>
        /// OK result.
        /// </summary>
        OK,

        /// <summary>
        /// Cancel result.
        /// </summary>
        Cancel,

        /// <summary>
        /// Yes result.
        /// </summary>
        Yes,

        /// <summary>
        /// No result.
        /// </summary>
        No
    }

    /// <summary>
    /// This interface defines a interface that will allow 
    /// a ViewModel to show a messagebox
    /// </summary>
    /// <remarks>
    /// From the Cinch framework by Sacha Barber: http://cinch.codeplex.com/
    /// </remarks>
    public interface IMessageBoxService
    {
        /// <summary>
        /// Shows an error message
        /// </summary>
        /// <param name="message">The error message</param>
        void ShowError(string message);

        /// <summary>
        /// Shows an information message
        /// </summary>
        /// <param name="message">The information message</param>
        void ShowInformation(string message);

        /// <summary>
        /// Shows an warning message
        /// </summary>
        /// <param name="message">The warning message</param>
        void ShowWarning(string message);

        /// <summary>
        /// Displays a Yes/No dialog and returns the user input.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="icon">The icon to be displayed.</param>
        /// <returns>User selection.</returns>
        CustomDialogResults ShowYesNo(string message, CustomDialogIcons icon);

        /// <summary>
        /// Displays a Yes/No/Cancel dialog and returns the user input.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="icon">The icon to be displayed.</param>
        /// <returns>User selection.</returns>
        CustomDialogResults ShowYesNoCancel(string message, CustomDialogIcons icon);

        /// <summary>
        /// Displays a OK/Cancel dialog and returns the user input.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="icon">The icon to be displayed.</param>
        /// <returns>User selection.</returns>
        CustomDialogResults ShowOkCancel(string message, CustomDialogIcons icon);

    }
}

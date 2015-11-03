using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Behaviors
{
    /// <summary>
    /// Textbox behavior for the enter key: Enter key in the active textbox specifies the
    /// end of the editing process.
    /// </summary>
    public class TextBoxEnterBehavior : Behavior<TextBox>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.KeyDown += new System.Windows.Input.KeyEventHandler(AssociatedObject_KeyDown);
        }

        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.KeyDown -= new System.Windows.Input.KeyEventHandler(AssociatedObject_KeyDown);

            base.OnDetaching();
        }

        void AssociatedObject_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (this.AssociatedObject.IsFocused)
            {
                if (e.Key == System.Windows.Input.Key.Enter)
                {
                    // clear focus
                    Keyboard.ClearFocus();

                    // update text property
                    var bindingExpression = this.AssociatedObject.GetBindingExpression(TextBox.TextProperty);
                    bindingExpression.UpdateSource();
                }   
            }
        }
    }
}

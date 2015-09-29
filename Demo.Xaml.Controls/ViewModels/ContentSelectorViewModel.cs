using System;

using Xamarin.Forms;
using System.Windows.Input;

namespace Demo.Xaml.Controls
{
    /// <summary>
    /// Content selector view model.
    /// </summary>
    public class ContentSelectorViewModel : ViewModelBase
    {
        object bindingContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Demo.Xaml.Controls.ContentSelectorViewModel"/> class.
        /// </summary>
        public ContentSelectorViewModel()
        {
            ChangeBindingContextCommand = new Command(() =>
                {
                    if (BindingContext is int)
                        BindingContext = "Hello, World!";
                    else
                        BindingContext = 666;
                });

            ChangeBindingContextCommand.Execute(null);
        }

        /// <summary>
        /// Gets or sets the binding context for.
        /// </summary>
        /// <value>The binding context.</value>
        public object BindingContext
        {
            get { return bindingContext; }
            set
            {
                if (bindingContext == value)
                    return;
                bindingContext = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The command to change the binding context.
        /// </summary>
        public ICommand ChangeBindingContextCommand { get; private set; }
    }
}



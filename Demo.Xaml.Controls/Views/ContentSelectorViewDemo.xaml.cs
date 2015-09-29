using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Demo.Xaml.Controls
{
    /// <summary>
    /// Content selector view demo.
    /// </summary>
    public partial class ContentSelectorViewDemo : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Demo.Xaml.Controls.ContentSelectorViewDemo"/> class.
        /// </summary>
        public ContentSelectorViewDemo()
        {
            InitializeComponent();

            BindingContext = new ContentSelectorViewModel();
        }
    }
}


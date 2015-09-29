using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Demo.Xaml.Controls
{
    /// <summary>
    /// View selector list view demo.
    /// </summary>
    public partial class ViewSelectorListViewDemo : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Demo.Xaml.Controls.ViewSelectorListViewDemo"/> class.
        /// </summary>
        public ViewSelectorListViewDemo()
        {
            InitializeComponent();
            selectorList.ItemsSource = new object[]
                {
                    "Hello, World!",
                    666,
                    new object()
                };
        }
    }
}


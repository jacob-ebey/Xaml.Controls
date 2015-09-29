using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Demo.Xaml.Controls
{
    /// <summary>
    /// The home page that has a list of all the control demos.
    /// </summary>
    public partial class HomePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Demo.Xaml.Controls.HomePage"/> class.
        /// </summary>
        public HomePage()
        {
            InitializeComponent();

            BindingContext = PagesToDemo;
        }

        /// <summary>
        /// Occurs when an item in the list is selected.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Get the selected vm from the list.
            PageViewModel vm = e.SelectedItem as PageViewModel;

            // Navigate to the page if it is not null.
            if (vm != null)
            {
                Navigation.PushAsync(vm.PageCreator.Invoke());
            }

            // Get the list and deselect the item.
            var listView = sender as ListView;

            if (listView != null)
                listView.SelectedItem = null;
        }

        /// <summary>
        /// The pages to demo.
        /// </summary>
        static PageViewModel[] PagesToDemo { get; } = new PageViewModel[]
            {
                new PageViewModel("ContentSelectorView Demo", () => new ContentSelectorViewDemo()),
                new PageViewModel("ViewSelectorListView Demo", () => new ViewSelectorListViewDemo())
            };
    }
}


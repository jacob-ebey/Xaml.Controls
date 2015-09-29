using System;

using Xamarin.Forms;

namespace Xaml.Controls
{
    /// <summary>
    /// This control is used to select a view based on the BindingContext.
    /// When the BindingContext changes the ViewCreatorProvider is used to
    /// create the view. If the ViewCreatorProvider is not set, then the
    /// virtual method GetDefaultView is used to create the view.
    /// </summary>
    public class ContentSelectorView : ContentView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Xaml.Controls.ContentSelectorView"/> class.
        /// </summary>
        public ContentSelectorView()
        {
        }

        /// <summary>
        /// Gets or sets the view creator provider. If this is null the virtual method <see cref="Xaml.Controls.ViewSelectorListView.GetDefaultView"/>.
        /// </summary>
        /// <value>The view creator provider.</value>
        public IProvideViewCreators ViewCreatorProvider
        {
            get { return (IProvideViewCreators)GetValue(ViewCreatorProviderProperty); }
            set { SetValue(ViewCreatorProviderProperty, value); }
        }

        /// <summary>
        /// Gets the default view.
        /// </summary>
        /// <returns>The default view.</returns>
        /// <param name="o">The object the view will represent.</param>
        protected virtual View GetDefaultView(object o) { return null; }

        /// <summary>
        /// Gets the view for object.
        /// </summary>
        /// <returns>The view for object.</returns>
        /// <param name="o">The object to get the view for.</param>
        private View GetViewForObject(object o)
        {
            Func<object, View> viewCreator = ViewCreatorProvider?.GetViewCreator(o) ?? GetDefaultView;
            return viewCreator?.Invoke(o);
        }

        /// <summary>
        /// Override this method to execute an action when the BindingContext changes.
        /// </summary>
        /// <remarks></remarks>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            Content = GetViewForObject(BindingContext);
        }

        /// <summary>
        /// Gets the view creator provider property.
        /// </summary>
        /// <value>The view creator provider property.</value>
        public static BindableProperty ViewCreatorProviderProperty { get; } = BindableProperty.Create<ContentSelectorView, IProvideViewCreators>(
            o => o.ViewCreatorProvider,
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                (bindable as ContentSelectorView).ViewCreatorProvider = newValue;
            });
    }
}



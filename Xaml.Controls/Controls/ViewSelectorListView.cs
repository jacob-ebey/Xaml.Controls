using System;

using Xamarin.Forms;
using System.Collections;
using System.Collections.Specialized;

namespace Xaml.Controls
{
    /// <summary>
    /// This control is used to display information from an ItemsSource where
    /// the way the info needs to be display can differ for each item.
    /// </summary>
    public class ViewSelectorListView : ContentView
    {
        readonly StackLayout stackLayout;

        /// <summary>
        /// Initializes a new instance of the <see cref="Xaml.Controls.ViewSelectorListView"/> class.
        /// </summary>
        public ViewSelectorListView()
        {
            Content = stackLayout = new StackLayout();
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public StackOrientation Orientation
        {
            get { return (StackOrientation)GetValue(OrientationProperty); }
            set
            {
                SetValue(OrientationProperty, value);

                stackLayout.Orientation = value;
            }
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
        /// Gets or sets the source of items to template and display.
        /// </summary>
        /// <value>The items source.</value>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set
            {
                OnItemsSourceChanging();
                SetValue(ItemsSourceProperty, value);
                OnItemsSourceChanged();
            }
        }

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

        private void OnItemsSourceColectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                int offset = e.NewStartingIndex;
                foreach (var item in e.NewItems)
                    stackLayout.Children.Insert(offset++, GetViewForObject(item));
            }
            else if (e.Action == NotifyCollectionChangedAction.Move)
            {
                var viewToMove = stackLayout.Children[e.OldStartingIndex];
                stackLayout.Children.Insert(e.NewStartingIndex, viewToMove);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                stackLayout.Children.RemoveAt(e.OldStartingIndex);
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                stackLayout.Children[e.NewStartingIndex] = GetViewForObject(e.NewItems[0]);
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                stackLayout.Children.Clear();
            }
        }

        /// <summary>
        /// Gets the default view.
        /// </summary>
        /// <returns>The default view.</returns>
        /// <param name="o">The object the view will represent.</param>
        protected virtual View GetDefaultView(object o) { return null; }

        /// <summary>
        /// Raises the items source changing event.
        /// </summary>
        protected virtual void OnItemsSourceChanging()
        {
            ItemsSourceChanging?.Invoke(this, new EventArgs());

            INotifyCollectionChanged collectionChangedNotifier = ItemsSource as INotifyCollectionChanged;

            if (collectionChangedNotifier != null)
                collectionChangedNotifier.CollectionChanged -= OnItemsSourceColectionChanged;
        }

        /// <summary>
        /// Raises the items source changed event.
        /// </summary>
        protected virtual void OnItemsSourceChanged()
        {
            ItemsSourceChanged?.Invoke(this, new EventArgs());

            INotifyCollectionChanged collectionChangedNotifier = ItemsSource as INotifyCollectionChanged;

            if (collectionChangedNotifier != null)
                collectionChangedNotifier.CollectionChanged += OnItemsSourceColectionChanged;
        }

        /// <summary>
        /// Occurs when items source is about to change.
        /// </summary>
        public event EventHandler ItemsSourceChanging;

        /// <summary>
        /// Occurs when <see cref="Xaml.Controls.ViewSelectorListView.ItemsSource"/> changed.
        /// </summary>
        public event EventHandler ItemsSourceChanged;

        /// <summary>
        /// Gets the orientation property.
        /// </summary>
        /// <value>The orientation property.</value>
        public static BindableProperty OrientationProperty { get; } = BindableProperty.Create<ViewSelectorListView, StackOrientation>(
            o => o.Orientation,
            defaultValue: StackOrientation.Vertical,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                (bindable as ViewSelectorListView).Orientation = newValue;
            });

        /// <summary>
        /// Gets the view creator provider property.
        /// </summary>
        /// <value>The view creator provider property.</value>
        public static BindableProperty ViewCreatorProviderProperty { get; } = BindableProperty.Create<ViewSelectorListView, IProvideViewCreators>(
            o => o.ViewCreatorProvider,
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                (bindable as ViewSelectorListView).ViewCreatorProvider = newValue;
            });

        /// <summary>
        /// Gets the items source property.
        /// </summary>
        /// <value>The items source property.</value>
        public static BindableProperty ItemsSourceProperty { get; } = BindableProperty.Create<ViewSelectorListView, IEnumerable>(
            o => o.ItemsSource,
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                (bindable as ViewSelectorListView).ItemsSource = newValue;
            });
    }
}


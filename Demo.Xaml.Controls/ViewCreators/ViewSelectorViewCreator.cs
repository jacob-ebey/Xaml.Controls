using System;

using Xamarin.Forms;

using Xaml.Controls;

namespace Demo.Xaml.Controls
{
    /// <summary>
    /// View selector view creator.
    /// </summary>
    public class ViewSelectorViewCreator : IProvideViewCreators
    {
        /// <summary>
        /// Gets the view creator for the provided item.
        /// </summary>
        /// <returns>The view creator.</returns>
        /// <param name="item">The item to check to get the correct view creator.</param>
        public Func<object, View> GetViewCreator(object item)
        {
            if (item is int)
                return o =>
                {
                    return new Label { Text = $"The item was an int of value: {o}" };
                };
            if (item is string)
                return o =>
                {
                    return new Label { Text = $"The item was a string of value: {o}" };
                };

            return o =>
            {
                return new Label { Text = "The object type was unknown." };
            };
        }
    }
}


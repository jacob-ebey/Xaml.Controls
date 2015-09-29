using System;

using Xamarin.Forms;
using Xaml.Controls;

namespace Demo.Xaml.Controls
{
    /// <summary>
    /// Content selector view creator.
    /// </summary>
    public class ContentSelectorViewCreator : IProvideViewCreators
    {
        /// <summary>
        /// Gets the view creator for the provided item.
        /// </summary>
        /// <returns>The view creator.</returns>
        /// <param name="item">The item to check to get the correct view creator.</param>
        public Func<object, View> GetViewCreator(object item)
        {
            // If the item is a string
            if (item is string)
                return o =>
                {
                    return new Label { Text = $"The binding context is a string with the value of: {o}" };
                };

            // If the item is an int
            if (item is int)
                return o =>
                {
                    return new Label { Text = $"The binding context is an int with the value of: {o}" };
                };

            // Return null if no known condition is met
            return null;
        }
    }
}



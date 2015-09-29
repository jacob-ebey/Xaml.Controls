using System;

using Xamarin.Forms;

namespace Xaml.Controls
{
    /// <summary>
    /// This interface provides a means of geting a Func to generate a view from an item.
    /// The item is also provided to <see cref="Xaml.Controls.IProvideViewCreators.GetViewCreator"/> to select
    /// the proper view creator for the item.
    /// </summary>
    public interface IProvideViewCreators
    {
        /// <summary>
        /// Gets the view creator for the provided item.
        /// </summary>
        /// <returns>The view creator.</returns>
        /// <param name="item">The item to check to get the correct view creator.</param>
        Func<object, View> GetViewCreator(object item);
    }
}



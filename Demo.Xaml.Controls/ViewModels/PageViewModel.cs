using System;
using Xamarin.Forms;

namespace Demo.Xaml.Controls
{
    /// <summary>
    /// This view model is used to associate a page with a label.
    /// </summary>
    public class PageViewModel : ViewModelBase
    {
        string label;
        Func<Page> pageCreator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Demo.Xaml.Controls.PageViewModel"/> class.
        /// </summary>
        /// <param name="label">The label of the page.</param>
        /// <param name="page">The page to give a label to.</param>
        public PageViewModel(string label, Func<Page> pageCreator)
        {
            if (string.IsNullOrWhiteSpace(label))
                throw new ArgumentOutOfRangeException($"{nameof(label)} is null, empty or whitespace.");
            if (pageCreator == null)
                throw new ArgumentNullException(nameof(pageCreator));
            
            this.label = label;
            this.pageCreator = pageCreator;
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label
        {
            get { return label; }
            set
            {
                if (label == value)
                    return;
                label = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>The page.</value>
        public Func<Page> PageCreator
        {
            get { return pageCreator; }
            set
            {
                if (pageCreator == value)
                    return;
                pageCreator = value;
                OnPropertyChanged();
            }
        }
    }
}


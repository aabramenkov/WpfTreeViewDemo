using System;
using System.Windows;
using System.Windows.Media;
using TreeView.Common;
using TreeView.Models;

namespace TreeView.ViewModels {

    /// <summary>
    /// View Model for Category. 
    /// </summary>
    public class CategoryViewModel : TreeViewItemViewModel{
        private Category _category;
        
        public CategoryViewModel(Category category):base(null) {
            _category = category;
            foreach (var item in _category.Items) {
                base.Children.Add(new ItemViewModel(item,this));
            }
        }

        public string Name => _category.Name;

        /// <summary>
        /// Main filter.
        /// </summary>
        /// <param name="filterValue"></param>

        public override void ApplyFilter(string filterValue) {
            if (String.IsNullOrEmpty(filterValue)) {
                base.IsExpanded = false;
                base.Foreground = Brushes.Black;
                base.IsVisible = Visibility.Visible;
            }
            else {
                if (_category.Name.Contains(filterValue, StringComparison.OrdinalIgnoreCase)) {
                    base.InFilter = true;
                    base.IsExpanded = true;
                    base.Foreground = Brushes.Green;
                }
                else {
                    base.InFilter = false;
                    base.IsVisible = Visibility.Collapsed;
                    base.Foreground = Brushes.Black;
                }
            }
            foreach (ItemViewModel itm in Children) {
                itm.ApplyFilter(filterValue);
            }


        }
    }
}

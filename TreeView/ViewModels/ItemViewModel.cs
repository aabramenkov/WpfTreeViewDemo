using System;
using System.Windows;
using System.Windows.Media;
using TreeView.Common;
using TreeView.Models;

namespace TreeView.ViewModels {
    /// <summary>
    /// View Model for Item
    /// </summary>
    public class ItemViewModel : TreeViewItemViewModel {
        private Item _item;

        public ItemViewModel(Item item, CategoryViewModel parent)
            :base (parent) {

            _item = item;
        }

        public string Name => _item.Name;

        /// <summary>
        /// Main filter.
        /// Set View visibility, foreground 
        /// Note: i have to check parent's InFilter property and change parents IsExpanded
        /// </summary>
        /// <param name="filterValue"></param>
        public override void ApplyFilter(string filterValue) {
            if (string.IsNullOrEmpty(filterValue)) {
                base.Foreground = Brushes.Black;
                base.IsVisible = Visibility.Visible;
                return;
            }

            if ( _item.Name.Contains(filterValue, StringComparison.OrdinalIgnoreCase)) {
                base.Foreground = Brushes.Green;
                Parent.IsVisible = Visibility.Visible;
                Parent.IsExpanded = true;
                base.IsVisible = Visibility.Visible;
            }
            else { 
                if (!Parent.InFilter){ 
                base.IsVisible = Visibility.Collapsed;
                base.Foreground = Brushes.Black;
                }
            }

        }
    }
}

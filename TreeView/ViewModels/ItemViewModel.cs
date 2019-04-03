using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TreeView.Models;

namespace TreeView.ViewModels {
    public class ItemViewModel : TreeViewItemViewModel {
        private Item _item;

        public ItemViewModel(Item item, CategoryViewModel parent)
            :base (parent) {

            _item = item;
        }

        public string Name => _item.Name;

        public override void ApplyFilter(string filterValue) {
            if ( _item.Name.Contains(filterValue)) {
                base.Foreground = Brushes.Green;
                Parent.IsVisible = Visibility.Visible;
                Parent.IsExpanded = true;
                base.IsVisible = Visibility.Visible;
            }
            else { 
                base.IsVisible = Visibility.Collapsed;
                base.Foreground = Brushes.Black;
            }

        }
    }
}

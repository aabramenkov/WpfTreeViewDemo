using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TreeView.Models;

namespace TreeView.ViewModels {
    public class ItemViewModel : TreeViewItemViewModel {
        private Item _item;

        public ItemViewModel(Item item, CategoryViewModel parent)
            :base (parent, false) {

            _item = item;
        }

        public string Name => _item.Name;

    }
}

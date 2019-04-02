using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TreeView.DataAccess;
using TreeView.Models;

namespace TreeView.ViewModels {
    public class CategoryViewModel : TreeViewItemViewModel{
        private Category _category;
        
        public CategoryViewModel(Category category):base(null,true) {
            _category = category;
            
        }

        public string Name => _category.Name;

        protected override void LoadChildren() {
            foreach (Item item in Database.GetItems(_category))
                base.Childrens.Add(new ItemViewModel(item, this));
        }
    }
}

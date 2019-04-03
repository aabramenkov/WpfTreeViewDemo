using System.Windows;
using System.Windows.Media;
using Microsoft.Practices.ObjectBuilder2;
using TreeView.Models;

namespace TreeView.ViewModels {
    public class CategoryViewModel : TreeViewItemViewModel{
        private Category _category;
        
        public CategoryViewModel(Category category):base(null) {
            _category = category;
            foreach (var item in _category.Items) {
                base.Childrens.Add(new ItemViewModel(item,this));
            }
        }

        public string Name => _category.Name;


        public override void ApplyFilter(string filterValue) {
            if (_category.Name.Contains(filterValue)) {
                base.IsExpanded = true;
                RaisePropertyChanged(nameof(IsExpanded));

                base.Foreground = Brushes.Green;
                RaisePropertyChanged(nameof(Foreground));
            }else {
                base.IsVisible = Visibility.Collapsed;
                base.Foreground = Brushes.Black;
            }

            foreach (ItemViewModel itm in Childrens) {
                itm.ApplyFilter(filterValue);
            }
        }


}
}

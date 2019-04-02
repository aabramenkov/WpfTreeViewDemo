using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace TreeView.ViewModels {
    /// <summary>
    /// Base class for all ViewModel classes displayed by TreeViewItems.  
    /// This acts as an adapter between a raw data object and a TreeViewItem.
    /// </summary>
    public class TreeViewItemViewModel :BindableBase {

       #region Data

       static readonly TreeViewItemViewModel DummyChild = new TreeViewItemViewModel();

       readonly ObservableCollection<TreeViewItemViewModel> _childrens;
       readonly TreeViewItemViewModel _parent;

       bool _isExpanded;
       bool _isSelected;

        #endregion // Data

       #region Ctor

       protected TreeViewItemViewModel(TreeViewItemViewModel parent, bool lazyLoadChildren) {
           _parent = parent;

           _childrens = new ObservableCollection<TreeViewItemViewModel>();

           if (lazyLoadChildren)
               _childrens.Add(DummyChild);
       }

       // This is used to create the DummyChild instance.
       private TreeViewItemViewModel() {
       }
        #endregion // Ctor

       /// <summary>
        /// Returns the logical child items of this object.
        /// </summary>
        public ObservableCollection<TreeViewItemViewModel> Childrens => _childrens;

        /// <summary>
        /// Returns true if this object's Children have not yet been populated.
        /// </summary>
        public bool HasDummyChild =>
            Childrens.Count == 1 && Childrens[0] == DummyChild; 

  
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded {
            get => _isExpanded; 
            set {
                if (value != _isExpanded) {
                    _isExpanded = value;
                    RaisePropertyChanged(nameof(IsExpanded));
                }

                // Expand all the way up to the root.
                if (_isExpanded && _parent != null)
                    _parent.IsExpanded = true;

                // Lazy load the child items, if necessary.
                if (HasDummyChild) {
                    Childrens.Remove(DummyChild);
                    LoadChildren();
                }
            }
        }

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected {
            get => _isSelected; 
            set {
                if (value != _isSelected) {
                    _isSelected = value;
                    RaisePropertyChanged(nameof(IsSelected));
                }
            }
        }

        /// <summary>
        /// Invoked when the child items need to be loaded on demand.
        /// Subclasses can override this to populate the Children collection.
        /// </summary>
        protected virtual void LoadChildren() { }

        public TreeViewItemViewModel Parent => _parent;
   
    }
}

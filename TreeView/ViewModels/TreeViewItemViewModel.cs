using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using Prism.Mvvm;

namespace TreeView.ViewModels {
    /// <summary>
    /// Base class for all ViewModel classes displayed by TreeViewItems.  
    /// This acts as an adapter between a raw data object and a TreeViewItem.
    /// </summary>
    public class TreeViewItemViewModel :BindableBase {

       #region Data

       readonly ObservableCollection<TreeViewItemViewModel> _children;
       readonly TreeViewItemViewModel _parent;

        private bool _isExpanded;
        private bool _isSelected;
        private Visibility _isVisible;
        private Brush _foreground =Brushes.Black;
        private bool _inFilter;

        #endregion // Data

       #region Ctor

       protected TreeViewItemViewModel(TreeViewItemViewModel parent) {
           _parent = parent;

           _children = new ObservableCollection<TreeViewItemViewModel>();
       }
        public TreeViewItemViewModel Parent => _parent;

        #endregion //Ctor

        #region Properties

        /// <summary>
        /// Returns the logical child items of this object.
        /// </summary>
        public ObservableCollection<TreeViewItemViewModel> Children => _children;

        
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded {
            get => _isExpanded; 
            set {
                if (value != _isExpanded) {
                    SetProperty(ref _isExpanded, value);
                }

                // Expand all the way up to the root.
                if (_isExpanded && _parent != null)
                    _parent.IsExpanded = true;
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
                    SetProperty(ref _isSelected,value);
                }
            }
        }
        /// <summary>
        /// Gets/sets whether the TreeViewItem
        /// associated with this object is visible
        /// </summary>
        public Visibility IsVisible {
            get => _isVisible;
            set {
                if (value != _isVisible) {
                    SetProperty(ref _isVisible,value);
                }
            }
        }
        /// <summary>
        /// Gets/sets whether this object meets filter conditions
        /// </summary>
        public bool InFilter {
            get => _inFilter;
            set => SetProperty(ref _inFilter, value);
        }
        
    /// <summary>
    /// Gets/sets TreeViewItem associated with this object foreground color
    /// </summary>
        public Brush Foreground {
            get => _foreground;
            set {
                if (value != _foreground) {
                    SetProperty(ref _foreground,value);
                }
            }
        }

        #endregion //Properties

        #region Methods
        /// <summary>
        /// This method should be override in inherited classes
        /// </summary>
        /// <param name="filterValue"></param>
        public virtual void ApplyFilter(string filterValue) {
        }

        #endregion //Methods
    }
}

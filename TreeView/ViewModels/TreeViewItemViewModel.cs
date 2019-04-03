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

       readonly ObservableCollection<TreeViewItemViewModel> _childrens;
       readonly TreeViewItemViewModel _parent;

       bool _isExpanded;
       bool _isSelected;
       Visibility _isVisible;
       Brush _foregraund=Brushes.Black;

        #endregion // Data

       #region Ctor

       protected TreeViewItemViewModel(TreeViewItemViewModel parent) {
           _parent = parent;

           _childrens = new ObservableCollection<TreeViewItemViewModel>();
       }
        public TreeViewItemViewModel Parent => _parent;

        #endregion //Ctor

        /// <summary>
        /// Returns the logical child items of this object.
        /// </summary>
        public ObservableCollection<TreeViewItemViewModel> Childrens => _childrens;

        
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

        public Visibility IsVisible {
            get => _isVisible;
            set {
                if (value != _isVisible) {
                    _isVisible = value;
                    RaisePropertyChanged(nameof(IsVisible));
                }
            }
        }

        public Brush Foreground {
            get => _foregraund;
            set {
                if (value != _foregraund) {
                    _foregraund = value;
                    RaisePropertyChanged(nameof(Foreground));
                } }
        }
        public virtual void ApplyFilter(string filterValue) {
        }

    }
}

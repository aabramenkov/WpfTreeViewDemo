using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using TreeView.DataAccess;
using TreeView.Models;

namespace TreeView.ViewModels {

    /// <summary>
    /// The ViewModel for the LoadOnDemand demo.  This simply
    /// exposes a read-only collection of regions.
    /// </summary>
    public class TreeView_ViewModel : BindableBase {
        #region Data
        private ObservableCollection<CategoryViewModel> _categories;
        private string _textFilterValue;
        private Database _db;
        private bool _isFilterReadOnly=false; 
        #endregion //Data

        #region Ctor
        public TreeView_ViewModel(Database db) {
            _db=db;
            _categories = new ObservableCollection<CategoryViewModel>();
            LoadCommand=new DelegateCommand(OnLoad,()=>true);
            SetFilterReadOnly = new DelegateCommand(OnSetFilterReadOnly,()=>true);
            SetFilterNotReadOnly=new DelegateCommand(OnSetFilterNotReadOnly,()=>true);
        }
        #endregion //Ctor

        public ObservableCollection<CategoryViewModel> Categories => _categories;

        public string TextFilterValue {
            get => _textFilterValue;
            set {
                SetProperty(ref _textFilterValue,value, OnFilter);
            }
        }

        public bool IsFilterReadOnly {
            get=> _isFilterReadOnly;
            set {
                SetProperty(ref _isFilterReadOnly, value);
            }
        }

        public  DelegateCommand LoadCommand { get; private set; }
        public  DelegateCommand SetFilterReadOnly { get; private set; }
        public  DelegateCommand SetFilterNotReadOnly { get; private set; }

        private void OnFilter() {
            foreach (CategoryViewModel cat in _categories) {
                cat.ApplyFilter(_textFilterValue);
            }
        }

        /// <summary>
        /// This method clear txtFilter,  clear TreeView and load updated list of Categories
        /// </summary>
        private void OnLoad() {
            _textFilterValue = String.Empty;
            RaisePropertyChanged(nameof(TextFilterValue));

            _categories.Clear();
            List<Category> catList;
            catList = _db.GetCategoryTree();
            foreach (Category category in catList) {
                _categories.Add(new CategoryViewModel(category));
            }

            RaisePropertyChanged(nameof(Categories));
        }

        private void OnSetFilterReadOnly() {
            IsFilterReadOnly = true;
        }

        private void OnSetFilterNotReadOnly() {
            IsFilterReadOnly = false;
        }
    }
}
   


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using TreeView.DataAccess;
using TreeView.Models;

namespace TreeView.ViewModels {

    /// <summary>
    /// The Base ViewModel module
    /// exposes collection of Categories and
    /// contain logic for Load button and filter text box
    /// </summary>
    public class TreeView_ViewModel : BindableBase {
        #region Data
        private ObservableCollection<CategoryViewModel> _categories;
        private string _textFilterValue;
        private Database _db;
        private bool _isFilterReadOnly; 
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

        #region Properties
        public ObservableCollection<CategoryViewModel> Categories => _categories;
        /// <summary>
        /// Binding to filter text box.
        /// Run OnFilter method for fitration
        /// </summary>
        public string TextFilterValue {
            get => _textFilterValue;
            set {
                SetProperty(ref _textFilterValue,value, OnFilter);
            }
        }
        /// <summary>
        /// Gets/sets ReadOnly property for filter textbox
        /// </summary>
        public bool IsFilterReadOnly {
            get=> _isFilterReadOnly;
            set {
                SetProperty(ref _isFilterReadOnly, value);
            }
        }
        #endregion //Properties

        #region DelegateCommands
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public  DelegateCommand LoadCommand { get; private set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public  DelegateCommand SetFilterReadOnly { get; private set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public  DelegateCommand SetFilterNotReadOnly { get; private set; }
        #endregion //DelegateCommands

        #region Methods for commands

        

        /// <summary>
        /// run filter logic on ViewModels
        /// </summary>
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

        /// <summary>
        /// set property ReadOnly on filter textbox.
        /// Binding to mouseClick event
        /// </summary>
        private void OnSetFilterReadOnly() {
            IsFilterReadOnly = true;
        }
        /// <summary>
        /// Disable ReadOnly property on filter textbox
        /// Binding to LostFocus event
        /// </summary>
        private void OnSetFilterNotReadOnly() {
            IsFilterReadOnly = false;
        }
        #endregion //Methods for commands

    }
}
   


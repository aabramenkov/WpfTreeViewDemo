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
        #endregion //Data

        #region Ctor
        public TreeView_ViewModel(Database db) {
            _db=db;
            _categories = new ObservableCollection<CategoryViewModel>();
            FilterCommand = new DelegateCommand(OnFilter, () => true);
            LoadCommand=new DelegateCommand(OnLoad,()=>true);
        }
        #endregion //Ctor

        public ObservableCollection<CategoryViewModel> Categories => _categories;

        public string TextFilterValue {
            get => _textFilterValue;
            set { _textFilterValue = value; }
        }


        public DelegateCommand FilterCommand { get; private set; }
        public  DelegateCommand LoadCommand { get; private set; }

        private void OnFilter() {
            foreach (CategoryViewModel cat in _categories) {
                cat.ApplyFilter(_textFilterValue);
                };
            }

        private void OnLoad() {
            foreach (Category category in _db.GetCategoryTree()) {
                _categories.Add(new CategoryViewModel(category));
            }

            MessageBox.Show(_categories.Count.ToString());
            RaisePropertyChanged(nameof(Categories));
        }

        
    }
}
   


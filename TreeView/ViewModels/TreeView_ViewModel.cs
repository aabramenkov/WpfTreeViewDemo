using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.ObjectBuilder2;
using Prism.Commands;
using TreeView.DataAccess;
using TreeView.Models;

namespace TreeView.ViewModels {

    /// <summary>
    /// The ViewModel for the LoadOnDemand demo.  This simply
    /// exposes a read-only collection of regions.
    /// </summary>
    public class TreeView_ViewModel {
        #region Data
        private ICollection<CategoryViewModel> _categories;
        private string _textFilterValue;
        #endregion //Data

        #region Ctor
        public TreeView_ViewModel() {
            _categories = new List<CategoryViewModel>();
            foreach (Category category in Database.GetCategoryTree()) {
                _categories.Add(new CategoryViewModel(category));
            }

            FilterCommand = new DelegateCommand(OnFilter, () => true);
            LoadCommand=new DelegateCommand(OnLoad,()=>true);
        }
        #endregion //Ctor

        public ICollection<CategoryViewModel> Categories => _categories;

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
            MessageBox.Show("On Load");
        }
        }



        
        }
   


using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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
            IEnumerable<int> rnd = GetSequence(5, 10);
            Random r = new Random();
            //https://www.quora.com/How-do-I-generate-a-list-of-random-integers-without-repeating-in-C

            foreach (int i in rnd) {
                MessageBox.Show(i.ToString());
            }
            
        }

        private static Random _random = new Random();

        private static IEnumerable<int> GetSequence(int size, int max) {
            return Enumerable.Range(_random.Next(max - (size - 1)), size);
        }
    }



        
        }
   


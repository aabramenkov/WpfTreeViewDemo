using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder2;
using TreeView.DataAccess;
using TreeView.Models;

namespace TreeView.ViewModels {

    /// <summary>
    /// The ViewModel for the LoadOnDemand demo.  This simply
    /// exposes a read-only collection of regions.
    /// </summary>
    public class TreeView_ViewModel {

        private ICollection<CategoryViewModel> _categories;

        public TreeView_ViewModel() {
            _categories=new List<CategoryViewModel>();
            foreach (Category category in Database.GetCategoryTree()) {
                Console.WriteLine(category.Name);
                _categories.Add(new CategoryViewModel(category));
            }
        }

        public ICollection<CategoryViewModel> Categories => _categories; 
        }
    }


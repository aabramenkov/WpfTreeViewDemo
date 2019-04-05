using System;
using System.Collections.Generic;
using System.Linq;
using TreeView.Models;

namespace TreeView.DataAccess {
    
    /// <summary>
    /// This class store Category list.
    /// Class registered as Unity singleton in Bootstrapper
    /// Frankly speaking this class more repository then db.
    /// </summary>

    public  class Database {

        private Dictionary<int, Category> _categories;

        public   Database() {
            _categories=new Dictionary<int, Category>();
        }
        /// <summary>
        /// Method return List of Category with Items
        /// use Dictionary int,Category to control unique of categories name
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategoryTree() {
            // new Random instance for every category. Use instance in GenerateItemsList
            var seed = (int)DateTime.Now.Ticks;
            var rand = new Random(seed);

            int maxValue=0;
            if (_categories.Count != 0) {
                maxValue =_categories.Keys.Max();
            }

            for ( int i = maxValue+1; i <= maxValue+25; i++) {
                _categories.Add(i,
                    new Category {
                        Name = $"Category{i}",
                        ID=i,
                        Items = GenerateItemsList(rand)
                    });
            }
            return _categories.Values.ToList();
        }

        /// <summary>
        /// Method return list of Items. Using Hashset to guarantee unique values for Items
        /// </summary>
        /// <param name="rand"></param>
        /// <returns></returns>
        private  List<Item> GenerateItemsList(Random rand) {
            var hs = new HashSet<int>();
            while (hs.Count < 10) {
                hs.Add(rand.Next(1, 31));
            }

            List<Item> result = new List<Item>();
            foreach (int value in hs) {
                result.Add(new Item {Name = $"Item{value}"});
            }

            return result;
        }
        
    }
}

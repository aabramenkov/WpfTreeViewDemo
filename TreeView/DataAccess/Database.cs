using System;
using System.Collections.Generic;
using System.Linq;
using TreeView.Models;

namespace TreeView.DataAccess {
    public   class Database {

        private Dictionary<int, Category> _categories;
        //private List<Category> _categories;

        public   Database() {
            _categories=new Dictionary<int, Category>();
        }

        public List<Category> GetCategoryTree() {

            var seed = (int)DateTime.Now.Ticks;
            var rand = new Random(seed);

            int maxValue;
            if (_categories.Count == 0) {
                maxValue = 0;
            }
            else {
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

        public  IEnumerable<Item> GetItems(Category _category) {
            return _category.Items;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using TreeView.Models;

namespace TreeView.DataAccess {
    public static class Database {

        public static IEnumerable<Category> GetCategoryTree() {

            IList<Category> result = new List<Category>();
            for (int i = 0; i <= 10; i++) {
                result.Add(
                    new Category {
                        Name = $"Category{i}",
                        Items = GenerateItemsList()
                    });
            }
            return result;
        }

        private static List<Item> GenerateItemsList() {
            List<Item> result = new List<Item>();
            for (int i = 0; i <= 10; i++) {
                result.Add(new Item {Name = $"Item{i}"});
            }

            return result;
        }

        public static IEnumerable<Item> GetItems(Category _category) {
            return _category.Items;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TreeView.Models {
    public class Category {

        public IEnumerable<Item> Items;
        public int ID;
        public string Name;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeView.Views {
    /// <summary>
    /// Here is nothing.
    /// Context = TreeView_ViewModel class
    /// Binding initiated in xaml => mvvm:ViewModelLocator.AutoWireViewModel="True"
    /// </summary>
    public partial class TreeView_View : UserControl {
        public TreeView_View() {
            InitializeComponent();
        }
    }
}

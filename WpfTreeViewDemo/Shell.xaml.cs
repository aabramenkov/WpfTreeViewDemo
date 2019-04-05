using System.Windows;
using System.Windows.Navigation;

namespace WpfTreeViewDemo {
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window {
        public Shell() {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e) {
            System.Diagnostics.Process.Start(e.Uri.ToString()); 
        }
    }
}

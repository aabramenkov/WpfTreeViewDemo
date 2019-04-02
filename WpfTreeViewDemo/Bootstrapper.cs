using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;
using Prism.Unity;
using TreeView;

namespace WpfTreeViewDemo {
    public class Bootstrapper : UnityBootstrapper {

        protected override DependencyObject CreateShell() {
            Shell view = Container.TryResolve<Shell>();
            return view;
        }

        protected override void InitializeShell() {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog() {
            base.ConfigureModuleCatalog();
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(TreeViewModule));
        }
    }
}

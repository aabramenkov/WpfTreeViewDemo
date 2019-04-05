using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using TreeView;
using TreeView.DataAccess;

namespace WpfTreeViewDemo {
    public class Bootstrapper : UnityBootstrapper {

        protected override DependencyObject CreateShell() {
            Shell view = Container.TryResolve<Shell>();
            return view;
        }

        protected override void InitializeShell() {
            base.InitializeShell();
            Application.Current.MainWindow = (Window) this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog() {
            base.ConfigureModuleCatalog();
            var moduleCatalog = (ModuleCatalog) ModuleCatalog;
            moduleCatalog.AddModule(typeof(TreeViewModule));
        }

        protected override void ConfigureContainer() {
            base.ConfigureContainer();
            Container.RegisterType<Database>(new ContainerControlledLifetimeManager());
        }
    }
}

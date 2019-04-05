using Prism.Modularity;
using Prism.Regions;
using TreeView.Views;

namespace TreeView {
    public class TreeViewModule : IModule {
        IRegionManager _regionManager;

        public TreeViewModule(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        public void Initialize() {
            _regionManager.RegisterViewWithRegion("TreeViewRegion", typeof(TreeView_View));
        }
    }
}

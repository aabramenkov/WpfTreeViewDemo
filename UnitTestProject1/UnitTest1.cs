using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreeView.DataAccess;
using TreeView.ViewModels;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            //Arrange
            Database mockDb = new Database();
            TreeView_ViewModel tv = new TreeView_ViewModel(mockDb);

            tv.TextFilterValue
        }
    }
}

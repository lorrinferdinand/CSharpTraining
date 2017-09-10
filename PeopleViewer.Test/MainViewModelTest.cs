using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PeopleViewer.Test
{
    [TestClass]
    public class MainViewModelTest
    {

        [TestMethod]
        public void People_OnFetchData_IsPopulated()
        {
            //arrange 
            var viewModel = new MainViewModel();

            //Act
            viewModel.FetchData();

            //asserts
            Assert.IsNotNull(viewModel.People);
            Assert.AreEqual(2, viewModel.People.Count());

        }
    }
}

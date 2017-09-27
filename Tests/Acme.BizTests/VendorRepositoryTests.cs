using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveValueTest()
        {
            //Arrange 
            var repository = new VendorRepository();
            var expected = 42;

            //Act 
            var actual = repository.RetrieveValue<int>("Select ... ", 42);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RetrieveValueObjectTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            //Act
            var actual = repository.RetrieveValue<Vendor>("Select ..", vendor);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void RetrieveTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();
            expected.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
            expected.Add(new Vendor() { VendorId = 2, CompanyName = "BABC Corp", Email = "babc@abc.com" });

            //Act
            var actual = repository.Retrieve();

            //Assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveWithIteratorTest()
        {
            //Arrange 
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "BABC Corp", Email = "babc@abc.com" }
            };

            //Act
            var vendorIterator = repository.RetrieveWithIterator();
            foreach (var item in vendorIterator)
            {
                Console.WriteLine(item);
            }
            var actual = vendorIterator.ToList();

            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RetrieveWithLINQ()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "BABC Corp", Email = "babc@abc.com" }
            };

            //Act
            var vendors = repository.RetrieveAll();

            //Assert
        }

        [TestMethod()]
        public void RetrieveAllTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "BABC Corp", Email = "babc@abc.com" }
            };

            //Act
            var vendors = repository.RetrieveAll();

            //var vendorQuery = from v in vendors
            //                  where v.CompanyName.Contains("ABC")
            //                  select v;

            var vendorQuery = vendors.Where(FilterCompanies)
                .OrderBy(OrderCompanies);

            //Assert
            CollectionAssert.AreEqual(expected, vendorQuery.ToList());
        }

        private bool FilterCompanies(Vendor v) => v.CompanyName.Contains("ABC");
        private string OrderCompanies(Vendor v) => v.CompanyName;

    }
}
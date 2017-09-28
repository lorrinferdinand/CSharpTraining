using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        private List<Vendor> vendors;
        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        public T RetrieveValue<T>(string sql, T defaultValue)
        {
            //call to db to retrieve the value
            // if no value returned, return the default value

            T value = defaultValue;
            return value;

        }

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }

        /// <summary>
        /// Retrieve all approved vendors.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public IEnumerable<Vendor> Retrieve()
        {
            if(vendors == null)
            {
                vendors = new List<Vendor>();
                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "BABC Corp", Email = "babc@abc.com" });
            }

            for (int i = 0; i < vendors.Count; i++)
            {
                Console.WriteLine(vendors[i]);
            }

            return vendors;
        }

        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            // Get the data
            this.Retrieve();
            foreach (var vendor in vendors)
            {
                Console.WriteLine($"Vendor id: {vendor.VendorId}");
                yield return vendor;
            }

        }

        public  IEnumerable<Vendor> RetrieveAll()
        {
            var vendors = new List<Vendor>()
            {
                new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "BABC Corp", Email = "babc@abc.com" },
                new Vendor() { VendorId = 1, CompanyName = "BAC Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "BCBA Corp", Email = "babc@abc.com" },
                new Vendor() { VendorId = 1, CompanyName = "CAB Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "ABBC Corp", Email = "babc@abc.com" },
                new Vendor() { VendorId = 1, CompanyName = "ACB Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "CABB Corp", Email = "babc@abc.com" },
             };

            return vendors;

        }
    }
}

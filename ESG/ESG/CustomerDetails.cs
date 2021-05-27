using System;
using System.Collections.Generic;
using System.Text;

namespace ESG
{
    class CustomerDetails
    {
  
       public CustomerDetails(int customerRef, string customerName, string addressLine1, string  addressLine2, string town, string county, string country, string postcode)
        {
            this.CustomerRef = customerRef;
            this.CustomerName = customerName;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.Town = town;
            this.County = county;
            this.Country = country;
            this.Postcode = postcode;
        }

        public int CustomerRef { get; set; }
        public string CustomerName { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
  

    }
}

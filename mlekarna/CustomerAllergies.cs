using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace mlekarna
{
    class CustomerAllergies
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int SubstanceID { get; set; }

        public CustomerAllergies() { }
        public CustomerAllergies(int customerID, int substanceID)
        {
            CustomerID = customerID;
            SubstanceID = substanceID;
        }
    }
}

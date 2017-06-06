using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mlekarna
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Customer(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}

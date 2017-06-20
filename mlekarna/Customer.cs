using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace mlekarna
{
    public class Customer
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Customer() { }

        public Customer(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}

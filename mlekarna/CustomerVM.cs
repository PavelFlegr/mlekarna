using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mlekarna
{
    public class CustomerVM
    {
        Customer _customer;
        public string Name
        {
            get => _customer.Name;
            set => _customer.Name = value;
        }
        public string Surname
        {
            get => _customer.Surname;
            set => _customer.Surname = value;
        }
        public string FullName
        {
            get => string.Format("{0} {1}", Name, Surname);
        }

        public CustomerVM(Customer customer)
        {
            _customer = customer;
        }
    }
}

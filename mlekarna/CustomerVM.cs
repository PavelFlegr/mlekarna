﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace mlekarna
{
    public class CustomerVM
    {
        public ObservableCollection<Substance> Allergies { get; set; }
        Customer _customer;
        public string Name
        {
            get { return _customer.Name; }
            set { _customer.Name = value; }
        }
        public string Surname
        {
            get { return _customer.Surname; }
            set { _customer.Surname = value; }
        }
        public string FullName
        {
            get { return string.Format("{0} {1}", Name, Surname); }
        }

        public CustomerVM(Customer customer)
        {
            _customer = customer;
            Allergies = new ObservableCollection<Substance>
            {
                new Substance("látka15")
            };
        }
    }
}

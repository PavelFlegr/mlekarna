using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mlekarna
{
    public class Drug
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Drug(string name)
        {
            Name = name;
        }
    }
}

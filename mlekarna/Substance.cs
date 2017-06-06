using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mlekarna
{
    public class Substance
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Substance(string name)
        {
            Name = name;
        }
    }
}

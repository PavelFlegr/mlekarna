using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace mlekarna
{
    class DrugSubstance
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int DrugID { get; set; }
        public int SubstanceID { get; set; }
    }
}

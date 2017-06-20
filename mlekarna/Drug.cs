using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace mlekarna
{
    public class Drug
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }

        public Drug() { }
        public Drug(string name)
        {
            Name = name;
        }
        [Ignore]
        public List<Substance> Substances
        {
            get
            {
                return DB<Substance>.GetItems().Where(s => DB<DrugSubstance>.GetItems().Where(ds => ds.DrugID == ID).Select(ds => ds.SubstanceID).Contains(s.ID)).ToList();
            }
        }
    }
}

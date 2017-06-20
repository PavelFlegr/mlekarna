using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace mlekarna
{
    public class DrugVM
    {
        Drug _drug;

        public int ID => _drug.ID;
        public string Name
        {
            get { return _drug.Name; }
            set { _drug.Name = value; }
        }

        public DrugVM(Drug drug)
        {
            _drug = drug;
            Substances = new ObservableCollection<Substance>(DB<Substance>.GetItems().Where(s => DB<DrugSubstance>.GetItems().Where(ds => ds.DrugID == _drug.ID).Select(da => da.SubstanceID).Any(id => s.ID == id)));
        }

        public ObservableCollection<Substance> Substances { get; set; }
    }
}

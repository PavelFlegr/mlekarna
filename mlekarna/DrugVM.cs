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
        public string Name
        {
            get { return _drug.Name; }
            set { _drug.Name = value; }
        }

        public DrugVM(Drug drug)
        {
            _drug = drug;
            Substances = new ObservableCollection<Substance>
            {
                new Substance("latka1"),
                new Substance("latka2")
            };
        }

        public ObservableCollection<Substance> Substances { get; set; }
    }
}

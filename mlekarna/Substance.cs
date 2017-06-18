using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace mlekarna
{
    public class Substance : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        string name;

        public Substance() { }

        public Substance(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

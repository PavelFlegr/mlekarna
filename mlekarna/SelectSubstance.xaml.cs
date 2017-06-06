using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace mlekarna
{
    /// <summary>
    /// Interakční logika pro SelectSubstance.xaml
    /// </summary>
    public partial class SelectSubstance : Window
    {
        public Substance SelectedSubstance { get; set; }
        public ObservableCollection<Substance> Substances { get; set; }
        public SelectSubstance()
        {
            InitializeComponent();
            Substances = new ObservableCollection<Substance>
            {
                new Substance()
            };
            DataContext = this;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedSubstance = (sender as ListBox).SelectedItem as Substance;
            DialogResult = true;
            Close();
        }
    }
}

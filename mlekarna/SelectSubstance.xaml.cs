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
        public IEnumerable<Substance> SelectedSubstances { get; set; }
        public ObservableCollection<Substance> Substances { get; set; }
        public SelectSubstance()
        {
            InitializeComponent();
            Substances = new ObservableCollection<Substance>
            {
                new Substance("latka2"),
                new Substance("látka3")
            };
            DataContext = this;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetSelected();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetSelected();
        }

        void SetSelected()
        {
            SelectedSubstances = substances.SelectedItems.Cast<Substance>();
            DialogResult = true;
            Close();
        }
    }
}

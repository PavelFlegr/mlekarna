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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mlekarna
{
    /// <summary>
    /// Interakční logika pro DrugView.xaml
    /// </summary>
    public partial class DrugView : Page
    {
        DrugVM _drug
        {
            get { return DataContext as DrugVM; }
            set { DataContext = value; }
        }
        public DrugView(DrugVM drug)
        {
            InitializeComponent();

            _drug = drug;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new SelectSubstance();
            if (w.ShowDialog() == true)
            {
                foreach (Substance s in w.SelectedSubstances)
                {
                    DB<DrugSubstance>.AddItem(new DrugSubstance { DrugID = _drug.ID, SubstanceID = s.ID });
                    _drug.Substances.Add(s);
                }
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var tmp = new List<Substance>(AllergyList.SelectedItems.Cast<Substance>());
            foreach (Substance s in tmp)
            {
                _drug.Substances.Remove(s);
                DB<DrugSubstance>.RemoveWhere(ds => ds.SubstanceID == s.ID && ds.DrugID == _drug.ID);
                    }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

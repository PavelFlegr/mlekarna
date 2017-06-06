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
    /// Interakční logika pro CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Page
    {
        public List<Substance> Allergies { get; set; }
        public CustomerView(CustomerVM customer)
        {
            InitializeComponent();
            DataContext = customer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new SelectSubstance();
            if(w.ShowDialog() == true)
            {
                Allergies.Add(w.SelectedSubstance);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

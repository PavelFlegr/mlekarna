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
using System.Collections.ObjectModel;

namespace mlekarna
{
    /// <summary>
    /// Interakční logika pro CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Page
    {
        CustomerVM _customer
        {
            get { return DataContext as CustomerVM; }
            set { DataContext = value; }
        }
        public CustomerView(CustomerVM customer)
        {
            InitializeComponent();
            _customer = customer;
            InputBox.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new SelectSubstance();
            if (w.ShowDialog() == true)
            {
                foreach (Substance s in w.SelectedSubstances)
                {
                    _customer.Allergies.Add(s);
                    DB<CustomerAllergies>.AddItem(new CustomerAllergies(_customer.ID, s.ID));
                }
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var tmp = new List<Substance>(AllergyList.SelectedItems.Cast<Substance>());
            foreach (Substance s in tmp)
            {
                _customer.Allergies.Remove(s);
                DB<CustomerAllergies>.RemoveWhere(ca => ca.CustomerID == _customer.ID && ca.SubstanceID == s.ID);
            }
        }

        private void PrescribeButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
        }
    }
}

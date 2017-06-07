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
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public ObservableCollection<CustomerVM> Customers { get; set; }
        public ObservableCollection<DrugVM> Drugs {get; set;}
        public ObservableCollection<Substance> Substances { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Customers = new ObservableCollection<CustomerVM> {
                new CustomerVM(new Customer("test1", "surtest1")),
                new CustomerVM(new Customer("test2", "surtest2"))
            };

            Drugs = new ObservableCollection<DrugVM>
            {
                new DrugVM(new Drug("lék1")),
                new DrugVM(new Drug("lék2")),
                new DrugVM(new Drug("lék3"))
            };

            Substances = new ObservableCollection<Substance>
            {
                new Substance("latka1"),
                new Substance("LATKA2")
            };
            DataContext = this;
        }

        private void CustomerList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var source = CustomerList.SelectedItem as CustomerVM;
            NavigationService.Navigate(new CustomerView(source));
        }

        private void DrugList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var source = DrugList.SelectedItem as DrugVM;
            NavigationService.Navigate(new DrugView(source));
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            var s = SubstanceList.SelectedItem as Substance;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

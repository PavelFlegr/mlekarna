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
using System.ComponentModel;

namespace mlekarna
{
    /// <summary>
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<CustomerVM> Customers { get; set; }
        public ObservableCollection<DrugVM> Drugs { get; set; }
        public ObservableCollection<Substance> Substances { get; set; }
        public MainPage()
        {
            InitializeComponent();

            Customers = new ObservableCollection<CustomerVM>(DB<Customer>.GetItems().Select(c => new CustomerVM(c)));

            Drugs = new ObservableCollection<DrugVM>(DB<Drug>.GetItems().Select(d => new DrugVM(d)));

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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        string mode;

        public event PropertyChangedEventHandler PropertyChanged;

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

            InputBox.Visibility = Visibility.Visible;
            NameTextBox.Text = (SubstanceList.SelectedItem as Substance).Name;
            mode = "rename";
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Substance>(SubstanceList.SelectedItems.Cast<Substance>());
            foreach(Substance s in list)
            {
                Substances.Remove(s);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
            mode = "add";
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(mode == "rename")
            {
                (SubstanceList.SelectedItem as Substance).Name = NameTextBox.Text;
            }
            else
            {
                Substances.Add(new Substance(NameTextBox.Text));
            }
            BoxCleanUp();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            BoxCleanUp();
        }

        void BoxCleanUp()
        {
            InputBox.Visibility = Visibility.Collapsed;
            NameTextBox.Text = "";
        }
    }
}

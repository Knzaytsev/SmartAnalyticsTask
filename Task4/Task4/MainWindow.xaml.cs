using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Task4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IReader reader = new CSVReader();
        public MainWindow()
        {
            InitializeComponent();
            listYears.ItemsSource = reader.ReadYear();
        }

        private void selectYear_Click(object sender, RoutedEventArgs e)
        {
            int year = (int)listYears.SelectedItem;
            dgSales.ItemsSource = reader.ReadCountries(year);
        }
    }
}

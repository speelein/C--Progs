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
using Typisiertes_DataSet.CustOrdTableAdapters;

namespace Typisiertes_DataSet {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window {
        CustOrd dataset;
        CustomersTableAdapter adapter;

        public MainWindow() {
            InitializeComponent();
            dataset = new CustOrd();
            adapter = new CustomersTableAdapter();
            try {
                adapter.Fill(dataset.Customers);
            } catch (Exception e) {
                MessageBox.Show(e.Message);
                throw;
            }
            DataContext = dataset.Customers;
        }

        private void BtnSaveClick(object sender, RoutedEventArgs e) {
            try {
                adapter.Update(dataset.Customers);
                MessageBox.Show("Änderungen in die Datenbank geschrieben");
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnCancelClick(object sender, RoutedEventArgs e) {
            try {
                adapter.Fill(dataset.Customers);
                MessageBox.Show("Änderungen verworfen, Daten neu geladen");
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

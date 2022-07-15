using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DmToEuro
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            const decimal faktor = 1.95583m;
            decimal euro = Convert.ToDecimal(eingabe.Text) / faktor;
            decimal cent = euro % 1.0m;
            euro -= cent;
            cent *= 100;
            lblEuro.Content = String.Format($"{euro:f0}");
            lblCent.Content = String.Format($"{cent:f0}");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            eingabe.Focus();
        }
    }
}

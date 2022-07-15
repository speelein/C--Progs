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

namespace BruchKürzenGui {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        Bruch b = new Bruch();

        public MainWindow() {
            InitializeComponent();
        }

        private void reduceBtn_Click(object sender, RoutedEventArgs e) {
            try {
                b.Zaehler = Convert.ToInt32(numTb.Text);
                b.Nenner = Convert.ToInt32(denomTb.Text);
                b.Kuerze();
                numTb.Text = b.Zaehler.ToString();
                denomTb.Text = b.Nenner.ToString();
            } catch {
                MessageBox.Show("Eingabefehler", "Fehler", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Keyboard.Focus(numTb);
        }
    }
}

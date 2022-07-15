using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Eratosthenes {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e) {
            Cursor oldCursor = Cursor;
            Cursor = Cursors.Wait;
            try {
                var items = new List<int>();

                // Kandidaten-Array erzeugen und vorbereiten
                int grenze = Convert.ToInt32(textBox.Text);
                if (grenze < 2 || grenze > 2146435070)
                    throw new ArgumentException("Unzulässiges Argument");
                int maxBasis = (int)(Math.Sqrt(grenze) + 0.5);
                bool[] prim = new bool[grenze + 1];
                for (int i = 1; i <= grenze; i++)
                    prim[i] = true;

                // Eratosthenes-Sieb
                for (int basis = 2; basis <= maxBasis; basis++)
                    if (prim[basis])
                        for (int i = 2; i * basis <= grenze; i++)
                            prim[i * basis] = false;
                
                // Ergebnis ausgeben
                for (int i = 2; i <= grenze; i++)
                    if (prim[i])
                        items.Add(i);
                listBox.ItemsSource = items;
            } catch (Exception ex) {
                listBox.ItemsSource = null;
                MessageBox.Show(this, ex.ToString(), ex.Message);
            } finally {
                Cursor = oldCursor;
            }
        }
    }
}

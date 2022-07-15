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

namespace Button {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
        long anzahl;

        public MainWindow() {
			InitializeComponent();
		}

        private void Button_Click(object sender, RoutedEventArgs e) {
	        if (e.Source == count)
		        anzahl++;
	        else
		        anzahl = 0;
	        label.Content = anzahl.ToString();
        }
    }
}

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

namespace ListBox {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();

            //listBox.Items.Add(new TextBlock {Text = "Dyn"});

            //var items = new System.Collections.ObjectModel.ObservableCollection<String>();
            //items.Add("One"); items.Add("Two");
            //listBox.ItemsSource = items;
        }

        private void button_Click(object sender, RoutedEventArgs e) {
			MessageBox.Show("Guten Tag, " + ((TextBlock)listBox.SelectedItem).Text + " " +
				comboBox.Text);
        }
	}
}

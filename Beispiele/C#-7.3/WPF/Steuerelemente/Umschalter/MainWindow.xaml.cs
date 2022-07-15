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

namespace Umschalter {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		FontFamily ffArial = new FontFamily("Arial");
		FontFamily ffTNR = new FontFamily("Times New Roman");
		FontFamily ffCourierNew = new FontFamily("Courier New");

		public MainWindow() {
			InitializeComponent();
		}

		private void CheckBox_Click(object sender, RoutedEventArgs e) {
			if (chkBold.IsChecked == true)
				lblTextbeispiel.FontWeight = FontWeights.Heavy;
			else
				lblTextbeispiel.FontWeight = FontWeights.Normal;
			if (chkItalic.IsChecked == true)
				lblTextbeispiel.FontStyle = FontStyles.Italic;
			else
				lblTextbeispiel.FontStyle = FontStyles.Normal;
		}

        private void RadioButton_Click(object sender, RoutedEventArgs e) {
            if (e.Source is RadioButton)
                lblTextbeispiel.FontFamily = ((RadioButton)e.Source).FontFamily;
        }
    }
}

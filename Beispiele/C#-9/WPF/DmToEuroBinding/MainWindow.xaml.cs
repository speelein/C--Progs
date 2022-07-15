//  Urheber: Paul Frischknecht

using System;
using System.Windows;
using System.Windows.Data;

namespace DmToEuroBinding {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            tbEingabe.Focus();
        }
    }

    public class DmToEuroConverter : IValueConverter {
        const double factor = 1.95583;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            string s = "";
            try {
                s = string.IsNullOrEmpty((string)value) ? "" : (System.Convert.ToDouble(value) / factor).ToString("0.00");
            } catch {
            }
            return s;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}

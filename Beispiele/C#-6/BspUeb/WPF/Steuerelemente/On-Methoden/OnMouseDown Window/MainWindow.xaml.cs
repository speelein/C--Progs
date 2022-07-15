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

namespace OnMouseDownWindow {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

        protected override void OnMouseDown(MouseButtonEventArgs e) {
            base.OnMouseDown(e);
            label.Margin = new Thickness(e.GetPosition(this).X, e.GetPosition(this).Y, 0, 0);
            label.Content = "(" + e.GetPosition(this).ToString() + ")";
        }

        //private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
        //    label.Margin = new Thickness(e.GetPosition(this).X, e.GetPosition(this).Y, 0, 0);
        //    label.Content = "(" + e.GetPosition(this).ToString() + ")";
        //}
    }
}

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

namespace Routingereignisse {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        // Tunnelereignis PreviewMouseDown
        private void HandlePreviewMouseDown(object sender, MouseButtonEventArgs e) {
            listBox.Items.Add($"PreviewMouseDown(Sender: {sender.GetType().Name}, " +
                              $"Quelle: {e.Source.GetType().Name})");
        }
        // Blasenereignis MouseDown
        private void HandleMouseDown(object sender, MouseButtonEventArgs e) {
            listBox.Items.Add($"MouseDown (Sender: {sender.GetType().Name}, " +
                              $"Quelle: {e.Source.GetType().Name})");
        }
        // Blasenereignis Click
        private void HandleClick(object sender, RoutedEventArgs e) {
            listBox.Items.Add($"Click (Sender: {sender.GetType().Name}, " +
                              $"Quelle: {e.Source.GetType().Name})");
        }
    }
}

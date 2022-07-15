using System.Windows;

namespace LayoutContainer {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Loaded += Window_Loaded;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            MessageBox.Show(Content.ToString());
        }
    }
}

using System;
using System.Windows;

namespace ListBox {
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

        private void Button_Click(object sender, RoutedEventArgs e) {
            Object[] tempAnwaerter = new Object[listeAnwaerter.SelectedItems.Count];
            Object[] tempTeilnehmer = new Object[listeTeilnehmer.SelectedItems.Count];
            if (e.Source == cmdRein) {
                listeAnwaerter.SelectedItems.CopyTo(tempAnwaerter, 0);
                foreach (object anw in tempAnwaerter) {
                    listeAnwaerter.Items.Remove(anw);
                    listeTeilnehmer.Items.Add(anw);
                }
            }
            else {
                listeTeilnehmer.SelectedItems.CopyTo(tempTeilnehmer, 0);
                foreach (object anw in tempTeilnehmer) {
                    listeTeilnehmer.Items.Remove(anw);
                    listeAnwaerter.Items.Add(anw);
                }
            }
        }
    }
}

using System;
using System.ComponentModel;
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
            if (e.Source == cmdRein) {
                Object[] tempAnwaerter = new Object[listeAnwaerter.SelectedItems.Count];
                listeAnwaerter.SelectedItems.CopyTo(tempAnwaerter, 0);
                foreach (object anw in tempAnwaerter) {
                    listeAnwaerter.Items.Remove(anw);
                    listeTeilnehmer.Items.Add(anw);
                }
            }
            else {
                Object[] tempTeilnehmer = new Object[listeTeilnehmer.SelectedItems.Count];
                listeTeilnehmer.SelectedItems.CopyTo(tempTeilnehmer, 0);
                foreach (object anw in tempTeilnehmer) {
                    listeTeilnehmer.Items.Remove(anw);
                    listeAnwaerter.Items.Add(anw);
                }
            }
            SortDescription sd = new SortDescription("Text", ListSortDirection.Ascending);
            listeAnwaerter.Items.SortDescriptions.Add(sd);
            listeTeilnehmer.Items.SortDescriptions.Add(sd);
        }
    }
}

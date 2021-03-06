using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RssFeedReader {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            textBox.Text = "https://www.microsoft.com/de-de/techwiese/feeds/rss/aktuell.xml";
        }

		private void button_Click(object sender, RoutedEventArgs e) {
			Cursor oldCursor = this.Cursor;
			Cursor = Cursors.Wait;
			try {
				XDocument feed = XDocument.Load(textBox.Text);
				var items = new List<RssItem>();
				IEnumerable<XElement> xDocItems = feed.Descendants("item");
				RssItem rit;
				foreach (XElement item in xDocItems) {
					rit = new RssItem() {
						Title = item.Element("title").Value,
						Description = Regex.Replace(item.Element("description").Value, "<[^>]*>",
													String.Empty, RegexOptions.IgnoreCase).Trim(),
						Url = item.Element("link").Value
					};
					items.Add(rit);
				}
				listBox.ItemsSource = items;
			} catch (Exception ex) {
				listBox.ItemsSource = null;
				MessageBox.Show(this, ex.ToString(), ex.Message);
			} finally {
				Cursor = oldCursor;
			}
		}

		private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
			RssItem item = (RssItem)listBox.SelectedItem;
			// Exist. SelectedItem? Liefert seine Url-Eigenschaft einen nicht-leeren String?
			if (item != null && !String.IsNullOrEmpty(item.Url))
				try {
					System.Diagnostics.Process.Start(item.Url);
				} catch (Exception ex) {
					MessageBox.Show(this, ex.ToString(), ex.Message);
				}
		}
	}
}


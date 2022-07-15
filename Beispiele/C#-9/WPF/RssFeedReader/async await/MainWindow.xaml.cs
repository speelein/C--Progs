using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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

		private List<RssItem> GetItemsSource(Object obj) {
			String url = (String)obj;
			XDocument feed = XDocument.Load(url);
			var items = new List<RssItem>();
			IEnumerable<XElement> xDocItems = feed.Descendants("item");
			RssItem rit;
			foreach (XElement item in xDocItems) {
				rit = new RssItem() {
					Title = item.Element("title").Value,
					Description = Regex.Replace(item.Element("description").Value, "<[^>]*>", String.Empty, RegexOptions.IgnoreCase).Trim(),
					Url = item.Element("link").Value};
				items.Add(rit);
			}
			return items;
		}

		private async void button_Click(object sender, RoutedEventArgs e) {
			Task<List<RssItem>> gis = Task.Factory.StartNew<List<RssItem>>(GetItemsSource, textBox.Text);
			button.IsEnabled = false;
			var waitInfo = new List<RssItem>()
								{ new RssItem() { Title = "Feed wird geladen. Bitte warten ..." } };
			listBox.ItemsSource = waitInfo;
			try {
				listBox.ItemsSource = await gis;
			} catch (Exception ex) {
				listBox.ItemsSource = null;
				MessageBox.Show(this, ex.ToString(), ex.Message);
			} finally {
				button.IsEnabled = true;
			}
		}

		private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
			RssItem item = (RssItem)listBox.SelectedItem;
			// Exist. SelectedItem? Liefert seine Url-Eigenschaft einen nicht-leeren String?
			if (item != null && !String.IsNullOrEmpty(item.Url))
				try {
					System.Diagnostics.Process.Start(item.Url);
				}
				catch (Exception ex) {
					MessageBox.Show(this, ex.ToString(), ex.Message);
				}
		}
	}
}

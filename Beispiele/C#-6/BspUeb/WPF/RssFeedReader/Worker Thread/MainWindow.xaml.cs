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
			textBox.Text = "https://www.microsoft.com/germany/msdn/rss/DC_Csharp.xml";
		}

		private void button_Click(object sender, RoutedEventArgs e) {
			SynchronizationContext contextUI = SynchronizationContext.Current;
			var waitInfo = new List<RssItem>() { new RssItem() { Title = "Bitte Warten ..." } };
			listBox.ItemsSource = waitInfo;
			button.IsEnabled = false;

			String s = textBox.Text;
			Task.Factory.StartNew(() => {
				try {
					XDocument feed = XDocument.Load(s);
					var items = new List<RssItem>();
					IEnumerable<XElement> xDocItems = feed.Descendants("item");
					RssItem rit;
					foreach (XElement item in xDocItems) {
						rit = new RssItem() {
							Title = item.Element("title").Value,
							Description = Regex.Replace(item.Element("description").Value, "<[^>]*>", String.Empty, RegexOptions.IgnoreCase).Trim(),
							Url = item.Element("link").Value
						};
						items.Add(rit);
					}
					contextUI.Post(notUsed => {listBox.ItemsSource = items;}, null);
				} catch (Exception ex) {
					contextUI.Post(notUsed => {listBox.ItemsSource = null;
						                       MessageBox.Show(this, ex.ToString(), ex.Message);}, null);
				} finally {
					contextUI.Post(notUsed => {button.IsEnabled = true;}, null);
				}
			});
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

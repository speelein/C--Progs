using System;
using System.Configuration;
using System.Collections.Specialized;

class AppSettingsDemo {
	static void Main() {
		Console.WriteLine("Einstellungen im Element <appSettings>:");
		NameValueCollection settings = ConfigurationManager.AppSettings;
		for (int i = 0; i < settings.Count; i++)
			Console.WriteLine("Key: {0} \tValue: {1}", settings.GetKey(i), settings.Get(i));

		// Wert in appSettings ändern
		Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		conf.AppSettings.Settings["AppName"].Value = "Richis Texteditor";
		conf.Save();
		Console.ReadLine();
	}
}
using System;
using System.Windows;
using System.Windows.Controls;

class MaiButton : Button {
	protected override void OnClick() {
        base.OnClick();
        MessageBox.Show("Überschreibende On-Methode von MaiButton");
	}
}

class OnClickButton : Window {
	OnClickButton() {
		Height = 100; Width = 300;
		Title = "OnClick Button";
		MaiButton knopf = new MaiButton();
        knopf.Content = "Knopf"; knopf.Width = 100;
        knopf.Margin = new Thickness(10);
		knopf.Click += new RoutedEventHandler(knopf_Click);
        AddChild(knopf);
    }

	private void knopf_Click(object sender, RoutedEventArgs e) {
		MessageBox.Show("Click-Handler von Knopf");
	}

	[STAThread]
	static void Main() {
		new Application().Run(new OnClickButton());
	}
}
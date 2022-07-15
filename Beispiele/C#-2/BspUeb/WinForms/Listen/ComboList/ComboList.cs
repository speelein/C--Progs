using System;
using System.Windows.Forms;
using System.Drawing;

class ComboList : Form {
	ListBox listBoxAnrede;
	ComboBox comboBoxNachname;

	public ComboList() {
		Height = 100; Width = 320;
		Text = "(Combo)List";

		listBoxAnrede = new ListBox();
		listBoxAnrede.Location = new Point(20, 30);
		listBoxAnrede.Size = new Size(50, 30);
		listBoxAnrede.Items.AddRange(new String[2] {"Frau", "Herr"});
		listBoxAnrede.SelectedIndex = 0;
		Controls.Add(listBoxAnrede);

		Label lbAnrede = new Label();
		lbAnrede.Text = "Anrede:";
		lbAnrede.Width = 50;
		lbAnrede.Location = new Point(20, 10);
		Controls.Add(lbAnrede);

		comboBoxNachname = new ComboBox();
		comboBoxNachname.Location = new Point(100, 30);
		comboBoxNachname.Width = 100;
		comboBoxNachname.Items.AddRange(
			new String[4] {"Müller", "Maier", "Schulz", "Schmitt"});
		comboBoxNachname.Sorted = true;
		Controls.Add(comboBoxNachname);

		Label lbNachname = new Label();
		lbNachname.Text = "Name:";
		lbNachname.Location = new Point(100, 10);
		Controls.Add(lbNachname);

		Button cbFertig = new Button();
		cbFertig.Text = "Fertig!";
		cbFertig.Click += new EventHandler(FertigOnClick);
		cbFertig.Location = new Point(220, 30);
		Controls.Add(cbFertig);
	}

	protected void FertigOnClick(object sender, EventArgs e) {
		String nachname;
		if (comboBoxNachname.Text.Length > 0)
			nachname = comboBoxNachname.Text;
		else
			nachname = " ... Äh";
		MessageBox.Show("Guten Tag, " + listBoxAnrede.Text + " " +
		 nachname, Text, MessageBoxButtons.OK);
	}

	static void Main() {
		Application.Run(new ComboList());
	}
}

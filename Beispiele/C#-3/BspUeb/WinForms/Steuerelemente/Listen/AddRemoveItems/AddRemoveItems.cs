using System;
using System.Windows.Forms;
using System.Drawing;

class AddRemoveItems : Form {
	ListBox listeAnwaerter, listeTeilnehmer;
	Button cmdRein, cmdRaus;

	AddRemoveItems() {
		Text = "AddRemoveItems";
		ClientSize = new System.Drawing.Size(480, 160);
		FormBorderStyle = FormBorderStyle.FixedSingle;

		listeAnwaerter = new ListBox();
		listeAnwaerter.Parent = this;
		listeAnwaerter.Location = new Point(16, 30);
		listeAnwaerter.Size = new Size(180, 120);
		listeAnwaerter.SelectionMode = SelectionMode.MultiExtended;
		listeAnwaerter.Items.AddRange(new object[10] {"Rott, Felix", "Konz, Susanne",
				"Roth, Ruth", "Schorn, Kurt", "Orth, Peter", "Antwerpen, Udo", "Thor, Theo",
				"Nickel, Nicole", "Sand, Sandra", "Mock, Mirko"});
		listeAnwaerter.Sorted = true;

		Label lbAnwaerter = new Label();
		lbAnwaerter.Text = "Anwärter:";
		lbAnwaerter.Left = listeAnwaerter.Left; lbAnwaerter.Top = 10;
		lbAnwaerter.Parent = this;

		listeTeilnehmer = new ListBox();
		listeTeilnehmer.Parent = this;
		listeTeilnehmer.Location = new Point(280, 30);
		listeTeilnehmer.Size = new Size(180, 120);
		listeTeilnehmer.SelectionMode = SelectionMode.MultiExtended;

		Label lbTeilnehmer = new Label();
		lbTeilnehmer.Text = "Teilnehmer:";
		lbTeilnehmer.Left = listeTeilnehmer.Left; lbTeilnehmer.Top = 10;
		lbTeilnehmer.Parent = this;

		cmdRein = new Button();
		cmdRein.Text = "->";
		cmdRein.Location = new Point(220, 50);
		cmdRein.Size = new Size(30, 30);
		cmdRein.Parent = this;
		cmdRein.Click += new EventHandler(ButtonOnClick);

		cmdRaus = new Button();
		cmdRaus.Text = "<-";
		cmdRaus.Location = new Point(220, 90);
		cmdRaus.Size = new Size(30, 30);
		cmdRaus.Parent = this;
		cmdRaus.Click += new EventHandler(ButtonOnClick);
	}

	void ButtonOnClick(object sender, EventArgs e) {
		if (sender == cmdRein) {
			bool found;
			foreach (object anw in listeAnwaerter.SelectedItems) {
				found = false;
				foreach (object teiln in listeTeilnehmer.Items)
					if (anw == teiln)
						found = true;
				if (!found)
					listeTeilnehmer.Items.Add(anw);
			}
		} else {
			while (listeTeilnehmer.SelectedItems.Count > 0)
				listeTeilnehmer.Items.Remove(listeTeilnehmer.SelectedItems[0]);
		}
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new AddRemoveItems());
	}
}

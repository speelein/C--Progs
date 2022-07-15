using System;
using System.Windows.Forms;
using System.Drawing;

class Umschalter : Form {
	Label lblTextbeispiel;
	CheckBox chkBold, chkItalic;
	RadioButton rbArial, rbTimesNewRoman, rbCourierNew;

	Umschalter() {
		ClientSize = new Size(460, 125);
		Text = "Umschalter";

		lblTextbeispiel = new Label();
		lblTextbeispiel.Text = "Beispieltext";
		lblTextbeispiel.Font = new Font("Arial", 16);
		lblTextbeispiel.Location = new Point(250, 50);
		lblTextbeispiel.Width = 200;
		Controls.Add(lblTextbeispiel);

		chkBold = new CheckBox();
		chkBold.Text = "fett";
		chkBold.Location = new Point(20, 30);
		chkBold.Width = 60;
		Controls.Add(chkBold);

		chkItalic = new CheckBox();
		chkItalic.Text = "kursiv";
		chkItalic.Location = new Point(20, 70);
		chkItalic.Width = 60;
		Controls.Add(chkItalic);

		EventHandler eh = new EventHandler(CheckBoxOnClick);
		chkBold.Click += eh;
		chkItalic.Click += eh;

		rbArial = new RadioButton();
		rbArial.Text = "Arial";
		rbArial.Location = new Point(100, 10);
		rbArial.Checked = true;
		Controls.Add(rbArial);

		rbTimesNewRoman = new RadioButton();
		rbTimesNewRoman.Text = "Times New Roman";
		rbTimesNewRoman.Location = new Point(100, 50);
		rbTimesNewRoman.Width = 190;
		Controls.Add(rbTimesNewRoman);

		rbCourierNew = new RadioButton();
		rbCourierNew.Text = "Courier New";
		rbCourierNew.Location = new Point(100, 90);
		Controls.Add(rbCourierNew);

		eh = new EventHandler(RadioButtonOnlick);
		rbArial.Click += eh;
		rbTimesNewRoman.Click += eh;
		rbCourierNew.Click += eh;
	}

	void CheckBoxOnClick(object sender, EventArgs e) {
		if (chkBold.Checked)
			lblTextbeispiel.Font = new Font(lblTextbeispiel.Font,
				 lblTextbeispiel.Font.Style | FontStyle.Bold);
		else
			lblTextbeispiel.Font = new Font(lblTextbeispiel.Font,
				 lblTextbeispiel.Font.Style & ~FontStyle.Bold);
		if (chkItalic.Checked)
			lblTextbeispiel.Font = new Font(lblTextbeispiel.Font,
				 lblTextbeispiel.Font.Style | FontStyle.Italic);
		else
			lblTextbeispiel.Font = new Font(lblTextbeispiel.Font,
				 lblTextbeispiel.Font.Style & ~FontStyle.Italic);
	}

	void RadioButtonOnlick(object sender, EventArgs e) {
		if (rbArial.Checked)
				lblTextbeispiel.Font = new Font("Arial", lblTextbeispiel.Font.Size,
					 lblTextbeispiel.Font.Style);
		else
			if (rbTimesNewRoman.Checked)
				lblTextbeispiel.Font = new Font("Times New Roman", lblTextbeispiel.Font.Size,
					 lblTextbeispiel.Font.Style);
			else
				lblTextbeispiel.Font = new Font("Courier New", lblTextbeispiel.Font.Size,
					 lblTextbeispiel.Font.Style);
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new Umschalter());
	}
}

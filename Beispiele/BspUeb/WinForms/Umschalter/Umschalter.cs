using System;
using System.Windows.Forms;
using System.Drawing;

class Umschalter : Form {
	Label lbTextbeispiel;
	CheckBox cbBold, cbItalic;
	RadioButton rbCourierNew, rbTimesNewRoman, rbArial;

	public Umschalter() {
		ClientSize = new Size(460, 125);
		Text = "Umschalter";

		lbTextbeispiel = new Label();
		lbTextbeispiel.Text = "Beispieltext";
		lbTextbeispiel.Font = new Font("Arial", 16);
		lbTextbeispiel.Location = new Point(250, 50);
		lbTextbeispiel.Width = 200;
		Controls.Add(lbTextbeispiel);

		cbBold = new CheckBox();
		cbBold.Text = "fett";
		cbBold.Location = new Point(20, 30);
		cbBold.Width = 60;
		Controls.Add(cbBold);

		cbItalic = new CheckBox();
		cbItalic.Text = "kursiv";
		cbItalic.Location = new Point(20, 70);
		cbItalic.Width = 60;
		Controls.Add(cbItalic);

		EventHandler eh = new EventHandler(CheckBoxOnClick);
		cbBold.Click += eh;
		cbItalic.Click += eh;

		rbCourierNew = new RadioButton();
		rbCourierNew.Text = "Courier New";
		rbCourierNew.Location = new Point(100, 10);
		Controls.Add(rbCourierNew);

		rbTimesNewRoman = new RadioButton();
		rbTimesNewRoman.Text = "Times New Roman";
		rbTimesNewRoman.Location = new Point(100, 50);
		rbTimesNewRoman.Width = 190;
		Controls.Add(rbTimesNewRoman);

		rbArial = new RadioButton();
		rbArial.Text = "Arial";
		rbArial.Location = new Point(100, 90);
		rbArial.Checked = true;
		Controls.Add(rbArial);

		eh = new EventHandler(RadioButtonOnlick);
		rbCourierNew.Click += eh;
		rbTimesNewRoman.Click += eh;
		rbArial.Click += eh;
	}

	protected void CheckBoxOnClick(object sender, EventArgs e) {
		if (cbBold.Checked)
			lbTextbeispiel.Font = new Font(lbTextbeispiel.Font,
				 lbTextbeispiel.Font.Style | FontStyle.Bold);
		else
			lbTextbeispiel.Font = new Font(lbTextbeispiel.Font,
				 lbTextbeispiel.Font.Style & ~FontStyle.Bold);
		if (cbItalic.Checked)
			lbTextbeispiel.Font = new Font(lbTextbeispiel.Font,
				 lbTextbeispiel.Font.Style | FontStyle.Italic);
		else
			lbTextbeispiel.Font = new Font(lbTextbeispiel.Font,
				 lbTextbeispiel.Font.Style & ~FontStyle.Italic);
	}

	protected void RadioButtonOnlick(object sender, EventArgs e) {
		if (rbCourierNew.Checked)
			lbTextbeispiel.Font = new Font("Courier New", lbTextbeispiel.Font.Size,
				 lbTextbeispiel.Font.Style);
		else
			if (rbTimesNewRoman.Checked)
				lbTextbeispiel.Font = new Font("Times New Roman", lbTextbeispiel.Font.Size,
					 lbTextbeispiel.Font.Style);
			else
				lbTextbeispiel.Font = new Font("Arial", lbTextbeispiel.Font.Size,
					 lbTextbeispiel.Font.Style);
	}

	static void Main() {
		Application.Run(new Umschalter());
	}
}

using System;
using System.Drawing;
using System.Windows.Forms;

public class UpDown : Form {
	Panel panel;
	NumericUpDown numUpDownRot, numUpDownBlau, numUpDownGruen, numUpDownAlpha;
	DomainUpDown domainUpDown;

	public UpDown() {
		AutoScaleBaseSize = new Size(5, 13);
		ClientSize = new Size(432, 318);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		Text = "FarbMixer";

		Label lbTitel = new Label();
		lbTitel.Text = "Farbmixer";
		lbTitel.Font = new Font("Tahoma", 16, FontStyle.Bold);
		lbTitel.Location = new Point(24, 8);
		lbTitel.Size = new Size(384, 32);
		lbTitel.TextAlign = ContentAlignment.MiddleCenter;
		Controls.Add(lbTitel);

		Label lbRot = new Label();
		lbRot.Location = new Point(32, 66);
		lbRot.Size = new Size(48, 16);
		lbRot.Text = "Rot";
		Controls.Add(lbRot);

		Label lbGruen = new Label(); ;
		lbGruen.Location = new Point(32, 114);
		lbGruen.Size = new Size(48, 16);
		lbGruen.Text = "Grün";
		Controls.Add(lbGruen);

		Label lbBlau = new Label();
		lbBlau.Location = new Point(32, 170);
		lbBlau.Size = new Size(48, 16);
		lbBlau.Text = "Blau";
		Controls.Add(lbBlau);

		Label lbAlpha = new Label();
		lbAlpha.Location = new Point(32, 226);
		lbAlpha.Size = new Size(48, 16);
		lbAlpha.Text = "Alpha";
		Controls.Add(lbAlpha);

		Label lbForm = new Label();
		lbForm.Location = new Point(32, 274);
		lbForm.Size = new Size(48, 16);
		lbForm.Text = "Form";
		Controls.Add(lbForm);

		panel = new Panel();
		panel.BorderStyle = BorderStyle.Fixed3D;
		panel.Location = new Point(168, 64);
		panel.Name = "panel";
		panel.Size = new Size(240, 184);
		panel.Paint += new PaintEventHandler(PanelOnPaint);
		Controls.Add(panel);

		numUpDownRot = new NumericUpDown();
		numUpDownRot.Location = new Point(80, 64);
		numUpDownRot.Size = new Size(75, 20);
		numUpDownRot.Maximum = 255;
		numUpDownRot.Value = 127;
		Controls.Add(numUpDownRot);
		numUpDownRot.ValueChanged +=
			new System.EventHandler(NumericUpDownOnSelectedItemChanged);

		numUpDownGruen = new NumericUpDown();
		numUpDownGruen.Location = new Point(80, 112);
		numUpDownGruen.Size = new Size(75, 20);
		numUpDownGruen.Maximum = 255;
		numUpDownGruen.Value = 127;
		Controls.Add(numUpDownGruen);
		numUpDownGruen.ValueChanged +=
			new System.EventHandler(NumericUpDownOnSelectedItemChanged);

		numUpDownBlau = new NumericUpDown();
		numUpDownBlau.Location = new Point(80, 168);
		numUpDownBlau.Size = new Size(75, 20);
		numUpDownBlau.Maximum = 255;
		numUpDownBlau.Value = 127;
		Controls.Add(numUpDownBlau);
		numUpDownBlau.ValueChanged +=
			new System.EventHandler(NumericUpDownOnSelectedItemChanged);

		numUpDownAlpha = new NumericUpDown();
		numUpDownAlpha.Location = new Point(80, 224);
		numUpDownAlpha.Size = new Size(75, 20);
		numUpDownAlpha.Maximum = 255;
		numUpDownAlpha.Value = 255;
		Controls.Add(numUpDownAlpha);
		numUpDownAlpha.ValueChanged +=
			new System.EventHandler(NumericUpDownOnSelectedItemChanged);

		domainUpDown = new DomainUpDown();
		domainUpDown.Items.Add("Ellipse");
		domainUpDown.Items.Add("Rechteck");
		domainUpDown.Location = new Point(80, 272);
		domainUpDown.Size = new Size(75, 20);
		domainUpDown.ReadOnly = true;
		domainUpDown.SelectedIndex = 0;
		Controls.Add(domainUpDown);
		domainUpDown.SelectedItemChanged +=
			new System.EventHandler(DomainUpDownOnSelectedItemChanged);
	}
	void PanelOnPaint(object sender, PaintEventArgs e) {
		Graphics g = e.Graphics;
		Panel pan = (Panel)sender;
		Brush brush = new SolidBrush(Color.FromArgb((int)numUpDownAlpha.Value,
			(int)numUpDownRot.Value, (int)numUpDownGruen.Value, (int)numUpDownBlau.Value));
		if (domainUpDown.SelectedIndex == 0) {
			g.FillEllipse(brush, 0, 0, pan.Width - 5, pan.Height - 5);
		} else
			g.FillRectangle(brush, 0, 0, pan.Width - 5, pan.Height - 5);
		brush.Dispose();
	}

	void NumericUpDownOnSelectedItemChanged(object sender, System.EventArgs e) {
		panel.Refresh();
	}

	void DomainUpDownOnSelectedItemChanged(object sender, System.EventArgs e) {
		panel.Refresh();
	}

	public static void Main() {
		Application.Run(new UpDown());
	}
}

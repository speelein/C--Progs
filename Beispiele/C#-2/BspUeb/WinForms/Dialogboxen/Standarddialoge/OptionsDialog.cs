using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

class OptionsDialog : Form {
	CheckBox ckbxWordWrap, ckbxHorBar, ckbxVertBar;
	NumericUpDown updwnZoomFactor;

	public event EventHandler Apply;
	
	public OptionsDialog() {
		Text = "Optionen";
		MaximizeBox = false;
		MinimizeBox = false;
		FormBorderStyle = FormBorderStyle.FixedDialog;
		ClientSize = new Size(310, 170);
		StartPosition = FormStartPosition.Manual;
		Location = ActiveForm.DesktopLocation + ActiveForm.Size - ActiveForm.ClientSize;

		Button btnOK = new Button();
		btnOK.Text = "OK";
		btnOK.Parent = this;
		btnOK.Location = new Point(20, 130);
		AcceptButton = btnOK;
		btnOK.DialogResult = DialogResult.OK;

		Button btnCancel = new Button();
		btnCancel.Text = "Abbrechen";
		btnCancel.Parent = this;
		btnCancel.Location = new Point(110, 130);
		CancelButton = btnCancel;
		btnCancel.DialogResult = DialogResult.Cancel;

		Button btnApply = new Button();
		btnApply.Text = "Übernehmen";
		btnApply.Width = 90;
		btnApply.Parent = this;
		btnApply.Location = new Point(200, 130);
		btnApply.Click += new EventHandler(ButtonApplyOnClick);

		ckbxWordWrap = new CheckBox();
		ckbxWordWrap.Text = "Zeilenumbruch";
		ckbxWordWrap.Location = new Point(20, 20);
		ckbxWordWrap.Parent = this;

		ckbxHorBar = new CheckBox();
		ckbxHorBar.Text = "Horizontale Bildlaufleiste";
		ckbxHorBar.Location = new Point(20, 50);
		ckbxHorBar.Width = 100;
		ckbxHorBar.Parent = this;
		
		ckbxVertBar = new CheckBox();
		ckbxVertBar.Text = "Vertikale Bildlaufleiste";
		ckbxVertBar.Location = new Point(20, 80);
		ckbxVertBar.Parent = this;

		updwnZoomFactor = new NumericUpDown();
		updwnZoomFactor.Location = new Point(130, 50);
		updwnZoomFactor.Size = new Size(50, 50);
		updwnZoomFactor.Minimum = 64;
		updwnZoomFactor.Increment = 5;
		updwnZoomFactor.Maximum = 640;
		updwnZoomFactor.Value = 100;
		updwnZoomFactor.Parent = this;

		Label lbZoomFactor = new Label();
		lbZoomFactor.Location = new Point(190, 50);
		lbZoomFactor.Text = "Zoom-Faktor in %";
		lbZoomFactor.Parent = this;
	}

	protected void ButtonApplyOnClick(object sender, EventArgs ea) {
		if (Apply != null)
			Apply(this, EventArgs.Empty);
	}	

	public bool WordWrap {
		get {return ckbxWordWrap.Checked;}
		set {ckbxWordWrap.Checked = value;}
	}

	public RichTextBoxScrollBars ScrollBars {
		get {
			if (ckbxHorBar.Checked)
				if (ckbxVertBar.Checked)
					return RichTextBoxScrollBars.Both;
				else
					return RichTextBoxScrollBars.Horizontal;
			else
				if (ckbxVertBar.Checked)
					return RichTextBoxScrollBars.Vertical;
				else
					return RichTextBoxScrollBars.None;
		}
		set {
			switch (value) {
					case RichTextBoxScrollBars.Both:
							ckbxHorBar.Checked = true;
							ckbxVertBar.Checked = true;
							break;
					case RichTextBoxScrollBars.Horizontal:
							ckbxHorBar.Checked = true;
							ckbxVertBar.Checked = false;
							break;
					case RichTextBoxScrollBars.Vertical:
							ckbxHorBar.Checked = false;
							ckbxVertBar.Checked = true;
							break;
					case RichTextBoxScrollBars.None:
							ckbxHorBar.Checked = false;
							ckbxVertBar.Checked = false;
							break;
			}
		}
	}

	public float ZoomFactor {
		get {return (float) updwnZoomFactor.Value/100;}
		set {updwnZoomFactor.Value = (decimal) (value * 100);}
	}
}

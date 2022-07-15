using System;
using System.Windows.Forms;
using System.Drawing;

class OptionsDialog : Form {
	CheckBox chkWordWrap, chkHorBar, chkVertBar;
	Button cmdApply;
	NumericUpDown updwnZoomFactor;

	public event EventHandler Apply;

	public OptionsDialog(Form owner) {
		Text = "Optionen";
		MaximizeBox = false;
		MinimizeBox = false;
		FormBorderStyle = FormBorderStyle.FixedDialog;
		ClientSize = new Size(310, 170);
		StartPosition = FormStartPosition.Manual;
		Owner = owner;
		Location = Owner.DesktopLocation +
			new Size(Owner.ClientSize.Width / 5, Owner.ClientSize.Height / 2);
		
		Button cmdOK = new Button();
		cmdOK.Text = "OK";
		cmdOK.Parent = this;
		cmdOK.Location = new Point(20, 130);
		AcceptButton = cmdOK;
		cmdOK.DialogResult = DialogResult.OK;

		Button cmdCancel = new Button();
		cmdCancel.Text = "Abbrechen";
		cmdCancel.Parent = this;
		cmdCancel.Location = new Point(110, 130);
		CancelButton = cmdCancel;
		cmdCancel.DialogResult = DialogResult.Cancel;

		cmdApply = new Button();
		cmdApply.Text = "Übernehmen";
		cmdApply.Width = 90;
		cmdApply.Parent = this;
		cmdApply.Location = new Point(200, 130);
		cmdApply.Click += new EventHandler(ButtonApplyOnClick);

		chkWordWrap = new CheckBox();
		chkWordWrap.Text = "Zeilenumbruch";
		chkWordWrap.Location = new Point(20, 20);
		chkWordWrap.Parent = this;

		chkHorBar = new CheckBox();
		chkHorBar.Text = "Horizontale Bildlaufleiste";
		chkHorBar.Location = new Point(20, 50);
		chkHorBar.Width = 100;
		chkHorBar.Parent = this;
		
		chkVertBar = new CheckBox();
		chkVertBar.Text = "Vertikale Bildlaufleiste";
		chkVertBar.Location = new Point(20, 80);
		chkVertBar.Parent = this;

		updwnZoomFactor = new NumericUpDown();
		updwnZoomFactor.Location = new Point(130, 50);
		updwnZoomFactor.Size = new Size(50, 50);
		updwnZoomFactor.Minimum = 64;
		updwnZoomFactor.Increment = 5;
		updwnZoomFactor.Maximum = 640;
		updwnZoomFactor.Value = 100;
		updwnZoomFactor.Parent = this;

		Label lblZoomFactor = new Label();
		lblZoomFactor.Location = new Point(190, 50);
		lblZoomFactor.Text = "Zoom-Faktor in %";
		lblZoomFactor.Parent = this;
	}

	public bool WordWrap {
		get {return chkWordWrap.Checked;}
		set {chkWordWrap.Checked = value;}
	}

	public RichTextBoxScrollBars ScrollBars {
		get {
			if (chkHorBar.Checked)
				if (chkVertBar.Checked)
					return RichTextBoxScrollBars.Both;
				else
					return RichTextBoxScrollBars.Horizontal;
			else
				if (chkVertBar.Checked)
					return RichTextBoxScrollBars.Vertical;
				else
					return RichTextBoxScrollBars.None;
		}
		set {
			switch (value) {
					case RichTextBoxScrollBars.Both:
							chkHorBar.Checked = true;
							chkVertBar.Checked = true;
							break;
					case RichTextBoxScrollBars.Horizontal:
							chkHorBar.Checked = true;
							chkVertBar.Checked = false;
							break;
					case RichTextBoxScrollBars.Vertical:
							chkHorBar.Checked = false;
							chkVertBar.Checked = true;
							break;
					case RichTextBoxScrollBars.None:
							chkHorBar.Checked = false;
							chkVertBar.Checked = false;
							break;
			}
		}
	}

	public float ZoomFactor {
		get {return (float) updwnZoomFactor.Value/100;}
		set {updwnZoomFactor.Value = (decimal) (value * 100);}
	}

	protected void ButtonApplyOnClick(object sender, EventArgs ea) {
		if (Apply != null) {
			Apply(this, EventArgs.Empty);
		}
	}
}

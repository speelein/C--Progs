using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

class SuchDialog : Form {
	TextBox tbSuchText;
		
	public event EventHandler Weitersuchen;
	
	public SuchDialog() {
		Text = "Suchen";
		MaximizeBox = false;
		MinimizeBox = false;
		ShowInTaskbar = false;
		FormBorderStyle = FormBorderStyle.FixedDialog;
		ClientSize = new Size(430, 100);
		StartPosition = FormStartPosition.Manual;
		Location = ActiveForm.DesktopLocation + ActiveForm.Size - ActiveForm.ClientSize;
		Label lbSuchen = new Label();
		lbSuchen.Text = "Suchen nach:";
		lbSuchen.Parent = this;
		lbSuchen.Location = new Point(10, 20);
		lbSuchen.Width = 80;

		tbSuchText = new TextBox();
		tbSuchText.Parent = this;
		tbSuchText.Location = new Point(100, 20);
		tbSuchText.Size = new Size(200, Font.Height);
		
		Button btnNext = new Button();
		btnNext.Text = "Weitersuchen";
		btnNext.Parent = this;
		btnNext.Location = new Point(320, 20);
		btnNext.Width = 90;
		AcceptButton = btnNext;
		btnNext.Click += new EventHandler(ButtonNextOnClick);
	
		Button btnCancel = new Button();
		btnCancel.Text = "Abbrechen";
		btnCancel.Parent = this;
		btnCancel.Location = new Point(320, 60);
		btnCancel.Width = 90;
		CancelButton = btnCancel;
		btnCancel.Click += new EventHandler(ButtonCancelOnClick);
	}

	protected void ButtonNextOnClick(object sender, EventArgs ea) {
		if (tbSuchText.Text.Length > 0 && Weitersuchen != null)
			Weitersuchen(this, EventArgs.Empty);
	}
	
	protected void ButtonCancelOnClick(object sender, EventArgs ea) {
		Verstecken();
	}

	protected override void OnClosing(CancelEventArgs cea) {
		cea.Cancel = true;
		Verstecken();
	}

	protected void Verstecken() {
		tbSuchText.Focus();
		Hide();
		Owner.Activate();
	}
	
	public string SuchText {
		get { return tbSuchText.Text;}
		set {tbSuchText.Text = value;}
	}
}

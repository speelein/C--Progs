using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

class SearchDialog : Form {
	TextBox tbSearchText;
		
	public event EventHandler FindNext;
	
	public SearchDialog(Form owner) {
		Text = "Suchen";
		MaximizeBox = false;
		MinimizeBox = false;
		ShowInTaskbar = false;
		FormBorderStyle = FormBorderStyle.FixedDialog;
		ClientSize = new Size(430, 100);
		StartPosition = FormStartPosition.Manual;
		Owner = owner;
		Location = Owner.DesktopLocation +
			new Size(Owner.ClientSize.Width / 5, Owner.ClientSize.Height / 2);

		Label lblSearch = new Label();
		lblSearch.Text = "Suchen nach:";
		lblSearch.Parent = this;
		lblSearch.Location = new Point(10, 20);
		lblSearch.Width = 80;

		tbSearchText = new TextBox();
		tbSearchText.Parent = this;
		tbSearchText.Location = new Point(100, 20);
		tbSearchText.Size = new Size(200, Font.Height);
		
		Button cmdNext = new Button();
		cmdNext.Text = "Weitersuchen";
		cmdNext.Parent = this;
		cmdNext.Location = new Point(320, 20);
		cmdNext.Width = 90;
		AcceptButton = cmdNext;
		cmdNext.Click += new EventHandler(ButtonNextOnClick);
	
		Button cmdCancel = new Button();
		cmdCancel.Text = "Abbrechen";
		cmdCancel.Parent = this;
		cmdCancel.Location = new Point(320, 60);
		cmdCancel.Width = 90;
		CancelButton = cmdCancel;
		cmdCancel.Click += new EventHandler(ButtonCancelOnClick);
	}

	protected void ButtonNextOnClick(object sender, EventArgs ea) {
		if (tbSearchText.Text.Length > 0 && FindNext != null)
			FindNext(this, EventArgs.Empty);
	}
	
	protected void ButtonCancelOnClick(object sender, EventArgs ea) {
		HideSearchDialog();
	}

	protected override void OnClosing(CancelEventArgs cea) {
		cea.Cancel = true;
		HideSearchDialog();
	}

	protected void HideSearchDialog() {
		tbSearchText.Focus();
		tbSearchText.SelectAll();
		Owner.Activate();
		Hide();
	}
	
	public string SearchText {
		get { return tbSearchText.Text;}
		set {tbSearchText.Text = value;}
	}
}

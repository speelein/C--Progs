using System;
using System.Windows.Forms;
using System.Drawing;

class ClipboardInspector : Form {
	ListBox libClipboard;
	CheckBox cbAutoConv;

	public ClipboardInspector() {
		Text = "Clipboard-Inspektor";
		ClientSize = new Size(280, 190);

		Label labClipboard = new Label();
		labClipboard.Text = "Akt. Formate der Zwischenablage (Win32-ID):";
		labClipboard.Location = new Point(20, 20);
		labClipboard.Size = new Size(260, 20);
		labClipboard.Parent = this;

		libClipboard = new ListBox();
		libClipboard.Location = new Point(20, 40);
		libClipboard.Size = new Size(240, 100);
		libClipboard.Parent = this;

		Button btnAkt = new Button();
		btnAkt.Text = "Aktualisieren";
		btnAkt.Width = 80;
		btnAkt.Parent = this;
		btnAkt.Location = new Point(180, 150);
		AcceptButton = btnAkt;
		btnAkt.Click += new EventHandler(AktualisierenOnClick);

		cbAutoConv = new CheckBox();
		cbAutoConv.Text = "Konvertierungs-Formate";
		cbAutoConv.Parent = this;
		cbAutoConv.Width = 150;
		cbAutoConv.Checked = true;
		cbAutoConv.Location = new Point(20, 150);
		cbAutoConv.Click += new EventHandler(CheckBoxOnClick);

		AktualisierenOnClick(this, EventArgs.Empty);
	}

	protected void AktualisierenOnClick(object sender, EventArgs ea) {
		//String data = Clipboard.GetText();
		//MessageBox.Show(data.GetType().FullName);

		//Bitmap image = new Bitmap("eins.bmp");
		//Clipboard.SetDataObject(image);
		//image.RotateFlip(RotateFlipType.Rotate90FlipXY);

		//Font fontAr12Bd = new Font("Arial", 12, FontStyle.Bold);
		//Clipboard.SetDataObject(fontAr12Bd);

		//Font fontAr12Bd = new Font("Arial", 12, FontStyle.Bold);
		//DataObject dataObject = new DataObject();
		//dataObject.SetData("RitchisFontAr12Bd", fontAr12Bd);
		//Clipboard.SetDataObject(dataObject);

		libClipboard.Items.Clear();
		DataFormats.Format clipFormat;
		int id;
		string[] sF = Clipboard.GetDataObject().GetFormats(cbAutoConv.Checked);
		for (int i = 0; i < sF.Length; i++) {
			clipFormat = DataFormats.GetFormat(sF[i]);
			id = clipFormat.Id;
			if (1 <= id && id <= 16)
				libClipboard.Items.Add(clipFormat.Name + " (" + id + ")");
			else
			  libClipboard.Items.Add(clipFormat.Name);
		}
	}

	protected void CheckBoxOnClick(object sender, EventArgs ea) {
		AktualisierenOnClick(this, EventArgs.Empty);
	}

	[STAThread]
	static void Main() {
		Application.Run(new ClipboardInspector());
	}
}

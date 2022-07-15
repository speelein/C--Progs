using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Specialized;

class ClipboardInspector : Form {
	ListBox libClipboard;
	CheckBox cbAutoConv;

	public ClipboardInspector() {
		Text = "Clipboard-Inspektor";
		Size = MinimumSize = new Size(300, 200);

		TableLayoutPanel table = new TableLayoutPanel();
		table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
		table.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
		table.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
		Controls.Add(table);
		table.Dock = DockStyle.Fill;

		TableLayoutPanel row3 = new TableLayoutPanel();
		row3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		row3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		row3.Dock = DockStyle.Fill;
		table.Controls.Add(row3, 0, 2);

		Label labClipboard = new Label();
		labClipboard.Text = "Akt. Formate der Zwischenablage (Win32-ID):";
		labClipboard.Anchor = AnchorStyles.Bottom;
		labClipboard.AutoSize = true;
		table.Controls.Add(labClipboard, 0, 0);

		libClipboard = new ListBox();
		libClipboard.Dock = DockStyle.Fill;
		table.Controls.Add(libClipboard, 0, 1);

		cbAutoConv = new CheckBox();
		cbAutoConv.Text = "Konvertierungsformate";
		row3.Controls.Add(cbAutoConv, 0, 0);
		cbAutoConv.Anchor = AnchorStyles.None;
		cbAutoConv.AutoSize = true;
		cbAutoConv.Checked = true;
		cbAutoConv.Click += new EventHandler(CheckBoxOnClick);

		Button btnAkt = new Button();
		btnAkt.Text = "Aktualisieren";
		btnAkt.AutoSize = true;
		row3.Controls.Add(btnAkt, 1, 0);
		btnAkt.Anchor = AnchorStyles.None;
		AcceptButton = btnAkt;
		btnAkt.Click += new EventHandler(AktualisierenOnClick);

		AktualisierenOnClick(this, EventArgs.Empty);
	}

	protected void AktualisierenOnClick(object sender, EventArgs ea) {

		// Demonstration von Clipboard-Methoden

		//Bitmap image = new Bitmap("eins.bmp");
		//Clipboard.SetImage(image);

		//byte[] b = new byte[] { 1, 2, 3 };
		//Clipboard.SetAudio(b);

		//StringCollection sc = new StringCollection();
		//sc.Add("Eins"); sc.Add("Zwei");
		//Clipboard.SetFileDropList(sc);

		//Clipboard.SetData(DataFormats.Bitmap,13);

		//DataObject dataObject = new DataObject();
		//dataObject.SetData(DataFormats.Bitmap, image);
		//dataObject.SetData(DataFormats.Text, "123");
		//Clipboard.SetDataObject(dataObject, true);

		//Bitmap image = new Bitmap("eins.bmp");
		//Clipboard.SetDataObject(image);
		//image.RotateFlip(RotateFlipType.Rotate90FlipXY);

		//Clipboard.SetDataObject("Text");

		//Font fontAr12Bd = new Font("Arial", 12, FontStyle.Bold);
		//DataObject dataObject = new DataObject();
		//dataObject.SetData("RitchisFontAr12Bd", fontAr12Bd);
		//Clipboard.SetDataObject(dataObject);

		// führt zu einem Ausnahmefehler, wenn die Zwichenablage keine Bitmap-Daten enthält:
		//MessageBox.Show(Clipboard.ContainsImage().ToString());
		//Image image = Clipboard.GetImage();
		//MessageBox.Show(image.GetType().ToString());

		//MessageBox.Show(Clipboard.ContainsText().ToString());
		//MessageBox.Show(Clipboard.GetText().GetType().ToString());
		//MessageBox.Show(Clipboard.GetText());

		libClipboard.Items.Clear();
		DataFormats.Format clipFormat;
		int id;
		String[] sF = Clipboard.GetDataObject().GetFormats(cbAutoConv.Checked);
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
		Application.EnableVisualStyles();
		Application.Run(new ClipboardInspector());
	}
}

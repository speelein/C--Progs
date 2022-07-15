using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

class BoundsChecker : Form {
	PrintDocument pd = new PrintDocument();
	PageSetupDialog pageSetupDialog = new PageSetupDialog();

	public BoundsChecker() {
		Text = "BoundsChecker";
		BackColor = Color.White;

		MenuStrip mainMenue = new MenuStrip();
		mainMenue.Dock = DockStyle.Top;
		Controls.Add(mainMenue);
		ToolStripMenuItem mitPrint, mitPageSetup;
		mitPrint = new ToolStripMenuItem("&Drucken", null, new EventHandler(MitPrintOnClick));
		mitPrint.ShortcutKeys = Keys.Control | Keys.P;
		mitPageSetup = new ToolStripMenuItem("&Seite einrichten", null, new EventHandler(MitPageSetupOnClick));
		mainMenue.Items.AddRange(new ToolStripItem[] {mitPrint, mitPageSetup});

		pd.DocumentName = Text;
		pageSetupDialog.Document = pd;
		pageSetupDialog.EnableMetric = true;
		pd.PrintPage += new PrintPageEventHandler(PrintDocumentOnPrintPage);
	}
	
	void MitPrintOnClick(object sender, EventArgs e) {
		pd.Print();
	}

	void MitPageSetupOnClick(object sender, EventArgs e) {
		pageSetupDialog.ShowDialog();
	}

	void PrintDocumentOnPrintPage(object sender, PrintPageEventArgs e) {
		MessageBox.Show("Drucker: \t" + pd.PrinterSettings.PrinterName + "\n" + "\n" +
			"PageBounds.Left:     \t" + e.PageBounds.Left + "\n" +
			"PageBounds.Width:    \t" + e.PageBounds.Width + "\n" + 
			"PrintableArea.Left:  \t" + e.PageSettings.PrintableArea.Left + "\n" +
			"PrintableArea.Width: \t" + e.PageSettings.PrintableArea.Width + "\n" +
			"VisibleClipBounds.Left:\t" + e.Graphics.VisibleClipBounds.Left + "\n" +
			"VisibleClipBounds.Width:\t" + e.Graphics.VisibleClipBounds.Width + "\n" +
			"MarginBounds.Left:   \t" + e.MarginBounds.Left + "\n" +
			"MarginBounds.Width:  \t" + e.MarginBounds.Right + "\n" +
			"HardMarginX:  \t\t" + e.PageSettings.HardMarginX + "\n" +
			"HardMarginY:  \t\t" + e.PageSettings.HardMarginY, Text);
		e.Cancel = true;
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new BoundsChecker());
	}
}

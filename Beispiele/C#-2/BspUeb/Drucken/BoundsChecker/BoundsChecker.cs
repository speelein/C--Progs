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
		Menu = new MainMenu();
		Menu.MenuItems.Add(new MenuItem("&Drucken", new EventHandler(MitPrintOnClick), Shortcut.CtrlP));
		Menu.MenuItems.Add(new MenuItem("&Seite einrichten", new EventHandler(MitPageSetupOnClick), Shortcut.CtrlP));
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
			"PageBounds.Right:    \t" + e.PageBounds.Right + "\n" + 
			"PrintableArea.Left:  \t" + e.PageSettings.PrintableArea.Left + "\n" +
			"PrintableArea.Right: \t" + e.PageSettings.PrintableArea.Right + "\n" +
			"VisibleClipBounds.Left:\t" + e.Graphics.VisibleClipBounds.Left + "\n" +
			"VisibleClipBounds.Right:\t" + e.Graphics.VisibleClipBounds.Right + "\n" +
			"MarginBounds.Left:   \t" + e.MarginBounds.Left + "\n" +
			"MarginBounds.Right:  \t" + e.MarginBounds.Right, Text);
		e.Cancel = true;
	}
	
	static void Main() {
		Application.Run(new BoundsChecker());
	}
}

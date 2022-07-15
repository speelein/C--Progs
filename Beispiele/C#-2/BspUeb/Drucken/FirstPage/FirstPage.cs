using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

class FirstPage : Form {
	PrinterSettings.StringCollection pc = PrinterSettings.InstalledPrinters;
	PrintDocument pd = new PrintDocument();
	Brush brush = Brushes.Black;

	public FirstPage() {
		Height = 300; Width = 400;
		Text = "FirstPage";
		BackColor = Color.White;
		Menu = new MainMenu();
		Menu.MenuItems.Add(new MenuItem("&Drucken", new EventHandler(MitPrintOnClick), Shortcut.CtrlP));
		pd.DocumentName = Text;
		//pd.DefaultPageSettings.Landscape = true;
		pd.PrintPage += new PrintPageEventHandler(PrintDocumentOnPrintPage);
	}

	protected override void OnPaint(PaintEventArgs e) {
		DrawToDevice(e.Graphics);
	}

	void DrawToDevice(Graphics g) {
		g.DrawString("Installierte Drucker:", Font, brush, 10, Font.Height);
		for (int i = 0; i < pc.Count; i++)
			g.DrawString(pc[i], Font, brush, 20, (i + 2) * Font.Height);
		g.DrawString("Standarddrucker:", Font, brush, 10, (pc.Count+3)*Font.Height);
		g.DrawString("PrinterName:\t"+pd.PrinterSettings.PrinterName, Font, brush, 20, (pc.Count+4)*Font.Height);
		g.DrawString("IsValid:   \t"+pd.PrinterSettings.IsValid.ToString(), Font, brush, 20, (pc.Count + 5) * Font.Height);
	}
	
	void MitPrintOnClick(object sender, EventArgs e) {
		pd.Print();
	}
	
	void PrintDocumentOnPrintPage(object sender, PrintPageEventArgs e) {
		DrawToDevice(e.Graphics);		
	}
	
	static void Main() {
		Application.Run(new FirstPage());
	}
}

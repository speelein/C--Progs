using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

class FirstPage : Form {
	PrinterSettings.StringCollection pc = PrinterSettings.InstalledPrinters;
	PrintDocument pd = new PrintDocument();
	Brush brush;
	MenuStrip mainMenue;

	public FirstPage() {
		Height = 300; Width = 400;
		Text = "FirstPage";
		BackColor = Color.White;
		brush = Brushes.Black;

		mainMenue = new MenuStrip();
		mainMenue.Dock = DockStyle.Top;
		Controls.Add(mainMenue);
		ToolStripMenuItem mitPrint;
		mitPrint = new ToolStripMenuItem("&Drucken", null, new EventHandler(MitPrintOnClick));
		mitPrint.ShortcutKeys = Keys.Control | Keys.P;
		mainMenue.Items.Add(mitPrint);

		pd.DocumentName = Text;
		//pd.DefaultPageSettings.Landscape = true;
		pd.PrintPage += new PrintPageEventHandler(PrintDocumentOnPrintPage);
	}

	protected override void OnPaint(PaintEventArgs e) {
		DrawToDevice(e.Graphics);
	}

	void DrawToDevice(Graphics g) {
		int vpos = mainMenue.Height + 10;
		int rand = 10;
		int indent = 20;
		g.DrawString("Installierte Drucker:", Font, brush, rand, vpos);
		for (int i = 0; i < pc.Count; i++)
			g.DrawString(pc[i], Font, brush, rand+indent, vpos + (i+2)*Font.Height);
		vpos = vpos + pc.Count*Font.Height + 4*Font.Height;
		g.DrawString("Standarddrucker:", Font, brush, rand, vpos);
		g.DrawString("PrinterName:\t"+pd.PrinterSettings.PrinterName,
			Font, brush, rand+indent, vpos + 2*Font.Height);
		g.DrawString("IsValid:   \t"+pd.PrinterSettings.IsValid.ToString(),
			Font, brush, rand + indent, vpos + 3 * Font.Height);
	}
	
	void MitPrintOnClick(object sender, EventArgs e) {
		pd.Print();
	}
	
	void PrintDocumentOnPrintPage(object sender, PrintPageEventArgs e) {
		DrawToDevice(e.Graphics);		
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new FirstPage());
	}
}

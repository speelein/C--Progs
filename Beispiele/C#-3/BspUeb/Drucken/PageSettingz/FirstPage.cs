using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

class PageSettingz : Form {
	PrintDocument pd;
	Brush brush = Brushes.Black;

	public PageSettingz() {
		Text = "PageSettingz";
		pd = new PrintDocument();
		pd.PrinterSettings.PrinterName = "QMS 3825 Print System";
		pd.DefaultPageSettings.Color = true;
	}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
		g.DrawString("pd.PrinterSettings.PrinterName:\t" + pd.PrinterSettings.PrinterName, Font, brush, 20, Font.Height);
		g.DrawString("pd.PrinterSettings.SupportsColor:\t" + pd.PrinterSettings.SupportsColor, Font, brush, 20, 3 * Font.Height);
		g.DrawString("pd.DefaultPageSettings.Color:\t" + pd.DefaultPageSettings.Color, Font, brush, 20, 5 * Font.Height);
		g.DrawString("pd.DefaultPageSettings.PrinterSettings.PrinterName:\t" + pd.DefaultPageSettings.PrinterSettings.PrinterName, Font, brush, 20, 7 * Font.Height);
	}

	[STAThread]
	static void Main() {
		Application.Run(new PageSettingz());
	}
}

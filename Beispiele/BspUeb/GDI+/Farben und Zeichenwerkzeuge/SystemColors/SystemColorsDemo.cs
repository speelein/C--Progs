using System;
using System.Windows.Forms;
using System.Drawing;

class SystemColorsDemo : Form {

	public SystemColorsDemo() {
		Text = "SystemColor-Demo";
		Size = new Size(320, 150);
	}

	protected override void OnPaint(PaintEventArgs e) {
		e.Graphics.DrawString("Können Sie das lesen?", new Font("Arial", 20, FontStyle.Bold), new
													SolidBrush(SystemColors.WindowText), 3, 40);
		//e.Graphics.DrawString("Können Sie das lesen?", new Font("Arial", 20, FontStyle.Bold),
		// SystemBrushes.WindowText, 3, 40);
	}

	static void Main() {
		Application.Run(new SystemColorsDemo());
	}
}

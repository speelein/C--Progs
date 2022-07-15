using System;
using System.Windows.Forms;
using System.Drawing;

class SystemColorsDemo : Form {
	Font ab20 = new Font("Arial", 20, FontStyle.Bold);
	SolidBrush sbText = new SolidBrush(SystemColors.WindowText);

	SystemColorsDemo() {
		Text = "SystemColors-Demo";
		Size = new Size(380, 160);
	}

	protected override void OnPaint(PaintEventArgs e) {
		//e.Graphics.DrawString("SystemColors.WindowText", ab20, sbText, 3, 40);
		e.Graphics.DrawString("SystemColors.WindowText", ab20,
			SystemBrushes.WindowText, 3, 40);
	}

	[STAThread]
	static void Main() {
		Application.Run(new SystemColorsDemo());
	}
}

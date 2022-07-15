using System;
using System.Windows.Forms;

class RitchisTexteditor : Form {
	RitchisTexteditor() {
		Text = "Ritchis Texteditor";
		RichTextBox editor = new RichTextBox();
		editor.Dock = DockStyle.Fill;
		editor.AcceptsTab = true;
		Controls.Add(editor);
	}

	[STAThread]
	static void Main() {
		Application.Run(new RitchisTexteditor());
	}
}
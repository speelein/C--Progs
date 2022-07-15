using System;
using System.Windows.Forms;

class RitchisTexteditor : Form {
	public RitchisTexteditor() {
		Text = "Ritchis Texteditor";
		RichTextBox editor = new RichTextBox();
		editor.Dock = DockStyle.Fill;
		Controls.Add(editor);
	}

	static void Main() {
		Application.Run(new RitchisTexteditor());
	}
}
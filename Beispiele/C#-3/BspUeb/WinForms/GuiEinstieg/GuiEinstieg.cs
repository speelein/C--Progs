using System.Windows.Forms;
class GuiEinstieg : Form {
	GuiEinstieg() {
		Text = "WinForms-Einstieg";
	}
	static void Main() {
		GuiEinstieg hf = new GuiEinstieg();
		Application.Run(hf);
	}
}

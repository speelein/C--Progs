using System;
using System.Runtime.InteropServices;

class Win32MessageBox {
	[DllImport("user32.dll")]
	static extern int MessageBox(int hWnd, string text, string titel, int typ);

	static void Main() {
		MessageBox(0, "MessageBox-Vergleich", "Win32-API", 0);
		System.Windows.Forms.MessageBox.Show("MessageBox-Vergleich", ".NET");
	}
}

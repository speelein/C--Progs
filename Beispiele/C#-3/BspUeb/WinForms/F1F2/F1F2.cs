using System;
using System.Windows.Forms;
class F1F2 : Form {
	F1F2(String titel) {
		Text = titel;
	}
	static void Main() {
		F1F2 p1 = new F1F2("F1");
		F1F2 p2 = new F1F2("F2");
		p2.Show();
		Application.Run(p1);
	}
}

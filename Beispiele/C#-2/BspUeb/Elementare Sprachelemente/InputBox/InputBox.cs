using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

class InputBox {
	static void Main() {
		int zahl = Convert.ToInt32(
				Interaction.InputBox("Ihre Lieblingszahl?", "InputBox", "", -1, -1)
                );
		MessageBox.Show("Verstanden: "+zahl);
	}
}

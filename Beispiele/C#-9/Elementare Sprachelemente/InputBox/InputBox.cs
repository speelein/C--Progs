using System;
using System.Windows;
using Microsoft.VisualBasic;

class InputBox {
    static void Main() {
        string eingabe = Interaction.InputBox("Ihre Lieblingszahl?", "InputBox", "", -1, -1);
        int zahl = Convert.ToInt32(eingabe);
        MessageBox.Show("Verstanden: " + zahl);
    }
}

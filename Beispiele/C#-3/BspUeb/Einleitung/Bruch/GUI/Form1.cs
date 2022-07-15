using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BruchKürzenGui {
    public partial class Form1 : Form {
        Bruch b = new Bruch();

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                b.Zaehler = Convert.ToInt32(textBox1.Text);
                b.Nenner = Convert.ToInt32(textBox2.Text);
                b.Kuerze();
                textBox1.Text = Convert.ToString(b.Zaehler);
                textBox2.Text = Convert.ToString(b.Nenner);
            } catch {
                MessageBox.Show("Eingabefehler", "Fehler", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }
    }
}

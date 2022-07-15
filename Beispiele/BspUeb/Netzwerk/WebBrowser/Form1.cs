using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyBrowser {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) {
            String s = textBox1.Text;
            if (!s.StartsWith("http://"))
                s = "http://" + s;
            try {
                webBrowser1.Navigate(new Uri(s));
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            webBrowser1.GoBack();
        }

        private void button3_Click(object sender, EventArgs e) {
            webBrowser1.GoForward();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) {

        }
    }
}
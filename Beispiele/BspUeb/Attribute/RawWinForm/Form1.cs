using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RawWinForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show("Version "+Application.ProductVersion,
                            Application.ProductName, MessageBoxButtons.OK,
                            MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ApplicationSettingsVS {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			ColorDialog	colorDialog = new ColorDialog();
			if (colorDialog.ShowDialog() == DialogResult.OK) {
				this.BackColor = colorDialog.Color;
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			global::ApplicationSettingsVS.Properties.Settings.Default.Save();
		}
	}
}
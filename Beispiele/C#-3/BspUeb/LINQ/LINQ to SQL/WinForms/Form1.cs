using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinqToSqlWinForms;

namespace LinqToSqlWinForms {
	public partial class Form1 : Form {
		NorthwindDataContext dc;

		public Form1() {
			InitializeComponent();
			dc = new NorthwindDataContext();
		}

		private void button1_Click(object sender, EventArgs e) {
			dataGridView.DataSource = dc.Customers;
		}

		private void button2_Click(object sender, EventArgs e) {
			dataGridView.DataSource = dc.Orders;
		}
	}
}

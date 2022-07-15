using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Datenquelle {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
			this.Validate();
			this.customersBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.nORTHWNDDataSet);

		}

		private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e) {
			this.Validate();
			this.customersBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.nORTHWNDDataSet);

		}

		private void Form1_Load(object sender, EventArgs e) {
			// TODO: Diese Codezeile lädt Daten in die Tabelle "nORTHWNDDataSet.Customers". Sie können sie bei Bedarf verschieben oder entfernen.
			this.customersTableAdapter.Fill(this.nORTHWNDDataSet.Customers);

		}
	}
}

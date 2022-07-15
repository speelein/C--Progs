// Skizze für einen TreeView zur Datenerfassung
// mit primitiven TreeNode-Editor:
//   + fügt einen Unterknoten zum markierten Knoten ein
//   - entfernt den markierten Knoten

using System;
using System.Windows.Forms;
using System.Drawing;

class TreeViewInput : Form {
	TreeView tv;

	TreeViewInput() {
		Text = "TreeView - Datenerfassung";

		tv = new TreeView();
		tv.Parent = this;
		tv.Dock = DockStyle.Fill;
		tv.BackColor = SystemColors.Control;
		tv.CheckBoxes = true;
		tv.LabelEdit = true;

		tv.Nodes.Add("Scanner");
		tv.Nodes[0].Nodes.Add("Canon");
		tv.Nodes[0].Nodes.Add("Panasonic");
		tv.Nodes[0].Nodes.Add("Kodak");
		tv.Nodes[0].Nodes[0].Nodes.Add("M 3060");
		tv.Nodes[0].Nodes[0].Nodes.Add("M 3080");
		tv.Nodes[0].Nodes[1].Nodes.Add("X Delta");
		tv.Nodes[0].Nodes[1].Nodes.Add("Y Zeta");
		tv.Nodes[0].Nodes[2].Nodes.Add("9001");
		tv.Nodes[0].Nodes[2].Nodes.Add("9004");

		tv.Nodes.Add("Drucker");
		tv.Nodes[1].Nodes.Add("Canon");
		tv.Nodes[1].Nodes.Add("HP");
		tv.Nodes[1].Nodes.Add("Minolta");
		tv.Nodes[1].Nodes[0].Nodes.Add("PIXMA IP 4000");
		tv.Nodes[1].Nodes[0].Nodes.Add("PIXMA IP 5000");
		tv.Nodes[1].Nodes[1].Nodes.Add("QuickPix 3000");
		tv.Nodes[1].Nodes[1].Nodes.Add("PS 7");
		tv.Nodes[1].Nodes[2].Nodes.Add("Magic 2000");
		tv.Nodes[1].Nodes[2].Nodes.Add("FinePix 56");

		tv.KeyPress += new KeyPressEventHandler(TreeViewOnkeyPress);
	}

	void TreeViewOnkeyPress(object sender, KeyPressEventArgs e) {
		if (e.KeyChar == (char) '+')
			tv.SelectedNode.Nodes.Add("Neu");
		else if (e.KeyChar == (char)'-' &&  tv.SelectedNode != tv.Nodes[0])
			tv.SelectedNode.Remove();
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new TreeViewInput());
	}
}
using System;
using System.Windows.Forms;
using System.Drawing;

public class TreeViewDemo : Form {

	public TreeViewDemo() {
		Text = "TreeView";

		TreeView tv = new TreeView();
		tv.Parent = this;
		tv.Dock = DockStyle.Fill;

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
		//TreeNode minolta = tv.Nodes[1].Nodes[2];
		//minolta.Nodes.Add("Magic 2000");
		//minolta.Nodes.Add("FinePix 56");
	}
		
	public static void Main() {
		Application.Run(new TreeViewDemo());
	}
}

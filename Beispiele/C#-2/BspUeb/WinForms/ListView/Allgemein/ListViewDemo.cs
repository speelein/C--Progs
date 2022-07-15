using System;
using System.Windows.Forms;

public class ListViewDemo : Form 	{

	public ListViewDemo() {
		Text = "ListView-Demo";
	
		ListView lv = new ListView();
		lv.Parent = this;
		lv.Dock = DockStyle.Fill;
		lv.View = View.Details;
		lv.Sorting = SortOrder.Ascending;
		//lv.CheckBoxes = true;
		//lv.LabelEdit = true;
		
		lv.Columns.Add("Name", 120,  HorizontalAlignment.Left);
		lv.Columns.Add("Preis", 100,  HorizontalAlignment.Right);
		lv.Columns.Add("Kalorien", 100, HorizontalAlignment.Right);

		String[] namen = {"Lecker & Gesund", "Beckerstolz",
		                  "Die gute Paste", "Prima fürs Brot"};
		double[] preise = {2.34, 1.78, 2.19, 0.78};
		int[] kalorien = {57, 77, 121, 85};
		for (int i = 0; i < namen.Length; i++) {
			ListViewItem lvi = new ListViewItem(namen[i]);
			lv.Items.Add(lvi);
			lvi.SubItems.Add(preise[i].ToString());
			lvi.SubItems.Add(kalorien[i].ToString());
		}
	}
		
	public static void Main() {
		Application.Run(new ListViewDemo());
	}
}

using System;
using System.Windows.Forms;
using System.Drawing;

class TableLayoutPanelDemo : Form {
	Label stand;
	long anzahl;
	Button count, reset;
	
    public TableLayoutPanelDemo() {
        Height = 100; Width = 250;
        Text = "Multi Purpose Counter";
        MinimumSize = new Size(Width, Height);
        
        TableLayoutPanel table = new TableLayoutPanel();
        //table.ColumnCount = 3;
        //table.RowCount = 1;
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        Controls.Add(table);
        table.Dock = DockStyle.Fill;
        
        stand = new Label();
        stand.Text = anzahl.ToString();
        stand.Font = new Font("Arial", 24);
        stand.AutoSize = true;
        table.Controls.Add(stand, 0, 0);
        stand.Anchor = AnchorStyles.None;

        count = new Button();
        count.Text = "Count";
        table.Controls.Add(count, 1, 0);
        count.Anchor = AnchorStyles.None;

        reset = new Button();
        reset.Text = "Reset";
        table.Controls.Add(reset, 2, 0);
        reset.Anchor = AnchorStyles.None;

        EventHandler eh = new EventHandler(ButtonOnClick);
        count.Click += eh;
        reset.Click += eh;
    }

	void ButtonOnClick(object sender, EventArgs e) {
		if (sender == count)
			anzahl++;
		else
			anzahl = 0;
		stand.Text = anzahl.ToString();
	}

	static void Main() {
		Application.Run(new TableLayoutPanelDemo());
	}
}

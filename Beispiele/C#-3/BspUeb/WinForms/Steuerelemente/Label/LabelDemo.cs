using System;
using System.Windows.Forms;
using System.Drawing;

class LabelDemo : Form {
    LabelDemo() {
		Size = new Size(400, 200);
        BackColor = Color.LightGray;
	    Text = "Label-Demo";

		Label info = new Label();
	    info.Text = "Demo-Label";
		info.Size = new Size(120, 30);
		//info.Width = 120;
		//info.Height = 30;
	    info.Left = (ClientSize.Width-info.Width)/2;
	    info.Top = (ClientSize.Height-info.Height)/2;
		info.Font = new Font("Times New Roman", 15);
		info.TextAlign = ContentAlignment.MiddleCenter;
	    info.BorderStyle = BorderStyle.FixedSingle;

	    Controls.Add(info);
		//info.Parent = this;
	    info.Click += new EventHandler(InfoOnClick);
    }

    void InfoOnClick(object sender, EventArgs e) {
	    if (BackColor == Color.Beige)
		    BackColor = Color.LightGray;
	    else
		    BackColor = Color.Beige;
    }

    static void Main() {
	    Application.Run(new LabelDemo());
    }
}

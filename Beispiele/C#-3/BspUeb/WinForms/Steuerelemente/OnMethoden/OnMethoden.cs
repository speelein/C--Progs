using System;
using System.Windows.Forms;

class OnMethodenDemo : Form {
	Label lab;
	OnMethodenDemo() {
		Text = "OnMethoden-Demo";
		lab = new Label();
		lab.Parent = this;
		MouseDown += FormOnMouseDown;
	}

	protected override void OnMouseDown(MouseEventArgs e) {
		base.OnMouseDown(e);
		lab.Text = "(" + e.X.ToString() + "; " + e.Y.ToString() + ")";
	}

	void FormOnMouseDown(object sender, MouseEventArgs e) {
		lab.Left = e.X;
		lab.Top = e.Y;
	}

	static void Main() {
		Application.Run(new OnMethodenDemo());
	}
}
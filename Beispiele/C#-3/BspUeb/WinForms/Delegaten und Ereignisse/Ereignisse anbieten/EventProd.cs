using System;
using System.Windows.Forms;

class MyEventArgs : EventArgs {
	public int Pos;
}

delegate void MyDelegate(object sender, MyEventArgs e);

class EventProd : Button {
	public event MyDelegate Seven;
	Random zzg = new Random();
	protected override void OnClick(EventArgs e) {
		base.OnClick(e);
		for (int i = 1; i <= 10; i++) {
			if (zzg.Next(10) == 7 && Seven != null) {
				MyEventArgs mea = new MyEventArgs();
				mea.Pos = i;
				Seven(this, mea);
				break;
			}
		}
	}
}

class EventConsumer : Form {
	EventConsumer() {
		Height = 75; Width = 266;
		Text = "Schalter sendet Ereignisse";
		EventProd ep = new EventProd();
		ep.Text = "Teste Dein Glück!";
		ep.Top = 10;
		ep.Left = 30;
		ep.Width = 200;
		Controls.Add(ep);
		ep.Seven += new MyDelegate(this.EventProdOnSeven);
	}
	void EventProdOnSeven(object sender, MyEventArgs e) {
		MessageBox.Show("7 an Position " + e.Pos + " gezogen",
		  "Ereignis-Verarbeitung");
	}
	static void Main() {
		Application.Run(new EventConsumer());
	}
}

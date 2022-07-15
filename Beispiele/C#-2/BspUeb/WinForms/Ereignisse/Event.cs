using System;
using System.Windows.Forms;

public class MyEventArgs : EventArgs {
	public int Pos;
}

public delegate void SimpleDelegate(object sender, MyEventArgs e);

public class EventProd : Button {
    public event SimpleDelegate Seven;
    Random zzg = new Random();
    override protected void OnClick(EventArgs e) {
        for (int i = 1; i <= 10; i++) {
            if (zzg.Next(10) == 7 && Seven != null) {
                MyEventArgs mea = new MyEventArgs();
                mea.Pos = i;
                Seven(this, mea);
            }
        }
    }
}


class EventConsumer : Form {
    public EventConsumer() {
        Height = 70; Width = 230;
        Text = "Ereignis-Konsument";
        EventProd ep = new EventProd();
        ep.Text = "Teste Dein Glück!";
        ep.Top = 10;
        ep.Left = 10;
        ep.Width = 200;
        Controls.Add(ep);
        ep.Seven += new SimpleDelegate(this.EventProdOnSeven);
    }
    protected void EventProdOnSeven(object sender, MyEventArgs e) {
        MessageBox.Show("7 an Position " + e.Pos + " gezogen",
          "Ereignis-Produzent");
    }
    static void Main() {
        Application.Run(new EventConsumer());
    }
}

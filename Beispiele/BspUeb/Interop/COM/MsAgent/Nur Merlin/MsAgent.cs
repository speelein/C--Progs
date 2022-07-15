using System;
using System.Windows.Forms;
using AgentObjects;
using System.Threading;
using System.Drawing;
	
class MsAgentDemo: Form {
	IAgentCtlCharacterEx merlin;
	Button cbMerlin;

	MsAgentDemo() {
		Text = "ActiveX-Steuerelemente in .NET";
		Width = 450; Height = 140;
		FormBorderStyle = FormBorderStyle.FixedSingle;

		AgentClass agent = new AgentClass();
		agent.Connected = true;
		agent.Characters.Load("merlin", "merlin.acs");
		merlin = agent.Characters["merlin"];

		Label lbInfo = new Label();
		lbInfo.Font = new Font("Arial", 12, FontStyle.Bold);
		lbInfo.Text = "Erfahren Sie Neuigkeiten zu COM und .NET von ...";
		lbInfo.Top = 20; lbInfo.Left = 20; lbInfo.AutoSize = true;
		lbInfo.Parent = this;
		
		cbMerlin = new Button();
		cbMerlin.Text = "Merlin";
		cbMerlin.Top = 60; cbMerlin.Left = 170; cbMerlin.Width = 100;
		cbMerlin.Parent = this;
		cbMerlin.Click += new EventHandler(ButtonOnClick);
	}

	void ButtonOnClick(object sender, EventArgs e) {	
		if (sender == cbMerlin) {
			merlin.Show(true);
			merlin.MoveTo(200, 300, 1000);
			merlin.Play("Greet");
			merlin.Play("Announce");
			merlin.Play("Explain");
			merlin.Speak("Hallo, mein Name ist Merlin, und ich soll hier was zur Integration von COM in .NET erzählen.", null);
			merlin.Play("Explain");
			merlin.Speak("Also, was Sie gerade vor sich sehen, ist ein ActiveX-Steuerelement, das von einem C#-Programm dirigiert wird.", null);
			merlin.Speak("Bei der Steuerung hilft ein .NET-internes Stellvertreter-Objekt, der Runtime Callable Wrapper (RCW).", null);
			merlin.Play("Pleased");
			merlin.Speak("Klappt doch toll, oder?", null);
            merlin.Play("Blink");
            merlin.Play("Confused");
            merlin.Hide(false);

        }
	}
	
	public static void Main() {
		Application.Run(new MsAgentDemo());
	}
}

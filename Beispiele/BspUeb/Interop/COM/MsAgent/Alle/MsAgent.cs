using System;
using System.Windows.Forms;
using AgentObjects;
using System.Threading;
using System.Drawing;
	
class MsAgentDemo: Form {
	IAgentCtlCharacterEx merlin, robby, peedy;
	Button cbMerlin, cbRobby, cbPeedy;

	MsAgentDemo() {
		Text = "ActiveX-Steuerelemente in .NET";
		Width = 450; Height = 140;
		FormBorderStyle = FormBorderStyle.FixedSingle;

		AgentClass agent = new AgentClass();
		agent.Connected = true;
		agent.Characters.Load("merlin", "merlin.acs");
		merlin = agent.Characters["merlin"];

		agent.Characters.Load("robby", "robby.acs");
		robby = agent.Characters["robby"];

		agent.Characters.Load("peedy", "peedy.acs");
		peedy = agent.Characters["peedy"];

		Label lbInfo = new Label();
		lbInfo.Font = new Font("Arial", 12, FontStyle.Bold);
		lbInfo.Text = "Erfahren Sie Neuigkeiten zu COM und .NET von ...";
		lbInfo.Top = 20; lbInfo.Left = 20; lbInfo.AutoSize = true;
		lbInfo.Parent = this;
		
		cbMerlin = new Button();
		cbMerlin.Text = "Merlin";
		cbMerlin.Top = 60; cbMerlin.Left = 20; cbMerlin.Width = 100;
		cbMerlin.Parent = this;
		cbMerlin.Click += new EventHandler(ButtonOnClick);

		cbRobby = new Button();
		cbRobby.Text = "Robby";
		cbRobby.Top = 60; cbRobby.Left = 170; cbRobby.Width = 100;
		cbRobby.Parent = this;
		cbRobby.Click += new EventHandler(ButtonOnClick);

		cbPeedy = new Button();
		cbPeedy.Text = "Peedy";
		cbPeedy.Top = 60; cbPeedy.Left = 320; cbPeedy.Width = 100;
		cbPeedy.Parent = this;
		cbPeedy.Click += new EventHandler(ButtonOnClick);
	}

	void ButtonOnClick(object sender, EventArgs e) {	
		IAgentCtlCharacterEx teacher;
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
			teacher = merlin;
		} else
			if (sender == cbRobby) {
				robby.Show(true);
				robby.MoveTo(600, 500, 800);
				robby.Play("Greet");
				robby.Play("Alert");
				robby.Play("Announce");
				robby.Speak("Hallo, Ich bin der Robby und mache weiter mit der Erklärung.", null);
				robby.Play("Explain");
				robby.Speak("Zunächst braucht man, wie so oft im Leben, auch in einem .NET-Projekt gute Referenzen!", null);			
				robby.Play("GetAttention");
				robby.Play("Explain");
				robby.Speak("In der Visual C# 2005 Express Edition kriegt man die am einfachsten per Dialogbox 'Verweis hinzufügen' hin.", null);
				robby.Play("GetAttention");
				robby.Play("Explain");
				robby.Speak("Auf dem Registerblatt COM finden sich alle installierten COM-Server und ActiveX-Steuerelemente.", null);
				robby.Play("Pleased");
				robby.Speak("Alles klar?", null);
				teacher = robby;
		} else {
				peedy.Show(true);
				peedy.MoveTo(800, 100, 1000);
				peedy.Play("Greet");
				peedy.Play("Alert");
				peedy.Play("Announce");
				peedy.Speak("Hallo, ich bin Peedy und gebe Ihnen jetzt den Rest (der Erklärung)!", null);
				peedy.Play("Explain");
				peedy.GestureAt(12,13);
				peedy.Speak("Legen Sie eine Referenzvariable vom Typ IAgentCtlCharacterEx an, und lassen Sie unseren Boss ein Objekt erzeugen.", null);
				peedy.Play("GetAttention");
				peedy.Speak("Wie es ganz genau geht, weiß ich jetzt grad nicht mehr ...", null);
				peedy.Play("Explain");
				peedy.Speak("Danach können Sie mich jedenfalls wie jedes ordentliche Objekt herumkommandieren, z.B. zum Gruß zwingen.", null);
				peedy.Play("Greet");
				peedy.Play("Pleased");
				peedy.Speak("Gut, oder?", null);
				teacher = peedy;
		}
			teacher.Play("Blink");
			teacher.Play("Confused");
			teacher.Hide(false);
	}
	
	public static void Main() {
		Application.Run(new MsAgentDemo());
	}
}

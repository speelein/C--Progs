/*
 * Created by SharpDevelop.
 * User: baltes
 * Date: 15.02.2005
 * Time: 12:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace DNS
{
	/// <summary>
	/// Description of MainForm.	
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cbToName;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.TextBox tbNumber;
		private System.Windows.Forms.Button cbToNumber;
		private System.Windows.Forms.Label label2;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Run(new MainForm());
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
			this.label2 = new System.Windows.Forms.Label();
			this.cbToNumber = new System.Windows.Forms.Button();
			this.tbNumber = new System.Windows.Forms.TextBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.cbToName = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "IP-Name";
			// 
			// cbToNumber
			// 
			this.cbToNumber.Location = new System.Drawing.Point(24, 152);
			this.cbToNumber.Name = "cbToNumber";
			this.cbToNumber.Size = new System.Drawing.Size(152, 32);
			this.cbToNumber.TabIndex = 2;
			this.cbToNumber.Text = "Name  ->  Nummer";
			this.cbToNumber.Click += new System.EventHandler(this.CbToNumberClick);
			// 
			// tbNumber
			// 
			this.tbNumber.Location = new System.Drawing.Point(120, 32);
			this.tbNumber.Name = "tbNumber";
			this.tbNumber.Size = new System.Drawing.Size(264, 20);
			this.tbNumber.TabIndex = 1;
			this.tbNumber.Text = "";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(120, 96);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(264, 20);
			this.tbName.TabIndex = 1;
			this.tbName.Text = "";
			// 
			// cbToName
			// 
			this.cbToName.Location = new System.Drawing.Point(232, 152);
			this.cbToName.Name = "cbToName";
			this.cbToName.Size = new System.Drawing.Size(152, 32);
			this.cbToName.TabIndex = 2;
			this.cbToName.Text = "Nummer  ->  Name";
			this.cbToName.Click += new System.EventHandler(this.CbToNameClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP-Nummer";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 205);
			this.Controls.Add(this.cbToNumber);
			this.Controls.Add(this.tbNumber);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbToName);
			this.Name = "MainForm";
			this.Text = "DNS-Demo läuft auf dem Rechner: "+Dns.GetHostName();
			this.ResumeLayout(false);
		}
		#endregion
		
		
        void CbToNumberClick(object sender, System.EventArgs e)
        {
            try {
                IPHostEntry host = Dns.GetHostEntry(tbName.Text);
	            tbNumber.Text = host.AddressList[0].ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        void CbToNameClick(object sender, System.EventArgs e)
        {
            try {
                IPHostEntry host = Dns.GetHostEntry(tbNumber.Text);
                tbName.Text = host.HostName;
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(),"Fehler");
            }
        }
		
	}
}

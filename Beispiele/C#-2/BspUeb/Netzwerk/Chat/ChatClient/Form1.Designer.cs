namespace ChatClientNameSpace {
    partial class ChatClient {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutMessage = new System.Windows.Forms.TableLayoutPanel();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.cbSend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutServer = new System.Windows.Forms.TableLayoutPanel();
            this.cbEnd = new System.Windows.Forms.Button();
            this.cbConnect = new System.Windows.Forms.Button();
            this.cbDisconnect = new System.Windows.Forms.Button();
            this.tableLayoutServerLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.tbProtocol = new System.Windows.Forms.TextBox();
            this.tableLayoutMessage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutServer.SuspendLayout();
            this.tableLayoutServerLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMessage
            // 
            this.tableLayoutMessage.ColumnCount = 3;
            this.tableLayoutMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutMessage.Controls.Add(this.tbMessage, 1, 0);
            this.tableLayoutMessage.Controls.Add(this.lbMessage, 0, 0);
            this.tableLayoutMessage.Controls.Add(this.cbSend, 2, 0);
            this.tableLayoutMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutMessage.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMessage.Name = "tableLayoutMessage";
            this.tableLayoutMessage.RowCount = 1;
            this.tableLayoutMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMessage.Size = new System.Drawing.Size(686, 26);
            this.tableLayoutMessage.TabIndex = 1;
            // 
            // tbMessage
            // 
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessage.Location = new System.Drawing.Point(83, 3);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(520, 20);
            this.tbMessage.TabIndex = 0;
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(24, 6);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(53, 13);
            this.lbMessage.TabIndex = 3;
            this.lbMessage.Text = "Nachricht";
            // 
            // cbSend
            // 
            this.cbSend.Location = new System.Drawing.Point(609, 3);
            this.cbSend.Name = "cbSend";
            this.cbSend.Size = new System.Drawing.Size(74, 19);
            this.cbSend.TabIndex = 1;
            this.cbSend.Text = "Abschicken";
            this.cbSend.UseVisualStyleBackColor = true;
            this.cbSend.Click += new System.EventHandler(this.cdSend_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutServer);
            this.panel1.Controls.Add(this.tableLayoutMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 85);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutServer
            // 
            this.tableLayoutServer.ColumnCount = 4;
            this.tableLayoutServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutServer.Controls.Add(this.cbEnd, 3, 0);
            this.tableLayoutServer.Controls.Add(this.cbConnect, 1, 0);
            this.tableLayoutServer.Controls.Add(this.cbDisconnect, 2, 0);
            this.tableLayoutServer.Controls.Add(this.tableLayoutServerLeft, 0, 0);
            this.tableLayoutServer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutServer.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutServer.Name = "tableLayoutServer";
            this.tableLayoutServer.RowCount = 1;
            this.tableLayoutServer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutServer.Size = new System.Drawing.Size(686, 55);
            this.tableLayoutServer.TabIndex = 4;
            // 
            // cbEnd
            // 
            this.cbEnd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbEnd.Location = new System.Drawing.Point(609, 17);
            this.cbEnd.Name = "cbEnd";
            this.cbEnd.Size = new System.Drawing.Size(74, 20);
            this.cbEnd.TabIndex = 2;
            this.cbEnd.Text = "Beenden";
            this.cbEnd.UseVisualStyleBackColor = true;
            this.cbEnd.Click += new System.EventHandler(this.cbEnd_Click);
            // 
            // cbConnect
            // 
            this.cbConnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbConnect.Location = new System.Drawing.Point(449, 17);
            this.cbConnect.Name = "cbConnect";
            this.cbConnect.Size = new System.Drawing.Size(74, 21);
            this.cbConnect.TabIndex = 0;
            this.cbConnect.Text = "Verbinden";
            this.cbConnect.UseVisualStyleBackColor = true;
            this.cbConnect.Click += new System.EventHandler(this.cbConnect_Click);
            // 
            // cbDisconnect
            // 
            this.cbDisconnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbDisconnect.Location = new System.Drawing.Point(529, 17);
            this.cbDisconnect.Name = "cbDisconnect";
            this.cbDisconnect.Size = new System.Drawing.Size(74, 21);
            this.cbDisconnect.TabIndex = 1;
            this.cbDisconnect.Text = "Trennen";
            this.cbDisconnect.UseVisualStyleBackColor = true;
            this.cbDisconnect.Click += new System.EventHandler(this.cbDisconnect_Click);
            // 
            // tableLayoutServerLeft
            // 
            this.tableLayoutServerLeft.ColumnCount = 2;
            this.tableLayoutServerLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutServerLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutServerLeft.Controls.Add(this.tbUserName, 1, 1);
            this.tableLayoutServerLeft.Controls.Add(this.lbUserName, 0, 1);
            this.tableLayoutServerLeft.Controls.Add(this.tbServer, 1, 0);
            this.tableLayoutServerLeft.Controls.Add(this.lbServer, 0, 0);
            this.tableLayoutServerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutServerLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutServerLeft.Name = "tableLayoutServerLeft";
            this.tableLayoutServerLeft.RowCount = 2;
            this.tableLayoutServerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutServerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutServerLeft.Size = new System.Drawing.Size(440, 49);
            this.tableLayoutServerLeft.TabIndex = 3;
            // 
            // tbUserName
            // 
            this.tbUserName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbUserName.Location = new System.Drawing.Point(80, 27);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(118, 20);
            this.tbUserName.TabIndex = 1;
            // 
            // lbUserName
            // 
            this.lbUserName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(24, 30);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(50, 13);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "Ihr Name";
            // 
            // tbServer
            // 
            this.tbServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbServer.Location = new System.Drawing.Point(80, 3);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(357, 20);
            this.tbServer.TabIndex = 0;
            // 
            // lbServer
            // 
            this.lbServer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(36, 5);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(38, 13);
            this.lbServer.TabIndex = 0;
            this.lbServer.Text = "Server";
            // 
            // tbProtocol
            // 
            this.tbProtocol.BackColor = System.Drawing.SystemColors.Window;
            this.tbProtocol.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbProtocol.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProtocol.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbProtocol.Location = new System.Drawing.Point(0, 0);
            this.tbProtocol.Multiline = true;
            this.tbProtocol.Name = "tbProtocol";
            this.tbProtocol.ReadOnly = true;
            this.tbProtocol.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbProtocol.Size = new System.Drawing.Size(690, 279);
            this.tbProtocol.TabIndex = 999;
            this.tbProtocol.TabStop = false;
            // 
            // ChatClient
            // 
            this.AcceptButton = this.cbConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 364);
            this.Controls.Add(this.tbProtocol);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "ChatClient";
            this.Text = "ChatClient (v0.2)";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutMessage.ResumeLayout(false);
            this.tableLayoutMessage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutServer.ResumeLayout(false);
            this.tableLayoutServerLeft.ResumeLayout(false);
            this.tableLayoutServerLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Button cbEnd;
        private System.Windows.Forms.Button cbSend;
        private System.Windows.Forms.TextBox tbProtocol;
        private System.Windows.Forms.TableLayoutPanel tableLayoutServer;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Button cbConnect;
        private System.Windows.Forms.Button cbDisconnect;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutServerLeft;
    }
}


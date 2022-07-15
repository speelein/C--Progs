namespace ChatServerNameSpace {
    partial class ChatServer {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbStop = new System.Windows.Forms.Button();
            this.tbProtocol = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.cbStop, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 236);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(675, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbStop
            // 
            this.cbStop.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbStop.Location = new System.Drawing.Point(228, 3);
            this.cbStop.Name = "cbStop";
            this.cbStop.Size = new System.Drawing.Size(219, 23);
            this.cbStop.TabIndex = 0;
            this.cbStop.Text = "ChatServer stoppen";
            this.cbStop.UseVisualStyleBackColor = true;
            this.cbStop.Click += new System.EventHandler(this.cbStop_Click);
            // 
            // tbProtocol
            // 
            this.tbProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbProtocol.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProtocol.Location = new System.Drawing.Point(0, 0);
            this.tbProtocol.Multiline = true;
            this.tbProtocol.Name = "tbProtocol";
            this.tbProtocol.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbProtocol.Size = new System.Drawing.Size(675, 236);
            this.tbProtocol.TabIndex = 1;
            // 
            // ChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 266);
            this.Controls.Add(this.tbProtocol);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChatServer";
            this.Text = "ChatServer (v0.2)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatServer_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button cbStop;
        private System.Windows.Forms.TextBox tbProtocol;
    }
}


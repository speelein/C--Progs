namespace LinqToSqlWinForms {
	partial class Form1 {
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(13, 13);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(525, 150);
			this.dataGridView.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(27, 181);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(152, 35);
			this.button1.TabIndex = 1;
			this.button1.Text = "Kunden";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(368, 181);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(152, 35);
			this.button2.TabIndex = 2;
			this.button2.Text = "Aufträge";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(550, 226);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView);
			this.Name = "Form1";
			this.Text = "LINQ to SQL";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}


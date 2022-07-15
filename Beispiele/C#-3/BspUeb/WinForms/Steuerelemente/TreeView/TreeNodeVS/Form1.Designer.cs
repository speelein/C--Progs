namespace WindowsApplication1 {
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("M 3060");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("M 3080");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Canon", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Scanner", new System.Windows.Forms.TreeNode[] {
            treeNode3});
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Canon");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("HP");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Magic 2000");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Minolta", new System.Windows.Forms.TreeNode[] {
            treeNode7});
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Drucker", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode8});
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(12, 12);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "m3060";
			treeNode1.Text = "M 3060";
			treeNode2.Name = "m3080";
			treeNode2.Text = "M 3080";
			treeNode3.Name = "Canon";
			treeNode3.Text = "Canon";
			treeNode4.Name = "Scanner";
			treeNode4.Text = "Scanner";
			treeNode5.Name = "canon";
			treeNode5.Text = "Canon";
			treeNode6.Name = "hp";
			treeNode6.Text = "HP";
			treeNode7.Name = "magic2000";
			treeNode7.Text = "Magic 2000";
			treeNode8.Name = "minolta";
			treeNode8.Text = "Minolta";
			treeNode9.Name = "drucker";
			treeNode9.Text = "Drucker";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode9});
			this.treeView1.Size = new System.Drawing.Size(115, 105);
			this.treeView1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 181);
			this.Controls.Add(this.treeView1);
			this.Name = "Form1";
			this.Text = "TreeView VS";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeView1;
	}
}


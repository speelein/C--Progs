namespace ResEditorComponents 
{
    
	using System;
	using System.Drawing;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Collections; 
	using System.IO; 
	using System.Resources; 


	/// <summary>
	///    Summary description for Win32Form1.
	/// </summary>
	public class ResEditor : System.Windows.Forms.Form 
	{

		/// <summary> 
		///    Required by the Win Forms designer 
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.TextBox textBoxAdd;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox textBoxRename;
		private System.Windows.Forms.Button buttonRename;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboBoxAdd;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PropertyGrid propertyGridResources;
        
		private string currentFileName;
		private System.Windows.Forms.MainMenu menuMain;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuFileOpen;
		private System.Windows.Forms.MenuItem menuFileSave;
		private System.Windows.Forms.MenuItem menuFileExit;
		private System.Windows.Forms.MenuItem menuResource;
		private System.Windows.Forms.MenuItem menuResourceDelete;
		private ResHolder currentResHolder;

		public ResEditor() 
		{

			// Required for Win Form Designer support
			InitializeComponent();


			// TODO: Add any constructor code after InitializeComponent call
            
			//Min Size 720, 464
            
			comboBoxAdd.Items.Add(typeof(Bitmap));
			comboBoxAdd.Items.Add(typeof(Icon));
			comboBoxAdd.Items.Add(typeof(String));
			comboBoxAdd.Items.Add(typeof(ImageList));
			comboBoxAdd.SelectedIndex = 0;
		}

		/// <summary>
		///    Clean up any resources being used
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		/// <summary>
		///    The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args) 
		{
			Application.Run(new ResEditor());
		}


		/// <summary>
		///    Required method for Designer support - do not modify
		///    the contents of this method with an editor
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxRename = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBoxAdd = new System.Windows.Forms.TextBox();
			this.comboBoxAdd = new System.Windows.Forms.ComboBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.menuFileOpen = new System.Windows.Forms.MenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.propertyGridResources = new System.Windows.Forms.PropertyGrid();
			this.menuMain = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuFileSave = new System.Windows.Forms.MenuItem();
			this.menuFileExit = new System.Windows.Forms.MenuItem();
			this.menuResource = new System.Windows.Forms.MenuItem();
			this.menuResourceDelete = new System.Windows.Forms.MenuItem();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonRename = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			
			// 
			// textBoxRename
			// 
			this.textBoxRename.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxRename.Location = new System.Drawing.Point(8, 16);
			this.textBoxRename.Name = "textBoxRename";
			this.textBoxRename.Size = new System.Drawing.Size(160, 20);
			this.textBoxRename.TabIndex = 0;
			this.textBoxRename.Text = "";
			this.textBoxRename.TextChanged += new System.EventHandler(this.textBoxRename_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.textBoxAdd,
																					this.comboBoxAdd,
																					this.buttonAdd});
			this.groupBox1.Location = new System.Drawing.Point(8, 288);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(448, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// textBoxAdd
			// 
			this.textBoxAdd.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxAdd.Location = new System.Drawing.Point(192, 16);
			this.textBoxAdd.Name = "textBoxAdd";
			this.textBoxAdd.Size = new System.Drawing.Size(160, 20);
			this.textBoxAdd.TabIndex = 1;
			this.textBoxAdd.Text = "";
			this.textBoxAdd.TextChanged += new System.EventHandler(this.textBoxAdd_TextChanged);
			// 
			// comboBoxAdd
			// 
			this.comboBoxAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.comboBoxAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxAdd.DropDownWidth = 168;
			this.comboBoxAdd.Location = new System.Drawing.Point(8, 16);
			this.comboBoxAdd.Name = "comboBoxAdd";
			this.comboBoxAdd.Size = new System.Drawing.Size(176, 21);
			this.comboBoxAdd.TabIndex = 0;
			this.comboBoxAdd.SelectedIndexChanged += new System.EventHandler(this.comboBoxAdd_SelectedIndexChanged);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.buttonAdd.Enabled = false;
			this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAdd.Location = new System.Drawing.Point(360, 16);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.TabIndex = 2;
			this.buttonAdd.Text = "&Add";
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// menuFileOpen
			// 
			this.menuFileOpen.Index = 0;
			this.menuFileOpen.Text = "&Open...";
			this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "resources";
			this.saveFileDialog1.Filter = "Resource Files (*.resources)|*.resources|ResX Files (*.resX)|*.resX|All Files (*." +
				"*)|*.*";
			this.saveFileDialog1.RestoreDirectory = true;
			this.saveFileDialog1.Title = "Save Resource File";
			this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "resources";
			this.openFileDialog1.Filter = "Resource Files (*.resources)|*.resources|ResX Files (*.resX)|*.resX|All Files (*." +
				"*)|*.*";
			this.openFileDialog1.RestoreDirectory = true;
			this.openFileDialog1.Title = "Open a Resource file";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// propertyGridResources
			// 
			this.propertyGridResources.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.propertyGridResources.CommandsVisibleIfAvailable = true;
			this.propertyGridResources.LargeButtons = false;
			this.propertyGridResources.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGridResources.Name = "propertyGridResources";
			this.propertyGridResources.Size = new System.Drawing.Size(464, 280);
			this.propertyGridResources.TabIndex = 0;
			this.propertyGridResources.Text = "PropertyGrid";
			this.propertyGridResources.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGridResources.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.propertyGridResources.Click += new System.EventHandler(this.propertyGridResources_Click);
			this.propertyGridResources.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.propertyGridResources_SelectedGridItemChanged);
			// 
			// menuMain
			// 
			this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.menuResource});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFileOpen,
																					 this.menuFileSave,
																					 this.menuFileExit});
			this.menuFile.Text = "&File";
			this.menuFile.Click += new System.EventHandler(this.menuFile_Click);
			// 
			// menuFileSave
			// 
			this.menuFileSave.Index = 1;
			this.menuFileSave.Text = "&Save As...";
			this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
			// 
			// menuFileExit
			// 
			this.menuFileExit.Index = 2;
			this.menuFileExit.Text = "E&xit";
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// menuResource
			// 
			this.menuResource.Index = 1;
			this.menuResource.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuResourceDelete});
			this.menuResource.Text = "&Resource";
			this.menuResource.Click += new System.EventHandler(this.menuResource_Click);
			// 
			// menuResourceDelete
			// 
			this.menuResourceDelete.Index = 0;
			this.menuResourceDelete.Text = "&Delete";
			this.menuResourceDelete.Click += new System.EventHandler(this.menuResourceDelete_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.textBoxRename,
																					this.buttonRename});
			this.groupBox2.Location = new System.Drawing.Point(192, 336);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(264, 48);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Rename";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// buttonRename
			// 
			this.buttonRename.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.buttonRename.Enabled = false;
			this.buttonRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRename.Location = new System.Drawing.Point(176, 16);
			this.buttonRename.Name = "buttonRename";
			this.buttonRename.TabIndex = 1;
			this.buttonRename.Text = "Re&name";
			this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
			// 
			// ResEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 393);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.propertyGridResources});
			this.Menu = this.menuMain;
			this.Name = "ResEditor";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Resource Editor";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ResEditor_Closing);
			this.Load += new System.EventHandler(this.ResEditor_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.MinimumSize = new System.Drawing.Size(460,360);

		}
    
		protected void ResEditor_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
		{
			if (currentResHolder != null && currentResHolder.IsDirty) 
			{
				System.Windows.Forms.DialogResult dr = MessageBox.Show(this,
					"Do you want to save the current changes?",
					"Save Changes?",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				switch (dr) 
				{
					case System.Windows.Forms.DialogResult.Yes:
						if (SaveResources() == false) e.Cancel = true;
						break;
					case System.Windows.Forms.DialogResult.No:
						break;
					case System.Windows.Forms.DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}
		}
        
		private  void textBoxAdd_TextChanged(object sender, System.EventArgs e) 
		{
			buttonAdd.Enabled = (textBoxAdd.Text.Length != 0) ;
		}

		private  void textBoxRename_TextChanged(object sender, System.EventArgs e) 
		{
			buttonRename.Enabled = (textBoxRename.Text.Length != 0) ;
		}

		private  void propertyGridResources_SelectedGridItemChanged(object sender, System.Windows.Forms.SelectedGridItemChangedEventArgs e) 
		{
			currentResHolder.IsDirty = true;
		}

		protected void buttonAdd_Click(object sender, System.EventArgs e) 
		{
            
			if (currentResHolder == null) 
			{
				currentResHolder = new ResHolder();
			} 
                
			Type selectedType = (Type)(comboBoxAdd.SelectedItem);

			//Need a robust naming scheme
			try 
			{
				currentResHolder.Add(textBoxAdd.Text, selectedType);
			}
			catch (ApplicationException) 
			{
				MessageBox.Show(this,
					"Resource names must be unique!",
					"Resource Editor",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally 
			{
				propertyGridResources.SelectedObject = currentResHolder;
			}
			textBoxAdd.Text = "";
		}

		protected void menuResourceDelete_Click(object sender, System.EventArgs e) 
		{
			if (propertyGridResources.SelectedGridItem != null) 
			{
				try
				{
					Console.WriteLine("Deleting " + propertyGridResources.SelectedGridItem.PropertyDescriptor.Name);
					currentResHolder.Delete(propertyGridResources.SelectedGridItem.PropertyDescriptor);
					propertyGridResources.SelectedObject = currentResHolder;
				}
				catch (NullReferenceException) 
				{
					MessageBox.Show(this,
						"Must select a resource to delete!",
						"Resource Editor",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			}
		}

		protected void buttonRename_Click(object sender, System.EventArgs e) 
		{
			if (propertyGridResources.SelectedGridItem != null) 
			{
				try 
				{
					currentResHolder.Rename(textBoxRename.Text);
					ResourceDescriptor rd = (ResourceDescriptor)propertyGridResources.SelectedGridItem.PropertyDescriptor;
					rd.ResourceName = textBoxRename.Text;
					//propertyGridResources.SelectedGridItem.Value = textBoxRename.Text;
					propertyGridResources.SelectedObject = currentResHolder;
					//currentResHolder.DumpResources();
					textBoxRename.Text = "";
				}
				catch (ApplicationException) 
				{
					MessageBox.Show(this,
						"Resource names must be unique!",
						"Resource Editor",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				catch (NullReferenceException) 
				{
					MessageBox.Show(this,
						"Must select a resource to rename!",
						"Resource Editor",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				finally 
				{
					propertyGridResources.SelectedObject = currentResHolder;
				}
			}
		}

		//Handle the File Open
		private void menuFileOpen_Click(object sender, System.EventArgs e) 
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK) 
			{
				currentFileName =  openFileDialog1.FileName;

				FileInfo efInfo = new FileInfo(currentFileName);
				string fext = efInfo.Extension.ToUpper();

				try 
				{
					if (fext.Equals(".RESX")) 
						ReadResXFile(currentFileName);
					else if (fext.Equals(".RESOURCES")) 
						ReadResourceFile(currentFileName);
					else
						ReadPEFile(currentFileName);
				}
				catch (FileNotFoundException)
				{
					MessageBox.Show(this,
						"Invalid file format!",
						"Resource Editor",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation
					);
				}
				catch (ArgumentException)
				{
					MessageBox.Show(this,
						"Invalid file format!",
						"Resource Editor",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation
					);
				}
			}
		}

		//Handle the File Save
		protected void menuFileSave_Click(object sender, System.EventArgs e) 
		{
			bool retval = SaveResources();
		}

		// Save out the resources
		protected bool SaveResources() 
		{
            		try
            		{
				if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
				{
					currentFileName =  saveFileDialog1.FileName;
	
					FileInfo efInfo = new FileInfo(currentFileName);
					string fext = efInfo.Extension.ToUpper();

					if (fext.Equals(".RESX")) 
						WriteResXFile(currentFileName);
					else
						WriteResourceFile(currentFileName);
					return true;
				}
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show(this,
					"Unable to write to this file!",
					"Resource Editor",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation
				);
			}
			return false;
		}

		//Handle the File Exit
		protected void menuFileExit_Click(object sender, System.EventArgs e) 
		{
			this.Close();
		}
		
		// Write a resource file 
		private void WriteResXFile(string fileName) 
		{
			ResXResourceWriter rwtr = null ;
			try 
			{
				rwtr = new ResXResourceWriter (fileName) ;
				currentResHolder.WriteResources(rwtr);
			}
			finally 
			{
				if (null != rwtr) rwtr.Close();
			}
		}

		private void WriteResourceFile(string fileName) 
		{
			ResourceWriter rwtr = null ;
			try 
			{
				rwtr = new ResourceWriter (fileName) ;
				currentResHolder.WriteResources(rwtr);
			}
			finally 
			{
				if (null != rwtr) rwtr.Close();
			}
		}


		//Read a resource file 
		private void ReadResXFile(string fileName) 
		{
			ResXResourceReader rrdr = null ; 
			try 
			{
				rrdr = new ResXResourceReader(fileName);
				currentResHolder = new ResHolder(rrdr);
				propertyGridResources.SelectedObject = currentResHolder;
			}
			finally 
			{
				if (null != rrdr) rrdr.Close();
			}
		}

		private void ReadResourceFile(string fileName) 
		{
			ResourceReader rrdr = null ; 
			try 
			{
				rrdr = new ResourceReader(fileName);
				currentResHolder = new ResHolder(rrdr);
				propertyGridResources.SelectedObject = currentResHolder;
			}
			finally 
			{
				if (null != rrdr) rrdr.Close();
			}
		}

		private void ReadPEFile(string fileName)  {}
		private void ResEditor_Load(object sender, System.EventArgs e) {}
		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e){}
		private void menuFile_Click(object sender, System.EventArgs e) {}
		private void groupBox2_Enter(object sender, System.EventArgs e){}
		private void menuResource_Click(object sender, System.EventArgs e) {}
		private void groupBox1_Enter(object sender, System.EventArgs e) {}
		private void propertyGridResources_Click(object sender, System.EventArgs e) {}
		private void comboBoxAdd_SelectedIndexChanged(object sender, System.EventArgs e) {}
		private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {}
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SampleCs
{
	/// <summary>
	/// Summary description for SampleFrame.
	/// </summary>
	public class SampleFrame : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu;
		private RichTextBoxEx richTextBoxEx;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog;
		private System.Windows.Forms.MenuItem menuFilePrintPreview;
		private System.Windows.Forms.MenuItem menuFilePrint;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuFilePageSetup;
		private System.Windows.Forms.MenuItem menuFormat;
		private System.Windows.Forms.MenuItem menuFormatBold;
		private System.Windows.Forms.MenuItem menuFormatItalic;
		private System.Windows.Forms.MenuItem menuFontSize;
		private System.Windows.Forms.MenuItem menuFontSize8;
		private System.Windows.Forms.MenuItem menuFontSize10;
		private System.Windows.Forms.MenuItem menuFontSize12;
		private System.Windows.Forms.MenuItem menuFontSize18;
		private System.Windows.Forms.MenuItem menuFontSize24;
		private System.Windows.Forms.MenuItem menuFont;
		private System.Windows.Forms.MenuItem menuFontArial;
		private System.Windows.Forms.MenuItem menuFontCourier;
		private System.Windows.Forms.MenuItem menuFontTimes;
		private System.Windows.Forms.MenuItem menuFormatUnderlined;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SampleFrame()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SampleFrame));
			this.richTextBoxEx = new RichTextBoxEx();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuFilePageSetup = new System.Windows.Forms.MenuItem();
			this.menuFilePrintPreview = new System.Windows.Forms.MenuItem();
			this.menuFilePrint = new System.Windows.Forms.MenuItem();
			this.menuFormat = new System.Windows.Forms.MenuItem();
			this.menuFormatBold = new System.Windows.Forms.MenuItem();
			this.menuFormatItalic = new System.Windows.Forms.MenuItem();
			this.menuFontSize = new System.Windows.Forms.MenuItem();
			this.menuFontSize8 = new System.Windows.Forms.MenuItem();
			this.menuFontSize10 = new System.Windows.Forms.MenuItem();
			this.menuFontSize12 = new System.Windows.Forms.MenuItem();
			this.menuFontSize18 = new System.Windows.Forms.MenuItem();
			this.menuFontSize24 = new System.Windows.Forms.MenuItem();
			this.menuFont = new System.Windows.Forms.MenuItem();
			this.menuFontArial = new System.Windows.Forms.MenuItem();
			this.menuFontCourier = new System.Windows.Forms.MenuItem();
			this.menuFontTimes = new System.Windows.Forms.MenuItem();
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			this.printDialog = new System.Windows.Forms.PrintDialog();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
			this.menuFormatUnderlined = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// richTextBoxEx
			// 
			this.richTextBoxEx.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.richTextBoxEx.Name = "richTextBoxEx";
			this.richTextBoxEx.Size = new System.Drawing.Size(400, 235);
			this.richTextBoxEx.TabIndex = 0;
			this.richTextBoxEx.Text = "";
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.menuFormat});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFilePageSetup,
																					 this.menuFilePrintPreview,
																					 this.menuFilePrint});
			this.menuFile.Text = "&File";
			// 
			// menuFilePageSetup
			// 
			this.menuFilePageSetup.Index = 0;
			this.menuFilePageSetup.Text = "Page &Setup...";
			this.menuFilePageSetup.Click += new System.EventHandler(this.menuFilePageSetup_Click);
			// 
			// menuFilePrintPreview
			// 
			this.menuFilePrintPreview.Index = 1;
			this.menuFilePrintPreview.Text = "Print Pre&view...";
			this.menuFilePrintPreview.Click += new System.EventHandler(this.menuFilePrintPreview_Click);
			// 
			// menuFilePrint
			// 
			this.menuFilePrint.Index = 2;
			this.menuFilePrint.Text = "&Print...";
			this.menuFilePrint.Click += new System.EventHandler(this.menuFilePrint_Click);
			// 
			// menuFormat
			// 
			this.menuFormat.Index = 1;
			this.menuFormat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuFormatBold,
																					   this.menuFormatItalic,
																					   this.menuFormatUnderlined,
																					   this.menuFontSize,
																					   this.menuFont});
			this.menuFormat.Text = "F&ormat";
			// 
			// menuFormatBold
			// 
			this.menuFormatBold.Index = 0;
			this.menuFormatBold.Text = "&Bold";
			this.menuFormatBold.Click += new System.EventHandler(this.menuFormatBold_Click);
			// 
			// menuFormatItalic
			// 
			this.menuFormatItalic.Index = 1;
			this.menuFormatItalic.Text = "&Italic";
			this.menuFormatItalic.Click += new System.EventHandler(this.menuFormatItalic_Click);
			// 
			// menuFontSize
			// 
			this.menuFontSize.Index = 3;
			this.menuFontSize.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuFontSize8,
																						 this.menuFontSize10,
																						 this.menuFontSize12,
																						 this.menuFontSize18,
																						 this.menuFontSize24});
			this.menuFontSize.Text = "Font &Size";
			// 
			// menuFontSize8
			// 
			this.menuFontSize8.Index = 0;
			this.menuFontSize8.Text = "8";
			this.menuFontSize8.Click += new System.EventHandler(this.menuFontSize8_Click);
			// 
			// menuFontSize10
			// 
			this.menuFontSize10.Index = 1;
			this.menuFontSize10.Text = "10";
			this.menuFontSize10.Click += new System.EventHandler(this.menuFontSize10_Click);
			// 
			// menuFontSize12
			// 
			this.menuFontSize12.Index = 2;
			this.menuFontSize12.Text = "12";
			this.menuFontSize12.Click += new System.EventHandler(this.menuFontSize12_Click);
			// 
			// menuFontSize18
			// 
			this.menuFontSize18.Index = 3;
			this.menuFontSize18.Text = "18";
			this.menuFontSize18.Click += new System.EventHandler(this.menuFontSize18_Click);
			// 
			// menuFontSize24
			// 
			this.menuFontSize24.Index = 4;
			this.menuFontSize24.Text = "24";
			this.menuFontSize24.Click += new System.EventHandler(this.menuFontSize24_Click);
			// 
			// menuFont
			// 
			this.menuFont.Index = 4;
			this.menuFont.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFontArial,
																					 this.menuFontCourier,
																					 this.menuFontTimes});
			this.menuFont.Text = "&Font";
			// 
			// menuFontArial
			// 
			this.menuFontArial.Index = 0;
			this.menuFontArial.Text = "Arial";
			this.menuFontArial.Click += new System.EventHandler(this.menuFontArial_Click);
			// 
			// menuFontCourier
			// 
			this.menuFontCourier.Index = 1;
			this.menuFontCourier.Text = "Courier";
			this.menuFontCourier.Click += new System.EventHandler(this.menuFontCourier_Click);
			// 
			// menuFontTimes
			// 
			this.menuFontTimes.Index = 2;
			this.menuFontTimes.Text = "Times New Roman";
			this.menuFontTimes.Click += new System.EventHandler(this.menuFontTimes_Click);
			// 
			// printDocument
			// 
			this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
			this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
			this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
			// 
			// printDialog
			// 
			this.printDialog.Document = this.printDocument;
			// 
			// printPreviewDialog
			// 
			this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog.Document = this.printDocument;
			this.printPreviewDialog.Enabled = true;
			this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
			this.printPreviewDialog.Location = new System.Drawing.Point(243, 16);
			this.printPreviewDialog.MaximumSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.Name = "printPreviewDialog";
			this.printPreviewDialog.Opacity = 1;
			this.printPreviewDialog.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog.Visible = false;
			// 
			// pageSetupDialog
			// 
			this.pageSetupDialog.Document = this.printDocument;
			// 
			// menuFormatUnderlined
			// 
			this.menuFormatUnderlined.Index = 2;
			this.menuFormatUnderlined.Text = "&Underlined";
			this.menuFormatUnderlined.Click += new System.EventHandler(this.menuFormatUnderlined_Click);
			// 
			// SampleFrame
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 233);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.richTextBoxEx});
			this.Menu = this.mainMenu;
			this.Name = "SampleFrame";
			this.Text = "RichTextBoxEx Sample (C#)";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SampleFrame());
		}

		private int m_nFirstCharOnPage;

		private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			// Start at the beginning of the text
			m_nFirstCharOnPage = 0;
		}

		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			// To print the boundaries of the current page margins
			// uncomment the next line:
			//e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, e.MarginBounds);
    
			// make the RichTextBoxEx calculate and render as much text as will
			// fit on the page and remember the last character printed for the
			// beginning of the next page
			m_nFirstCharOnPage = richTextBoxEx.FormatRange(false,
				e,
				m_nFirstCharOnPage,
				richTextBoxEx.TextLength);

			// check if there are more pages to print
			if (m_nFirstCharOnPage < richTextBoxEx.TextLength)
				e.HasMorePages = true;
			else
				e.HasMorePages = false;
		}

		private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			// Clean up cached information
			richTextBoxEx.FormatRangeDone();
		}

		private void menuFilePageSetup_Click(object sender, System.EventArgs e)
		{
			pageSetupDialog.ShowDialog();
		}

		private void menuFilePrintPreview_Click(object sender, System.EventArgs e)
		{
			if (printPreviewDialog.ShowDialog() == DialogResult.OK)
				printDocument.Print();
		}

		private void menuFilePrint_Click(object sender, System.EventArgs e)
		{
			printDocument.Print();
		}

		private void menuFormatBold_Click(object sender, System.EventArgs e)
		{
			richTextBoxEx.SetSelectionBold(true);		
		}

		private void menuFormatItalic_Click(object sender, System.EventArgs e)
		{
			richTextBoxEx.SetSelectionItalic(true);
		}

		private void menuFormatUnderlined_Click(object sender, System.EventArgs e)
		{
			richTextBoxEx.SetSelectionUnderlined(true);
		}

		private void menuFontSize8_Click(object sender, System.EventArgs e)
		{
			richTextBoxEx.SetSelectionSize(8);
		}

		private void menuFontSize10_Click(object sender, System.EventArgs e)
		{
			richTextBoxEx.SetSelectionSize(10);
		}

		private void menuFontSize12_Click(object sender, System.EventArgs e)
		{
			richTextBoxEx.SetSelectionSize(12);
		}

		private void menuFontSize18_Click(object sender, System.EventArgs e)
		{
			richTextBoxEx.SetSelectionSize(18);
		}

		private void menuFontSize24_Click(object sender, System.EventArgs e)
		{	
			richTextBoxEx.SetSelectionSize(24);
		}

		private void menuFontArial_Click(object sender, System.EventArgs e)
		{
			richTextBoxEx.SetSelectionFont("Arial");
		}

		private void menuFontCourier_Click(object sender, System.EventArgs e)
		{
			richTextBoxEx.SetSelectionFont("Courier New");
		}

		private void menuFontTimes_Click(object sender, System.EventArgs e)
		{
			richTextBoxEx.SetSelectionFont("Times New Roman");
		}
	}
}

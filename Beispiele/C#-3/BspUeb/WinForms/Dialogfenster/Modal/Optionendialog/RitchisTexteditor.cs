using System;
using System.Windows.Forms;
using System.Drawing;

class RitchisTexteditor : Form {
	RichTextBox editor;
	ToolStripMenuItem	mitFile, mitEdit, mitTools, mitHelp,
						mitQuit,
						mitUndo, mitRedo, mitCut, mitCopy, mitPaste, mitDel, mitSelectAll,
						cmitUndo, cmitRedo, cmitCut, cmitCopy, cmitPaste, cmitDel, cmitSelectAll,
						mitFont, mitCourierNew, mitTimesNewRoman, mitArial, mitCurrentFont,
						mitSize,
						mitBackColor, mitBeige, mitWhite, mitCurrentColor,
						mitOptions,
						mitInfo;
	Font fontTNR12, fontCN12, fontA12, fontTNR16, fontCN16, fontA16;

	OptionsDialog optionsDialog;

	public RitchisTexteditor() {
		fontTNR12 = new Font("Times New Roman", 12);
		fontCN12 = new Font("Courier New", 12);
		fontA12 = new Font("Arial", 12);
		fontTNR16 = new Font("Times New Roman", 16);
		fontCN16 = new Font("Courier New", 16);
		fontA16 = new Font("Arial", 16);

		Text = "Ritchis Texteditor";
		editor = new RichTextBox();
		editor.Font = fontTNR12;
		editor.Dock = DockStyle.Fill;
		editor.HideSelection = false;
		editor.AcceptsTab = true;
		Controls.Add(editor);

		MenuStrip mainMenu = new MenuStrip();
		mainMenu.Dock = DockStyle.Top;
		Controls.Add(mainMenu);
		
		mitFile = new ToolStripMenuItem("&Datei");
		mitEdit = new ToolStripMenuItem("&Bearbeiten");
		mitTools = new ToolStripMenuItem("&Extras");
		mitHelp = new ToolStripMenuItem("&Hilfe");
		mainMenu.Items.AddRange(new ToolStripItem[] {mitFile, mitEdit, mitTools, mitHelp});

		// Menüitems Datei
		mitQuit = new ToolStripMenuItem("&Beenden", null, new EventHandler(MitExitOnClick));
		mitFile.DropDownItems.Add(mitQuit);

		// Menüitems Bearbeiten
		Bitmap bmp = new Bitmap("undo.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitUndo = new ToolStripMenuItem("&Rückgängig", bmp, MitUnRedoOnClick);
		mitUndo.ShortcutKeys = Keys.Control | Keys.Z;
		cmitUndo = new ToolStripMenuItem("&Rückgängig", bmp, MitUnRedoOnClick);

		bmp = new Bitmap("redo.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitRedo = new ToolStripMenuItem("&Wiederholen", bmp, MitUnRedoOnClick);
		mitRedo.ShortcutKeys = Keys.Control | Keys.Y;
		cmitRedo = new ToolStripMenuItem("&Wiederholen", bmp, MitUnRedoOnClick);

		bmp = new Bitmap("cut.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitCut = new ToolStripMenuItem("Auss&chneiden", bmp, MitCutOnClick);
		mitCut.ShortcutKeys = Keys.Control | Keys.X;
		cmitCut = new ToolStripMenuItem("Auss&chneiden", bmp, MitCutOnClick);

		bmp = new Bitmap("copy.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitCopy = new ToolStripMenuItem("&Kopieren", bmp, MitCopyOnClick);
		mitCopy.ShortcutKeys = Keys.Control | Keys.C;
		cmitCopy = new ToolStripMenuItem("&Kopieren", bmp, MitCopyOnClick);

		bmp = new Bitmap("paste.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitPaste = new ToolStripMenuItem("&Einfügen", bmp, MitPasteOnClick);
		mitPaste.ShortcutKeys = Keys.Control | Keys.V;
		cmitPaste = new ToolStripMenuItem("&Einfügen", bmp, MitPasteOnClick);

		bmp = new Bitmap("del.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitDel = new ToolStripMenuItem("&Löschen", bmp, MitDeleteOnClick);
		mitDel.ShortcutKeys = Keys.Delete;
		cmitDel = new ToolStripMenuItem("&Löschen", bmp, MitDeleteOnClick);

		mitSelectAll = new ToolStripMenuItem("&Alles auswählen", null, MitSelectAllOnClick);
		mitSelectAll.ShortcutKeys = Keys.Control | Keys.A;
		cmitSelectAll = new ToolStripMenuItem("&Alles auswählen", null, MitSelectAllOnClick);

		mitEdit.DropDownItems.AddRange(new ToolStripItem[] {mitUndo, mitRedo, new ToolStripSeparator(),
			mitCut, mitCopy, mitPaste, mitDel,
			new ToolStripSeparator(), mitSelectAll});
		mitEdit.DropDownOpening += MitEditOnPopup;

		// Menüitems Extras
		mitFont = new ToolStripMenuItem("&Schriftart");

		EventHandler fontHandler = new EventHandler(MitFontOnClick);
		mitCourierNew = new ToolStripMenuItem("&Courier New", null, fontHandler);
		mitFont.DropDownItems.Add(mitCourierNew);

		mitTimesNewRoman = new ToolStripMenuItem("&Times New Roman", null, fontHandler);
		mitTimesNewRoman.Checked = true;
		mitCurrentFont = mitTimesNewRoman;
		mitFont.DropDownItems.Add(mitTimesNewRoman);

		mitArial = new ToolStripMenuItem("&Arial", null, fontHandler);
		mitFont.DropDownItems.Add(mitArial);

		mitTools.DropDownItems.Add(mitFont);

		mitSize = new ToolStripMenuItem("&Große Schrift", null, new EventHandler(MitSizeOnClick));

		mitTools.DropDownItems.Add(mitSize);
		mitTools.DropDownItems.Add(new ToolStripSeparator());

		mitBackColor = new ToolStripMenuItem("&Hintergrundfarbe");
		mitTools.DropDownItems.Add(mitBackColor);

		EventHandler bcHandler = new EventHandler(MitBackColorOnClick);
		mitWhite = new ToolStripMenuItem("&Weiss", null, bcHandler);
		mitCurrentColor = mitWhite;
		mitWhite.Checked = true;
		mitBackColor.DropDownItems.Add(mitWhite);
		mitBeige = new ToolStripMenuItem("&Beige", null, bcHandler);
		mitBackColor.DropDownItems.Add(mitBeige);
		mitTools.DropDownItems.Add(new ToolStripSeparator());

		mitOptions = new ToolStripMenuItem("&Optionen...", null, MitOptionenOnClick);
		mitTools.DropDownItems.Add(mitOptions);

		// Menüitems Hilfe
		mitInfo = new ToolStripMenuItem("&Info", null, new EventHandler(MitInfoOnClick));
		mitInfo.ShortcutKeys = Keys.F1;
		mitHelp.DropDownItems.Add(mitInfo);
		//mitInfo.Visible = false;

		// Kontextmenü für die Editor-Komponente
		ContextMenuStrip  contextMenu = new ContextMenuStrip();
		contextMenu.Items.AddRange(new ToolStripItem[] {cmitUndo, cmitRedo, new ToolStripSeparator(),
			cmitCut, cmitCopy, cmitPaste, cmitDel,
			new ToolStripSeparator(), cmitSelectAll });
		editor.ContextMenuStrip = contextMenu;
		contextMenu.Opening += MitEditOnPopup;

	} // Ende Formularkonstruktor

	protected void MitExitOnClick(object sender, EventArgs e) {
		Close();
	}

	// Click-Handler zum Hauptmenü-Item Bearbeiten
	protected void MitUnRedoOnClick(object sender, EventArgs e) {
		if (sender == mitUndo || sender == cmitUndo)
			editor.Undo();
		else
			editor.Redo();
	}
	protected void MitCutOnClick(object sender, EventArgs e) {
		if (editor.SelectionLength > 0)
			editor.Cut();
	}
	protected void MitCopyOnClick(object sender, EventArgs e) {
		if (editor.SelectionLength > 0)
			editor.Copy();
	}
	protected void MitDeleteOnClick(object sender, EventArgs e) {
		if (editor.SelectionLength == 0 && editor.SelectionStart < editor.TextLength)
			editor.Select(editor.SelectionStart, 1);
		editor.SelectedText = "";
	}
	protected void MitPasteOnClick(object sender, EventArgs e) {
		editor.Paste();
	}
	protected void MitSelectAllOnClick(object sender, EventArgs e) {
		editor.SelectAll();
	}
	
	protected void MitEditOnPopup(object sender, EventArgs e) {
		if (editor.SelectionLength > 0) {
			mitCut.Enabled = true;
			mitCopy.Enabled = true;
			mitDel.Enabled = true;
			cmitCut.Enabled = true;
			cmitCopy.Enabled = true;
			cmitDel.Enabled = true;
		} else {
			mitCut.Enabled = false;
			mitCopy.Enabled = false;
			mitDel.Enabled = false;
			cmitCut.Enabled = false;
			cmitCopy.Enabled = false;
			cmitDel.Enabled = false;
		}
		if (editor.CanUndo) {
			mitUndo.Enabled = true;
			cmitUndo.Enabled = true;
		} else {
			mitUndo.Enabled = false;
			cmitUndo.Enabled = false;
		}
		if (editor.CanRedo) {
			mitRedo.Enabled = true;
			cmitRedo.Enabled = true;
		} else {
			mitRedo.Enabled = false;
			cmitRedo.Enabled = false;
		}
	}

	// Click-Behandlungsmethoden zum Untermenü Extras
	protected void MitFontOnClick(object sender, EventArgs e) {
		mitCurrentFont.Checked = false;
		mitCurrentFont = (ToolStripMenuItem) sender;
		mitCurrentFont.Checked = true;

		if (sender == mitCourierNew) {
			editor.Font = (mitSize.Checked ? fontCN16 : fontCN12);
		} else
			if (sender == mitTimesNewRoman) {
				editor.Font = (mitSize.Checked ? fontTNR16 : fontTNR12);
			} else {
				editor.Font = (mitSize.Checked ? fontA16 : fontA12);
			}
	}

	protected void MitSizeOnClick(object sender, EventArgs e) {
		mitSize.Checked ^= true;
		if (mitCurrentFont == mitCourierNew) {
			editor.Font = (mitSize.Checked ? fontCN16 : fontCN12);
		} else
			if (mitCurrentFont == mitTimesNewRoman) {
				editor.Font = (mitSize.Checked ? fontTNR16 : fontTNR12);
			} else {
				editor.Font = (mitSize.Checked ? fontA16 : fontA12);
			}
	}

	protected void MitBackColorOnClick(object sender, EventArgs e) {
		mitCurrentColor.Checked = false;
		mitCurrentColor = (ToolStripMenuItem)sender;
		mitCurrentColor.Checked = true;

		if (sender == mitBeige)
			editor.BackColor = Color.Beige;
		else
			editor.BackColor = Color.White;
	}

	protected void MitOptionenOnClick(object sender, EventArgs e) {
		if (optionsDialog == null) {
			optionsDialog = new OptionsDialog(this);
		}
		optionsDialog.ZoomFactor = editor.ZoomFactor;
		optionsDialog.ScrollBars = editor.ScrollBars;
		optionsDialog.WordWrap = editor.WordWrap;
		if (optionsDialog.ShowDialog() == DialogResult.OK) {
			editor.WordWrap = optionsDialog.WordWrap;
			editor.ScrollBars = optionsDialog.ScrollBars;
			editor.ZoomFactor = optionsDialog.ZoomFactor;
		}
	}

	// Click-Behandlungsmethoden zum Untermenü Hilfe
	protected void MitInfoOnClick(object sender, EventArgs e) {
		MessageBox.Show(Text + "  \u00A9 by Mirko Weich");
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new RitchisTexteditor());
	}
}
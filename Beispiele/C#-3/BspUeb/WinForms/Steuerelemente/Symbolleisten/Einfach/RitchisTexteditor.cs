using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using System.Configuration;

[assembly: AssemblyCompany("Mirko Weich")]
[assembly: AssemblyProduct("Ritchis Texteditor")]
[assembly: AssemblyVersion("1.4.2.3")]

class RitchisTexteditor : Form {
	RichTextBox editor;
	RitchisTexteditorSettings applicationSettings;
	ToolStripMenuItem	mitFile, mitEdit, mitFormat, mitTools, mitHelp,
						mitNew, mitOpen, mitSave, mitSaveAs, mitQuit,
						mitUndo, mitRedo, mitCut, mitCopy, mitPaste, mitDel, mitSelectAll,
						mitFind, mitFindNext,
						cmitUndo, cmitRedo, cmitCut, cmitCopy, cmitPaste, cmitDel, cmitSelectAll,
						mitFont,
						mitOptions,
						mitInfo;
	OptionsDialog optionsDialog;
	SearchDialog searchDialog;
	string searchText;
	FontDialog fontDialog;
	ColorDialog colorDialog;
	SaveFileDialog sfDialog;
	String filter = "Textdokument (*.txt)|*.txt|RTF-Dokument (*.rtf)|*.rtf";
	int fileType; // 1: txt, 2: rtf
	String appName, fileName;
	OpenFileDialog ofDialog;

	ToolStripButton tsbNew, tsbOpen, tsbSave, tsbFind;

	public RitchisTexteditor() {
		appName = Application.ProductName;
		Text = "Unbenannt - " + appName;
		editor = new RichTextBox();
		editor.Dock = DockStyle.Fill;
		editor.HideSelection = false;
		editor.AcceptsTab = true;
		editor.Font = new Font("Lucida Console", 12);
		editor.TextChanged += new EventHandler(RichTextBoxOnTextChanged);
		Controls.Add(editor);

		// Menü- und Symbolleisten-Objekte
		MenuStrip mainMenu = new MenuStrip();
		mainMenu.LayoutStyle = ToolStripLayoutStyle.Flow;
		
		mitFile = new ToolStripMenuItem("&Datei");
		mitEdit = new ToolStripMenuItem("&Bearbeiten");
		mitFormat = new ToolStripMenuItem("&Format");
		mitTools = new ToolStripMenuItem("&Extras");
		mitHelp = new ToolStripMenuItem("&Hilfe");
		mainMenu.Items.AddRange(new ToolStripItem[] {mitFile, mitEdit, mitFormat, mitTools, mitHelp});

		ToolStrip toolStripStandard = new ToolStrip();
		toolStripStandard.GripStyle = ToolStripGripStyle.Hidden;
		toolStripStandard.Dock = DockStyle.Top;
		mainMenu.Dock = DockStyle.Top;
		Controls.Add(toolStripStandard);
		Controls.Add(mainMenu);

		tsbNew = new ToolStripButton();
		tsbNew.ToolTipText = "Neu";
		tsbOpen = new ToolStripButton();
		tsbOpen.ToolTipText = "Öffnen";
		tsbSave = new ToolStripButton();
		tsbSave.ToolTipText = "Speichern";
		tsbFind = new ToolStripButton();
		tsbFind.Enabled = false;
		tsbFind.ToolTipText = "Suchen";

		toolStripStandard.Items.AddRange(
			new ToolStripItem[] {tsbNew, tsbOpen, tsbSave, tsbFind});

		// Menüitems Datei, analoge Symbolleistenschalter
		Bitmap bmp = new Bitmap("new.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitNew = new ToolStripMenuItem("&Neu", bmp, MitNewOnClick);
		mitNew.ShortcutKeys = Keys.Control | Keys.N;
		mitFile.DropDownItems.Add(mitNew);

		tsbNew.Image = bmp;
		tsbNew.Click += new System.EventHandler(MitNewOnClick);

		bmp = new Bitmap("open.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitOpen = new ToolStripMenuItem("&Öffnen", bmp, MitOpenOnClick);
		mitOpen.ShortcutKeys = Keys.Control | Keys.O;
		mitFile.DropDownItems.Add(mitOpen);

		tsbOpen.Image = bmp;
		tsbOpen.Click += new System.EventHandler(MitOpenOnClick);

		EventHandler ehSave = new EventHandler(MitSaveOnClick);
		
		bmp = new Bitmap("save.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitSave = new ToolStripMenuItem("&Speichern", bmp, ehSave);
		mitSave.ShortcutKeys = Keys.Control | Keys.S;
		mitFile.DropDownItems.Add(mitSave);

		tsbSave.Image = bmp;
		tsbSave.Click += new System.EventHandler(MitSaveOnClick);

		mitSaveAs = new ToolStripMenuItem("Speichern &unter...", null, ehSave);
		mitFile.DropDownItems.Add(mitSaveAs);

		mitQuit = new ToolStripMenuItem("&Beenden", null, new EventHandler(MitExitOnClick));
		mitFile.DropDownItems.Add(new ToolStripSeparator());
		mitFile.DropDownItems.Add(mitQuit);

		// Menüitems Bearbeiten, korresponiedrende Symbolleitenschalter
		bmp = new Bitmap("undo.bmp");
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

		bmp = new Bitmap("find.bmp");
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitFind = new ToolStripMenuItem("&Suchen", bmp, MitFindOnClick);
		mitFind.ShortcutKeys = Keys.Control | Keys.F;

		mitFindNext = new ToolStripMenuItem("&Weitersuchen", null, MitFindNextOnClick);
		mitFindNext.ShortcutKeys = Keys.F3;

		tsbFind.Image = bmp;
		tsbFind.Click += new System.EventHandler(MitFindOnClick);

		mitEdit.DropDownItems.AddRange(new ToolStripItem[] {mitUndo, mitRedo, new ToolStripSeparator(),
			mitCut, mitCopy, mitPaste, mitDel,
			new ToolStripSeparator(), mitSelectAll, new ToolStripSeparator(), mitFind, mitFindNext});
		mitEdit.DropDownOpening += MitEditOnPopup;

		// Menüitems Format
		mitFont = new ToolStripMenuItem("&Schriftart...", null, MitFontOnClick);
		mitFormat.DropDownItems.Add(mitFont);

		// Menüitems Extras
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

		// Form - Ereignisbehandlung
		Load += FormOnLoad;
		FormClosing += FormOnClosing;

	} // Ende Formularkonstruktor

	// Form.Load - Ereignismethode
	void FormOnLoad(object sender, EventArgs e) {
		applicationSettings = new RitchisTexteditorSettings();
		try {
			// Benutzerbezogene Einstellungen
			editor.WordWrap = applicationSettings.WordWrap;
			editor.ScrollBars = applicationSettings.ScrollBars;
			//editor.ZoomFactor = applicationSettings.ZoomFactor;
			editor.DataBindings.Add(new Binding("ZoomFactor", applicationSettings, "ZoomFactor"));
			editor.BackColor = applicationSettings.BackColor;
			ClientSize = applicationSettings.ClientSize;
			Location = applicationSettings.Location;
			// Anwendungsbezogene Einstellungen
			appName = applicationSettings.AppName;
			Text = "Unbenannt - " + appName;
		} catch {
			MessageBox.Show("Fehler beim Lesen der Einstellungen\n"+
					"Beim Beenden können keine Einstellungen gespeichert werden.",
					appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			applicationSettings = null;
		}

		// Der LocalFileSettingsProvider verwendet den folgenden Pfad leider  n i c h t  für die Datei user.config:
		//MessageBox.Show(Application.LocalUserAppDataPath.ToString());
		// So ermittelt man den tatsächlich verwendeten Pfad für die Datei user.config (Verweis auf System.Configuration erforderlich)
		//Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
		//MessageBox.Show(config.FilePath);

		// Demonstration für eine Einstellungs-Validierung über das SettingChanging-Ereignis
		//applicationSettings.SettingChanging += new SettingChangingEventHandler(AppSettOnSettChanging);
	}

	void AppSettOnSettChanging(object sender, SettingChangingEventArgs e) {
		//MessageBox.Show("Sender = " + sender.ToString() + ", SettingName = " + e.SettingName + ", NewValue = "+e.NewValue);
		if (e.SettingName.Equals("ZoomFactor")) {
			if ((float) e.NewValue > 3.0)
				e.Cancel = true;
			else
				MessageBox.Show("Der neue Zoom-Faktor ist " + e.NewValue);
		}
	}

	// Click-Handler zum Hauptmenü-Item Datei
	protected bool UnsavedText() {
		if (!(editor.Modified && editor.Text.Length > 0))
			return false;
		else {
			DialogResult result = MessageBox.Show("Es ist ungesicherter Text vorhanden.\n" +
								                  "Soll der Text gesichert werden?",
					appName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button1);
			if (result == DialogResult.Yes)
				MitSaveOnClick(mitSave, new EventArgs());
			else if (result == DialogResult.No)
				editor.Modified = false;
			else
				return true;
			if (editor.Modified)
				return true;
			else
				return false;
		}
	}

	protected void MitNewOnClick(object sender, EventArgs e) {
		if (UnsavedText())
			return;
		else {
			editor.Clear();
			Text = "Unbenannt - " + appName;
		}
	}

	protected void MitOpenOnClick(object sender, EventArgs e) {
		if (ofDialog == null) {
			ofDialog = new OpenFileDialog();
			ofDialog.Filter = filter;
		}
		if (UnsavedText())
			return;
		if (ofDialog.ShowDialog() == DialogResult.OK) {
			FileStream fs = null;
			try {
				fs = new FileStream(ofDialog.FileName, FileMode.Open,
									FileAccess.Read, FileShare.Read);
				fileType = ofDialog.FilterIndex;
				if (fileType == 1)
					editor.LoadFile(fs, RichTextBoxStreamType.PlainText);
				else
					editor.LoadFile(fs, RichTextBoxStreamType.RichText);
				fileName = ofDialog.FileName;
				Text = Path.GetFileName(fileName) + " - " + appName;
				editor.Modified = false;
			} catch (Exception ex) {
				MessageBox.Show("Fehler beim Öffnen der Datei " +
								fileName + "\n" + ex.Message, Text);
			} finally {
				if (fs != null) fs.Close();
			}
		}
	}

	protected void MitSaveOnClick(object sender, EventArgs e) {
		if (sfDialog == null) {
			sfDialog = new SaveFileDialog();
			sfDialog.Filter = filter;
		}
		bool sas = (sender == mitSaveAs);
		if (!(sas || editor.Modified))
			return;
		if (fileName == null || sas) {
			if (sfDialog.ShowDialog() != DialogResult.OK)
				return;
			fileName = sfDialog.FileName;
			fileType = sfDialog.FilterIndex;
			Text = Path.GetFileName(fileName) + " - " + appName;
		}
		FileStream fs = null;
		try {
			fs = new FileStream(fileName, FileMode.Create);
			if (fileType == 1)
				editor.SaveFile(fs, RichTextBoxStreamType.PlainText);
			else
				editor.SaveFile(fs, RichTextBoxStreamType.RichText);
			editor.Modified = false;
		} catch (Exception ex) {
			MessageBox.Show("Fehler beim Speichern in die Datei " +
							fileName + "\n" + ex.Message, Text);
		} finally {
			if (fs != null) fs.Close();
		}
	}

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

	protected void MitFindOnClick(object sender, EventArgs e) {
		if (editor.Text.Length == 0)
			return;
		if (searchDialog == null) {
			searchDialog = new SearchDialog(this);
			searchDialog.FindNext += new EventHandler(SearchDialogOnFindNext);
		}
		searchDialog.Show();
	}

	protected void MitFindNextOnClick(object sender, EventArgs e) {
		if (searchText != null)
			FindText();
		else
			MitFindOnClick(sender, e);
	}


	protected void SearchDialogOnFindNext(object sender, EventArgs e) {
		searchText = ((SearchDialog)sender).SearchText;
		FindText();
	}

	protected void FindText() {
		int start = editor.SelectionStart + editor.SelectionLength;
		int hitPosition;
		if (start >= editor.Text.Length ||
		 (hitPosition = editor.Find(searchText, start, RichTextBoxFinds.None)) < 0) {
			MessageBox.Show("'" + searchText + "' kann nicht gefunden werden.", searchDialog.Text);
		}
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
		if (editor.Text.Length > 0) {
			mitFind.Enabled = true;
			mitFindNext.Enabled = true;
		} else {
			mitFind.Enabled = false;
			mitFindNext.Enabled = false;
		}
	}

	// Click-Behandlungsmethoden zum Untermenü Format
	protected void MitFontOnClick(object sender, EventArgs e) {
		if (fontDialog == null) {
			fontDialog = new FontDialog();
			fontDialog.Font = editor.Font;
			fontDialog.ShowColor = true;
			fontDialog.Color = editor.ForeColor;
			fontDialog.ShowApply = true;
			fontDialog.Apply += new EventHandler(FontDialogOnApply);
		}
		if (fontDialog.ShowDialog() == DialogResult.OK) {
			Font oldFont = editor.Font;
			editor.Font = new Font(fontDialog.Font.FontFamily,
				(float)Math.Round(fontDialog.Font.SizeInPoints), fontDialog.Font.Style);
			oldFont.Dispose();
			editor.ForeColor = fontDialog.Color;
		}
	}

	protected void FontDialogOnApply(object sender, EventArgs e) {
		Font oldFont = editor.Font;
		editor.Font = new Font(fontDialog.Font.FontFamily,
			(float)Math.Round(fontDialog.Font.SizeInPoints), fontDialog.Font.Style);
		oldFont.Dispose();
		fontDialog.Font.Dispose();
		editor.ForeColor = fontDialog.Color;
	}

	// Click-Behandlungsmethoden zum Untermenü Extras
	protected void MitBackColorOnClick(object sender, EventArgs e) {
		if (colorDialog == null) {
			colorDialog = new ColorDialog();
			colorDialog.Color = editor.BackColor;
		}
		if (colorDialog.ShowDialog() == DialogResult.OK) {
			editor.BackColor = colorDialog.Color;
		}
	}

	protected void MitOptionenOnClick(object sender, EventArgs e) {
		if (optionsDialog == null) {
			optionsDialog = new OptionsDialog();
			optionsDialog.Apply += new EventHandler(OptionsDialogOnApply);
		}

		optionsDialog.ZoomFactor = editor.ZoomFactor;
		optionsDialog.ScrollBars = editor.ScrollBars;
		optionsDialog.WordWrap = editor.WordWrap;
		optionsDialog.OptionBackColor = editor.BackColor;

		DialogResult result = optionsDialog.ShowDialog();
		if (result == DialogResult.OK) {
			editor.WordWrap = optionsDialog.WordWrap;
			editor.ScrollBars = optionsDialog.ScrollBars;
			editor.ZoomFactor = optionsDialog.ZoomFactor;
			editor.BackColor = optionsDialog.OptionBackColor;
		}
	}

	protected void OptionsDialogOnApply(object sender, EventArgs e) {
		editor.WordWrap = optionsDialog.WordWrap;
		editor.ScrollBars = optionsDialog.ScrollBars;
		editor.ZoomFactor = optionsDialog.ZoomFactor;
		editor.BackColor = optionsDialog.OptionBackColor;
	}

	// Click-Behandlungsmethoden zum Untermenü Hilfe
	protected void MitInfoOnClick(object sender, EventArgs e) {
		MessageBox.Show(appName + "  \u00A9 by Mirko Weich");
	}

	// Aktualisierung der Symbolleiste bei Textänderung
	protected void RichTextBoxOnTextChanged(object sender, EventArgs ea) {
		double d = editor.TextLength;
		// ToolStripButton tsbFind umschalten
		if (editor.TextLength > 0)
			tsbFind.Enabled = true;
		else
			tsbFind.Enabled = false;
	}
	
	// Form.FormClosing - Ereignismethode
	void FormOnClosing(object sender, CancelEventArgs cea) {
		if (UnsavedText())
			cea.Cancel = true;
		else {
			if (applicationSettings != null) {
				applicationSettings.WordWrap = editor.WordWrap;
				applicationSettings.ScrollBars = editor.ScrollBars;
				// ZoomFactor wird per DataBinding aktualisiert (siehe Methode FormOnLoad()).
				//applicationSettings.ZoomFactor = editor.ZoomFactor;
				applicationSettings.BackColor = editor.BackColor;
				applicationSettings.ClientSize = this.ClientSize;
				applicationSettings.Location = this.Location;
				try {
					applicationSettings.Save();
				} catch {
					MessageBox.Show("Fehler beim Sichern der Einstellungen",
							appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			Application.Exit();
		}
	}

	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new RitchisTexteditor());
	}
}
// Ritchis Texteditor mit Symbolleiste
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Microsoft.Win32;

class RitchisTexteditor : Form {
	RichTextBox editor;
	MenuItem mitNew, mitOpen, mitSave, mitSaveAs, mitExit,
		mitUndo, mitCut, mitCopy, mitPaste, mitDel, mitFind, mitFindNext, mitSelectAll,
		cmitUndo, cmitCut, cmitCopy, cmitPaste, cmitDel, cmitSelectAll,
		mitFont, mitOptions;
	OptionsDialog optionsDialog;
	SuchDialog suchDialog;
	FontDialog fontDialog;
	SaveFileDialog sfDialog;
	string filter = "Textdokument (*.txt)|*.txt|RTF-Dokument (*.rtf)|*.rtf";
	int fileType; // 1: txt, 2: rtf
	string suchText, fileName, infoTextBak;
	OpenFileDialog ofDialog;
	const string strAppName = "Ritchis Texteditor";
	const string strUserKey = "Software\\RitchisTexteditor";
	const string strWordWrap = "WordWrap";
	const string strScrollBars = "ScrollBars";
	const string strZoomFactor = "ZoomFactor";
	const string strBackColor = "BackColor";
	StatusBarPanel sbpInfo, sbpTextSize;
	ToolBarButton tbbFind;

	public RitchisTexteditor() {
		Text = "Dokument - " + strAppName;
		editor = new RichTextBox();
		editor.Dock = DockStyle.Fill;
		editor.HideSelection = false;
		Controls.Add(editor);
		editor.TextChanged += new EventHandler(RichTextBoxOnTextChanged);

		// Hauptmenü
		Menu = new MainMenu();
		MenuItem mitDatei = Menu.MenuItems.Add("&Datei");
		MenuItem mitEdit = Menu.MenuItems.Add("&Bearbeiten");
		mitEdit.Popup += new EventHandler(MitEditOnPopup);
		MenuItem mitFormat = Menu.MenuItems.Add("&Format");
		MenuItem mitExtras = Menu.MenuItems.Add("&Extras");
		MenuItem mitHilfe = Menu.MenuItems.Add("&Hilfe");

		// Untermenü Datei
		mitNew = mitDatei.MenuItems.Add("&Neu...", new EventHandler(MitNewOnClick));
		mitNew.Shortcut = Shortcut.CtrlN; 
		mitOpen = mitDatei.MenuItems.Add("&Öffnen...", new EventHandler(MitOpenOnClick));
		mitOpen.Shortcut = Shortcut.CtrlO;
		EventHandler ehSave = new EventHandler(MitSaveOnClick);
		mitSave = mitDatei.MenuItems.Add("&Speichern", ehSave);
		mitSave.Shortcut = Shortcut.CtrlS;
		mitSaveAs = new MenuItem("Speichern unter...", ehSave);
		mitDatei.MenuItems.Add(mitSaveAs);
		mitDatei.MenuItems.Add("-");
		mitExit = mitDatei.MenuItems.Add("&Beenden", new EventHandler(MitExitOnClick));
		mitExit.Shortcut = Shortcut.AltF4;

		// Untermenü Bearbeiten
		mitUndo = mitEdit.MenuItems.Add("&Rückgängig", new EventHandler(MitUndoOnClick));
		mitUndo.Shortcut = Shortcut.CtrlZ;
		mitEdit.MenuItems.Add("-");
		mitCut = mitEdit.MenuItems.Add("&Ausschneiden", new EventHandler(MitCutOnClick));
		mitCut.Shortcut = Shortcut.CtrlX;
		mitCopy = mitEdit.MenuItems.Add("&Kopieren", new EventHandler(MitCopyOnClick));
		mitCopy.Shortcut = Shortcut.CtrlC;
		mitPaste = mitEdit.MenuItems.Add("&Einfügen", new EventHandler(MitPasteOnClick));
		mitPaste.Shortcut = Shortcut.CtrlV;
		mitDel = mitEdit.MenuItems.Add("&Löschen", new EventHandler(MitDeleteOnClick));
		mitDel.Shortcut = Shortcut.Del;
		mitEdit.MenuItems.Add("-");
		mitFind = mitEdit.MenuItems.Add("&Suchen", new EventHandler(MitSuchenOnClick));
		mitFind.Shortcut = Shortcut.CtrlF;
		mitFindNext = mitEdit.MenuItems.Add("&Weitersuchen", new EventHandler(MitWeitersuchenOnClick));
		mitFindNext.Shortcut = Shortcut.F3;
		mitEdit.MenuItems.Add("-");
		mitSelectAll = mitEdit.MenuItems.Add("Alles &markieren", new EventHandler(MitSelectAllOnClick));
		mitSelectAll.Shortcut = Shortcut.CtrlA;

		// Untermenü Format
		mitFont = mitFormat.MenuItems.Add("&Schriftart...", new EventHandler(MitFontOnClick));

		// Untermenü Extras
		mitOptions = mitExtras.MenuItems.Add("&Optionen...", new EventHandler(MitOptionenOnClick));

		// Untermenü Hilfe
		MenuItem mitInfo = new MenuItem("&Info",
													 new EventHandler(MitInfoOnClick),
													 Shortcut.F1);
		mitHilfe.MenuItems.Add(mitInfo);

		EventHandler mitSelectHandler = new EventHandler(MenuItemOnSelect);
		foreach (MenuItem mmit in Menu.MenuItems)
			foreach (MenuItem mit in mmit.MenuItems)
				mit.Select += mitSelectHandler;

		// Kontextmenü  mit Bearbeiten-Items
		cmitUndo = new MenuItem("&Rückgängig", new EventHandler(MitUndoOnClick));
		cmitCut = new MenuItem("&Ausschneiden", new EventHandler(MitCutOnClick));
		cmitCopy = new MenuItem("&Kopieren", new EventHandler(MitCopyOnClick));
		cmitPaste = new MenuItem("&Einfügen", new EventHandler(MitPasteOnClick));
		cmitDel = new MenuItem("&Löschen", new EventHandler(MitDeleteOnClick));
		cmitSelectAll = new MenuItem("Alles &markieren", new EventHandler(MitSelectAllOnClick));
		MenuItem[] cmi = { cmitUndo, new MenuItem("-"), cmitCut, cmitCopy, cmitPaste, new MenuItem("-"), cmitSelectAll };
		editor.ContextMenu = new ContextMenu(cmi);
		editor.ContextMenu.Popup += MitEditOnPopup;

		// Statuszeile
		StatusBar sb = new StatusBar();
		sb.Parent = this;
		sb.ShowPanels = true;

		sbpInfo = new StatusBarPanel();
		sbpInfo.BorderStyle = StatusBarPanelBorderStyle.None;
		sbpInfo.Text = "Drücken Sie F1, um Hilfe aufzurufen";
		sbpInfo.AutoSize = StatusBarPanelAutoSize.Spring;
		sb.Panels.Add(sbpInfo);

		sbpTextSize = new StatusBarPanel();
		sbpTextSize.Text = " 0 Bytes ";
		sbpTextSize.AutoSize = StatusBarPanelAutoSize.Contents;
		sbpTextSize.Alignment = HorizontalAlignment.Right;
		sbpTextSize.ToolTipText = "Textlänge (ohne RTF-Formatierungscodes)";
		sb.Panels.Add(sbpTextSize);

		// Symbolleiste
		ImageList il = new ImageList();
		il.Images.AddStrip(Image.FromFile("Toolbar.bmp"));
		il.TransparentColor = Color.Cyan;
		ToolBar tb = new ToolBar();
		tb.ImageList = il;
		tb.Parent = this;
		tb.AutoSize = false;
		tb.Height = 24;
		tb.Appearance = ToolBarAppearance.Flat;
		tb.TextAlign = ToolBarTextAlign.Right;
		tb.ButtonClick += new ToolBarButtonClickEventHandler(ToolBarOnButtonClick);
		string[] tips = { "Neu", "Öffnen", "Speichern", "Suchen" };
		MenuItem[] tags = { mitNew, mitOpen, mitSave, mitFind };
		for (int i = 0; i < 4; i++) {
			ToolBarButton tbb = new ToolBarButton();
			tbb.ImageIndex = i;
			tbb.ToolTipText = tips[i];
			tbb.Tag = tags[i];
			tb.Buttons.Add(tbb);
			//tbb.Text = tips[i];
		}
		tbbFind = tb.Buttons[3];
		tbbFind.Enabled = false;

	} //End Konstruktor RitchisTexteditor


	// Click-Behandlungsmethoden zum Untermenü Datei
	protected void MitNewOnClick(object sender, EventArgs e) {
		if (TextModified())
			MitSaveOnClick(this, EventArgs.Empty);
		editor.Clear();
		Text = "Dokument - " + strAppName;
	}

	protected void MitOpenOnClick(object sender, EventArgs e) {
		if (ofDialog == null) {
			ofDialog = new OpenFileDialog();
			ofDialog.Filter = filter;
		}
		if (TextModified())
			MitSaveOnClick(this, EventArgs.Empty);
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
				Text = Path.GetFileName(fileName) + " - " + strAppName;
				editor.Modified = false;
			} catch {
				MessageBox.Show("Fehler beim Öffnen", Text);
			} finally {
				fs.Close();
			}
		}
	}

	protected void MitSaveOnClick(object sender, EventArgs e) {
		if (sfDialog == null) {
			sfDialog = new SaveFileDialog();
			sfDialog.Filter = filter;
		}
		bool sas = (sender == mitSaveAs);
		if (!(sas || (editor.Modified && editor.Text.Length > 0)))
			return;
		if (fileName == null || sas) {
			if (sfDialog.ShowDialog() != DialogResult.OK)
				return;
			fileName = sfDialog.FileName;
			fileType = sfDialog.FilterIndex;
			Text = Path.GetFileName(fileName) + " - " + strAppName;
		}
		FileStream fs = null;
		try {
			fs = new FileStream(fileName, FileMode.Create);
			if (fileType == 1)
				editor.SaveFile(fs, RichTextBoxStreamType.PlainText);
			else
				editor.SaveFile(fs, RichTextBoxStreamType.RichText);
			editor.Modified = false;
		} catch {
			MessageBox.Show("Fehler beim Speichern", Text);
		} finally {
			fs.Close();
		}
	}

	protected void MitExitOnClick(object sender, EventArgs e) {
		Close();
	}

	// Click-Behandlungsmethoden zum Untermenü Bearbeiten
	protected void MitUndoOnClick(object sender, EventArgs e) {
		if (editor.CanUndo)
			editor.Undo();
	}
	protected void MitCutOnClick(object sender, EventArgs e) {
		if (editor.SelectionLength > 0)
			editor.Cut();
	}
	protected void MitCopyOnClick(object sender, EventArgs e) {
		if (editor.SelectionLength > 0)
			editor.Copy();
	}
	protected void MitPasteOnClick(object sender, EventArgs e) {
		editor.Paste();
	}
	protected void MitDeleteOnClick(object sender, EventArgs e) {
		if (editor.SelectionLength == 0 && editor.SelectionStart < editor.TextLength)
			editor.Select(editor.SelectionStart, 1);
		editor.SelectedText = "";
	}
	protected void MitSelectAllOnClick(object sender, EventArgs e) {
		editor.SelectAll();
	}
	protected void MitEditOnPopup(object sender, EventArgs e) {
		if (editor.CanUndo) {
			mitUndo.Enabled = true;
			cmitUndo.Enabled = true;
		} else {
			mitUndo.Enabled = false;
			cmitUndo.Enabled = false;
		}
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
		if (Clipboard.ContainsText()) {
			mitPaste.Enabled = true;
			cmitPaste.Enabled = true;
		} else {
			mitPaste.Enabled = false;
			cmitPaste.Enabled = false;
		}
		if (editor.TextLength > 0) {
			mitSelectAll.Enabled = true;
			cmitSelectAll.Enabled = true;
			mitFind.Enabled = true;
			mitFindNext.Enabled = true;
		} else {
			mitSelectAll.Enabled = false;
			cmitSelectAll.Enabled = false;
			mitFind.Enabled = false;
			mitFindNext.Enabled = false;
		}
	}

	protected void MitSuchenOnClick(object sender, EventArgs e) {
		if (editor.Text.Length == 0)
			return;
		if (suchDialog == null) {
			suchDialog = new SuchDialog();
			suchDialog.Owner = this;
			suchDialog.Weitersuchen += new EventHandler(SuchDialogOnWeitersuchen);
		}
		suchDialog.SuchText = suchText;
		suchDialog.Show();
	}

	protected void MitWeitersuchenOnClick(object sender, EventArgs e) {
		if (suchText != null)
			Weitersuchen();
		else
			MitSuchenOnClick(sender, e);
	}

	protected void SuchDialogOnWeitersuchen(object sender, EventArgs e) {
		suchText = ((SuchDialog)sender).SuchText;
		Weitersuchen();
	}

	protected void Weitersuchen() {
		int start = editor.SelectionStart + editor.SelectionLength;
		int ende = editor.TextLength;
		bool anfangRelevant = (start > 0);
		int fundStelle;
		string infoText;
	StarteSuche:
		infoText = sbpInfo.Text;
		sbpInfo.Text = "Suche ...";
		if ((fundStelle = editor.Find(suchText, start, ende, RichTextBoxFinds.None)) >= 0) {
			editor.SelectionStart = fundStelle;
			editor.SelectionLength = suchText.Length;
			sbpInfo.Text = infoText;
			return;
		}
		sbpInfo.Text = infoText;
		if (!anfangRelevant) {
			MessageBox.Show("'" + suchText + "' kann nicht gefunden werden.", suchDialog.Text);
			return;
		} else {
			anfangRelevant = false;
			if (MessageBox.Show("Soll die Suche am Textanfang fortgesetzt werden?",
												suchDialog.Text, MessageBoxButtons.YesNo,
												MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
				ende = start + suchText.Length - 1;
				start = 0;
				goto StarteSuche;
			}
		}
	}

	// Click-Behandlungsmethoden zum Untermenü Extras
	protected void MitFontOnClick(object sender, EventArgs e) {
		if (fontDialog == null) {
			fontDialog = new FontDialog();
			fontDialog.Font = editor.Font;
			fontDialog.ShowColor = true;
			fontDialog.Color = editor.ForeColor;
			fontDialog.ShowApply = true;
			fontDialog.Apply += new EventHandler(FontDialogOnApply);
		}

		Font oldFont = editor.Font;
		Color oldForeColor = editor.ForeColor;

		DialogResult result;
		result = fontDialog.ShowDialog();
		if (result == DialogResult.OK) {
			editor.Font = fontDialog.Font;
			editor.ForeColor = fontDialog.Color;
		} else if (result == DialogResult.Cancel) {
			editor.Font = oldFont;
			editor.ForeColor = oldForeColor;
		}
	}

	protected void FontDialogOnApply(object sender, EventArgs e) {
		editor.Font = fontDialog.Font;
		editor.ForeColor = fontDialog.Color;
	}

	protected void MitOptionenOnClick(object sender, EventArgs e) {
		// Nötigenfalls ein OptionsDialog-Objekt erstellen
		if (optionsDialog == null) {
			optionsDialog = new OptionsDialog();
			optionsDialog.Apply += new EventHandler(OptionsDialogOnApply);
		}

		// Eigeschaften des Dialogs mit den aktuellen Werten des Formulars besetzen
		optionsDialog.ZoomFactor = editor.ZoomFactor;
		optionsDialog.ScrollBars = editor.ScrollBars;
		optionsDialog.WordWrap = editor.WordWrap;
		optionsDialog.OptionBackColor = editor.BackColor;

		// Alte Werte sichern
		float OldZoomFactor = editor.ZoomFactor;
		RichTextBoxScrollBars OldScrollBars = editor.ScrollBars;
		bool OldWordWrap = editor.WordWrap;
		Color oldColor = editor.BackColor;

		// Aufrufen und Benutzerwahl verwenden oder zurücksetzen (bei Abbrechen nach Übernehmen)
		DialogResult result = optionsDialog.ShowDialog();
		if (result == DialogResult.OK) {
			editor.WordWrap = optionsDialog.WordWrap;
			editor.ScrollBars = optionsDialog.ScrollBars;
			editor.ZoomFactor = optionsDialog.ZoomFactor;
			editor.BackColor = optionsDialog.OptionBackColor;
		} else if (result == DialogResult.Cancel) {
			editor.ZoomFactor = OldZoomFactor;
			editor.ScrollBars = OldScrollBars;
			editor.WordWrap = OldWordWrap;
			editor.BackColor = oldColor;
		}
	}
	
	protected void OptionsDialogOnApply(object sender, EventArgs e) {
		editor.WordWrap = optionsDialog.WordWrap;
		editor.ScrollBars = optionsDialog.ScrollBars;
		editor.ZoomFactor = optionsDialog.ZoomFactor;
		editor.BackColor = optionsDialog.OptionBackColor;
	}

	// Click-Behandlungsmethoden zum Untermenü ?
	protected void MitInfoOnClick(object sender, EventArgs e) {
		MessageBox.Show(strAppName + "  \u00A9 by Mirko Weich");
	}

	// Hilfstexte zu den Menüitems
	protected override void OnMenuStart(EventArgs ea) {
		infoTextBak = sbpInfo.Text;
	}
	protected override void OnMenuComplete(EventArgs ea) {
		sbpInfo.Text = infoTextBak;
	}

	protected void MenuItemOnSelect(object sender, EventArgs ea) {
		if (sender == mitNew)
			sbpInfo.Text = "Neues Dokument beginnen";
		else if (sender == mitOpen)
			sbpInfo.Text = "Dokument öffnen";
		else if (sender == mitSave)
			sbpInfo.Text = "Dokument speichern";
		else if (sender == mitSaveAs)
			sbpInfo.Text = "Dokument in eine andere Datei speichern";
		else if (sender == mitExit)
			sbpInfo.Text = "Programm beenden";
		else if (sender == mitUndo)
			sbpInfo.Text = "Letzte Änderung rückgängig machen";
		else if (sender == mitCopy)
			sbpInfo.Text = "Markierten Text in die Zwischenablage kopieren";
		else if (sender == mitCut)
			sbpInfo.Text = "Markierten Text ausschneiden und in der Zwischenablage ablegen";
		else if (sender == mitPaste)
			sbpInfo.Text = "Text aus der Zwischenablage einfügen";
		else if (sender == mitSelectAll)
			sbpInfo.Text = "Kompletten Text markieren";
		else if (sender == mitFind)
			sbpInfo.Text = "Text suchen";
		else if (sender == mitFindNext)
			sbpInfo.Text = "Nächste Trefferstelle suchen";
		else if (sender == mitFont)
			sbpInfo.Text = "Schriftart für den gesamten Text ändern";
		else if (sender == mitOptions)
			sbpInfo.Text = "Optionen wählen";
	}


	// Muss der Text gesichert werden?
	protected bool TextModified() {
		if (editor.Modified && editor.Text.Length > 0)
			if (MessageBox.Show("Aktuelle Änderungen speichern?",
												 strAppName, MessageBoxButtons.YesNoCancel,
												 MessageBoxIcon.Question) == DialogResult.Yes)
				return true;
			else
				return false;
		return false;
	}

	// Aktualisierung von Statuszeile und Symbolleiste
	protected void RichTextBoxOnTextChanged(object sender, EventArgs ea) {
		double d = editor.TextLength;
		// ToolBarButton Find umschalten
		if (editor.TextLength > 0)
			tbbFind.Enabled = true;
		else
			tbbFind.Enabled = false;
		if (d < 1024)
			sbpTextSize.Text = String.Format("{0:f0}", d) + " Bytes ";
		else {
			d /= 1024;
			if (d < 1024)
				sbpTextSize.Text = String.Format("{0:f2}", d) + " kByte ";
			else {
				d /= 1024;
				if (d < 1024)
					sbpTextSize.Text = String.Format("{0:f2}", d) + " MByte ";
				else {
					d /= 1024;
					sbpTextSize.Text = String.Format("{0:f2}", d) + " GByte ";
				}
			}
		}
	}

	// Symbolleisten-Ereignis ButtonClick
	protected void ToolBarOnButtonClick(object sender, ToolBarButtonClickEventArgs e) {
		((MenuItem)e.Button.Tag).PerformClick();
	}

	// Ereignisse beim Starten und Beenden
	protected override void OnClosing(System.ComponentModel.CancelEventArgs cea) {
		if (TextModified())
			MitSaveOnClick(this, EventArgs.Empty);
	}

	protected override void OnLoad(EventArgs ea) {
		base.OnLoad(ea);
		RegistryKey userKey = Registry.CurrentUser.OpenSubKey(strUserKey);
		if (userKey != null) {
			try {
				int ww = (int)userKey.GetValue(strWordWrap);
				switch (ww) {
					case 0: editor.WordWrap = false; break;
					case 1: editor.WordWrap = true; break;
				}
				string strSB = (string)userKey.GetValue(strScrollBars);
				if (strSB != null)
					switch (strSB) {
						case "None":
							editor.ScrollBars = RichTextBoxScrollBars.None; break;
						case "Vertical":
							editor.ScrollBars = RichTextBoxScrollBars.Vertical; break;
						case "Horizontal":
							editor.ScrollBars = RichTextBoxScrollBars.Horizontal; break;
						case "Both":
							editor.ScrollBars = RichTextBoxScrollBars.Both; break;
					}
				int zf = (int)userKey.GetValue(strZoomFactor);
				if (zf >= 64 && zf <= 640)
					editor.ZoomFactor = ((float)zf) / 100;
				int color = (int)userKey.GetValue(strBackColor);
				editor.BackColor = Color.FromArgb(color);
			} catch {
				MessageBox.Show("Fehler beim Laden der Einstellungen", strAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			userKey.Close();
		}
	}

	protected override void OnClosed(EventArgs ea) {
		base.OnClosed(ea);
		RegistryKey userKey = null;
		try {
			userKey = Registry.CurrentUser.OpenSubKey(strUserKey, true);
			if (userKey == null)
				userKey = Registry.CurrentUser.CreateSubKey(strUserKey);
			userKey.SetValue(strWordWrap, (editor.WordWrap == true ? 1 : 0));
			switch (editor.ScrollBars) {
				case RichTextBoxScrollBars.None:
					userKey.SetValue(strScrollBars, "None"); break;
				case RichTextBoxScrollBars.Vertical:
					userKey.SetValue(strScrollBars, "Vertical"); break;
				case RichTextBoxScrollBars.Horizontal:
					userKey.SetValue(strScrollBars, "Horizontal"); break;
				case RichTextBoxScrollBars.Both:
					userKey.SetValue(strScrollBars, "Both"); break;
			}
			userKey.SetValue(strZoomFactor, (int)(editor.ZoomFactor * 100 + 0.5));
			userKey.SetValue(strBackColor, editor.BackColor.ToArgb());
		} catch {
			MessageBox.Show("Fehler beim Speicher der Einstellungen", strAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		} finally {
			userKey.Close();
		}
	}

	[STAThread]
	static void Main() {
		Application.Run(new RitchisTexteditor());
	}
}
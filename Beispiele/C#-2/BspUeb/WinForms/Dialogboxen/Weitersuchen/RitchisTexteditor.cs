// Ritchis Texteditor mit Lösungsvorschlag Weitersuchen

using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

class RitchisTexteditor : Form {
	RichTextBox editor;
	MenuItem mitSaveAs, mitUndo, mitCut, mitCopy, mitPaste, mitDel, mitFind, mitFindNext, mitSelectAll,
			     cmitUndo, cmitCut, cmitCopy, cmitPaste, cmitDel, cmitSelectAll;
	OptionsDialog optionsDialog;
	SuchDialog suchDialog;
	string suchText;
	FontDialog fontDialog;
	SaveFileDialog sfDialog;
	string filter = "Textdokument (*.txt)|*.txt|RTF-Dokument (*.rtf)|*.rtf";
	int fileType; // 1: txt, 2: rtf
	string appName, fileName;
	OpenFileDialog ofDialog;

	public RitchisTexteditor() {
		appName = "Ritchis Texteditor";
		Text = "Dokument - " + appName;
		editor = new RichTextBox();
		editor.Dock = DockStyle.Fill;
		editor.HideSelection = false;
		Controls.Add(editor);

		// Hauptmenü
		Menu = new MainMenu();
		MenuItem mitDatei = Menu.MenuItems.Add("&Datei");
		MenuItem mitEdit = Menu.MenuItems.Add("&Bearbeiten");
		mitEdit.Popup += new EventHandler(MitEditOnPopup);
		MenuItem mitFormat = Menu.MenuItems.Add("&Format");
		MenuItem mitExtras = Menu.MenuItems.Add("&Extras");
		MenuItem mitHilfe = Menu.MenuItems.Add("&Hilfe");

		// Untermenü Datei
		mitDatei.MenuItems.Add(new MenuItem("&Öffnen...",
																		new EventHandler(MitOpenOnClick),
																		Shortcut.CtrlO));
		EventHandler ehSave = new EventHandler(MitSaveOnClick);
		mitDatei.MenuItems.Add(new MenuItem("&Speichern", ehSave, Shortcut.CtrlS));
		mitSaveAs = new MenuItem("Speichern unter...", ehSave);
		mitDatei.MenuItems.Add(mitSaveAs);
		mitDatei.MenuItems.Add("-");
		mitDatei.MenuItems.Add(new MenuItem("&Beenden",
																				new EventHandler(MitExitOnClick),
																				Shortcut.AltF4));

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
		mitFormat.MenuItems.Add(new MenuItem("&Schriftart...", MitFontOnClick));

		// Untermenü Extras
		mitExtras.MenuItems.Add(new MenuItem("&Optionen...", new EventHandler(MitOptionenOnClick)));

		// Untermenü Hilfe
		MenuItem mitInfo = new MenuItem("&Info",
													 new EventHandler(MitInfoOnClick),
													 Shortcut.F1);
		mitHilfe.MenuItems.Add(mitInfo);

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

	} //End Konstruktor RitchisTexteditor

	// Click-Behandlungsmethoden zum Untermenü Datei
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
				Text = Path.GetFileName(fileName) + " - " + appName;
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
	StarteSuche:
		if ((fundStelle = editor.Find(suchText, start, ende, RichTextBoxFinds.None)) >= 0) {
			editor.SelectionStart = fundStelle;
			editor.SelectionLength = suchText.Length;
			return;
		}
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
		MessageBox.Show(appName + "  \u00A9 by Mirko Weich");
	}

	// Muss der Text gesichert werden?
	protected bool TextModified() {
		if (editor.Modified && editor.Text.Length > 0)
			if (MessageBox.Show("Aktuelle Änderungen speichern?",
												 appName, MessageBoxButtons.YesNoCancel,
												 MessageBoxIcon.Question) == DialogResult.Yes)
				return true;
			else
				return false;
		return false;
	}

	protected override void OnClosing(System.ComponentModel.CancelEventArgs cea) {
		if (TextModified())
			MitSaveOnClick(this, EventArgs.Empty);
	}

	[STAThread]
	static void Main() {
		Application.Run(new RitchisTexteditor());
	}
}
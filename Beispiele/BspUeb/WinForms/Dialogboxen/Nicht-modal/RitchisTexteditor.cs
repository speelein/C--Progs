// Ritchis Texteditor mit nicht-modalem Dialog

using System;
using System.Windows.Forms;
using System.Drawing;

class RitchisTexteditor : Form {
	RichTextBox editor;
	MenuItem mitDatei, mitExtras, mitHilfe,
			 mitUndo, mitCut, mitCopy, mitPaste, mitDel, mitFind, mitSelectAll,
			 cmitUndo, cmitCut, cmitCopy, cmitPaste, cmitDel, cmitSelectAll,
			 mitFont, mitCourierNew, mitTimesNewRoman, mitArial, mitAktFont,
			 mitSize,
			 mitInfo;
	Font fontTNR12, fontCN12, fontA12, fontTNR16, fontCN16, fontA16;
	OptionsDialog optionsDialog;
	SuchDialog suchDialog;
	string suchText;

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
		Controls.Add(editor);

		// Hauptmenü
		Menu = new MainMenu();
		mitDatei = Menu.MenuItems.Add("&Datei");
		MenuItem mitEdit = Menu.MenuItems.Add("&Bearbeiten");
		mitEdit.Popup += new EventHandler(MitEditOnPopup);
		mitExtras = Menu.MenuItems.Add("&Extras");
		mitHilfe = Menu.MenuItems.Add("&Hilfe");

		// Untermenü Datei
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
		mitEdit.MenuItems.Add("-");
		mitSelectAll = mitEdit.MenuItems.Add("Alles &markieren", new EventHandler(MitSelectAllOnClick));
		mitSelectAll.Shortcut = Shortcut.CtrlA;

		// Untermenü Extras
		mitFont = mitExtras.MenuItems.Add("&Schriftart");
		EventHandler fontHandler = new EventHandler(MitFontOnClick);
		mitCourierNew = new MenuItem("&Courier New", fontHandler);
		mitCourierNew.RadioCheck = true;
		mitFont.MenuItems.Add(mitCourierNew);
		mitTimesNewRoman = new MenuItem("&Times New Roman", fontHandler);
		mitTimesNewRoman.Checked = true;
		mitTimesNewRoman.RadioCheck = true;
		mitAktFont = mitTimesNewRoman;
		mitFont.MenuItems.Add(mitTimesNewRoman);
		mitArial = new MenuItem("&Arial", fontHandler);
		mitArial.RadioCheck = true;
		mitFont.MenuItems.Add(mitArial);

		mitSize = new MenuItem("&Große Schrift", new EventHandler(MitSizeOnClick));
		mitSize.Checked = false;
		mitExtras.MenuItems.Add(mitSize);
		mitExtras.MenuItems.Add("-");

		mitExtras.MenuItems.Add(new MenuItem("&Optionen...", new EventHandler(MitOptionenOnClick)));

		// Untermenü ?
		mitInfo = new MenuItem("&Info",
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
		} else {
			mitSelectAll.Enabled = false;
			cmitSelectAll.Enabled = false;
			mitFind.Enabled = false;
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
			MessageBox.Show("'"+suchText+"' kann nicht gefunden werden.",	suchDialog.Text);
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
		mitAktFont.Checked = false;
		mitAktFont = (MenuItem)sender;
		mitAktFont.Checked = true;

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
		if (mitAktFont == mitCourierNew) {
			editor.Font = (mitSize.Checked ? fontCN16 : fontCN12);
		} else
			if (mitAktFont == mitTimesNewRoman) {
				editor.Font = (mitSize.Checked ? fontTNR16 : fontTNR12);
			} else {
				editor.Font = (mitSize.Checked ? fontA16 : fontA12);
			}
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

		// Alte Werte sichern
		float OldZoomFactor = editor.ZoomFactor;
		RichTextBoxScrollBars OldScrollBars = editor.ScrollBars;
		bool OldWordWrap = editor.WordWrap;

		// Aufrufen und Benutzerwahl verwenden oder zurücksetzen (bei Abbrechen nach Übernehmen)
		DialogResult result = optionsDialog.ShowDialog();
		if (result == DialogResult.OK) {
			editor.WordWrap = optionsDialog.WordWrap;
			editor.ScrollBars = optionsDialog.ScrollBars;
			editor.ZoomFactor = optionsDialog.ZoomFactor;
		} else if (result == DialogResult.Cancel) {
			editor.ZoomFactor = OldZoomFactor;
			editor.ScrollBars = OldScrollBars;
			editor.WordWrap = OldWordWrap;
		}
	}
	
	protected void OptionsDialogOnApply(object sender, EventArgs e) {
		editor.WordWrap = optionsDialog.WordWrap;
		editor.ScrollBars = optionsDialog.ScrollBars;
		editor.ZoomFactor = optionsDialog.ZoomFactor;
	}

	// Click-Behandlungsmethoden zum Untermenü ?
	protected void MitInfoOnClick(object sender, EventArgs e) {
		MessageBox.Show(Text + "  \u00A9 by Mirko Weich");
	}

	[STAThread]
	static void Main() {
		Application.Run(new RitchisTexteditor());
	}
}
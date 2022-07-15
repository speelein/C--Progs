// Ritchis Texteditor mit Zwischenablage sowie Drag & Drop

using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;
using Microsoft.Win32;
using System.Threading;

class RitchisTexteditor : Form {
	RichTextBox editor;
	MenuItem mitNew, mitOpen, mitSave, mitSaveAs, mitPrint, mitPreview, mitPageSetup, mitExit,
		mitUndo, mitCut, mitCopy, mitPaste, mitDel, mitFind, mitFindNext, mitSelectAll,
		cmitUndo, cmitCut, cmitCopy, cmitPaste, cmitDel, cmitSelectAll,
		mitFont, mitOptions;
	OptionsDialog optionsDialog;
	SuchDialog suchDialog;
	FontDialog fontDialog;
	SaveFileDialog sfDialog;
	string filter = "Textdokument (*.txt)|*.txt|RTF-Dokument (*.rtf)|*.rtf";
	int fileType; // 1: txt, 2: rtf
	string suchText, fileName, infoTextBak, tempText;
	OpenFileDialog ofDialog;
	const string strAppName = "Ritchis Texteditor";
	const string strUserKey = "Software\\RitchisTexteditor";
	const string strWordWrap = "WordWrap";
	const string strScrollBars = "ScrollBars";
	const string strZoomFactor = "ZoomFactor";
	const string strBackColor = "BackColor";
	StatusBarPanel sbpInfo, sbpTextSize;
	ToolBarButton tbbCut, tbbCopy, tbbPaste, tbbPrint, tbbPreview, tbbFind, tbbUndo;
	PrintDocument druckAuftrag = new PrintDocument();
	PrintDialog druckDialog = new PrintDialog();
	int fromPage, toPage, actPage;
	PrintPreviewDialog previewDialog = new PrintPreviewDialog();
	PageSetupDialog pageSetupDialog = new PageSetupDialog();
	long lastClick;

	struct RitchSelection {
		public int Start, Length;
	}

	public RitchisTexteditor() {
		Text = "Dokument - " + strAppName;
		editor = new RichTextBox();
		editor.Dock = DockStyle.Fill;
		editor.HideSelection = false;
		Controls.Add(editor);
		editor.TextChanged += new EventHandler(RichTextBoxOnTextChanged);
		editor.SelectionChanged += new EventHandler(RichTextBoxOnSelectionChanged);
		editor.GotFocus += new EventHandler(EditorOnGotFocus);
		// Drag & Drop
		editor.AllowDrop = true;
		editor.DragEnter += new DragEventHandler(EditorOnDragEnter);
		editor.DragOver += new DragEventHandler(EditorOnDragOver);
		editor.DragDrop += new DragEventHandler(EditorOnDragDrop);
		editor.MouseDown += new MouseEventHandler(EditorOnMouseDown);
		lastClick = DateTime.Now.Ticks;

		// Hauptmenü
		Menu = new MainMenu();
		MenuItem mitFile = Menu.MenuItems.Add("&Datei");
		mitFile.Popup += new EventHandler(MitFileOnPopup);
		MenuItem mitEdit = Menu.MenuItems.Add("&Bearbeiten");
		mitEdit.Popup += new EventHandler(MitEditOnPopup);
		MenuItem mitFormat = Menu.MenuItems.Add("&Format");
		MenuItem mitExtras = Menu.MenuItems.Add("&Extras");
		MenuItem mitHilfe = Menu.MenuItems.Add("&Hilfe");

		// Untermenü Datei
		mitNew = mitFile.MenuItems.Add("&Neu...", new EventHandler(MitNewOnClick));
		mitNew.Shortcut = Shortcut.CtrlN; 
		mitOpen = mitFile.MenuItems.Add("&Öffnen...", new EventHandler(MitOpenOnClick));
		mitOpen.Shortcut = Shortcut.CtrlO;
		EventHandler ehSave = new EventHandler(MitSaveOnClick);
		mitSave = mitFile.MenuItems.Add("&Speichern", ehSave);
		mitSave.Shortcut = Shortcut.CtrlS;
		mitSaveAs = new MenuItem("Speichern unter...", ehSave);
		mitFile.MenuItems.Add(mitSaveAs);
		mitFile.MenuItems.Add("-");
		mitPrint = mitFile.MenuItems.Add("&Drucken", new EventHandler(MitPrintOnClick));
		mitPrint.Shortcut = Shortcut.CtrlP;
		mitPreview = mitFile.MenuItems.Add("Seitenans&icht", new EventHandler(MitPreviewOnClick));
		mitPageSetup = mitFile.MenuItems.Add("Seite ein&richten", new EventHandler(MitPageSetupOnClick));
		mitFile.MenuItems.Add("-");
		mitExit = mitFile.MenuItems.Add("&Beenden", new EventHandler(MitExitOnClick));
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
		string[] tips = {"Neu", "Öffnen", "Speichern", "Drucken", "Seitenansicht", "Suchen", "Ausschneiden",
			"Kopieren", "Einfügen", "Rückgängig"};
		MenuItem[] tags = {mitNew, mitOpen, mitSave, mitPrint, mitPreview, mitFind, mitCut,	mitCopy, mitPaste, mitUndo};
		for (int i = 0; i < 10; i++) {
			ToolBarButton tbb = new ToolBarButton();
			tbb.ImageIndex = i;
			tbb.ToolTipText = tips[i];
			tbb.Tag = tags[i];
			tb.Buttons.Add(tbb);
		}
		tbbPrint = tb.Buttons[3];
		tbbPrint.Enabled = false;
		tbbPreview = tb.Buttons[4];
		tbbPreview.Enabled = false;
		tbbFind = tb.Buttons[5];
		tbbFind.Enabled = false;
		tbbCut = tb.Buttons[6];
		tbbCut.Enabled = false;
		tbbCopy = tb.Buttons[7];
		tbbCopy.Enabled = false;
		tbbPaste = tb.Buttons[8];
		tbbPaste.Enabled = Clipboard.ContainsText();
		tbbUndo = tb.Buttons[9];
		tbbUndo.Enabled = false;

		// Druckfunktion
		druckDialog.Document = druckAuftrag;
		druckDialog.AllowSomePages = true;
		druckDialog.AllowCurrentPage = true;
		druckDialog.UseEXDialog = true;
		druckAuftrag.BeginPrint += new PrintEventHandler(DruckAuftragOnBeginPrint);
		druckAuftrag.PrintPage += new PrintPageEventHandler(DruckAuftragOnPrintPage);
		previewDialog.Document = druckAuftrag;
		pageSetupDialog.Document = druckAuftrag;
		pageSetupDialog.EnableMetric = true;

	} //End Konstruktor RitchisTexteditor


	// Click-Behandlungsmethoden zum Untermenü Datei
	protected void MitNewOnClick(object sender, EventArgs e) {
		int answer = TextModified();
		if (answer == -1)
			return;
		if (answer == 1)
			MitSaveOnClick(this, EventArgs.Empty);
		editor.Clear();
		Text = "Dokument - " + strAppName;
		fileName = null;
	}

	protected void MitOpenOnClick(object sender, EventArgs e) {
		if (ofDialog == null) {
			ofDialog = new OpenFileDialog();
			ofDialog.Filter = filter;
		}
		int answer = TextModified();
		if (answer == -1)
			return;
		if (answer == 1)
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

	protected void MitPrintOnClick(object sender, EventArgs e) {
		druckDialog.AllowSelection = (editor.SelectionLength > 0);
		if (druckDialog.ShowDialog() == DialogResult.OK)
			druckAuftrag.Print();
	}

	protected void DruckAuftragOnBeginPrint(object sender, PrintEventArgs e) {
		if (e.PrintAction == PrintAction.PrintToPreview) {
			tempText = editor.Text;
			fromPage = 1;
			toPage = Int32.MaxValue;
		} else
			switch (druckDialog.PrinterSettings.PrintRange) {
				case PrintRange.AllPages:
					tempText = editor.Text;
					fromPage = 1;
					toPage = Int32.MaxValue;
					break;
				case PrintRange.Selection:
					tempText = editor.SelectedText;
					fromPage = 1;
					toPage = Int32.MaxValue;
					break;
				case PrintRange.SomePages:
					tempText = editor.Text;
					fromPage = druckDialog.PrinterSettings.FromPage;
					toPage = druckDialog.PrinterSettings.ToPage;
					break;
				case PrintRange.CurrentPage:
					tempText = editor.Text;
					fromPage = 1;
					toPage = Int32.MaxValue;
					break;
			}
		actPage = 1;
		if (fileName != null)
			druckAuftrag.DocumentName = Path.GetFileName(fileName);
		else
			druckAuftrag.DocumentName = Text;
	}

	protected void DruckAuftragOnPrintPage(object sender, PrintPageEventArgs e) {
		Graphics g = e.Graphics;
		int anzZeichen, anzZeilen, ganzeZeilen;
		float zeilenabstand;
		RectangleF rectPage;

		// Ausgaberechteck unter Beachtung des nicht bedruckbaren Rands bestimmen
		rectPage = new RectangleF(e.MarginBounds.Left - e.PageSettings.HardMarginX,
															e.MarginBounds.Top - e.PageSettings.HardMarginY,
															Math.Min(e.MarginBounds.Width, g.VisibleClipBounds.Width),
															Math.Min(e.MarginBounds.Height, g.VisibleClipBounds.Height));

		// Die Höhe des Ausgaberechtsecks wird so bestimmt, dass eine ganze Anzahl von Zeilen hinein passt.
		zeilenabstand = editor.Font.GetHeight(g); // GetHeight() verwendet die akt. Einheit des Graphics-Objektes.
		ganzeZeilen = (int)(rectPage.Height / zeilenabstand);
		rectPage.Height = ganzeZeilen * zeilenabstand;

		// StringFormat für Text einstellen (wird auch in MeasureString() benötigt)
		StringFormat sfText = new StringFormat();
		if (editor.WordWrap)
			sfText.Trimming = StringTrimming.Word;
		else {
			sfText.Trimming = StringTrimming.EllipsisCharacter;
			sfText.FormatFlags |= StringFormatFlags.NoWrap;
		}

		if (druckAuftrag.PrinterSettings.PrintRange == PrintRange.CurrentPage) {
			// Bei Ausgabe der akt. Seite wird diese über das Ende der Markierung ermittelt.
			long written = 0;
			bool found = false;
			while (tempText.Length > 0  && !found) {
				g.MeasureString(tempText, editor.Font, rectPage.Size, sfText, out anzZeichen, out anzZeilen);
				if (!editor.WordWrap)
					anzZeichen = NumberOfCharsInBlock(tempText, anzZeilen);
				written += anzZeichen;
				if (written < editor.SelectionStart + editor.SelectionLength) {
					tempText = tempText.Substring(anzZeichen);
					actPage++;
				} else {
					found = true;
					fromPage = toPage = actPage;
				}
			}
		} else if (druckAuftrag.PrinterSettings.PrintRange == PrintRange.SomePages) {
			// Bei Ausgabe eines Seitenbereichs die Startseite suchen
			while (actPage < fromPage && tempText.Length > 0) {
				g.MeasureString(tempText, editor.Font, rectPage.Size, sfText, out anzZeichen, out anzZeilen);
				if (!editor.WordWrap)
					anzZeichen = NumberOfCharsInBlock(tempText, anzZeilen);
				tempText = tempText.Substring(anzZeichen);
				actPage++;
			}
		}

		// Wurde beim Ermitteln der Startseite das Textende erreicht, wird der Druckauftrag abgebrochen:
		if (tempText.Length == 0) {
			e.Cancel = true;
			return;
		}

		// Text ausgeben
		g.DrawString(tempText, editor.Font, Brushes.Black, rectPage, sfText);

		// Bei hinreichend Platz im oberen und unteren Randbereich wird eine Kopf- bzw. Fußzeile ausgegeben.
		StringFormat sfKF = new StringFormat();
		sfKF.Alignment = StringAlignment.Center;
		if (rectPage.Top > zeilenabstand) {
			RectangleF rectHead = rectPage;
			rectHead.Height = zeilenabstand;
			rectHead.Y = Math.Max((e.PageSettings.Margins.Top - zeilenabstand) / 2 - e.PageSettings.HardMarginY, 0);
			g.DrawString(druckAuftrag.DocumentName, editor.Font, Brushes.Black, rectHead, sfKF);
		}
		if (g.VisibleClipBounds.Height - rectPage.Bottom > zeilenabstand) {
			RectangleF rectFoot = rectPage;
			rectFoot.Height = zeilenabstand;
			rectFoot.Y = Math.Min(rectPage.Bottom + (e.PageSettings.Margins.Bottom - zeilenabstand) / 2, g.VisibleClipBounds.Height - zeilenabstand);
			g.DrawString("Seite " + actPage.ToString(), editor.Font, Brushes.Black, rectFoot, sfKF);
		}

		// restlichen Text ermitteln
		g.MeasureString(tempText, editor.Font, rectPage.Size, sfText, out anzZeichen, out anzZeilen);
		if (!editor.WordWrap)
			anzZeichen = NumberOfCharsInBlock(tempText, anzZeilen);
		tempText = tempText.Substring(anzZeichen);
		actPage++;

		// Sind weitere Seiten auszugeben?
		if (tempText.Length > 0 && actPage <= toPage)
			e.HasMorePages = true;
	}

	int NumberOfCharsInBlock(string text, int anzZeilen) {
		// Diese Methode wurde weitgehend von Petzold (2003, S. 906) übernommen.
		// Sie wird nur bei abgeschaltetem Zeilenumbruch aufgerufen.
		int last = 0;
		for (int i = 0; i < anzZeilen; i++) {
			last = text.IndexOf("\n", last) + 1;
			// falls der gesamte Drucktext auf die Seite passte, wird am Ende der letzten Zeile keine NewLine-Sequenz gefunden:
			if (last == 0)
				return text.Length;
		}
		return last;
	}

	protected void MitPreviewOnClick(object sender, EventArgs e) {
		previewDialog.ShowDialog();
	}

	protected void MitPageSetupOnClick(object sender, EventArgs e) {
		pageSetupDialog.ShowDialog();
	}

	protected void MitExitOnClick(object sender, EventArgs e) {
		Close();
	}

	protected void MitFileOnPopup(object sender, EventArgs e) {
		if (editor.TextLength > 0) {
			mitPrint.Enabled = true;
			mitPreview.Enabled = true;
		} else {
			mitPrint.Enabled = false;
			mitPreview.Enabled = false;
		}
	}

	// Click-Behandlungsmethoden zum Untermenü Bearbeiten
	protected void MitUndoOnClick(object sender, EventArgs e) {
		if (editor.CanUndo)
			editor.Undo();
	}
	protected void MitCutOnClick(object sender, EventArgs e) {
		if (editor.SelectionLength > 0) {
			editor.Cut();
			tbbPaste.Enabled = true;
		}
	}
	protected void MitCopyOnClick(object sender, EventArgs e) {
		if (editor.SelectionLength > 0) {
			editor.Copy();
			tbbPaste.Enabled = true;
		}
	}

	//protected void MitCopyOnClick(object sender, EventArgs e) {
	//  if (editor.SelectionLength > 0) {
	//    //Clipboard.SetText(editor.SelectedRtf, TextDataFormat.Rtf);
	//    //Clipboard.SetDataObject(editor.SelectedRtf, true);
	//    DataObject dataObject = new DataObject();
	//    dataObject.SetData(DataFormats.Rtf, editor.SelectedRtf);
	//    dataObject.SetData(DataFormats.Text, editor.SelectedText);
	//    Clipboard.SetDataObject(dataObject, true);
	//    tbbPaste.Enabled = true;
	//  }
	//}

	protected void MitPasteOnClick(object sender, EventArgs e) {
		editor.Paste();
	}

	//protected void MitPasteOnClick(object sender, EventArgs e) {
	//  if (Clipboard.ContainsText(TextDataFormat.Rtf))
	//    editor.SelectedRtf = Clipboard.GetText(TextDataFormat.Rtf);
	//  else
	//    if (Clipboard.ContainsText())
	//      editor.SelectedText = Clipboard.GetText();
	//}

	//protected void MitPasteOnClick(object sender, EventArgs e) {
	//  IDataObject dataObject = Clipboard.GetDataObject();
	//  if (dataObject.GetDataPresent(DataFormats.Rtf))
	//    editor.SelectedRtf = (string)dataObject.GetData(DataFormats.Rtf);
	//  else
	//    if (dataObject.GetDataPresent(typeof(String)))
	//      editor.SelectedText = (string)dataObject.GetData(typeof(String));
	//}
	
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

		Font oldFont = editor.SelectionFont;
		Color oldForeColor = editor.SelectionColor;

		DialogResult result;
		result = fontDialog.ShowDialog();
		if (result == DialogResult.OK) {
			editor.SelectionFont = fontDialog.Font;
			editor.SelectionColor = fontDialog.Color;
		} else if (result == DialogResult.Cancel) {
			editor.SelectionFont = oldFont;
			editor.SelectionColor = oldForeColor;
		}
	}

	protected void FontDialogOnApply(object sender, EventArgs e) {
		editor.SelectionFont = fontDialog.Font;
		editor.SelectionColor = fontDialog.Color;
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
		else if (sender == mitPrint)
			sbpInfo.Text = "Text drucken";
		else if (sender == mitPreview)
			sbpInfo.Text = "Seitenansicht";
		else if (sender == mitPageSetup)
			sbpInfo.Text = "Seite einrichten";
		else if (sender == mitFont)
			sbpInfo.Text = "Schriftart für den gesamten Text ändern";
		else if (sender == mitOptions)
			sbpInfo.Text = "Optionen wählen";
	}

	// Muss der Text gesichert werden?
	protected int TextModified() {
		if (!editor.Modified || editor.Text.Length == 0)
			return 0;
		DialogResult result = MessageBox.Show("Aktuelle Änderungen speichern?",
												 strAppName, MessageBoxButtons.YesNoCancel,
												 MessageBoxIcon.Question);
		if (result == DialogResult.Yes)
			return 1;
		else
			if (result == DialogResult.No)
				return 0;
			else
				return -1;
	}

	// Aktualisierung von Statuszeile und Symbolleiste bei Textänderung
	protected void RichTextBoxOnTextChanged(object sender, EventArgs ea) {
		double d = editor.TextLength;
		// ToolBarButton Find umschalten
		if (editor.TextLength > 0) {
			tbbPrint.Enabled = true;
			tbbPreview.Enabled = true;
			tbbFind.Enabled = true;
		} else {
			tbbPrint.Enabled = false;
			tbbPreview.Enabled = false;
			tbbFind.Enabled = false;
		}
		if (editor.CanUndo) {
			tbbUndo.Enabled = true;
		} else {
			tbbUndo.Enabled = false;
		}

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

	// Aktualisierung der Symbolleiste bei Auswahländerung
	protected void RichTextBoxOnSelectionChanged(object sender, EventArgs ea) {
		if (editor.SelectionLength > 0) {
			tbbCut.Enabled = true;
			tbbCopy.Enabled = true;
		} else {
			tbbCut.Enabled = false;
			tbbCopy.Enabled = false;
		}
	}

	// Aktualisierung der Symbolleiste bei Fokus-Übernahme durch das RichTextBox-Objekt
	protected void EditorOnGotFocus(object o, EventArgs ea) {
		if (Clipboard.ContainsText()) {
			tbbPaste.Enabled = true;
		} else {
			tbbPaste.Enabled = false;
		}
	}

	// Symbolleisten-Ereignis ButtonClick
	protected void ToolBarOnButtonClick(object sender, ToolBarButtonClickEventArgs e) {
		((MenuItem)e.Button.Tag).PerformClick();
	}

	//Drag & Drop
	protected void EditorOnMouseDown(object sender, MouseEventArgs e) {
		int selStart, selLength;
		bool within = false;
		// Nichts tun bei Doppel- oder Dreifachklick (z.B. zur Textmarkierung)
		long diff = DateTime.Now.Ticks - lastClick;
		lastClick = DateTime.Now.Ticks;
		if (diff < 3000000) {
			lastClick = DateTime.Now.Ticks;
			return;
		}
		if (e.Button == MouseButtons.Left && editor.SelectionLength > 0) { // Nichts tun bei Rechtsklick oder leerer Markierung
			selStart = editor.SelectionStart;
			selLength = editor.SelectionLength;
			int textLength = editor.Text.Length;
			DataObject dataObject = new DataObject();
			RitchSelection rs = new RitchSelection();
			rs.Start = selStart;
			rs.Length = selLength;
			dataObject.SetData("Selected in RitchisTextBox", rs);
			dataObject.SetData("Rich Text Format", editor.SelectedRtf);
			DragDropEffects ddResult = editor.DoDragDrop(dataObject, DragDropEffects.Copy | DragDropEffects.Move);
			if (editor.Text.Length > textLength)
				within = true;
			if (ddResult == DragDropEffects.Move) {	// Bei MOVE den Text am alten Ort per CUT() (wegen Undo-Option) löschen
				if (within) {
					if (editor.SelectionStart > selStart) {  //nach rechts verschoben
						editor.SelectionStart = selStart;
					} else { // nach links verschoben
						editor.SelectionStart = selStart + selLength;
					}
				} else {
					editor.SelectionStart = selStart;
				}
				editor.SelectionLength = selLength;
				editor.Cut();
			}
			if (!within) {
				dataObject.SetData("Drag & Drop Canceled", new Object()); // Sonst wird nach Drop in ein Fremdprogramm  auch noch ein internes DragDrop-Ereignis ausgelöst.
				// Verhindert einen Caret-Sprung an den Textanfang:
				editor.SelectionStart = selStart;
			}
		}
	}

	void EditorOnDragEnter(object sender, DragEventArgs dea) {
		editor.Focus(); // Caret() sichtbar machen
	}

	void EditorOnDragOver(object sender, DragEventArgs dea) {
		if ((dea.KeyState & 1) != 1)
			return;
		if (dea.Data.GetDataPresent(DataFormats.FileDrop)) {
			dea.Effect = DragDropEffects.Copy;
		} else {
			if (dea.Data.GetDataPresent(DataFormats.Text) || dea.Data.GetDataPresent(DataFormats.Rtf)) {
				if (((dea.AllowedEffect & DragDropEffects.Move) != 0) && (dea.KeyState & 8) == 0) {
					dea.Effect = DragDropEffects.Move;
				} else {
					if ((dea.AllowedEffect & DragDropEffects.Copy) != 0)
						dea.Effect = DragDropEffects.Copy;
				}
			}
		}
		if (dea.Data.GetDataPresent(DataFormats.Text) || dea.Data.GetDataPresent(DataFormats.Rtf)) {
			editor.SelectionLength = 0;
			Point pt = editor.PointToClient(new Point(dea.X, dea.Y));
			int insPos = editor.GetCharIndexFromPosition(pt);
			// Die nächste Anweisung korrigiert einen GetCharIndexFromPosition()-Bug:
			// Befindet sich die Maus hinter dem letzten Zeichen, ist die gemeldete Position um 1 zu klein.
			if (pt.X > editor.GetPositionFromCharIndex(insPos).X + 10)
				insPos++;
			editor.SelectionStart = insPos;
			// Ein interner Transport in die Markierung ist verboten:
			if (dea.Data.GetDataPresent("Selected in RitchisTextBox")) {
				RitchSelection sel = (RitchSelection)dea.Data.GetData("Selected in RitchisTextBox");
				if (editor.SelectionStart < sel.Start + sel.Length && editor.SelectionStart > sel.Start)
					dea.Effect = DragDropEffects.None;
			}
		}
	}

	void EditorOnDragDrop(object sender, DragEventArgs dea) {
		if (dea.Data.GetDataPresent("Drag & Drop Canceled"))
			return;
		if (dea.Data.GetDataPresent(DataFormats.Rtf)) {
			int oldSelectionStart = editor.SelectionStart;
			editor.SelectedRtf = (string) dea.Data.GetData(DataFormats.Rtf);
			editor.SelectionStart = oldSelectionStart;
		} else
			if (dea.Data.GetDataPresent(DataFormats.StringFormat)) {
				int oldSelectionStart = editor.SelectionStart;
				editor.SelectedText = (string)dea.Data.GetData(DataFormats.StringFormat);
				editor.SelectionStart = oldSelectionStart;
			} else
				if (dea.Data.GetDataPresent(DataFormats.FileDrop)) {
					int answer = TextModified();
					if (answer == -1)
						return;
					if (answer == 1)
						MitSaveOnClick(this, EventArgs.Empty);
					String[] fns = (string[])dea.Data.GetData(DataFormats.FileDrop);
					FileStream fs = null;
					try {
						fs = new FileStream(fns[0], FileMode.Open,
																FileAccess.Read, FileShare.Read);
						editor.Text = "";
						editor.LoadFile(fs, RichTextBoxStreamType.PlainText);
						if (editor.Text.Substring(2, 4).IndexOf("rtf1") == 0)
							editor.Rtf = editor.Text;
						fileName = fns[0];
						Text = Path.GetFileName(fileName) + " - " + strAppName;
						editor.Modified = false;
					} catch {
						MessageBox.Show("Fehler beim Öffnen der Datei " + fns[0], strAppName,
														MessageBoxButtons.OK, MessageBoxIcon.Error);
					} finally {
						fs.Close();
					}
				}
	}

	// Ereignisse beim Starten und Beenden
	protected override void OnClosing(System.ComponentModel.CancelEventArgs cea) {
		int answer = TextModified();
		if (answer == -1) {
			cea.Cancel = true;
			return;
		}
		if (answer == 1)
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
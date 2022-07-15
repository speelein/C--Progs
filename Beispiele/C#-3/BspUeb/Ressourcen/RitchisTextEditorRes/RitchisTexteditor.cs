// Ritchis Texteditor mit Zwischenablage sowie Drag & Drop

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using System.Configuration;
using RitchisNamespace.Properties;

[assembly: AssemblyCompany("Mirko Weich")]
[assembly: AssemblyProduct("Ritchis Texteditor")]
[assembly: AssemblyVersion("1.4.2.3")]

class RitchisTexteditor : Form {
	RichTextBox editor;

	RitchisTexteditorSettings applicationSettings;
	ToolStripMenuItem	mitFile, mitEdit, mitFormat, mitTools, mitHelp,
						mitNew, mitOpen, mitSave, mitSaveAs, mitPrint, mitPreview, mitPageSetup, mitQuit,
						mitUndo, mitRedo, mitCut, mitCopy, mitPaste, mitDel, mitSelectAll,
						mitFind, mitFindNext,
						cmitUndo, cmitRedo, cmitCut, cmitCopy, cmitPaste, cmitDel, cmitSelectAll,
						mitFont,
						mitOptions,
						mitInfo;
	OptionsDialog optionsDialog;
	SearchDialog searchDialog;
	String searchText, infoTextBak;
	FontDialog fontDialog;
	ColorDialog colorDialog;
	SaveFileDialog sfDialog;
	String filter = "Textdokument (*.txt)|*.txt|RTF-Dokument (*.rtf)|*.rtf";
	int fileType; // 1: txt, 2: rtf
	String appName, fileName;
	OpenFileDialog ofDialog;

	ToolStripButton tsbNew, tsbOpen, tsbSave, tsbPrint, tsbPreview, tsbFind;
	ToolStripStatusLabel sblInfo, sblTextSize;

	PrintDocument printJob = new PrintDocument();
	PrintDialog printDialog = new PrintDialog();
	string tempText;
	int fromPage, toPage, actPage;
	PrintPreviewDialog previewDialog = new PrintPreviewDialog();
	PageSetupDialog pageSetupDialog = new PageSetupDialog();

	public RitchisTexteditor() {
		appName = Application.ProductName;
		Text = "Unbenannt - " + appName;
		editor = new RichTextBox();
		editor.Dock = DockStyle.Fill;
		editor.HideSelection = false;
		editor.Font = new Font("Lucida Console", 12);
		editor.TextChanged += new EventHandler(RichTextBoxOnTextChanged);
		editor.AcceptsTab = true;
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
		tsbPrint = new ToolStripButton();
		tsbPrint.Enabled = false;
		tsbPrint.ToolTipText = "Drucken";
		tsbPreview = new ToolStripButton();
		tsbPreview.Enabled = false;
		tsbPreview.ToolTipText = "Seitenansicht";
		tsbFind = new ToolStripButton();
		tsbFind.Enabled = false;
		tsbFind.ToolTipText = "Suchen";

		toolStripStandard.Items.AddRange(
			new ToolStripItem[] { tsbNew, tsbOpen, tsbSave, tsbPrint, tsbPreview, tsbFind });

		// Menüitems Datei, analoge Symbolleistenschalter
		Bitmap bmp = Resources.New;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitNew = new ToolStripMenuItem("&Neu", bmp, MitNewOnClick);
		mitNew.ShortcutKeys = Keys.Control | Keys.N;
		mitFile.DropDownItems.Add(mitNew);

		tsbNew.Image = bmp;
		tsbNew.Click += new System.EventHandler(MitNewOnClick);

		bmp = Resources.Open;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitOpen = new ToolStripMenuItem("&Öffnen", bmp, MitOpenOnClick);
		mitOpen.ShortcutKeys = Keys.Control | Keys.O;
		mitFile.DropDownItems.Add(mitOpen);

		tsbOpen.Image = bmp;
		tsbOpen.Click += new System.EventHandler(MitOpenOnClick);

		EventHandler ehSave = new EventHandler(MitSaveOnClick);

		bmp = Resources.Save;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitSave = new ToolStripMenuItem("&Speichern", bmp, ehSave);
		mitSave.ShortcutKeys = Keys.Control | Keys.S;
		mitFile.DropDownItems.Add(mitSave);

		tsbSave.Image = bmp;
		tsbSave.Click += new System.EventHandler(MitSaveOnClick);

		mitSaveAs = new ToolStripMenuItem("Speichern &unter...", null, ehSave);
		mitFile.DropDownItems.Add(mitSaveAs);

		bmp = Resources.Print;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitPrint = new ToolStripMenuItem("&Drucken...", bmp, new EventHandler(MitPrintOnClick));
		mitPrint.ShortcutKeys = Keys.Control | Keys.P;
		mitFile.DropDownItems.Add(new ToolStripSeparator());
		mitFile.DropDownItems.Add(mitPrint);

		tsbPrint.Image = bmp;
		tsbPrint.Click += new System.EventHandler(MitPrintOnClick);

		bmp = Resources.Preview;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitPreview = new ToolStripMenuItem("&Seitenans&icht...", bmp, new EventHandler(MitPreviewOnClick));
		mitFile.DropDownItems.Add(mitPreview);

		tsbPreview.Image = bmp;
		tsbPreview.Click += new System.EventHandler(MitPreviewOnClick);

		mitPageSetup = new ToolStripMenuItem("Seite ein&richten...", null, new EventHandler(MitPageSetupOnClick));
		mitFile.DropDownItems.Add(mitPageSetup);

		mitQuit = new ToolStripMenuItem("&Beenden", null, new EventHandler(MitExitOnClick));
		mitFile.DropDownItems.Add(new ToolStripSeparator());
		mitFile.DropDownItems.Add(mitQuit);
		mitFile.DropDownOpening += MitFileOnPopup;

		// Menüitems Bearbeiten, korresponiedrende Symbolleitenschalter
		bmp = Resources.Undo;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitUndo = new ToolStripMenuItem("&Rückgängig", bmp, MitUnRedoOnClick);
		mitUndo.ShortcutKeys = Keys.Control | Keys.Z;
		cmitUndo = new ToolStripMenuItem("&Rückgängig", bmp, MitUnRedoOnClick);

		bmp = Resources.Redo;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitRedo = new ToolStripMenuItem("&Wiederholen", bmp, MitUnRedoOnClick);
		mitRedo.ShortcutKeys = Keys.Control | Keys.Y;
		cmitRedo = new ToolStripMenuItem("&Wiederholen", bmp, MitUnRedoOnClick);

		bmp = Resources.Cut;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitCut = new ToolStripMenuItem("Auss&chneiden", bmp, MitCutOnClick);
		mitCut.ShortcutKeys = Keys.Control | Keys.X;
		cmitCut = new ToolStripMenuItem("Auss&chneiden", bmp, MitCutOnClick);

		bmp = Resources.Copy;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitCopy = new ToolStripMenuItem("&Kopieren", bmp, MitCopyOnClick);
		mitCopy.ShortcutKeys = Keys.Control | Keys.C;
		cmitCopy = new ToolStripMenuItem("&Kopieren", bmp, MitCopyOnClick);

		bmp = Resources.Paste;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitPaste = new ToolStripMenuItem("&Einfügen", bmp, MitPasteOnClick);
		mitPaste.ShortcutKeys = Keys.Control | Keys.V;
		cmitPaste = new ToolStripMenuItem("&Einfügen", bmp, MitPasteOnClick);

		bmp = Resources.Del;
		bmp.MakeTransparent(bmp.GetPixel(0, 0));
		mitDel = new ToolStripMenuItem("&Löschen", bmp, MitDeleteOnClick);
		mitDel.ShortcutKeys = Keys.Delete;
		cmitDel = new ToolStripMenuItem("&Löschen", bmp, MitDeleteOnClick);

		mitSelectAll = new ToolStripMenuItem("&Alles auswählen", null, MitSelectAllOnClick);
		mitSelectAll.ShortcutKeys = Keys.Control | Keys.A;
		cmitSelectAll = new ToolStripMenuItem("&Alles auswählen", null, MitSelectAllOnClick);

		bmp = Resources.Find;
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

		StatusStrip statusStrip = new StatusStrip();
		statusStrip.ShowItemToolTips = true;
		Controls.Add(statusStrip);

		sblInfo = new ToolStripStatusLabel();
		sblInfo.Text = "Drücken Sie F1, um Hilfe aufzurufen";
		sblInfo.TextAlign = ContentAlignment.MiddleLeft;
		sblInfo.Spring = true;
	
		sblTextSize = new ToolStripStatusLabel();
		sblTextSize.TextAlign = ContentAlignment.MiddleRight;
		sblTextSize.Text = "0 Bytes";
		sblTextSize.AutoSize = true;
		sblTextSize.ToolTipText = "Textlänge (ohne RTF-Formatierungscodes)";
		sblTextSize.AutoToolTip = false;

		statusStrip.Items.AddRange(new ToolStripItem[] {sblInfo, sblTextSize});

		// Vorbereitungen für die Statusleisten-Inforanzeige zu den Menü-Items
		mainMenu.MenuActivate += MainMenuOnActivate;
		mainMenu.MenuDeactivate += MainMenuOnDeactivate;
		EventHandler mitMouseHoverHandler = new EventHandler(MenuItemOnMouseHover);
		EventHandler mitMouseLeaveHandler = new EventHandler(MenuItemOnMouseLeave);
		foreach (ToolStripMenuItem mit in mainMenu.Items)
			foreach (ToolStripItem umit in mit.DropDownItems) {
				umit.MouseHover += mitMouseHoverHandler;
				umit.MouseLeave += mitMouseLeaveHandler;
			}

		// Druckfunktion
		printDialog.Document = printJob;
		printDialog.AllowSomePages = true;
		printDialog.AllowCurrentPage = true;
		printDialog.UseEXDialog = true;

		printJob.BeginPrint += new PrintEventHandler(PrintJobOnBeginPrint);
		printJob.PrintPage += new PrintPageEventHandler(PrintJobOnPrintPage);

		previewDialog.Document = printJob;
		//previewDialog.UseAntiAlias = true;

		pageSetupDialog.Document = printJob;
		pageSetupDialog.EnableMetric = true;

		// Drag & Drop
		editor.EnableAutoDragDrop = true;

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

	protected void MitPrintOnClick(object sender, EventArgs e) {
		printDialog.AllowSelection = (editor.SelectionLength > 0);
		if (sender == mitPrint) {
			if (printDialog.ShowDialog() == DialogResult.OK) {
				printJob.Print();
			}
		} else
			printJob.Print();
	}

	protected void PrintJobOnBeginPrint(object sender, PrintEventArgs e) {
		switch (printJob.PrinterSettings.PrintRange) {
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
				fromPage = printJob.PrinterSettings.FromPage;
				toPage = printDialog.PrinterSettings.ToPage;
				break;
			case PrintRange.CurrentPage:
				tempText = editor.Text;
				fromPage = 1;
				toPage = Int32.MaxValue;
				break;
		}
		actPage = 1;
		if (fileName != null)
			printJob.DocumentName = Path.GetFileName(fileName);
		else
			printJob.DocumentName = Text;
	}

	protected void PrintJobOnPrintPage(object sender, PrintPageEventArgs e) {
		Graphics g = e.Graphics;
		int nrChars, nrLines, completeLines;
		float lineSpacing;
		RectangleF rectPage;

		// Ausgaberechteck unter Beachtung des nicht bedruckbaren Rands bestimmen
		rectPage = new RectangleF(e.MarginBounds.Left - e.PageSettings.HardMarginX,
									e.MarginBounds.Top - e.PageSettings.HardMarginY,
									Math.Min(e.MarginBounds.Width, g.VisibleClipBounds.Width),
									Math.Min(e.MarginBounds.Height, g.VisibleClipBounds.Height));

		// Die Höhe des Ausgaberechtsecks wird so bestimmt, dass eine ganze Anzahl von Zeilen hinein passt.
		lineSpacing = editor.Font.GetHeight(g); // GetHeight() verwendet die akt. Einheit des Graphics-Objektes.
		completeLines = (int)(rectPage.Height / lineSpacing);
		rectPage.Height = completeLines * lineSpacing;

		// StringFormat für Text einstellen (wird auch in MeasureString() benötigt)
		StringFormat sfText = new StringFormat();
		if (editor.WordWrap)
			sfText.Trimming = StringTrimming.Word;
		else {
			sfText.Trimming = StringTrimming.EllipsisCharacter;
			sfText.FormatFlags |= StringFormatFlags.NoWrap;
		}

		if (printJob.PrinterSettings.PrintRange == PrintRange.CurrentPage) {
			// Bei Ausgabe der akt. Seite wird diese über das Ende der Markierung ermittelt.
			long written = 0;
			bool found = false;
			while (tempText.Length > 0 && !found) {
				g.MeasureString(tempText, editor.Font, rectPage.Size, sfText, out nrChars, out nrLines);
				if (!editor.WordWrap)
					nrChars = NumberOfCharsInBlock(tempText, nrLines);
				written += nrChars;
				if (written < editor.SelectionStart + editor.SelectionLength) {
					tempText = tempText.Substring(nrChars);
					actPage++;
				} else {
					found = true;
					fromPage = toPage = actPage;
				}
			}
		} else if (printJob.PrinterSettings.PrintRange == PrintRange.SomePages) {
			// Bei Ausgabe eines Seitenbereichs die Startseite suchen
			while (actPage < fromPage && tempText.Length > 0) {
				g.MeasureString(tempText, editor.Font, rectPage.Size, sfText, out nrChars, out nrLines);
				if (!editor.WordWrap)
					nrChars = NumberOfCharsInBlock(tempText, nrLines);
				tempText = tempText.Substring(nrChars);
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
		if (rectPage.Top > lineSpacing) {
			RectangleF rectHead = rectPage;
			rectHead.Height = lineSpacing;
			rectHead.Y = Math.Max((e.PageSettings.Margins.Top - lineSpacing) / 2 - e.PageSettings.HardMarginY, 0);
			g.DrawString(printJob.DocumentName, editor.Font, Brushes.Black, rectHead, sfKF);
		}
		if (g.VisibleClipBounds.Height - rectPage.Bottom > lineSpacing) {
			RectangleF rectFoot = rectPage;
			rectFoot.Height = lineSpacing;
			rectFoot.Y = Math.Min(rectPage.Bottom + (e.PageSettings.Margins.Bottom - lineSpacing) / 2, g.VisibleClipBounds.Height - lineSpacing);
			g.DrawString("Seite " + actPage.ToString(), editor.Font, Brushes.Black, rectFoot, sfKF);
		}

		// restlichen Text ermitteln
		g.MeasureString(tempText, editor.Font, rectPage.Size, sfText, out nrChars, out nrLines);
		if (!editor.WordWrap)
			nrChars = NumberOfCharsInBlock(tempText, nrLines);
		tempText = tempText.Substring(nrChars);
		actPage++;

		// Sind weitere Seiten auszugeben?
		if (tempText.Length > 0 && actPage <= toPage)
			e.HasMorePages = true;
	}

	int NumberOfCharsInBlock(string text, int nrLines) {
		// Diese Methode wurde weitgehend von Petzold (2002, S. 906) übernommen.
		// Sie wird nur bei abgeschaltetem Zeilenumbruch aufgerufen.
		int last = 0;
		for (int i = 0; i < nrLines; i++) {
			last = text.IndexOf("\n", last) + 1;
			// falls der gesamte Drucktext auf die Seite passte, wird am Ende der letzten Zeile keine NewLine-Sequenz gefunden:
			if (last == 0)
				return text.Length;
		}
		return last;
	}

	protected void MitPreviewOnClick(object sender, EventArgs e) {
		tempText = editor.Text;
		fromPage = 1;
		toPage = Int32.MaxValue;
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

	// Manuelles Copy mit Clipboard.SetText()
	//protected void MitCopyOnClick(object sender, EventArgs e) {
	//    if (editor.SelectionLength > 0)
	//        Clipboard.SetText(editor.SelectedRtf, TextDataFormat.Rtf);
	//}

	// Manuelles Copy  mit Clipboard.SetDataObject()
	//protected void MitCopyOnClick(object sender, EventArgs e) {
	//    if (editor.SelectionLength > 0) {
	//        DataObject dataObject = new DataObject();
	//        dataObject.SetData(DataFormats.Rtf, editor.SelectedRtf);
	//        dataObject.SetData(DataFormats.Text, editor.SelectedText);
	//        Clipboard.SetDataObject(dataObject, true);
	//    }
	//}

	protected void MitDeleteOnClick(object sender, EventArgs e) {
		if (editor.SelectionLength == 0 && editor.SelectionStart < editor.TextLength)
			editor.Select(editor.SelectionStart, 1);
		editor.SelectedText = "";
	}

	protected void MitPasteOnClick(object sender, EventArgs e) {
	    editor.Paste();
	}

	// Manuelles Paste mit Clipboard.GetText()
	//protected void MitPasteOnClick(object sender, EventArgs e) {
	//    if (Clipboard.ContainsText(TextDataFormat.Text) || Clipboard.ContainsText(TextDataFormat.Rtf))
	//        editor.SelectedRtf = Clipboard.GetText(TextDataFormat.Rtf);
	//    else
	//        if (Clipboard.ContainsText())
	//            editor.SelectedText = Clipboard.GetText();
	//}

	// Manuelles Paste mit mit Clipboard.GetDataObject()
	//protected void MitPasteOnClick(Object sender, EventArgs e) {
	//    IDataObject dataObject = Clipboard.GetDataObject();
	//    if (dataObject.GetDataPresent(DataFormats.Rtf))
	//        editor.SelectedRtf = (String)dataObject.GetData(DataFormats.Rtf);
	//    else
	//        if (dataObject.GetDataPresent(typeof(String)))
	//            editor.SelectedText = (String)dataObject.GetData(typeof(String));
	//}

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
		String infoText = sblInfo.Text;
		sblInfo.Text = "Suche ...";
		Refresh();
		if (start >= editor.Text.Length ||
		 (hitPosition = editor.Find(searchText, start, RichTextBoxFinds.None)) < 0) {
			MessageBox.Show("'" + searchText + "' kann nicht gefunden werden.", searchDialog.Text);
		}
		sblInfo.Text = infoText;
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
			editor.SelectionFont = new Font(fontDialog.Font.FontFamily,
				(float)Math.Round(fontDialog.Font.SizeInPoints), fontDialog.Font.Style);
			editor.SelectionColor = fontDialog.Color;
		}
	}

	protected void FontDialogOnApply(object sender, EventArgs e) {
		editor.SelectionFont = new Font(fontDialog.Font.FontFamily,
			(float)Math.Round(fontDialog.Font.SizeInPoints), fontDialog.Font.Style);
		editor.SelectionColor = fontDialog.Color;
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

	// Menüitem-Erläuterungen in der Statuszeile anzeigen
	protected void MainMenuOnActivate(object sender, EventArgs ea) {
		infoTextBak = sblInfo.Text;
	}
	protected void MainMenuOnDeactivate(object sender, EventArgs ea) {
		sblInfo.Text = infoTextBak;
		infoTextBak = "";
	}

	protected void MenuItemOnMouseHover(object sender, EventArgs ea) {
		if (sender == mitNew)
			sblInfo.Text = "Neues Dokument beginnen";
		else if (sender == mitOpen)
			sblInfo.Text = "Dokument öffnen";
		else if (sender == mitSave)
			sblInfo.Text = "Dokument speichern";
		else if (sender == mitSaveAs)
			sblInfo.Text = "Dokument in eine andere Datei speichern";
		else if (sender == mitSaveAs)
			sblInfo.Text = "Dokument in eine andere Datei speichern";
		else if (sender == mitPrint)
			sblInfo.Text = "Dokument im Textformat drucken";
		else if (sender == mitPreview)
			sblInfo.Text = "Druckvorschau";
		else if (sender == mitPageSetup)
			sblInfo.Text = "Seiteneinrichtung (z.B. Papierformat, Ränder)";
		else if (sender == mitQuit)
			sblInfo.Text = "Programm beenden";
		else if (sender == mitUndo)
			sblInfo.Text = "Letzte Änderung rückgängig machen";
		else if (sender == mitCopy)
			sblInfo.Text = "Markierten Text in die Zwischenablage kopieren";
		else if (sender == mitCut)
			sblInfo.Text = "Markierten Text ausschneiden und in der Zwischenablage ablegen";
		else if (sender == mitPaste)
			sblInfo.Text = "Text aus der Zwischenablage einfügen";
		else if (sender == mitSelectAll)
			sblInfo.Text = "Kompletten Text markieren";
		else if (sender == mitFind)
			sblInfo.Text = "Text suchen";
		else if (sender == mitFindNext)
			sblInfo.Text = "Nächste Trefferstelle suchen";
		else if (sender == mitFont)
			sblInfo.Text = "Schriftart für den gesamten Text ändern";
		else if (sender == mitOptions)
			sblInfo.Text = "Optionen wählen";
		else if (sender == mitInfo)
			sblInfo.Text = "Informationen zum Programm anzeigen";
	}

	protected void MenuItemOnMouseLeave(object sender, EventArgs ea) {
		if (infoTextBak != "")
			sblInfo.Text = "";
	}
	
	// Aktualisierung der Symbol- und Statusleiste bei Textänderung
	protected void RichTextBoxOnTextChanged(object sender, EventArgs ea) {
		double d = editor.TextLength;
		// ToolStripButton tsbFind umschalten
		if (editor.TextLength > 0) {
			tsbFind.Enabled = true;
			tsbPrint.Enabled = true;
			tsbPreview.Enabled = true;
		} else {
			tsbFind.Enabled = false;
			tsbPrint.Enabled = false;
			tsbPreview.Enabled = false;
		}

		// Textlängenanzeige aktualisieren 
		if (d < 1024)
			sblTextSize.Text = String.Format("{0:f0}", d) + " Bytes ";
		else {
			d /= 1024;
			if (d < 1024)
				sblTextSize.Text = String.Format("{0:f2}", d) + " KBytes ";
			else {
				d /= 1024;
				if (d < 1024)
					sblTextSize.Text = String.Format("{0:f2}", d) + " MBytes ";
				else {
					d /= 1024;
					sblTextSize.Text = String.Format("{0:f2}", d) + " GBytes ";
				}
			}
		}
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
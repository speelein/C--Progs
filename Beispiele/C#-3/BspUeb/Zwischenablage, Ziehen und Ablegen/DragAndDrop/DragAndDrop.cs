using System;
using System.Windows.Forms;
using System.Drawing;

class DragAndDrop : Form {
	Bitmap picture,insertPicture;
	Graphics gPicture, gForm;
	Point oleck, insertPoint;
	Rectangle mark;
	DataObject dataObject;
	bool intDrop;
	Point mousePos;
	int pictureWidth = 300;
	int pictureHeight = 200;

	public DragAndDrop() {
		picture = new Bitmap(pictureWidth, pictureHeight);
		gPicture = Graphics.FromImage(picture);
		gPicture.Clear(Color.White);

		this.Text = "Drag & Drop";
		this.ClientSize = new Size(pictureWidth, pictureHeight);
		this.FormBorderStyle = FormBorderStyle.FixedSingle;
		this.gForm = CreateGraphics();
		this.AllowDrop = true;
		this.Paint += FormOnPaint;
		this.MouseDown += FormOnMouseDown;
		this.MouseMove += FormOnMouseMove;
		this.DragOver += FormOnDragOver;
		this.DragDrop += FormOnDragDrop;
		this.QueryContinueDrag += FormOnQueryContinueDrag;

		oleck.X = -1;
		mark.Width = -1;
		dataObject = new DataObject();
	}

	void FormOnPaint(object sender, PaintEventArgs e) {
		e.Graphics.DrawImage(picture, 0, 0);
		if (mark.Width > 0)
			e.Graphics.DrawRectangle(Pens.Red, mark);
	}

	void FormOnMouseDown(object sender, MouseEventArgs e) {
		if (e.Button == MouseButtons.Left) {
			mousePos = new Point(e.X, e.Y);
			return;
		} else
			if (e.Button != MouseButtons.Right)
				return;
		if (oleck.X < 0) {
			oleck = new Point(e.X, e.Y);
		} else
			if (mark.Width < 0) {
				if ((e.X > oleck.X) && (e.Y > oleck.Y))
					mark = new Rectangle(oleck, new Size(e.X - oleck.X, e.Y - oleck.Y));
					gForm.DrawRectangle(Pens.Red, mark);
			} else {
				gForm.Clear(Color.White);
				Renew();
			}
	}

	void FormOnMouseMove(object sender, MouseEventArgs e) {
		if (!(e.Button == MouseButtons.Left) || mark.Width < 0 ||
			mousePos.X < oleck.X || mousePos.X > oleck.X + mark.Width ||
			mousePos.Y < oleck.Y || mousePos.Y > oleck.Y + mark.Height)
			return;
		if (Math.Abs(mousePos.X - e.X) > SystemInformation.DragSize.Width ||
			Math.Abs(e.Y - mousePos.Y) > SystemInformation.DragSize.Height) {
			Rectangle localMark = mark;
			intDrop = false;
			Bitmap subPic = picture.Clone(mark, picture.PixelFormat);
			dataObject.SetData(DataFormats.Bitmap,subPic);
			//DragDropEffects ddResult = DoDragDrop(picture.Clone(mark, picture.PixelFormat), DragDropEffects.Copy | DragDropEffects.Move);
			DragDropEffects ddResult = DoDragDrop(dataObject,
				DragDropEffects.Copy | DragDropEffects.Move);
			if (ddResult == DragDropEffects.Move) {
				gPicture.FillRectangle(Brushes.White, localMark);
				if (intDrop)  // Bei einer internen Verschiebung wurde eben eventuell das Ziel verletzt.
					gPicture.DrawImage(insertPicture, insertPoint);
			}
			Renew();
		}
	}

	private void FormOnDragOver(object sender, DragEventArgs dea) {
		if ((dea.KeyState & 1) != 1)
			return;
		if (dea.Data.GetDataPresent(DataFormats.Text) ||
			dea.Data.GetDataPresent(DataFormats.Bitmap) ||
			dea.Data.GetDataPresent(DataFormats.FileDrop)) {
			if (((dea.AllowedEffect & DragDropEffects.Move) != 0) && (dea.KeyState & 8) == 0) {
				dea.Effect = DragDropEffects.Move;
			} else {
				if ((dea.AllowedEffect & DragDropEffects.Copy) != 0)
					dea.Effect = DragDropEffects.Copy;
			}
		}
	}

	private void FormOnDragDrop(object sender, DragEventArgs dea) {
		if (dea.Data.GetDataPresent(DataFormats.Text)) {
			String text = (string) dea.Data.GetData(DataFormats.Text);
			insertPoint = PointToClient(new Point(dea.X, dea.Y));
			gPicture.DrawString(text, Font, Brushes.Black, insertPoint);
			Refresh();
		} else if (dea.Data.GetDataPresent(DataFormats.Bitmap)) {
			intDrop = true;
			insertPicture = (Bitmap)dea.Data.GetData(DataFormats.Bitmap);
			insertPoint = PointToClient(new Point(dea.X, dea.Y));
			try {
				gPicture.DrawImage(insertPicture, insertPoint);
			} catch (Exception e) {
				MessageBox.Show(e.Message);
			}
			Renew();
		} else if (dea.Data.GetDataPresent(DataFormats.FileDrop)) {
			String[] fns = (string[])dea.Data.GetData(DataFormats.FileDrop);
			gPicture.DrawImage(new Bitmap(fns[0]),
				               new Rectangle(0, 0, pictureWidth, pictureHeight));
			Refresh();
		}
	}

	void FormOnQueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
		// Abbrechen beim Verlassen des Fenster-Klientenbereichs
		Point pc = PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));	
		if (pc.X < 0 || pc.X > ClientSize.Width ||
			pc.Y < 0 || pc.Y > ClientSize.Height)
			e.Action = DragAction.Cancel;
	}

	void Renew() {
		oleck.X = -1;
		mark.Width = -1;
		Refresh();
	}

	[STAThread]
	static void Main() {
		Application.Run(new DragAndDrop());
	}
}



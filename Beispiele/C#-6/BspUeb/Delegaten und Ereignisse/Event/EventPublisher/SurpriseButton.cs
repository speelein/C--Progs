using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventPublisher {
	/// <summary>
	/// Führen Sie die Schritte 1a oder 1b und anschließend Schritt 2 aus, um dieses benutzerdefinierte Steuerelement in einer XAML-Datei zu verwenden.
	///
	/// Schritt 1a) Verwenden des benutzerdefinierten Steuerelements in einer XAML-Datei, die im aktuellen Projekt vorhanden ist.
	/// Fügen Sie dieses XmlNamespace-Attribut dem Stammelement der Markupdatei 
	/// an der Stelle hinzu, an der es verwendet werden soll:
	///
	///     xmlns:MyNamespace="clr-namespace:EventPublisher"
	///
	///
	/// Schritt 1b) Verwenden des benutzerdefinierten Steuerelements in einer XAML-Datei, die in einem anderen Projekt vorhanden ist.
	/// Fügen Sie dieses XmlNamespace-Attribut dem Stammelement der Markupdatei 
	/// an der Stelle hinzu, an der es verwendet werden soll:
	///
	///     xmlns:MyNamespace="clr-namespace:EventPublisher;assembly=EventPublisher"
	///
	/// Darüber hinaus müssen Sie von dem Projekt, das die XAML-Datei enthält, einen Projektverweis
	/// zu diesem Projekt hinzufügen und das Projekt neu erstellen, um Kompilierungsfehler zu vermeiden:
	///
	///     Klicken Sie im Projektmappen-Explorer mit der rechten Maustaste auf das Zielprojekt und anschließend auf
	///     "Verweis hinzufügen"->"Projekte"->[Navigieren Sie zu diesem Projekt, und wählen Sie es aus.]
	///
	///
	/// Schritt 2)
	/// Fahren Sie fort, und verwenden Sie das Steuerelement in der XAML-Datei.
	///
	///     <MyNamespace:SurpriseButton/>
	///
	/// </summary>
	/// 


	public class SevenEventArgs : EventArgs {
		public int Nr;
	}

	public delegate void SevenEventHandler(object sender, SevenEventArgs e);

	public class SurpriseButton : Button {
		internal event SevenEventHandler Seven;
		Random zzg = new Random();

		protected override void OnClick() {
			base.OnClick();
			if (Seven != null) {
				int losnummer = zzg.Next(10000);
				if (losnummer % 7 == 0) {
					SevenEventArgs sea = new SevenEventArgs();
					sea.Nr = losnummer;
					OnSeven(sea);
				}
			}
		}

		protected virtual void OnSeven(SevenEventArgs sea) {
			Seven(this, sea);
		}
	}
}

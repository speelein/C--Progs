using System;
using System.ComponentModel;
using System.Windows;

public class Person : INotifyPropertyChanged {
	public event PropertyChangedEventHandler PropertyChanged;

	double income;

	public double Income {
		get { return income; }
		set { if (value >= 0.0) {
				income = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Income)));
				//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Einkommen"));
			} else
				Console.WriteLine($"Falscher Wert {value} bei Eigenschaft {nameof(Income)}");
		}
	}

	public String FirstName { get; set; }
	public String LastName { get; set; }

	public Person(String fn, String ln, double income) {
		FirstName = fn; LastName = ln; Income = income;
	}
}


class Prog {
	static void Person_PropertyChanged(Object sender, PropertyChangedEventArgs pc) {
		MessageBox.Show("Neuer Wert bei der Eigenschaft " + pc.PropertyName);
	}

	static void Main() {
		Person p = new Person("Otto", "Mayer", -1);
		p.PropertyChanged += Person_PropertyChanged;
		p.Income = 5500;
    }
}
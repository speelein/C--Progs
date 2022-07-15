using System;
using System.ComponentModel;
using System.Windows;

public class Person : INotifyPropertyChanged {
	public event PropertyChangedEventHandler PropertyChanged;
	decimal income;
	public decimal Income {
		get { return income; }
		set {
			if (value >= 0.0m) {
				income = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Income)));
			} else
				throw new ArgumentException(string.Format(
							   $"Falscher Wert {value} bei Eigenschaft {nameof(Income)}"));
		}
	}

	public string FirstName { get; set; }
	public string LastName { get; set; }

	public Person(string fn, string ln, decimal income) {
		FirstName = fn; LastName = ln; Income = income;
	}
}



class Prog {
	static void PersonPropertyChanged(Object sender, PropertyChangedEventArgs pc) {
		MessageBox.Show("Neuer Wert bei der Eigenschaft " + pc.PropertyName + " : " + (sender as Person).Income);
	}

	static void Main() {
		Person p = new Person("Otto", "Mayer", 1000m);
		p.PropertyChanged += PersonPropertyChanged;
		p.Income = 5500m;
    }
}
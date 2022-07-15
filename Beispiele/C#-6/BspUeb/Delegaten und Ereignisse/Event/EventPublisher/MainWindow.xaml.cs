﻿using System;
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
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			surpriseButton.Seven += surpriseButton_Seven;
		}

		void surpriseButton_Seven(object sender, SevenEventArgs e) {
			MessageBox.Show("Sie haben gewonenen. Losnummer: " + e.Nr, "Event Consumer");
		}
	}
}

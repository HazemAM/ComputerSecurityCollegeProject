using System;
using System.Windows.Forms;

namespace ComputerSecurity
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			string enc = Ceasar.encrypt("Hazem", 3);
			string dec = Ceasar.decrypt(enc, 3);
		}
	}
}

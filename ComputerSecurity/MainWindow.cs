using System;
using System.Windows.Forms;

namespace ComputerSecurity
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			string enc = Ceasar.encrypt("Haz-em", 3);
			string dec = Ceasar.decrypt(enc, 3);
			
			enc = Playfair.encrypt("Hazem", "playfairexample");
			dec = Playfair.decrypt(enc, "playfairexample");
		}
	}
}

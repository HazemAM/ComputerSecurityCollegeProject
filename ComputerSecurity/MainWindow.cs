using System;
using System.Windows.Forms;

namespace ComputerSecurity
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();

			string enc, dec, key;

			enc = Ceasar.encrypt("Haz-em", 3);
			dec = Ceasar.decrypt(enc, 3);
			
			enc = Playfair.encrypt("Hazem", "playfairexample");
			dec = Playfair.decrypt(enc, "playfairexample");

			key = Vigenere.formulateKey("Haz-em", "bla", VigenereType.AUTO_KEY);
			enc = Vigenere.encrypt("Haz-em", key);
			dec = Vigenere.decrypt(enc, key);

			enc = RC4.encrypt("Hazem", "ehm");
			dec = RC4.decrypt(enc, "ehm");
		}
	}
}

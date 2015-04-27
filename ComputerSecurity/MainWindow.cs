using System;
using System.Windows.Forms;

namespace ComputerSecurity
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();

			string enc, dec, key, result;

			enc = Ceasar.encrypt("Haz-em", 3);
			dec = Ceasar.decrypt(enc, 3);
			
			enc = Playfair.encrypt("Hazem", "playfairexample");
			dec = Playfair.decrypt(enc, "playfairexample");

			key = Vigenere.formulateKey("Haz-em", "bla", VigenereType.AUTO_KEY);
			enc = Vigenere.encrypt("Haz-em", key);
			dec = Vigenere.decrypt(enc, key);

			enc = RC4.encrypt("Hazem", "ehm");
			dec = RC4.decrypt(enc, "ehm");

			result = MD5.getHash("Hazem AbuMostafa").ToLower();
		}

		private void btnEncrypt_Click(object sender, EventArgs e)
		{
			string plaintext = txtPlaintext.Text,
				   key = txtKey.Text;
			int intKey = 0;

			/* CATCHING ERRORS */
			if(rdioCeasar.Checked)
				try{
					intKey = int.Parse(key);
				} catch{
					MessageBox.Show(this, "Key must be integer in Ceasar.", "Wrong key",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			else if (rdioPlayfair.Checked){
				//TODO: Check for out-of-alphabet characters in key.
			}

			if(plaintext.Length == 0)
				return;
			//TODO: Check when (key.Length == 0) for algorithms that require that.

			/* ENCRYTING */
			if(rdioCeasar.Checked)
				txtCiphertext.Text = Ceasar.encrypt(plaintext, intKey);
			else if(rdioPlayfair.Checked)
				txtCiphertext.Text = Playfair.encrypt(plaintext, key);
			else if(rdioVigenereRe.Checked){
				txtKey.Text = Vigenere.formulateKey(plaintext, key, VigenereType.REPEATING_KEY);
				txtCiphertext.Text = Vigenere.encrypt(plaintext, txtKey.Text);
			}
			else if(rdioVigenereAuto.Checked){
				txtKey.Text = Vigenere.formulateKey(plaintext, key, VigenereType.AUTO_KEY);
				txtCiphertext.Text = Vigenere.encrypt(plaintext, txtKey.Text);
			}
			else if(rdioRC4.Checked)
				txtCiphertext.Text = RC4.encrypt(plaintext, key);
			else if(rdioMD5.Checked)
				txtCiphertext.Text = MD5.getHash(plaintext).ToLower();
		}
	}
}

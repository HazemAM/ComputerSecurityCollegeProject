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

			/* CATCHING ERRORS */
			if(!everythingIsFine())
				return;

			if(plaintext.Length == 0)
				return;

			/* ENCRYPTING */
			if(rdioCeasar.Checked)
				txtCiphertext.Text = Ceasar.encrypt(plaintext, int.Parse(key));
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

		private void btnDecrypt_Click(object sender, EventArgs e)
		{
			string ciphertext = txtCiphertext.Text,
				   key = txtKey.Text;

			/* CATCHING ERRORS */
			if(!everythingIsFine())
				return;

			if(ciphertext.Length == 0)
				return;

			/* DECRYPTING */
			if(rdioCeasar.Checked)
				txtPlaintext.Text = Ceasar.decrypt(ciphertext, int.Parse(key));
			else if(rdioPlayfair.Checked)
				txtPlaintext.Text = Playfair.decrypt(ciphertext, key);
			else if(rdioVigenereRe.Checked){
				txtKey.Text = Vigenere.formulateKey(ciphertext, key, VigenereType.REPEATING_KEY);
				txtPlaintext.Text = Vigenere.decrypt(ciphertext, txtKey.Text);
			}
			else if(rdioVigenereAuto.Checked){
				txtKey.Text = Vigenere.formulateKey(ciphertext, key, VigenereType.AUTO_KEY);
				txtPlaintext.Text = Vigenere.decrypt(ciphertext, txtKey.Text);
			}
			else if(rdioRC4.Checked)
				txtPlaintext.Text = RC4.decrypt(ciphertext, key);
		}

		private bool everythingIsFine()
		{
			if(rdioCeasar.Checked)
				try{
					int.Parse(txtKey.Text);
				} catch{
					MessageBox.Show(this, "Key must be integer in Ceasar.", "Wrong key",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			else if(rdioPlayfair.Checked){
				//TODO: Check for out-of-alphabet characters in key.
			}
			//TODO: Check when (key.Length == 0) for algorithms that require that.

			return true;
		}
	}
}

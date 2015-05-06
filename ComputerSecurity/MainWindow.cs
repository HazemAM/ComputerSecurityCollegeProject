using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ComputerSecurity
{
	public partial class MainWindow : Form
	{
        Socket client;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void test()
		{
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

		private void startServer()
		{
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 1100);
            
            serverSocket.Bind(endpoint);
            serverSocket.Listen(1);

            client = serverSocket.Accept();

            lblServerStatus.Text = "Client connected.";
            btnServerStart.Enabled = false;
            btnSend.Enabled = true;
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

            //Second part:
            else if(rdioMonoalphabetic.Checked)
                txtCiphertext.Text = new MonoAlpha(plaintext, key).Encrypt();
            else if(rdioHill.Checked)
                txtCiphertext.Text = new HillCipher(plaintext, key).Encrypt();
            else if(rdioRailFence.Checked)
                txtCiphertext.Text = new RailFence(plaintext, int.Parse(key)).Encrypt();
            else if(rdioColumnar.Checked)
                txtCiphertext.Text = new Colum(plaintext, getIntArray(key)).Encrypt();

            //Third part:
            else if(rdioDES.Checked)
                txtCiphertext.Text = new Des(removeDashes(key), removeDashes(plaintext), 1).Encode();
            else if(rdioTripleDES.Checked)
                txtCiphertext.Text = new TripleDes(removeDashes(plaintext), removeDashes(key.Split(' ')), 1).encrypt();
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

            //Second part:
            else if(rdioMonoalphabetic.Checked)
                txtPlaintext.Text = new MonoAlpha(ciphertext, key).Decrypt();
            else if(rdioHill.Checked)
                try { txtPlaintext.Text = new HillCipher(ciphertext, key).Decrypt(); }
                catch(Exception){ showMessage("Bad key", "Can't find an inverse for the determinant of the key."
                    + "\nPlease decrypt with another key."); }
            else if(rdioRailFence.Checked)
                txtPlaintext.Text = new RailFence(ciphertext, int.Parse(key)).Decrypt();
            else if(rdioColumnar.Checked)
                txtPlaintext.Text = new Colum(ciphertext, getIntArray(key)).Decrypt();

            //Third part:
            else if(rdioDES.Checked)
                txtPlaintext.Text = new Des(removeDashes(key), removeDashes(ciphertext), 1).decode();
            else if(rdioTripleDES.Checked)
                txtPlaintext.Text = new TripleDes(removeDashes(ciphertext), removeDashes(key.Split(' ')), 1).decrypt();
		}

		private bool everythingIsFine()
		{
			if(rdioCeasar.Checked)
				try{
					int.Parse(txtKey.Text);
				} catch{
                    showMessage("Wrong key", "Key must be integer in Ceasar.");
					return false;
				}
			else if(rdioPlayfair.Checked){
				//TODO: Check for out-of-alphabet characters in key.
			}
            else if(rdioMonoalphabetic.Checked && txtKey.Text.Length != 26){
                showMessage("Wrong key", "Key must be of exact 26 characters in Monoalphabetic.");
                return false;
            }
            else if(rdioHill.Checked && txtKey.Text.Length != 4){
                showMessage("Wrong key", "Key must be of exact 4 characters (2x2) in Hill.");
                return false;
            }
            else if(rdioRailFence.Checked)
                try{
					int.Parse(txtKey.Text);
				} catch{
                    showMessage("Wrong key", "Key must be an integer in Rail Fence.");
					return false;
				}
            else if(rdioColumnar.Checked)
                try{
                    getIntArray(txtKey.Text);
				} catch{
                    showMessage("Wrong key", "Key must be an array of integers, separated by spaces in Columnar.");
					return false;
				}
            else if(rdioDES.Checked){
                try{
                    Des.HexToByteArray(removeDashes(txtKey.Text));
				} catch{
                    showMessage("Wrong key", "Key must be a valid hex value in DES.");
					return false;
				}
                try{
                    Des.HexToByteArray(removeDashes(txtPlaintext.Text));
				} catch{
                    showMessage("Wrong key", "Plaintext must be a valid hex value in DES.");
					return false;
				}
                if(removeDashes(txtKey.Text).Length != 16){
                    showMessage("Wrong key", "Key must be a hex of exact 16 digit in DES.");
                    return false;
                }
            }
            else if(rdioTripleDES.Checked){
                string[] keys = txtKey.Text.Split(' ');

                if(keys.Length != 3){
                    showMessage("Wrong key", "Key must consist of 3 hex keys separated by spaces in Triple-DES.");
                    return false;
                }
                try{
                    foreach(string key in keys)
                        Des.HexToByteArray(removeDashes(key));
				} catch{
                    showMessage("Wrong key", "Each key must be a valid hex value in DES.");
					return false;
				}
                try{
                    Des.HexToByteArray(removeDashes(txtPlaintext.Text));
				} catch{
                    showMessage("Wrong key", "Plaintext must be a valid hex value in DES.");
					return false;
				}
                foreach(string key in keys)
                    if(removeDashes(key).Length != 16){
                        showMessage("Wrong key", "Each key must be a hex of exact 16 digit in DES.");
                        return false;
                    }
            }
			//TODO: Check when (key.Length == 0) for algorithms that require that.

			return true;
		}

        private string removeDashes(string text)
        {
            return text.Replace("-", "");
        }

        private string[] removeDashes(string[] text)
        {
            return Array.ConvertAll(text, removeDashes);
        }

        private int[] getIntArray(string text)
        {
            return Array.ConvertAll(text.Split(new char[]{' ', ','}), int.Parse);
        }

        private void showMessage(string title, string text){
            MessageBox.Show(this, text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		private void btnServerStart_Click(object sender, EventArgs e)
		{
            startServer();
		}

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.Send(Encoding.UTF8.GetBytes(txtCiphertext.Text));
        }
	}
}

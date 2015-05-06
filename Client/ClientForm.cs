using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ComputerSecurity
{
    public partial class ClientForm : Form
    {
        Socket clientSocket;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void startClient()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1132);
            
            try{
                clientSocket.Connect(endpoint);

                lblClientStatus.Text = "Connected to server.";
                btnListen.Enabled = false;
                btnReceive.Enabled = true;
            } catch {
                MessageBox.Show(this, "No servers found.", "No server", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                txtCiphertext.Text = new Colum(plaintext, Helpers.getIntArray(key)).Encrypt();

            //Third part:
            else if(rdioDES.Checked)
                txtCiphertext.Text = new Des(Helpers.removeDashes(key), Helpers.removeDashes(plaintext), 1).Encode();
            else if(rdioTripleDES.Checked)
                txtCiphertext.Text = new TripleDes(Helpers.removeDashes(plaintext), Helpers.removeDashes(key.Split(' ')), 1).encrypt();
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
                txtPlaintext.Text = new Colum(ciphertext, Helpers.getIntArray(key)).Decrypt();

            //Third part:
            else if(rdioDES.Checked)
                txtPlaintext.Text = new Des(Helpers.removeDashes(key), Helpers.removeDashes(ciphertext), 1).decode();
            else if(rdioTripleDES.Checked)
                txtPlaintext.Text = new TripleDes(Helpers.removeDashes(ciphertext), Helpers.removeDashes(key.Split(' ')), 1).decrypt();
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
                    Helpers.getIntArray(txtKey.Text);
				} catch{
                    showMessage("Wrong key", "Key must be an array of integers, separated by spaces in Columnar.");
					return false;
				}
            else if(rdioDES.Checked){
                try{
                    Des.HexToByteArray(Helpers.removeDashes(txtKey.Text));
				} catch{
                    showMessage("Wrong key", "Key must be a valid hex value in DES.");
					return false;
				}
                try{
                    Des.HexToByteArray(Helpers.removeDashes(txtPlaintext.Text));
				} catch{
                    showMessage("Wrong key", "Plaintext must be a valid hex value in DES.");
					return false;
				}
                if(Helpers.removeDashes(txtKey.Text).Length != 16){
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
                        Des.HexToByteArray(Helpers.removeDashes(key));
				} catch{
                    showMessage("Wrong key", "Each key must be a valid hex value in DES.");
					return false;
				}
                try{
                    Des.HexToByteArray(Helpers.removeDashes(txtPlaintext.Text));
				} catch{
                    showMessage("Wrong key", "Plaintext must be a valid hex value in DES.");
					return false;
				}
                foreach(string key in keys)
                    if(Helpers.removeDashes(key).Length != 16){
                        showMessage("Wrong key", "Each key must be a hex of exact 16 digit in DES.");
                        return false;
                    }
            }
			//TODO: Check when (key.Length == 0) for algorithms that require that.

			return true;
		}

        private void showMessage(string title, string text){
            MessageBox.Show(this, text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            startClient();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[2048];
            int length = clientSocket.Receive(data);
            String receivedString = Encoding.UTF8.GetString(data, 0, length);
            txtCiphertext.Text = receivedString;
        }
    }
}

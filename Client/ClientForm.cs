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
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1100);
            
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

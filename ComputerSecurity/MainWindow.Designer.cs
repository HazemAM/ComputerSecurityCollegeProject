namespace ComputerSecurity
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.rdioCeasar = new System.Windows.Forms.RadioButton();
            this.rdioPlayfair = new System.Windows.Forms.RadioButton();
            this.rdioVigenereRe = new System.Windows.Forms.RadioButton();
            this.rdioVigenereAuto = new System.Windows.Forms.RadioButton();
            this.rdioRC4 = new System.Windows.Forms.RadioButton();
            this.rdioMD5 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPlaintext = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtCiphertext = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnServerStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdioCeasar
            // 
            this.rdioCeasar.AutoSize = true;
            this.rdioCeasar.Checked = true;
            this.rdioCeasar.Location = new System.Drawing.Point(10, 23);
            this.rdioCeasar.Name = "rdioCeasar";
            this.rdioCeasar.Size = new System.Drawing.Size(58, 17);
            this.rdioCeasar.TabIndex = 0;
            this.rdioCeasar.TabStop = true;
            this.rdioCeasar.Text = "Ceasar";
            this.rdioCeasar.UseVisualStyleBackColor = true;
            // 
            // rdioPlayfair
            // 
            this.rdioPlayfair.AutoSize = true;
            this.rdioPlayfair.Location = new System.Drawing.Point(98, 23);
            this.rdioPlayfair.Name = "rdioPlayfair";
            this.rdioPlayfair.Size = new System.Drawing.Size(59, 17);
            this.rdioPlayfair.TabIndex = 1;
            this.rdioPlayfair.Text = "Playfair";
            this.rdioPlayfair.UseVisualStyleBackColor = true;
            // 
            // rdioVigenereRe
            // 
            this.rdioVigenereRe.AutoSize = true;
            this.rdioVigenereRe.Location = new System.Drawing.Point(187, 23);
            this.rdioVigenereRe.Name = "rdioVigenereRe";
            this.rdioVigenereRe.Size = new System.Drawing.Size(108, 17);
            this.rdioVigenereRe.TabIndex = 2;
            this.rdioVigenereRe.Text = "Vigenere: Repeat";
            this.rdioVigenereRe.UseVisualStyleBackColor = true;
            // 
            // rdioVigenereAuto
            // 
            this.rdioVigenereAuto.AutoSize = true;
            this.rdioVigenereAuto.Location = new System.Drawing.Point(325, 23);
            this.rdioVigenereAuto.Name = "rdioVigenereAuto";
            this.rdioVigenereAuto.Size = new System.Drawing.Size(95, 17);
            this.rdioVigenereAuto.TabIndex = 3;
            this.rdioVigenereAuto.Text = "Vigenere: Auto";
            this.rdioVigenereAuto.UseVisualStyleBackColor = true;
            // 
            // rdioRC4
            // 
            this.rdioRC4.AutoSize = true;
            this.rdioRC4.Location = new System.Drawing.Point(10, 46);
            this.rdioRC4.Name = "rdioRC4";
            this.rdioRC4.Size = new System.Drawing.Size(46, 17);
            this.rdioRC4.TabIndex = 4;
            this.rdioRC4.Text = "RC4";
            this.rdioRC4.UseVisualStyleBackColor = true;
            // 
            // rdioMD5
            // 
            this.rdioMD5.AutoSize = true;
            this.rdioMD5.Location = new System.Drawing.Point(98, 46);
            this.rdioMD5.Name = "rdioMD5";
            this.rdioMD5.Size = new System.Drawing.Size(48, 17);
            this.rdioMD5.TabIndex = 5;
            this.rdioMD5.Text = "MD5";
            this.rdioMD5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdioMD5);
            this.groupBox1.Controls.Add(this.rdioRC4);
            this.groupBox1.Controls.Add(this.rdioCeasar);
            this.groupBox1.Controls.Add(this.rdioVigenereRe);
            this.groupBox1.Controls.Add(this.rdioVigenereAuto);
            this.groupBox1.Controls.Add(this.rdioPlayfair);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 76);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encryption Algorithm";
            // 
            // txtPlaintext
            // 
            this.txtPlaintext.Location = new System.Drawing.Point(18, 129);
            this.txtPlaintext.Multiline = true;
            this.txtPlaintext.Name = "txtPlaintext";
            this.txtPlaintext.Size = new System.Drawing.Size(171, 46);
            this.txtPlaintext.TabIndex = 8;
            this.toolTip.SetToolTip(this.txtPlaintext, "Plaintext");
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(144, 106);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(171, 20);
            this.txtKey.TabIndex = 9;
            this.toolTip.SetToolTip(this.txtKey, "Key");
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(191, 128);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 25);
            this.btnEncrypt.TabIndex = 10;
            this.btnEncrypt.Text = "Encrypt »";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtCiphertext
            // 
            this.txtCiphertext.Location = new System.Drawing.Point(268, 129);
            this.txtCiphertext.Multiline = true;
            this.txtCiphertext.Name = "txtCiphertext";
            this.txtCiphertext.Size = new System.Drawing.Size(171, 46);
            this.txtCiphertext.TabIndex = 11;
            this.toolTip.SetToolTip(this.txtCiphertext, "Ciphertext");
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(191, 152);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 24);
            this.btnDecrypt.TabIndex = 12;
            this.btnDecrypt.Text = "« Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnServerStart
            // 
            this.btnServerStart.Location = new System.Drawing.Point(180, 211);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(98, 31);
            this.btnServerStart.TabIndex = 13;
            this.btnServerStart.Text = "Start server";
            this.btnServerStart.UseVisualStyleBackColor = true;
            this.btnServerStart.Click += new System.EventHandler(this.btnServerStart_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(55, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 2);
            this.label1.TabIndex = 20;
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Location = new System.Drawing.Point(178, 271);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(100, 13);
            this.lblServerStatus.TabIndex = 21;
            this.lblServerStatus.Text = "--";
            this.lblServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(180, 241);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 21);
            this.btnSend.TabIndex = 22;
            this.btnSend.Text = "Send ciphertext";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 293);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnServerStart);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.txtCiphertext);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtPlaintext);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWindow";
            this.Text = "Server";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rdioCeasar;
		private System.Windows.Forms.RadioButton rdioPlayfair;
		private System.Windows.Forms.RadioButton rdioVigenereRe;
		private System.Windows.Forms.RadioButton rdioVigenereAuto;
		private System.Windows.Forms.RadioButton rdioRC4;
		private System.Windows.Forms.RadioButton rdioMD5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtPlaintext;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.Button btnEncrypt;
		private System.Windows.Forms.TextBox txtCiphertext;
		private System.Windows.Forms.Button btnDecrypt;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button btnServerStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Button btnSend;
	}
}


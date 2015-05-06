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
            this.rdioHill = new System.Windows.Forms.RadioButton();
            this.rdioColumnar = new System.Windows.Forms.RadioButton();
            this.rdioRailFence = new System.Windows.Forms.RadioButton();
            this.rdioMonoalphabetic = new System.Windows.Forms.RadioButton();
            this.rdioDES = new System.Windows.Forms.RadioButton();
            this.rdioTripleDES = new System.Windows.Forms.RadioButton();
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
            this.rdioPlayfair.Location = new System.Drawing.Point(130, 23);
            this.rdioPlayfair.Name = "rdioPlayfair";
            this.rdioPlayfair.Size = new System.Drawing.Size(59, 17);
            this.rdioPlayfair.TabIndex = 1;
            this.rdioPlayfair.Text = "Playfair";
            this.rdioPlayfair.UseVisualStyleBackColor = true;
            // 
            // rdioVigenereRe
            // 
            this.rdioVigenereRe.AutoSize = true;
            this.rdioVigenereRe.Location = new System.Drawing.Point(226, 23);
            this.rdioVigenereRe.Name = "rdioVigenereRe";
            this.rdioVigenereRe.Size = new System.Drawing.Size(108, 17);
            this.rdioVigenereRe.TabIndex = 2;
            this.rdioVigenereRe.Text = "Vigenere: Repeat";
            this.rdioVigenereRe.UseVisualStyleBackColor = true;
            // 
            // rdioVigenereAuto
            // 
            this.rdioVigenereAuto.AutoSize = true;
            this.rdioVigenereAuto.Location = new System.Drawing.Point(362, 23);
            this.rdioVigenereAuto.Name = "rdioVigenereAuto";
            this.rdioVigenereAuto.Size = new System.Drawing.Size(95, 17);
            this.rdioVigenereAuto.TabIndex = 3;
            this.rdioVigenereAuto.Text = "Vigenere: Auto";
            this.rdioVigenereAuto.UseVisualStyleBackColor = true;
            // 
            // rdioRC4
            // 
            this.rdioRC4.AutoSize = true;
            this.rdioRC4.Location = new System.Drawing.Point(10, 92);
            this.rdioRC4.Name = "rdioRC4";
            this.rdioRC4.Size = new System.Drawing.Size(46, 17);
            this.rdioRC4.TabIndex = 4;
            this.rdioRC4.Text = "RC4";
            this.rdioRC4.UseVisualStyleBackColor = true;
            // 
            // rdioMD5
            // 
            this.rdioMD5.AutoSize = true;
            this.rdioMD5.Location = new System.Drawing.Point(130, 92);
            this.rdioMD5.Name = "rdioMD5";
            this.rdioMD5.Size = new System.Drawing.Size(48, 17);
            this.rdioMD5.TabIndex = 5;
            this.rdioMD5.Text = "MD5";
            this.rdioMD5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdioTripleDES);
            this.groupBox1.Controls.Add(this.rdioDES);
            this.groupBox1.Controls.Add(this.rdioMonoalphabetic);
            this.groupBox1.Controls.Add(this.rdioMD5);
            this.groupBox1.Controls.Add(this.rdioRC4);
            this.groupBox1.Controls.Add(this.rdioCeasar);
            this.groupBox1.Controls.Add(this.rdioRailFence);
            this.groupBox1.Controls.Add(this.rdioColumnar);
            this.groupBox1.Controls.Add(this.rdioVigenereRe);
            this.groupBox1.Controls.Add(this.rdioHill);
            this.groupBox1.Controls.Add(this.rdioVigenereAuto);
            this.groupBox1.Controls.Add(this.rdioPlayfair);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 124);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithm";
            // 
            // txtPlaintext
            // 
            this.txtPlaintext.Location = new System.Drawing.Point(18, 178);
            this.txtPlaintext.Multiline = true;
            this.txtPlaintext.Name = "txtPlaintext";
            this.txtPlaintext.Size = new System.Drawing.Size(171, 46);
            this.txtPlaintext.TabIndex = 8;
            this.toolTip.SetToolTip(this.txtPlaintext, "Plaintext");
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(144, 155);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(171, 20);
            this.txtKey.TabIndex = 9;
            this.toolTip.SetToolTip(this.txtKey, "Key");
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(191, 177);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 25);
            this.btnEncrypt.TabIndex = 10;
            this.btnEncrypt.Text = "Encrypt »";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtCiphertext
            // 
            this.txtCiphertext.Location = new System.Drawing.Point(268, 178);
            this.txtCiphertext.Multiline = true;
            this.txtCiphertext.Name = "txtCiphertext";
            this.txtCiphertext.Size = new System.Drawing.Size(171, 46);
            this.txtCiphertext.TabIndex = 11;
            this.toolTip.SetToolTip(this.txtCiphertext, "Ciphertext");
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(191, 201);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 24);
            this.btnDecrypt.TabIndex = 12;
            this.btnDecrypt.Text = "« Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnServerStart
            // 
            this.btnServerStart.Location = new System.Drawing.Point(180, 260);
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
            this.label1.Location = new System.Drawing.Point(55, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 2);
            this.label1.TabIndex = 20;
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Location = new System.Drawing.Point(178, 320);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(100, 13);
            this.lblServerStatus.TabIndex = 21;
            this.lblServerStatus.Text = "--";
            this.lblServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(180, 290);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 24);
            this.btnSend.TabIndex = 22;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rdioHill
            // 
            this.rdioHill.AutoSize = true;
            this.rdioHill.Location = new System.Drawing.Point(130, 46);
            this.rdioHill.Name = "rdioHill";
            this.rdioHill.Size = new System.Drawing.Size(72, 17);
            this.rdioHill.TabIndex = 1;
            this.rdioHill.Text = "Hill Cipher";
            this.rdioHill.UseVisualStyleBackColor = true;
            // 
            // rdioColumnar
            // 
            this.rdioColumnar.AutoSize = true;
            this.rdioColumnar.Location = new System.Drawing.Point(362, 46);
            this.rdioColumnar.Name = "rdioColumnar";
            this.rdioColumnar.Size = new System.Drawing.Size(69, 17);
            this.rdioColumnar.TabIndex = 3;
            this.rdioColumnar.Text = "Columnar";
            this.rdioColumnar.UseVisualStyleBackColor = true;
            // 
            // rdioRailFence
            // 
            this.rdioRailFence.AutoSize = true;
            this.rdioRailFence.Location = new System.Drawing.Point(226, 46);
            this.rdioRailFence.Name = "rdioRailFence";
            this.rdioRailFence.Size = new System.Drawing.Size(73, 17);
            this.rdioRailFence.TabIndex = 2;
            this.rdioRailFence.Text = "Rail fence";
            this.rdioRailFence.UseVisualStyleBackColor = true;
            // 
            // rdioMonoalphabetic
            // 
            this.rdioMonoalphabetic.AutoSize = true;
            this.rdioMonoalphabetic.Location = new System.Drawing.Point(10, 46);
            this.rdioMonoalphabetic.Name = "rdioMonoalphabetic";
            this.rdioMonoalphabetic.Size = new System.Drawing.Size(101, 17);
            this.rdioMonoalphabetic.TabIndex = 6;
            this.rdioMonoalphabetic.Text = "Monoalphabetic";
            this.rdioMonoalphabetic.UseVisualStyleBackColor = true;
            // 
            // rdioDES
            // 
            this.rdioDES.AutoSize = true;
            this.rdioDES.Location = new System.Drawing.Point(10, 69);
            this.rdioDES.Name = "rdioDES";
            this.rdioDES.Size = new System.Drawing.Size(47, 17);
            this.rdioDES.TabIndex = 7;
            this.rdioDES.Text = "DES";
            this.rdioDES.UseVisualStyleBackColor = true;
            // 
            // rdioTripleDES
            // 
            this.rdioTripleDES.AutoSize = true;
            this.rdioTripleDES.Location = new System.Drawing.Point(130, 69);
            this.rdioTripleDES.Name = "rdioTripleDES";
            this.rdioTripleDES.Size = new System.Drawing.Size(76, 17);
            this.rdioTripleDES.TabIndex = 8;
            this.rdioTripleDES.Text = "Triple-DES";
            this.rdioTripleDES.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 350);
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
        private System.Windows.Forms.RadioButton rdioTripleDES;
        private System.Windows.Forms.RadioButton rdioDES;
        private System.Windows.Forms.RadioButton rdioMonoalphabetic;
        private System.Windows.Forms.RadioButton rdioRailFence;
        private System.Windows.Forms.RadioButton rdioColumnar;
        private System.Windows.Forms.RadioButton rdioHill;
	}
}


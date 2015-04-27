namespace ComputerSecurity
{
    partial class ClientForm
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
            this.btnListen = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtCiphertext = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtPlaintext = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdioMD5 = new System.Windows.Forms.RadioButton();
            this.rdioRC4 = new System.Windows.Forms.RadioButton();
            this.rdioCeasar = new System.Windows.Forms.RadioButton();
            this.rdioVigenereRe = new System.Windows.Forms.RadioButton();
            this.rdioVigenereAuto = new System.Windows.Forms.RadioButton();
            this.rdioPlayfair = new System.Windows.Forms.RadioButton();
            this.lblClientStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(176, 213);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(101, 32);
            this.btnListen.TabIndex = 0;
            this.btnListen.Text = "Connect to server";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Enabled = false;
            this.btnReceive.Location = new System.Drawing.Point(176, 245);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(101, 23);
            this.btnReceive.TabIndex = 0;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(53, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 2);
            this.label1.TabIndex = 27;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(189, 150);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 24);
            this.btnDecrypt.TabIndex = 26;
            this.btnDecrypt.Text = "« Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtCiphertext
            // 
            this.txtCiphertext.Location = new System.Drawing.Point(266, 127);
            this.txtCiphertext.Multiline = true;
            this.txtCiphertext.Name = "txtCiphertext";
            this.txtCiphertext.Size = new System.Drawing.Size(171, 46);
            this.txtCiphertext.TabIndex = 25;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(189, 126);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 25);
            this.btnEncrypt.TabIndex = 24;
            this.btnEncrypt.Text = "Encrypt »";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(142, 104);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(171, 20);
            this.txtKey.TabIndex = 23;
            // 
            // txtPlaintext
            // 
            this.txtPlaintext.Location = new System.Drawing.Point(16, 127);
            this.txtPlaintext.Multiline = true;
            this.txtPlaintext.Name = "txtPlaintext";
            this.txtPlaintext.Size = new System.Drawing.Size(171, 46);
            this.txtPlaintext.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdioMD5);
            this.groupBox1.Controls.Add(this.rdioRC4);
            this.groupBox1.Controls.Add(this.rdioCeasar);
            this.groupBox1.Controls.Add(this.rdioVigenereRe);
            this.groupBox1.Controls.Add(this.rdioVigenereAuto);
            this.groupBox1.Controls.Add(this.rdioPlayfair);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 76);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encryption Algorithm";
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
            // lblClientStatus
            // 
            this.lblClientStatus.Location = new System.Drawing.Point(154, 273);
            this.lblClientStatus.Name = "lblClientStatus";
            this.lblClientStatus.Size = new System.Drawing.Size(147, 13);
            this.lblClientStatus.TabIndex = 28;
            this.lblClientStatus.Text = "--";
            this.lblClientStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 299);
            this.Controls.Add(this.lblClientStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.txtCiphertext);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtPlaintext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.btnListen);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtCiphertext;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtPlaintext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdioMD5;
        private System.Windows.Forms.RadioButton rdioRC4;
        private System.Windows.Forms.RadioButton rdioCeasar;
        private System.Windows.Forms.RadioButton rdioVigenereRe;
        private System.Windows.Forms.RadioButton rdioVigenereAuto;
        private System.Windows.Forms.RadioButton rdioPlayfair;
        private System.Windows.Forms.Label lblClientStatus;
    }
}
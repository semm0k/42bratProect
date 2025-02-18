namespace _42
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F);
            this.label1.Location = new System.Drawing.Point(211, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Email
            // 
            this.Email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Email.Location = new System.Drawing.Point(92, 141);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(60, 25);
            this.Email.TabIndex = 1;
            this.Email.Text = "Email";
            this.Email.Click += new System.EventHandler(this.label2_Click);
            // 
            // Password
            // 
            this.Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Password.Location = new System.Drawing.Point(72, 230);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(80, 25);
            this.Password.TabIndex = 2;
            this.Password.Text = "Пароль";
            this.Password.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtEmail.Location = new System.Drawing.Point(189, 136);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(197, 30);
            this.txtEmail.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtPassword.Location = new System.Drawing.Point(189, 230);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(197, 30);
            this.txtPassword.TabIndex = 4;
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegister.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnRegister.Location = new System.Drawing.Point(189, 308);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(197, 35);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Зарегистрировать ";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblMessage.Location = new System.Drawing.Point(12, 387);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(23, 25);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "_";
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Location = new System.Drawing.Point(676, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 49);
            this.button1.TabIndex = 7;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form3";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button button1;
    }
}
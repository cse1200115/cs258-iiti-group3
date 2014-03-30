namespace Registration
{
    partial class Login_frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_frm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_user = new System.Windows.Forms.TextBox();
            this.text_pass = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.login_pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.login_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // text_user
            // 
            this.text_user.Location = new System.Drawing.Point(340, 73);
            this.text_user.Name = "text_user";
            this.text_user.Size = new System.Drawing.Size(165, 20);
            this.text_user.TabIndex = 2;
            // 
            // text_pass
            // 
            this.text_pass.Location = new System.Drawing.Point(340, 121);
            this.text_pass.Name = "text_pass";
            this.text_pass.Size = new System.Drawing.Size(165, 20);
            this.text_pass.TabIndex = 3;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(363, 165);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(96, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Login";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // login_pic
            // 
            this.login_pic.Image = ((System.Drawing.Image)(resources.GetObject("login_pic.Image")));
            this.login_pic.ImageLocation = "";
            this.login_pic.InitialImage = null;
            this.login_pic.Location = new System.Drawing.Point(12, 27);
            this.login_pic.Name = "login_pic";
            this.login_pic.Size = new System.Drawing.Size(221, 196);
            this.login_pic.TabIndex = 6;
            this.login_pic.TabStop = false;
            // 
            // Login_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 271);
            this.Controls.Add(this.login_pic);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.text_pass);
            this.Controls.Add(this.text_user);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Login_frm";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.login_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_user;
        private System.Windows.Forms.TextBox text_pass;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.PictureBox login_pic;
    }
}


namespace AttendanceUI.Forms
{
    partial class Login1
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
            this.form1 = new XanderUI.XUIFormDesign();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.xuiSplashScreen1 = new XanderUI.XUISplashScreen();
            this.form1.WorkingArea.SuspendLayout();
            this.form1.SuspendLayout();
            this.SuspendLayout();
            // 
            // form1
            // 
            this.form1.BackColor = System.Drawing.Color.White;
            this.form1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form1.ExitApplication = true;
            this.form1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.form1.FormStyle = XanderUI.XUIFormDesign.Style.Material;
            this.form1.Location = new System.Drawing.Point(0, 0);
            this.form1.MaterialBackColor = System.Drawing.Color.DodgerBlue;
            this.form1.MaterialForeColor = System.Drawing.Color.White;
            this.form1.Name = "form1";
            this.form1.ShowMaximize = false;
            this.form1.ShowMinimize = false;
            this.form1.Size = new System.Drawing.Size(800, 450);
            this.form1.TabIndex = 0;
            this.form1.TitleText = "Login";
            // 
            // form1.WorkingArea
            // 
            this.form1.WorkingArea.BackColor = System.Drawing.Color.White;
            this.form1.WorkingArea.Controls.Add(this.btnLogin);
            this.form1.WorkingArea.Controls.Add(this.linkForgotPassword);
            this.form1.WorkingArea.Controls.Add(this.txtPassword);
            this.form1.WorkingArea.Controls.Add(this.label3);
            this.form1.WorkingArea.Controls.Add(this.txtUsername);
            this.form1.WorkingArea.Controls.Add(this.label2);
            this.form1.WorkingArea.Controls.Add(this.label1);
            this.form1.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form1.WorkingArea.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.form1.WorkingArea.Location = new System.Drawing.Point(0, 74);
            this.form1.WorkingArea.Name = "WorkingArea";
            this.form1.WorkingArea.Size = new System.Drawing.Size(800, 376);
            this.form1.WorkingArea.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(557, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(396, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(400, 126);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(356, 32);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(400, 210);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(356, 32);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(396, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // linkForgotPassword
            // 
            this.linkForgotPassword.AutoSize = true;
            this.linkForgotPassword.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkForgotPassword.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkForgotPassword.Location = new System.Drawing.Point(490, 255);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(170, 23);
            this.linkForgotPassword.TabIndex = 5;
            this.linkForgotPassword.TabStop = true;
            this.linkForgotPassword.Text = "Forgot Password?";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(400, 293);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(356, 40);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // xuiSplashScreen1
            // 
            this.xuiSplashScreen1.AllowDragging = true;
            this.xuiSplashScreen1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.xuiSplashScreen1.BottomText = "Loading";
            this.xuiSplashScreen1.BottomTextColor = System.Drawing.Color.White;
            this.xuiSplashScreen1.BottomTextSize = 16;
            this.xuiSplashScreen1.EllipseCornerRadius = 10;
            this.xuiSplashScreen1.IsEllipse = false;
            this.xuiSplashScreen1.LoadedColor = System.Drawing.Color.DodgerBlue;
            this.xuiSplashScreen1.ProgressBarStyle = XanderUI.XUIFlatProgressBar.Style.IOS;
            this.xuiSplashScreen1.SecondsDisplayed = 3000;
            this.xuiSplashScreen1.ShowProgressBar = true;
            this.xuiSplashScreen1.SplashSize = new System.Drawing.Size(450, 280);
            this.xuiSplashScreen1.TopText = "Biometric Attendance System";
            this.xuiSplashScreen1.TopTextColor = System.Drawing.Color.DodgerBlue;
            this.xuiSplashScreen1.TopTextSize = 36;
            this.xuiSplashScreen1.UnloadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.form1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            this.form1.WorkingArea.ResumeLayout(false);
            this.form1.WorkingArea.PerformLayout();
            this.form1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private XanderUI.XUIFormDesign form1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private XanderUI.XUISplashScreen xuiSplashScreen1;
    }
}
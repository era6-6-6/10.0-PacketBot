namespace FunnyProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainTabPage = new System.Windows.Forms.TabControl();
            this.LoginPage = new System.Windows.Forms.TabPage();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.ServerComboBox = new System.Windows.Forms.ComboBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.MainTabPage.SuspendLayout();
            this.LoginPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.LoginPage);
            this.MainTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabPage.Location = new System.Drawing.Point(0, 0);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.SelectedIndex = 0;
            this.MainTabPage.Size = new System.Drawing.Size(800, 450);
            this.MainTabPage.TabIndex = 0;
            // 
            // LoginPage
            // 
            this.LoginPage.Controls.Add(this.LoginBtn);
            this.LoginPage.Controls.Add(this.ServerComboBox);
            this.LoginPage.Controls.Add(this.PasswordBox);
            this.LoginPage.Controls.Add(this.UsernameBox);
            this.LoginPage.Location = new System.Drawing.Point(4, 24);
            this.LoginPage.Name = "LoginPage";
            this.LoginPage.Padding = new System.Windows.Forms.Padding(3);
            this.LoginPage.Size = new System.Drawing.Size(792, 422);
            this.LoginPage.TabIndex = 0;
            this.LoginPage.Text = "+";
            this.LoginPage.UseVisualStyleBackColor = true;
            this.LoginPage.Resize += new System.EventHandler(this.LoginPage_Resize);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginBtn.Location = new System.Drawing.Point(341, 274);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 3;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // ServerComboBox
            // 
            this.ServerComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ServerComboBox.FormattingEnabled = true;
            this.ServerComboBox.Items.AddRange(new object[] {
            "finalorbit",
            "starzone",
            "ancientorbit",
            "eternalorbit",
            "stargalaxy"});
            this.ServerComboBox.Location = new System.Drawing.Point(280, 245);
            this.ServerComboBox.Name = "ServerComboBox";
            this.ServerComboBox.Size = new System.Drawing.Size(210, 23);
            this.ServerComboBox.TabIndex = 2;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordBox.Location = new System.Drawing.Point(280, 204);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.PlaceholderText = "Password";
            this.PasswordBox.Size = new System.Drawing.Size(210, 23);
            this.PasswordBox.TabIndex = 1;
            // 
            // UsernameBox
            // 
            this.UsernameBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameBox.Location = new System.Drawing.Point(280, 175);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.PlaceholderText = "Username";
            this.UsernameBox.Size = new System.Drawing.Size(210, 23);
            this.UsernameBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainTabPage);
            this.Name = "Form1";
            this.Text = "With <3 from era";
            this.MainTabPage.ResumeLayout(false);
            this.LoginPage.ResumeLayout(false);
            this.LoginPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl MainTabPage;
        private TabPage LoginPage;
        private Button LoginBtn;
        private ComboBox ServerComboBox;
        private TextBox PasswordBox;
        private TextBox UsernameBox;
    }
}
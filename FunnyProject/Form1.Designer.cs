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
            this.LoginBtn = new System.Windows.Forms.Button();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.MinimapPanel = new System.Windows.Forms.Panel();
            this.StartBtn = new System.Windows.Forms.Button();
            this.ServerCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(653, 79);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 0;
            this.LoginBtn.Text = "Load";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(598, 41);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(190, 23);
            this.PasswordBox.TabIndex = 1;
            this.PasswordBox.Text = "Darkorbit123";
            // 
            // UserNameBox
            // 
            this.UserNameBox.Location = new System.Drawing.Point(598, 12);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(190, 23);
            this.UserNameBox.TabIndex = 2;
            this.UserNameBox.Text = "ProQ";
            // 
            // MinimapPanel
            // 
            this.MinimapPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MinimapPanel.Location = new System.Drawing.Point(2, 2);
            this.MinimapPanel.Name = "MinimapPanel";
            this.MinimapPanel.Size = new System.Drawing.Size(590, 447);
            this.MinimapPanel.TabIndex = 3;
            this.MinimapPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimapPanel_MouseDown);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(653, 118);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 4;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // ServerCombo
            // 
            this.ServerCombo.FormattingEnabled = true;
            this.ServerCombo.Items.AddRange(new object[] {
            "starzone",
            "oneultimate",
            "finalorbit",
            "ancientorbit"});
            this.ServerCombo.Location = new System.Drawing.Point(667, 415);
            this.ServerCombo.Name = "ServerCombo";
            this.ServerCombo.Size = new System.Drawing.Size(121, 23);
            this.ServerCombo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerCombo);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.MinimapPanel);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.LoginBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button LoginBtn;
        private TextBox PasswordBox;
        private TextBox UserNameBox;
        private Panel MinimapPanel;
        private Button StartBtn;
        private ComboBox ServerCombo;
        private Label label1;
    }
}
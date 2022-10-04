namespace FunnyProject.Forms
{
    partial class UserWindow
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MinimapPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InfoTab = new System.Windows.Forms.TabControl();
            this.ActionPage = new System.Windows.Forms.TabPage();
            this.StartBtn = new System.Windows.Forms.Button();
            this.StatPage = new System.Windows.Forms.TabPage();
            this.UriLbl = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.InfoTab.SuspendLayout();
            this.ActionPage.SuspendLayout();
            this.StatPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MinimapPanel);
            this.MainPanel.Controls.Add(this.panel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 450);
            this.MainPanel.TabIndex = 0;
            // 
            // MinimapPanel
            // 
            this.MinimapPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MinimapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MinimapPanel.Location = new System.Drawing.Point(0, 0);
            this.MinimapPanel.Name = "MinimapPanel";
            this.MinimapPanel.Size = new System.Drawing.Size(625, 450);
            this.MinimapPanel.TabIndex = 1;
            this.MinimapPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimapPanel_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InfoTab);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(625, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 450);
            this.panel1.TabIndex = 0;
            // 
            // InfoTab
            // 
            this.InfoTab.Controls.Add(this.ActionPage);
            this.InfoTab.Controls.Add(this.StatPage);
            this.InfoTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoTab.Location = new System.Drawing.Point(0, 0);
            this.InfoTab.Name = "InfoTab";
            this.InfoTab.SelectedIndex = 0;
            this.InfoTab.Size = new System.Drawing.Size(175, 450);
            this.InfoTab.TabIndex = 1;
            // 
            // ActionPage
            // 
            this.ActionPage.Controls.Add(this.StartBtn);
            this.ActionPage.Location = new System.Drawing.Point(4, 24);
            this.ActionPage.Name = "ActionPage";
            this.ActionPage.Padding = new System.Windows.Forms.Padding(3);
            this.ActionPage.Size = new System.Drawing.Size(167, 422);
            this.ActionPage.TabIndex = 0;
            this.ActionPage.Text = "Action";
            this.ActionPage.UseVisualStyleBackColor = true;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(38, 130);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(82, 26);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StatPage
            // 
            this.StatPage.Controls.Add(this.UriLbl);
            this.StatPage.Location = new System.Drawing.Point(4, 24);
            this.StatPage.Name = "StatPage";
            this.StatPage.Padding = new System.Windows.Forms.Padding(3);
            this.StatPage.Size = new System.Drawing.Size(167, 422);
            this.StatPage.TabIndex = 1;
            this.StatPage.Text = "Statistics";
            this.StatPage.UseVisualStyleBackColor = true;
            // 
            // UriLbl
            // 
            this.UriLbl.AutoSize = true;
            this.UriLbl.Location = new System.Drawing.Point(6, 27);
            this.UriLbl.Name = "UriLbl";
            this.UriLbl.Size = new System.Drawing.Size(25, 15);
            this.UriLbl.TabIndex = 0;
            this.UriLbl.Text = "Uri:";
            // 
            // UserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPanel);
            this.Name = "UserWindow";
            this.Text = "UserWindow";
            this.MainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.InfoTab.ResumeLayout(false);
            this.ActionPage.ResumeLayout(false);
            this.StatPage.ResumeLayout(false);
            this.StatPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel MainPanel;
        private Panel MinimapPanel;
        private Panel panel1;
        private TabControl InfoTab;
        private TabPage ActionPage;
        private Button StartBtn;
        private TabPage StatPage;
        private Label UriLbl;
    }
}
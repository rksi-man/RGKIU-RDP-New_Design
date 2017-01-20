namespace RDP
{
    partial class F_RDP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_RDP));
            this.cnct_rdp = new System.Windows.Forms.Button();
            this.user_text = new System.Windows.Forms.Label();
            this.top_GB = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Not_Pic = new System.Windows.Forms.PictureBox();
            this.top_GB.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Not_Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // cnct_rdp
            // 
            this.cnct_rdp.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.cnct_rdp, "cnct_rdp");
            this.cnct_rdp.Name = "cnct_rdp";
            this.cnct_rdp.TabStop = false;
            this.cnct_rdp.UseVisualStyleBackColor = false;
            this.cnct_rdp.Click += new System.EventHandler(this.cnct_rdp_Click);
            // 
            // user_text
            // 
            resources.ApplyResources(this.user_text, "user_text");
            this.user_text.Name = "user_text";
            // 
            // top_GB
            // 
            this.top_GB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.top_GB.Controls.Add(this.user_text);
            resources.ApplyResources(this.top_GB, "top_GB");
            this.top_GB.Name = "top_GB";
            this.top_GB.TabStop = false;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.SettingsToolStripMenuItem,
            this.FAQToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            resources.ApplyResources(this.SettingsToolStripMenuItem, "SettingsToolStripMenuItem");
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // FAQToolStripMenuItem
            // 
            this.FAQToolStripMenuItem.Name = "FAQToolStripMenuItem";
            resources.ApplyResources(this.FAQToolStripMenuItem, "FAQToolStripMenuItem");
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
            // 
            // Not_Pic
            // 
            this.Not_Pic.Image = global::RGKIU_VCH.Properties.Resources.logopnng;
            resources.ApplyResources(this.Not_Pic, "Not_Pic");
            this.Not_Pic.Name = "Not_Pic";
            this.Not_Pic.TabStop = false;
            this.Not_Pic.Click += new System.EventHandler(this.Not_Pic_Click);
            // 
            // F_RDP
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.cnct_rdp);
            this.Controls.Add(this.Not_Pic);
            this.Controls.Add(this.top_GB);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "F_RDP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing_F);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.top_GB.ResumeLayout(false);
            this.top_GB.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Not_Pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label user_text;
        private System.Windows.Forms.PictureBox Not_Pic;
        private System.Windows.Forms.GroupBox top_GB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FAQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.Button cnct_rdp;
    }
}


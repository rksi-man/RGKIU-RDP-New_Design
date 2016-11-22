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
            this.rdp = new AxMSTSCLib.AxMsTscAxNotSafeForScripting();
            this.cnct_rdp = new System.Windows.Forms.Button();
            this.ChkBox_F_S = new System.Windows.Forms.CheckBox();
            this.user_text = new System.Windows.Forms.Label();
            this.dcnct_rdp = new System.Windows.Forms.Button();
            this.F_S_O = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.LinkLabel();
            this.Not_Pic = new System.Windows.Forms.PictureBox();
            this.Not_TxT = new System.Windows.Forms.Label();
            this.Help = new System.Windows.Forms.LinkLabel();
            this.About = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Not_Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // rdp
            // 
            resources.ApplyResources(this.rdp, "rdp");
            this.rdp.Name = "rdp";
            this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
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
            // ChkBox_F_S
            // 
            resources.ApplyResources(this.ChkBox_F_S, "ChkBox_F_S");
            this.ChkBox_F_S.Checked = true;
            this.ChkBox_F_S.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBox_F_S.Name = "ChkBox_F_S";
            this.ChkBox_F_S.UseVisualStyleBackColor = true;
            // 
            // user_text
            // 
            resources.ApplyResources(this.user_text, "user_text");
            this.user_text.Name = "user_text";
            // 
            // dcnct_rdp
            // 
            this.dcnct_rdp.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dcnct_rdp, "dcnct_rdp");
            this.dcnct_rdp.Name = "dcnct_rdp";
            this.dcnct_rdp.UseVisualStyleBackColor = false;
            this.dcnct_rdp.Click += new System.EventHandler(this.dcnct_rdp_Click);
            // 
            // F_S_O
            // 
            this.F_S_O.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.F_S_O, "F_S_O");
            this.F_S_O.Name = "F_S_O";
            this.F_S_O.UseVisualStyleBackColor = false;
            this.F_S_O.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Settings
            // 
            resources.ApplyResources(this.Settings, "Settings");
            this.Settings.LinkColor = System.Drawing.Color.DarkBlue;
            this.Settings.Name = "Settings";
            this.Settings.TabStop = true;
            this.Settings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Settings_LinkClicked);
            // 
            // Not_Pic
            // 
            this.Not_Pic.Image = global::RGKIU_VCH.Properties.Resources.index;
            resources.ApplyResources(this.Not_Pic, "Not_Pic");
            this.Not_Pic.Name = "Not_Pic";
            this.Not_Pic.TabStop = false;
            // 
            // Not_TxT
            // 
            resources.ApplyResources(this.Not_TxT, "Not_TxT");
            this.Not_TxT.Name = "Not_TxT";
            // 
            // Help
            // 
            resources.ApplyResources(this.Help, "Help");
            this.Help.LinkColor = System.Drawing.Color.DarkBlue;
            this.Help.Name = "Help";
            this.Help.TabStop = true;
            // 
            // About
            // 
            resources.ApplyResources(this.About, "About");
            this.About.LinkColor = System.Drawing.Color.DarkBlue;
            this.About.Name = "About";
            this.About.TabStop = true;
            // 
            // F_RDP
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.About);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.F_S_O);
            this.Controls.Add(this.Not_TxT);
            this.Controls.Add(this.Not_Pic);
            this.Controls.Add(this.user_text);
            this.Controls.Add(this.ChkBox_F_S);
            this.Controls.Add(this.rdp);
            this.Controls.Add(this.cnct_rdp);
            this.Controls.Add(this.dcnct_rdp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "F_RDP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing_F);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Not_Pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxMSTSCLib.AxMsTscAxNotSafeForScripting rdp;
        private System.Windows.Forms.Button cnct_rdp;
        private System.Windows.Forms.CheckBox ChkBox_F_S;
        private System.Windows.Forms.Label user_text;
        private System.Windows.Forms.PictureBox Not_Pic;
        private System.Windows.Forms.Button dcnct_rdp;
        private System.Windows.Forms.Button F_S_O;
        private System.Windows.Forms.LinkLabel Settings;
        private System.Windows.Forms.Label Not_TxT;
        private System.Windows.Forms.LinkLabel Help;
        private System.Windows.Forms.LinkLabel About;
    }
}


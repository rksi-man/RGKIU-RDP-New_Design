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
            this.dcnct_rdp = new System.Windows.Forms.Button();
            this.ChkBox_F_S = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
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
            resources.ApplyResources(this.cnct_rdp, "cnct_rdp");
            this.cnct_rdp.Name = "cnct_rdp";
            this.cnct_rdp.TabStop = false;
            this.cnct_rdp.UseVisualStyleBackColor = true;
            this.cnct_rdp.Click += new System.EventHandler(this.cnct_rdp_Click);
            // 
            // dcnct_rdp
            // 
            resources.ApplyResources(this.dcnct_rdp, "dcnct_rdp");
            this.dcnct_rdp.Name = "dcnct_rdp";
            this.dcnct_rdp.UseVisualStyleBackColor = true;
            this.dcnct_rdp.Click += new System.EventHandler(this.dcnct_rdp_Click);
            // 
            // ChkBox_F_S
            // 
            resources.ApplyResources(this.ChkBox_F_S, "ChkBox_F_S");
            this.ChkBox_F_S.Name = "ChkBox_F_S";
            this.ChkBox_F_S.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // F_RDP
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChkBox_F_S);
            this.Controls.Add(this.dcnct_rdp);
            this.Controls.Add(this.rdp);
            this.Controls.Add(this.cnct_rdp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "F_RDP";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxMSTSCLib.AxMsTscAxNotSafeForScripting rdp;
        private System.Windows.Forms.Button cnct_rdp;
        private System.Windows.Forms.Button dcnct_rdp;
        private System.Windows.Forms.CheckBox ChkBox_F_S;
        private System.Windows.Forms.Label label1;
    }
}


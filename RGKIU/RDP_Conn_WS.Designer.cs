namespace RGKIU_VCH
{
    partial class RDP_Conn_WS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RDP_Conn_WS));
            this.rdp = new AxMSTSCLib.AxMsTscAxNotSafeForScripting();
            this.Login_text = new System.Windows.Forms.Label();
            this.Serv_text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
            this.SuspendLayout();
            // 
            // rdp
            // 
            this.rdp.Enabled = true;
            this.rdp.Location = new System.Drawing.Point(12, 13);
            this.rdp.Name = "rdp";
            this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
            this.rdp.Size = new System.Drawing.Size(192, 192);
            this.rdp.TabIndex = 1;
            this.rdp.Visible = false;
            this.rdp.OnLoginComplete += new System.EventHandler(this.rdp_OnLoginComplete);
            this.rdp.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(this.rdp_OnDisconnected);
            // 
            // Login_text
            // 
            this.Login_text.AutoSize = true;
            this.Login_text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Login_text.Location = new System.Drawing.Point(76, 99);
            this.Login_text.Name = "Login_text";
            this.Login_text.Size = new System.Drawing.Size(60, 13);
            this.Login_text.TabIndex = 106;
            this.Login_text.Text = "No_LOGIN";
            this.Login_text.Visible = false;
            // 
            // Serv_text
            // 
            this.Serv_text.AutoSize = true;
            this.Serv_text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Serv_text.Location = new System.Drawing.Point(76, 86);
            this.Serv_text.Name = "Serv_text";
            this.Serv_text.Size = new System.Drawing.Size(56, 13);
            this.Serv_text.TabIndex = 105;
            this.Serv_text.Text = "No_SERV";
            this.Serv_text.Visible = false;
            // 
            // RDP_Conn_WS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 217);
            this.Controls.Add(this.Login_text);
            this.Controls.Add(this.Serv_text);
            this.Controls.Add(this.rdp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RDP_Conn_WS";
            this.Text = "RDP_Conn_WS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RDP_Conn_WS_FormClosed);
            this.Load += new System.EventHandler(this.RDP_Conn_WS_Load);
            this.SizeChanged += new System.EventHandler(this.RDP_Conn_WS_SizeChanged121);
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxMSTSCLib.AxMsTscAxNotSafeForScripting rdp;
        private System.Windows.Forms.Label Login_text;
        private System.Windows.Forms.Label Serv_text;
    }
}
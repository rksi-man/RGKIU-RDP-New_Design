namespace RGKIU_VCH
{
    partial class RDP_Conn_All_IN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RDP_Conn_All_IN));
            this.Login_text = new System.Windows.Forms.Label();
            this.Serv_text = new System.Windows.Forms.Label();
            this.rdp = new AxMSTSCLib.AxMsTscAxNotSafeForScripting();
            this.close_btn = new System.Windows.Forms.Button();
            this.to_tray = new System.Windows.Forms.Button();
            this.re_size = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
            this.SuspendLayout();
            // 
            // Login_text
            // 
            this.Login_text.AutoSize = true;
            this.Login_text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Login_text.Location = new System.Drawing.Point(77, 99);
            this.Login_text.Name = "Login_text";
            this.Login_text.Size = new System.Drawing.Size(60, 13);
            this.Login_text.TabIndex = 109;
            this.Login_text.Text = "No_LOGIN";
            this.Login_text.Visible = false;
            // 
            // Serv_text
            // 
            this.Serv_text.AutoSize = true;
            this.Serv_text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Serv_text.Location = new System.Drawing.Point(77, 86);
            this.Serv_text.Name = "Serv_text";
            this.Serv_text.Size = new System.Drawing.Size(56, 13);
            this.Serv_text.TabIndex = 108;
            this.Serv_text.Text = "No_SERV";
            this.Serv_text.Visible = false;
            // 
            // rdp
            // 
            this.rdp.Enabled = true;
            this.rdp.Location = new System.Drawing.Point(12, 12);
            this.rdp.Name = "rdp";
            this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
            this.rdp.Size = new System.Drawing.Size(192, 192);
            this.rdp.TabIndex = 107;
            this.rdp.Visible = false;
            this.rdp.OnLoginComplete += new System.EventHandler(this.rdp_OnLoginComplete);
            this.rdp.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(this.rdp_OnDisconnected);
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(146, 11);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(80, 20);
            this.close_btn.TabIndex = 110;
            this.close_btn.Text = "Закрыть";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Visible = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click_1);
            // 
            // to_tray
            // 
            this.to_tray.Location = new System.Drawing.Point(4, 11);
            this.to_tray.Name = "to_tray";
            this.to_tray.Size = new System.Drawing.Size(80, 20);
            this.to_tray.TabIndex = 111;
            this.to_tray.Text = "Свернуть";
            this.to_tray.UseVisualStyleBackColor = true;
            this.to_tray.Visible = false;
            this.to_tray.Click += new System.EventHandler(this.to_tray_Click);
            // 
            // re_size
            // 
            this.re_size.Location = new System.Drawing.Point(75, 11);
            this.re_size.Name = "re_size";
            this.re_size.Size = new System.Drawing.Size(80, 20);
            this.re_size.TabIndex = 112;
            this.re_size.Text = "В окно";
            this.re_size.UseVisualStyleBackColor = true;
            this.re_size.Visible = false;
            this.re_size.Click += new System.EventHandler(this.re_size_Click);
            // 
            // RDP_Conn_All_IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 216);
            this.Controls.Add(this.re_size);
            this.Controls.Add(this.to_tray);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.Login_text);
            this.Controls.Add(this.Serv_text);
            this.Controls.Add(this.rdp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RDP_Conn_All_IN";
            this.Text = "RDP_Conn_All_IN";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RDP_Conn_All_IN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Login_text;
        private System.Windows.Forms.Label Serv_text;
        private AxMSTSCLib.AxMsTscAxNotSafeForScripting rdp;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Button to_tray;
        private System.Windows.Forms.Button re_size;
    }
}
namespace RGKIU_VCH
{
    partial class RDP_Conn_FS
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
            this.Login_text = new System.Windows.Forms.Label();
            this.Serv_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Login_text
            // 
            this.Login_text.AutoSize = true;
            this.Login_text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Login_text.Location = new System.Drawing.Point(12, 22);
            this.Login_text.Name = "Login_text";
            this.Login_text.Size = new System.Drawing.Size(60, 13);
            this.Login_text.TabIndex = 104;
            this.Login_text.Text = "No_LOGIN";
            this.Login_text.Visible = false;
            // 
            // Serv_text
            // 
            this.Serv_text.AutoSize = true;
            this.Serv_text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Serv_text.Location = new System.Drawing.Point(12, 9);
            this.Serv_text.Name = "Serv_text";
            this.Serv_text.Size = new System.Drawing.Size(56, 13);
            this.Serv_text.TabIndex = 103;
            this.Serv_text.Text = "No_SERV";
            this.Serv_text.Visible = false;
            // 
            // RDP_Conn_FS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 43);
            this.Controls.Add(this.Login_text);
            this.Controls.Add(this.Serv_text);
            this.Name = "RDP_Conn_FS";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "RDP_Conn";
            this.Load += new System.EventHandler(this.RDP_Conn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Login_text;
        private System.Windows.Forms.Label Serv_text;
    }
}
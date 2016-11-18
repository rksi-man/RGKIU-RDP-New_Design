namespace RGKIU_VCH
{
    partial class VPN
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
            this.label1 = new System.Windows.Forms.Label();
            this.CHK_on_VPN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "LBL";
            // 
            // CHK_on_VPN
            // 
            this.CHK_on_VPN.AutoSize = true;
            this.CHK_on_VPN.Location = new System.Drawing.Point(75, 9);
            this.CHK_on_VPN.Name = "CHK_on_VPN";
            this.CHK_on_VPN.Size = new System.Drawing.Size(75, 13);
            this.CHK_on_VPN.TabIndex = 1;
            this.CHK_on_VPN.Text = "CHK_on_VPN";
            this.CHK_on_VPN.Visible = false;
            // 
            // VPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 111);
            this.Controls.Add(this.CHK_on_VPN);
            this.Controls.Add(this.label1);
            this.Name = "VPN";
            this.Text = "VPN";
            this.Load += new System.EventHandler(this.VPN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CHK_on_VPN;
    }
}
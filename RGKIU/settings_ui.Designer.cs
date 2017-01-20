namespace RGKIU_VCH
{
    partial class settings_ui
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
            this.save_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.win_chk_auto = new System.Windows.Forms.CheckBox();
            this.win_chk = new System.Windows.Forms.CheckBox();
            this.GRP_text = new System.Windows.Forms.Label();
            this.FAM_text = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.save_btn.Location = new System.Drawing.Point(12, 163);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(91, 36);
            this.save_btn.TabIndex = 0;
            this.save_btn.Text = "Сохранить";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.win_chk_auto);
            this.groupBox1.Controls.Add(this.win_chk);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // win_chk_auto
            // 
            this.win_chk_auto.AutoSize = true;
            this.win_chk_auto.Enabled = false;
            this.win_chk_auto.Location = new System.Drawing.Point(18, 41);
            this.win_chk_auto.Name = "win_chk_auto";
            this.win_chk_auto.Size = new System.Drawing.Size(88, 17);
            this.win_chk_auto.TabIndex = 1;
            this.win_chk_auto.Text = "Авто-запуск";
            this.win_chk_auto.UseVisualStyleBackColor = true;
            // 
            // win_chk
            // 
            this.win_chk.AutoSize = true;
            this.win_chk.Checked = true;
            this.win_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.win_chk.Location = new System.Drawing.Point(18, 18);
            this.win_chk.Name = "win_chk";
            this.win_chk.Size = new System.Drawing.Size(145, 17);
            this.win_chk.TabIndex = 0;
            this.win_chk.Text = "Полноэкранный режим";
            this.win_chk.UseVisualStyleBackColor = true;
            this.win_chk.CheckedChanged += new System.EventHandler(this.win_chk_CheckedChanged);
            // 
            // GRP_text
            // 
            this.GRP_text.AutoSize = true;
            this.GRP_text.Location = new System.Drawing.Point(16, 9);
            this.GRP_text.Name = "GRP_text";
            this.GRP_text.Size = new System.Drawing.Size(58, 13);
            this.GRP_text.TabIndex = 2;
            this.GRP_text.Text = "NaN_GRP";
            // 
            // FAM_text
            // 
            this.FAM_text.AutoSize = true;
            this.FAM_text.Location = new System.Drawing.Point(16, 27);
            this.FAM_text.Name = "FAM_text";
            this.FAM_text.Size = new System.Drawing.Size(57, 13);
            this.FAM_text.TabIndex = 3;
            this.FAM_text.Text = "NaN_FAM";
            // 
            // cancel_btn
            // 
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Location = new System.Drawing.Point(109, 163);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(91, 36);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Очистить данные пользователя";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // settings_ui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(212, 211);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.FAM_text);
            this.Controls.Add(this.GRP_text);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.save_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "settings_ui";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.settings_ui_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox win_chk;
        private System.Windows.Forms.Label GRP_text;
        private System.Windows.Forms.Label FAM_text;
        private System.Windows.Forms.CheckBox win_chk_auto;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button save_btn;
    }
}
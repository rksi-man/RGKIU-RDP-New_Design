namespace RGKIU_VCH
{
    partial class Login
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboGRP = new System.Windows.Forms.ComboBox();
            this.spisok_box = new System.Windows.Forms.ComboBox();
            this.PASS_Text = new System.Windows.Forms.TextBox();
            this.Next = new System.Windows.Forms.Button();
            this.CHK_Text = new System.Windows.Forms.Label();
            this.Login_Text = new System.Windows.Forms.Label();
            this.PVM_Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(75, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Группа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Пароль";
            // 
            // ComboGRP
            // 
            this.ComboGRP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboGRP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboGRP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComboGRP.FormattingEnabled = true;
            this.ComboGRP.Location = new System.Drawing.Point(145, 62);
            this.ComboGRP.Name = "ComboGRP";
            this.ComboGRP.Size = new System.Drawing.Size(119, 27);
            this.ComboGRP.TabIndex = 92;
            this.ComboGRP.SelectedIndexChanged += new System.EventHandler(this.ComboGRP_SelectedIndexChanged);
            // 
            // spisok_box
            // 
            this.spisok_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spisok_box.Enabled = false;
            this.spisok_box.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.spisok_box.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spisok_box.FormattingEnabled = true;
            this.spisok_box.Location = new System.Drawing.Point(145, 99);
            this.spisok_box.Name = "spisok_box";
            this.spisok_box.Size = new System.Drawing.Size(119, 27);
            this.spisok_box.TabIndex = 93;
            this.spisok_box.SelectedIndexChanged += new System.EventHandler(this.spisok_box_SelectedIndexChanged);
            // 
            // PASS_Text
            // 
            this.PASS_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PASS_Text.Enabled = false;
            this.PASS_Text.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PASS_Text.Location = new System.Drawing.Point(145, 136);
            this.PASS_Text.Name = "PASS_Text";
            this.PASS_Text.PasswordChar = '●';
            this.PASS_Text.Size = new System.Drawing.Size(119, 26);
            this.PASS_Text.TabIndex = 94;
            this.PASS_Text.Tag = "";
            this.PASS_Text.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.PASS_Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PASS_Text_KeyPress);
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.SystemColors.Control;
            this.Next.Enabled = false;
            this.Next.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Next.Location = new System.Drawing.Point(86, 180);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(112, 40);
            this.Next.TabIndex = 95;
            this.Next.Text = "Далее";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // CHK_Text
            // 
            this.CHK_Text.AutoSize = true;
            this.CHK_Text.Location = new System.Drawing.Point(0, 0);
            this.CHK_Text.Name = "CHK_Text";
            this.CHK_Text.Size = new System.Drawing.Size(50, 13);
            this.CHK_Text.TabIndex = 97;
            this.CHK_Text.Text = "No_Pass";
            this.CHK_Text.Visible = false;
            // 
            // Login_Text
            // 
            this.Login_Text.AutoSize = true;
            this.Login_Text.Location = new System.Drawing.Point(0, 13);
            this.Login_Text.Name = "Login_Text";
            this.Login_Text.Size = new System.Drawing.Size(53, 13);
            this.Login_Text.TabIndex = 98;
            this.Login_Text.Text = "No_Login";
            this.Login_Text.Visible = false;
            // 
            // PVM_Text
            // 
            this.PVM_Text.AutoSize = true;
            this.PVM_Text.Location = new System.Drawing.Point(0, 26);
            this.PVM_Text.Name = "PVM_Text";
            this.PVM_Text.Size = new System.Drawing.Size(50, 13);
            this.PVM_Text.TabIndex = 99;
            this.PVM_Text.Text = "No_PVM";
            this.PVM_Text.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(284, 240);
            this.Controls.Add(this.PVM_Text);
            this.Controls.Add(this.Login_Text);
            this.Controls.Add(this.CHK_Text);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.PASS_Text);
            this.Controls.Add(this.spisok_box);
            this.Controls.Add(this.ComboGRP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "РКИУ Connect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing_F_L);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComboGRP;
        private System.Windows.Forms.ComboBox spisok_box;
        public System.Windows.Forms.TextBox PASS_Text;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label CHK_Text;
        private System.Windows.Forms.Label Login_Text;
        private System.Windows.Forms.Label PVM_Text;
    }
}
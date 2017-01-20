using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RGKIU_VCH
{
    public partial class settings_ui : Form
    {

        public settings_ui()
        {
            InitializeComponent();
        }

        private void settings_ui_Load(object sender, EventArgs e)
        {
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; ///// 
            string user_data_set = rkiu_folder + @"\settings"; ///// 
            string[] Mass = File.ReadAllLines(user_data, Encoding.Default);
            string[] Mass_set = File.ReadAllLines(user_data_set, Encoding.Default);
            GRP_text.Text = "Группа: " + Mass[0];
            FAM_text.Text = "Фамилия: " + Mass[1];
            //bool window = win_chk.Checked;
            //bool auto = win_chk_auto.Checked;
            if (Mass_set[0].Equals("FS=True"))
            {
                win_chk.Checked = true;
            } else if (Mass_set[0].Equals("FS=False"))
            {
                win_chk.Checked = false;
            }




        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Правильное решение");
          
        }

        private void win_chk_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 

            DialogResult dialogResult = MessageBox.Show("Внимание!\nЕсли Вы нажмете \"Да\", то это вызовет авторизацию заново.\nЭквивалентно выходу из учетной записи.", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Directory.Delete(rkiu_folder, true);
                VPN Form_VPN1 = new VPN();
                Form_VPN1.Close();
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //MessageBox.Show("Одумался");
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data_set = rkiu_folder + @"\settings"; ///// 
            string[] Mass_set = File.ReadAllLines(user_data_set, Encoding.Default);


            bool flag = win_chk.Checked;
            Console.WriteLine(flag);

            if (Mass_set[0].Equals("FS=" + flag))
            {
                //Console.WriteLine("Эквивалентно. " + flag);
                //FileStream USR_Text = new FileStream(user_data_set, FileMode.Create);
                //StreamWriter USR_Writer = new StreamWriter(USR_Text, Encoding.Default);
                //{
                //    USR_Writer.WriteLine("FS=" + flag);
                //    USR_Writer.Close();
                //}
            } else if (!Mass_set[0].Equals("FS=" + flag))
            {
                //Console.WriteLine("Не Эквивалентно. " + flag);
                FileStream USR_Text = new FileStream(user_data_set, FileMode.Create);
                StreamWriter USR_Writer = new StreamWriter(USR_Text, Encoding.Default);
                {
                    USR_Writer.WriteLine("FS=" + flag);
                    USR_Writer.Close();
                }

            }
        }
    }
}

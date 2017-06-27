using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSTSCLib;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using RGKIU_VCH;
using AxMSTSCLib;

namespace RDP
{
   

    public partial class F_RDP : Form
    {
        //string connStr = "server=" + "172.16.1.1" + ";user=" + "mysql_user" + ";database=" + "dpo" + ";port=" + "3306" + ";password=" + "208406" + "; CharSet = utf8;";//Для подключения на ВЦ

        Rectangle screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds;


        public void Form1_Load(object sender, EventArgs e)
        {


            //this.BackColor = Color.Red;
            //this.TransparencyKey = BackColor;

            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; ///// 
            string[] Mass = File.ReadAllLines(user_data, Encoding.Default); //массив 


            Not_Pic.SizeMode = PictureBoxSizeMode.StretchImage;
           // this.dcnct_rdp.Enabled = false;
            this.AcceptButton = cnct_rdp;
            user_text.Text = Mass[1] + ", вход выполнен";
        }

        public F_RDP()
        {
            InitializeComponent();
            this.Text = Application.ProductName;
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);    
        }


      
        private void OnApplicationExit(object sender, EventArgs e)
        {
            //закрыть всссеееее формы
        }

       // private AxMSTSCLib.AxMsRdpClient5 rdpClient; //для full_screen

        public void cnct_rdp_Click(object sender, EventArgs e)
        {



            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; ///// 
            string user_data_set = rkiu_folder + @"\settings"; ///// 
            string[] Mass = File.ReadAllLines(user_data, Encoding.Default);
            string[] Mass_set = File.ReadAllLines(user_data_set, Encoding.Default);




            if (Mass_set[0].Equals("FS=True"))
            {
                /*Код ниже.
                 *Все работает. Старая версия с распределением по формам. 
                 *Попытка перейти на одну главную форму 'RDP_Conn_All_IN' 
                 */
                //RDP_Conn_FS new_FS = new RDP_Conn_FS(); 
                //new_FS.Show();
                /*Код ниже.
                 *Переход на одну главную форму...
                 * Попытка не удалась
                 */
                RDP_Conn_All_IN new_FS = new RDP_Conn_All_IN();
                new_FS.Show();
                //this.Hide();
             //   this.Visible = false;
            }
            else if (Mass_set[0].Equals("FS=False"))
            {
                /*
                 *RDP_Conn_WS new_WS = new RDP_Conn_WS();
                 *new_WS.Show();
                 *this.Hide();
                 */
                RDP_Conn_WS new_WS = new RDP_Conn_WS();
                new_WS.Show();
                //this.Hide();
              //  this.Visible = false;
            }


          

               
        }

        //private void dcnct_rdp_Click(object sender, EventArgs e)
        //{

        //    string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
        //    string rkiu_folder = MyDoc + "\\RKIU"; ///// 
        //    string user_data = rkiu_folder + @"\user"; ///// 
        //    string[] Mass = File.ReadAllLines(user_data, Encoding.Default);
        //    try
        //    {
        //        // Check if connected before disconnecting

        //        if (rdp.Connected.ToString() == "1")
        //        {
        //            rdp.Disconnect();
        //            this.Width = 310;
        //            this.Height = 420;
        //            rdp.Visible = false;
        //            /////
        //            cnct_rdp.Enabled = true;
        //            dcnct_rdp.Enabled = false;
        //            Not_Pic.Visible = true;
        //            dcnct_rdp.Visible = false;
        //            cnct_rdp.Visible = true;
        //            ChkBox_F_S.Visible = true;
        //            F_S_O.Visible = false;
        //            user_text.Text = Mass[1] + ", вход выполнен";
        //            //Settings.Visible = true;
        //            //Help.Visible = true;
        //            //About.Visible = true;
        //        }
                
        //    }
        //    catch (Exception Ex)
        //    {
        //        rdp.Visible = false;
        //        MessageBox.Show("Ошибка отключения", "Ошибка отключения от удаленного рабочего стола " + " Ошибка:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

     
        private void Closing_F(object sender, FormClosingEventArgs e)
        {
            VPN Form_VPN1 = new VPN();
            Form_VPN1.Close();
            Application.Exit();
        }


       
       

        private void Help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

            string help_path = @"RGKIU.chm";
            var help_proc = new System.Diagnostics.Process();
            help_proc.StartInfo.FileName = help_path;
            help_proc.StartInfo.UseShellExecute = true;
            help_proc.Start();
            
        }

        private void Not_Pic_Click(object sender, EventArgs e)
        {

        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы входите в экспертный режим. \nВы уверены, что это необходимо?", "Экспертный режим", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                settings_ui set_ui = new settings_ui();
                set_ui.ShowDialog();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сейчас Вы будете направлены на стариницу проекта.\nНажмите \"Да\", если хотите перейти или нажмите \"Нет\", если хотите остаться в программе", "Переход на сайт", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("http://connect.rgkiu.ru/");
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
            
        }
    }
}
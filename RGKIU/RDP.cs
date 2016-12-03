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
        
       
        Rectangle screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds;


        public void Form1_Load(object sender, EventArgs e)
        {
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; ///// 
            string[] Mass = File.ReadAllLines(user_data, Encoding.Default);


            // label2.Text = File.OpenText(TxT_Pa.ToString);



            //FileStream load = new FileStream(TxT_Pa, FileMode.Open);
            //StreamReader read = new StreamReader(load);
            //Not_TxT.Text = read.ReadToEnd();

            //Not_Pic.Load(path);
            Not_Pic.SizeMode = PictureBoxSizeMode.StretchImage;



            this.dcnct_rdp.Enabled = false;
            //string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            //string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            //string user_data = rkiu_folder + @"\user"; /////
            //string[] Mass = File.ReadAllLines(user_data, Encoding.Default);



            this.AcceptButton = cnct_rdp;

            user_text.Text = Mass[1] + ", добро пожаловать!";



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
        private AxMSTSCLib.AxMsRdpClient5 rdpClient; //для full_screen

        private void cnct_rdp_Click(object sender, EventArgs e)
        {
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; ///// 
            string[] Mass = File.ReadAllLines(user_data, Encoding.Default);


            string connStr = "server=" + "172.16.1.1" + ";user=" + "mysql_user" + ";database=" + "dpo" + ";port=" + "3306" + ";password=" + "208406" + "; CharSet = utf8;";//Для подключения на ВЦ
           





            MySqlConnection Conn_atriz_serv = new MySqlConnection(connStr);
            Conn_atriz_serv.Open();
            MySqlCommand atriz_serv = new MySqlCommand("SELECT PVM FROM dpo.users_dpo where GRP = " + "'" + Mass[0] + "'" + " and " + "FAM = " + "'" + Mass[1] + "'" + ";", Conn_atriz_serv);
            MySqlDataReader atriz_com_serv = atriz_serv.ExecuteReader();
            while (atriz_com_serv.Read())
            {
                string table1 = atriz_com_serv.GetString(0);
                Serv_text.Text = table1.ToString();
             
            }
            atriz_com_serv.Close();


            MySqlConnection Conn_atriz_login = new MySqlConnection(connStr);
            Conn_atriz_login.Open();
            MySqlCommand atriz_login = new MySqlCommand("SELECT LOGIN FROM dpo.users_dpo where GRP = " + "'" + Mass[0] + "'" + " and " + "FAM = " + "'" + Mass[1] + "'" + ";", Conn_atriz_login);
            MySqlDataReader atriz_com_login = atriz_login.ExecuteReader();
            while (atriz_com_login.Read())
            {
                string table1 = atriz_com_login.GetString(0);
                Login_text.Text = table1.ToString();
              
            }
            atriz_com_login.Close();




            try
            {
               


                if (ChkBox_F_S.Checked == true)
                {
                   

                   
                        rdpClient = new AxMSTSCLib.AxMsRdpClient5();
                        ((ISupportInitialize)rdpClient).BeginInit();
                        // rdpClient.Enabled = true;
                        //rdpClient.Location = new System.Drawing.Point(0, 0);
                        // rdpClient.Name = "MsRdpClient";
                        rdpClient.Size = new Size(screenSize.Size.Width, screenSize.Size.Height);
                        rdpClient.TabIndex = 1;
                        rdpClient.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                        Controls.Add(rdpClient); ((ISupportInitialize)rdpClient).EndInit();

                        //String username = "boss";
                        //String password = "newsign147";
                        rdpClient.Server = Serv_text.Text;
                        rdpClient.UserName = Login_text.Text;
                        IMsTscNonScriptable secured = (IMsTscNonScriptable)rdpClient.GetOcx();
                        secured.ClearTextPassword = Mass[2];
                    // rdpClient.AdvancedSettings2.ClearTextPassword = textBox2.Text; //старое получение пароля
                    //rdpClient.Domain = "COLLEGE";                                                                                           //домен!!!
                    rdpClient.FullScreen = true;

                        rdpClient.AdvancedSettings2.PerformanceFlags = 127; //графика
                        rdpClient.ColorDepth = 16; // цвета
                        rdpClient.AdvancedSettings2.ConnectToServerConsole = true; // под вопросом???

                        rdpClient.AdvancedSettings2.RedirectDrives = false;
                        rdpClient.AdvancedSettings2.RedirectPrinters = false;
                        rdpClient.AdvancedSettings2.RedirectPorts = false;
                        rdpClient.AdvancedSettings2.RedirectSmartCards = false;
                        rdpClient.AdvancedSettings6.RedirectClipboard = false;
                        rdpClient.AdvancedSettings6.MinutesToIdleTimeout = 1;
                        //////////////////////////////////////////////////////////////////////////////
                        //rdpClient.AdvancedSettings2.ContainerHandledFullScreen = 1;

                        rdpClient.AdvancedSettings4.ConnectionBarShowRestoreButton = false;
                        rdpClient.AdvancedSettings4.ConnectionBarShowMinimizeButton = false;
                        rdpClient.AdvancedSettings4.PinConnectionBar = false;
                        //rdpClient.AdvancedSettings4.DisplayConnectionBar = false; 

                        //rdpClient.FullScreenTitle = "111";
                        //////////////////////////////////////////////////////////////////////////////////
                        // rdpClient.Size = new System.Drawing.Size(screenSize.Size.Width, screenSize.Size.Height);

                        //rdpClient.AdvancedSettings6.AuthenticationLevel = 0; //уровень проверки сертефиката
                        rdpClient.Connect();
                        rdpClient.Visible = false;                // ГИПЕР КОСТЫЛЬ, надеюсь временно


                        //Settings.Visible = false;



                    //rdp.Visible = false;                    //????
                    ///////////////////////////

                    /////

                    /////

                    //скрыть белое полотно!!!



                }
                else if (ChkBox_F_S.Checked == false)
                {
                  
                    {
                        rdp.Server = Mass[4];
                        //rdp.Domain = "COLLEGE";
                        rdp.UserName = Mass[3];
                        IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                        secured.ClearTextPassword = Mass[2];

                        rdp.Location = new System.Drawing.Point(0, 50);
                        rdp.Size = new System.Drawing.Size(800, 600);
                        /////////////////////////////////////////////
                        //rdp.
                        /////////////////////////////////////////////
                        rdp.Connect();
                    }
                    //if (rdp.Connected.ToString() == "1")
                    //{
                    {
                        this.Width = 805;
                        this.Height = 680;
                        /////
                        //cnct_rdp.Visible = false;
                        //    dcnct_rdp.Visible = true;
                        cnct_rdp.Enabled = false;
                        dcnct_rdp.Enabled = true;
                        /////
                        Not_Pic.Visible = false;
                        cnct_rdp.Visible = false;
                        ChkBox_F_S.Visible = false;
                        dcnct_rdp.Left = 650;
                        dcnct_rdp.Visible = true;
                        Not_TxT.Visible = false;
                        user_text.Text = "Some Text";
                        F_S_O.Visible = true;
                        F_S_O.Left = 520;


                        Settings.Visible = false;
                        Help.Visible = false;
                        About.Visible = false;
                        rdp.Visible = true;
                    }
                    //}
                }

            }

            
            catch
                {
                    rdp.Visible = false;
                    MessageBox.Show("Ошибка подключения к удаленному рабочему столу " + Mass[4] + "\nОшибка: Неверный пароль ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                }

           


        }

        private void dcnct_rdp_Click(object sender, EventArgs e)
        {

            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; ///// 
            string[] Mass = File.ReadAllLines(user_data, Encoding.Default);
            try
            {
                // Check if connected before disconnecting
                {
                    if (rdp.Connected.ToString() == "1")
                        rdp.Disconnect();
                    this.Width = 550;
                    this.Height = 400;
                    /////
                    //cnct_rdp.Visible = true;
                    //dcnct_rdp.Visible = false;
                    rdp.Visible = false;
                    /////
                    cnct_rdp.Enabled = true;
                    dcnct_rdp.Enabled = false;

                    Not_Pic.Visible = true;
                    dcnct_rdp.Visible = false;
                    cnct_rdp.Visible = true;
                    ChkBox_F_S.Visible = true;
                    Not_TxT.Visible = true;
                    F_S_O.Visible = false;
                    user_text.Text = Mass[1] + ", добро пожаловать!";

                    Settings.Visible = true;
                    Help.Visible = true;
                    About.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                rdp.Visible = false;
                MessageBox.Show("Ошибка отключения", "Ошибка отключения от удаленного рабочего стола " + " Ошибка:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        private void Closing_F(object sender, FormClosingEventArgs e)
        {
            VPN Form_VPN1 = new VPN();
            Form_VPN1.Close();
            Application.Exit();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; ///// 
            string[] Mass = File.ReadAllLines(user_data, Encoding.Default);
            try
            {
                // Check if connected before disconnecting
                {
                    if (rdp.Connected.ToString() == "1")
                    rdp.Disconnect();
                    this.Width = 550;
                    this.Height = 400;
                    /////
                    //cnct_rdp.Visible = true;
                    //dcnct_rdp.Visible = false;
                    rdp.Visible = false;
                    /////
                    cnct_rdp.Enabled = true;
                    dcnct_rdp.Enabled = false;

                    Not_Pic.Visible = true;
                    dcnct_rdp.Visible = false;
                    cnct_rdp.Visible = true;
                    ChkBox_F_S.Visible = true;
                    Not_TxT.Visible = true;
                    F_S_O.Visible = false;
                    user_text.Text = Mass[1] + ", добро пожаловать!";

                    Settings.Visible = true;
                    Help.Visible = true;
                    About.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                rdp.Visible = false;
                MessageBox.Show("Ошибка отключения", "Ошибка отключения от удаленного рабочего стола " + " Ошибка:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.Width = 550;
            this.Height = 400;
            rdp.Visible = false;
            /////
            cnct_rdp.Enabled = true;
            dcnct_rdp.Enabled = false;

            Not_Pic.Visible = true;
            dcnct_rdp.Visible = false;
            cnct_rdp.Visible = true;
            ChkBox_F_S.Visible = true;
            Not_TxT.Visible = true;
            F_S_O.Visible = false;
            user_text.Text = Mass[1] + ", добро пожаловать!";
           


            rdpClient = new AxMSTSCLib.AxMsRdpClient5();
            ((ISupportInitialize)rdpClient).BeginInit();
            // rdpClient.Enabled = true;
            //rdpClient.Location = new System.Drawing.Point(0, 0);
            // rdpClient.Name = "MsRdpClient";
            rdpClient.Size = new Size(screenSize.Size.Width, screenSize.Size.Height);
            rdpClient.TabIndex = 1;
            rdpClient.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            Controls.Add(rdpClient); ((ISupportInitialize)rdpClient).EndInit();

            //String username = "boss";
            //String password = "newsign147";
            rdpClient.Server = Mass[4];
            rdpClient.UserName = Mass[3];
            IMsTscNonScriptable secured = (IMsTscNonScriptable)rdpClient.GetOcx();
            secured.ClearTextPassword = Mass[2];
            // rdpClient.AdvancedSettings2.ClearTextPassword = textBox2.Text; //старое получение пароля
            //rdpClient.Domain = "COLLEGE";
            rdpClient.FullScreen = true;

            rdpClient.AdvancedSettings2.PerformanceFlags = 127; //графика
            rdpClient.ColorDepth = 16; // цвета
            rdpClient.AdvancedSettings2.ConnectToServerConsole = true; // под вопросом???

            rdpClient.AdvancedSettings2.RedirectDrives = false;
            rdpClient.AdvancedSettings2.RedirectPrinters = false;
            rdpClient.AdvancedSettings2.RedirectPorts = false;
            rdpClient.AdvancedSettings2.RedirectSmartCards = false;
            rdpClient.AdvancedSettings6.RedirectClipboard = false;
            rdpClient.AdvancedSettings6.MinutesToIdleTimeout = 1;
            //////////////////////////////////////////////////////////////////////////////
            //rdpClient.AdvancedSettings2.ContainerHandledFullScreen = 1;

            rdpClient.AdvancedSettings4.ConnectionBarShowRestoreButton = false;
            rdpClient.AdvancedSettings4.ConnectionBarShowMinimizeButton = false;
            rdpClient.AdvancedSettings4.PinConnectionBar = false;
            //rdpClient.AdvancedSettings4.DisplayConnectionBar = false; 

            //rdpClient.FullScreenTitle = "111";
            //////////////////////////////////////////////////////////////////////////////////
            // rdpClient.Size = new System.Drawing.Size(screenSize.Size.Width, screenSize.Size.Height);

            //rdpClient.AdvancedSettings6.AuthenticationLevel = 0; //уровень проверки сертефиката
            rdpClient.Connect();
            rdpClient.Visible = false;                // ГИПЕР КОСТЫЛЬ, надеюсь временно

        }

        private void Settings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MessageBox.Show("123");

        }

        private void Help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

            string help_path = @"RGKIU.chm";
            var help_proc = new System.Diagnostics.Process();
            help_proc.StartInfo.FileName = help_path;
            help_proc.StartInfo.UseShellExecute = true;
            help_proc.Start();
            
        }
    }
}
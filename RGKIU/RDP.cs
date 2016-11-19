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

namespace RDP
{
   

    public partial class F_RDP : Form
    {
        
       
        Rectangle screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

       
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dcnct_rdp.Enabled = false;
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; /////
            string[] Mass = File.ReadAllLines(user_data, Encoding.Default);



            this.AcceptButton = cnct_rdp;

            label1.Text = Mass[1] + ", добро пожаловать!";
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
                        rdpClient.Server = Mass[4];
                        rdpClient.UserName = Mass[3];
                        IMsTscNonScriptable secured = (IMsTscNonScriptable)rdpClient.GetOcx();
                        secured.ClearTextPassword = Mass[2];
                        // rdpClient.AdvancedSettings2.ClearTextPassword = textBox2.Text; //старое получение пароля
                        rdpClient.Domain = "COLLEGE";
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

                        rdpClient.AdvancedSettings6.AuthenticationLevel = 0; //уровень проверки сертефиката
                        rdpClient.Connect();
                        rdpClient.Visible = false;                // ГИПЕР КОСТЫЛЬ, надеюсь временно
                                                                  //rdp.Visible = false;                    //????
                                                                  ///////////////////////////

                        /////

                        /////

                        //скрыть белое полотно!!!
                   
                }
                else if (ChkBox_F_S.Checked == false)
                {
                    rdp.Server = Mass[4];
                    rdp.Domain = "COLLEGE";
                    rdp.UserName = Mass[3];
                    IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                    secured.ClearTextPassword = Mass[2];

                    rdp.Location = new System.Drawing.Point(0, 50);
                    rdp.Size = new System.Drawing.Size(800, 600);
                    /////////////////////////////////////////////
                    //rdp.
                    /////////////////////////////////////////////
                    rdp.Connect();

                    rdp.Visible = true;

                    this.Width = 805;
                    this.Height = 680;
                    /////
                    //cnct_rdp.Visible = false;
                    //    dcnct_rdp.Visible = true;
                    cnct_rdp.Enabled = false;
                    dcnct_rdp.Enabled = true;
                    /////
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
            try
            {          
                // Check if connected before disconnecting
                {
                    if (rdp.Connected.ToString() == "1")
                    rdp.Disconnect();
                    this.Width = 805;
                    this.Height = 85;
                    /////
                    //cnct_rdp.Visible = true;
                    //dcnct_rdp.Visible = false;
                    rdp.Visible = false;
                    /////
                    cnct_rdp.Enabled = true;
                    dcnct_rdp.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                rdp.Visible = false;
                MessageBox.Show("Ошибка отключения", "Ошибка отключения от удаленного рабочего стола "  + " Ошибка:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        private void Closing_F(object sender, FormClosingEventArgs e)
        {
            VPN Form_VPN1 = new VPN();
            Form_VPN1.Close();
            Application.Exit();
        }
    }
}
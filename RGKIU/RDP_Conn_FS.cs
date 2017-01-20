using MSTSCLib;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

/*
*26.12.2016
*Начал разговаривать с кодом..
*Пытался с ним договориться, после - угрожал
*/
namespace RGKIU_VCH
{
    public partial class RDP_Conn_FS : Form
    {
        public RDP_Conn_FS()
        {
            InitializeComponent();
            //this.AllowTransparency = true;
            this.FormBorderStyle = FormBorderStyle.None;

            this.Opacity = 0.0;


        }
        private AxMSTSCLib.AxMsRdpClient5 rdpClient; //для full_screen




        private void RDP_Conn_Load(object sender, EventArgs e) //Просто перенес методы из старого класса, осознал, что код бывает бесчуственным..
        {
            Rectangle screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds;



            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; ///// 
            string user_data_set = rkiu_folder + @"\settings"; ///// 
            string[] Mass = File.ReadAllLines(user_data, Encoding.Default);
            string[] Mass_set = File.ReadAllLines(user_data_set, Encoding.Default);




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

                    rdpClient.AdvancedSettings6.AuthenticationLevel = 0; //уровень проверки сертефиката
                    
                    rdpClient.Connect();
                    rdpClient.Visible = false;                // ГИПЕР КОСТЫЛЬ, надеюсь временно

                //Settings.Visible = false;



                //rdp.Visible = false;                    //????
                ///////////////////////////

                /////

                /////

                //скрыть белое полотно!!!





                
            }


            catch
            {
                //rdp.Visible = false;
                MessageBox.Show("Ошибка подключения к удаленному рабочему столу " + Serv_text.Text + "\nОшибка: Неверный пароль ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

           

        }
    }
}

using MSTSCLib;
using MySql.Data.MySqlClient;
using RDP;
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
    public partial class RDP_Conn_WS : Form
    {
        public void Transform()
        {
            //this.Close();
            this.Opacity = 0.0;
            this.Visible = false;
            RDP_Conn_All_IN newFALLIN = new RDP_Conn_All_IN();
            newFALLIN.Show();
        }
        public RDP_Conn_WS()
        {
            InitializeComponent();
            this.Opacity = 0.0;
        }
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        const int SC_RESTORE = 0xF120;
        const int WM_NCLBUTTONDBLCLK = 0x00A3;
        const int HTCAPTION = 2;
        const string MsgMaximizing = "Разворачивание";
        const string MsgMinimizing = "Сворачивание";
        const string MsgRestoring = "Восстановление";

        protected override void WndProc(ref Message m)
        {
           
            string state = string.Empty;
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    switch (m.WParam.ToInt32())
                    {
                        case SC_MINIMIZE:
                           
                            state = MsgMinimizing;
                            break;
                        case SC_MAXIMIZE:
                            state = MsgMaximizing;
                          
                            Transform(); /// Мой трансформер
                            break;
                        case SC_RESTORE:
                            state = MsgRestoring;
                            
                            break;
                    }
                    break;
                case WM_NCLBUTTONDBLCLK:
                    if (m.WParam.ToInt32() == HTCAPTION)
                    {
                       
                        if (WindowState == FormWindowState.Maximized)
                        {
                            state = MsgRestoring;
                            //MessageBox.Show("Сворачивание x2");
                        }
                        else
                        {
                            state = MsgMaximizing;
                            //MessageBox.Show("Разворачивание x2");
                            Transform(); /// Мой трансформер
                        }
                    }
                    break;
            }
           

            base.WndProc(ref m);
        }
        private void RDP_Conn_WS_Load(object sender, EventArgs e)
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




                    {
                        
                        rdp.Server = Serv_text.Text;
                        //rdp.Domain = "COLLEGE";
                        rdp.UserName = Login_text.Text;
                        IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                        secured.ClearTextPassword = Mass[2];
                        rdp.Location = new System.Drawing.Point(0, 0);
                        rdp.Size = new System.Drawing.Size(800, 600);
                    
                    /////////////////////////////////////////////////////////////////
                   
                    /////////////////////////////////////////////////////////////////
                    rdp.Connect();
                    }

                    {
                    this.Width = rdp.Size.Width + 5;
                    this.Height = rdp.Size.Height + 28;
                    //cnct_rdp.Enabled = false;
                    //dcnct_rdp.Enabled = true;
                    /////
                    //Not_Pic.Visible = false;
                    //cnct_rdp.Visible = false;
                    //ChkBox_F_S.Visible = false;
                    //dcnct_rdp.Left = 650;
                    //dcnct_rdp.Visible = true;
                    //user_text.Text = "Some Text";
                    //F_S_O.Visible = true;
                    //F_S_O.Left = 520;
                    //Settings.Visible = false;
                    //Help.Visible = false;
                    //About.Visible = false;
                    rdp.Visible = true;
                    }

                

            }


            catch
            {
                rdp.Visible = false;
                MessageBox.Show("Ошибка подключения к удаленному рабочему столу " + Serv_text.Text + "\nОшибка: Неверный пароль ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

    }

        private void Rdp_OnEnterFullScreenMode(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void rdp_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            //rdp.Disconnect();
            //MessageBox.Show("DSCNKT");
            /////////////////////////////////////////////////////////////this.Close();
            this.Visible = false;
            

        }

        private void RDP_Conn_WS_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //this.Close();
                this.Visible = false;
                F_RDP f_rdp = new F_RDP();
                f_rdp.Show();
                
            }
           



        }

        private void rdp_OnLoginComplete(object sender, EventArgs e)
        {
            //MessageBox.Show("render complete");


            ///////////
            this.AllowTransparency = true;
            this.TransparencyKey = this.BackColor;//он же будет заменен на прозрачный цвет
            Opacity = 0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((sender1, e1) =>
            {
                if ((Opacity += 0.05d) == 1) timer.Stop();
            });
            timer.Interval = 30;
            timer.Start();
            /////////



            //this.Opacity = 1;
         
        }

        private void RDP_Conn_WS_SizeChanged121(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            this.Visible = false;
        }
    }
}

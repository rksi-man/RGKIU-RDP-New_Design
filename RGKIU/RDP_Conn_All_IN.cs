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
using System.Threading;
using System.Windows.Forms;

namespace RGKIU_VCH
{
    public partial class RDP_Conn_All_IN : Form
    {
        System.Windows.Forms.Timer tmrShow;
        public RDP_Conn_All_IN()
        {
            InitializeComponent();
            this.Opacity = 0.0;
        }

        public Rectangle screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

        private void RDP_Conn_All_IN_Load(object sender, EventArgs e)
        {
            
          


            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; ///// 
            string user_data_set = rkiu_folder + @"\settings"; ///// 
            string[] Mass = File.ReadAllLines(user_data, Encoding.Default);
            string[] Mass_set = File.ReadAllLines(user_data_set, Encoding.Default);


            string connStr = "server=" + "185.154.72.11" + ";user=" + "vlad" + ";database=" + "dpo" + ";port=" + "3306" + ";password=" + "212121" + "; CharSet = utf8;";//Для подключения на ВЦ


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
                    //rdp.Size = new System.Drawing.Size(800, 600);
                    rdp.Size = new System.Drawing.Size(screenSize.Size.Width, screenSize.Size.Height);
                    /////////////////////////////////////////////////////////////////
                                                                                ////Уменьшить качество
                    /////////////////////////////////////////////////////////////////
                    rdp.Connect();
                }

                {
                    //this.Width = 805;
                    //this.Height = 640;




                    //this.WindowState = FormWindowState.Maximized;



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

        private void rdp_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            MessageBox.Show("Кто-то выбил или что-то с сетью, что маловероятно....");
            this.Visible = false;
            this.Close();
            F_RDP f_rdpD = new F_RDP();
            f_rdpD.Show();

        }

        //private void RDP_Conn_All_IN_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    F_RDP Main_FRM = new F_RDP();
        //    Main_FRM.Show();
        //}

        private void rdp_OnLoginComplete(object sender, EventArgs e)
        {
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
            double xwidth = screenSize.Width;
            int xwidthfinal = Convert.ToInt32(xwidth) / 2 - re_size.Size.Width / 2;

            to_tray.Visible = true;
            to_tray.Location = new Point(xwidthfinal - 100, to_tray.Location.Y);
            re_size.Visible = true;
            re_size.Location = new Point(xwidthfinal, re_size.Location.Y);
            close_btn.Visible = true;
            close_btn.Location = new Point(xwidthfinal + 100, close_btn.Location.Y);
        }

        private void close_btn_Click_1(object sender, EventArgs e)
        {


            ////////
            Opacity = 1;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((sender1, e1) =>
            {
                if ((Opacity -= 0.05d) == 0)
                {
                    timer.Stop();
                    //MessageBox.Show("123");
                }
               
            });
            timer.Interval = 30;
            timer.Start();
            ///////




            tmrShow = new System.Windows.Forms.Timer();
            tmrShow.Interval = 700;
            tmrShow.Tick += tmrShow_Tick;
            tmrShow.Enabled = true;

            ////////////////
            //this.Visible = false;
            //this.Close();
            //F_RDP Main_FRM = new F_RDP();
            //Main_FRM.Show();
           ////////////////

        }

        private void tmrShow_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("странности");
            this.Visible = false;
            this.Close();
            F_RDP Main_FRM = new F_RDP();
            Main_FRM.Show();
            tmrShow.Stop();
                    
        }

        private void to_tray_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void re_size_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            //rdp.Size = new Size(screenSize.Width / Convert.ToInt32(1.5), screenSize.Height / Convert.ToInt32(1.5));
            //this.Size = new Size(screenSize.Width / Convert.ToInt32(1.5), screenSize.Height / Convert.ToInt32(1.5));
            //this.Visible = false;
            //this.Close();
            this.Visible = false;
            this.Close();
            RDP_Conn_WS wsForm = new RDP_Conn_WS();
            wsForm.Show();
                     

        }
    }
}

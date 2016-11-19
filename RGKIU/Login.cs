using MySql.Data.MySqlClient;
using RDP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RGKIU_VCH
{
    public partial class Login : Form
    {
        string connStr = "server=" + "172.16.1.1" + ";user=" + "mysql_user" + ";database=" + "dpo" + ";port=" + "3306" + ";password=" + "208406" + "; CharSet = utf8;";//Для подключения на ВЦ
        public Login()
        {
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = Next;
            {
                MySqlConnection conn_sp_grp = new MySqlConnection(connStr);
                conn_sp_grp.Open();

                MySqlCommand GRP = new MySqlCommand("SELECT GRP FROM dpo.users_dpo where CHK = '1' group by GRP;", conn_sp_grp);
                MySqlDataReader comb_grp = GRP.ExecuteReader();

                while (comb_grp.Read())
                {

                    string table1 = comb_grp.GetString(0);
                    ComboGRP.Items.Add(table1);
                }
                comb_grp.Close();
            }
        }

        private void ComboGRP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboGRP.SelectedIndex > -1)
            {
                spisok_box.Items.Clear();
                PASS_Text.Clear();
                {
                    MySqlConnection conn_sp = new MySqlConnection(connStr);
                    conn_sp.Open();
                    MySqlCommand FAM = new MySqlCommand("SELECT FAM FROM dpo.users_dpo where GRP = " + "'" + ComboGRP.SelectedItem + "'" + ";", conn_sp);
                    MySqlDataReader comb = FAM.ExecuteReader();
                    while (comb.Read())
                    {

                        string table1 = comb.GetString(0);
                        spisok_box.Items.Add(table1);

                    }
                    comb.Close();
                }
                spisok_box.Enabled = true;
            }
        }

        private void spisok_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            PASS_Text.Enabled = true;
            PASS_Text.Clear(); 
        }
        private void OnApplicationExit(object sender, EventArgs e)
        {
            
            //VPN frm = new VPN();
            //frm.Show();
            //frm.OnApplicationExit();
            //Application.Exit();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            {
                CHK_Text.Text = "No_Pass";

                MySqlConnection conn_sp = new MySqlConnection(connStr);
                conn_sp.Open();
                MySqlCommand CHK = new MySqlCommand("SELECT CHK FROM dpo.users_dpo where GRP = " + "'" + ComboGRP.SelectedItem + "'" + " and " + "FAM = " + "'" + spisok_box.SelectedItem + "'" + " and " + "PASS = " + "'" + PASS_Text.Text + "'" + ";", conn_sp);
                MySqlDataReader comb = CHK.ExecuteReader();
                while (comb.Read())
                {
                    string table1 = comb.GetString(0);
                    CHK_Text.Text = table1.ToString();
                }
                comb.Close();
                {


                        if (CHK_Text.Text == "1")
                    {
                        MessageBox.Show("Добро пожаловать!");
                        MySqlConnection Conn_Login = new MySqlConnection(connStr);
                        Conn_Login.Open();
                        MySqlCommand Login = new MySqlCommand("SELECT LOGIN FROM dpo.users_dpo where GRP = " + "'" + ComboGRP.SelectedItem + "'" + " and " + "FAM = " + "'" + spisok_box.SelectedItem + "'" + " and " + "PASS = " + "'" + PASS_Text.Text + "'" + ";", conn_sp);
                        MySqlDataReader Login_com = Login.ExecuteReader();
                        while (Login_com.Read())
                        {
                            string table1 = Login_com.GetString(0);
                            Login_Text.Text = table1.ToString();
                        }
                        Login_com.Close();

                        MySqlConnection Conn_PVM = new MySqlConnection(connStr);
                        Conn_PVM.Open();
                        MySqlCommand PVM = new MySqlCommand("SELECT PVM FROM dpo.users_dpo where GRP = " + "'" + ComboGRP.SelectedItem + "'" + " and " + "FAM = " + "'" + spisok_box.SelectedItem + "'" + " and " + "PASS = " + "'" + PASS_Text.Text + "'" + ";", conn_sp);
                        MySqlDataReader PVM_com = PVM.ExecuteReader();
                        while (PVM_com.Read())
                        {
                            string table1 = PVM_com.GetString(0);
                            PVM_Text.Text = table1.ToString();
                        }
                        Conn_PVM.Close();


                        string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
                        string rkiu_folder = MyDoc + "\\RKIU"; ///// 
                        string user_data = rkiu_folder + @"\user"; ///// 



                        {
                            if (File.Exists(user_data) == false)

                                Directory.CreateDirectory(rkiu_folder);
                            FileStream USR_Text = new FileStream(user_data, FileMode.Create);
                            StreamWriter USR_Writer = new StreamWriter(USR_Text, Encoding.Default);
                            {
                                USR_Writer.WriteLine(ComboGRP.SelectedItem);
                                USR_Writer.WriteLine(spisok_box.SelectedItem);
                                USR_Writer.WriteLine(PASS_Text.Text);
                                USR_Writer.WriteLine(Login_Text.Text);
                                USR_Writer.WriteLine(PVM_Text.Text);
                                USR_Writer.Close();
                            }
                        }

                        //открытие формы RDP
                        F_RDP Form_RDP = new F_RDP();
                        Form_RDP.Show();
                        this.Hide();

                    }

                        else if (CHK_Text.Text == "0")
                        {
                            MessageBox.Show("Отчислен");
                        }
                        else if (CHK_Text.Text == "No_Pass")
                        {
                            MessageBox.Show("Неправильный пароль!");
                        }





                }
                
            }

            //запуск формы RDP

            //F_RDP Form_RDP = new F_RDP();
            //this.Hide();
            //Form_RDP.Show();

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            PASS_Text.MaxLength = 8;
            if (PASS_Text.TextLength > 7)
            Next.Enabled = true;
            if (PASS_Text.TextLength < 8)
                Next.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
            string rkiu_folder = MyDoc + "\\RKIU"; ///// 
            string user_data = rkiu_folder + @"\user"; ///// 

            string str = user_data;
            string result = str.Substring(str.IndexOf("TD", 0));
            Console.WriteLine(result);
        }

        private void Closing_F_L(object sender, FormClosingEventArgs e)
        {
            VPN Form_VPN1 = new VPN();
            Form_VPN1.Close();
            Application.Exit();
        }
    }
}

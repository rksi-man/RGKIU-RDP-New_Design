using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RGKIU_VCH
{
    public partial class Login : Form
    {
        string connStr = "server=" + "192.168.1.1" + ";user=" + "mysql_user" + ";database=" + "dpo" + ";port=" + "3306" + ";password=" + "208406" + "; CharSet = utf8;";//Для подключения на ВЦ
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
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
            textBox2.Enabled = true;
        }
    }
}

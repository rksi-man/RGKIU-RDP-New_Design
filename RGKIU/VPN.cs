using MySql.Data.MySqlClient;
using RDP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RGKIU_VCH
{
    public partial class VPN : Form
    {
        BackgroundWorker NW = new BackgroundWorker();
        IPStatus status_local = IPStatus.TimedOut;
        string ServMySQL = @"172.16.1.1"; //Для пинга на ВЦ
        string connStr = "server=" + "172.16.1.1" + ";user=" + "mysql_user" + ";database=" + "dpo" + ";port=" + "3306" + ";password=" + "208406" + "; CharSet = utf8;";//Для подключения на ВЦ
        public VPN()
        {
            
            TopMost = true;
            InitializeComponent();


            this.AllowTransparency = true;
            //this.BackColor = Color.AliceBlue;//цвет фона  
            this.TransparencyKey = this.BackColor;//он же будет заменен на прозрачный цвет
            Opacity = 0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler((sender, e) =>
            {
                if ((Opacity += 0.05d) == 1) timer.Stop();
            });
            timer.Interval = 50;
            timer.Start();
            NW.DoWork += new DoWorkEventHandler(Nigga_Work);
            NW.ProgressChanged += new ProgressChangedEventHandler(Nigga_Work_Chang);
            NW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Nigga_Work_RunWorkerCompleted);
            NW.WorkerReportsProgress = true;
            NW.WorkerSupportsCancellation = true;

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        } //инициальизация

        void Nigga_Work_Chang(object sender, ProgressChangedEventArgs e)
        {

        }

        void Nigga_Work(object sender, DoWorkEventArgs e) //нигга
        {
            IPStatus status_global = IPStatus.TimedOut;
           // IPStatus status_local = IPStatus.TimedOut;

            string global_ping = @"ya.ru"; //Для пинга на ВЦ
            string ServMySQL = @"172.16.1.1"; //Для пинга на ВЦ
            try
            {
                {

                    Ping ping_global = new Ping();
                    PingReply reply_global = ping_global.Send(global_ping);//Проверка интернета
                                                                           //PingReply reply_global = ping_global.Send(ServMySQL); //Проверка интернета ДОМА.
                    status_global = reply_global.Status;
                    ///////////////////////////////////////////////////////////////
                    Ping ping_local = new Ping();
                    PingReply reply_local = ping_local.Send(ServMySQL, 10);
                    status_local = reply_local.Status;
                    ///////////////////////////////////////////////////////////////



                    if (status_global == IPStatus.Success)
                    {
                        //MessageBox.Show("Инет есть. Интернет. Запуск ВПН");
                        ///////ньюконфиг
                        {
                            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Мои документы"
                            string rkiu_folder = MyDoc + "\\RKIU"; ///// Папка "Мои документы\RKIU\"
                            string PBK_File = rkiu_folder + @"\connection.pbk"; ///// Файл "Мои документы\RKIU\connection.pbk"
                                                                                //this.Text = (rkiu_folder);


                            //VPN РЕКВИЗИТЫ
                            string Vpn_Name = "RKIU-VPN-TEST";
                            string Vpn_IP = "109.195.230.224";
                            string Vpn_Login = "vpn";
                            string Vpn_Pass = "123";



                            {///// Если не нашел Файл "Мои документы\RKIU\connection.pbk" то создать Папку "Мои документы\RKIU\" и Пустой файл "Мои документы\RKIU\connection.pbk" с записью нижеизложенного. (полный конфиг)
                                if

                                (File.Exists(PBK_File) == false)
                                    Directory.CreateDirectory(rkiu_folder);
                                FileStream PBK_Text = new FileStream(PBK_File, FileMode.Create);
                                StreamWriter PBK_Writer = new StreamWriter(PBK_Text);


                                {///// Полный конфиг PBK файла.
                                    PBK_Writer.WriteLine("[" + Vpn_Name + "]");
                                    PBK_Writer.WriteLine("Encoding=1");
                                    PBK_Writer.WriteLine("PBVersion=1");
                                    PBK_Writer.WriteLine("Type=2");
                                    PBK_Writer.WriteLine("AutoLogon=0");
                                    PBK_Writer.WriteLine("UseRasCredentials=1");
                                    PBK_Writer.WriteLine("LowDateTime=-1406685632");
                                    PBK_Writer.WriteLine("HighDateTime=30552741");
                                    PBK_Writer.WriteLine("DialParamsUID=167606281");
                                    PBK_Writer.WriteLine("Guid=FBC982CFFD24754B9EE04E331B9FF727");
                                    PBK_Writer.WriteLine("VpnStrategy=2");
                                    PBK_Writer.WriteLine("ExcludedProtocols=0");
                                    PBK_Writer.WriteLine("LcpExtensions=1");
                                    PBK_Writer.WriteLine("DataEncryption=256");
                                    PBK_Writer.WriteLine("SwCompression=0");
                                    PBK_Writer.WriteLine("NegotiateMultilinkAlways=0");
                                    PBK_Writer.WriteLine("SkipDoubleDialDialog=0");
                                    PBK_Writer.WriteLine("DialMode=0");
                                    PBK_Writer.WriteLine("OverridePref=15");
                                    PBK_Writer.WriteLine("RedialAttempts=3");
                                    PBK_Writer.WriteLine("RedialSeconds=60");
                                    PBK_Writer.WriteLine("IdleDisconnectSeconds=0");
                                    PBK_Writer.WriteLine("RedialOnLinkFailure=1");
                                    PBK_Writer.WriteLine("CallbackMode=0");
                                    PBK_Writer.WriteLine("CustomDialDll=");
                                    PBK_Writer.WriteLine("CustomDialFunc=");
                                    PBK_Writer.WriteLine("CustomRasDialDll=");
                                    PBK_Writer.WriteLine("ForceSecureCompartment=0");
                                    PBK_Writer.WriteLine("DisableIKENameEkuCheck=0");
                                    PBK_Writer.WriteLine("AuthenticateServer=0");
                                    PBK_Writer.WriteLine("ShareMsFilePrint=1");
                                    PBK_Writer.WriteLine("BindMsNetClient=1");
                                    PBK_Writer.WriteLine("SharedPhoneNumbers=0");
                                    PBK_Writer.WriteLine("GlobalDeviceSettings=0");
                                    PBK_Writer.WriteLine("PrerequisiteEntry=");
                                    PBK_Writer.WriteLine("PrerequisitePbk=");
                                    PBK_Writer.WriteLine("PreferredPort=VPN3-0");
                                    PBK_Writer.WriteLine("PreferredDevice=WAN Miniport (PPTP)");
                                    PBK_Writer.WriteLine("PreferredBps=0");
                                    PBK_Writer.WriteLine("PreferredHwFlow=1");
                                    PBK_Writer.WriteLine("PreferredProtocol=1");
                                    PBK_Writer.WriteLine("PreferredCompression=1");
                                    PBK_Writer.WriteLine("PreferredSpeaker=1");
                                    PBK_Writer.WriteLine("PreferredMdmProtocol=0");
                                    PBK_Writer.WriteLine("PreviewUserPw=1");
                                    PBK_Writer.WriteLine("PreviewDomain=1");
                                    PBK_Writer.WriteLine("PreviewPhoneNumber=0");
                                    PBK_Writer.WriteLine("ShowDialingProgress=1");
                                    PBK_Writer.WriteLine("ShowMonitorIconInTaskBar=1");
                                    PBK_Writer.WriteLine("CustomAuthKey=0");
                                    PBK_Writer.WriteLine("AuthRestrictions=544");
                                    PBK_Writer.WriteLine("IpPrioritizeRemote=1");
                                    PBK_Writer.WriteLine("IpInterfaceMetric=0");
                                    PBK_Writer.WriteLine("IpHeaderCompression=0");
                                    PBK_Writer.WriteLine("IpAddress=0.0.0.0");
                                    PBK_Writer.WriteLine("IpDnsAddress=0.0.0.0");
                                    PBK_Writer.WriteLine("IpDns2Address=0.0.0.0");
                                    PBK_Writer.WriteLine("IpWinsAddress=0.0.0.0");
                                    PBK_Writer.WriteLine("IpWins2Address=0.0.0.0");
                                    PBK_Writer.WriteLine("IpAssign=1");
                                    PBK_Writer.WriteLine("IpNameAssign=1");
                                    PBK_Writer.WriteLine("IpDnsFlags=0");
                                    PBK_Writer.WriteLine("IpNBTFlags=1");
                                    PBK_Writer.WriteLine("TcpWindowSize=0");
                                    PBK_Writer.WriteLine("UseFlags=2");
                                    PBK_Writer.WriteLine("IpSecFlags=0");
                                    PBK_Writer.WriteLine("IpDnsSuffix=");
                                    PBK_Writer.WriteLine("Ipv6Assign=1");
                                    PBK_Writer.WriteLine("Ipv6Address=::");
                                    PBK_Writer.WriteLine("Ipv6PrefixLength=0");
                                    PBK_Writer.WriteLine("Ipv6PrioritizeRemote=1");
                                    PBK_Writer.WriteLine("Ipv6InterfaceMetric=0");
                                    PBK_Writer.WriteLine("TESIpv6NameAssign=1T");
                                    PBK_Writer.WriteLine("Ipv6DnsAddress=::");
                                    PBK_Writer.WriteLine("Ipv6Dns2Address=::");
                                    PBK_Writer.WriteLine("Ipv6Prefix=0000000000000000");
                                    PBK_Writer.WriteLine("Ipv6InterfaceId=0000000000000000");
                                    PBK_Writer.WriteLine("DisableClassBasedDefaultRoute=0");
                                    PBK_Writer.WriteLine("DisableMobility=0");
                                    PBK_Writer.WriteLine("NetworkOutageTime=1800");
                                    PBK_Writer.WriteLine("ProvisionType=0");
                                    PBK_Writer.WriteLine("PreSharedKey=");
                                    PBK_Writer.WriteLine("NETCOMPONENTS=");
                                    PBK_Writer.WriteLine("ms_msclient=1");
                                    PBK_Writer.WriteLine("ms_server=1");
                                    PBK_Writer.WriteLine("MEDIA=rastapi");
                                    PBK_Writer.WriteLine("Port=VPN3-0");
                                    PBK_Writer.WriteLine("Device=WAN Miniport (PPTP)");
                                    PBK_Writer.WriteLine("DEVICE=vpn");
                                    PBK_Writer.WriteLine("PhoneNumber=" + Vpn_IP + "");
                                    PBK_Writer.WriteLine("AreaCode=");
                                    PBK_Writer.WriteLine("CountryCode=0");
                                    PBK_Writer.WriteLine("CountryID=0");
                                    PBK_Writer.WriteLine("UseDialingRules=0");
                                    PBK_Writer.WriteLine("Comment=");
                                    PBK_Writer.WriteLine("FriendlyName=");
                                    PBK_Writer.WriteLine("LastSelectedPhone=0");
                                    PBK_Writer.WriteLine("PromoteAlternates=0");
                                    PBK_Writer.WriteLine("TryNextAlternateOnFail=1");
                                }

                                {///// Закрыть поток. Иначе не сохранит.
                                    PBK_Writer.Close();
                                }

                            }

                            {
                                string Con_Dial = ("rasdial " + @"""" + Vpn_Name + @"""" + " " + Vpn_Login + " " + Vpn_Pass + " " + "/phonebook:" + @"""" + PBK_File + @"""");
                                ProcessStartInfo Connect_Process = new ProcessStartInfo("cmd.exe", "/C " + Con_Dial);
                                // Process Connect_Process = new Process(); ///старый коннект
                                Connect_Process.WindowStyle = ProcessWindowStyle.Hidden;
                                Connect_Process.RedirectStandardOutput = true;
                                Connect_Process.UseShellExecute = false;
                                Connect_Process.CreateNoWindow = true;
                                //запуск процесса
                                Process New_Connect_Process = Process.Start(Connect_Process);
                                //получить ответ
                                StreamReader str_incom = New_Connect_Process.StandardOutput;
                                //выводим результат
                                Console.WriteLine(str_incom.ReadToEnd());
                                //закрыть процесс
                                New_Connect_Process.WaitForExit();
                                Console.Read();

                            }
                        }
                    }
                }
            }
            catch
            {
                //Thread.Sleep(2000);
                MessageBox.Show("Вероятей всего, у Вас пропало соденинение с интернетом\nПроверьте соединение и запуститие программу заново", "Ошибка" ,MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1,MessageBoxOptions.ServiceNotification);
                    Application.Exit();
                
            }
        }

        internal void OnApplicationExit()
        {
            throw new NotImplementedException();
        }

        void Nigga_Work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) //Когда закончил
        {
            
            if (e.Cancelled)
            {
                inf_lbl.Text = "Отмена";
                Application.Exit();
            }
            else if (e.Error != null)
            {
                inf_lbl.Text = "Ошибка во время потока";
                Application.Exit();
            }
            else
            {

                Ping ping_local = new Ping();
                PingReply reply_local = ping_local.Send(ServMySQL);
                status_local = reply_local.Status;
                if (status_local == IPStatus.Success)
                {
                    
                    inf_lbl.Text = "Подключено! Базы пингуются";

                    //открыть форму Login
                    string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Program Data"
                    string rkiu_folder = MyDoc + "\\RKIU"; ///// 
                    string user_data = rkiu_folder + @"\user"; ///// 
                    {

                        if (File.Exists(user_data) == true)

                            using (StreamReader USR_Reader = new StreamReader(user_data, Encoding.Default))
                            {
                                //////string line;

                                ////while ((line = USR_Reader.ReadLine()) != null)

                                ////    if (line.IndexOf("rkiu") > -1)
                                ////    {


                                string[] Mass = File.ReadAllLines(user_data, Encoding.Default);


                                MySqlConnection CHK_on_VPN = new MySqlConnection(connStr);
                                CHK_on_VPN.Open();
                                MySqlCommand CHK_VPN = new MySqlCommand("SELECT CHK FROM dpo.users_dpo where GRP = " + "'" + Mass[0] + "'" + " and " + "FAM = " + "'" + Mass[1] + "'" + " and " + "PASS = " + "'" + Mass[2] + "'" + ";", CHK_on_VPN);
                                MySqlDataReader comb_chk = CHK_VPN.ExecuteReader();
                                while (comb_chk.Read())
                                {
                                    string table1 = comb_chk.GetString(0);
                                    this.CHK_on_VPN.Text = table1.ToString();
                                }
                                comb_chk.Close();

                                if (this.CHK_on_VPN.Text == "1")
                                {
                                    
                                    F_RDP Form_RDP = new F_RDP();
                                    Form_RDP.Show();
                                    this.Hide();
                                }
                                else if (this.CHK_on_VPN.Text == "0")
                                {
                                    
                                    MessageBox.Show("Отчислен");
                                    Application.Exit();
                                   // Login Form_LOGIN = new Login();                           //Переавторизация...
                                   // Form_LOGIN.Show();
                                   // this.Hide();
                                }
                            }
                        else
                        {
                            Login LOGIN = new Login();
                            this.Hide();
                            LOGIN.Show();
                        }
                    }           
                }
                else
                {
                    MessageBox.Show("Ошибка. Завершение работы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    Application.Exit();
                }
            }
        }

        private void VPN_Load(object sender, EventArgs e)
        {
            NW.RunWorkerAsync();
            //Pic_Box.Image = Image.FromFile("C:/gears.gif");
            Pic_Box.Image = RGKIU_VCH.Properties.Resources.gears;
            inf_lbl.Text = "Подключение к серверам RKIU...";
        } //Для пользователся. Индикация загрузки

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //// Нужно сделать отключение только подключенного соединения
            string Con_RasDial = "rasdial /d";
            ProcessStartInfo Disconnect_Process = new ProcessStartInfo("cmd.exe", "/C " + Con_RasDial);
            Disconnect_Process.WindowStyle = ProcessWindowStyle.Hidden;
            Disconnect_Process.RedirectStandardOutput = true;
            Disconnect_Process.UseShellExecute = false;
            Disconnect_Process.CreateNoWindow = true;
            //запуск процесса
            Process New_Disconnect_Process = Process.Start(Disconnect_Process);
            //получить ответ
            StreamReader str_incom = New_Disconnect_Process.StandardOutput;
            //выводим результат
            Console.WriteLine(str_incom.ReadToEnd());
            //закрыть процесс
            New_Disconnect_Process.WaitForExit();
            Console.Read();



            ////////string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            ////////string rkiu_folder = MyDoc + "\\RKIU";
            ////////string BAT_File_Disconnect = rkiu_folder + @"\disconnect.bat";
            ////////{
            ////////    if

            ////////    (File.Exists(BAT_File_Disconnect) == false) ;
            ////////    FileStream BAT_Text = new FileStream(BAT_File_Disconnect, FileMode.Create);
            ////////    StreamWriter BAT_Writer = new StreamWriter(BAT_Text);
            ////////    //BAT_Writer.WriteLine("@echo off");
            ////////    //BAT_Writer.Write("start /min ");
            ////////    BAT_Writer.Write("rasdial/d");
            ////////    BAT_Writer.Close();

            ////////}
            ////////ProcessStartInfo Disconnect_Process = new ProcessStartInfo(BAT_File_Disconnect);
            ////////Disconnect_Process.WindowStyle = ProcessWindowStyle.Hidden;
            ////////Disconnect_Process.RedirectStandardOutput = true;
            ////////Disconnect_Process.UseShellExecute = false;
            ////////Disconnect_Process.CreateNoWindow = true;
            //////////запуск процесса
            ////////Process New_Disconnect_Process = Process.Start(Disconnect_Process);
            //////////получить ответ
            ////////StreamReader str_incom = New_Disconnect_Process.StandardOutput;
            //////////выводим результат
            ////////Console.WriteLine(str_incom.ReadToEnd());
            //////////закрыть процесс
            ////////New_Disconnect_Process.WaitForExit();
            ////////Console.Read();
            ///////////////ньюконфиг_конец
        }
    }
}

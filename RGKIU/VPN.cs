using MySql.Data.MySqlClient;
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

        IPStatus status_global = IPStatus.TimedOut;
        IPStatus status_local = IPStatus.TimedOut;
        IPStatus status_local_2 = IPStatus.TimedOut;
        
        string global_ping = @"ya.ru"; //Для пинга на ВЦ
        string ServMySQL = @"192.168.1.1"; //Для пинга на ВЦ
        string connStr = "server=" + "192.168.1.1" + ";user=" + "mysql_user" + ";database=" + "dpo" + ";port=" + "3306" + ";password=" + "208406" + "; CharSet = utf8;";//Для подключения на ВЦ
        public VPN()
        {
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        private void VPN_Load(object sender, EventArgs e)
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




            if (status_local == IPStatus.Success)
            {

                MessageBox.Show("Ты в локалке.");

            }
            else if (status_global == IPStatus.Success)
            {
                //MessageBox.Show("Инет есть. Интернет. Запуск ВПН");
                ///////ньюконфиг
                {
                    string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);///// Папка "Мои документы"
                    string rkiu_folder = MyDoc + "\\RKIU"; ///// Папка "Мои документы\RKIU\"
                    string PBK_File = rkiu_folder + @"\connection.pbk"; ///// Файл "Мои документы\RKIU\connection.pbk"
                    string BAT_File_Connect = rkiu_folder + @"\connection.bat"; ///// Файл "Мои документы\RKIU\connection.bat"
                                                                                //this.Text = (rkiu_folder);

                    {///// Если не нашел Файл "Мои документы\RKIU\connection.pbk" то создать Папку "Мои документы\RKIU\" и Пустой файл "Мои документы\RKIU\connection.pbk" с записью нижеизложенного. (полный конфиг)
                        if

                        (File.Exists(PBK_File) == false)
                            Directory.CreateDirectory(rkiu_folder);
                        FileStream PBK_Text = new FileStream(PBK_File, FileMode.Create);
                        StreamWriter PBK_Writer = new StreamWriter(PBK_Text);


                        {///// Полный конфиг PBK файла.
                            PBK_Writer.WriteLine("[RKIU-VPN]");
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
                            PBK_Writer.WriteLine("PhoneNumber=109.195.230.224");
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

                    if

                    (File.Exists(BAT_File_Connect) == false) ;
                    FileStream BAT_Text = new FileStream(BAT_File_Connect, FileMode.Create);
                    StreamWriter BAT_Writer = new StreamWriter(BAT_Text);
                    //BAT_Writer.WriteLine("@echo off");
                    //BAT_Writer.Write("start /min ");
                    BAT_Writer.Write(@"rasdial ""RKIU-VPN"" ");
                    BAT_Writer.Write("vpn ");
                    BAT_Writer.Write("newsign ");
                    BAT_Writer.Write("/phonebook:");
                    BAT_Writer.Write(@"""");
                    BAT_Writer.Write(PBK_File);
                    BAT_Writer.Write(@"""");
                    BAT_Writer.Close();


                    ProcessStartInfo Connect_Process = new ProcessStartInfo(BAT_File_Connect);
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
                ///////ньюконфиг_конец
                
            }
            Ping ping_local_2 = new Ping();
            PingReply reply_local_2 = ping_local_2.Send(ServMySQL, 10000);
            status_local_2 = reply_local_2.Status;
            if (status_local_2 == IPStatus.Success)
            {

               // MessageBox.Show("Пинг прошел");
                {
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();

                    MySqlCommand GRP = new MySqlCommand("SELECT GRP FROM dpo.users_dpo where CHK = '1' group by GRP;", conn);
                    MySqlDataReader comb_grp = GRP.ExecuteReader();

                    while (comb_grp.Read())
                    {

                        string table1 = comb_grp.GetString(0);
                        comboBox1.Items.Add(table1);
                    }
                    comb_grp.Close();
                }
            }
            else
            {
                MessageBox.Show("Пинг не прошел");
                Application.Exit();
            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            ///////ньюконфиг2
            string MyDoc = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string rkiu_folder = MyDoc + "\\RKIU";
            string BAT_File_Disconnect = rkiu_folder + @"\disconnect.bat";
            {
                if

                (File.Exists(BAT_File_Disconnect) == false) ;
                FileStream BAT_Text = new FileStream(BAT_File_Disconnect, FileMode.Create);
                StreamWriter BAT_Writer = new StreamWriter(BAT_Text);
                //BAT_Writer.WriteLine("@echo off");
                //BAT_Writer.Write("start /min ");
                BAT_Writer.Write("rasdial/d");
                BAT_Writer.Close();

            }
            ProcessStartInfo Disconnect_Process = new ProcessStartInfo(BAT_File_Disconnect);
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
            ///////ньюконфиг_конец
            MessageBox.Show("Досвидули");
        }
    }
}

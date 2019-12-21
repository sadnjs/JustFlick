using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 봉순봇
{
    public partial class Login : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "nBj8udcmN6j965YzDsfMbO674ZfPacwocxfVP7zV",
            BasePath = "https://goldsex-d69d4.firebaseio.com/"

        };

        IFirebaseClient client;

        private Point mousePoint;

        public Login()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcesses())
            {
                //프로그램명으로 시작되는 프로세스를 모두 죽인다. 엉뚱한 프로세스를 죽이지 않게 IF문을 잘 사용한다.
                if (process.ProcessName.ToUpper().StartsWith("ㅇㄴㅁㄹ"))
                {
                    process.Kill();
                }
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {

            }
        }

        public string GetMyIP()
        {
            string myIP = new WebClient().DownloadString("http://ipinfo.io/ip").Trim(); //http://icanhazip.com;
            return myIP;
        }

        private async Task LoginE()
        {
            FirebaseResponse responseu = await client.GetTaskAsync($"USERLIST/{Code.Text}");
            try
            {
                Data data = responseu.ResultAs<Data>();
                int year = int.Parse(data.YTime.Substring(0, 4)),
                        month = int.Parse(data.YTime.Substring(4, 2)),
                        day = int.Parse(data.YTime.Substring(6, 2)),
                        hour = int.Parse(data.YTime.Substring(8, 2)),
                        minute = int.Parse(data.YTime.Substring(10, 2));

                DateTime nowtime = DateTime.Now;
                DateTime lefttime = new DateTime(year, month, day, hour, minute, 0);
                TimeSpan timeDiff = lefttime - nowtime;

                string sday = timeDiff.Days.ToString(),
                        shour = timeDiff.Hours.ToString(),
                        smin = timeDiff.Minutes.ToString();

                if (DateTime.Compare(lefttime, nowtime) > 0)
                {
                    Data udata = new Data
                    {
                        YTime = data.YTime,
                        ZAdress = GetMyIP()
                    };

                    await client.UpdateTaskAsync($"USERLIST/{Code.Text}", udata);
                    this.Opacity = 0;
                    if (timeDiff.Days < 10000)
                    {
                        MessageBox.Show($"남은시간 : {sday}일 {shour}시간 {smin}분");
                        Rework_Main p = new Rework_Main();
                        p.Show();
                        Hide();
                    }
                }
                else
                {
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        public async Task SignUpE()
        {
            bool zzzz = false;

            FirebaseResponse responseu = await client.GetTaskAsync("USERLIST/" + Code.Text);
            try
            {
                try
                {
                    responseu.ResultAs<Data>();
                    zzzz = true;
                }
                catch { }
                if (!zzzz)
                {
                    string codepathstr = null;
                    bool Day1 = false, Day7 = false, Day15 = false, Day30 = false;
                    FirebaseResponse coderesponse1 = await client.GetTaskAsync("1Day/" + Code.Text);
                    FirebaseResponse coderesponse7 = await client.GetTaskAsync("7Day/" + Code.Text);
                    FirebaseResponse coderesponse15 = await client.GetTaskAsync("15Day/" + Code.Text);
                    FirebaseResponse coderesponse30 = await client.GetTaskAsync("30Day/" + Code.Text);

                    try
                    {
                        coderesponse1.ResultAs<CodeData>();
                        Day1 = true;
                        codepathstr = "1Day";
                    }
                    catch { }

                    try
                    {
                        coderesponse7.ResultAs<CodeData>();
                        Day7 = true;
                        codepathstr = "7Day";
                    }
                    catch { }

                    try
                    {
                        coderesponse15.ResultAs<CodeData>();
                        Day15 = true;
                        codepathstr = "15Day";
                    }
                    catch { }

                    try
                    {
                        coderesponse30.ResultAs<CodeData>();
                        Day30 = true;
                        codepathstr = "30Day";
                    }
                    catch { }

                    if (Day1 || Day7 || Day15 || Day30)
                    {
                        string time = null;
                        if (Day1)
                        {
                            time = (DateTime.Now + TimeSpan.FromDays(1)).ToString("yyyyMMddHHmm");
                        }
                        else if (Day7)
                        {
                            time = (DateTime.Now + TimeSpan.FromDays(7)).ToString("yyyyMMddHHmm");
                        }
                        else if (Day15)
                        {
                            time = (DateTime.Now + TimeSpan.FromDays(15)).ToString("yyyyMMddHHmm");
                        }
                        else if (Day30)
                        {
                            time = (DateTime.Now + TimeSpan.FromDays(30)).ToString("yyyyMMddHHmm");
                        }

                        Data data = new Data
                        {
                            Code = Code.Text,
                            YTime = time,
                            ZAdress = GetMyIP()
                        };
                        await client.SetTaskAsync("USERLIST/" + Code.Text, data);
                        await client.DeleteTaskAsync("1Day/" + Code.Text);
                        await client.DeleteTaskAsync("7Day/" + Code.Text);
                        await client.DeleteTaskAsync("15Day/" + Code.Text);
                        await client.DeleteTaskAsync("30Day/" + Code.Text);
                        MessageBox.Show("회원가입이 완료되었습니다.");
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Code.Text != "")
                LoginE();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Code.Text != "")
                SignUpE();
        }
    }
}

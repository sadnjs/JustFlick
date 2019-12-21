using GameOverlay.Drawing;
using GameOverlay.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 봉순봇
{
    public partial class Rework_Main : Form
    {
        [DllImport("kernel32.DLL")]
        static extern void Beep(int freq, int dur);
        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(System.Windows.Forms.Keys keyCode);
        [DllImport("user32.dll")]
        static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);
        [DllImport("Rework.dll")]
        public static extern void DD_btn(int btn);
        [DllImport("Rework.dll")]
        public static extern void DD_movR(int x, int y);
        [DllImport("Rework.dll")]
        public static extern void DD_key(int ddcode, int flag);

        bool EntityStart = false, TeamChange = false, AimbotStart = false, ScanStart = false;
        Matrix viewMatrix;
        long[] FoundList, newFoundList = new long[0];
        long viewMatrixPtr;
        public Entity[] EntityList;
        public static int WX = Screen.PrimaryScreen.Bounds.Width / 2, WY = Screen.PrimaryScreen.Bounds.Height / 2,
            SX = Screen.PrimaryScreen.Bounds.Width, SY = Screen.PrimaryScreen.Bounds.Height;
        Thread AimbotThread, InsertThread, flickThread;
        long AutoShot;

        public struct Entity
        {
            public Vector3 head, foot, Location;
            public byte 생사, 팀;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        StringBuilder buff = new StringBuilder(100);

        public Rework_Main()
        {
            InitializeComponent();
            /*Location = Point.Empty;
            ClientSize = new Size(433, 335);
            new Thread(delegate ()
            {
                while (true)
                {
                    try
                    {
                        var handle = GetForegroundWindow();
                        if (handle != null)
                        {
                            if (GetWindowText(handle, buff, 100) > 0)
                            {
                                if (buff.ToString() == "오버워치" || buff.ToString() == "Overwatch")
                                {
                                    Invoke((MethodInvoker)delegate () { TopMost = true; });
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                    Thread.Sleep(10);
                }
            })
            { IsBackground = true }.Start();*/
        }

        private OverlayWindow _window;
        private Graphics _graphics;
        private SolidBrush _White;
        public SolidBrush _red;
        SolidBrush myPen;
        SolidBrush myPen2;
        SolidBrush myPen3;
        SolidBrush EnemyPointPen;
        SolidBrush LinePen;
        SolidBrush PointPen;
        SolidBrush CirclePen;
        SolidBrush DistancePen;

        private void Rework_Main_Load(object sender, EventArgs e)
        {
            RegisterHotKey((int)Handle, 0, 0x0, (int)Keys.F1);
            RegisterHotKey((int)Handle, 0, 0x0, (int)Keys.F2);
            RegisterHotKey((int)Handle, 0, 0x0, (int)Keys.F3);
            RegisterHotKey((int)Handle, 0, 0x0, (int)Keys.Insert);
            RegisterHotKey((int)Handle, 0, 0x0, (int)Keys.End);

            _window = new GameOverlay.Windows.OverlayWindow(0, 0, SX, SY)
            {
                IsTopmost = true,
                IsVisible = true
            };

            _window.CreateWindow();

            _graphics = new Graphics()
            {
                MeasureFPS = true,
                Height = _window.Height,
                PerPrimitiveAntiAliasing = true,
                TextAntiAliasing = true,
                UseMultiThreadedFactories = true,
                VSync = true,
                Width = _window.Width,
                WindowHandle = _window.Handle
            };

            _graphics.Setup();

            _red = _graphics.CreateSolidBrush(Color.Red);
            myPen = _red;
            myPen2 = _red;
            myPen3 = _red;
            PointPen = _red;
            LinePen = _graphics.CreateSolidBrush(0xFF, 0x00, 0x00, 130);
            DistancePen = _red;

            flickThread = new Thread(Trigger);
            flickThread.IsBackground = true;
            flickThread.Start();
        }

        private void HeadOffsetTrackbar_Paint(object sender, PaintEventArgs e)
        {
            HeadOffsetValue.Text = HeadOffsetTrackbar.Value.ToString();
        }

        private void RangeTrackbar_Paint(object sender, PaintEventArgs e)
        {
            RangeValue.Text = RangeTrackbar.Value.ToString();
        }

        private void XTrackbar_Paint(object sender, PaintEventArgs e)
        {
            XValue.Text = XTrackbar.Value.ToString();
        }

        private void YTrackbar_Paint(object sender, PaintEventArgs e)
        {
            YValue.Text = YTrackbar.Value.ToString();
        }

        private void ThTrackbar_Paint(object sender, PaintEventArgs e)
        {
            ThValue.Text = ThTrackbar.Value.ToString();
        }

        private void FhTrackbar_Paint(object sender, PaintEventArgs e)
        {
            FhValue.Text = FhTrackbar.Value.ToString();
        }

        private void ModeValue_Click(object sender, EventArgs e)
        {
            if (ModeValue.Text == "Tracking")
            {
                ModeValue.Text = "Flick";
            }
            else if (ModeValue.Text == "Flick")
            {
                ModeValue.Text = "Prediction";
            }
            else if (ModeValue.Text == "Prediction")
            {
                ModeValue.Text = "Tracking";
            }
        }

        private void ZoomOutValue_Click(object sender, EventArgs e)
        {
            if (ZoomOutValue.Text == "OFF")
            {
                ZoomOutValue.Text = "ON";
            }
            else
            {
                ZoomOutValue.Text = "OFF";
            }
        }

        private void EspValue_Click(object sender, EventArgs e)
        {
            if (EspValue.Text == "OFF")
            {
                EspValue.Text = "ON";
            }
            else
            {
                EspValue.Text = "OFF";
            }
        }

        private void B1Value_Click(object sender, EventArgs e)
        {
            if (B1Value.Text == "OFF")
            {
                B1Value.Text = "ON";
            }
            else
            {
                B1Value.Text = "OFF";
            }
        }

        private void B2Value_Click(object sender, EventArgs e)
        {
            if (B2Value.Text == "OFF")
            {
                B2Value.Text = "ON";
            }
            else
            {
                B2Value.Text = "OFF";
            }
        }

        private void B3Value_Click(object sender, EventArgs e)
        {
            if (B3Value.Text == "OFF")
            {
                B3Value.Text = "ON";
            }
            else
            {
                B3Value.Text = "OFF";
            }
        }

        private void DValue_Click(object sender, EventArgs e)
        {
            if (DValue.Text == "OFF")
            {
                DValue.Text = "ON";
            }
            else
            {
                DValue.Text = "OFF";
            }
        }

        private void LValue_Click(object sender, EventArgs e)
        {
            if (LValue.Text == "OFF")
            {
                LValue.Text = "ON";
            }
            else
            {
                LValue.Text = "OFF";
            }
        }

        private void PValue_Click(object sender, EventArgs e)
        {
            if (PValue.Text == "OFF")
            {
                PValue.Text = "ON";
            }
            else
            {
                PValue.Text = "OFF";
            }
        }

        private void B1Color_MouseClick(object sender, MouseEventArgs e)
        {
            B1C.ShowDialog();
            B1Color.BackColor = B1C.Color;
            myPen = _graphics.CreateSolidBrush(new Color(B1C.Color.R, B1C.Color.G, B1C.Color.B));
        }

        private void B2Color_MouseClick(object sender, MouseEventArgs e)
        {
            B2C.ShowDialog();
            B2Color.BackColor = B2C.Color;
            myPen2 = _graphics.CreateSolidBrush(new Color(B2C.Color.R, B2C.Color.G, B2C.Color.B));
        }

        private void B3Color_MouseClick(object sender, MouseEventArgs e)
        {
            B3C.ShowDialog();
            B3Color.BackColor = B3C.Color;
            myPen3 = _graphics.CreateSolidBrush(new Color(B3C.Color.R, B3C.Color.G, B3C.Color.B));
        }

        private void DColor_MouseClick(object sender, MouseEventArgs e)
        {
            DC.ShowDialog();
            DColor.BackColor = DC.Color;
            DistancePen = _graphics.CreateSolidBrush(new Color(DC.Color.R, DC.Color.G, DC.Color.B));
        }

        private void LColor_MouseClick(object sender, MouseEventArgs e)
        {
            LC.ShowDialog();
            LColor.BackColor = LC.Color;
            LinePen = _graphics.CreateSolidBrush(LC.Color.R, LC.Color.G, LC.Color.B, 130);
        }

        private void PColor_MouseClick(object sender, MouseEventArgs e)
        {
            PC.ShowDialog();
            PColor.BackColor = PC.Color;
            PointPen = _graphics.CreateSolidBrush(new Color(PC.Color.R, PC.Color.G, PC.Color.B));
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);

                if (Keys.F1 == key)
                {
                    if (ScanStart == false)
                    {
                        InsertThread = new Thread(MainThread);
                        InsertThread.IsBackground = true;
                        InsertThread.Start();
                        ScanStart = true;
                    }
                    else
                    {
                        InsertThread.Abort();
                        InsertThread = new Thread(MainThread);
                        InsertThread.IsBackground = true;
                        InsertThread.Start();
                    }
                }

                if (Keys.F2 == key)
                {
                    if (AimbotStart == false)
                    {
                        AimbotThread = new Thread(MouseTracker);
                        AimbotThread.IsBackground = true;
                        AimbotThread.Start();
                        AimbotStart = true;
                        Beep(640, 300);
                    }
                    else if (AimbotStart == true)
                    {
                        AimbotThread.Abort();
                        Beep(440, 300);
                        AimbotStart = false;
                    }
                }

                if (Keys.F3 == key)
                {
                    if (TeamChange == false)
                    {
                        TeamChange = true;
                    }
                    else if (TeamChange == true)
                    {
                        TeamChange = false;
                    }
                }

                if (Keys.Insert == key)
                {
                    MemoryHelper.OpenProcess("Overwatch");
                    MemoryHelper.SetRgSize(0x400000);
                    AutoShot = MemoryHelper.FindPatternExReg(Offsets.Autoshot, "xxxxxxxxxxx");
                    MemoryHelper.ReadMemory<int>(AutoShot - 0x44, 4);
                    Beep(1000, 200);
                }

                if (Keys.End == key)
                {
                    System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("봉순봇");
                    if (p.GetLength(0) > 0)
                        p[0].Kill();
                }
            }
            base.WndProc(ref m);
        }

        bool Key;

        void MouseTracker()
        {
            while (true)
            {
                Key = GetAsyncKeyState(Keys.LButton);
                Vector2 d = GetAimEnemy();
                Vector2 u = GetAimRange();
                if (d.x != 0 && d.y != 0)
                {
                    if (ModeValue.Text == "Flick")
                    {
                        if (FhTrackbar.Value == 1)
                        {
                            if (Key)
                            {
                                double mouseX = d.x * (XTrackbar.Value / 20.0) * 8 / (30.0 / 4.0);
                                double mouseY = d.y * (YTrackbar.Value / 20.0) * 8 / (30.0 / 4.0);
                                DD_movR((int)mouseX, (int)mouseY);
                                DD_key(106, 1);
                                Thread.Sleep(1);
                                DD_key(106, 2);
                                if (ZoomOutValue.Text == "ON")
                                {
                                    DD_btn(4);
                                    Thread.Sleep(1);
                                    DD_btn(8);
                                }
                                Thread.Sleep(400);
                            }
                            else
                                Index = -1;
                            Thread.Sleep(1);
                        }
                        else
                        {
                            if (Key)
                            {
                                double mouseX = d.x * (XTrackbar.Value / 50.0) / (30.0 / 5.0);
                                double mouseY = d.y * (YTrackbar.Value / 50.0) / (30.0 / 5.0);
                                DD_movR((int)mouseX, (int)mouseY);
                                if (u.x != 0 && u.y != 0)
                                {
                                    DD_key(106, 1);
                                    Thread.Sleep(1);
                                    DD_key(106, 2);
                                    if (ZoomOutValue.Text == "ON")
                                    {
                                        DD_btn(4);
                                        Thread.Sleep(1);
                                        DD_btn(8);
                                    }
                                }
                            }
                            else
                                Index = -1;
                            Thread.Sleep(1);
                        }
                    }
                    else if (ModeValue.Text == "Tracking")
                    {
                        if (Key)
                        {
                            double mouseX = d.x * (XTrackbar.Value / 50.0) / (ThTrackbar.Value / 5.0);
                            double mouseY = d.y * (YTrackbar.Value / 50.0) / (ThTrackbar.Value / 5.0);
                            DD_movR((int)mouseX, (int)mouseY);
                        }
                        else
                            Index = -1;
                        Thread.Sleep(1);
                    }
                    else if (ModeValue.Text == "Prediction")
                    {
                        double predictionX = d.x;
                        double predictionY = d.y;

                        if (GetAsyncKeyState(Keys.MButton))
                        {
                            double mouseX = d.x + (d.x - predictionX) * (XTrackbar.Value / 20.0) * 9 / (30.0 / 4.0);
                            double mouseY = d.y + (d.y - predictionY) * (YTrackbar.Value / 20.0) * 9 / (30.0 / 4.0);
                            DD_movR((int)mouseX, (int)mouseY);
                            DD_key(106, 1);
                            Thread.Sleep(1);
                            DD_key(106, 2);
                            Thread.Sleep(400);
                        }
                    }
                }
            }
        }

        void Trigger()
        {
            Thread.Sleep(0);
            while (true)
            {
                int snipe;
                int Filter1 = MemoryHelper.ReadMemory<int>(AutoShot - 0x46, 1),
                    Filter2 = MemoryHelper.ReadMemory<int>(AutoShot - 0x47, 1);
                snipe = MemoryHelper.ReadMemory<int>(AutoShot - 0x44, 1);
                if (GetAsyncKeyState(Keys.RButton) && snipe == 128 && (Filter1 >= 2 || Filter1 == 1 && Filter2 >= 100))
                {
                    DD_btn(1);
                    Thread.Sleep(1);
                    DD_btn(2);
                    Thread.Sleep(1);
                    Application.DoEvents();
                }
            }
        }

        private void ThreadInit()
        {
            try
            {
                EntityStart = false;

                MemoryHelper.OpenProcess("Overwatch");

                MemoryHelper.SetRgSize(0x1000000);
                viewMatrixPtr = MemoryHelper.ReadMemory<long>(MemoryHelper.ReadMemory<long>(MemoryHelper.BaseAddress + 0x2EBDE50, sizeof(long)) + 0x8, sizeof(long)) + 0x80;
                viewMatrix = MemoryHelper.ReadMatrix(viewMatrixPtr);

                ScanEntity();
                EntityStart = true;
                new Thread(ESP).Start();
                new Thread(AutoSearch_).Start();
                Beep(1000, 200);
            }
            catch
            {
                EntityStart = false;
                Beep(1000, 100);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ESP()
        {
            while (EspValue.Text == "ON")
            {
                try
                {
                    _graphics.BeginScene();
                    _graphics.ClearScene();
                    GameOverlay.Drawing.Font font = _graphics.CreateFont("맑은 고딕", 9f, true, false, false);
                    EnemyPointPen = _graphics.CreateSolidBrush(255, 255, 255);
                    for (var i = 0; i < EntityList.Length; i++)
                    {
                        if (EntityList[i].생사 == 20 &&
                            ((EntityList[i].팀 == 8 && TeamChange) || (EntityList[i].팀 != 8 && !TeamChange)))
                        {
                            Vector3 worldPos = new Vector3(this.EntityList[i].head.x, this.EntityList[i].head.y, this.EntityList[i].head.z);
                            Vector3 worldPos2 = new Vector3(this.EntityList[i].head.x, this.EntityList[i].head.y, this.EntityList[i].head.z - 1f);
                            Vector3 worldPos3 = new Vector3(this.EntityList[i].head.x, this.EntityList[i].head.y - 2f, this.EntityList[i].head.z);
                            Vector3 worldPos4 = new Vector3(this.EntityList[i].head.x, this.EntityList[i].head.y - 2f, this.EntityList[i].head.z - 1f);
                            Vector3 worldPos5 = new Vector3(this.EntityList[i].head.x - 1f, this.EntityList[i].head.y, this.EntityList[i].head.z);
                            Vector3 worldPos6 = new Vector3(this.EntityList[i].head.x - 1f, this.EntityList[i].head.y, this.EntityList[i].head.z - 1f);
                            Vector3 worldPos7 = new Vector3(this.EntityList[i].head.x - 1f, this.EntityList[i].head.y - 2f, this.EntityList[i].head.z);
                            Vector3 worldPos8 = new Vector3(this.EntityList[i].head.x - 1f, this.EntityList[i].head.y - 2f, this.EntityList[i].head.z - 1f);
                            Vector2 vector;
                            Vector2 vector2;
                            Vector2 vector3;
                            Vector2 vector4;
                            Vector2 vector5;
                            Vector2 vector6;
                            Vector2 vector7;
                            Vector2 vector8;
                            Vector2 vector9;
                            Vector2 vector10;
                            if (viewMatrix.WorldToScreen(this.EntityList[i].head, SX, SY, out vector) && this.viewMatrix.WorldToScreen(this.EntityList[i].foot, SX, SY, out vector2) && this.viewMatrix.WorldToScreen(worldPos, SX, SY, out vector3) && this.viewMatrix.WorldToScreen(worldPos2, SX, SY, out vector4) && this.viewMatrix.WorldToScreen(worldPos3, SX, SY, out vector5) && this.viewMatrix.WorldToScreen(worldPos4, SX, SY, out vector6) && this.viewMatrix.WorldToScreen(worldPos5, SX, SY, out vector7) && this.viewMatrix.WorldToScreen(worldPos6, SX, SY, out vector8) && this.viewMatrix.WorldToScreen(worldPos7, SX, SY, out vector9) && this.viewMatrix.WorldToScreen(worldPos8, SX, SY, out vector10))
                            {
                                int num = Screen.PrimaryScreen.Bounds.Width - 835;
                                float num2 = Math.Abs(vector.y - vector2.y);
                                float num3 = (vector.x + vector2.x) / 2f;
                                float num4 = vector.y + num2 / HeadOffsetTrackbar.Value;
                                float num5 = vector.y + num2 / 2f;
                                float num6 = (float)(1500 / (int)num2);

                                if (B1Value.Text == "ON")
                                {
                                    _graphics.DrawRoundedRectangle(myPen, RoundedRectangle.Create(num3 - num2 / 4, vector.y, num2 / 2, num2, 1), 1);
                                }

                                if (B2Value.Text == "ON")
                                {
                                    Draw3DBox(_graphics, myPen2, new Vector2[] { vector, vector2, vector3, vector4, vector5, vector6, vector7, vector8, vector9, vector10 }, 1f);
                                }

                                if (B3Value.Text == "ON")
                                {
                                    Draw_Edge(num3, num5, num2, 2f, _graphics, myPen3);
                                }

                                if (DValue.Text == "ON")
                                {
                                    _graphics.DrawText(font, 11f, DistancePen, num3 - 13f, vector2.y, "[" + num6 + "M]");
                                }

                                if(LValue.Text == "ON")
                                {
                                    _graphics.DrawLine(LinePen, WX, num, num3, vector2.y, 4);
                                }

                                if (PValue.Text == "ON")
                                {
                                    _graphics.FillCircle(PointPen, new Circle(new Point(num3, num4), num2 / 30));
                                }
                            }
                        }
                    }

                    _graphics.EndScene();
                }
                catch { }


                Thread.Sleep(10);
            }
        }

        public static void Draw3DBox(Graphics g, SolidBrush Pen, Vector2[] p, float stroke)
        {
            g.DrawLine(Pen, new Line(new Point(p[3].x, p[3].y), new Point(p[2].x, p[2].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[2].x, p[2].y), new Point(p[4].x, p[4].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[3].x, p[3].y), new Point(p[5].x, p[5].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[5].x, p[5].y), new Point(p[4].x, p[4].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[6].x, p[6].y), new Point(p[2].x, p[2].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[6].x, p[6].y), new Point(p[8].x, p[8].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[8].x, p[8].y), new Point(p[4].x, p[4].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[7].x, p[7].y), new Point(p[6].x, p[6].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[7].x, p[7].y), new Point(p[9].x, p[9].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[9].x, p[9].y), new Point(p[8].x, p[8].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[7].x, p[7].y), new Point(p[3].x, p[3].y)), stroke);
            g.DrawLine(Pen, new Line(new Point(p[9].x, p[9].y), new Point(p[5].x, p[5].y)), stroke);
        }

        private void Draw_Edge(float xpos, float ypos, float size, float stroke, Graphics g, SolidBrush EnemyPen)
        {
            float num = 7f;
            float num2 = 2.5f;
            g.DrawLine(EnemyPen, new Line(new Point(xpos - size / 4f, ypos - size / 2f), new Point(xpos - size / 4f, ypos - size / num2)), stroke);
            g.DrawLine(EnemyPen, new Line(new Point(xpos - size / 4f, ypos - size / 2f), new Point(xpos - size / num, ypos - size / 2f)), stroke);
            g.DrawLine(EnemyPen, new Line(new Point(xpos + size / 4f, ypos - size / 2f), new Point(xpos + size / 4f, ypos - size / num2)), stroke);
            g.DrawLine(EnemyPen, new Line(new Point(xpos + size / 4f, ypos - size / 2f), new Point(xpos + size / num, ypos - size / 2f)), stroke);
            g.DrawLine(EnemyPen, new Line(new Point(xpos - size / 4f, ypos + size / 2f), new Point(xpos - size / 4f, ypos + size / num2)), stroke);
            g.DrawLine(EnemyPen, new Line(new Point(xpos - size / 4f, ypos + size / 2f), new Point(xpos - size / num, ypos + size / 2f)), stroke);
            g.DrawLine(EnemyPen, new Line(new Point(xpos + size / 4f, ypos + size / 2f), new Point(xpos + size / 4f, ypos + size / num2)), stroke);
            g.DrawLine(EnemyPen, new Line(new Point(xpos + size / 4f, ypos + size / 2f), new Point(xpos + size / num, ypos + size / 2f)), stroke);
        }

        void AutoSearch_()
        {
            while (EntityStart)
            {
                ScanEntity();
                Thread.Sleep(200);
            }
        }

        private void MainThread()
        {
            ThreadInit();
            while (EntityStart)
            {
                for (var i = 0; i < EntityList.Length; i++)
                {
                    try
                    {
                        EntityList[i].head = MemoryHelper.ReadVector3(FoundList[i] - 0x8C);
                        EntityList[i].foot = new Vector3(EntityList[i].head.x - 1f, EntityList[i].head.y - 2f, EntityList[i].head.z - 1f);
                        EntityList[i].Location = MemoryHelper.ReadVector3(FoundList[i] - 140L);
                        EntityList[i].생사 = MemoryHelper.ReadMemory<byte>(FoundList[i] - 0x1, 1);
                        EntityList[i].팀 = MemoryHelper.ReadMemory<byte>(FoundList[i] - 0x4, 1);
                    }
                    catch { }
                }
                viewMatrix = MemoryHelper.ReadMatrix(viewMatrixPtr);

                Thread.Sleep(1);
            }
        }

        private void ScanEntity()
        {
            MemoryHelper.SetRgSize(0x180000);
            long pat = MemoryHelper.FindPatternExReg(Offsets.EntityArray, "xxxx??xx?xxx?xxxxxxxxxxxx");
            if (pat > 0)
            {
                foreach (MemoryHelper.MEMORY_BASIC_INFORMATION64 region in MemoryHelper.mbis)
                {
                    if ((long)region.BaseAddress < pat && pat - (long)region.BaseAddress < (long)region.RegionSize)
                    {
                        pat = (long)region.BaseAddress;
                    }
                }
                byte[] buf = MemoryHelper.Read(pat, 0x180000);
                long[] entities = MemoryHelper.FindPatterns(buf, Offsets.EntityArray, "xxxx??xx?xxx?xxxxxxxxxxxx");
                bool haschanged = false;
                FoundList = entities;
                for (var i = 0; i < entities.Length; i++)
                {
                    entities[i] += pat;
                }
                if (entities.Length != FoundList.Length)
                {
                    haschanged = true;
                }
                else
                {
                    for (int i = 0; i < entities.Length; i++)
                    {
                        if (entities[i] != FoundList[i])
                        {
                            haschanged = true;
                        }
                    }
                }
                if (haschanged)
                {
                    newFoundList = entities;
                }
            }
            else
            {
                FoundList = new long[0];
            }

            EntityList = new Entity[FoundList.Length];
        }

        int Index = -1;

        private Vector2 GetAimEnemy()
        {
            Vector2 target = new Vector2(0, 0);
            Vector2 crossHair = new Vector2(WX, WY);
            try
            {
                if (Index != -1)
                {
                    if (EntityList[Index].생사 == 20 && ((EntityList[Index].팀 != 8 && !TeamChange) || (EntityList[Index].팀 == 8 && TeamChange)))
                    {
                        if (viewMatrix.WorldToScreen(EntityList[Index].head, SX, SY, out Vector2 hp) &&
                           viewMatrix.WorldToScreen(EntityList[Index].foot, SX, SY, out Vector2 fp))
                        {
                            float size = Math.Abs(hp.y - fp.y);
                            float xpos = (hp.x + fp.x) / 2;
                            float ypos = hp.y + size / HeadOffsetTrackbar.Value;

                            int nesDist = (int)crossHair.Distance(new Vector2(xpos, ypos));

                            if (nesDist < RangeTrackbar.Value)
                                target = new Vector2(xpos - MousePosition.X, ypos - MousePosition.Y);
                            else
                                Index = -1;
                        }
                        else
                            Index = -1;
                    }
                    else
                        Index = -1;
                }
                else
                {
                    int[] list = new int[EntityList.Length];

                    for (int i = 0; i < EntityList.Length; i++)
                    {
                        if (((EntityList[i].팀 != 8 && !TeamChange) || (EntityList[i].팀 == 8 && TeamChange)) &&
                            EntityList[i].생사 == 20 && viewMatrix.WorldToScreen(EntityList[i].head, SX, SY, out Vector2 hop) &&
                            viewMatrix.WorldToScreen(EntityList[i].foot, SX, SY, out Vector2 fop))
                        {
                            float size = Math.Abs(hop.y - fop.y);
                            float xpos = (hop.x + fop.x) / 2;
                            float ypos = hop.y + size / HeadOffsetTrackbar.Value;

                            int nesDist = (int)crossHair.Distance(new Vector2(xpos, ypos));

                            if (nesDist < RangeTrackbar.Value)
                            {
                                list[i] = nesDist;
                            }
                            else
                                list[i] = 9999;
                        }
                        else
                            list[i] = 9999;
                    }

                    int indexmin = list.ToList().IndexOf(list.Min());

                    if (list[indexmin] != 9999 &&
                        viewMatrix.WorldToScreen(EntityList[indexmin].head, SX, SY, out Vector2 hp) &&
                        viewMatrix.WorldToScreen(EntityList[indexmin].foot, SX, SY, out Vector2 fp))
                    {
                        float size = Math.Abs(hp.y - fp.y);
                        float xpos = (hp.x + fp.x) / 2;
                        float ypos = hp.y + size / HeadOffsetTrackbar.Value;

                        int nesDist = (int)Math.Round((Math.Abs(xpos - WX) + Math.Abs(ypos - WY)) / 2.0);

                        target = new Vector2(xpos - MousePosition.X, ypos - MousePosition.Y);
                        Index = indexmin;
                    }
                }
                return target;
            }
            catch
            {
                Index = -1;
                return target;
            }
        }

        private Vector2 GetAimRange()
        {
            Vector2 target = new Vector2(0, 0);
            Vector2 crossHair = new Vector2(WX, WY);
            try
            {
                if (Index != -1)
                {
                    if (EntityList[Index].생사 == 20 && ((EntityList[Index].팀 != 8 && !TeamChange) || (EntityList[Index].팀 == 8 && TeamChange)))
                    {
                        if (viewMatrix.WorldToScreen(EntityList[Index].head, SX, SY, out Vector2 hp) &&
                           viewMatrix.WorldToScreen(EntityList[Index].foot, SX, SY, out Vector2 fp))
                        {
                            float size = Math.Abs(hp.y - fp.y);
                            float xpos = (hp.x + fp.x) / 2;
                            float ypos = hp.y + size / HeadOffsetTrackbar.Value;

                            int nesDist = (int)crossHair.Distance(new Vector2(xpos, ypos));

                            if (nesDist < FhTrackbar.Value)
                                target = new Vector2(xpos - MousePosition.X, ypos - MousePosition.Y);
                            else
                                Index = -1;
                        }
                        else
                            Index = -1;
                    }
                    else
                        Index = -1;
                }
                else
                {
                    int[] list = new int[EntityList.Length];

                    for (int i = 0; i < EntityList.Length; i++)
                    {
                        if (((EntityList[i].팀 != 8 && !TeamChange) || (EntityList[i].팀 == 8 && TeamChange)) &&
                            EntityList[i].생사 == 20 && viewMatrix.WorldToScreen(EntityList[i].head, SX, SY, out Vector2 hop) &&
                            viewMatrix.WorldToScreen(EntityList[i].foot, SX, SY, out Vector2 fop))
                        {
                            float size = Math.Abs(hop.y - fop.y);
                            float xpos = (hop.x + fop.x) / 2;
                            float ypos = hop.y + size / HeadOffsetTrackbar.Value;

                            int nesDist = (int)crossHair.Distance(new Vector2(xpos, ypos));

                            if (nesDist < FhTrackbar.Value)
                            {
                                list[i] = nesDist;
                            }
                            else
                                list[i] = 9999;
                        }
                        else
                            list[i] = 9999;
                    }

                    int indexmin = list.ToList().IndexOf(list.Min());

                    if (list[indexmin] != 9999 &&
                        viewMatrix.WorldToScreen(EntityList[indexmin].head, SX, SY, out Vector2 hp) &&
                        viewMatrix.WorldToScreen(EntityList[indexmin].foot, SX, SY, out Vector2 fp))
                    {
                        float size = Math.Abs(hp.y - fp.y);
                        float xpos = (hp.x + fp.x) / 2;
                        float ypos = hp.y + size / HeadOffsetTrackbar.Value;

                        int nesDist = (int)Math.Round((Math.Abs(xpos - WX) + Math.Abs(ypos - WY)) / 2.0);

                        target = new Vector2(xpos - MousePosition.X, ypos - MousePosition.Y);
                        Index = indexmin;
                    }
                }
                return target;
            }
            catch
            {
                Index = -1;
                return target;
            }
        }
    }
}

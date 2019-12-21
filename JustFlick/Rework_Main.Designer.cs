namespace 봉순봇
{
    partial class Rework_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rework_Main));
            this.DragPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.HeadOffsetValue = new System.Windows.Forms.Label();
            this.XValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RangeValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.YValue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ThValue = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ModeValue = new System.Windows.Forms.Label();
            this.ZoomOutValue = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.EspValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B1Value = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.B2Value = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.B3Value = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.B1Color = new System.Windows.Forms.Panel();
            this.B2Color = new System.Windows.Forms.Panel();
            this.B3Color = new System.Windows.Forms.Panel();
            this.PColor = new System.Windows.Forms.Panel();
            this.LColor = new System.Windows.Forms.Panel();
            this.DColor = new System.Windows.Forms.Panel();
            this.PValue = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.LValue = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.DValue = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.FhValue = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.FhTrackbar = new 봉순봇.CustomTrackbar();
            this.ThTrackbar = new 봉순봇.CustomTrackbar();
            this.YTrackbar = new 봉순봇.CustomTrackbar();
            this.XTrackbar = new 봉순봇.CustomTrackbar();
            this.HeadOffsetTrackbar = new 봉순봇.CustomTrackbar();
            this.RangeTrackbar = new 봉순봇.CustomTrackbar();
            this.B1C = new System.Windows.Forms.ColorDialog();
            this.B2C = new System.Windows.Forms.ColorDialog();
            this.B3C = new System.Windows.Forms.ColorDialog();
            this.DC = new System.Windows.Forms.ColorDialog();
            this.LC = new System.Windows.Forms.ColorDialog();
            this.PC = new System.Windows.Forms.ColorDialog();
            this.DragPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DragPanel
            // 
            this.DragPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(43)))));
            this.DragPanel.Controls.Add(this.label1);
            this.DragPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DragPanel.Location = new System.Drawing.Point(0, 0);
            this.DragPanel.Name = "DragPanel";
            this.DragPanel.Size = new System.Drawing.Size(433, 29);
            this.DragPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "봉순봇";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Head Offset : ";
            // 
            // HeadOffsetValue
            // 
            this.HeadOffsetValue.AutoSize = true;
            this.HeadOffsetValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.HeadOffsetValue.ForeColor = System.Drawing.Color.White;
            this.HeadOffsetValue.Location = new System.Drawing.Point(109, 43);
            this.HeadOffsetValue.Name = "HeadOffsetValue";
            this.HeadOffsetValue.Size = new System.Drawing.Size(15, 17);
            this.HeadOffsetValue.TabIndex = 3;
            this.HeadOffsetValue.Text = "5";
            // 
            // XValue
            // 
            this.XValue.AutoSize = true;
            this.XValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.XValue.ForeColor = System.Drawing.Color.White;
            this.XValue.Location = new System.Drawing.Point(109, 133);
            this.XValue.Name = "XValue";
            this.XValue.Size = new System.Drawing.Size(22, 17);
            this.XValue.TabIndex = 6;
            this.XValue.Text = "60";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "X Sensitivity : ";
            // 
            // RangeValue
            // 
            this.RangeValue.AutoSize = true;
            this.RangeValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.RangeValue.ForeColor = System.Drawing.Color.White;
            this.RangeValue.Location = new System.Drawing.Point(76, 88);
            this.RangeValue.Name = "RangeValue";
            this.RangeValue.Size = new System.Drawing.Size(29, 17);
            this.RangeValue.TabIndex = 9;
            this.RangeValue.Text = "200";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(11, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Range : ";
            // 
            // YValue
            // 
            this.YValue.AutoSize = true;
            this.YValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.YValue.ForeColor = System.Drawing.Color.White;
            this.YValue.Location = new System.Drawing.Point(107, 178);
            this.YValue.Name = "YValue";
            this.YValue.Size = new System.Drawing.Size(22, 17);
            this.YValue.TabIndex = 12;
            this.YValue.Text = "50";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(11, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Y Sensitivity : ";
            // 
            // ThValue
            // 
            this.ThValue.AutoSize = true;
            this.ThValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.ThValue.ForeColor = System.Drawing.Color.White;
            this.ThValue.Location = new System.Drawing.Point(157, 223);
            this.ThValue.Name = "ThValue";
            this.ThValue.Size = new System.Drawing.Size(22, 17);
            this.ThValue.TabIndex = 15;
            this.ThValue.Text = "30";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(10, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "Tracking Humanizer : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Mode : ";
            // 
            // ModeValue
            // 
            this.ModeValue.AutoSize = true;
            this.ModeValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModeValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.ModeValue.ForeColor = System.Drawing.Color.White;
            this.ModeValue.Location = new System.Drawing.Point(73, 320);
            this.ModeValue.Name = "ModeValue";
            this.ModeValue.Size = new System.Drawing.Size(59, 17);
            this.ModeValue.TabIndex = 17;
            this.ModeValue.Text = "Tracking";
            this.ModeValue.Click += new System.EventHandler(this.ModeValue_Click);
            // 
            // ZoomOutValue
            // 
            this.ZoomOutValue.AutoSize = true;
            this.ZoomOutValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZoomOutValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.ZoomOutValue.ForeColor = System.Drawing.Color.White;
            this.ZoomOutValue.Location = new System.Drawing.Point(187, 344);
            this.ZoomOutValue.Name = "ZoomOutValue";
            this.ZoomOutValue.Size = new System.Drawing.Size(30, 17);
            this.ZoomOutValue.TabIndex = 21;
            this.ZoomOutValue.Text = "OFF";
            this.ZoomOutValue.Click += new System.EventHandler(this.ZoomOutValue_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(11, 344);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "ZoomOut (Widow, Ashe) : ";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.DragPanel;
            this.bunifuDragControl1.Vertical = true;
            // 
            // EspValue
            // 
            this.EspValue.AutoSize = true;
            this.EspValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EspValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.EspValue.ForeColor = System.Drawing.Color.White;
            this.EspValue.Location = new System.Drawing.Point(59, 397);
            this.EspValue.Name = "EspValue";
            this.EspValue.Size = new System.Drawing.Size(30, 17);
            this.EspValue.TabIndex = 23;
            this.EspValue.Text = "OFF";
            this.EspValue.Click += new System.EventHandler(this.EspValue_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(11, 397);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "ESP : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(43)))));
            this.panel1.Location = new System.Drawing.Point(0, 373);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 10);
            this.panel1.TabIndex = 24;
            // 
            // B1Value
            // 
            this.B1Value.AutoSize = true;
            this.B1Value.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B1Value.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.B1Value.ForeColor = System.Drawing.Color.White;
            this.B1Value.Location = new System.Drawing.Point(81, 424);
            this.B1Value.Name = "B1Value";
            this.B1Value.Size = new System.Drawing.Size(30, 17);
            this.B1Value.TabIndex = 26;
            this.B1Value.Text = "OFF";
            this.B1Value.Click += new System.EventHandler(this.B1Value_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(11, 424);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "2D Box : ";
            // 
            // B2Value
            // 
            this.B2Value.AutoSize = true;
            this.B2Value.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B2Value.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.B2Value.ForeColor = System.Drawing.Color.White;
            this.B2Value.Location = new System.Drawing.Point(81, 452);
            this.B2Value.Name = "B2Value";
            this.B2Value.Size = new System.Drawing.Size(30, 17);
            this.B2Value.TabIndex = 28;
            this.B2Value.Text = "OFF";
            this.B2Value.Click += new System.EventHandler(this.B2Value_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(11, 452);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 17);
            this.label13.TabIndex = 27;
            this.label13.Text = "3D Box : ";
            // 
            // B3Value
            // 
            this.B3Value.AutoSize = true;
            this.B3Value.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B3Value.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.B3Value.ForeColor = System.Drawing.Color.White;
            this.B3Value.Location = new System.Drawing.Point(95, 479);
            this.B3Value.Name = "B3Value";
            this.B3Value.Size = new System.Drawing.Size(30, 17);
            this.B3Value.TabIndex = 30;
            this.B3Value.Text = "OFF";
            this.B3Value.Click += new System.EventHandler(this.B3Value_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(11, 479);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 17);
            this.label15.TabIndex = 29;
            this.label15.Text = "Edge Box : ";
            // 
            // B1Color
            // 
            this.B1Color.BackColor = System.Drawing.Color.Red;
            this.B1Color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B1Color.Location = new System.Drawing.Point(163, 425);
            this.B1Color.Name = "B1Color";
            this.B1Color.Size = new System.Drawing.Size(15, 15);
            this.B1Color.TabIndex = 31;
            this.B1Color.MouseClick += new System.Windows.Forms.MouseEventHandler(this.B1Color_MouseClick);
            // 
            // B2Color
            // 
            this.B2Color.BackColor = System.Drawing.Color.Red;
            this.B2Color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B2Color.Location = new System.Drawing.Point(163, 452);
            this.B2Color.Name = "B2Color";
            this.B2Color.Size = new System.Drawing.Size(15, 15);
            this.B2Color.TabIndex = 32;
            this.B2Color.MouseClick += new System.Windows.Forms.MouseEventHandler(this.B2Color_MouseClick);
            // 
            // B3Color
            // 
            this.B3Color.BackColor = System.Drawing.Color.Red;
            this.B3Color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B3Color.Location = new System.Drawing.Point(163, 480);
            this.B3Color.Name = "B3Color";
            this.B3Color.Size = new System.Drawing.Size(15, 15);
            this.B3Color.TabIndex = 33;
            this.B3Color.MouseClick += new System.Windows.Forms.MouseEventHandler(this.B3Color_MouseClick);
            // 
            // PColor
            // 
            this.PColor.BackColor = System.Drawing.Color.Red;
            this.PColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PColor.Location = new System.Drawing.Point(404, 480);
            this.PColor.Name = "PColor";
            this.PColor.Size = new System.Drawing.Size(15, 15);
            this.PColor.TabIndex = 42;
            this.PColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PColor_MouseClick);
            // 
            // LColor
            // 
            this.LColor.BackColor = System.Drawing.Color.Red;
            this.LColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LColor.Location = new System.Drawing.Point(404, 452);
            this.LColor.Name = "LColor";
            this.LColor.Size = new System.Drawing.Size(15, 15);
            this.LColor.TabIndex = 41;
            this.LColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LColor_MouseClick);
            // 
            // DColor
            // 
            this.DColor.BackColor = System.Drawing.Color.Red;
            this.DColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DColor.Location = new System.Drawing.Point(404, 425);
            this.DColor.Name = "DColor";
            this.DColor.Size = new System.Drawing.Size(15, 15);
            this.DColor.TabIndex = 40;
            this.DColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DColor_MouseClick);
            // 
            // PValue
            // 
            this.PValue.AutoSize = true;
            this.PValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.PValue.ForeColor = System.Drawing.Color.White;
            this.PValue.Location = new System.Drawing.Point(322, 479);
            this.PValue.Name = "PValue";
            this.PValue.Size = new System.Drawing.Size(30, 17);
            this.PValue.TabIndex = 39;
            this.PValue.Text = "OFF";
            this.PValue.Click += new System.EventHandler(this.PValue_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(239, 479);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 17);
            this.label17.TabIndex = 38;
            this.label17.Text = "Point ESP : ";
            // 
            // LValue
            // 
            this.LValue.AutoSize = true;
            this.LValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.LValue.ForeColor = System.Drawing.Color.White;
            this.LValue.Location = new System.Drawing.Point(322, 452);
            this.LValue.Name = "LValue";
            this.LValue.Size = new System.Drawing.Size(30, 17);
            this.LValue.TabIndex = 37;
            this.LValue.Text = "OFF";
            this.LValue.Click += new System.EventHandler(this.LValue_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(245, 452);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 17);
            this.label19.TabIndex = 36;
            this.label19.Text = "Line ESP : ";
            // 
            // DValue
            // 
            this.DValue.AutoSize = true;
            this.DValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.DValue.ForeColor = System.Drawing.Color.White;
            this.DValue.Location = new System.Drawing.Point(322, 424);
            this.DValue.Name = "DValue";
            this.DValue.Size = new System.Drawing.Size(30, 17);
            this.DValue.TabIndex = 35;
            this.DValue.Text = "OFF";
            this.DValue.Click += new System.EventHandler(this.DValue_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(219, 424);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(97, 17);
            this.label21.TabIndex = 34;
            this.label21.Text = "Distance ESP : ";
            // 
            // FhValue
            // 
            this.FhValue.AutoSize = true;
            this.FhValue.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.FhValue.ForeColor = System.Drawing.Color.White;
            this.FhValue.Location = new System.Drawing.Point(131, 267);
            this.FhValue.Name = "FhValue";
            this.FhValue.Size = new System.Drawing.Size(22, 17);
            this.FhValue.TabIndex = 45;
            this.FhValue.Text = "30";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(10, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 17);
            this.label10.TabIndex = 44;
            this.label10.Text = "Flick Humanizer : ";
            // 
            // FhTrackbar
            // 
            this.FhTrackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.FhTrackbar.Location = new System.Drawing.Point(11, 274);
            this.FhTrackbar.Max = 50;
            this.FhTrackbar.Min = 1;
            this.FhTrackbar.Name = "FhTrackbar";
            this.FhTrackbar.Size = new System.Drawing.Size(409, 47);
            this.FhTrackbar.TabIndex = 43;
            this.FhTrackbar.Value = 30;
            this.FhTrackbar.Paint += new System.Windows.Forms.PaintEventHandler(this.FhTrackbar_Paint);
            // 
            // ThTrackbar
            // 
            this.ThTrackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.ThTrackbar.Location = new System.Drawing.Point(11, 229);
            this.ThTrackbar.Max = 100;
            this.ThTrackbar.Min = 1;
            this.ThTrackbar.Name = "ThTrackbar";
            this.ThTrackbar.Size = new System.Drawing.Size(409, 47);
            this.ThTrackbar.TabIndex = 13;
            this.ThTrackbar.Value = 30;
            this.ThTrackbar.Paint += new System.Windows.Forms.PaintEventHandler(this.ThTrackbar_Paint);
            // 
            // YTrackbar
            // 
            this.YTrackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.YTrackbar.Location = new System.Drawing.Point(12, 184);
            this.YTrackbar.Max = 100;
            this.YTrackbar.Min = 1;
            this.YTrackbar.Name = "YTrackbar";
            this.YTrackbar.Size = new System.Drawing.Size(409, 47);
            this.YTrackbar.TabIndex = 10;
            this.YTrackbar.Value = 50;
            this.YTrackbar.Paint += new System.Windows.Forms.PaintEventHandler(this.YTrackbar_Paint);
            // 
            // XTrackbar
            // 
            this.XTrackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.XTrackbar.Location = new System.Drawing.Point(11, 139);
            this.XTrackbar.Max = 100;
            this.XTrackbar.Min = 1;
            this.XTrackbar.Name = "XTrackbar";
            this.XTrackbar.Size = new System.Drawing.Size(409, 47);
            this.XTrackbar.TabIndex = 4;
            this.XTrackbar.Value = 60;
            this.XTrackbar.Paint += new System.Windows.Forms.PaintEventHandler(this.XTrackbar_Paint);
            // 
            // HeadOffsetTrackbar
            // 
            this.HeadOffsetTrackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.HeadOffsetTrackbar.Location = new System.Drawing.Point(11, 49);
            this.HeadOffsetTrackbar.Max = 10;
            this.HeadOffsetTrackbar.Min = 1;
            this.HeadOffsetTrackbar.Name = "HeadOffsetTrackbar";
            this.HeadOffsetTrackbar.Size = new System.Drawing.Size(409, 47);
            this.HeadOffsetTrackbar.TabIndex = 1;
            this.HeadOffsetTrackbar.Value = 5;
            this.HeadOffsetTrackbar.Paint += new System.Windows.Forms.PaintEventHandler(this.HeadOffsetTrackbar_Paint);
            // 
            // RangeTrackbar
            // 
            this.RangeTrackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.RangeTrackbar.Location = new System.Drawing.Point(11, 94);
            this.RangeTrackbar.Max = 1000;
            this.RangeTrackbar.Min = 1;
            this.RangeTrackbar.Name = "RangeTrackbar";
            this.RangeTrackbar.Size = new System.Drawing.Size(409, 47);
            this.RangeTrackbar.TabIndex = 7;
            this.RangeTrackbar.Value = 200;
            this.RangeTrackbar.Paint += new System.Windows.Forms.PaintEventHandler(this.RangeTrackbar_Paint);
            // 
            // B1C
            // 
            this.B1C.Color = System.Drawing.Color.Red;
            // 
            // B2C
            // 
            this.B2C.Color = System.Drawing.Color.Red;
            // 
            // B3C
            // 
            this.B3C.Color = System.Drawing.Color.Red;
            // 
            // DC
            // 
            this.DC.Color = System.Drawing.Color.Red;
            // 
            // LC
            // 
            this.LC.Color = System.Drawing.Color.Red;
            // 
            // PC
            // 
            this.PC.Color = System.Drawing.Color.Red;
            // 
            // Rework_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(47)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(433, 509);
            this.Controls.Add(this.FhValue);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.FhTrackbar);
            this.Controls.Add(this.PColor);
            this.Controls.Add(this.LColor);
            this.Controls.Add(this.DColor);
            this.Controls.Add(this.PValue);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.LValue);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.DValue);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.B3Color);
            this.Controls.Add(this.B2Color);
            this.Controls.Add(this.B1Color);
            this.Controls.Add(this.B3Value);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.B2Value);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.B1Value);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EspValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ZoomOutValue);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ModeValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ThValue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ThTrackbar);
            this.Controls.Add(this.YValue);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.YTrackbar);
            this.Controls.Add(this.RangeValue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.XValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.XTrackbar);
            this.Controls.Add(this.HeadOffsetValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HeadOffsetTrackbar);
            this.Controls.Add(this.DragPanel);
            this.Controls.Add(this.RangeTrackbar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "봉순봇";
            this.Opacity = 0.95D;
            this.Text = "봉순봇";
            this.Load += new System.EventHandler(this.Rework_Main_Load);
            this.DragPanel.ResumeLayout(false);
            this.DragPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel DragPanel;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private CustomTrackbar HeadOffsetTrackbar;
        private System.Windows.Forms.Label HeadOffsetValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label XValue;
        private System.Windows.Forms.Label label5;
        private CustomTrackbar XTrackbar;
        private System.Windows.Forms.Label YValue;
        private System.Windows.Forms.Label label9;
        private CustomTrackbar YTrackbar;
        private System.Windows.Forms.Label RangeValue;
        private System.Windows.Forms.Label label7;
        private CustomTrackbar RangeTrackbar;
        private System.Windows.Forms.Label ThValue;
        private System.Windows.Forms.Label label11;
        private CustomTrackbar ThTrackbar;
        private System.Windows.Forms.Label ZoomOutValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label ModeValue;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label EspValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel B3Color;
        private System.Windows.Forms.Panel B2Color;
        private System.Windows.Forms.Panel B1Color;
        private System.Windows.Forms.Label B3Value;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label B2Value;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label B1Value;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel PColor;
        private System.Windows.Forms.Panel LColor;
        private System.Windows.Forms.Panel DColor;
        private System.Windows.Forms.Label PValue;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label LValue;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label DValue;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label FhValue;
        private System.Windows.Forms.Label label10;
        private CustomTrackbar FhTrackbar;
        private System.Windows.Forms.ColorDialog B1C;
        private System.Windows.Forms.ColorDialog B2C;
        private System.Windows.Forms.ColorDialog B3C;
        private System.Windows.Forms.ColorDialog DC;
        private System.Windows.Forms.ColorDialog LC;
        private System.Windows.Forms.ColorDialog PC;
    }
}


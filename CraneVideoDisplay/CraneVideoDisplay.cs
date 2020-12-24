using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CraneVideoDisplay
{
    public partial class CraneVideoDisplay : Form
    {
        const int WM_SYSCOMMAND = 0X112;//274
        const int SC_MAXIMIZE = 0XF030;//61488
        const int SC_MINIMIZE = 0XF020;//61472
        const int SC_RESTORE = 0XF120; //61728
        const int SC_CLOSE = 0XF060;//61536
        const int SC_RESIZE_Horizontal = 0XF002;//61442
        const int SC_RESIZE_Vertical = 0XF006;//61446
        const int SC_RESIZE_Both = 0XF008;//61448

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_SYSCOMMAND)
        //    {
        //        switch (m.WParam.ToInt32())
        //        {
        //            case SC_MAXIMIZE:
        //            case SC_RESTORE:
        //            case SC_RESIZE_Horizontal:
        //            case SC_RESIZE_Vertical:
        //            case SC_RESIZE_Both:
        //                if (WindowState == FormWindowState.Minimized)
        //                {
        //                    base.WndProc(ref m);
        //                }
        //                else
        //                {
        //                    Size beforeResizeSize = this.Size;
        //                    base.WndProc(ref m);
        //                    //窗口resize之后的大小
        //                    Size afterResizeSize = this.Size;
        //                    //获得变化比例
        //                    float percentWidth = (float)afterResizeSize.Width / beforeResizeSize.Width;
        //                    float percentHeight = (float)afterResizeSize.Height / beforeResizeSize.Height;
        //                    foreach (Control control in this.Controls)
        //                    {
        //                        //按比例改变控件大小
        //                        control.Width = (int)(control.Width * percentWidth);
        //                        control.Height = (int)(control.Height * percentHeight);
        //                        //为了不使控件之间覆盖 位置也要按比例变化
        //                        control.Left = (int)(control.Left * percentWidth);
        //                        control.Top = (int)(control.Top * percentHeight);
        //                        //改变控件字体大小
        //                        control.Font = new Font(control.Font.Name, control.Font.Size * Math.Min(percentHeight, percentHeight), control.Font.Style, control.Font.Unit);
        //                    }
        //                }
        //                break;
        //            default:
        //                base.WndProc(ref m);
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        base.WndProc(ref m);
        //    }
        //}


        public CraneVideoDisplay()
        {
            InitializeComponent();
        }
        private int UserID = -1;  //登录用户ID
        private int ChannelNum = 0;   //通道数量
        private int RealPlayHandler = -1; //实时预览句柄
        private CHCNetSDK.REALDATACALLBACK RealData = null;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        public CHCNetSDK.NET_DVR_STREAM_MODE m_struStreamMode;
        public CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;
        public CHCNetSDK.NET_DVR_PU_STREAM_URL m_struStreamURL;
        public CHCNetSDK.NET_DVR_IPCHANINFO_V40 m_struChanInfoV40;

        private void CameraLoginIn()
        {
            string ip = "192.168.1.20";
            int port = 8000;
            string user = "admin";
            string password = "a1234567";

            UserID = CHCNetSDK.NET_DVR_Login_V30(ip, port, user, password, ref DeviceInfo);


            //UserID = CHCNetSDK.NET_DVR_Login_V30("10.20.3.53", 554, "yzwl", "future2020", ref DeviceInfo);
            //rtsp://yzwl:futurecloud2020@10.20.3.53:554/H265/chi1/av_stream
        }

        private void CameraReview()
        {
            #region  Loop through multiple videos
            //CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfox;// = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            //lpPreviewInfox.hPlayWnd = pic.Handle;//预览窗口 live view window
            //lpPreviewInfox.lChannel = nowChannel;//预览的设备通道 the device channel number
            //lpPreviewInfox.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            //lpPreviewInfox.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            //lpPreviewInfox.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            //lpPreviewInfox.dwDisplayBufNum = 1; //播放库显示缓冲区最大帧数
            //                                    //IntPtr pUser = IntPtr.Zero;//用户数据 user data 
            //lpPreviewInfox.lChannel = iChannelNum[i - 1];
            //lpPreviewInfox.bPassbackRecord = false;
            //lpPreviewInfox.byNPQMode = 0;
            //lpPreviewInfox.byPreviewMode = 0;
            //lpPreviewInfox.byProtoType = 0;
            //lpPreviewInfox.byRes = null;
            //lpPreviewInfox.byRes1 = 0;
            //lpPreviewInfox.byStreamID = null;
            //lpPreviewInfox.byVideoCodingType = 0;
            //CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfox, null, pUser);
            #endregion

            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo.hPlayWnd = pic_main.Handle;//预览窗口 live view window
            lpPreviewInfo.lChannel = 33;//1;//34;//预览的设备通道 the device channel number
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;// 4;//0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo.dwDisplayBufNum = 1; //播放库显示缓冲区最大帧数
            IntPtr pUser = IntPtr.Zero;//用户数据 user data 
            CHCNetSDK.NET_DVR_RealPlay_V40(UserID, ref lpPreviewInfo, null, pUser);

            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo2 = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo2.hPlayWnd = pic_1.Handle;//预览窗口 live view window
            lpPreviewInfo2.lChannel = 34;//1;//34;//预览的设备通道 the device channel number
            lpPreviewInfo2.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo2.dwLinkMode = 0;// 4;//0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo2.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo2.dwDisplayBufNum = 1; //播放库显示缓冲区最大帧数
            CHCNetSDK.NET_DVR_RealPlay_V40(UserID, ref lpPreviewInfo2, null, pUser);

            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo3 = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo3.hPlayWnd = pic_2.Handle;//预览窗口 live view window
            lpPreviewInfo3.lChannel = 35;//1;//34;//预览的设备通道 the device channel number
            lpPreviewInfo3.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo3.dwLinkMode = 0;// 4;//0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo3.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo3.dwDisplayBufNum = 1; //播放库显示缓冲区最大帧数
            CHCNetSDK.NET_DVR_RealPlay_V40(UserID, ref lpPreviewInfo3, null, pUser);

            pic_1.MouseClick += new MouseEventHandler(PicClick);
            pic_2.MouseClick += new MouseEventHandler(PicClick);
            pic_main.MouseClick += new MouseEventHandler(PicClick);

        }

        private void PicClick(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;

            string picnow;

            if (pic != null)
            {
                picnow = pic.Name;
                if (pic.Name != "pic_main")
                {
                    PictureBox pict = new PictureBox();
                    foreach (PictureBox pictemp in pnl_main.Controls)
                    {
                        if (pictemp.Name == "pic_main")
                        {
                            pict = pictemp;
                        }
                    }

                    pnl_main.Controls.Clear();
                    pnl_main.Controls.Add(pic);

                    pic.Dock = DockStyle.Fill;

                    foreach (Control pnltemp in this.Controls)
                    {
                        if (pnltemp is Panel)
                        {
                            if (pnltemp.Name != "pnl_main")
                            {
                                if (pnltemp.Name.Substring(4, pnltemp.Name.Length - 4) == picnow.Substring(4, picnow.Length - 4))
                                {
                                    pnltemp.Controls.Clear();
                                    pnltemp.Controls.Add(pict);
                                    pict.Dock = DockStyle.Fill;
                                    pict.Name = picnow;
                                }
                            }
                        }
                    }
                }
                pic.Name = "pic_main";
            }
        }

        private void CraneVideoDisplay_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            pnl_main.Size = new Size(Convert.ToInt32(this.Width * 0.8) - 1, Convert.ToInt32(this.Height * 0.8) - 1);
            pnl_main.Location = new Point(0, 0);
            pnl_1.Size = new Size(Convert.ToInt32(this.Width * 0.2) - 1, Convert.ToInt32(this.Height * 0.2) - 1);
            pnl_1.Location = new Point(Convert.ToInt32(this.Width * 0.8) - 1, 0);
            pnl_2.Size = new Size(Convert.ToInt32(this.Width * 0.2) - 1, Convert.ToInt32(this.Height * 0.2) - 1);
            pnl_2.Location = new Point(Convert.ToInt32(this.Width * 0.8) - 1, Convert.ToInt32(this.Height * 0.2) - 1);

            string path1 = Application.StartupPath + @"\img\" + "1.jpg";
            Bitmap b1 = new Bitmap(path1);
            pic_main.Image = b1;
            pic_main.SizeMode = PictureBoxSizeMode.StretchImage;

            pic_main.Size = new Size(Convert.ToInt32(this.Width * 0.8), Convert.ToInt32(this.Height * 0.8));
            pic_main.Location = new Point(0, 0);

            string path2 = Application.StartupPath + @"\img\" + "1.jpg";
            Bitmap b2 = new Bitmap(path2);
            pic_1.Image = b2;
            pic_1.SizeMode = PictureBoxSizeMode.StretchImage;

            string path3 = Application.StartupPath + @"\img\" + "1.jpg";
            Bitmap b3 = new Bitmap(path3);
            pic_2.Image = b3;
            pic_2.SizeMode = PictureBoxSizeMode.StretchImage;

            pic_1.MouseClick += new MouseEventHandler(PicClick);
            pic_2.MouseClick += new MouseEventHandler(PicClick);
            pic_main.MouseClick += new MouseEventHandler(PicClick);

            CHCNetSDK.NET_DVR_Init();
            CameraLoginIn();
            CameraReview();

            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            int i = rd.Next(1, 3);
            textBox1.Text += i;

            if (i == 1)
            {
                foreach (Control picx in this.Controls)
                {
                    if (picx is Panel)
                    {
                        if (picx.Name == "pnl_1")
                        {
                            foreach (Control pp in picx.Controls)
                            {
                                if (pp is PictureBox)
                                {
                                    PicClick(pp, null);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Control picx in this.Controls)
                {
                    if (picx is Panel)
                    {
                        if (picx.Name == "pnl_2")
                        {
                            foreach (Control pp in picx.Controls)
                            {
                                if (pp is PictureBox)
                                {
                                    PicClick(pp, null);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

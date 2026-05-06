using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1131435_張新誠_多媒體播放器
{
    public partial class frmMediaPlayer: Form
    {
        int initWidth = 0;
        int initHeight = 0;
        Dictionary<string, Rectangle> initControl = new Dictionary<string, Rectangle>();
        public frmMediaPlayer()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "WMV files (*.wmv)|*.wmv|MP4 files(*.mp4) | *.mp4 | AVI files(*.avi) | *.avi | All files(*.*) | *.* ";
            if (ofd.ShowDialog() == DialogResult.OK)
                {
                    wmpVideo.URL = ofd.FileName;
                    wmpVideo.Ctlcontrols.stop(); // 停止
                }
        }

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.play();
            tmrPlay.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.pause();
            tmrPlay.Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.stop();
            tmrPlay.Stop();
            trbProgress.Value = 0;
            lblTime.Text = "00:00 / 00:00";
        }

        private void frmMediaPlayer_Load(object sender, EventArgs e)
        {
            wmpVideo.uiMode = "none";
            lblTime.Text = "00:00 / 00:00";
            this.initWidth = this.Width;
            this.initHeight = this.Height;

            foreach (Control ctl in this.Controls)
            {
                this.initControl.Add(ctl.Name, new Rectangle(ctl.Left, ctl.Top, ctl.Width, ctl.Height));
            }
        }

        private void tmrPlay_Tick(object sender, EventArgs e)
        {
            if (wmpVideo.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                trbProgress.Maximum = (int)wmpVideo.currentMedia.duration;

                trbProgress.Value = (int)wmpVideo.Ctlcontrols.currentPosition;

                lblTime.Text = $"{wmpVideo.Ctlcontrols.currentPositionString} / {wmpVideo.currentMedia.durationString}";
            }
        }

        private void trbProgress_Scroll(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.currentPosition = trbProgress.Value;
        }

        private void frmMediaPlayer_SizeChanged(object sender, EventArgs e)
        {
            if (initWidth == 0) return;

            double iRatioWidth = (double)this.Width / this.initWidth;
            double iRatioHeight = (double)this.Height / this.initHeight;

            foreach (Control ctl in this.Controls)
            {
                if (initControl.ContainsKey(ctl.Name))
                {
                    ctl.Left = (int)(initControl[ctl.Name].Left * iRatioWidth);
                    ctl.Top = (int)(initControl[ctl.Name].Top * iRatioHeight);
                    ctl.Width = (int)(initControl[ctl.Name].Width * iRatioWidth);
                    ctl.Height = (int)(initControl[ctl.Name].Height * iRatioHeight);
                }
            }
        }
    }
}

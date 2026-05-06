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
            lblTime.Text = "00:00 / 00:00";
        }
    }
}

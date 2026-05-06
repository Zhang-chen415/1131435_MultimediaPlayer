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
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.stop();
        }

        private void frmMediaPlayer_Load(object sender, EventArgs e)
        {
            wmpVideo.uiMode = "none";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using gClient;

namespace gClient
{
    public partial class mainFm : Form
    {
        private FrmHandler _extensions;

        public mainFm()
        {
            _extensions = new FrmHandler(this, true);
            InitializeComponent();
            new GlobalRef(this);
            SetStyle(ControlStyles.ResizeRedraw, true);           
        }

        #region Core Window Procedures 
        protected override void OnPaint(PaintEventArgs ev)
        {
            base.OnPaint(ev);

            ev.Graphics.FillRectangle(new SolidBrush(BackColor),
              new Rectangle(0, ClientSize.Height - Padding.Bottom, Width, Padding.Bottom));
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (WindowState is FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;

            MARGINS margins = new MARGINS()
            {
                leftWidth = 0,
                rightWidth = 0,
                topHeight = 0,
                bottomHeight = 1
            };

            if (m.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = PointToClient(Cursor.Position);

                if (FrmHandler.Form.TopLeft.Contains(cursor)) m.Result = (IntPtr)FrmHandler.Form.HTTOPLEFT;
                else if (FrmHandler.Form.TopRight.Contains(cursor)) m.Result = (IntPtr)FrmHandler.Form.HTTOPRIGHT;
                else if (FrmHandler.Form.BottomLeft.Contains(cursor)) m.Result = (IntPtr)FrmHandler.Form.HTBOTTOMLEFT;
                else if (FrmHandler.Form.BottomRight.Contains(cursor)) m.Result = (IntPtr)FrmHandler.Form.HTBOTTOMRIGHT;

                else if (FrmHandler.Form.Top.Contains(cursor)) m.Result = (IntPtr)FrmHandler.Form.HTTOP;
                else if (FrmHandler.Form.Left.Contains(cursor)) m.Result = (IntPtr)FrmHandler.Form.HTLEFT;
                else if (FrmHandler.Form.Right.Contains(cursor)) m.Result = (IntPtr)FrmHandler.Form.HTRIGHT;
                else if (FrmHandler.Form.Bottom.Contains(cursor)) m.Result = (IntPtr)FrmHandler.Form.HTBOTTOM;
            }


            if (_extensions != null)
            {
                _extensions.ShadowProc(ref m, Handle, margins);
                _extensions.SizeProc(ref m, this);
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                _extensions = new FrmHandler(this, true);

                if (!_extensions.AeroActive)
                    cp.ClassStyle |= (int)Constants.CS_DROPSHADOW;

                return cp;
            }
        }
        #endregion

        public class NoFocusCueButton : Button
        {
            protected override bool ShowFocusCues
            {
                get
                {
                    SetStyle(ControlStyles.Selectable, false);
                    return false;
                }
            }

        }

        private void headPnl_MouseDown(object sender, MouseEventArgs e)
        {
            FrmHandler.Form.Drag();
        }

        private void nameLbl_MouseDown(object sender, MouseEventArgs e)
        {
            FrmHandler.Form.Drag();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainFm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit gClient?",
Application.ProductName, MessageBoxButtons.YesNoCancel,
MessageBoxIcon.Question) is DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void pinBtn_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            pinBtn.BackColor = TopMost ? Color.FromArgb(51, 51, 51) : Color.FromArgb(30, 30, 30);
        }

        private void logoPic_MouseDown(object sender, MouseEventArgs e)
        {
            FrmHandler.Form.Drag();
        }

        public static string ServerUrl;
        private void LoadGame(string Server)
        {
            switch (Server)
            {
                case "classic":
                    ServerUrl = "https://classic.graalonline.com/";
                    break;
                case "era":
                    ServerUrl = "https://era.graalonline.com/";
                    break;
                case "zone":
                    ServerUrl = "https://zone.graalonline.com/";
                    break;
                case "west":
                    ServerUrl = "https://west.graalonline.com/";
                    break;
            }

            if (Cef.Browser.gameBrowser == null) Cef.Browser.Init();
            GlobalRef._clientFm.Invoke(new MethodInvoker(delegate
            {
                foreach (Control c in bodyPnl.Controls)
                    if (c.GetType().FullName == "System.Windows.Forms.Label")
                        (c as Label).Dispose();
            }));

        }

        private void classicLbl_Click(object sender, EventArgs e)
        {
            new Thread(() => LoadGame("classic")).Start();
        }

        private void eraLbl_Click(object sender, EventArgs e)
        {
            new Thread(() => LoadGame("era")).Start();
        }

        private void zoneLbl_Click(object sender, EventArgs e)
        {
            new Thread(() => LoadGame("zone")).Start();
        }

        private void westLbl_Click(object sender, EventArgs e)
        {
            new Thread(() => LoadGame("west")).Start();
        }

        private void mainFm_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) 
            {
                if (Size.Width < 450) Size = new Size(450, Size.Height);
                else if (Size.Height < 250) Size = new Size(Size.Width, 250);

                var Browser = Cef.Browser.gameBrowser;

                headPnl.Width = ClientSize.Width - 11;

                bodyPnl.Width = ClientSize.Width - 12;
                bodyPnl.Height = ClientSize.Height - GlobalRef.Client.Settings.UI.headerHeight;

                if (Cef.Browser.gameBrowser != null)
                {
                    Cef.Browser.gameBrowser.GetMainFrame().ExecuteJavaScriptAsync($"document.getElementById('unityContainer').style='width: 100%; height: {Cef.Browser.gameBrowser.Height + 1}px;';");
                }
            }
        }
    }
}

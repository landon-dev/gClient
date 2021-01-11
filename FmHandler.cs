using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gClient;

namespace gClient
{
    public class FrmHandler
    {
        private readonly System.Windows.Forms.Form _formObject = null;

        /// <summary>
        /// Window extension class constructor.
        /// </summary>
        /// <param name="target">Target form to apply properties on.</param>
        public FrmHandler(System.Windows.Forms.Form target, bool doDrag = true)
        {
            _formObject = target;

            if (doDrag)
                _formObject.MouseDown += FormObject_MouseDown;
        }

        /// <summary>
        /// Attempts to enable the undocumented DWM dark theme. If first attempt fails then we will retry with an older constant. (It won't work if you have coloured title bars.)
        /// </summary>
        public void TryEnableDarkTheme()
        {
            int value = 1;

            if (NativeMethods.DwmSetWindowAttribute(_formObject.Handle, Constants.DWMA_USE_IMMERSIVE_DARK_MODE, ref value, 4) != 0)
                NativeMethods.DwmSetWindowAttribute(_formObject.Handle, Constants.DWMA_USE_IMMERSIVE_DARK_MODE_OLD, ref value, 4);
        }

        #region Window Movement

        public void FormObject_MouseDown(object source, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();

                Type type = source.GetType().BaseType;

                if (type.FullName is "System.Windows.Forms.Form")
                {
                    NativeMethods.SendMessage(((System.Windows.Forms.Form)source).Handle, 0xA1, 0x2, 0);
                    return;
                }

                try
                {
                    Control ctrl = (Control)source;

                    NativeMethods.SendMessage(ctrl.FindForm().Handle, 0xA1, 0x2, 0);
                }
                catch
                {
                    return;
                }
            }
        }

        #endregion

        /// <summary>
        /// Checks if aero is enabled on the local machime
        /// </summary>
        /// <returns>A <see cref="bool"/> value indicating whether aero is enabled.</returns>
        public bool AeroActive
        {
            get
            {
                try
                {
                    if (Environment.OSVersion.Version.Major >= 6)
                    {
                        int enabled = 0;
                        NativeMethods.DwmIsCompositionEnabled(ref enabled);
                        return (enabled is 1);
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        #region DWM Shadow

        /// <summary>
        /// Shadow Processing Method
        /// </summary>
        /// <param name="m">WinAPI Message Reference</param>
        /// <param name="handle">Window Handle</param>
        public void ShadowProc(ref Message m, IntPtr handle)
        {
            if ((uint)m.Msg is Constants.WM_NCPAINT)
            {
                if (AeroActive)
                {
                    var attrVal = 2;
                    NativeMethods.DwmSetWindowAttribute(handle, 2, ref attrVal, 4);

                    MARGINS wMargins = new MARGINS()
                    {
                        bottomHeight = 1,
                        leftWidth = 1,
                        rightWidth = 1,
                        topHeight = 1
                    };

                    NativeMethods.DwmExtendFrameIntoClientArea(handle, ref wMargins);
                }
            }
        }

        /// <summary>
        /// Shadow Processing Method (Custom Margins)
        /// </summary>
        /// <param name="m">WinAPI Message Reference</param>
        /// <param name="handle">Window Handle</param>
        /// <param name="margins">Border Margins</param>
        public void ShadowProc(ref Message m, IntPtr handle, MARGINS margins)
        {
            if ((uint)m.Msg is Constants.WM_NCPAINT)
            {
                if (AeroActive)
                {
                    var attrVal = 2;
                    NativeMethods.DwmSetWindowAttribute(handle, 2, ref attrVal, 4);
                    NativeMethods.DwmExtendFrameIntoClientArea(handle, ref margins);
                }
            }
        }

        #endregion

        #region Window Sizing

        public const int RESIZE_HANDLE_SIZE = 5;

        /// <summary>
        /// Resize Processing Method
        /// </summary>
        /// <param name="m">Window Message Reference/param>
        /// <param name="source">Window Object</param>
        public void SizeProc(ref Message m, object source)
        {
            Type type = source.GetType().BaseType;

            if (type.FullName != "System.Windows.Forms.Form")
                return;

            System.Windows.Forms.Form window = (System.Windows.Forms.Form)source;

            if ((uint)m.Msg is Constants.WM_NCHITTEST)
            {
                if ((int)m.Result is 0x01)
                {
                    var screenPoint = new Point(m.LParam.ToInt32());
                    var clientPoint = window.PointToClient(screenPoint);

                    if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                    {
                        if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                            m.Result = (IntPtr)13;
                        else if (clientPoint.X < (window.Size.Width - RESIZE_HANDLE_SIZE))
                            m.Result = (IntPtr)12;
                        else
                            m.Result = (IntPtr)14;
                    }
                    else if (clientPoint.Y <= (window.Size.Height - RESIZE_HANDLE_SIZE))
                    {
                        if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                            m.Result = (IntPtr)10;
                        else if (clientPoint.X < (window.Size.Width - RESIZE_HANDLE_SIZE))
                            m.Result = (IntPtr)2;
                        else
                            m.Result = (IntPtr)11;
                    }
                    else
                    {
                        if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                            m.Result = (IntPtr)16;
                        else if (clientPoint.X < (window.Size.Width - RESIZE_HANDLE_SIZE))
                            m.Result = (IntPtr)15;
                        else
                            m.Result = (IntPtr)17;
                    }
                }
            }
        }

        #endregion

        public class Form
        {
            public static void Drag()
            {
                GlobalRef._clientFm.Invoke(new MethodInvoker(delegate
                {
                    if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left)
                    {
                        NativeMethods.ReleaseCapture();
                        NativeMethods.SendMessage(GlobalRef._clientFm.Handle, Constants.WM_NCLBUTTONDOWN, Constants.HT_CAPTION, 0);
                    }
                }));
            }

            public const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

            const int _ = 10;
            public static Rectangle Top { get { return new Rectangle(0, 0, GlobalRef._clientFm.ClientSize.Width, _); } }
            public static Rectangle Left { get { return new Rectangle(0, 0, _, GlobalRef._clientFm.ClientSize.Height); } }
            public static Rectangle Bottom { get { return new Rectangle(0, GlobalRef._clientFm.ClientSize.Height - _, GlobalRef._clientFm.ClientSize.Width, _); } }
            public static Rectangle Right { get { return new Rectangle(GlobalRef._clientFm.ClientSize.Width - _, 0, _, GlobalRef._clientFm.ClientSize.Height); } }

            public static Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
            public static Rectangle TopRight { get { return new Rectangle(GlobalRef._clientFm.ClientSize.Width - _, 0, _, _); } }
            public static Rectangle BottomLeft { get { return new Rectangle(0, GlobalRef._clientFm.ClientSize.Height - _, _, _); } }
            public static Rectangle BottomRight { get { return new Rectangle(GlobalRef._clientFm.ClientSize.Width - _, GlobalRef._clientFm.ClientSize.Height - _, _, _); } }

        }


    }

}
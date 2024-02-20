﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Everything_Handhelds_Tool.OSK
{
    /// <summary>
    /// Interaction logic for OSK.xaml
    /// </summary>
    public partial class OSK : Window
    {
        public OSK()
        {
            InitializeComponent();

            SetLocation();
            ShowWindowAndLoadKeyboardPageInFrame();
        }


        #region handle interprocess post messages here AND making the app non focusable

        //used in non focus app
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);


            SetWindowAsNonFocusable();
        }


        private void SetWindowAsNonFocusable()
        {
            //set app as non focusable 
            var helper = new WindowInteropHelper(this);
            SetWindowLong(helper.Handle, GWL_EXSTYLE,
                GetWindowLong(helper.Handle, GWL_EXSTYLE) | WS_EX_NOACTIVATE);
        }




        #endregion
        public void ShowWindowAndLoadKeyboardPageInFrame()
        {
            if (this.Visibility != Visibility.Visible)
            {
                this.Visibility = Visibility.Visible;
                frame.Source = new Uri("Keyboards\\QWERTY.xaml", UriKind.RelativeOrAbsolute);
            }


        }
        public void UnloadPageAndHideWindow()
        {
            frame.Content = null;
            frame.Source = null;

        }

        private void SetLocation()
        {
            this.Width = SystemParameters.FullPrimaryScreenWidth;
            this.Height = Math.Round(SystemParameters.PrimaryScreenHeight * 0.5, 0);
            this.Top = SystemParameters.PrimaryScreenHeight - Math.Round(SystemParameters.PrimaryScreenHeight * 0.5, 0);


        }
    }
}

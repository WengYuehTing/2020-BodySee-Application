﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BodySee.Windows;

namespace BodySee.Tools
{
    class WindowsHandler
    {
        // Toolbar's width equals to screen width * WRATIO
        public static double WRATIO = 0.2f;

        // Toolbar's height equals to screen height * HATIO
        public static double HRATIO = 0.15f;

        // Definition of screen touch mode.
        public static ScreenTouchMode ScreenTouchMode = ScreenTouchMode.Normal;

        #region Window Controls
        public static void CloseWindow(IntPtr hwnd)
        {
            if (hwnd != IntPtr.Zero)
            {
                Console.WriteLine("Close Window:" + GetWindowTitle(hwnd));
                WinApiManager.SendMessage(hwnd, WinApiManager.WM_CLOSE, 0, IntPtr.Zero);
            }
        }

        public static void MinimizeWindow(IntPtr hwnd)
        {
            if (hwnd != IntPtr.Zero)
            {
                Console.WriteLine("Minimize Window: " + GetWindowTitle(hwnd));
                WinApiManager.SendMessage(hwnd, WinApiManager.WM_SYSCOMMAND, WinApiManager.SC_MINIMIZE, IntPtr.Zero);
            }
        }

        public static void MaximizeWindow(IntPtr hwnd)
        {
            if (hwnd != IntPtr.Zero)
            {
                Console.WriteLine("Maximize Window: " + GetWindowTitle(hwnd));
                WinApiManager.SendMessage(hwnd, WinApiManager.WM_SYSCOMMAND, WinApiManager.SC_MAXIMIZE, IntPtr.Zero);
            }
        }

        public static void RestoreWindow(IntPtr hwnd)
        {
            if (hwnd != IntPtr.Zero)
            {
                Console.WriteLine("Restore Window: " + GetWindowTitle(hwnd));
                WinApiManager.SendMessage(hwnd, WinApiManager.WM_SYSCOMMAND, WinApiManager.SC_RESTORE, IntPtr.Zero);
            }
        }

        public static void ShowWindow(IntPtr hwnd)
        {
            if(hwnd != IntPtr.Zero)
            {
                Console.WriteLine("Show Window: " + GetWindowTitle(hwnd));
                WinApiManager.ShowWindow(hwnd, WinApiManager.SW_SHOW);
            }
        }

        public static void MoveWindow(IntPtr hwnd, int xOffset, int yOffset)
        {
            if (hwnd != IntPtr.Zero)
            {
                WinApiManager.RECT rect = new WinApiManager.RECT();
                WinApiManager.GetWindowRect(hwnd, out rect);
                int width = Math.Abs(rect.Right - rect.Left);
                int height = Math.Abs(rect.Bottom - rect.Top);
                int x = Math.Max(0 - width / 2, Math.Min((int)WindowsHandler.GetScreenWidth() + width / 2, rect.Left + xOffset));
                int y = Math.Max(0, Math.Min((int)WindowsHandler.GetScreenHeight(), rect.Top + yOffset));
                WinApiManager.SetWindowPos(hwnd, IntPtr.Zero, x, y, 0, 0, WinApiManager.SWP_NOSIZE | WinApiManager.SWP_NOACTIVATE | WinApiManager.SWP_NOZORDER | WinApiManager.SWP_SHOWWINDOW);
            }
        }

        public static void ScaleWindow(IntPtr hwnd, double xRatio, double yRatio)
        {
            if (hwnd != IntPtr.Zero)
            {
                WinApiManager.RECT rect = new WinApiManager.RECT();
                WinApiManager.GetWindowRect(hwnd, out rect);
                int width = Math.Abs(rect.Right - rect.Left);
                int height = Math.Abs(rect.Bottom - rect.Top);
                int x = rect.Left;
                int y = rect.Top;
                int cx = x + width / 2;
                int cy = y + height / 2;
                int nWidth = (int)((double)width * xRatio);
                int nHeight = (int)((double)height * yRatio);
                int nx = cx - nWidth / 2;
                int ny = cy - nHeight / 2;
                WinApiManager.SetWindowPos(hwnd, IntPtr.Zero, x, y, nWidth, nHeight, WinApiManager.SWP_NOACTIVATE | WinApiManager.SWP_NOZORDER | WinApiManager.SWP_SHOWWINDOW);
            }
        }

        public static void ReturnToDesktop()
        {
            Shell32.Shell shell = new Shell32.Shell();
            shell.ToggleDesktop();
            //foreach(Window window in Application.Current.Windows)
            //{
            //    if(window.Title == "Menu" && window.WindowState == WindowState.Minimized)
            //    {
            //        window.WindowState = WindowState.Normal;
            //    }
            //}
        }
        #endregion


        #region Enabled/Disable Screen Touch 
        /// <summary>
        /// Trigger while a user faces to screen. 
        /// </summary>
        public static void BlockingScreenTouch()
        {
            ScreenTouchMode = ScreenTouchMode.Blocking;

            if (!IsWindowOpen<BlockingWindow>())
            {
                BlockingWindow win = new BlockingWindow();
                win.Show();
            }
        }

        public static void AcquirePriortyofScreenTouch()
        {
            ScreenTouchMode = ScreenTouchMode.BlockingAndGesture;

            if (!IsWindowOpen<GestureWindow>())
            {
                GestureWindow win = new GestureWindow();
                win.Show();
            }
        }

        public static void RecoverScreenTouch()
        {
            ScreenTouchMode = ScreenTouchMode.Normal;
            if (IsWindowOpen<BlockingWindow>() || IsWindowOpen<GestureWindow>())
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.Title == "BlockingWindow" || window.Title == "GestureWindow")
                    {
                        window.Close();
                    }
                }
            }
        }
        #endregion

        #region Find Active/Topmost Windows

        public static bool IsAltTabWindow(IntPtr hwnd)
        {
            const uint WS_EX_TOOLWINDOW = 0x00000080;
            const uint DWMWA_CLOAKED = 14;

            if (!WinApiManager.IsWindowVisible(hwnd)) return false;

            string title = GetWindowTitle(hwnd);
            if (title == null || title == "Menu" || title == "GestureWindow" || title == "BlockingWindow" || title == "AppList") return false;

            WinApiManager.WINDOWINFO winInfo = new WinApiManager.WINDOWINFO(true);
            WinApiManager.GetWindowInfo(hwnd, ref winInfo);
            if ((winInfo.dwExStyle & WS_EX_TOOLWINDOW) != 0) return false;

            uint CloakedVal;
            WinApiManager.DwmGetWindowAttribute(hwnd, DWMWA_CLOAKED, out CloakedVal, sizeof(uint));
            return CloakedVal == 0;
        }


        public static IntPtr FindTopmostWindow()
        {
            List<IntPtr> hwnds = EnumerateWindow();
            if (hwnds.Count != 0)
            {
                int max = -1;
                IntPtr result = IntPtr.Zero;
                foreach (IntPtr hwnd in hwnds)
                {
                    var z = GetWindowZOrder(hwnd);
                    if (z > max)
                    {
                        max = z;
                        result = hwnd;
                    }
                }
                return result;
            }

            return IntPtr.Zero;
        }

        private static IntPtr GetLastVisibleActivePopUpOfWindow(IntPtr window)
        {
            IntPtr lastPopUp = WinApiManager.GetLastActivePopup(window);
            if (WinApiManager.IsWindowVisible(lastPopUp))
                return lastPopUp;
            else if (lastPopUp == window)
                return IntPtr.Zero;
            else
                return GetLastVisibleActivePopUpOfWindow(lastPopUp);
        }

        public static List<IntPtr> EnumerateWindow()
        {
            List<IntPtr> windows = new List<IntPtr>();
            WinApiManager.EnumWindows(delegate (IntPtr hwnd, int param)
            {
                if (!IsAltTabWindow(hwnd))
                    return true;
                windows.Add(hwnd);
                return true;
            }, 0);


            //Console.WriteLine(windows.Count);
            //foreach (IntPtr hWnd in windows)
            //{
            //    Console.WriteLine(GetWindowTitle(hWnd));
            //}
            return windows;
        }
        #endregion

        #region Get Window Parameter

        public static IntPtr GetHandleFromTitle(string title)
        {
            return WinApiManager.FindWindow("", title);
        }


        public static String GetWindowTitle(IntPtr hWnd)
        {
            StringBuilder Buff = new StringBuilder(256);
            if (WinApiManager.GetWindowText(hWnd, Buff, 256) > 0)
                return Buff.ToString();
            return null;
        }

        private static int GetWindowZOrder(IntPtr hWnd)
        {
            var zOrder = -1;
            while ((hWnd = WinApiManager.GetWindow(hWnd, 2)) != IntPtr.Zero) zOrder++;
            return zOrder;
        }

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
                ? Application.Current.Windows.OfType<T>().Any()
                : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        public static ImageSource GetAppIcon(IntPtr hwnd)
        {
            try
            {
                IntPtr hIcon = default(IntPtr);
                hIcon = WinApiManager.SendMessage(hwnd, WinApiManager.WM_GETICON, WinApiManager.ICON_SMALL2, IntPtr.Zero);

                if (hIcon == IntPtr.Zero)
                    hIcon = WinApiManager.GetClassLongPtr(hwnd, -14); // GCL_HICON

                if (hIcon == IntPtr.Zero)
                    hIcon = WinApiManager.LoadIcon(IntPtr.Zero, (IntPtr)0x7F00);

                if (hIcon != IntPtr.Zero)
                {
                    Bitmap bmp = new Bitmap(Icon.FromHandle(hIcon).ToBitmap(), 64, 64);
                    IntPtr hbmp = bmp.GetHbitmap();
                    return Imaging.CreateBitmapSourceFromHBitmap(hbmp, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public static IntPtr GetWindowHandle(Window window)
        {
            return WinApiManager.FindWindowByCaption(IntPtr.Zero, window.Title);   
        }
        #endregion

        #region Screen Parameters
        public static double GetScreenWidth()
        {
            return SystemParameters.PrimaryScreenWidth;
        }

        public static double GetScreenHeight()
        {
            return SystemParameters.PrimaryScreenHeight;
        }

        public static System.Windows.Size GetScreenSize()
        {
            return new System.Windows.Size(SystemParameters.PrimaryScreenWidth, System.Windows.SystemParameters.PrimaryScreenHeight);
        }

        #endregion 
    }
}

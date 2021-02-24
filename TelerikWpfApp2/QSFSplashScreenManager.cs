using System;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.SplashScreen;

namespace Org.Tao.QuickStart
{
    internal static class QSFSplashScreenManager
    {
        internal static void Show()
        {
            (RadSplashScreenManager.HideAnimation as FadeAnimation).Duration = TimeSpan.FromMilliseconds(1000);
            RadSplashScreenManager.Show<QSFSplashScreen>();
        }

        internal static void Close()
        {
            RadSplashScreenManager.Close();
            RadSplashScreenManager.Reset();
        }

        private class QSFSplashScreen : RadSplashScreen
        {
            public QSFSplashScreen()
            {
                this.ImagePath = "pack://application:,,,/SplashScreen3.jpg";
                this.Content = "加载中";
                this.FontFamily = new System.Windows.Media.FontFamily("微软雅黑");
                this.Footer = "";
            }
        }
    }
}

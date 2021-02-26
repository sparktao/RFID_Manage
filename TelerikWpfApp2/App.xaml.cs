using Microsoft.Extensions.Configuration;
using Org.Tao.FW.Common.Lic;
using Serilog;
using Serilog.Core;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Org.Tao.QuickStart
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // 配置文件
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            // 配置SeriLog日志文件
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
           
            // 全局字体和字体大小
            FluentPalette.Palette.FontFamily = new FontFamily("微软雅黑");
            FluentPalette.Palette.FontSize = 14;
            // telerik本地化设置
            LocalizationManager.Manager = new CustomLocalizationManager();

            this.InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool isValidate = false;
            // 判断许可
            try
            {
                isValidate = LicenseGenerate.validateLicense();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);                
            }
            if (!isValidate)
            {
                Log.Information("许可过期，请联系管理员");
                var sh = new NoLicenseWin();
                sh.Show();
            }
            else
            {
                // 启动等待界面
                QSFSplashScreenManager.Show();
                // 启动shell进程
                Log.Information("初始化参数");
                var sh = new Shell();

                sh.Loaded += (s, args) =>
                {
                    // shell 进程启动后关闭等待界面
                    QSFSplashScreenManager.Close();
                    sh.BringToFront();
                };

                sh.Show();
            }
            
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
        }
    }
}

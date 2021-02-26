using Telerik.Windows.Controls;
using Org.Tao.FW.Common.Infrastructure;
using Org.Tao.FW.Application;
using Serilog;

namespace Org.Tao.QuickStart
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : RadWindow
    {        
        public Shell()
        {            
            this.InitializeComponent();
            this.init();
        }

        private void init()
        {
            // 
            Log.Information("初始化系统..");

            var appModule = new ApplicationModule();
            appModule.Initialize();

            NavigationService.Instance.Frame = this.ApplicationContentPlaceholder;
            NavigationService.Instance.Navigate(ApplicationView.Home);
        }
    }
}

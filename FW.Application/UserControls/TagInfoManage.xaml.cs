using Org.Tao.FW.Application.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Org.Tao.FW.Application.UserControls
{
    /// <summary>
    /// Interaction logic for TagInfoManage.xaml
    /// </summary>
    public partial class TagInfoManage : UserControl
    {
        public TagInfoManage()
        {
            InitializeComponent();
            this.DataContext = new TagInfoManageViewModel();           

            this.Loaded += TagInfoManage_Loaded;
        }

        private void TagInfoManage_Loaded(object sender, RoutedEventArgs e)
        {
            ((TagInfoManageViewModel)this.DataContext).InitData();
        }
    }
}

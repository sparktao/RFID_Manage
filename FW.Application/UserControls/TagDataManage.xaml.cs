using Org.Tao.FW.Application.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Org.Tao.FW.Application.UserControls
{
    /// <summary>
    /// Interaction logic for TagDataManage.xaml
    /// </summary>
    public partial class TagDataManage : UserControl
    {
        public TagDataManage()
        {
            this.DataContext = new TagDataManageViewModel();
            InitializeComponent();
            this.Loaded += TagDataManage_Loaded;
        }

        private void TagDataManage_Loaded(object sender, RoutedEventArgs e)
        {
            ((TagDataManageViewModel)this.DataContext).InitData();
        }
    }
}

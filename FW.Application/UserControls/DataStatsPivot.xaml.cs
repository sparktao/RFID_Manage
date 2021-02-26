using Org.Tao.FW.Application.ViewModel;
using System.Windows.Controls;

namespace Org.Tao.FW.Application.UserControls
{
    /// <summary>
    /// Interaction logic for DataStatsPivort.xaml
    /// </summary>
    public partial class DataStatsPivot : UserControl
    {
        public DataStatsPivot()
        {
            this.DataContext = new DataStatsPivotViewModel();
            InitializeComponent();
        }
    }
}

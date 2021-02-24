using Org.Tao.FW.Application.ViewModel;
using System.Windows.Controls;

namespace Org.Tao.FW.Application.UserControls
{
    /// <summary>
    /// Interaction logic for DataImport.xaml
    /// </summary>
    public partial class DataImport : UserControl
    {
        public DataImport()
        {
            InitializeComponent();
            this.DataContext = new DataImportViewModel(this);
        }

        public void scrollToEnd() 
        {
            logComponent.CaretIndex = logComponent.Text.Length;
            logComponent.ScrollToEnd();
        }
    }
}

using Org.Tao.FW.Common.Infrastructure;
using System.Windows;
using System.Windows.Controls;

namespace Org.Tao.FW.Application
{
    public class ViewBase : UserControl, INotifyUser, IView
    {
        public virtual void Notify(object param)
        {
            MessageBox.Show(param.ToString());
        }

        public virtual void OnNavigatedFrom(object parameter)
        {
        }

        public virtual void OnNavigatedTo(object parameter)
        {
        }
    }
}

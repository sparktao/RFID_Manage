namespace Org.Tao.FW.Common.Infrastructure
{
    public interface IView
    {
        void OnNavigatedFrom(object parameter);
        void OnNavigatedTo(object parameter);
    }
}
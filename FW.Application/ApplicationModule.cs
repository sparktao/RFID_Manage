using Org.Tao.FW.Common.Infrastructure;

namespace Org.Tao.FW.Application
{
    public class ApplicationModule
    {
        public void Initialize()
        {
            //ViewModelLocator.RegisterAssociation(typeof(AllControls), typeof(QuickStartViewModelBase));
            ViewModelLocator.RegisterAssociation(typeof(Home), typeof(HomeViewModel));
            //ViewModelLocator.RegisterAssociation(typeof(SingleControlExamples), typeof(SingleControlExamplesViewModel));
            //ViewModelLocator.RegisterAssociation(typeof(SingleExample), typeof(SingleExampleViewModel), true);

            //ApplicationThemeManager.GetInstance().EnsureResourcesForTheme(ApplicationThemeManager.DefaultThemeName);

            //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("/Application;component/Resources.xaml", UriKind.RelativeOrAbsolute) });

            NavigationService.Instance.AssociateViewWithType(ApplicationView.Home, typeof(Home));
            //NavigationService.Instance.AssociateViewWithType(ApplicationView.AllControls, typeof(AllControls));
            //NavigationService.Instance.AssociateViewWithType(ApplicationView.SingleExample, typeof(SingleExample));
            //NavigationService.Instance.AssociateViewWithType(ApplicationView.SingleControlExamples, typeof(SingleControlExamples));
        }
    }
}
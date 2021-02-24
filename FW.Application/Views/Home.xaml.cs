using Microsoft.Extensions.Logging;
using Org.Tao.FW.Common.Types;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Org.Tao.FW.Application
{
    public partial class Home : ViewBase
	{
		public Home()
		{
			this.DataContext = new HomeViewModel();
			InitializeComponent();
			this.Loaded += this.OnHomeLoaded;
		}

		public override void OnNavigatedFrom(object parameter)
		{
			base.OnNavigatedFrom(parameter);
			this.ExampleArea.Content = null;
		}

		private void OnHomeLoaded(object sender, RoutedEventArgs e)
		{
			this.Loaded -= this.OnHomeLoaded;
		}

		public override void OnNavigatedTo(object parameter)
		{
			base.OnNavigatedTo(parameter);
			var viewModel = this.DataContext as HomeViewModel;

			viewModel.Initialize(parameter as IPageInfo, () =>
			{
				//TODO: find a way to fix this properly
				// refresh binding, so content is properly updated
				// this fixes an issue where inside the example Window.GetWindow(this.LayoutRoot); returns null

				this.ExampleArea.Content = null;
                this.ExampleArea.SetBinding(ContentControl.ContentProperty, new Binding("CurrentExampleInstance"));
            });
		}


	}
}

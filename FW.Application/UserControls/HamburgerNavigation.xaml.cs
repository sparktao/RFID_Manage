using System.Windows;
using System.Windows.Controls;

namespace Org.Tao.FW.Application
{
    /// <summary>
    /// Interaction logic for HamburgerNavigation.xaml
    /// </summary>
    public partial class HamburgerNavigation : UserControl
    {
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(HamburgerNavigation), new FrameworkPropertyMetadata { BindsTwoWayByDefault = true });

        public HamburgerNavigation()
        {
            InitializeComponent();
        }

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

		public override void OnApplyTemplate()
		{
			//if (!(this.DataContext is HomeViewModel) && !(this.DataContext is SingleControlExamplesViewModel) && !(this.DataContext is SingleExampleViewModel))
			//{
			//	//this.ControlsButton.Visibility = Visibility.Collapsed;
   //             this.ControlsButton.Content = "OVERVIEW";
   //             this.ControlsButton.CommandParameter = "Home";
   //             this.ControlsVerticalButton.Content = "OVERVIEW";
   //             this.ControlsVerticalButton.CommandParameter = "Home";
   //         }
   //         if((this.DataContext is SingleExampleViewModel) || (this.DataContext is SingleControlExamplesViewModel))
   //         {
   //             this.HomeButtonMinimized.Height = 56;
   //         }
   //         if(this.DataContext is HomeViewModel)
   //         {
   //             this.HomeButton.Visibility = Visibility.Collapsed;
   //         }
			base.OnApplyTemplate();
		}
	}
}

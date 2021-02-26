using Org.Tao.FW.Application.Model;
using Org.Tao.FW.Application.ViewModel;
using Org.Tao.FW.Common.Infrastructure;
using Org.Tao.FW.Common.Types;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Org.Tao.FW.Application
{
    public class HomeViewModel : ViewModelBase
    {
        private bool isDialogOverlayOpen;

        private IPageInfo currentPage;
        private object currentExampleInstance;
        private Action exampleInstantiatedCallback;
        public DelegateCommand NavigateCommand { get; protected set; }

        public IPageInfo CurrentPage
        {
            get
            {
                return this.currentPage;
            }
            private set
            {
                if (this.currentPage != value)
                {
                    this.currentPage = value;
                    this.OnPropertyChanged("CurrentExample");
                }
            }
        }
        public object CurrentExampleInstance
        {
            get
            {
                return this.currentExampleInstance;
            }
            set
            {
                if (this.currentExampleInstance != value)
                {
                    this.currentExampleInstance = value;
                    this.OnPropertyChanged("CurrentExampleInstance");
                }
            }
        }
        public HomeViewModel()
        {
            this.NavigateCommand = new DelegateCommand(this.OnNavigateCommandExecuted);
            this.IsMenuExpanded = true;
            this.Menus = new List<MenuInfo>();
            this.Menus.Add(new MenuInfo("数据导入", "/Images/menu/m_import.png", new IPageInfo { Text = "DataImport", Name = "Org.Tao.FW.Application.UserControls.DataImport", PackageName = "FW.Application" }));
            this.Menus.Add(new MenuInfo("数据浏览", "/Images/menu/m_table.png", new IPageInfo { Text = "TagDataManage", Name = "Org.Tao.FW.Application.UserControls.TagDataManage", PackageName = "FW.Application" }));
            this.Menus.Add(new MenuInfo("分析统计", "/Images/menu/m_statistic.png", new IPageInfo { Text = "DataStatsPivot", Name = "Org.Tao.FW.Application.UserControls.DataStatsPivot", PackageName = "FW.Application" }));
            this.Menus.Add(new MenuInfo("标签管理", "/Images/menu/m_barcode.png", new IPageInfo { Text= "TagInfoManage", Name= "Org.Tao.FW.Application.UserControls.TagInfoManage", PackageName= "FW.Application" }));
            
            PageLoader.Instance.Initialize();
            PageLoader.Instance.PropertyChanged += OnPageLoaderPropertyChanged;
            PageLoader.Instance.PageInstantiated += OnPageLoaderExampleInstantiated;
        }

        public bool IsMenuExpanded { get; set; }

        public List<MenuInfo> Menus { get; set; }
      
        public bool IsDialogOverlayOpen
        {
            get
            {
                return this.isDialogOverlayOpen;
            }
            set
            {
                if (this.isDialogOverlayOpen != value)
                {
                    this.isDialogOverlayOpen = value;
                    this.OnPropertyChanged("IsDialogOverlayOpen");
                }
            }
        }

        public void Initialize(IPageInfo exampleInfo, Action exampleInstantiatedCallback)
        {
            this.exampleInstantiatedCallback = exampleInstantiatedCallback;
            
            this.NavigateToExample(exampleInfo);
        }

        public void NavigateToExample(IPageInfo pageInfo)
        {
            if (this.currentPage == null)
            {
                this.currentPage = pageInfo;
            }

            PageLoader.Instance.LoadPage(pageInfo);
        }

        protected void OnNavigateCommandExecuted(object parameter)
        {
            try
            {
                IPageInfo pageInfo = parameter as IPageInfo;
                if (pageInfo != null)
                {
                    NavigationService.Instance.Navigate(ApplicationView.Home, pageInfo);
                }                
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

        }

        private void OnPageLoaderExampleInstantiated(object s, ExampleInstantiatedEventArgs e)
        {
            this.CurrentExampleInstance = e.ExampleInstance;
            if (this.exampleInstantiatedCallback != null)
            {
                this.exampleInstantiatedCallback();
            }
        }

        private void OnPageLoaderPropertyChanged(object s, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {               
                case "CurrentPage":
                    this.CurrentPage = PageLoader.Instance.CurrentPage;
                    break;               
                default:
                    throw new NotImplementedException(e.PropertyName);
            }
        }
    }

}
using Org.Tao.DB.Data.Dao;
using Org.Tao.DB.Data.Model;
using Org.Tao.DB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Telerik.Windows.Controls;

namespace Org.Tao.FW.Application.ViewModel
{
    public class TagDataManageViewModel : ViewModelBase
    {

        private RadDesktopAlertManager desktopAlertManager;
        private TagDataService tagDataService = new TagDataService();
        private List<TagData> _tagList;
        public List<TagData> TagList
        {
            get { return _tagList; }
            set
            {
                _tagList = value;
                this.OnPropertyChanged("TagList");
            }
        }
        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            private set
            {
                if (this.pageSize != value)
                {
                    this.pageSize = value;
                    this.OnPropertyChanged("PageSize");
                }
            }
        }


        private int pageNumber = 0;
        public int PageNumber
        {
            get { return pageNumber; }
            set
            {
                this.pageNumber = value;
                this.OnPropertyChanged("PageNumber");
                this.IsBusy = true;
            }
        }

        private int totalPages;
        public int TotalPages
        {
            get { return totalPages; }
            set
            {
                this.totalPages = value;
                this.OnPropertyChanged("TotalPages");
            }
        }

        private int totalCounts;
        public int TotalCounts
        {
            get { return totalCounts; }
            private set
            {
                if (this.totalCounts != value)
                {
                    this.totalCounts = value;
                    this.OnPropertyChanged("TotalCounts");
                }
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return this.isBusy; }
            set
            {
                if (this.isBusy != value)
                {
                    this.isBusy = value;
                    this.OnPropertyChanged(() => this.IsBusy);

                    if (this.isBusy)
                    {
                        var backgroundWorker = new BackgroundWorker();
                        backgroundWorker.DoWork += this.OnBackgroundWorkerDoWork;
                        backgroundWorker.RunWorkerCompleted += OnBackgroundWorkerRunWorkerCompleted;
                        backgroundWorker.RunWorkerAsync();
                    }
                }
            }
        }
        public TagDataManageViewModel()
        {
            this.PageSize = 15;
            this.desktopAlertManager = new RadDesktopAlertManager(AlertScreenPosition.BottomRight, 5d);
        }

        public void InitData()
        {
            this.IsBusy = true;
        }

        private void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            backgroundWorker.DoWork -= this.OnBackgroundWorkerDoWork;
            backgroundWorker.RunWorkerCompleted -= OnBackgroundWorkerRunWorkerCompleted;

            InvokeOnUIThread(() =>
            {
                this.IsBusy = false;

                PaginatedList<TagData> result = e.Result as PaginatedList<TagData>;
                this.TotalPages = result.TotalPages;
                this.TotalCounts = result.TotalCounts;
                this.TagList = result.Items;
            });
        }
        private async void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = await this.tagDataService.GetList(PageNumber + 1, PageSize, "RecordDateTime", "desc");
        }

    }
}

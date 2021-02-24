using Org.Tao.DB.Data;
using Org.Tao.DB.Data.Dao;
using Org.Tao.DB.Data.Model;
using Org.Tao.DB.Model;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Telerik.Windows.Controls;

namespace Org.Tao.FW.Application.ViewModel
{
    public class TagInfoManageViewModel : ViewModelBase
    {
        private RadDesktopAlertManager desktopAlertManager;
        private TagInfoService tagInfoService = new TagInfoService();
        private List<TagInfo> _tagList;
        public List<TagInfo> TagList
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
        public TagInfoManageViewModel()
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

                PaginatedList<TagInfo> result = e.Result as PaginatedList<TagInfo>;
                this.TotalPages = result.TotalPages;
                this.TotalCounts = result.TotalCounts;
                this.TagList = result.Items;
            });
        }
        private async void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = await this.tagInfoService.GetList(PageNumber + 1, PageSize, "SeqNum", "asc");
        }

        public async void BroadCastGridView_Deleted(object sender, Telerik.Windows.Controls.GridViewDeletedEventArgs e)
        {
            if (e.Items != null && (e.Items as ICollection).Count > 0)
            {
                foreach (var item in e.Items)
                {
                   await tagInfoService.Delete((item as TagInfo).SeqNum);
                }
                Log.Debug("删除标签项.");
            }
        }

        public async void BroadCastGridView_RowEditEnded(object sender, Telerik.Windows.Controls.GridViewRowEditEndedEventArgs e)
        {
            if (e.EditAction == Telerik.Windows.Controls.GridView.GridViewEditAction.Commit)
            {
                if (e.EditOperationType == Telerik.Windows.Controls.GridView.GridViewEditOperationType.Insert)
                {
                    Log.Debug("插入标签项.");
                    TagInfo tagInfoData = e.NewData as TagInfo;
                    TagInfo result = await tagInfoService.Add(tagInfoData);

                    if (result != null)
                    {
                        this.desktopAlertManager.ShowAlert(new DesktopAlertParameters
                        {
                            Header = "标签管理",
                            Content = "新建标签成功.",
                            ShowDuration = 1000
                        });
                        Log.Debug("新建公告{0}成功.", tagInfoData.TagName);
                        //插入记录后更新列表
                        IsBusy = true;
                    }
                    else
                    {
                        this.desktopAlertManager.ShowAlert(new DesktopAlertParameters
                        {
                            Header = "标签管理",
                            Content = "新建标签失败.",
                            ShowDuration = 1000
                        });
                    }
                }
                else
                {
                    Log.Debug("更新标签项.");
                    TagInfo tagInfoData = e.NewData as TagInfo;
                    TagInfo result = await tagInfoService.Update(tagInfoData);
                    if (result != null)
                    {
                        this.desktopAlertManager.ShowAlert(new DesktopAlertParameters
                        {
                            Header = "标签管理",
                            Content = "更新标签成功.",
                            ShowDuration = 1000
                        });
                        Log.Debug("修改标签{0}成功.", (e.NewData as TagInfo).TagName);
                        //插入记录后更新列表
                        IsBusy = true;
                    }
                    else
                    {
                        this.desktopAlertManager.ShowAlert(new DesktopAlertParameters
                        {
                            Header = "标签管理",
                            Content = "更新标签失败.",
                            ShowDuration = 1000
                        });
                    }
                }
            }
            else if (e.EditAction == Telerik.Windows.Controls.GridView.GridViewEditAction.Cancel)
            {
                // do nothing
            }
        }
    }
    
}

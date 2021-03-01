using Org.Tao.DB.Data.Dao;
using Org.Tao.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Windows.Controls;

namespace Org.Tao.FW.Application.ViewModel
{
    public class DataStatsPivotViewModel : ViewModelBase
    {
        private TagDataService tagDataService = new TagDataService();
        private List<TagData> _tagDataList;
        public List<TagData> TagDataList
        {
            get { return _tagDataList; }
            set
            {
                _tagDataList = value;
                this.OnPropertyChanged("TagDataList");
            }
        }
        private string queryTerminalName;
        public string QueryTerminalName
        {
            get { return queryTerminalName; }
            set
            {
                if (this.queryTerminalName != value)
                {
                    this.queryTerminalName = value;
                    this.OnPropertyChanged("QueryTerminalName");
                }
            }
        }

        private string queryTagName;
        public string QueryTagName
        {
            get { return queryTagName; }
            set
            {
                this.queryTagName = value;
                this.OnPropertyChanged("QueryTagName");
            }
        }

        private DelegateCommand queryCommand;

        public DelegateCommand QueryCommand
        {
            get { return queryCommand; }
            set 
            {
                this.queryCommand = value;
                this.OnPropertyChanged("QueryCommand");
            }
        }

        public DataStatsPivotViewModel()
        { 
            this.QueryCommand = new DelegateCommand(this.OnQueryCommand);
        }

        private async void OnQueryCommand(object obj)
        {
            if (String.IsNullOrEmpty(QueryTerminalName) || String.IsNullOrEmpty(QueryTagName))
            {
                RadWindow.Alert(new DialogParameters
                {      
                    Header= "数据统计",
                    Content = "查询条件不能为空!"
                });
                return;
            }
            this.TagDataList = await this.tagDataService.GetByTagName(QueryTerminalName, QueryTagName);
        }
    }
}

using Org.Tao.DB.Data.Dao;
using Org.Tao.DB.Model;
using Org.Tao.FW.Application.UserControls;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Telerik.Windows.Controls;

namespace Org.Tao.FW.Application.ViewModel
{
    public class DataImportViewModel : ViewModelBase
    {
        private TagDataService tagDataService = new TagDataService();
        private DataImport _owner;
        private string filePath;

        public string FilePath 
        {
            get { return filePath; }
            set
            {

                if (this.filePath != value)
                {
                    this.filePath = value;
                    this.OnPropertyChanged("FilePath");
                }
            }
        }

        private string logData;

        public string LogData
        {
            get { return logData; }
            set
            {

                if (this.logData != value)
                {
                    this.logData = value;
                    this.OnPropertyChanged("LogData");
                }
            }
        }

        public Int32 LogDataIndex { get; set; }

        private DelegateCommand startImportCommand;

        public DelegateCommand StartImportCommand
        {
            get { return startImportCommand; }
            set
            {

                if (this.startImportCommand != value)
                {
                    this.startImportCommand = value;
                    this.OnPropertyChanged("StartImportCommand");
                }
            }
        }

        private DelegateCommand selectFileCommand;
        public DelegateCommand SelectFileCommand
        {
            get { return selectFileCommand; }
            set
            {

                if (this.selectFileCommand != value)
                {
                    this.selectFileCommand = value;
                    this.OnPropertyChanged("SelectFileCommand");
                }
            }
        }

        public DataImportViewModel(DataImport owner) 
        {
            _owner = owner;
            this.StartImportCommand = new DelegateCommand(this.OnStartImport);
            this.SelectFileCommand = new DelegateCommand(this.OnSelectFile);
        }

        private void OnStartImport(object obj)
        {
            if (String.IsNullOrEmpty(this.FilePath))
                return;

            FileStream fileStream = null;
            StringBuilder sb = new StringBuilder();
            try
            {
                fileStream = new FileStream(this.FilePath, FileMode.Open);
                //read file line by line using StreamReader
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string terminalName = null, siteName = null;                    
                    string line = "";
                    sb = new StringBuilder();
                    string[] temps = null;
                    List<TagData> tagDataLst = new List<TagData>();
                    TagData tagData;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // 解析终端名称和站点名称
                        if (line.StartsWith("Reader:"))
                        {
                            temps = System.Text.RegularExpressions.Regex.Split(line, @"\ +");
                            terminalName = temps[1];
                            siteName = temps[3];
                            Log.Information("读取Reader: {0}, Site: {1}", terminalName, siteName);
                            sb.Append(string.Format("读取Reader: {0}, Site: {1}", terminalName, siteName)).Append("\r\n");
                        }
                        else if (line.StartsWith("D "))
                        {
                            temps = System.Text.RegularExpressions.Regex.Split(line, @"\ +");
                            tagData = new TagData
                            {
                                TerminalName = terminalName,
                                SiteName = siteName,
                                TagName = temps[5],
                                RecordDateTime = DateTime.Parse(temps[1] + "T" + temps[2]),
                                FlagColumn1 = temps[6],
                                FlagColumn2 = temps[7]
                            };
                            tagDataLst.Add(tagData);
                            Log.Information("读取数据标签: {0}, 日期: {1}, 时间: {2}", tagData.TagName, tagData.RecordDateTime.ToShortDateString(), tagData.RecordDateTime.ToShortTimeString());
                            sb.Append(string.Format("读取数据标签: {0}, 日期: {1}, 时间: {2}", tagData.TagName, tagData.RecordDateTime.ToLongDateString(), tagData.RecordDateTime.ToShortTimeString())).Append("\r\n");
                        }
                        this.LogData = sb.ToString();
                    }
                    _owner.scrollToEnd();

                    if (tagDataLst.Count > 0) 
                    {
                        this.tagDataService.BulkAdd(tagDataLst);

                        Log.Information("=================批量插入{0}条数据.===============================", tagDataLst.Count);
                        sb.Append(string.Format("==================批量插入{0}条数据.=============================", tagDataLst.Count)).Append("\r\n");
                        this.LogData = sb.ToString();
                        tagDataLst = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                sb.Append("=====================批量插入出现错误，请查看系统日志。=========================").Append("\r\n");
                this.LogData = sb.ToString();
            }
            finally
            {
                if(fileStream != null)
                    fileStream.Close();
            }
            
        }

        private void OnSelectFile(object obj)
        {
            RadOpenFileDialog openFileDialog = new RadOpenFileDialog()
            {
                Filter = "Txt Files (*.txt)|*.txt"
            };
            openFileDialog.ShowDialog();
            
            this.FilePath = openFileDialog.FileName;
        }
    }
}

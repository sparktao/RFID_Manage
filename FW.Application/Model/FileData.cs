using System.IO;
using Telerik.Windows.Controls;

namespace Org.Tao.FW.Application.Model
{
    public class FileData : ViewModelBase
    {
        private string filePath;
        private string fileName;
        private long fileSize;

        public string FilePath
        {
            get
            {
                return this.filePath;
            }

            set
            {
                if (this.filePath != value)
                {
                    this.filePath = value;

                    if (!string.IsNullOrEmpty(this.filePath))
                    {
                        FileInfo fileInfo = new FileInfo(this.FilePath);

                        if (fileInfo != null)
                        {
                            this.FileName = fileInfo.Name;
                            this.FileSize = fileInfo.Length;
                        }
                    }
                    this.OnPropertyChanged("FilePath");
                }
            }
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }

            set
            {
                if (this.fileName != value)
                {
                    this.fileName = value;
                    this.OnPropertyChanged("FileName");
                }
            }
        }

        public long FileSize
        {
            get
            {
                return this.fileSize;
            }

            set
            {
                if (this.fileSize != value)
                {
                    this.fileSize = value;
                    this.OnPropertyChanged("FileSize");
                }
            }
        }
    }
}

using Org.Tao.FW.Application.Utils;
using Org.Tao.FW.Application.ViewModel;
using Org.Tao.FW.Common.Types;
using Serilog;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Org.Tao.FW.Application
{
    public class PageLoader
    {
        private static PageLoader instance;

        private IPageInfo currentPage;
        private IPageInfo pageToNavigate;

        private int exampleProgress;
        private bool isInitialized = false;

        private ICache cachedPages = new Cache();

        public IPageInfo CurrentPage
        {
            get
            {
                return this.currentPage;
            }
            set
            {
                this.currentPage = value;
            }
        }

        public int ExampleProgress
        {
            get
            {
                return this.exampleProgress;
            }

            set
            {
                if (this.exampleProgress != value)
                {
                    this.exampleProgress = value;
                }
            }
        }

        private PageLoader()
        {
            // intentionally empty
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<ExampleInstantiatedEventArgs> PageInstantiated;

        public static PageLoader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageLoader();
                }

                return instance;
            }
        }

        public void Initialize()
        {
            if (this.isInitialized)
            {
                return;
            }
            //this.data = data;
            this.isInitialized = true;
        }

        public void UnInitialize()
        {
            this.isInitialized = false;

            currentPage = null;
            pageToNavigate = null;
            exampleProgress = 0;
            this.cachedPages.RemoveCache();
        }

        public void LoadPage(IPageInfo pageInfo)
        {
            var newExample = pageInfo;
            this.pageToNavigate = newExample;
            //this.currentPage = this.pageToNavigate;
            var moduleName = this.pageToNavigate.PackageName;

            this.LoadNormalPage(moduleName, null);
        }

        private void LoadNormalPage(string assemblyName, string theme)
        {
            //this.CurrentTheme = theme;
            Log.Information(string.Format("LoadNormalPage, Loading assembly {0}", assemblyName));

            if (assemblyName == this.pageToNavigate.PackageName)
            {
                this.InstantiateExampleContent(this.pageToNavigate);

                this.ExampleProgress = 100;
            }
            Log.Information(string.Format("LoadedNormalPage, Loaded assembly {0}", assemblyName));
        }

        private void InstantiateExampleContent(IPageInfo pageInfo)
        {
            try
            {
                var assemblyName = this.pageToNavigate.PackageName;

                var assembly = GetAssemblyByName(assemblyName);
                object exampleInstance = this.cachedPages.GetCache<object>(pageInfo.Text);

                if (exampleInstance == null)
                {
                    exampleInstance = assembly.CreateInstance(pageInfo.Name);
                    this.cachedPages.WriteCache<object>(exampleInstance, pageInfo.Text);
                }

                this.RaisePageInstantiatedEvent(exampleInstance);
                //this.CurrentPage = example;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

        }

        private void RaisePageInstantiatedEvent(object exampleInstance)
        {
            if (this.PageInstantiated != null)
            {
                this.PageInstantiated(this, new ExampleInstantiatedEventArgs(exampleInstance));
            }
        }

        private static Assembly GetAssemblyByName(string moduleName)
        {
            Assembly assembly = null;
            try
            {
                assembly = AppDomain.CurrentDomain
                                .GetAssemblies()
                                .Where(a => a.GetName().Name == moduleName)
                                .FirstOrDefault();
                if (assembly == null)
                {
                    FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().Location);
                    assembly = Assembly.LoadFile(fi.DirectoryName + "\\" + moduleName + ".dll");
                }

            }
            catch (Exception ex)
            {
                throw ex;
                //LogHelperUtil.Instance.Error("初始化", String.Format("Get Assembly {0} Error.", moduleName), ex);
            }
            return assembly;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler onPropertyChanged = this.PropertyChanged;
            if (onPropertyChanged != null)
            {
                onPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

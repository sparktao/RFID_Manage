using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Tao.FW.Application.Model
{
    public class MenuInfo
    {
        public string DisplayText { get; private set; }
        public string ImagePath { get; private set; }
        public object NavigationParameter { get; private set; }

        public MenuInfo(string defaultText, string imagePath, object navigationParameter)
        {
            this.DisplayText = defaultText;
            this.NavigationParameter = navigationParameter;
            this.ImagePath = imagePath;
        }

    }
}

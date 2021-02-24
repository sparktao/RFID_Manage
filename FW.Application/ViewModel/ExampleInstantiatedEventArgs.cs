using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Tao.FW.Application.ViewModel
{
    public class ExampleInstantiatedEventArgs: EventArgs
    {
        public ExampleInstantiatedEventArgs(object instance)
        {
            this.ExampleInstance = instance;
        }

        public object ExampleInstance { get; set; }
    }
}

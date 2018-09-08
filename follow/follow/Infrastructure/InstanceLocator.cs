using System;
using System.Collections.Generic;
using System.Text;

namespace follow.Infrastructure
{
    using View_model;
    public class InstanceLocator
    {
        public object Main
        {
            get;
            set;
        }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}

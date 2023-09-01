using System;
using System.Collections.Generic;
using System.Text;

namespace WMInteraction
{
    class Status
    {
        private string wmiAttribute { get; set; }
        private string wmiClass { get; set; }
        private string wmiScope { get; set; }

        public string WmiAttribute
        {
            get { return wmiAttribute; }
            set { wmiAttribute = value; }
        }

        public string WmiClass
        {
            get { return wmiClass; }
            set { wmiClass = value; }
        }

        public string WmiScope
        {
            get { return wmiScope; }
            set { wmiScope = value; }
        }
    }
}

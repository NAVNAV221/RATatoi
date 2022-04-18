using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace WMInteraction
{
    public class Query
    {
        private string userScope;
        private string wmiAttributes;
        private string wmiClass;

        public Query(string userScope, string wmiAttributes, string wmiClass)
        {
            this.userScope = userScope;
            this.wmiAttributes = wmiAttributes;
            this.wmiClass = wmiClass;
        }

        public string WmiAttributes { get; set; }

        public string UserScope { get; set; }

        public string WmiClass { get; set; }

        ObjectQuery BuildQuery(string wmi_attributes, string wmi_class)
        {
            ObjectQuery query = new ObjectQuery("SELECT " + wmi_attributes + "FROM " + wmi_class);
            return query;
        }

        public ManagementObjectCollection ExecuteQuery()
        {
            ObjectQuery query = BuildQuery(this.wmiAttributes, this.wmiClass);

            ManagementScope scope = new ManagementScope(this.userScope);
            scope.Connect();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            return searcher.Get();
        }
    }
}

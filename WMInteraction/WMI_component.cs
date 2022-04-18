using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace WMInteraction
{
    public class WMI_component
    {
        private string scope;
        private string wmiClass;
        private string wmiAttributes;
        private Query query;

        public WMI_component(string scope, string wmi_class, string wmiAttributes)
        {
            this.scope = scope;
            this.wmiClass = wmi_class;
            this.wmiAttributes = wmiAttributes;
            this.query = new Query(this.scope, this.wmiAttributes, this.wmiClass);
        }

        public string WmiClass { get; set; }

        public string Scope { get; set; }

        public string WmiAttribute { get; set; }

        public void RetriveWMIData()
        {
            ManagementObjectCollection queryCollection = query.ExecuteQuery();
            foreach (ManagementObject obj in queryCollection)
            {
                foreach (PropertyData property in obj.Properties)
                {
                    Console.WriteLine("Proerty Name: {0} | Property Value: {1}", property.Name, property.Value);
                }
            }
        }

    }
}

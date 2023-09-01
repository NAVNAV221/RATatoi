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
        private string wmiActionId;
        private Query query;
        private Dictionary<string, Object> wmiProperties;

        public WMI_component(string scope, string wmi_class, string wmiAttributes, string wmiActionId)
        {
            this.scope = scope;
            this.wmiClass = wmi_class;
            this.wmiAttributes = wmiAttributes;
            this.query = new Query(this.scope, this.wmiAttributes, this.wmiClass);
            this.wmiActionId = wmiActionId;
        }

        public string WmiClass
        {
            get { return wmiClass; }
            set { wmiClass = value; }
        }

        public string Scope
        {
            get { return scope; }
            set { scope = value; }
        }

        public string WmiAttributes
        {
            get { return wmiAttributes; }
            set { wmiAttributes = value; }
        }

        public string WmiActionId
        {
            get { return wmiActionId; }
            set { wmiActionId = value; }
        }

        public Query Query
        {
            get { return query; }
            set { query = value; }
        }

        public Dictionary<string, Object> WmiProperties
        {
            get { return wmiProperties; }
            set { wmiProperties = value; }
        }

        public Dictionary<string, Object> RetriveWMIData()
        {
            Dictionary<string, Object> properties = new Dictionary<string, Object>();

            Console.WriteLine(query.WmiAttributes);
            ManagementObjectCollection queryCollection = query.ExecuteQuery();
            foreach (ManagementObject obj in queryCollection)
            {
                foreach (PropertyData property in obj.Properties)
                {
                    /*
                    Console.WriteLine(property.Name + " | " + property.Value);
                    */
                    if (!properties.ContainsKey(property.Name))
                    {
                        properties.Add(property.Name, property.Value);
                    }
                }
            }

            return properties;
        }

    }
}

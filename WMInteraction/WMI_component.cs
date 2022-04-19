﻿using System;
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
        private Dictionary<string, Object> wmiProperties;

        public WMI_component(string scope, string wmi_class, string wmiAttributes)
        {
            this.scope = scope;
            this.wmiClass = wmi_class;
            this.wmiAttributes = wmiAttributes;
            this.query = new Query(this.scope, this.wmiAttributes, this.wmiClass);
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

            ManagementObjectCollection queryCollection = query.ExecuteQuery();
            foreach (ManagementObject obj in queryCollection)
            {
                foreach (PropertyData property in obj.Properties)
                {
                    properties.Add(property.Name, property.Value);
                }
            }

            return properties;
        }

    }
}

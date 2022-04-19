using System;
using System.Collections.Generic;
using System.Management;

namespace WMInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            WMI_component dynamicWMI = new WMI_component("","","");
            HTTPClient.RunAsync(dynamicWMI).GetAwaiter().GetResult();

            Dictionary<string, Object> wmiProperties = dynamicWMI.RetriveWMIData();

            foreach (KeyValuePair<string, Object> entry in wmiProperties)
            {
                Console.WriteLine("Key: {0} | Value: {1}", entry.Key, entry.Value);
            }
        }
    }
}

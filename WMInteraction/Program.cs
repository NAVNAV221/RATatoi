using System;
using System.Collections.Generic;
using System.Management;

namespace WMInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            WMI_component operatingSystemAPI = new WMI_component("ROOT\\cimv2", "Win32_OperatingSystem", "*");
            operatingSystemAPI.RetriveWMIData();
        }
    }
}

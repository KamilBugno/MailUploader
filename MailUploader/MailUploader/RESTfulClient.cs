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

        public async Task UploadFileToFoxxAsync(string filePathFromClient, string foxxFileName)
        {
            using (var stream = File.OpenRead(filePathFromClient))
            {
                var fullUrl = ApplicationConstant.urlService + ApplicationConstant.uploadFileAction + foxxFileName;
                var httpResponse = await client.PostAsync(fullUrl, new StreamContent(stream)).ConfigureAwait(false);
                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task UploadMailToFoxxAsync(MailStructure mail)
        {
            var json = objectToJsonConverter.Convert(mail);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var fullUrl = ApplicationConstant.urlService + ApplicationConstant.uploadMailAction;
            
            var httpResponse = await client.PostAsync(fullUrl, content).ConfigureAwait(false);
            httpResponse.EnsureSuccessStatusCode();
            
        }
    }
}

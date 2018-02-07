using System;
using System.Collections.Generic;
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

        public RESTfulClient()
        {
            client = new HttpClient();
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
    }
}

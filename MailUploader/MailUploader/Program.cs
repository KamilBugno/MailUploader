using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TikaOnDotNet.TextExtraction;

namespace MailUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailGenerator = new MailGenerator();
            var mails = mailGenerator.Generate();

            var mailUploader = new MailUploader();
            mailUploader.UploadMails(mails);
        }
    }
}

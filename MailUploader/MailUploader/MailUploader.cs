using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailUploader
{
    public class MailUploader
    {
        private RESTfulClient restClient;
        
        public MailUploader()
        {
            restClient = new RESTfulClient();
        }

        public void UploadMails(List<MailStructure> mails)
        {
            foreach(MailStructure mail in mails)
            {
                var resultForSendingMail = restClient.UploadMailToFoxx(mail);

                if (mail.HasProcessedAttachment())
                {
                    var resultForSendingAttachment = restClient.UploadFileToFoxx(ApplicationConstant.pathToFolder + mail._key + ".pdf",
                        mail._key + ".pdf");
                }
            }
        }
    }
}

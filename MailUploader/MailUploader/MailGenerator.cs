using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailUploader
{
    class MailGenerator
    {
        private Random random;
        private Extractor extractor;

        public MailGenerator()
        {
            random = new Random();
            extractor = new Extractor();
        }
        public List<MailStructure> Generate()
        {
            var mailList = new List<MailStructure>();
            for(int i = 0; i < ApplicationConstant.numberOfMails; i++)
            {
                var key = (ApplicationConstant.startKey + i).ToString();
                var attachment_text = String.Empty;

                if (HasAttachment(key))
                {
                    attachment_text = extractor.Extract(key);
                }

                mailList.Add(new MailStructure()
                {
                    _key = key,
                    _id = ApplicationConstant.prefixMail + key,
                    _from = ApplicationConstant.prefixPerson + GenerateFromAndTo().from,
                    _to = ApplicationConstant.prefixPerson + GenerateFromAndTo().to,
                    type = "mail",
                    topic = GenerateTopic(),
                    body = GenerateBody(),
                    text_from_attachment = attachment_text
                });
            }

            return mailList;
        }

        public string GenerateTopic()
        {
            var mailTopics = ApplicationConstant.mailTopic;
            var topicId = random.Next(mailTopics.Length);
            return mailTopics[topicId];
        }

        public string GenerateBody()
        {
            var mailBodies = ApplicationConstant.mailBody;
            var bodyId = random.Next(mailBodies.Length);
            return mailBodies[bodyId];
        }

        public bool HasAttachment(string mailKey)
        {
            return File.Exists(ApplicationConstant.pathToFolder + mailKey + ".pdf");
        }

        public (int from, int to) GenerateFromAndTo()
        {
            int to;
            var from = random.Next(ApplicationConstant.minPersonKeyValue, 
                ApplicationConstant.maxPersonKeyValue + 1);

            do
            {
                to = random.Next(ApplicationConstant.minPersonKeyValue,
                ApplicationConstant.maxPersonKeyValue + 1);
            } while (to == from);

            return (from, to);
        } 
    }
}

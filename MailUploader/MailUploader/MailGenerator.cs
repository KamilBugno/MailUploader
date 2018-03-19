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

                var topic = GenerateTopic();
                var body = GenerateBody();
                var date = GenerateDate();

                mailList.Add(new MailStructure()
                {
                    _key = key,
                    _id = ApplicationConstant.prefixMail + key,
                    _from = ApplicationConstant.prefixPerson + GenerateFromAndTo().from,
                    _to = ApplicationConstant.prefixPerson + GenerateFromAndTo().to,
                    type = "mail",
                    topic = topic,
                    body = body,
                    text_from_attachment = attachment_text,
                    date = DateToString(date)
                });

                var client = new RESTfulClient();
                client.UploadToElasticSearch(body, topic, attachment_text, DateToShortString(date), key);
            }

            return mailList;
        }

        public DateTime GenerateDate()
        {
            var year = ApplicationConstant.year;
            var month = ApplicationConstant.month;
            var day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            var hour = random.Next(0, 24);
            var minute = random.Next(0, 60);
            var second = random.Next(0, 60);
            return new DateTime(year, month, day, hour, minute, second);
        }

        public string DateToString(DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss.000");
        }

        public string DateToShortString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
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
            var from = random.Next(ApplicationConstant.minPersonKeyValue, 
                ApplicationConstant.maxPersonKeyValue + 1);
            int to = from;

            while (to == from)
            {
                to = random.Next(ApplicationConstant.minPersonKeyValue,
                ApplicationConstant.maxPersonKeyValue + 1);
            } 

            return (from, to);
        } 
    }
}

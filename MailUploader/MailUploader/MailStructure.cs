using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MailUploader
{
    [DataContract]
    public class MailStructure
    {
        [DataMember]
        public string _key { get; set; }
        [DataMember]
        public string _id { get; set; }
        [DataMember]
        public string _from { get; set; }
        [DataMember]
        public string _to { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string topic { get; set; }
        [DataMember]
        public string body { get; set; }
        [DataMember]
        public string text_from_attachment { get; set; }

        public bool HasProcessedAttachment()
        {
            return text_from_attachment != String.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MailUploader
{
    [DataContract]
    class MailElasticSearch
    {
        [DataMember]
        public string body { get; set; }
        [DataMember]
        public string topic { get; set; }
        [DataMember]
        public string attachment { get; set; }
        [DataMember]
        public string key { get; set; }
    }
}

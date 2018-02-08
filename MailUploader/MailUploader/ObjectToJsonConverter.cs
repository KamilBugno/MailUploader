using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MailUploader
{
    class ObjectToJsonConverter
    {
        public string Convert(MailStructure mail)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MailStructure));
            MemoryStream memoryStreamObj = new MemoryStream();
            serializer.WriteObject(memoryStreamObj, mail);
            memoryStreamObj.Position = 0;
            StreamReader streamReader = new StreamReader(memoryStreamObj);

            string json = streamReader.ReadToEnd();

            streamReader.Close();
            memoryStreamObj.Close();

            return json;
        }
    }
}

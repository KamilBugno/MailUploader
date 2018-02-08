using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TikaOnDotNet.TextExtraction;

namespace MailUploader
{
    class Extractor
    {
        public string Extract(string mailKey)
        {
            var textExtractor = new TextExtractor();
            var textExtractorResult = textExtractor.Extract(ApplicationConstant.pathToFolder + mailKey + ".pdf");
            var text = removeWhiteCharacters(textExtractorResult.Text);
            return text;
        }

        private string removeWhiteCharacters(string text)
        {
            return Regex.Replace(text, @"\s+", " ");
        }
       
    }
}

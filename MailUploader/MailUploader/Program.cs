using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikaOnDotNet.TextExtraction;

namespace MailUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            var textExtractor = new TextExtractor();

            var wordDocContents = textExtractor.Extract(@"C:\Users\Kamil\Desktop\sonetyAdamaMickiewicza.pdf");

            Console.WriteLine(wordDocContents.Text);
            Console.ReadKey();
        }
    }
}

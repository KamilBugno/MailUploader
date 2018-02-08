namespace MailUploader
{
    class ApplicationConstant
    {
        public static string urlService = "http://127.0.0.1:8529/_db/_system/foxx-service/";
        public static string uploadFileAction = "save-file/";
        public static string uploadMailAction = "add-mail/";
        public static int minPersonKeyValue = 1;
        public static int maxPersonKeyValue = 4;
        public static int numberOfMails = 2;
        public static int startKey = 21;
        public static string prefixPerson = "HRSystem/";
        public static string prefixMail = "Mails/";
        public static string pathToFolder = @"C:\Users\Kamil\Desktop\test\";
    }
}
namespace MailUploader
{
    class ApplicationConstant
    {
        public static string urlService = "http://127.0.0.1:8529/_db/_system/foxx-service/";
        public static string urlElasticSearch = "http://127.0.0.1:9200/mail/_doc?pretty";
        public static string uploadFileAction = "save-file/";
        public static string uploadMailAction = "add-mail/";
        public static int minPersonKeyValue = 1;
        public static int maxPersonKeyValue = 4;
        public static int numberOfMails = 10;
        public static int startKey = 300;
        public static int year = 2018;
        public static int month = 1;
        public static string prefixPerson = "HRSystem/";
        public static string prefixMail = "Mails/";
        public static string pathToFolder = @"C:\Users\Kamil\Desktop\test\";
        public static string[] mailTopic = {"Removal request delight if on he we",
            "Excellent so to no sincerity smallness", "Seen you eyes son show",
            "Prepared interest proposal it he exercise", "Described deficient applauded consisted my me do",
            "Entire its the did figure wonder off", "Distrusts an it contented perceived attending oh",
            "Received the likewise law graceful his", "Are court tiled cease young built fat one man taken",
            "settlement was barely operational",
            "India gained independence",
            "Nature takes its course"};
        public static string[] mailBody = {
            "It real sent your at. Amounted all shy set why followed declared. Repeated of endeavor mr position kindness offering ignorant so up. Simplicity are melancholy preference considered saw companions.",
            "The him father parish looked has sooner. Attachment frequently gay terminated son. You greater nay use prudent placing.",
            "Inquietude simplicity terminated she compliment remarkably few her nay. The weeks are ham asked jokes. Neglected perceived shy nay concluded. Not mile draw plan snug next all. Houses latter an valley be indeed wished merely in my.",
            "Remain lively hardly needed at do by. Two you fat downs fanny three. True mr gone most at. Dare as name just when with it body.",
            "British officers introduced various species of deer to the Andaman Islands for game hunting. However, without any natural predators",
            "It has been nearly eight decades since the penal colony was shut down, ending a dark chapter in the annals of India’s colonial past. ",
            "futureIn the Subordinate’s Club (pictured), built for the entertainment of junior officers, the teak dance floor must have once reverberated with music."};
    }
}
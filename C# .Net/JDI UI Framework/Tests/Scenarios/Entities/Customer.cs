using System;

namespace Epam.Tests.Scenarios.Entities
{
    public class Customer

    {
      
        public JobSearchFilter Filter = new JobSearchFilter();
        public string Phone;
        public string Company;
        public string Name = "Iuliia";
        public string LastName = "Petrova";
        public string Email = "iuliia_petrova@epam.com";
        public string Country = "Russia";
        public string Position = "Director";
        public string Subject = "Website Feedback";
        public string City = "Saint-Petersburg";
        public string Message1 = "London is the capital of Great Britain, its political, economic, and commercial centre. It is one of the largest cities in the world and the largest city in Europe. Its population is about 8 million.\n" +
                "London is divided into several parts: the City, Westminster, the West End, and the East End. Лондон — столица Великобритании, ее политический, экономический и торговый центр. Это один из крупнейших городов в Европе. Его население составляет около 8 миллионов человек.\n" +
                "Лондон разделен на несколько частей: Сиги, Вестминстер, Вест-Энд и Ист-Энд.";
        public string Message2 = "如今，这只风靡日本的小猫咪 已成为世界最著名动画人物之一Hello Kitty，深受成年人与儿童喜爱。2014年秋季，Hello Kitty将迎来40岁生日。它已成为日本“可爱文化”（ cute culture）风靡世界的“特洛伊木马”。从马拉喀什（Marrakech）到火奴鲁鲁（Honolulu），这只头戴红色蝴蝶结的小猫在各种玩具展览 中广受欢迎。假如你谷歌搜索“米奇老鼠”，将有230万个搜索结果；但如果搜索“Hello Kitty”，你将得到100万个搜索结果，尽管它只是个不会说话，商业图标以及有1000多万用户的游戏";

        public Customer()
        {
            Phone = "+79215853505";
            Company = "EPAM";
            Name = "UUUU";
        }

    }


}
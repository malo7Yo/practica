using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;


namespace news
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "c52ca5c548b24007aaa070d75f2af82a";

            string url = "http://newsapi.org/v2/top-headlines?country=ru&apiKey=" + key;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();


            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Root root = JsonConvert.DeserializeObject<Root>(result);
                Console.WriteLine("Новости:\n");

                foreach (Article article in root.Articles)
                {
                    Console.Write("\nНовость: " + article.Description + "\nСсылка на новость:  ");
                    Console.WriteLine(article.Url);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}




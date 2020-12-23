using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using weather;
using Newtonsoft.Json;

namespace weather
{
    class Program
    {
        static void Main(string[] we)
        {
            const string AppKey = "918463c58d81579f27743f12c53e7a36";
            var client = new HttpClient();
            Console.WriteLine("Введите название города: ");
            string city = Console.ReadLine();
            HttpResponseMessage response = client.GetAsync(new Uri($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={AppKey}&units=metric&lang=ru")).GetAwaiter().GetResult();
            string jsonResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var weatherInfo = JsonConvert.DeserializeObject<weatherMore>(jsonResult);

            Console.WriteLine($"В городе {weatherInfo.name} сейчас температура: {weatherInfo.Main.temp}, ощущается как {weatherInfo.Main.feels_like}");

        }
    }
}

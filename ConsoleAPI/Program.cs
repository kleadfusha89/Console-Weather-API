using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleAPI
{
    
    class Program
    {       

        public static void Main()
        {
           
            string lat = "41.3275";
            string lon = "19.8187";
            string apiKey = "621eb6dd0cdb9f6c6523181df99dd172";

            string answ = "";
            
            Console.Write("Enter latitude: ");
            lat = Console.ReadLine();
            Console.Write("Enter North or South: ");
            answ = Console.ReadLine();
            while(answ != "North" && answ != "South")
            {
                Console.Write("Enter either North or South: ");
                answ = Console.ReadLine();
            }
            if (answ == "South")
                lat = "-" + lat;


            Console.Write("Enter longitude: ");
            lon = Console.ReadLine();
            Console.Write("Enter East or West: ");
            answ = Console.ReadLine();
            while (answ != "East" && answ != "West")
            {
                Console.Write("Enter either East or West: ");
                answ = Console.ReadLine();
            }
            if (answ == "West")
                lon = "-" + lon;


            Console.WriteLine();

            

            string rawJSON = ProcessAPI(lat, lon, apiKey).GetAwaiter().GetResult();
                      


            WeatherApiObjects deserialize = JsonConvert.DeserializeObject<WeatherApiObjects>(rawJSON);
            Console.Write("City Name: ");
            Console.WriteLine(deserialize.name);

            Console.Write("Latitude: ");
            Console.WriteLine(deserialize.coord.lat);

            Console.Write("Timezone: ");
            Console.WriteLine(deserialize.timezone);

            //Console.WriteLine(deserialize.@base);
            Console.Write("Country: ");
            Console.WriteLine(deserialize.sys.country);

            //Console.Write("Type: ");
            //Console.WriteLine(deserialize.sys.type);                

            foreach (WeatherApiObjects.Weather x in deserialize.weather)
            {
                Console.Write("Weather description: ");
                Console.WriteLine(x.description);

                Console.Write("Main: ");
                Console.WriteLine(x.main);
            }

            Console.Read();
       }

        private static async Task<string> ProcessAPI(string lat, string lon, string apiKey)
        {
           HttpClient client = new HttpClient();
           string response = await client.GetStringAsync($"http://api.openweathermap.org/data/2.5/weather?lat={ lat }&lon={ lon }&appid={ apiKey }");
           return response;
        }

        

    }
}


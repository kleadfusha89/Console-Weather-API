using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleAPI
{
    public class WeatherCollection
    {
        private List<WeatherInfo> collections;

        public List<WeatherInfo> Collections { get => collections; set => collections = value; }
        
    }

}
using System;
using System.Collections.Generic;
using static CustomWeatherClientTool.Weather;

namespace CustomWeatherClientTool
{
    class Program
    {
        static void Main(string[] args)
        {
            try { 
            Consume con = new Consume();
            City cityList = new City();
            Console.WriteLine("Please enter the city as per simplemaps.com/data/in-cities database: ");
            string cityName = Console.ReadLine();
            City city= cityList.getCity(cityName);
            if (city == null)
            {
                Console.WriteLine("City name is not available in simplemaps.com/data/in-cities database");
                throw new Exception();
            }
            WeatherInfo result =  con.GetWeatherData(city.lat.ToString(), city.lng.ToString());
            Console.WriteLine(Environment.NewLine + "City : " + city.city.ToString() + "\n====================\n Temperature : " + result.current_weather.temperature + "\n Windspeed : " + result.current_weather.windspeed);
                Console.WriteLine("\n\nPress any key to exit");
                Console.ReadKey();
            }
            catch(Exception ex){
                Console.WriteLine("\n\nPress any key to exit");
                Console.ReadKey(); 
            }
        }
    }
}

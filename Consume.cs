using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using static CustomWeatherClientTool.Weather;

namespace CustomWeatherClientTool
{
    class Consume
    {
        public WeatherInfo GetWeatherData(string latitude, string longitude) 
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("https://api.open-meteo.com/v1/forecast?latitude="+ latitude + "&longitude="+longitude +"&current_weather=true"); //URI               
                return JsonSerializer.Deserialize<WeatherInfo>(result); ;
            }
        }
    }
}


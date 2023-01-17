using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CustomWeatherClientTool
{
    class City
    {
            public string city { get; set; }
            public string lat { get; set; }
            public string lng { get; set; }
            public string country { get; set; }
            public string iso2 { get; set; }
            public string admin_name { get; set; }
            public string capital { get; set; }
            public string population { get; set; }
            public string population_proper { get; set; }
        
        public City getCity(string city){
            City cityObj = null;
            string filePath = System.IO.Path.GetFullPath("in.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<City> cityList = new List<City>();

                cityList = JsonConvert.DeserializeObject<List<City>>(json);
                if (cityList.Count > 0)
                {
                    foreach (var obj in cityList) {
                        if (obj.city.ToLower() == city.ToLower())
                        {
                            cityObj = new City();
                            cityObj.city = obj.city;
                            cityObj.lat = obj.lat;
                            cityObj.lng = obj.lng;
                            break;
                        }
                    }
                }
                return cityObj;
            }
        }
    }
}

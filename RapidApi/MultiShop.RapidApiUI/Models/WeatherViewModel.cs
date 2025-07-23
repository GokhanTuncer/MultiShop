namespace MultiShop.RapidApiUI.Models
{
    public class WeatherViewModel
    {

        public class Rootobject
        {
            public Coord coord { get; set; }
            public string summery { get; set; }
            public Weather[] weather { get; set; }
            public string _base { get; set; }
            public Main main { get; set; }
            public int visibility_distance { get; set; }
            public string visibility_unit { get; set; }
            public Wind wind { get; set; }
            public Rain rain { get; set; }
            public Snow snow { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public DateTime dt_txt { get; set; }
            public Sys sys { get; set; }
            public int timezone { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }

        public class Coord
        {
            public float lon { get; set; }
            public float lat { get; set; }
        }

        public class Main
        {
            public float temprature { get; set; }
            public float temprature_feels_like { get; set; }
            public float temprature_min { get; set; }
            public float temprature_max { get; set; }
            public string temprature_unit { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public string humidity_unit { get; set; }
            public int sea_level_pressure { get; set; }
            public int ground_level_pressure { get; set; }
            public string pressure_unit { get; set; }
        }

        public class Wind
        {
            public float speed { get; set; }
            public int degrees { get; set; }
            public string direction { get; set; }
            public string speed_unit { get; set; }
        }

        public class Rain
        {
            public int amount { get; set; }
            public string unit { get; set; }
        }

        public class Snow
        {
            public int amount { get; set; }
            public string unit { get; set; }
        }

        public class Clouds
        {
            public int cloudiness { get; set; }
            public string unit { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public DateTime sunrise_txt { get; set; }
            public int sunset { get; set; }
            public DateTime sunset_txt { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

    }
}

using NuGet.Versioning;

namespace PlanesTuristicos.Models
{

    public class WeatherData
    {
        public Location location { get; set; }
        public Current current { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string country { get; set; }
    }

    public class Current
    {
        public double temperature { get; set; }
        public int humidity { get; set; }
    }

}

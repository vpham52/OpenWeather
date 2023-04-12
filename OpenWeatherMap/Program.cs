using System.Reflection.Emit;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMap;
class Program
{
    static void Main(string[] args)
    {
        var client = new HttpClient();

 
        string key = File.ReadAllText("appsettings.json");
        string APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();

        Console.WriteLine("Please enter your zipcode.");
        var zipCode = Console.ReadLine();

        var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={APIkey}&units=imperial";

        var weatherResponse = client.GetStringAsync(weatherURL).Result;

        var temp = double.Parse(JObject.Parse(weatherResponse)["main"]["temp"].ToString());
        var feelsLike = double.Parse(JObject.Parse(weatherResponse)["main"]["feels_like"].ToString());
        var tempMin = double.Parse(JObject.Parse(weatherResponse)["main"]["temp_min"].ToString());
        var tempMax = double.Parse(JObject.Parse(weatherResponse)["main"]["temp_max"].ToString());
        var city = JObject.Parse(weatherResponse)["name"].ToString();


        Console.WriteLine($"It is currently: {temp} degrees fahrenheit in {city}.");
        Console.WriteLine($"Feels like {feelsLike}");
        Console.WriteLine($"Temp. Min: {tempMin} degrees fahrenheit");
        Console.WriteLine($"Temp. Max: {tempMax} degrees fahrenheit");
       
    }
}


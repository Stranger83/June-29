using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Weather
{
	class WeatherInfo
	{
		public string Weather { get; set; }
		public double AverageTemp { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			var pattern = @"(?<city>[A-Z]{2})(?<temp>\d+\.\d+)(?<weather>[a-zA-Z]+)\|";
			var cities = new Dictionary<string, WeatherInfo>();
			var input = Console.ReadLine();

			while(input != "end")
			{
				var weatherMatch = Regex.Match(input, pattern);
				if (!weatherMatch.Success)
				{
					input = Console.ReadLine();
					continue;
				}
				var city = weatherMatch.Groups["city"].Value;
				var temp = double.Parse(weatherMatch.Groups["temp"].Value);
				var weather = weatherMatch.Groups["weather"].Value;
				var weatherInfo = new WeatherInfo { AverageTemp = temp, Weather = weather };
			
				cities[city] = weatherInfo;
				input = Console.ReadLine();
			}
			var sortedCities = cities.OrderBy(x => x.Value.AverageTemp)
				.ToDictionary(a => a.Key, a => a.Value);
			foreach (var cityInfo in sortedCities)
			{
				var city = cityInfo.Key;
				var weatherInfo = cityInfo.Value;
				Console.WriteLine($"{city} => {weatherInfo.AverageTemp:f2} => {weatherInfo.Weather}");
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QueryMess
{
	class Program
	{
		static void Main(string[] args)
		{
			var pattern = @"(?<key>[^=&?\s]+)\+*(\%20)*=((\%20)*\+*(?<value>[^=&?\s]+)(\%20)*\+*)+";
			
			var mess = Console.ReadLine();
			while (mess != "END")
			{
				var matches = Regex.Matches(mess, pattern)
					.Cast<Match>();
				
				var keyValues = new Dictionary<string, List<string>>();
				foreach (Match m in matches)
				{
					var key = Regex.Replace(m.Groups["key"].Value, @"((%20)|\+)+", " ").Trim();
					var value = Regex.Replace(m.Groups["value"].Value, @"((%20)|\+)+", " ").Trim();
					if (!keyValues.ContainsKey(key))
					{
						keyValues[key] = new List<string>();
					}
					keyValues[key].Add(value);
				}
				foreach (var item in keyValues)
				{
					Console.Write($"{item.Key.Trim()}=[{string.Join(", ", item.Value).Trim()}]");
				}
				Console.WriteLine();
				mess = Console.ReadLine();
			}
		}
	}
}

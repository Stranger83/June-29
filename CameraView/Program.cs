using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CameraView
{
	class Program
	{
		static void Main(string[] args)
		{
			var skipTake = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			var skip = skipTake[0];
			var take = skipTake[1];
			var results = new List<string>();
			var matches = Regex.Matches(Console.ReadLine(), @"(\|<)(?<shot>\w+)");

			foreach (Match m in matches)
			{
				var shot = m.Groups["shot"].Value;
				results.Add(new string(shot.Skip(skip).Take(take).ToArray()));
			}
			Console.WriteLine(string.Join(", ", results));
		}
	}
}

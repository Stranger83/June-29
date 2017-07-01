using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidUsernames
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();
			var pattern = @"\b[a-zA-Z]\w{2,24}\b";
			var matches = Regex.Matches(input, pattern)
				.Cast<Match>()
				.Select(x => x.Value)
				.ToArray();

			var longest = 0;
			var long1 = "";
			var long2 = "";
			for (int i = 0; i < matches.Length - 1; i++)
			{
				var currentLongest = matches[i].Length + matches[i + 1].Length;
				if (currentLongest > longest)
				{
					longest = currentLongest;
					long1 = matches[i];
					long2 = matches[i + 1];
				}
			}
			Console.WriteLine(long1);
			Console.WriteLine(long2);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractSentencesByKeyword
{
	class Program
	{
		static void Main(string[] args)
		{
			var keyword = Console.ReadLine();
			var input = Console.ReadLine();
			var pattern = @"[^!?.]*\b" + keyword + @"\b[^!?.]*";
			var matches = Regex.Matches(input, pattern);
			var results = matches.Cast<Match>()
				.Select(m => m.Value.Trim())
				.ToArray();
			Console.WriteLine(string.Join("\r\n", results));
		}
	}
}

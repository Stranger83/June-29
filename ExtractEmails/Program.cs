using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractEmails
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();
			var pattern = @"(^|\s)[A-Za-z0-9]+[.\-_A-Za-z0-9]+@[a-z-]+(\.[a-z]+)+";
			var matches = Regex.Matches(input, pattern);
			foreach (Match m in matches)
			{
				Console.WriteLine(m.Value);
			}
		}
	}
}

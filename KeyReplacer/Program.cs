using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeyReplacer
{
	class Program
	{
		static void Main(string[] args)
		{
			var keyString = Console.ReadLine();
			var textString = Console.ReadLine();
			var keyPattern = @"(?<startkey>^[a-zA-Z]+)[<\|\\]\w+[<\|\\](?<endkey>[a-zA-Z]+$)";
			Match matchedKeys = Regex.Match(keyString, keyPattern);
			var startKey = matchedKeys.Groups["startkey"].Value;
			var endKey = matchedKeys.Groups["endkey"].Value;
			var textPattern = startKey + @"(?<msg>\w*?)" + endKey;
			var matchedStrings = Regex.Matches(textString, textPattern)
				.Cast<Match>()
				.Select(x => x.Groups["msg"].Value)
				.ToArray();
			if (matchedStrings.All(x => string.IsNullOrEmpty(x)))
			{
				Console.WriteLine("Empty result");
			}
			else
			{
				Console.WriteLine(string.Join("", matchedStrings));
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C2_BasicLanguage.Statement
{
	public static class SwitchStatement
	{

		public static string TellMeMyType(object x)
		{
			StringBuilder sb = new StringBuilder();
			
			switch (x)
			{
				case int i:
					sb.Append($"It's an int!{Environment.NewLine}");
					sb.Append($"The square of {i} is {i * i}");
					break;

				case string s:
					sb.Append($"It's a string {Environment.NewLine}");
					sb.Append($"The length of {s} is {s.Length}");
					break;
				default:
					sb.Append("I don't know what x is");
					break;
			}

			return sb.ToString();
		}

		public static string BoolStringValue(bool x)
		{
			switch (x)
			{
				case bool b when b:
					return "True";
				case bool b:
					return "False";
			}
		}

		public static string ValueGreaterThan1000(object x)
		{
			switch (x)
			{
				case float f when f > 1000:
				case double d when d > 1000:
				case decimal m when m > 1000:
					return "We can refer to x here but not f or d or m";
				case null:
					return ("Nothing here");
			}

			return "";
		}
}
}

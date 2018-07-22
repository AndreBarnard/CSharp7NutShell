using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C2_BasicLanguage.VariablesAndParameters
{
	public class ParameterModifier
	{

		public static void Foo(StringBuilder fooSB)
		{
			fooSB.Append("test");
			fooSB = null;
		}

		public static void Foo(ref int p)
		{
			p = p + 1; // Increment p by 1
		}


		public static void Swap(ref string a, ref string b)
		{
			string temp = a;
			a = b;
			b = temp;
		}

		public static void Split(string name, out string firstname, out string lastName)
		{
			int i = name.LastIndexOf(' ');
			firstname = name.Substring(0, i);
			lastName = name.Substring(i + 1);
		}

		public static int Sum(params int[] ints)
		{
			int sum = 0;

			for (int i = 0; i < ints.Length; i++)
			{
				sum += ints[i];
			}
			return sum;
		}

		public static string ConcatinateInt(int x = 0, int y = 0)
		{
			return $"{x}, {y}";
		}

	
	}
}

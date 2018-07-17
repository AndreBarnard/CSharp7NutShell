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
	}
}

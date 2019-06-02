using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C2_BasicLanguage.Statement
{
	public static class IterationStatements
	{

		public static string FibonacciSeq()
		{

			StringBuilder sb = new StringBuilder();

			for (int i = 0, prevFib = 1, curFib = 1; i < 10; i++)
			{
				sb.Append($"{prevFib},");
				int newFib = prevFib + curFib;
				prevFib = curFib; curFib = newFib;
			}

			return sb.ToString().Substring(0, sb.ToString().LastIndexOf(','));

		}

	}
}

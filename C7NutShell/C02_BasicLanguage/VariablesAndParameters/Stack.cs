using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C2_BasicLanguage.VariablesAndParameters
{
	public class Stack
	{
		public List<int> IntergerList { get; set; }

		public Stack()
		{
			IntergerList = new List<int>();
		}

		public int Factorial(int x)
		{
			IntergerList.Add(x);
			if (x == 0) return 1;
			return x * Factorial(x - 1);
		}

	}
}

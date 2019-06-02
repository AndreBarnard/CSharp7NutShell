using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C2_BasicLanguage.VariablesAndParameters
{
	public static class Default
	{
		public static T  GetDefaultValue<T>(T item)
		{
			return default(T);
		}

		public static T GetDefaultGeneric<T>()
		{
			return default(T);
		}

	}
}

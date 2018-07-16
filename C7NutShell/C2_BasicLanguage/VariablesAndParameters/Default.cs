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
			var result = default(T);

			return result;
		}

	}
}

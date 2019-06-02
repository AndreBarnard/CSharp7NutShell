using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C2_BasicLanguage
{
	public class Umberalla
	{

		public static bool UseUmberalla(bool rainy, bool sunny, bool windy)
		{
			return !windy && (rainy || sunny);
		}

		public static bool UseUmberallaNoShortCircut(bool rainy, bool sunny, bool windy)
		{
			return !windy & (rainy | sunny);
		}

	}
}

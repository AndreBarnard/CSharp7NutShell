using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C2_BasicLanguage.Array
{
	public class SpeechSound
	{

		public char[] Vowels
		{
			get
			{
				char[] vowles = new char[5];
				vowles[0] = 'a';
				vowles[1] = 'e';
				vowles[2] = 'i';
				vowles[3] = 'o';
				vowles[4] = 'u';

				return vowles;
			}
		}

	}
}

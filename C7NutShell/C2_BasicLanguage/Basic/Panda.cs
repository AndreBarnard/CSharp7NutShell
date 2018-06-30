using System;

namespace C7NutShell.C2_BasicLanguage
{
	public class Panda
	{
		public string Name; // Instance field
		public static int Population; // Static field
		public Panda(string n) // Constructor
		{
			Name = n; // Assign the instance field
			Population = Population + 1; // Increment the static Population field
		}
	}
}

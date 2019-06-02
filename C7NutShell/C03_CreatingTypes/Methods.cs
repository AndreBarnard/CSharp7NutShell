using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace C7NutShell.C3_CreatingTypes
{
	public class Methods
	{
		public int DoubleMyValue(int x) => x * 2;

		public void OutputInt(int x) => Console.WriteLine(x);


		#region Overloading

		public void Overloading(int x) => Console.WriteLine($"int value is : {x}");
		public void Overloading(double x) => Console.WriteLine($"double value is : {x}");
		public void Overloading(int x, float y) => Console.WriteLine($"int value is : {x} , float value is : {y}");
		public void Overloading(float x, int y) => Console.WriteLine($"float value is : {x} , int value is {y}");

		#endregion

		#region Local methods

		public void WriteCubes()
		{
			WriteLine(Cube(3));
			WriteLine(Cube(4));
			WriteLine(Cube(5));

			int Cube(int value) => value * value * value;

		}

		#endregion
	}
}

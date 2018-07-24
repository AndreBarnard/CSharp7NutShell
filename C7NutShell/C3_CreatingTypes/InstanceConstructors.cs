using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C3_CreatingTypes
{
	public class Panda
	{
		string name; // Define field

		public Panda(string n) => name = n;

		public override string ToString() => name;
	}

	public class Wine
	{
		public decimal Price;
		public int Year;

		public Wine(decimal price) { Price = price; }

		public Wine(decimal price, int year) : this(price) { Year = year; }

		public Wine(decimal price, DateTime year) : this(price, year.Year) { } //You can pass an expression into another constructor

	}


	public class Rectangle
	{
		public readonly float Width, Height;

		public Rectangle(float width, float height)
		{
			Width = width;
			Height = height;
		}

		public void Deconstruct(out float width, out float height)
		{
			width = Width;
			height = Height;
		}
	}
}

 

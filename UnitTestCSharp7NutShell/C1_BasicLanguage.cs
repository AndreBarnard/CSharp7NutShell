using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp7NutShell;
namespace UnitTestCSharp7NutShell
{
	[TestClass]
	public class C1_BasicLanguage
	{
		#region Reference types
		[TestMethod]
		public void ContrastInstanceStaticMembers()
		{

			Panda P1 = new Panda("Pan Dee");
			Panda P2 = new Panda("Pan Dah");

			Console.WriteLine(P1.Name);
			Console.WriteLine(P2.Name);

			Assert.AreEqual(2, Panda.Population);

		}

		[TestMethod]
		public void AssignmentValueTypeInstance()
		{
			StructPoint p1 = new StructPoint();

			p1.X = 7;
			StructPoint p2 = p1;

			Console.WriteLine(p1.X);
			Console.WriteLine(p2.X);

			p1.X = 9;
			Assert.AreEqual(7 + 9, p2.X + p1.X);
		}

		[TestMethod]
		public void AssignmentReferenceypeInstance()
		{
			ClassPoint p1 = new ClassPoint();

			p1.X = 7;
			ClassPoint p2 = p1;

			Console.WriteLine(p1.X);
			Console.WriteLine(p2.X);

			p1.X = 9;
			Assert.AreEqual(9 + 9, p2.X + p1.X);
		}
		#endregion

		#region Numeric Types
		[TestMethod]
		public void NumericliteralTypeInferenceDecimal()
		{
			Type type = 1.0.GetType();
			Assert.AreEqual("System.Double", type.FullName);
		}

		[TestMethod]
		public void NumericliteralTypeInferenceExponentialSymbolDecimal()
		{
			Type type = 1E06.GetType();
			Assert.AreEqual("System.Double", type.FullName);
		}

		[TestMethod]
		public void NumericliteralTypeInferenceInterger()
		{
			Type type = 1.GetType();
			Assert.AreEqual("System.Int32", type.FullName);
		}

		[TestMethod]
		public void NumericliteralTypeInferenceUInt32()
		{
			Type type = 0xF0000000.GetType();
			Assert.AreEqual("System.UInt32", type.FullName);
		}

		[TestMethod]
		public void NumericliteralTypeInferenceInt64()
		{
			Type type = 0x100000000.GetType();
			Assert.AreEqual("System.Int64", type.FullName);
		}


		[TestMethod]
		public void ImplicitConversionIntToLong()
		{
			int x = 12345;
			long y = x;
			Assert.AreNotSame(y, x);
		}

		[TestMethod]
		public void ExplicitConversionIntToShort()
		{
			int x = 12345;
			short s = (short)x;
			Assert.AreNotSame(s, x);
		}


		[TestMethod]
		public void MagnitudePreservedPrecisionLost()
		{
			int i1 = 100000001;
			float f = i1; // Magnitude preserved, precision lost
			int i2 = (int)f; // 100000000

			Assert.AreNotEqual(i1, i2);
		}

		#region Increment and Decrement Operators

		[TestMethod]

		public void Outputs0xisnow1()
		{
			int x = 0;

			Assert.AreEqual(0, x++);
		}

		[TestMethod]
		public void Outputs1yisnow1()
		{
			int y = 0;

			Assert.AreEqual(1, ++y);
		}


		#endregion

		[TestMethod]
		public void intOverflowtoMaxValue()
		{
			int i = int.MinValue;
			i--;
			Assert.AreEqual(int.MaxValue, i);
		}

		#endregion


	}
}

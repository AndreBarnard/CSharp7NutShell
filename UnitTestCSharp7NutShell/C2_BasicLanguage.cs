﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C7NutShell.C2_BasicLanguage;

namespace UnitTestC7NutShell
{
	[TestClass]
	public class C2_BasicLanguage
	{
		#region Type Basic
		[TestMethod]
		[TestCategory("Type Basic - Value Types Versus Reference types")]
		public void ContrastInstanceStaticMembers()
		{

			Panda P1 = new Panda("Pan Dee");
			Panda P2 = new Panda("Pan Dah");

			Console.WriteLine(P1.Name);
			Console.WriteLine(P2.Name);

			Assert.AreEqual(2, Panda.Population);

		}

		[TestMethod]
		[TestCategory("Type Basic - Value Types Versus Reference types")]
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
		[TestCategory("Type Basic - Value Types Versus Reference types")]
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
		[TestCategory("Numeric Types - Numeric Literals")]
		public void NumericliteralTypeC7UnderscoreReadeble()
		{
			int million = 1_000_000;
			Assert.AreEqual(1000000, million);
		}

		[TestMethod]
		[TestCategory("Numeric Types - Numeric Literals")]
		public void NumericliteralTypeInferenceDecimal()
		{
			Type type = 1.0.GetType();
			Assert.AreEqual("System.Double", type.FullName);
		}

		[TestMethod]
		[TestCategory("Numeric Types - Numeric Literals")]
		public void NumericliteralTypeInferenceExponentialSymbolDecimal()
		{
			Type type = 1E06.GetType();
			Assert.AreEqual("System.Double", type.FullName);
		}

		[TestMethod]
		[TestCategory("Numeric Types - Numeric Literals")]
		public void NumericliteralTypeInferenceInterger()
		{
			Type type = 1.GetType();
			Assert.AreEqual("System.Int32", type.FullName);
		}

		[TestMethod]
		[TestCategory("Numeric Types - Numeric Literals")]
		public void NumericliteralTypeInferenceUInt32()
		{
			Type type = 0xF0000000.GetType();
			Assert.AreEqual("System.UInt32", type.FullName);
		}

		[TestMethod]
		[TestCategory("Numeric Types - Numeric Literals")]
		public void NumericliteralTypeInferenceInt64()
		{
			Type type = 0x100000000.GetType();
			Assert.AreEqual("System.Int64", type.FullName);
		}


		[TestMethod]
		[TestCategory("Numeric Types - Numeric Conversions")]
		public void ImplicitConversionIntToLong()
		{
			int x = 12345;
			long y = x;
			Assert.AreNotSame(y, x);
		}

		[TestMethod]
		[TestCategory("Numeric Types - Numeric Conversions")]
		public void ExplicitConversionIntToShort()
		{
			int x = 12345;
			short s = (short)x;
			Assert.AreNotSame(s, x);
		}


		[TestMethod]
		[TestCategory("Numeric Types - Numeric Conversions")]
		public void MagnitudePreservedPrecisionLost()
		{
			int i1 = 100000001;
			float f = i1; // Magnitude preserved, precision lost
			int i2 = (int)f; // 100000000

			Assert.AreNotEqual(i1, i2);
		}


		[TestMethod]
		[TestCategory("Numeric Types - Specialized Operations on Integral Types")]
		public void Outputs0xisnow1()
		{
			int x = 0;

			Assert.AreEqual(0, x++);
		}

		[TestMethod]
		[TestCategory("Numeric Types - Specialized Operations on Integral Types")]
		public void Outputs1yisnow1()
		{
			int y = 0;

			Assert.AreEqual(1, ++y);
		}

		[TestMethod]
		[TestCategory("Numeric Types - Specialized Operations on Integral Types")]
		public void intOverflowtoMaxValue()
		{
			int i = int.MinValue;
			i--;
			Assert.AreEqual(int.MaxValue, i);
		}

		[TestMethod]
		[TestCategory("Numeric Types - Specialized Operations on Integral Types")]
		public void CheckedExpression()
		{
			int a = 1000000;
			int b = 1000000;

			try
			{
				int c = checked(a * b);
				Assert.Fail("no exception thrown");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex.Message == "Arithmetic operation resulted in an overflow.");
			}

		}

		[TestMethod]
		[TestCategory("Numeric Types - Specialized Operations on Integral Types")]
		public void CheckedAllExpressionStatementBlock()
		{
			int a = 1000000;
			int b = 1000000;

			try
			{
				int c;

				checked
				{
					c = a * b;
				}

				Assert.Fail("no exception thrown");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex.Message == "Arithmetic operation resulted in an overflow.");
			}

		}


		[TestMethod]
		[TestCategory("Numeric Types -8- and 16-Bit Integral Types")]
		public void ExplicitCastShortLackAritheticOperator()
		{
			//Arrange
			short result = 2;
			short x = 1, y = 1;
			//Act

			short z = (short)(x + y);

			//Assert
			Assert.AreEqual(result, z);

		}

		[DataTestMethod]
		[TestCategory("Numeric Types - Special Float and Double Values")]
		[DataRow(1.0, 0.0)]
		[DataRow(-1.0, 0.0)]
		[DataRow(1.0, -0.0)]
		[DataRow(-1.0, -0.0)]
		public void DividingZeroResultInfinity(double Value, double Zero)
		{
			//arrange

			//act
			double d = Value / Zero;

			//assert
			Assert.IsTrue(double.IsInfinity(d));
		}

		[TestMethod]
		[TestCategory("Numeric Types - Special Float and Double Values")]
		public void DividingZeroByZero_NaN()
		{
			//Arrange
			double Value = 0.0, Zero = 0.0;
			//Act
			double d = Value / Zero;

			//Assert
			Assert.IsTrue(double.IsNaN(d));
		}

		[TestMethod]
		[TestCategory("Numeric Types - Special Float and Double Values")]
		public void SubtractingInfinityFromInfinity_NaN()
		{
			//Arrange
			double Value = 1.0, Zero = 0.0;
			//Act

			double d = (Value / Zero) - (Value / Zero);

			//Assert
			Assert.IsTrue(double.IsNaN(d));

		}


		[TestMethod]
		[TestCategory("Numeric Types - Special Float and Double Values")]
		public void NaN_NotEq_NaN()
		{
			//Arrange
			double Value = 0.0, Zero = 0.0;
			//Act

			double d = (Value / Zero);

			//Assert
			Assert.IsFalse(d == double.NaN);

		}

		[TestMethod]
		[TestCategory("Numeric Types - Special Float and Double Values")]
		public void Use_Object_Equals_Two_NaN_Same()
		{
			//Arrange
			double Value = 0.0, Zero = 0.0;
			//Act

			double d = (Value / Zero);

			bool IsEqual = object.Equals(d, double.NaN);

			//Assert
			Assert.IsTrue(IsEqual);

		}


		[TestMethod]
		[TestCategory("Numeric Types - Special Float and Double Values")]
		public void double_Rounding()
		{
			//Arrange
			double d = (1.0 / 6.0);
			//Act

			double notQuiteWholeD = d + d + d + d + d + d;

			//Assert
			Assert.IsTrue(notQuiteWholeD < 1.0);

		}

		[TestMethod]
		[TestCategory("Numeric Types - Special Float and Double Values")]
		public void decimal_Rounding()
		{
			//Arrange
			decimal m = (1M / 6M);
			//Act

			decimal notQuiteWholeM = m + m + m + m + m + m;

			//Assert
			Assert.IsFalse(notQuiteWholeM == 1M);

		}

		#endregion

		#region Boolean Types

		[DataTestMethod]
		[TestCategory("Boolean Types - Equality and Comparision Operators")]
		[DataRow(1, 2)]
		[DataRow(1, 1)]
		[DataRow("StingVal1", "StingVal1")]
		[DataRow("StingVal1", "StingVal2")]
		[DataRow(0.5, 0.35)]
		[DataRow(0.75, 0.33)]
		[DataRow("StingVal1", 1)]
		public void EqualityOperationResultTypeBool(object objX, object objY)
		{
			//arrange

			//act
			Type type = (objX == objY).GetType();

			//assert
			Assert.AreEqual("System.Boolean", type.FullName);
		}

		[TestMethod]
		[TestCategory("Boolean Types - Equality and Comparision Operators")]
		public void ValueTypeEquality()
		{
			//arrange
			Dude d1 = new Dude("John");
			Dude d2 = new Dude("John");

			//act
			bool IsEqual = d1 == d2;

			//assert
			Assert.IsFalse(IsEqual);
		}

		[TestMethod]
		[TestCategory("Boolean Types - Equality and Comparision Operators")]
		public void ReferenceTypeEquality()
		{
			//arrange
			Dude d1 = new Dude("John");
			Dude d2 = d1;

			//act
			bool IsEqual = d1 == d2;

			//assert
			Assert.IsTrue(IsEqual);
		}

		[DataTestMethod]
		[TestCategory("Boolean Types - Equality and Comparision Operators")]
		[DataRow(true,true,false,true)]
		[DataRow(true, false, false, true)]
		[DataRow(false, true, false, true)]
		[DataRow(false, false, false, false)]
		[DataRow(true, true, true, false)]
		[DataRow(true, false, true, false)]
		[DataRow(false, true, true, false)]
		[DataRow(false, false, true, false)]
		public void Operators_shortcircuit_evaluation(bool rainy, bool sunny, bool windy, bool expected)
		{
			//arrange

			//act
			bool useUmberalla = Umberalla.UseUmberalla(rainy, sunny, windy);

			//assert
			Assert.AreEqual(expected, useUmberalla);
		}

		[DataTestMethod]
		[TestCategory("Boolean Types - Equality and Comparision Operators")]
		[DataRow(true, true, false, true)]
		[DataRow(true, false, false, true)]
		[DataRow(false, true, false, true)]
		[DataRow(false, false, false, false)]
		[DataRow(true, true, true, false)]
		[DataRow(true, false, true, false)]
		[DataRow(false, true, true, false)]
		[DataRow(false, false, true, false)]
		public void Operators_NotShortcircuit_evaluation(bool rainy, bool sunny, bool windy, bool expected)
		{
			//arrange

			//act
			bool useUmberalla = Umberalla.UseUmberallaNoShortCircut(rainy, sunny, windy);

			//assert
			Assert.AreEqual(expected, useUmberalla);
		}

		[DataTestMethod]
		[TestCategory("Boolean Types - Equality and Comparision Operators")]
		[DataRow(1, 2, 2)]
		[DataRow(7, 2, 7)]
		[DataRow(8, 8, 8)]
		[DataRow(int.MaxValue, int.MinValue, int.MaxValue)]
		[DataRow(1_000_000, 1_000_000_000, 1_000_000_000)]
		public void TernaryOperators(int a, int b, int expected)
		{
			//arrange

			//act
			int max = Numbers.Max(a, b);

			//assert
			Assert.AreEqual(expected, max);
		}

		#endregion
	}
}
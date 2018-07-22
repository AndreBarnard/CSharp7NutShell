using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C7NutShell.C2_BasicLanguage;
using System.Text;
using C7NutShell.C2_BasicLanguage.VariablesAndParameters;
using C7NutShell.C2_BasicLanguage.NULL;
using C7NutShell.C2_BasicLanguage.Statement;

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
		[DataRow(true, true, false, true)]
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

		#region String Types

		[TestMethod]
		[TestCategory("String Types")]
		public void StringIsAReferenceType()
		{
			//arrange
			string a = "test";
			string b = "test";
			//act

			bool IsEqual = (a == b);

			//assert
			Assert.IsTrue(IsEqual);
		}

		[TestMethod]
		[TestCategory("String Types")]
		public void StringEscapeVsVerbatimBackslash()
		{
			//arrange
			string escape = "\\\\server\\fileshare\\helloworld.cs";
			string verbatim = @"\\server\fileshare\helloworld.cs";
			//act

			bool IsEqual = (escape == verbatim);

			//assert
			Assert.IsTrue(IsEqual);
		}

		[TestMethod]
		[TestCategory("String Types")]
		public void StringEscapeVsVerbatiMultiline()
		{
			//arrange
			string escape = "First Line\r\nSecond Line";
			string verbatim = @"First Line
Second Line";
			//act

			bool IsEqual = (escape == verbatim);

			//assert True if your IDE uses CR-LF line separators:
			Assert.IsTrue(IsEqual);
		}

		[DataTestMethod]
		[TestCategory("String Types")]
		[DataRow("a", "b", "ab")]
		[DataRow("a", "5", "a5")]
		[DataRow("Tom", "Boy", "TomBoy")]
		public void Stringconcatenation(string a, string b, string expected)
		{
			//arrange

			//act
			string s = a + b;

			//assert
			Assert.AreEqual(expected, s);
		}

		[TestMethod]
		[TestCategory("String Types")]
		public void StringInterpolation()
		{
			//arrange
			int x = 4;
			string expected = "A square has 4 sides";

			//act
			string a = $"A square has {x} sides";

			//assert
			Assert.AreEqual(expected, a);
		}



		#endregion

		#region Arrays

		[TestMethod]
		[TestCategory("Arrays")]
		public void Arrays()
		{
			//arrange
			C7NutShell.C2_BasicLanguage.Array.SpeechSound SpeechSound = new C7NutShell.C2_BasicLanguage.Array.SpeechSound();
			char[] vowles = SpeechSound.Vowels;

			//act

			//assert
			Assert.AreEqual('e', vowles[1]);
		}

		[TestMethod]
		[TestCategory("Arrays")]
		public void ArraysIterate()
		{
			//arrange
			C7NutShell.C2_BasicLanguage.Array.SpeechSound SpeechSound = new C7NutShell.C2_BasicLanguage.Array.SpeechSound();
			char[] vowles = SpeechSound.Vowels;
			string vowlesConcatinated = "";

			//act
			for (int i = 0; i < vowles.Length; i++)
			{
				vowlesConcatinated += vowles[i];
			}

			//assert
			Assert.AreEqual("aeiou", vowlesConcatinated);
		}


		[TestMethod]
		[TestCategory("Arrays")]
		public void ArraysSingleStepDeclare()
		{
			//arrange
			char[] vowelsA = new char[] { 'a', 'e', 'i', 'o', 'u' };

			//act
			char[] vowelsB = { 'a', 'e', 'i', 'o', 'u' };

			//assert
			Assert.AreEqual(vowelsA[2], vowelsB[2]);
		}

		[TestMethod]
		[TestCategory("Arrays - Default Element Initialization")]
		public void PreinitializesDefaultValues()
		{
			//arrange
			int[] a = new int[1000];

			//act

			//assert
			Assert.AreEqual(0, a[123]);
		}

		[TestMethod]
		[TestCategory("Arrays - Default Element Initialization")]
		public void ElementValueType()
		{
			//arrange
			StructPoint[] a = new StructPoint[1000];

			//act
			int x = a[500].X;

			//assert
			Assert.AreEqual(0, x);
		}

		[TestMethod]
		[TestCategory("Arrays - Default Element Initialization")]
		public void ElementReferenceType()
		{
			//arrange
			ClassPoint[] a = new ClassPoint[1000];

			//act & assert
			try
			{
				int x = a[500].X;

				Assert.Fail("no exception thrown");
			}
			catch (Exception ex)
			{

				Assert.IsTrue(ex.Message == "Object reference not set to an instance of an object.");
			}
		}

		[TestMethod]
		[TestCategory("Arrays - Default Element Initialization")]
		public void ElementReferenceTypeExplicitlyInstantiate()
		{
			//arrange
			ClassPoint[] a = new ClassPoint[1000];

			//act
			for (int i = 0; i < a.Length; i++)
			{
				a[i] = new ClassPoint();
			}

			int x = a[500].X;

			//assert
			Assert.AreEqual(0, x);

		}

		[TestMethod]
		[TestCategory("Arrays - Multidimensional Arrays")]
		public void RectangularArrays()
		{
			//arrange
			int[,] matrix = new int[3, 3];

			int[,] matrix2 = new int[,]
			{
			{0,1,2},
			{3,4,5},
			{6,7,8}
			};

			//act
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] = i * 3 + j;
				}
			}

			//assert
			Assert.IsTrue(matrix.Length == matrix2.Length);

		}


		[TestMethod]
		[TestCategory("Arrays - Multidimensional Arrays")]
		public void Jaggedarrays()
		{
			//arrange
			int[][] matrix = new int[3][];

			int[][] matrix2 = new int[][]
			{
			new int[]{0,1,2},
			new int[]{3,4,5},
			new int[]{6,7,8,9}
			};

			//act
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				matrix[i] = new int[3];
				for (int j = 0; j < matrix[i].Length; j++)
				{
					matrix[i][j] = i * 3 + j;
				}
			}

			//assert
			Assert.IsTrue(matrix.Length == matrix2.Length);

		}

		#endregion

		#region Variables and Parameters
		[DataTestMethod]
		[DataRow(1, 2)]
		[DataRow(7, 8)]
		[DataRow(20, 21)]
		[DataRow(100, 101)]
		[TestCategory("Variables and Parameters")]
		public void Stack(int x, int listLenght)
		{
			//Arrange
			C7NutShell.C2_BasicLanguage.VariablesAndParameters.Stack stack = new C7NutShell.C2_BasicLanguage.VariablesAndParameters.Stack();

			//Act
			stack.Factorial(x);

			//Assert
			Assert.AreEqual(listLenght, stack.IntergerList.Count);

		}

		[TestMethod]
		[TestCategory("Variables and Parameters")]
		public void Heap()
		{
			StringBuilder ref1 = new StringBuilder("object1");
			Console.WriteLine(ref1);
			// The StringBuilder referenced by ref1 is now eligible for GC.

			StringBuilder ref2 = new StringBuilder("object2");
			StringBuilder ref3 = ref2;
			// The StringBuilder referenced by ref2 is NOT yet eligible for GC.

			Console.WriteLine(ref3);
		}

		[DataTestMethod]
		[DataRow(1, 2)]
		[DataRow(7, 8)]
		[DataRow(19, 20)]
		[DataRow(-1, 0)]
		[TestCategory("Variables and Parameters")]
		[Ignore]
		public void DefaultValues(string FullyQualifiedName, object expectedValue)
		{

			//Type t = Type.GetType(FullyQualifiedName);

			//Arrange
			//
			object defaultValue;

			//Act

			switch (FullyQualifiedName)
			{
				case "System.Int32":
					defaultValue = default(Int32);
					break;
				case "System.Char":
					defaultValue = default(Char);
					break;
				case "System.Boolean":
					defaultValue = default(Boolean);
					break;
				case "System.Decimal":
					defaultValue = default(Decimal);
					expectedValue = Convert.ToDecimal(expectedValue);
					break;
				case "System.String":
					defaultValue = default(String);
					break;
				default:
					defaultValue = null;
					break;
			}

			//Assert
			Assert.AreEqual(expectedValue, defaultValue);

		}


		[DataTestMethod]
		[DataRow(1, 2)]
		[DataRow(7, 8)]
		[DataRow(20, 21)]
		[DataRow(100, 101)]
		[TestCategory("Variables and Parameters")]
		public void Parameters(int p, int expected)
		{
			//Arrange
			//Act
			p = p + 1;

			//Assert
			Assert.AreEqual(expected, p);

		}

		[TestMethod]
		[TestCategory("Variables and Parameters")]
		public void ValueParameter()
		{
			StringBuilder sb = new StringBuilder();
			ParameterModifier.Foo(sb); // Make a copy of x

			Assert.AreEqual("test", sb.ToString());
		}

		[TestMethod]
		[TestCategory("Variables and Parameters")]
		public void refmodifier()
		{
			int x = 8;
			ParameterModifier.Foo(ref x); // Ask Foo to deal directly with x
			Assert.AreEqual(9, x); // x is now 9
		}

		[DataTestMethod]
		[DataRow("Penn", "Teller")]
		[DataRow("Waldo", "Jeandre")]
		[DataRow("Girl", "Boy")]
		[DataRow("Sun", "Moon")]
		[TestCategory("Variables and Parameters")]
		public void refmodifierSwap(string x, string y)
		{
			//Arrange
			string expected = y;
			//Act
			ParameterModifier.Swap(ref x, ref y);
			//Assert
			Assert.AreEqual(expected, x);
		}

		[DataTestMethod]
		[DataRow("Stevie Ray Vaughan", "Stevie Ray", "Vaughan")]
		[DataRow("Andre Barnard", "Andre", "Barnard")]
		[DataRow("Jeanerien Michelle Barnard", "Jeanerien Michelle", "Barnard")]
		[DataRow("Piet Pompies", "Piet", "Pompies")]
		[TestCategory("Variables and Parameters")]
		public void outmodifierSplit(string Fullname, string expectedFirstName, string expectedLastName)
		{
			//Arrange
			string firstName, lastName;
			//Act
			ParameterModifier.Split(Fullname, out firstName, out lastName);
			//Assert
			Assert.AreEqual(expectedFirstName, firstName);
			Assert.AreEqual(expectedLastName, lastName);
		}


		[DataTestMethod]
		[DataRow("Stevie Ray Vaughan", "Stevie Ray", "Vaughan")]
		[DataRow("Andre Barnard", "Andre", "Barnard")]
		[DataRow("Jeanerien Michelle Barnard", "Jeanerien Michelle", "Barnard")]
		[DataRow("Piet Pompies", "Piet", "Pompies")]
		[TestCategory("Variables and Parameters")]
		public void Csharpout7modifierSplit(string Fullname, string expectedFirstName, string expectedLastName)
		{
			//Arrange

			//Act
			ParameterModifier.Split(Fullname, out string firstName, out string lastName);
			//Assert
			Assert.AreEqual(expectedFirstName, firstName);
			Assert.AreEqual(expectedLastName, lastName);
		}

		[DataTestMethod]
		[DataRow("Stevie Ray Vaughan", "Stevie Ray")]
		[DataRow("Andre Barnard", "Andre")]
		[DataRow("Jeanerien Michelle Barnard", "Jeanerien Michelle")]
		[DataRow("Piet Pompies", "Piet")]
		[TestCategory("Variables and Parameters")]
		public void Csharp_discard_out7modifierSplit(string Fullname, string expectedFirstName)
		{
			//Arrange

			//Act
			ParameterModifier.Split(Fullname, out string firstName, out _);
			//Assert
			Assert.AreEqual(expectedFirstName, firstName);

		}

		[TestMethod]
		[TestCategory("Variables and Parameters")]
		public void paramsmodifier()
		{

			//Arrange
			int expectedSum = 10;

			//Act

			int total = ParameterModifier.Sum(1, 2, 3, 4);

			//Assert
			Assert.AreEqual(expectedSum, total);

		}

		[TestMethod]
		[TestCategory("Variables and Parameters")]
		public void optionalParameters()
		{

			//Arrange
			string expectedString = "1, 0";

			//Act

			string actualString = ParameterModifier.ConcatinateInt(1);

			//Assert
			Assert.AreEqual(expectedString, actualString);

		}

		[TestMethod]
		[TestCategory("Variables and Parameters")]
		public void namedArguments()
		{

			//Arrange
			string yFirstString = ParameterModifier.ConcatinateInt(y: 2, x: 1);
			string xFirstString = ParameterModifier.ConcatinateInt(x: 1, y: 2);

			//Assert
			Assert.AreEqual(yFirstString, xFirstString);

		}

		[TestMethod]
		[TestCategory("Variables and Parameters")]
		public void refLocals()
		{

			//Arrange
			int[] number = { 0, 1, 2, 3, 4 };
			ref int numRef = ref number[2];

			//Act 
			numRef *= 10;

			Console.WriteLine(numRef);
			Console.WriteLine(number[2]);

			//Assert
			Assert.AreEqual(20, number[2]);

		}


		static string X = "Old Value";
		static ref string GetX() => ref X;

		[TestMethod]
		[TestCategory("Variables and Parameters")]
		public void refReturns()
		{

			//Arrange			
			ref string xRef = ref GetX();

			//Act 
			xRef = "New Value";
			Console.WriteLine(xRef);


			//Assert
			Assert.AreEqual("New Value", X);

		}


		#endregion

		#region Null Operators
		[TestMethod]
		[TestCategory("Null Operators")]
		public void Null_Coalescing_Operator()
		{
			//Arrange
			string s1 = null;

			//Act
			string s2 = s1 ?? "nothing";

			//Assert
			Assert.AreEqual("nothing", s2);
		}

		[TestMethod]
		[TestCategory("Null Operators")]
		public void Elvis_Operator()
		{
			//Arrange
			System.Text.StringBuilder sb = null;

			//Act
			string s1 = sb?.ToString();

			//Assert
			Assert.IsNull(s1);
		}

		[TestMethod]
		[TestCategory("Null Operators")]
		public void Elvis_Operator_Short_Circuits()
		{
			//Arrange
			System.Text.StringBuilder sb = null;

			//Act
			string s1 = sb?.ToString().ToUpper();

			//Assert
			Assert.IsNull(s1);
		}

		[TestMethod]
		[TestCategory("Null Operators")]
		public void Elvis_Operator_call_void_method()
		{
			//Arrange
			Elvis evlis = null;

			//Act
			evlis?.Quote();

			//Assert
			Assert.IsNull(evlis);
		}


		[TestMethod]
		[TestCategory("Null Operators")]
		public void Elvis_Operator_Combined_Null_Coalescing_Operator()
		{
			//Arrange
			System.Text.StringBuilder sb = null;

			//Act
			string s = sb?.ToString() ?? "nothing";

			//Assert
			Assert.AreEqual("nothing", s);
		}

		#endregion

		#region Statments
		[DataTestMethod]
		[DataRow(7)]
		[DataRow(35)]
		[DataRow(21)]
		[DataRow(18)]
		[DataRow(70)]
		[TestCategory("Statments")]
		public void if_else_statement(int age)
		{
			if (age >= 35)
				Console.WriteLine("You can be president!");
			else if (age >= 21)
				Console.WriteLine("You can drink!");
			else if (age >= 18)
				Console.WriteLine("You can vote!");
			else
				Console.WriteLine("You can wait!");
		}

		[DataTestMethod]
		[DataRow(7, "7")]
		[DataRow(13, "King")]
		[DataRow(-1, "Queen")]
		[DataRow(12, "Queen")]
		[DataRow(11, "Jack")]
		[TestCategory("Statments")]
		public void switch_statement(int cardNumber, string ExpectedCard)
		{
			string cardName;
			switch (cardNumber)
			{
				case 13:
					cardName = "King";
					break;
				case 12:
					cardName = "Queen";
					break;
				case 11:
					cardName = "Jack";
					break;
				case -1:          //Jocker is -1
					goto case 12;   //In the game joker counts as Queen
				default:
					cardName = cardNumber.ToString();
					break;
			}

			Assert.AreEqual(ExpectedCard, cardName);
		}


		[DataTestMethod]
		[DataRow(7, "Plain Card")]
		[DataRow(13, "Face Card")]
		[DataRow(12, "Face Card")]
		[DataRow(11, "Face Card")]
		[TestCategory("Statments")]
		public void switch_statement_execute_same_code(int cardNumber, string ExpectedCard)
		{
			string cardName;
			switch (cardNumber)
			{
				case 13:
				case 12:
				case 11:
					cardName = "Face Card";
					break;
				default:
					cardName = "Plain Card";
					break;
			}

			Assert.AreEqual(ExpectedCard, cardName);
		}

		[DataTestMethod]
		[DataRow(7, "int")]
		[DataRow("I am a string value", "string")]
		[DataRow('A', "don't")]
		[TestCategory("Statments")]
		public void switch_statement_types(object x, string ExpectedString)
		{
			string typeMessage = SwitchStatement.TellMeMyType(x);

			Console.WriteLine(typeMessage);
			StringAssert.Contains(typeMessage, ExpectedString);
		}

		[DataTestMethod]
		[DataRow(true, "True")]
		[DataRow(false, "False")]
		[TestCategory("Statments")]
		public void switch_statement_with_keyword(bool x, string ExpectedString)
		{
			string typeMessage = SwitchStatement.BoolStringValue(x);

			Console.WriteLine(typeMessage);
			StringAssert.Contains(typeMessage, ExpectedString);
		}

		[TestMethod]
		[TestCategory("Statments")]
		public void switch_statemen_ValueGreaterThan1000()
		{
			float f = 1500;

			string floatString = SwitchStatement.ValueGreaterThan1000(f);

			Assert.AreEqual("We can refer to x here but not f or d or m", floatString);

			double d = 1500;

			string doubleString = SwitchStatement.ValueGreaterThan1000(d);

			Assert.AreEqual("We can refer to x here but not f or d or m", doubleString);

			decimal dl = 1500;

			string decimalString = SwitchStatement.ValueGreaterThan1000(dl);

			Assert.AreEqual("We can refer to x here but not f or d or m", decimalString);

			string nullString = SwitchStatement.ValueGreaterThan1000(null);
			Assert.AreEqual("Nothing here", nullString);
		}

		#endregion

		#region  Iteration Statements

		[TestMethod]
		[TestCategory("Iteration Statements")]
		public void for_Fibonacci()
		{
			string FibonaccitString = IterationStatements.FibonacciSeq();

			Assert.AreEqual("1,1,2,3,5,8,13,21,34,55", FibonaccitString);
		}

		#endregion

		#region jump statments

		[TestMethod]
		[TestCategory("Jump Statements")]
		public void break_statement()
		{
			int x = 0;
			while (true)
			{
				if (x++ > 5)
					break; // break from the loop
			}

			Assert.AreEqual(7, x);			// execution continues here after break
		}

		[TestMethod]
		[TestCategory("Jump Statements")]
		public void continue_statement()
		{
			//Arrange
			StringBuilder sb = new StringBuilder();
			string expectedString = "1 3 5 7 9 ";
			//Act
			for (int i = 0; i < 10; i++)
			{
				if ((i % 2) == 0) // If i is even,
					continue; // continue with next iteration
				sb.Append($"{i} ");
			}

			//Assert
			Assert.AreEqual(expectedString, sb.ToString());      // execution continues here after break
		}

		[TestMethod]
		[TestCategory("Jump Statements")]
		public void goto_statement()
		{
			//Arrange
			StringBuilder sb = new StringBuilder();
			string expectedString = "1 2 3 4 5 ";
			//Act
			int i = 1;
			startloop:
			if(i <= 5)
			{
				sb.Append($"{i} ");
				i++;
				goto startloop;
			}

			//Assert
			Assert.AreEqual(expectedString, sb.ToString());      // execution continues here after break
		}


		#endregion
	}
}

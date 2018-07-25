using C7NutShell.C3_CreatingTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCSharp7NutShell
{
	[TestClass]
	public class C3_CreatingTypes
	{

		#region Classes
		[DataTestMethod]
		[TestCategory("Classes")]
		[DataRow(10, 20)]
		[DataRow(50, 100)]
		[DataRow(5, 10)]
		[DataRow(100, 200)]
		public void Expression_bodied_methods(int x, int expectedInt)
		{
			//Arrange
			Methods method = new Methods();

			//Act
			int mutiplier = method.DoubleMyValue(x);

			//Assert
			Assert.AreEqual(expectedInt, mutiplier);
		}


		[TestMethod]
		[TestCategory("Classes")]
		public void Expression_bodied_methods_Void()
		{
			//Arrange
			Methods method = new Methods();

			//Act
			method.OutputInt(1_000);
		}


		[TestMethod]
		[TestCategory("Classes")]
		public void Overloading_methods()
		{
			//Arrange
			Methods method = new Methods();

			int i = 1_000;
			double d = 100.50;
			float f = 450.85F;
			//Act
			method.Overloading(i);
			method.Overloading(d);
			method.Overloading(f, i);
			method.Overloading(i, f);
		}


		[TestMethod]
		[TestCategory("Classes")]
		public void Local_methods()
		{
			//Arrange
			Methods method = new Methods();

			//Act
			method.WriteCubes();
		}

		#endregion

		#region Instance Constructors
		[TestMethod]
		[TestCategory("Instance Constructors")]
		public void ConstructorInstance()
		{
			//Arrange
			Panda p = new Panda("Petey");

			//Act
			//Assert
			Assert.AreEqual("Petey", p.ToString());

		}

		[TestMethod]
		[TestCategory("Instance Constructors")]
		public void Overloading_constructors()
		{

			//Arrange
			Wine w1 = new Wine(250);
			Wine w2 = new Wine(250, 2010);
			Wine w3 = new Wine(250, DateTime.Parse("2010/01/01"));

			//Assert

			Assert.AreEqual(250, w1.Price);
			Assert.AreEqual(2010, w2.Year);
			Assert.AreEqual(2010, w3.Year);
		}


		[TestMethod]
		[TestCategory("Instance Constructors")]
		public void Deconstructors()
		{

			//Arrange
			var rect = new Rectangle (3, 4);

			//Act
			//rect.Deconstruct(out var width, out var height); // Deconstruction
					

			var (width, height) = rect;

			//Assert

			Assert.AreEqual(3, width);
			Assert.AreEqual(4, height);
		}

		#endregion
	}
}

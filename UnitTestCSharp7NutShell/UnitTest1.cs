using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp7NutShell;
namespace UnitTestCSharp7NutShell
{
	[TestClass]
	public class UnitTest1
	{
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
	}
}

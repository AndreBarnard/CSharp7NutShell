using C7NutShell.C2_BasicLanguage;
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
      C7NutShell.C3_CreatingTypes.Panda p = new C7NutShell.C3_CreatingTypes.Panda("Petey");

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

      var d = DateTime.MinValue;

      //Arrange
      var rect = new Rectangle(3, 4);

      //Act
      //rect.Deconstruct(out var width, out var height); // Deconstruction


      var (width, height) = rect;

      //Assert

      Assert.AreEqual(3, width);
      Assert.AreEqual(4, height);
    }

    #endregion

    #region Properties

    [TestMethod]
    [TestCategory("Properties")]
    public void readonlyproperty()
    {
      Properties prop = new Properties(100, 100);

      Assert.AreEqual(10000, prop.Worth);

    }


    [TestMethod]
    [TestCategory("Properties")]
    public void readonlyC6Expressionbodiedproperty()
    {
      Properties prop = new Properties(100, 100);

      Assert.AreEqual(10000, prop.WorthC6Expressionbodied);

    }

    [TestMethod]
    [TestCategory("Properties")]
    public void readonlyC7Expressionbodiedproperty()
    {
      Properties prop = new Properties(100, 100);

      prop.WorthC7ExpressionbodiedSet = 10000;

      Assert.AreEqual(10000, prop.WorthC7ExpressionbodiedSet);

    }

    [TestMethod]
    [TestCategory("Properties")]
    public void Initialzerproperty()
    {
      Stock stock = new Stock();

      Assert.AreEqual(123, stock.CurrentPrice);

    }

    [TestMethod]
    [TestCategory("Properties")]
    public void InitialzerReadonlyProperty()
    {
      Stock stock = new Stock();

      Assert.AreEqual(999, stock.Maximum);

    }

    #endregion

    #region Indexers

    [TestMethod]
    [TestCategory("Indexers")]

    public void Indexers()
    {
      string s = "hello";

      Assert.AreEqual('h', s[0]);
      Assert.AreEqual('l', s[3]);
    }

    [TestMethod]
    [TestCategory("Indexers")]
    public void IndexersNull()
    {
      string s = null;

      Assert.IsNull(s?[0]);
    }


    [TestMethod]
    [TestCategory("Indexers")]
    public void ImplementingAnIndexer()
    {
      Sentence s = new Sentence();

      Assert.AreEqual("fox", s[3]);

      s[3] = "kangaroo";

      Assert.AreEqual("kangaroo", s[3]);

    }

    [TestMethod]
    [TestCategory("Indexers")]
    public void ImplementingReadonlyAnIndexer()
    {
      SentenceReadonlyIndexer s = new SentenceReadonlyIndexer();

      Assert.AreEqual("fox", s[3]);


    }


    #endregion

    [TestMethod]
    [TestCategory("nameof Operator")]
    public void nameofOperator()
    {

      string s = nameof(StringBuilder) + "." + nameof(StringBuilder.Length);

      Assert.AreEqual("StringBuilder.Length", s);
    }


    #region Inheritance

    [TestMethod]
    [TestCategory("Inheritance")]
    public void InheritanceSample()
    {
      Stocks msft = new Stocks
      {
        Name = "MSFT",
        SharesOwned = 1000
      };

      Assert.AreEqual("MSFT", msft.Name);
      Assert.AreEqual(1000, msft.SharesOwned);

      House mansion = new House
      {
        Name = "Mansion",
        Mortgage = 250000
      };

      Assert.AreEqual("Mansion", mansion.Name);
      Assert.AreEqual(250000, mansion.Mortgage);
    }

    [TestMethod]
    [TestCategory("Inheritance")]
    public void Polymorphism()
    {
      Stocks msft = new Stocks
      {
        Name = "MSFT",
        SharesOwned = 1000
      };

      Assert.AreEqual("MSFT", Asset.Display(msft));

      House mansion = new House
      {
        Name = "Mansion",
        Mortgage = 250000
      };

      Assert.AreEqual("Mansion", Asset.Display(mansion));
    }

    [TestMethod]
    [TestCategory("Inheritance")]
    public void Upcasting()
    {
      Stocks msft = new Stocks();
      Asset a = msft; // Upcast

      Assert.AreEqual(msft, a);
    }

    [TestMethod]
    [TestCategory("Inheritance")]
    public void Downcasting()
    {
      Stocks msft = new Stocks
      {
        Name = "MSFT",
        SharesOwned = 1000
      };
      Asset a = msft; // Upcast
      Stocks s = (Stocks)a; // Downcast


      Assert.AreEqual(1000, s.SharesOwned);
      Assert.AreEqual(msft, s);

      Assert.AreEqual(a, s);
    }

    [TestMethod]
    [TestCategory("Inheritance")]
    public void DowncastingException()
    {
      try
      {
        House h = new House();
        Asset a = h; // Upcast always succeeds
        Stocks s = (Stocks)a; // Downcast fails: a is not a Stock

        Assert.Fail();
      }
      catch (Exception ex)
      {
        StringAssert.Contains(ex.Message, "Unable to cast object of type");
      }
    }

    [TestMethod]
    [TestCategory("Inheritance")]
    public void Downcasting_as_operator()
    {
      try
      {
        House h = new House();
        Asset a = h; // Upcast always succeeds
        Stocks s = a as Stocks; // s is null; no exception thrown

        Assert.IsNull(s);
      }
      catch (Exception)
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    [TestCategory("Inheritance")]
    public void Is_operator()
    {
      try
      {
        Stocks s1 = new Stocks();
        Asset a = s1; // Upcast always succeeds

        if (a is Stocks s)
          Assert.AreEqual(0, s.SharesOwned);
      }
      catch (Exception)
      {
        Assert.Fail();
      }
    }

    [DataTestMethod]
    [DataRow(10000)]
    [DataRow(100000)]
    [DataRow(100)]
    [DataRow(200000)]
    [TestCategory("Inheritance")]
    public void Is_operator_variable_immediate_use(long sharesOwned)
    {
      try
      {
        Stocks s1 = new Stocks
        {
          Name = "MSFT",
          SharesOwned = sharesOwned
        };
        Asset a = s1; // Upcast always succeeds

        if (a is Stocks s && s.SharesOwned > 100000)
        {
          Console.WriteLine("Wealthy");
          Assert.IsTrue(s.SharesOwned > 100000);
        }
        else
        {
          s = new Stocks(); // s is in scope
          Assert.IsTrue(s.SharesOwned < 100000);
        }

        Assert.IsNotNull(s.SharesOwned); // Still in scope
      }
      catch (Exception)
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    [TestCategory("Inheritance")]
    public void VirtualFunctionMembers()
    {

      House mansion = new House { Name = "McMansion", Mortgage = 250000 };
      Asset a = mansion;

      Assert.AreEqual(250000, mansion.Liability);
      Assert.AreEqual(mansion.Liability, a.Liability);
    }



    #endregion

    #region Object Types
    [TestMethod]
    [TestCategory("Object Types")]
    public void GetTypeMethodAndTypeofOperator()
    {
      ClassPoint p = new ClassPoint();

      Assert.AreEqual("ClassPoint", p.GetType().Name);
      Assert.AreEqual("ClassPoint", typeof(ClassPoint).Name);
      Assert.AreEqual(p.GetType(), typeof(ClassPoint));
      Assert.AreEqual("Int32", p.X.GetType().Name);
      Assert.AreEqual("System.Int32", p.Y.GetType().FullName);
    }

    #endregion

    #region Enums

    [TestMethod]
    public void FlagsEnums()
    {
      //arrange
      BorderSidesFlaged leftRight = BorderSidesFlaged.Left | BorderSidesFlaged.Right;

      if((leftRight & BorderSidesFlaged.Left) != 0)
      {
        Console.WriteLine("Includes Left");
      }

      string formatted = leftRight.ToString();
      Assert.AreEqual("Left, Right", formatted);

      BorderSidesFlaged s = BorderSidesFlaged.Left;
      s |= BorderSidesFlaged.Right;
      Assert.IsTrue(s == leftRight);

      s ^= BorderSidesFlaged.Right;
      Assert.AreEqual(BorderSidesFlaged.Left, s);

    }

    [TestMethod]
    public void EnumIsDefined()
    {
      BorderSides side = (BorderSides)12345;

      Assert.IsFalse(Enum.IsDefined(typeof(BorderSides), side));
    }

    [TestMethod]
    public void FlagedEnumIsDefined()
    {
      for (int i = 0; i <= 16; i++)
      {
        BorderSidesFlaged side = (BorderSidesFlaged)i;
        Console.WriteLine($"{EnumsTest.IsFlagDefined(side)} {side}");
      }
    }

    [TestMethod]
    public void FlagedNumericEnumIsDefined()
    {
      for (int i = 0; i <= 100; i++)
      {
        NumericText numValue = (NumericText)i;
        Console.WriteLine($"{EnumsTest.IsFlagDefined(numValue)} {numValue} , IntValue : {i}");
      }
    }

    #endregion
  }
}



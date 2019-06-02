using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using C7NutShell.C14_ConcurrencyandAsynchrony;

namespace UnitTestCSharp7NutShell
{
  [TestClass]
  public class C14_ConcurrencyandAsynchrony
  {
    #region Threading
    [TestMethod]
    [TestCategory("Threading - Creating a thread")]
    public void ThreadTest()
    {

      Thread ty = new Thread(C14TestUtility.WriteY); // Kick off a new thread
      ty.Start();                                    // running WriteY

      Thread tx = new Thread(C14TestUtility.WriteX); // Kick off a new thread
      tx.Start();
    }

    [TestMethod]
    [TestCategory("Threading - Join and Sleep")]
    public void ThreadJoinTest()
    {

      Thread t = new Thread(C14TestUtility.WriteY); // Kick off a new thread
      t.Start();                                    // running WriteY
      t.Join();
      Console.WriteLine("Thread t has ended");
    }

    #endregion
  }
}

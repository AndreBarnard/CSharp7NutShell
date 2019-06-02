using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C14_ConcurrencyandAsynchrony
{
  public static class C14TestUtility
  {
    public static void WriteY()
    {
      for (int i = 0; i < 1000; i++) Console.Write("y");
    }

    public static void WriteX()
    {
      for (int i = 0; i < 1000; i++) Console.Write("X");
    }
  }
}

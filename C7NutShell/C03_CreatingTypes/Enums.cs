using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C3_CreatingTypes
{
  public enum BorderSides { Left = 1, Right = 2, Top = 4, Bottom = 8 }

  [Flags]
  public enum BorderSidesFlaged { None=0, Left = 1, Right=2, Top=4, Bottom=8 }

  public  static class EnumsTest
  {
    public static bool IsFlagDefined(Enum e)
    {
      decimal d;
      return !decimal.TryParse(e.ToString(), out d);
    }
  }

  [Flags]
  public enum NumericText { Zero = 0, One = 1, Two = 2, Three = 3, Four = 4, Five = One | Four, SumKindOfValue = Two | Four, Ten = 10, Fiveteen = 15, Thirty = 30, Fourty = 40, Fifty = 50, Sixthy = 60, SeventyOne = 71, EithyFive = 85, NinetyNine = 99  }
}

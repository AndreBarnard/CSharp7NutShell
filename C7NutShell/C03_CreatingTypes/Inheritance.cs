using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C3_CreatingTypes
{


	public class Asset
	{
		public string Name;
		public virtual decimal Liability => 0;

		public static string Display(Asset asset)
		{
			return asset.Name;
		}
	}

	public class Stocks : Asset // inherits from Asset
	{
		public long SharesOwned;
	}

	public class House : Asset // inherits from Asset
	{
		public decimal Mortgage;
		public override decimal Liability => Mortgage;
	}
}

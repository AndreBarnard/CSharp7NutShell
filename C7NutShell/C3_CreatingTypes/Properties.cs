using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C3_CreatingTypes
{
	public class Properties
	{

		public Properties(decimal CurrentPrice, decimal SharesOwned)
		{
			currentPrice = CurrentPrice;
			sharesOwned = SharesOwned;
		}

		decimal currentPrice, sharesOwned;

		public decimal Worth { get { return currentPrice * sharesOwned; } }

		public decimal WorthC6Expressionbodied => currentPrice* sharesOwned;

		public decimal WorthC7ExpressionbodiedSet
		{
			get => currentPrice * sharesOwned;
			set => sharesOwned = value / currentPrice;
		}

	}


	public class Stock
	{
		public decimal CurrentPrice { get; set; } = 123;

		public int Maximum { get; } = 999;
	}
}

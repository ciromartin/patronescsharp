using Decorator.Starbuzz.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Starbuzz.Component
{
    public class Expresso : Beverage
    {
		public override double Cost()
		{
			return GetSize(base.Size);
		}

		public override string GetDescription()
		{
			return "Expresso";
		}

		private double GetSize(BeverageSize size)
		{
			switch (size)
			{
				case BeverageSize.TALL:
					return 1.50;
				case BeverageSize.GRANDE:
					return 1.75;
				case BeverageSize.VENTI:
					return 3.00;
				default:
					return 1.50;
			}
		}
	}
}

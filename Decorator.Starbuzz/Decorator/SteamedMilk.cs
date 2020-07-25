using Decorator.Starbuzz.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Starbuzz.Decorator
{
    public class SteamedMilk : CondimentDecorator
    {
		private readonly Beverage _beverage;

		public SteamedMilk(Beverage beverage)
		{
			this._beverage = beverage;
		}

		public override string GetDescription()
		{
			return $"{_beverage.GetDescription()}, Steamed Milk";
		}

		public override double Cost()
		{
			return .10 + _beverage.Cost();
		}
	}
}

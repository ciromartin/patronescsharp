using Decorator.Starbuzz.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Starbuzz.Decorator
{
    public class Soy : CondimentDecorator
    {
		private readonly Beverage _beverage;

        public Soy(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
		{
			return $"{_beverage.GetDescription()}, Soy";
		}

		public override double Cost()
		{
			return .25 + _beverage.Cost();
		}
	}
}

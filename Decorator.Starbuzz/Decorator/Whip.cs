using Decorator.Starbuzz.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Starbuzz.Decorator
{
    public class Whip : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Whip(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
        {
            return $"{_beverage.GetDescription()}, Whip";
        }

        public override double Cost()
        {
            return .20 + _beverage.Cost();
        }
    }
}

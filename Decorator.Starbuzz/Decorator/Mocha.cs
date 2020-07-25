using Decorator.Starbuzz.Component;
using Decorator.Starbuzz.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Starbuzz.Decorator
{
    public class Mocha : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override double Cost()
        {
            return GetSize(base.Size);
        }

        private double GetSize(BeverageSize size)
        {
            switch (size)
            {
                case BeverageSize.TALL:
                    return .10 + _beverage.Cost();
                case BeverageSize.GRANDE:
                    return .15 + _beverage.Cost();
                case BeverageSize.VENTI:
                    return .20 + _beverage.Cost();
                default:
                    return .20;
            }
        }

        public override string GetDescription()
        {
            return $"{_beverage.GetDescription()}, Mocha"; 
        }
    }
}

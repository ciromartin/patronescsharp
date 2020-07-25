using Decorator.Starbuzz.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Starbuzz.Decorator
{
    public abstract class CondimentDecorator : Beverage
    {
        public override abstract string GetDescription();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Starbuzz.Component
{
    public class HouseBlend : Beverage
    {
		public override double Cost()
		{
			return .89;
		}

		public override string GetDescription()
		{
			return "House Blend Coffee";
		}
	}
}

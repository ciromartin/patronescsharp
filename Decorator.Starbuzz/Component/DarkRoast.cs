using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Starbuzz.Component
{
    public class DarkRoast : Beverage
    {
		public override double Cost()
		{
			return .99;
		}

		public override string GetDescription()
		{
			return "Dark Roast Coffee";
		}
	}
}

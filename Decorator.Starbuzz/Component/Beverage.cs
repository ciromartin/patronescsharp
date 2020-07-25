using Decorator.Starbuzz.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Starbuzz.Component
{
    public abstract class Beverage
    {
		private BeverageSize _size;

		public virtual string GetDescription()
		{
			return "Unknown Beverage";
		}

		public BeverageSize Size
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		public abstract double Cost();
	}
}

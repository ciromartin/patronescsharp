using Strategy.Duck.Behavior.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Duck.Behavior.Implementation
{
    public class Squeak : IQuackBehavior
    {
        public string Quack()
        {
            return "Squeak";
        }
    }
}

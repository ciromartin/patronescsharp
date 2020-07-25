using Strategy.Duck.Behavior.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Duck.Behavior.Implementation
{
    public class FlyWithWings : IFlyBehavior
    {
        public string Fly()
        {
            return "I'm flying!!";
        }
    }
}

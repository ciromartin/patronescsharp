using Strategy.Duck.Behavior.Implementation;
using Strategy.Duck.Behavior.Interfaces;
using System;

namespace Strategy.Duck.Model
{
    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            FlyBehavior = new FlyNoWay();
            QuackBehavior = new Squeak();
        }
        public override string Display()
        {
            return "I'm a Rubber duck";
        }
    }
}

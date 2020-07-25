using Strategy.Duck.Behavior.Interfaces;

namespace Strategy.Duck.Behavior.Implementation
{
    public class FlyNoWay : IFlyBehavior
    {
        public string Fly()
        {
            return "I can't fly.";
        }
    }
}
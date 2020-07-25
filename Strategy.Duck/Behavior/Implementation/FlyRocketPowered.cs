using Strategy.Duck.Behavior.Interfaces;

namespace Strategy.Duck.Behavior.Implementation
{
    public class FlyRocketPowered : IFlyBehavior
    {
        public string Fly()
        {
            return "I'm flying with a rocket!";
        }
    }
}
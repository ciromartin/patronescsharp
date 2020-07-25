using Strategy.Duck.Behavior.Implementation;
using Strategy.Duck.Behavior.Interfaces;

namespace Strategy.Duck.Model
{
    public class MallarDuck : Duck
    {
        public MallarDuck()
        {
            FlyBehavior = new FlyWithWings();
            QuackBehavior = new Quack();
        }

        public override string Display()
        {
            return "I'm a real Mallard duck";
        }
    } 
}
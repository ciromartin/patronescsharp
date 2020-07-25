using Strategy.Duck.Behavior.Interfaces;

namespace Strategy.Duck.Behavior.Implementation
{
    public class Quack : IQuackBehavior
    {
        string IQuackBehavior.Quack()
        {
            return "Quack";
        }
    }
}
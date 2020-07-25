using Strategy.Duck.Behavior.Interfaces;

namespace Strategy.Duck.Model
{
    public abstract class Duck
    {
        public IFlyBehavior FlyBehavior { get; set; }
        public IQuackBehavior QuackBehavior { get; set; }

        public abstract string Display();

        public string PerformFly()
        {
            return FlyBehavior.Fly();
        }

        public string PerformQuack()
        {
            return QuackBehavior.Quack();
        }

        public string Swim()
		{
			return "All ducks float, even decoys!";
		}
    }
}
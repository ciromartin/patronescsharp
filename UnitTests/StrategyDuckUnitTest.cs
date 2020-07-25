using System;
using Strategy.Duck.Model;
using Xunit;
using FluentAssertions;
using Strategy.Duck.Behavior.Implementation;

namespace UnitTests
{
    public class StrategyDuckUnitTest
    {
        [Fact]
        public void MallarDuck_ShuldQuackAndFlyAndDisplay()
        {
            //Arrange
            Duck mallar = new MallarDuck();

            //Act
            var fly = mallar.PerformFly();
            var quack = mallar.PerformQuack();
            var display = mallar.Display();

            //Assert
            fly.Should().Be("I'm flying!!");
            quack.Should().Be("Quack");
            display.Should().Be("I'm a real Mallard duck");
        }

        [Fact]
        public void RubberDuck_ShouldCantFlyAndSqueakAndDisplay()
        {
            //Arrange
            Duck rubber = new RubberDuck();

            //Act
            var fly = rubber.PerformFly();
            var quack = rubber.PerformQuack();
            var display = rubber.Display();

            //Assert
            fly.Should().Be("I can't fly.");
            quack.Should().Be("Squeak");
            display.Should().Be("I'm a Rubber duck");
        }
        [Fact]
        public void RubberDuck_ShouldFlyRocketPowered_WhenChangeFlyRocketPowered()
        {
            //Arrange
            Duck rubber = new RubberDuck();

            //Act
            rubber.FlyBehavior = new FlyRocketPowered();
            var fly = rubber.PerformFly();

            //Assert
            fly.Should().Be("I'm flying with a rocket!");
        }

    }
}

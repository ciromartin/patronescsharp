using Decorator.Starbuzz.Component;
using Decorator.Starbuzz.Decorator;
using Decorator.Starbuzz.Enum;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class DecoratorStarbuzzUnitTest
    {
        [Fact]
        public void Expresso_ShouldBeExpressoAndCostOneDollarAndFiftyCents_WhenIsInstantiate()
        {
            //Arrange
            Beverage beverage = new Expresso();

            //Act
            var description = beverage.GetDescription();
            var cost = beverage.Cost();

            //Assert
            description.Should().Be("Expresso");
            cost.Should().Be(1.5);
            beverage.Size.Should().Be(BeverageSize.TALL);
        }

        [Fact]
        public void DarkRoast_ShouldBeExpressoAndCostNinetyNineCents_WhenIsInstantiate()
        {
            //Arrange
            Beverage beverage = new DarkRoast();

            //Act
            var description = beverage.GetDescription();
            var cost = beverage.Cost();

            //Assert
            description.Should().Be("Dark Roast Coffee");
            cost.Should().Be(.99);
        }

        [Fact]
        public void Decaf_ShouldBeExpressoAndCostOneDollarAndFiveCents_WhenIsInstantiate()
        {
            //Arrange
            Beverage beverage = new Decaf();

            //Act
            var description = beverage.GetDescription();
            var cost = beverage.Cost();

            //Assert
            description.Should().Be("Decaf Coffee");
            cost.Should().Be(1.05);
        }

        [Fact]
        public void HouseBlend_ShouldBeExpressoAndCostEightyNineCents_WhenIsInstantiate()
        {
            //Arrange
            Beverage beverage = new HouseBlend();

            //Act
            var description = beverage.GetDescription();
            var cost = beverage.Cost();

            //Assert
            description.Should().Be("House Blend Coffee");
            cost.Should().Be(.89);
        }

        [Fact]
        public void ExpressoTall_ShouldBeExpressoAndCostOneDollarAndFiftyCents_WhenIsInstantiate()
        {
            //Arrange
            BeverageSize beverageSize = BeverageSize.TALL;
            Beverage beverage = new Expresso();
            beverage.Size = beverageSize;

            //Act
            var description = beverage.GetDescription();
            var cost = beverage.Cost();

            //Assert
            description.Should().Be("Expresso");
            cost.Should().Be(1.5);
            beverage.Size.Should().Be(beverageSize);
        }

        [Fact]
        public void ExpressoGrande_ShouldBeExpressoAndCostOneDollarAndSeventyFiveCents_WhenIsInstantiate()
        {
            //Arrange
            BeverageSize beverageSize = BeverageSize.GRANDE;
            Beverage beverage = new Expresso();
            beverage.Size = beverageSize;

            //Act
            var description = beverage.GetDescription();
            var cost = beverage.Cost();

            //Assert
            description.Should().Be("Expresso");
            cost.Should().Be(1.75);
            beverage.Size.Should().Be(beverageSize);
        }


        [Fact]
        public void ExpressoVenti_ShouldBeExpressoAndCostThreeDollars_WhenIsInstantiate()
        {
            //Arrange
            BeverageSize beverageSize = BeverageSize.VENTI;
            Beverage beverage = new Expresso();
            beverage.Size = beverageSize;

            //Act
            var description = beverage.GetDescription();
            var cost = beverage.Cost();

            //Assert
            description.Should().Be("Expresso");
            cost.Should().Be(3);
            beverage.Size.Should().Be(beverageSize);
        }


        [Fact]
        public void Expresso_ShouldBeExpressoAndCostThreeDollarsAndTwentyCents_WhenMochaDecorateVenti()
        {
            //Arrange
            BeverageSize beverageSize = BeverageSize.VENTI;
            Beverage beverage = new Expresso();
            beverage.Size = beverageSize;
            beverage = new Mocha(beverage);
            beverage.Size = beverageSize;

            //Act
            var description = beverage.GetDescription();
            var cost = beverage.Cost();

            //Assert
            description.Should().Be("Expresso, Mocha");
            cost.Should().Be(3.2);
        }

        [Fact]
        public void Expresso_ShouldBeExpressoAndCostThreeDollarsAndTwentyCents_WhithMochaAndVenti()
        {
            //Arrange
            BeverageSize beverageSize = BeverageSize.VENTI;
            Beverage beverage = new Expresso();
            beverage.Size = beverageSize;
            beverage = new Mocha(beverage);
            beverage.Size = beverageSize;

            //Act
            var description = beverage.GetDescription();
            var cost = beverage.Cost();

            //Assert
            description.Should().Be("Expresso, Mocha");
            cost.Should().Be(3.2);
        }

        [Fact]
        public void Expresso_ShouldBeExpressoAndCostThreeDollarsAndFortyCents_WhithMochaWhipAndVenti()
        {
            //Arrange
            BeverageSize beverageSize = BeverageSize.VENTI;
            Beverage beverage = new Expresso();
            beverage.Size = beverageSize;
            beverage = new Mocha(beverage);
            beverage.Size = beverageSize;
            beverage = new Whip(beverage);

            //Act
            var description = beverage.GetDescription();
            var cost = beverage.Cost();

            //Assert
            description.Should().Be("Expresso, Mocha, Whip");
            Math.Round(cost, 2).Should().Be(3.4);
        }
    }
}

using FluentAssertions;
using HelloWorld.Api.Randomizer;
using NSubstitute;
using NUnit.Framework;
using System;

namespace HelloWorld.Api.Tests.Randomizer
{
    [TestFixture]
    public class RandomOutcomeGeneratorTests
    {
        [Test]
        public void GetHelloWorldString_Given52_ShouldThrowException()
        {
            // Arrange
            var expectedException = new Exception("Haha! You got joker'ed!");

            var random = Substitute.For<IRandomWrapper>();
            random.Next(Arg.Any<int>()).Returns(52);

            var generator = new RandomOutcomeGenerator(random);

            // Act & Assert
            var actualException = Assert.Throws<Exception>(() => generator.GetHelloWorldString());

            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

        [Test]
        public void GetHelloWorldString_Given53_ShouldThrowException()
        {
            // Arrange
            var expectedException = new Exception("Haha! You got joker'ed!");

            var random = Substitute.For<IRandomWrapper>();
            random.Next(Arg.Any<int>()).Returns(53);

            var generator = new RandomOutcomeGenerator(random);

            // Act & Assert
            var actualException = Assert.Throws<Exception>(() => generator.GetHelloWorldString());

            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

        [TestCase(0, "Spades")]
        [TestCase(12, "Spades")]
        [TestCase(13, "Diamonds")]
        [TestCase(25, "Diamonds")]
        [TestCase(26, "Clubs")]
        [TestCase(38, "Clubs")]
        [TestCase(39, "Hearts")]
        [TestCase(51, "Hearts")]
        public void GetHelloWorldString_GivenCardNumAndSuit_ShouldReturnCardNumOfGivenSuit(int returnedCardNum, string suit)
        {
            // Arrange
            var expectedString = $"Hello World. Your card number was {returnedCardNum % 13} of {suit}";

            var random = Substitute.For<IRandomWrapper>();
            random.Next(Arg.Any<int>()).Returns(returnedCardNum);

            var generator = new RandomOutcomeGenerator(random);

            // Act
            var actualString = generator.GetHelloWorldString();

            // Assert
            Assert.AreEqual(expectedString, actualString);
        }
    }
}

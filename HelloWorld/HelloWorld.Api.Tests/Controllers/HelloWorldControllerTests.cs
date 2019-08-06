using HelloWorld.Api.Controllers;
using HelloWorld.Api.Randomizer;
using NSubstitute;
using NUnit.Framework;
using System;

namespace HelloWorld.Api.Tests.Controllers
{
    [TestFixture]
    public class HelloWorldControllerTests
    {

        [Test]
        public void Constuctor_GivenValidGenerator_ShouldNotThrowException()
        {

            // Arrange
            var generator = Substitute.For<IRandomOutcomeGenerator>();

            // Act & Assert
            Assert.DoesNotThrow(() => new HelloWorldController(generator));

        }

        [Test]
        public void Constuctor_GivenNullGenerator_ShouldThrowArgumentNullException()
        {

            // Arrange
            var expectedParamName = "generator";

            // Act
            var actualException = Assert.Throws<ArgumentNullException>(() => new HelloWorldController(null));

            // Assert

            Assert.AreEqual(expectedParamName, actualException.ParamName);

        }
    }
}

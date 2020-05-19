using System;
using FluentAssertions;
using Xunit;

namespace Chain.Of.Responsibility.Example.Tests
{
    public class BasicUserRegistrationTests
    {
        [Fact]
        public void When_Username_Is_Empty_Then_Exception_Should_Be_Thrown()
        {
            //Arrange
            var user = new User();

            //Act
            Action act = () => new BasicUserRegistrationProcessor().Register(user);

            //Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void When_Password_Is_Empty_Then_Exception_Should_Be_Thrown()
        {
            //Arrange
            var user = new User
            {
                Username = "Daniel Rusnok"
            };
            //Act
            Action act = () => new BasicUserRegistrationProcessor().Register(user);

            //Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void When_BirthDate_Is_Not_Earlier_Than_18_Years_Ago_Then_Exception_Should_Be_Thrown()
        {
            //Arrange
            var user = new User
            {
                Username = "Daniel Rusnok",
                Password = Guid.NewGuid().ToString(),
                BirthDate = DateTime.Now
            };

            //Act
            Action act = () => new BasicUserRegistrationProcessor().Register(user);

            //Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void When_All_Properties_Are_valid_Then_Exception_Should_NOT_Be_Thrown()
        {
            //Arrange
            var user = new User
            {
                Username = "Daniel Rusnok",
                Password = Guid.NewGuid().ToString(),
                BirthDate = DateTime.Now.AddYears(-20)
            };

            //Act
            Action act = () => new BasicUserRegistrationProcessor().Register(user);

            //Assert
            act.Should().NotThrow<Exception>();
        }
    }
}
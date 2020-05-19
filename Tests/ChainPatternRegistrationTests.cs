using System;
using Chain.Of.Responsibility.Example.Chain.Pattern;
using FluentAssertions;
using Xunit;

namespace Chain.Of.Responsibility.Example.Tests
{
    public class ChainPatternRegistrationTests
    {
        [Fact]
        public void When_Username_Is_Empty_Then_Exception_Should_Be_Thrown()
        {
            //Arrange
            var user = new User{Username = string.Empty};

            //Act
            Action act = () => new UsernameRequiredValidationHandler().Handle(user);

            //Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void When_Username_Is_Filled_Then_Exception_Should_NOT_Be_Thrown()
        {
            //Arrange
            var user = new User{Username = "Daniel Rusnok"};

            //Act
            Action act = () => new UsernameRequiredValidationHandler().Handle(user);

            //Assert
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void When_Password_Is_Empty_Then_Exception_Should_Be_Thrown()
        {
            //Arrange
            var user = new User{Password = string.Empty};

            //Act
            Action act = () => new PasswordRequiredValidationHandler().Handle(user);

            //Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void When_Password_Is_Filled_Then_Exception_Should_NOT_Be_Thrown()
        {
            //Arrange
            var user = new User{Password = Guid.NewGuid().ToString()};

            //Act
            Action act = () => new PasswordRequiredValidationHandler().Handle(user);

            //Assert
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void When_BirthDate_Is_NOT_Earlier_Than_18_Years_Ago_Then_Exception_Should_Be_Thrown()
        {
            //Arrange
            var user = new User { BirthDate = DateTime.Now };

            //Act
            Action act = () => new OnlyAdultValidationHandler().Handle(user);

            //Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void When_BirthDate_Is_Earlier_Than_18_Years_Ago_Then_Exception_Should_Be_Thrown()
        {
            //Arrange
            var user = new User { BirthDate = DateTime.Now.AddYears(-20) };

            //Act
            Action act = () => new OnlyAdultValidationHandler().Handle(user);

            //Assert
            act.Should().NotThrow<Exception>();
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
            Action act = () => new ChainPatternRegistrationProcessor().Register(user);

            //Assert
            act.Should().NotThrow<Exception>();
        }
    }
}
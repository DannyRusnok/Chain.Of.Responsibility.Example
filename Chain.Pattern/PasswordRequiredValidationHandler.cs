using System;
using System.ComponentModel.DataAnnotations;

namespace Chain.Of.Responsibility.Example.Chain.Pattern
{
    public class PasswordRequiredValidationHandler : Handler<User>, IHandler<User>
    {
        public override void Handle(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new Exception("Password is required.");
            }

            base.Handle(user);
        }
    }
}
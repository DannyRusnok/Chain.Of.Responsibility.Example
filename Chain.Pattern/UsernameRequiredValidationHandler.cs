using System;

namespace Chain.Of.Responsibility.Example.Chain.Pattern
{
    public class UsernameRequiredValidationHandler : Handler<User>, IHandler<User>
    {
        public override void Handle(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new Exception("Username is required.");
            }

            base.Handle(user);
        }
    }
}
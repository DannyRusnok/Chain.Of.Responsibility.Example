using System;
using System.ComponentModel.DataAnnotations;

namespace Chain.Of.Responsibility.Example.Chain.Pattern
{
    public class OnlyAdultValidationHandler : Handler<User>, IHandler<User>
    {
        public override void Handle(User user)
        {
            if (user.BirthDate.Year > DateTime.Now.Year - 18)
            {
                throw new Exception("Age under 18 is not allowed.");
            }

            base.Handle(user);
        }
    }
}
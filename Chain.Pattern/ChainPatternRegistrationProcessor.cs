using System.ComponentModel.DataAnnotations;

namespace Chain.Of.Responsibility.Example.Chain.Pattern
{
    public class ChainPatternRegistrationProcessor
    {
        public void Register(User user)
        {
            var handler = new UsernameRequiredValidationHandler();
            handler.SetNext(new PasswordRequiredValidationHandler())
                .SetNext(new OnlyAdultValidationHandler());

            handler.Handle(user);
        }
    }
}
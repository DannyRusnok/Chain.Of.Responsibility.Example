using System;
using System.ComponentModel.DataAnnotations;

namespace Chain.Of.Responsibility.Example
{
    public class BasicUserRegistrationProcessor
    {
        public void Register(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new Exception("Username is required.");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new Exception("Password is required.");
            }

            if (user.BirthDate.Year > DateTime.Now.Year - 18)
            {
                throw new Exception("Password is required.");
            }
        }
    }
}
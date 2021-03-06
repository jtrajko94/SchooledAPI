using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class AdminUserService
    {
        public static APIValidatorResponse IsValid(AdminUserData user)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if (!Validator.Item(ValidatorType.Email, user.Email))
            {
                isValid = false;
                errors.Add("Email is required.");
            }

            if (!Validator.IsValidPassword(user.Password))
            {
                isValid = false;
                errors.Add("Password of lengths 5-25 is required.");
            }

            if (!Validator.Item(ValidatorType.FirstAndLastName, user.FirstName + " " + user.LastName))
            {
                isValid = false;
                errors.Add("First and Last Name are required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
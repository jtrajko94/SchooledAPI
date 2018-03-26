using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class UserService
    {
        public static APIValidatorResponse IsValid(UserData user)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if (user.UserRowKey != null && !Validator.IsValidGuid(user.UserRowKey))
            {
                isValid = false;
                errors.Add("User ID is invalid. Can enter null if inserting.");
            }

            if (!Validator.IsValidGuid(user.UserTypeRowKey))
            {
                isValid = false;
                errors.Add("User Type ID is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, user.SchoolRowKey.ToString()))
            {
                isValid = false;
                errors.Add("School ID is required.");
            }

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

            if (!Validator.IsBoundedInteger(user.GameDifficulty, 1, 10))
            {
                isValid = false;
                errors.Add("Game Difficulty between 1-10 is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
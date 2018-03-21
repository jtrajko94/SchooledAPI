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
            if (!Validator.Item(ValidatorType.Integer, user.UserTypeId.ToString()))
            {
                isValid = false;
                errors.Add("User Type ID is required.");
            }

            if (!Validator.Item(ValidatorType.Integer, user.SchoolId.ToString()))
            {
                isValid = false;
                errors.Add("School ID is required.");
            }

            if (!Validator.Item(ValidatorType.Email, user.Email))
            {
                isValid = false;
                errors.Add("Email is required.");
            }

            if (!Validator.Item(ValidatorType.Password, user.Password))
            {
                isValid = false;
                errors.Add("Password is required.");
            }

            if (!Validator.Item(ValidatorType.FirstAndLastName, user.FirstName + " " + user.LastName))
            {
                isValid = false;
                errors.Add("First and Last Name are required.");
            }

            if (!Validator.Item(ValidatorType.Integer, user.GameDifficulty.ToString()))
            {
                isValid = false;
                errors.Add("Game Difficulty is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
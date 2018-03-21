using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class UserTypeService
    {
        public static APIValidatorResponse IsValid(UserTypeData userType)
        {
            List<string> errors = new List<string>();
            bool isValid = true;
            if (!Validator.Item(ValidatorType.AnyValue, userType.Name))
            {
                isValid = false;
                errors.Add("User Type Name is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
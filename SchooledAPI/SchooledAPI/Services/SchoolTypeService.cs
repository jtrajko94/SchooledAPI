using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class SchoolTypeService
    {
        public static APIValidatorResponse IsValid(SchoolTypeData schoolType)
        {
            List<string> errors = new List<string>();
            bool isValid = true;
            if (!Validator.Item(ValidatorType.AnyValue, schoolType.Name))
            {
                isValid = false;
                errors.Add("School Type Name is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
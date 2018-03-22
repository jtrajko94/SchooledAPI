using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class SchoolService
    {
        public static APIValidatorResponse IsValid(SchoolData school)
        {
            List<string> errors = new List<string>();
            bool isValid = true;
            if (!Validator.Item(ValidatorType.AnyValue, school.SchoolTypeRowKey))
            {
                isValid = false;
                errors.Add("School Type ID is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, school.Name))
            {
                isValid = false;
                errors.Add("Name is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, school.Street))
            {
                isValid = false;
                errors.Add("Street Address is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, school.City))
            {
                isValid = false;
                errors.Add("City is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, school.State))
            {
                isValid = false;
                errors.Add("State is required.");
            }

            if (!Validator.Item(ValidatorType.ZipUS, school.Zipcode) && !Validator.Item(ValidatorType.ZipCanada, school.Zipcode))
            {
                isValid = false;
                errors.Add("Zipcode is invalid.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, school.Country))
            {
                isValid = false;
                errors.Add("Country is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, school.District))
            {
                isValid = false;
                errors.Add("District is required.");
            }

            if (!Validator.Item(ValidatorType.Integer, school.StudentCount.ToString()))
            {
                isValid = false;
                errors.Add("Student Count is required/invalid.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
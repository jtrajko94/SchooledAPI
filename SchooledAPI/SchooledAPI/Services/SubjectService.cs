using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class SubjectService
    {
        public static APIValidatorResponse IsValid(SubjectData subject)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if (subject.SubjectRowKey != null && !Validator.IsValidGuid(subject.SubjectRowKey))
            {
                isValid = false;
                errors.Add("Subject ID is invalid. Can enter null if inserting.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, subject.Name))
            {
                isValid = false;
                errors.Add("Name is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, subject.Image))
            {
                isValid = false;
                errors.Add("Image is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
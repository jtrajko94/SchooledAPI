using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class CourseService
    {
        public static APIValidatorResponse IsValid(CourseData course)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if (course.CourseRowKey != null && !Validator.IsValidGuid(course.CourseRowKey))
            {
                isValid = false;
                errors.Add("Course ID is invalid. Can enter null if inserting.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, course.SubjectRowKey))
            {
                isValid = false;
                errors.Add("Subject Id is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, course.Name))
            {
                isValid = false;
                errors.Add("Name is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, course.Image))
            {
                isValid = false;
                errors.Add("Image is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
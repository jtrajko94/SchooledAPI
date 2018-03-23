using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class SchoolScoreService
    {
        public static APIValidatorResponse IsValid(SchoolScoreData schoolScore)
        {
            List<string> errors = new List<string>();
            bool isValid = true;
            if (!Validator.Item(ValidatorType.AnyValue, schoolScore.CompetitionRowKey))
            {
                isValid = false;
                errors.Add("Competition ID is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, schoolScore.SchoolRowKey))
            {
                isValid = false;
                errors.Add("School ID is required.");
            }

            if (!Validator.Item(ValidatorType.Integer, schoolScore.Points.ToString()))
            {
                isValid = false;
                errors.Add("Point Count is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
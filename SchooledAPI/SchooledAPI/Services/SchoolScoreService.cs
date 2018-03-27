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

            if (schoolScore.SchoolScoreRowKey != null && !Validator.IsValidGuid(schoolScore.SchoolScoreRowKey))
            {
                isValid = false;
                errors.Add("School Score ID is invalid. Can enter null if inserting.");
            }

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

            if (!Validator.IsBoundedInteger(schoolScore.Points, 0, int.MaxValue))
            {
                isValid = false;
                errors.Add("Point Count is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class GameCompletionService
    {
        public static APIValidatorResponse IsValid(GameCompletionData gameCompletion)
        {
            List<string> errors = new List<string>();
            bool isValid = true;
            if (!Validator.Item(ValidatorType.AnyValue, gameCompletion.CompetitionRowKey))
            {
                isValid = false;
                errors.Add("Competition Id is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, gameCompletion.CourseRowKey))
            {
                isValid = false;
                errors.Add("Course Id is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, gameCompletion.GameRowKey))
            {
                isValid = false;
                errors.Add("Game Id is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, gameCompletion.UserRowKey))
            {
                isValid = false;
                errors.Add("User Id is required.");
            }

            if (!Validator.Item(ValidatorType.Integer, gameCompletion.Difficulty.ToString()))
            {
                isValid = false;
                errors.Add("Difficulty is required.");
            }

            if (!Validator.Item(ValidatorType.Integer, gameCompletion.RaffelTickets.ToString()))
            {
                isValid = false;
                errors.Add("Raffel Ticket Count is required.");
            }

            if (!Validator.Item(ValidatorType.Integer, gameCompletion.Points.ToString()))
            {
                isValid = false;
                errors.Add("Points Count is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
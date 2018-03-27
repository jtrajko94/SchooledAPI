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

            if (gameCompletion.GameCompletionRowKey != null && !Validator.IsValidGuid(gameCompletion.GameCompletionRowKey))
            {
                isValid = false;
                errors.Add("Game Completion ID is invalid. Can enter null if inserting.");
            }

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

            if (!Validator.IsBoundedInteger(gameCompletion.Difficulty, 1, 10))
            {
                isValid = false;
                errors.Add("Difficulty is required. (1-10)");
            }

            if (!Validator.IsBoundedInteger(gameCompletion.RaffelTickets, 0, int.MaxValue))
            {
                isValid = false;
                errors.Add("Raffel Ticket Count is required. (0-infinity");
            }

            if (!Validator.IsBoundedInteger(gameCompletion.Points, 0, int.MaxValue))
            {
                isValid = false;
                errors.Add("Points Count is required.(0-infinity)");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class ResponseService
    {
        public static APIValidatorResponse IsValid(ResponseData response)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if (response.ResponseRowKey != null && !Validator.IsValidGuid(response.ResponseRowKey))
            {
                isValid = false;
                errors.Add("Response ID is invalid. Can enter null if inserting.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, response.GameCompletionRowKey))
            {
                isValid = false;
                errors.Add("Game Completion ID is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, response.UserRowKey))
            {
                isValid = false;
                errors.Add("User ID is required.");
            }

            if (!Validator.Item(ValidatorType.Email, response.QuestionRowKey))
            {
                isValid = false;
                errors.Add("Question ID is required.");
            }

            if(!Validator.IsBoundedInteger(response.ChosenAnswer, 1, 4))
            {
                isValid = false;
                errors.Add("Chosen answer is required.");
            }

            if(response.IsCorrect == null)
            {
                isValid = false;
                errors.Add("IsCorrect is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
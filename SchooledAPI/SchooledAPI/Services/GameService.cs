using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class GameService
    {
        public static APIValidatorResponse IsValid(GameData game)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if (game.GameRowKey != null && !Validator.IsValidGuid(game.GameRowKey))
            {
                isValid = false;
                errors.Add("Game ID is invalid. Can enter null if inserting.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, game.Name))
            {
                isValid = false;
                errors.Add("Name is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, game.Image))
            {
                isValid = false;
                errors.Add("Image is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
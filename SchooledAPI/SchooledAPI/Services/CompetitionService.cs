using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class CompetitionService
    {
        public static APIValidatorResponse IsValid(CompetitionData competition)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if (competition.isIndividual)
            {
                if (!Validator.Item(ValidatorType.AnyValue, competition.UserTypeRowKey))
                {
                    isValid = false;
                    errors.Add("User Type Id is required.");
                }
            }
            else
            {
                if (!Validator.Item(ValidatorType.AnyValue, competition.SchoolTypeRowKey))
                {
                    isValid = false;
                    errors.Add("School Type Id is required.");
                }
            }

            if (competition.BeginDate == null || competition.EndDate == null)
            {
                isValid = false;
                errors.Add("Begin/End Date are required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, competition.PrizeOneName) ||
                    !Validator.Item(ValidatorType.AnyValue, competition.PrizeOneImage) ||
                    !Validator.Item(ValidatorType.AnyValue, competition.PrizeOneCost))
            {
                isValid = false;
                errors.Add("Prize One is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, competition.PrizeTwoName) ||
                    !Validator.Item(ValidatorType.AnyValue, competition.PrizeTwoImage) ||
                    !Validator.Item(ValidatorType.AnyValue, competition.PrizeTwoCost))
            {
                isValid = false;
                errors.Add("Prize Two is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, competition.PrizeThreeName) ||
                    !Validator.Item(ValidatorType.AnyValue, competition.PrizeThreeImage) ||
                    !Validator.Item(ValidatorType.AnyValue, competition.PrizeThreeCost))
            {
                isValid = false;
                errors.Add("Prize Three is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, competition.State))
            {
                isValid = false;
                errors.Add("State is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, competition.Country))
            {
                isValid = false;
                errors.Add("Country is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, competition.Name))
            {
                isValid = false;
                errors.Add("Name is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, competition.Description))
            {
                isValid = false;
                errors.Add("Description is required.");
            }


            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
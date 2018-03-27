using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class RaffelEntryService
    {
        public static APIValidatorResponse IsValid(RaffelEntryData raffelEntry)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if (raffelEntry.RaffelEntryRowKey != null && !Validator.IsValidGuid(raffelEntry.RaffelEntryRowKey))
            {
                isValid = false;
                errors.Add("Question ID is invalid. Can enter null if inserting.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, raffelEntry.CompetitionRowKey))
            {
                isValid = false;
                errors.Add("Competition ID is required.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, raffelEntry.UserRowKey))
            {
                isValid = false;
                errors.Add("User ID is required.");
            }

            if (!Validator.IsBoundedInteger(raffelEntry.TicketCount, 0, int.MaxValue))
            {
                isValid = false;
                errors.Add("Ticket Count is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
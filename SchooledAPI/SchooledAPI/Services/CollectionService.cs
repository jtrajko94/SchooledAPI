using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class CollectionService
    {
        public static APIValidatorResponse IsValid(CollectionData collection)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if (collection.CollectionRowKey != null && !Validator.IsValidGuid(collection.CollectionRowKey))
            {
                isValid = false;
                errors.Add("Collection ID is invalid. Can enter null if inserting.");
            }

            if (!Validator.Item(ValidatorType.AnyValue, collection.Name))
            {
                isValid = false;
                errors.Add("Name is required.");
            }

            if (collection.IsTextbook == null)
            {
                isValid = false;
                errors.Add("IsTextbook is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}
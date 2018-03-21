using System.Collections.Generic;

namespace SchooledAPI.Data
{
    public class APIValidatorResponse
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchooledAPI.Data
{
    public class APIValidatorResponse
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }
    }
}
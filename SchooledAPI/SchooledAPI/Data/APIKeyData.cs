using System;

namespace SchooledAPI.Data
{
    public class APIKeyData
    {
        public Guid APIKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
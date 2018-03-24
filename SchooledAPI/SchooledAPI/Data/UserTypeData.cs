using System;

namespace SchooledAPI.Data
{
    public class UserTypeData
    {
        public Guid UserTypeRowKey { get; set; }
        public string Name { get; set; }
        public int DefaultDifficulty { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
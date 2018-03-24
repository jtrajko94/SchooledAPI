using System;

namespace SchooledAPI.Data
{
    public class SubjectData
    {
        public Guid SubjectRowKey { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
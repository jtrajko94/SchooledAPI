using System;

namespace SchooledAPI.Data
{
    public class CourseData
    {
        public string CourseRowKey { get; set; }
        public string SubjectRowKey { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
using System;

namespace SchooledAPI.Data
{
    public class CourseData
    {
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
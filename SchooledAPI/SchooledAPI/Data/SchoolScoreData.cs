using System;

namespace SchooledAPI.Data
{
    public class SchoolScoreData
    {
        public string SchoolScoreRowKey { get; set; }
        public string CompetitionRowKey { get; set; }
        public string SchoolRowKey { get; set; }
        public int? Points { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
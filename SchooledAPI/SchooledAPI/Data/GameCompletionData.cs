using System;

namespace SchooledAPI.Data
{
    public class GameCompletionData
    {
        public string GameCompletionRowKey { get; set; }
        public string CourseRowKey { get; set; }
        public string GameRowKey { get; set; }
        public string CompetitionRowKey { get; set; }
        public string UserRowKey { get; set; }
        public int Points { get; set; }
        public int Difficulty { get; set; }
        public int RaffelTickets { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
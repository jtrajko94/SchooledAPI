using System;

namespace SchooledAPI.Data
{
    public class RaffelEntryData
    {
        public string RaffelEntryRowKey { get; set; }
        public string UserRowKey { get; set; }
        public string CompetitionRowKey { get; set; }
        public int TicketCount { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
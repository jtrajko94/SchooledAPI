using System;

namespace SchooledAPI.Data
{
    public class ResponseData
    {
        public string ResponseRowKey { get; set; }
        public string GameCompletionRowKey { get; set; }
        public string UserRowKey { get; set; }
        public string QuestionRowKey { get; set; }
        public int ChosenAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
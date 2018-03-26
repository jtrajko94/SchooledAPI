using System;

namespace SchooledAPI.Data
{
    public class QuestionData
    {
        public string QuestionRowKey { get; set; }
        public string CourseRowKey { get; set; }
        public string CollectionRowKey { get; set; }
        public int TotalAnswers { get; set; }
        public string Question { get; set; }
        public string AnswerOne { get; set; }
        public string AnswerTwo { get; set; }
        public string AnswerThree { get; set; }
        public string AnswerFour { get; set; }
        public int? Difficulty { get; set; }
        public int? CorrectAnswer {get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
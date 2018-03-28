using System;

namespace SchooledAPI.Data
{
    public class CompetitionData
    {
        public string CompetitionRowKey { get; set; }
        public string SchoolTypeRowKey { get; set; }
        public string UserTypeRowKey { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PrizeOneName { get; set; }
        public string PrizeOneCost { get; set; }
        public string PrizeOneImage { get; set; }
        public string PrizeTwoName { get; set; }
        public string PrizeTwoCost { get; set; }
        public string PrizeTwoImage { get; set; }
        public string PrizeThreeName { get; set; }
        public string PrizeThreeCost { get; set; }
        public string PrizeThreeImage { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsIndividual { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
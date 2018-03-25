using System;

namespace SchooledAPI.Data
{
    public class SchoolData
    {
        public string SchoolRowKey { get; set; }
        public string SchoolTypeRowKey { get; set; }
        public string Name { get; set; }
        public int? StudentCount { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
using System;

namespace SchooledAPI.Data
{
    public class UserData
    {
        public Guid UserRowKey { get; set; }
        public Guid UserTypeRowKey { get; set; }
        public Guid SchoolRowKey { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsFacebook { get; set; }
        public int GameDifficulty { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
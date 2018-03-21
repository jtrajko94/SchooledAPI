using System;

namespace SchooledAPI.Data
{
    public class UserData
    {
        public string UserRowKey { get; set; }
        public string UserTypeId { get; set; }
        public string SchoolId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFacebook { get; set; }
        public int GameDifficulty { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
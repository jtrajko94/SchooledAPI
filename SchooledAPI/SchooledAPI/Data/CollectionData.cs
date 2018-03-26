using System;

namespace SchooledAPI.Data
{
    public class CollectionData
    {
        public string CollectionRowKey { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool? IsTextbook { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
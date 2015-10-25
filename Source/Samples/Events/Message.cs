using System;

namespace Events
{
    public class Message
    {
        public Message()
        {
            Id = Guid.NewGuid().ToString();
            UserName = "[Unknown]";
            Category = "[Unknown]";
            Tenant = "[Unknown]";
            PostedDate = DateTime.UtcNow;
        }

        public string Id { get; set; }
        public bool NeedsAttention { get; set; }

        public DateTime PostedDate { get; set; }
        
        public string UserName { get; set; }

        public int ResponseInMinutes { get; set; }

        public string Category { get; set; }

        public string Tenant { get; set; }
       
    }
}

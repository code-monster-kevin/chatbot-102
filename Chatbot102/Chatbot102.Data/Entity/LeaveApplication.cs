using System;

namespace Chatbot102.Data.Entity
{
    public class LeaveApplication
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LeaveType { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTo { get; set; }
        public int Rating { get; set; }
    }
}

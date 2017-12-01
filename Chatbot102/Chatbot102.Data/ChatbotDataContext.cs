using Chatbot102.Data.Entity;
using System.Data.Entity;

namespace Chatbot102.Data
{
    public class ChatbotDataContext : DbContext
    {
        public ChatbotDataContext() : base("ChatbotDatabase")
        {

        }

        public DbSet<LeaveApplication> LeaveApplications { get; set; }
    }
}

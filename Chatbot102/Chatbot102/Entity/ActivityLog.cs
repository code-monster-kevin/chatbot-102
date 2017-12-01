namespace Chatbot102.Entity
{
    public class ActivityLog
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string TopicName { get; set; }
        public string TextFormat { get; set; }
        public string Action { get; set; }
        public string ReplyToId { get; set; }
        public string ServiceUrl { get; set; }
        public string ChannelId { get; set; }
        public string Locale { get; set; }
        public string FromChannelAccountId { get; set; }
        public string FromChannelAccountName { get; set; }
        public string RecipientChannelAccountId { get; set; }
        public string RecipientChannelAccountName { get; set; }
        public string ConversationId { get; set; }
        public string ConversationName { get; set; }
        public bool? ConversationIsGroup { get; set; }
        public string Text { get; set; }
        public string Speak { get; set; }
        public string InputHint { get; set; }
        public string Summary { get; set; }
    }
}
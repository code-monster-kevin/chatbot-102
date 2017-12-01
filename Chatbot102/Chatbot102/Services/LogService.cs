using Chatbot102.Entity;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace Chatbot102.Services
{
    public static class LogService
    {
        public static ActivityLog GetActivityLog(Activity activity)
        {
            return new ActivityLog
            {
                Id = activity.Id,
                Type = activity.Type,
                Name = activity.Name,
                TopicName = activity.TopicName,
                TextFormat = activity.TextFormat,
                Action = activity.Action,
                ReplyToId = activity.ReplyToId,
                ServiceUrl = activity.ServiceUrl,
                ChannelId = activity.ChannelId,
                Locale = activity.Locale,
                FromChannelAccountId = activity.From.Id,
                FromChannelAccountName = activity.From.Name,
                RecipientChannelAccountId = activity.Recipient.Id,
                RecipientChannelAccountName = activity.Recipient.Name,
                ConversationId = activity.Conversation.Id,
                ConversationName = activity.Conversation.Name,
                ConversationIsGroup = activity.Conversation.IsGroup,
                Text = activity.Text,
                Speak = activity.Speak,
                InputHint = activity.InputHint,
                Summary = activity.Summary
            };
        }

        public static string FormatActivityLog(ActivityLog activity_log)
        {
            return JsonConvert.SerializeObject(activity_log);
        }

        public static string FormatActivity(Activity activity)
        {
            return FormatActivityLog(GetActivityLog(activity));
        }
    }
}
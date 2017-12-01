using Chatbot102.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace Chatbot102.Dialogs
{
    [Serializable]
    public class SmallTalkDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (IntentDetectionService.CheckIntent(message.Text) == IntentDetectionService.IntentState.ROCKPAPERSCISSORS)
            {
                context.Call<object>(new RockPaperScissorsDialog(), ResumeAfterRockPaperScissorsDialog);
            }
            else
            {
                await context.PostAsync(SmallTalkResponse(message.Text));
                context.Wait(MessageReceivedAsync);
            }
        }

        private string SmallTalkResponse(string user_text)
        {
            string bot_reply = String.Empty;

            switch (IntentDetectionService.CheckIntent(user_text))
            {
                case IntentDetectionService.IntentState.ABOUT_ME:
                    bot_reply = SmallTalkService.RandomSmallTalk(SmallTalkService.About_Me_Sentences);
                    break;
                case IntentDetectionService.IntentState.BYE_BYE:
                    bot_reply = SmallTalkService.RandomSmallTalk(SmallTalkService.Bye_Sentences);
                    break;
                case IntentDetectionService.IntentState.HELLO:
                    bot_reply = SmallTalkService.RandomSmallTalk(SmallTalkService.Hello_Sentences);
                    break;
                case IntentDetectionService.IntentState.SMILE:
                    bot_reply = SmallTalkService.RandomSmallTalk(SmallTalkService.Smile_Textmojis_Sentences);
                    break;
                default:
                    bot_reply = SmallTalkService.RandomSmallTalk(SmallTalkService.No_Comprende_Sentences);
                    break;
            }

            return bot_reply;
        }

        public virtual async Task ResumeAfterRockPaperScissorsDialog(IDialogContext context, IAwaitable<object> result)
        {
            string reply = "To play again, just type Rock, Paper, Scissors or Game";
            await context.PostAsync(reply);
            context.Done(this);
        }
    }
}
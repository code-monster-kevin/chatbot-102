﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using NLog;
using Chatbot102.Services;
using Microsoft.Bot.Builder.FormFlow;
using Chatbot102.Forms;
using System;

namespace Chatbot102
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            logger.Log(LogLevel.Info, LogService.FormatActivity(activity));

            if (activity.Type == ActivityTypes.Message)
            {
                try
                {
                    await Conversation.SendAsync(activity, BuildLeaveFormDialog);
                }
                catch (FormCanceledException ex)
                {
                    HandleCanceledForm(activity, ex);
                }
                //await Conversation.SendAsync(activity, () => new Dialogs.SmallTalkDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }

        IDialog<LeaveForm> BuildLeaveFormDialog()
        {
            return FormDialog.FromForm(new LeaveForm().BuildForm);
        }

        void HandleCanceledForm(Activity activity, FormCanceledException ex)
        {
            string responseMessage = "You cancelled the form.";

            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            var response = activity.CreateReply(responseMessage);
            connector.Conversations.ReplyToActivity(response);
        }
    }
}
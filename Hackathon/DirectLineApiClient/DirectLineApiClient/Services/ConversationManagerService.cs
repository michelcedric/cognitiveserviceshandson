using DirectLineApiClient.Helpers;
using DirectLineApiClient.Models;
using Microsoft.Bot.Connector.DirectLine;

namespace DirectLineApiClient.Services
{
    public class ConversationManagerService
    {
        public DirectLineClient StartNewConversation()
        {
            var directLineClient = new DirectLineClient();
            var newConversation = directLineClient.Conversations.StartConversation();
            ConversationMemoryCache.Add(newConversation.ConversationId, directLineClient);
            return directLineClient;
        }

        public DirectLineClient GetClient(string conversationId)
        {
            var client = ConversationMemoryCache.Get(conversationId);
            if (client == null)
            {
                client = StartNewConversation();
            }
            return client;
        }

        public Answer GetMessage(Question question)
        {
            var client = GetClient(question.ConversationId);

            var directLineClient = new DirectLineClient();
            Activity userMessage = new Activity
            {
                From = new ChannelAccount("UserName"),
                Text = question.Text,
                Type = ActivityTypes.Message
            };

            directLineClient.Conversations.PostActivity(question.ConversationId, userMessage);

            var answer = new Answer
            {
                ConversationId = question.ConversationId,
                Text = ""
            };
            return answer;
        }
    }
}
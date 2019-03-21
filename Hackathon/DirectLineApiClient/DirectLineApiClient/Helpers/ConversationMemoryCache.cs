using Microsoft.Bot.Connector.DirectLine;
using System;
using System.Runtime.Caching;

namespace DirectLineApiClient.Helpers
{
    public static class ConversationMemoryCache
    {
        public static void Add(string conversationId, DirectLineClient client)
        {
            var memoryCache = MemoryCache.Default;
            memoryCache.Set(conversationId, client, DateTimeOffset.UtcNow.AddDays(1));
        }

        public static DirectLineClient Get(string conversationId)
        {
            var memoryCache = MemoryCache.Default;
            var result = memoryCache.Get(conversationId) as DirectLineClient;
            return result;
        }

        public static void Delete(string conversationId)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(conversationId))
            {
                memoryCache.Remove(conversationId);
            }
        }
    }
}
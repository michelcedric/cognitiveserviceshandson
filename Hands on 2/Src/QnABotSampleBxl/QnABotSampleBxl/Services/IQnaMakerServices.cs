using Microsoft.Bot.Builder.AI.QnA;

namespace QnABotSampleBxl.Services
{
    public interface IQnaMakerServices
    {
        QnAMaker QnAMaker { get; }
    }
}

using JB.Common.Entities;

namespace JB.Frontend.Services
{
    public interface IStockBotService
    {
        BotResponse BotDetection(string message);
    }
}
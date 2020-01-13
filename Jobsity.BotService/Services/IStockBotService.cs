using JB.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JB.StockBot.Services
{
   public interface IStockBotService
    {
        Stock GetStock(string stock_code);
    }
}

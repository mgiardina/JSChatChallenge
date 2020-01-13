using System;
using Microsoft.AspNetCore.Mvc;
using JB.Common.Models;
using JB.StockBot.Services;

namespace JB.BotService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockBotController : ControllerBase
    {
        private IStockBotService StockBotService;

        public StockBotController(IStockBotService stockInfoDomain)
        {
            StockBotService = stockInfoDomain;
        }

        /// <summary>
        /// Bot Controller
        /// </summary>
        /// <param name="stock_code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStock")]
        public ActionResult<Stock> GetStock(string stock_code)
        {
            try
            {
                var result = StockBotService.GetStock(stock_code);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

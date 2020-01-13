﻿using Newtonsoft.Json;
using JB.Common.Entities;
using JB.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JB.Frontend.Services
{
    public class StockBotService : IStockBotService
    {
        private HttpClient client { get; set; }

        public StockBotService(HttpClient _client)
        {
            client = _client;
        }

        /// <summary>
        /// Detects if the message contains the shortcut that allows the Bot to do his magic
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public BotResponse BotDetection(string message)
        {
            try
            {
                if (message.ToLower().Contains("/stock="))
                {
                    string code = message.Replace("/stock=", "");
                    using (HttpResponseMessage response = client.GetAsync($"https://localhost:44352/api/StockBot/GetStock?stock_code={code}").Result)
                    using (HttpContent content = response.Content)
                    {
                        string serviceResponse = content.ReadAsStringAsync().Result;
                        if (response.StatusCode != System.Net.HttpStatusCode.OK)
                            return new BotResponse { Detected = true, IsSuccessful = false, ErrorMessage = response.StatusCode.ToString()};

                        var stock = JsonConvert.DeserializeObject<Stock>(serviceResponse);
                        return new BotResponse { Detected = true, IsSuccessful = true, Symbol = stock.Symbol, Close = stock.Close.ToString() };
                    }
                }
                return new BotResponse { Detected = false };
            }
            catch (Exception ex)
            {
                return new BotResponse { Detected = true, IsSuccessful = false, ErrorMessage = ex.Message};
            }
        }
    }
}

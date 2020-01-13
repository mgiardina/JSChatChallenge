using JB.BotService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace JB.Tests
{
    public class StockBotUnitTest
    {
        /// <summary>
        /// Ok Response Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetStock_Ok()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            using (var client = server.CreateClient())
            {
                var code = "appl.us";
                var response = await client.GetAsync($"api/StockBot/GetStock?stock_code={code}");
                response.EnsureSuccessStatusCode();
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        /// <summary>
        /// Not Ok Response Test
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetStock_NotSuccess()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            using (var client = server.CreateClient())
            {
                var code = string.Empty;
                var response = await client.GetAsync($"api/StockBot/GetStock?stock_code={code}");
                var notSuccess = !response.IsSuccessStatusCode;
                Assert.True(notSuccess);
            }
        }
    }
}

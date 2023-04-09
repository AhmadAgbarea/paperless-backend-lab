using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Func.UnitTests
{
    [TestClass]
    public class ExchangeRateServiceTest
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ExchangeRateServiceTest(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        /// <summary>
        /// TestGetCurrencyExchangeRates
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGetCurrencyExchangeRates()
        {

            // Arrange
            var _exchangeRateService = new ExchangeRateService(_configuration);
            var year = 2021;
            var month = 11;

            // Act
            Dictionary<DateTime, decimal> result = await _exchangeRateService.GetExchangeRatesAsync(year, month, "USD", "ILS");

            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(daysInMonth, result.Count);
            Assert.IsTrue(result.Min(p => p.Value).ToString().Equals("3.0861"));
            Assert.IsTrue(result.Max(p => p.Value).ToString().Equals("3.1906"));
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Http;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Func
{
    public class Currency
    {
        private readonly ILogger<Currency> _logger;
        private readonly IConfiguration _configuration;
        private readonly ExchangeRateService _exchangeRateService;

        public Currency(IConfiguration configuration, ILogger<Currency> logger, ExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
            _configuration = configuration;
            _logger = logger;
        }

        [FunctionName("currency")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "currency/{monthYear}")] HttpRequest req, string monthYear, ILogger log)
        {
            //string date = req.Query["date"];
            string date = monthYear;

            if (!DateTime.TryParseExact(date, "yyMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                _logger.LogInformation("GetExchangeRatesAsync: BadRequest -> TryParseExact yymm. \nvalue not valid" + date);
                return new BadRequestErrorMessageResult("currency endpoint should receive Year and Month in this syntax (YYMM) e.g. baseurl/currency/2304 ");
            }
            int year = parsedDate.Year;
            int month = parsedDate.Month;

            // Call the GetExchangeRatesAsync to retrieve the exchange rates for the specified year and month from baseCurrency to symbolsCurrency.
            Dictionary<DateTime, decimal> GRAPH = await _exchangeRateService.GetExchangeRatesAsync(year, month, "USD", "ILS");

            // Calculate the minimum and maximum exchange rates from the retrieved data using LINQ.
            var min = GRAPH.ToArray().Min(rate => rate.Value);
            var max = GRAPH.ToArray().Max(rate => rate.Value);

            // Construct the output object to be returned by the API.
            var output = new { GRAPH, min, max };
            // Return the output as a JSON object with a 200 status code.
            return new OkObjectResult(output);
        }
    }
}

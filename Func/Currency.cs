using System.Globalization;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Func
{
    public class Currency
    {
        private readonly ILogger<Currency> _logger;
        private readonly IConfiguration _configuration;

        public Currency(IConfiguration configuration, ILogger<Currency> log)
        {
            _configuration = configuration;
            _logger = log;
        }

        [FunctionName("Currency")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
           [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "currency/{monthYear}")] HttpRequest req, string monthYear)
        {
            _logger.LogInformation("Currency function processed a request with param: " + monthYear);

            if (!DateTime.TryParseExact(monthYear, "yyMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                _logger.LogInformation("GetExchangeRatesAsync: BadRequest -> TryParseExact yymm");
                return new BadRequestErrorMessageResult("currency endpoint should receive Year and Month in this syntax (YYMM) e.g. baseurl/currency/2304 ");
            }
            return new OkObjectResult(parsedDate);
        }
    }
}


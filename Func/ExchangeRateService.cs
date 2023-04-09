using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Func
{
    public class ExchangeRateResponse
    {
        public DateTime Date { get; set; }
        public decimal Rate { get; set; }
    }

    public class ExchangeRateService
    {
        private readonly IConfiguration _configuration;
        private static readonly string BaseUrl = "https://v6.exchangerate-api.com";
        public ExchangeRateService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Dictionary<DateTime, decimal>> GetExchangeRatesAsync(int year, int month, string baseCurrency, string symbolsCurrency)
        {

            Dictionary<DateTime, decimal> list = new Dictionary<DateTime, decimal>();

            // TODO use Azure Key Vault to store and access secrets
            string apiKey = _configuration["ApiKeys:OpenExchangeRates"];

            int daysInMonth = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                // Construct the URL to query the currency exchange rate API
                var url = $"{BaseUrl}/v6/{apiKey}/history/{baseCurrency}/{year}/{month}/{day}";

                // Create a singleton instance of HttpClient to make the HTTP request
                HttpClient client = HttpClientSingleton.Instance;

                // Send the HTTP GET request to the API endpoint
                HttpResponseMessage response = await client.GetAsync(url);

                // Ensure that the response status code is successful
                response.EnsureSuccessStatusCode();

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Parse the response content as JSON
                using JsonDocument document = JsonDocument.Parse(responseContent);
                JsonElement root = document.RootElement;

                // Get the conversion rate for the specified currency
                decimal usdValue = root.GetProperty("conversion_rates").GetProperty(symbolsCurrency).GetDecimal();
                // Add the conversion rate to the list with the corresponding date
                list.Add(new DateTime(year, month, day), usdValue);
            }
            return list;
        }
    }
}   
# Exchange Rate API

This is a sample .NET Core Azure Function app 4 that retrieves historical currency exchange rates from an external API and returns them as a JSON object.

## Installation

To use this application, you'll need to have .NET Core installed on your machine.

## To run the application:
```
    Clone this repository to your local machine.
    Navigate to the project directory (/ExchangeRateApi).
    Run the following command to build the application: dotnet build.
    Run the following command to start the application: dotnet run.
```
Usage

- The application exposes a single GET endpoint at /currency/{year}{month} that retrieves the currency exchange rates for a given year and month.

- To use the endpoint, make a GET request to http://localhost:5000/currency/{year}{month} where {year} is a four-digit year and {month} is a two-digit month (e.g. /currency/202201 for January 2022).

- The endpoint returns a JSON object with the following properties:

    * graph: A dictionary of exchange rates for each day of the specified month.
    * minValue: The minimum exchange rate for the specified month.
    * maxValue: The maximum exchange rate for the specified month.

- Here's an example response:
```

```

# Configuration

The application reads its configuration values from the appsettings.json file in the project root directory. You can modify these values to change the behavior of the application.

The following values can be configured:

    ExchangeRateApi:BaseUrl: The base URL of the external API to query for exchange rates. (not yet hard coded)
    ExchangeRateApi:ApiKey: The API key to use when querying the external API.

Contributing

If you find a bug or have an idea for a new feature, feel free to open an issue or submit a pull request.
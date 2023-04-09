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
graph	
2021-11-01T00:00:00	3.1665
2021-11-02T00:00:00	3.1459
2021-11-03T00:00:00	3.1429
2021-11-04T00:00:00	3.1334
2021-11-05T00:00:00	3.1264
2021-11-06T00:00:00	3.1254
2021-11-07T00:00:00	3.1271
2021-11-08T00:00:00	3.1213
2021-11-09T00:00:00	3.1157
2021-11-10T00:00:00	3.1196
2021-11-11T00:00:00	3.1243
2021-11-12T00:00:00	3.1252
2021-11-13T00:00:00	3.1169
2021-11-14T00:00:00	3.1137
2021-11-15T00:00:00	3.122
2021-11-16T00:00:00	3.1131
2021-11-17T00:00:00	3.0986
2021-11-18T00:00:00	3.0861
2021-11-19T00:00:00	3.0954
2021-11-20T00:00:00	3.098
2021-11-21T00:00:00	3.096
2021-11-22T00:00:00	3.1043
2021-11-23T00:00:00	3.1101
2021-11-24T00:00:00	3.1407
2021-11-25T00:00:00	3.1571
2021-11-26T00:00:00	3.1766
2021-11-27T00:00:00	3.1858
2021-11-28T00:00:00	3.1861
2021-11-29T00:00:00	3.1906
2021-11-30T00:00:00	3.1708
min	3.0861
max	3.1906
```
![Screenshot(4)](https://user-images.githubusercontent.com/104764679/230756465-e5e95b8a-7445-4a5b-92c1-81b0a3f47bbd.png)

# Configuration

The application reads its configuration values from the appsettings.json file in the project root directory. You can modify these values to change the behavior of the application.

The following values can be configured:

    ExchangeRateApi:BaseUrl: The base URL of the external API to query for exchange rates. (not yet hard coded)
    ExchangeRateApi:ApiKey: The API key to use when querying the external API.

Contributing

If you find a bug or have an idea for a new feature, feel free to open an issue or submit a pull request.

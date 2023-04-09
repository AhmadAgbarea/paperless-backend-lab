

Backend:

1. [X] Create a new console app Function App 4 project in Visual Studio.
2. [X] Implement a GET endpoint that takes in a year and month in the format yymm, e.g. /currency/2212.
3. [X] Query a free currency exchange rate API for USD/NIS rates for the specified month using a static singleton http client class called ExchangeRateService.
4. [X] Return a JSON object that includes a dictionary of rate per day of the month named GRAPH (in capital letters) and the minimum and maximum values for the month using LINQ.
5. [X] Create a service class that contains all the logic for querying the currency exchange rate API and calculating the values.
6. [X] Use class library DI to call the service class from the FunctionApp, and use an interface for the service.
7. [X] Add a unit test to test the service.

Frontend:

1. Create a new Angular project with one input field for the month and one button that calls the backend endpoint using a service and displays the result.
2. [X] Use SCSS to style the form to give it a reasonable look.
3. [X] Separate the frontend and backend projects.
4. [X] Make sure to write clear and concise code with comments and no dead code or empty lines.
5. [X] Test the app to ensure that all requirements are met.
6. [ ] Record a video explaining the code and demonstrating the app in runtime.
7. [X] Upload the solution to GitHub.



---


# Currency Exchange Rate App

This is a Currency Exchange Rate app, which consists of a backend and frontend. The backend is a .NET Core console application that serves a GET endpoint that queries a free currency exchange rate API for USD/NIS rates for a specified month. The frontend is an Angular application that presents a form with an input field for the month and a button to call the backend endpoint and display the result.

# Backend
## Prerequisites

    .NET Core SDK
    IDE or text editor

## Setup

    Clone this repository
    Navigate to the backend/CurrencyExchangeRateApp directory in your terminal
    Run dotnet run to build and run the backend application

## API Endpoint

    Endpoint: /currency/{date}
    Input: Month in YYMM format
    Output: JSON object with:
        Dictionary of rate per day of month, named GRAPH (in capital letters)
        Min and Max values (using LINQ)

## Querying the API

    The backend queries a free currency exchange rate API for USD/NIS rates for the specified month
    It uses a static singleton http client (class name: ExchangeRateService)

## Project Structure

The backend project follows a typical .NET Core architecture with the following structure:

    Func/Startup.cs: Configures the application services
    Func/Currency.cs: Contains the GET endpoint that returns the exchange rate data
    Func/ExchangeRateService.cs: Contains the logic for querying the currency exchange rate API and formatting the response

Unit Test

    The ExchangeRateServiceTests.cs file contains a unit test to test the GetExchangeRatesAsync method in the ExchangeRateService class.

---


---

# Frontend
## Prerequisites
- Angular CLI

## Setup

- Navigate to the frontend/currency-exchange-rate-app directory in your terminal
- Run npm install to install the dependencies
- Run ng serve to start the development server
- Open http://localhost:4200 in your browser to view the app

## Features

- The frontend presents a form with one input field for month and one button that calls the backend endpoint using a service and displays the result.
    The form has basic styling using SCSS.


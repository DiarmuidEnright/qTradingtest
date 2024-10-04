# API Documentation

This document outlines the API for the Quantitative Trading System, including data feeds, indicators, signal generators, prediction models, and the main trading system.

## Data Feed API
- **IDataFeed**: Interface for all data feeds.
  - `GetHistoricalData(symbol: string, startDate: DateTime, endDate: DateTime): List<PriceData>`

## Indicators API
- **IIndicator**: Interface for all indicators.
  - `Calculate(values: List<double>): List<double>`

## Signal Generator API
- **ISignalGenerator**: Interface for generating buy/sell signals.
  - `GenerateSignal(data: List<PriceData>): List<Signal>`

## Prediction Models API
- **IPredictionModel**: Interface for prediction models.
  - `Predict(inputData: List<double>): double`

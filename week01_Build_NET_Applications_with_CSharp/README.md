# Week 01 Assignment

This folder contains the working code for W01 Assignment: Build .NET Applications with C#.

## Environment

- The repository is pinned to .NET SDK 8.0.422 with `../global.json`.
- `Week01Assignment.sln` contains both assignment projects.

## Projects

- `SalesSummary` - console app for the file and directory module. It reads `.csv` sales files from `Data/SalesFiles`, totals the sales, and writes `Data/sales-summary.txt`.
- `PizzaApi` - ASP.NET Core controller Web API for the pizza CRUD module.

## Commands

```powershell
dotnet --version
dotnet build Week01Assignment.sln
dotnet run --project SalesSummary
dotnet run --project PizzaApi
```

## Pizza API Examples

When the API is running, test these operations:

```http
GET /api/pizza
GET /api/pizza/1
POST /api/pizza
PUT /api/pizza/1
DELETE /api/pizza/1
```

Sample JSON body for POST or PUT:

```json
{
  "name": "Hawaiian",
  "isGlutenFree": false
}
```

## Sales Summary Function

The required working function for Part 2 is `CreateSalesSummaryReport` in `SalesSummary/Program.cs`.

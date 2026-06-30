# W01 Submission Notes

## 1. Web API Evidence

Project: `week01/PizzaApi`

Controller: `week01/PizzaApi/Controllers/PizzaController.cs`

The API starts with this existing pizza content:

```json
[
  {
    "id": 1,
    "name": "Classic Italian",
    "isGlutenFree": false
  },
  {
    "id": 2,
    "name": "Veggie",
    "isGlutenFree": true
  },
  {
    "id": 3,
    "name": "Spicy Pepperoni",
    "isGlutenFree": false
  }
]
```

I tested adding this additional record with `POST /api/pizza`:

```json
{
  "name": "Hawaiian",
  "isGlutenFree": false
}
```

The API created the new record with this result:

```json
{
  "id": 4,
  "name": "Hawaiian",
  "isGlutenFree": false
}
```

I also verified the update and delete operations:

```text
GET /api/pizza returned 3 existing records.
POST /api/pizza created id 4.
PUT /api/pizza/4 returned status 204.
DELETE /api/pizza/4 returned status 204.
```

## 2. Sales Summary Function

Project: `week01/SalesSummary`

Working function for Part 2:

```csharp
static void CreateSalesSummaryReport(string salesDirectoryPath, string reportFilePath, CultureInfo currencyCulture)
{
    decimal totalSales = 0;
    var fileTotals = new List<string>();

    foreach (var salesFilePath in Directory.EnumerateFiles(salesDirectoryPath, "*.csv").OrderBy(file => file))
    {
        var fileTotal = CalculateFileTotal(salesFilePath);

        totalSales += fileTotal;
        fileTotals.Add($"{Path.GetFileName(salesFilePath)}: {fileTotal.ToString("C", currencyCulture)}");
    }

    var report = new StringBuilder();
    report.AppendLine("Sales Summary");
    report.AppendLine("-------------------------");
    report.AppendLine($"Total Sales: {totalSales.ToString("C", currencyCulture)}");
    report.AppendLine();
    report.AppendLine("Details:");

    foreach (var fileTotal in fileTotals)
    {
        report.AppendLine(fileTotal);
    }

    File.WriteAllText(reportFilePath, report.ToString());
}
```

The function reads `.csv` files from `week01/Data/SalesFiles`, calculates the total sales, and writes the report to `week01/Data/sales-summary.txt`.

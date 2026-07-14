using System.Globalization;
using System.Text;

const string dataDirectory = "Data";
const string salesDirectoryName = "SalesFiles";
const string reportFileName = "sales-summary.txt";
var currencyCulture = CultureInfo.GetCultureInfo("en-US");

Directory.CreateDirectory(dataDirectory);

var salesDirectoryPath = Path.Combine(dataDirectory, salesDirectoryName);
var reportFilePath = Path.Combine(dataDirectory, reportFileName);

EnsureSampleSalesFiles(salesDirectoryPath);
CreateSalesSummaryReport(salesDirectoryPath, reportFilePath, currencyCulture);

Console.WriteLine($"Sales summary created at: {Path.GetFullPath(reportFilePath)}");
Console.WriteLine(File.ReadAllText(reportFilePath));

static void EnsureSampleSalesFiles(string salesDirectoryPath)
{
    Directory.CreateDirectory(salesDirectoryPath);

    if (Directory.EnumerateFiles(salesDirectoryPath, "*.csv").Any())
    {
        return;
    }

    File.WriteAllLines(
        Path.Combine(salesDirectoryPath, "pizza-sales.csv"),
        new[]
        {
            "Product,Amount",
            "Margherita Pizza,18.99",
            "Pepperoni Pizza,22.49",
            "Veggie Pizza,20.00"
        });

    File.WriteAllLines(
        Path.Combine(salesDirectoryPath, "side-sales.csv"),
        new[]
        {
            "Product,Amount",
            "Breadsticks,7.50",
            "Lemonade,4.25"
        });
}

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

static decimal CalculateFileTotal(string salesFilePath)
{
    decimal fileTotal = 0;

    foreach (var line in File.ReadLines(salesFilePath).Skip(1))
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            continue;
        }

        var columns = line.Split(',', 2);
        if (columns.Length != 2)
        {
            continue;
        }

        var amountText = columns[1].Trim();

        if (!decimal.TryParse(amountText, NumberStyles.Currency, CultureInfo.InvariantCulture, out var amount))
        {
            continue;
        }

        fileTotal += amount;
    }

    return fileTotal;
}

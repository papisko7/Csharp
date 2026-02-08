using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.NewSolution;
using CsvDataAccess.PerformanceTesting;

string filePath = "sampleData.csv";
var csvData = new CsvReader().Read(filePath);

ITableDataBuilder tableDataBuilder = new FastTableDataBuilder();

var _ = TableDataPerformanceMeasurer.Test(
	tableDataBuilder, csvData);

var testResult = TableDataPerformanceMeasurer.Test(
	tableDataBuilder, csvData);

Console.WriteLine("Test results for new code:");
Console.WriteLine("Memory increase in bytes: " +
	string.Format("{0:n0}", testResult.MemoryIncreaseInBytes));
Console.WriteLine($"Time of loading the CSV was " +
	$"{testResult.TimeOfBuildingTable}.");
Console.WriteLine($"Time of reading the CSV was " +
	$"{testResult.TimeOfDataReading}.");

Console.WriteLine("Done. Press any key to close.");
Console.ReadKey();
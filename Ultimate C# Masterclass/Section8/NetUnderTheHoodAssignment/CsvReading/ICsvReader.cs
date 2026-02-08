namespace CsvDataAccess.CsvReading;

public interface ICsvReader
{
	public CsvData Read(string filePath);
}
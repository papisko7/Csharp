using CsvDataAccess.CsvReading;

namespace CsvDataAccess.Interface;

public interface ITableDataBuilder
{
	public ITableData Build(CsvData csvData);
}
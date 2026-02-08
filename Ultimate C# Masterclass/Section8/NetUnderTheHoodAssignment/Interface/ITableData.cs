namespace CsvDataAccess.Interface;

public interface ITableData
{
	public IEnumerable<string> Columns { get; }

	public int RowCount { get; }

	public object GetValue(string columnName, int rowIndex);
}
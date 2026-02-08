using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;

public class FastTableData : ITableData
{
	public int RowCount => _rows.Count;

	public IEnumerable<string> Columns { get; }

	private readonly List<FastRow> _rows;

	public FastTableData(IEnumerable<string> columns, List<FastRow> rows)
	{
		_rows = rows;
		Columns = columns;
	}

	public object GetValue(string columnName, int rowIndex)
	{
		return _rows[rowIndex].GetAtColumn(columnName);
	}
}
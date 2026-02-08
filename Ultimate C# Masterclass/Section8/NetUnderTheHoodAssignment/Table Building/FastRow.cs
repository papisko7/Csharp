namespace CsvDataAccess.NewSolution;

public class FastRow
{
	private Dictionary<string, object> _data;

	public FastRow(Dictionary<string, object> data)
	{
		_data = data;
	}

	public object GetAtColumn(string columnName)
	{
		if (_data.ContainsKey(columnName))
		{
			return _data[columnName];
		}

		return null;
	}
}
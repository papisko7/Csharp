using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
	public ITableData Build(CsvData csvData)
	{
		var resultRows = new List<Row>(csvData.Rows.Count());
		int columnsCount = csvData.Columns.Length;

		foreach (var row in csvData.Rows)
		{
			Dictionary<string, object> newRowData = null;

			for (int columnIndex = 0; columnIndex < columnsCount; ++columnIndex)
			{
				string valueAsString = row[columnIndex];

				if (string.IsNullOrEmpty(valueAsString))
				{
					continue;
				}

				if (newRowData == null)
				{
					newRowData = new Dictionary<string, object>(columnsCount);
				}

				var column = csvData.Columns[columnIndex];
				newRowData[column] = ConvertValueToTargetType(valueAsString);
			}

			if (newRowData != null)
			{
				resultRows.Add(new Row(newRowData));
			}
		}

		return new TableData(csvData.Columns, resultRows);
	}

	private object ConvertValueToTargetType(string value)
	{
		if (value.Equals("TRUE", StringComparison.Ordinal))
		{
			return true;
		}

		if (value.Equals("FALSE", StringComparison.Ordinal))
		{
			return false;
		}

		if (int.TryParse(value, out var valueAsInt))
		{
			return valueAsInt;
		}

		if (decimal.TryParse(value, System.Globalization.NumberStyles.Any,
			System.Globalization.CultureInfo.InvariantCulture, out var valueAsDecimal))
		{
			return valueAsDecimal;
		}

		return value;
	}
}
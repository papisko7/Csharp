using TicketsDataAggregator.Contracts;

namespace TicketsDataAggregator.IO;

public class FileWriter : IFileWriter
{
	public void WriteLines(string path, IEnumerable<string> lines)
	{
		File.WriteAllLines(path, lines);
	}
}
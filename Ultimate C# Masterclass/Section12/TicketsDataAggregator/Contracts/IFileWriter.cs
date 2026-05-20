namespace TicketsDataAggregator.Contracts;

public interface IFileWriter
{
	void WriteLines(string path, IEnumerable<string> lines);
}
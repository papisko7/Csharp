using Section6.Caching;
using Section6.Interfaces;

namespace Section6.Logic
{
	public class DataDownloader : IDataDownloader
	{
		private readonly IGenericCache<string, string> _cache;

		public DataDownloader()
		{
			_cache = new GenericCache<string, string>();
		}

		public string DownloadData(string id)
		{
			Thread.Sleep(1000);
			return $"Data for {id}";
		}

		public void DisplayData(string id)
		{
			Console.WriteLine(DownloadData(id));
		}
	}
}
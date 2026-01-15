using Section6.Interfaces;

namespace Section6.Caching
{
	public class CachingDataDownloader : IDataDownloader
	{
		private readonly IGenericCache<string, string> _cache;
		private readonly IDataDownloader _dataDownloader;

		public CachingDataDownloader(IDataDownloader dataDownloader, IGenericCache<string, string> cache)
		{
			_dataDownloader = dataDownloader;
			_cache = cache;
		}

		public string DownloadData(string id)
		{
			return _cache.Get(id, _dataDownloader.DownloadData);
		}

		public void DisplayData(string id)
		{
			Console.WriteLine(DownloadData(id));
		}
	}
}
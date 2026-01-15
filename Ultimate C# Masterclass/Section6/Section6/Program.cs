using Section6.Caching;
using Section6.Interfaces;
using Section6.Logic;

namespace Section6
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IDataDownloader dataDownloader = new CachingDataDownloader(new DataDownloader(), new GenericCache<string, string>());

			dataDownloader.DisplayData("id1");
			dataDownloader.DisplayData("id2");
			dataDownloader.DisplayData("id1");
			dataDownloader.DisplayData("id2");
			dataDownloader.DisplayData("id1");
			dataDownloader.DisplayData("id2");
			dataDownloader.DisplayData("id1");
			dataDownloader.DisplayData("id2");
			dataDownloader.DisplayData("id1");
			dataDownloader.DisplayData("id2");
			dataDownloader.DisplayData("id3");
			dataDownloader.DisplayData("id4");
			dataDownloader.DisplayData("id5");
		}
	}
}
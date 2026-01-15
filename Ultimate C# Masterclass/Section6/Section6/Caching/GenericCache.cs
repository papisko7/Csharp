using Section6.Interfaces;

namespace Section6.Caching
{
	public class GenericCache<TKey, TData> : IGenericCache<TKey, TData>
	{
		private readonly Dictionary<TKey, TData> _cachedData = new();

		public TData Get(TKey key, Func<TKey, TData> getForFirstTime)
		{
			if (!_cachedData.ContainsKey(key))
			{
				_cachedData[key] = getForFirstTime(key);
			}

			return _cachedData[key];
		}
	}
}
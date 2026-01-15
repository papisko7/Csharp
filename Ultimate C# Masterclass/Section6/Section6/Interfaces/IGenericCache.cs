namespace Section6.Interfaces
{
	public interface IGenericCache<TKey, TData>
	{
		public TData Get(TKey key, Func<TKey, TData> getForFirstTime);
	}
}
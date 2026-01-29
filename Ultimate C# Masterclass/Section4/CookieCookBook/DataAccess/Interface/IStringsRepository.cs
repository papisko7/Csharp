namespace CookieCookBook.DataAccess.Interface
{
	public interface IStringsRepository
	{
		public List<string> Read(string filePath);

		public void Write(string filePath, List<string> allLines);
	}
}
namespace CookieCookBook.FileManagement.Interface
{
    public interface IStringsRepository
    {
        List<string> Read(string filePath);

        void Write(string filePath, List<string> allLines);
    }
}
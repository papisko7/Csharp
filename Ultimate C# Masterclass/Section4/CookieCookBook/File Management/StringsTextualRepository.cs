using CookieCookBook.FileManagement.Interface;

namespace CookieCookBook.FileManagement
{
    public class StringsTextualRepository : IStringsRepository
    {
        public List<string> Read(string filePath)
        {
            var fileContent = File.ReadAllText(filePath);

            return fileContent.Split(Environment.NewLine).ToList();
        }

        public void Write(string filePath, List<string> allLines)
        {
            File.WriteAllText(filePath, string.Join(Environment.NewLine, allLines));
        }
    }
}
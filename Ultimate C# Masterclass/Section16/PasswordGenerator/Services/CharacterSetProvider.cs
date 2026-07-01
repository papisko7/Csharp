namespace PasswordGenerator.Services;

public class CharacterSetProvider : ICharacterSetProvider
{
	private const string STANDARD_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
	private const string SPECIAL_CHARS = "!@#$%^&*()_-+=";

	public string GetAllowedCharacters(bool useSpecial)
	{
		return useSpecial ? $"{STANDARD_CHARS}{SPECIAL_CHARS}" : STANDARD_CHARS;
	}
}
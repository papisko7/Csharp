namespace PasswordGenerator.Services;

public interface ICharacterSetProvider
{
	string GetAllowedCharacters(bool useSpecial);
}
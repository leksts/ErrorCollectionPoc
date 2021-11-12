namespace ErrorCollectionPoc;

using CSharpFunctionalExtensions;
using System.Linq;

public class Password : SimpleValueObject<string>
{
	private Password(string value) : base(value)
	{
	}

	public static Result<Password, ErrorCollection> Create(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return Errors.PasswordRequired;
		}

		value = value.Trim();

		var errors = ErrorCollection.Empty;

		if (value.Length < 8)
		{
			errors = errors.Append(Errors.PasswordMinLength);
		}

		if (!value.Any(char.IsDigit))
		{
			errors = errors.Append(Errors.PasswordDigitRequired);
		}

		if (errors.HasErrors)
		{
			return errors;
		}

		return new Password(value);
	}
}
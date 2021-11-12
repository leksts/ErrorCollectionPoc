namespace ErrorCollectionPoc;

public static class Errors
{
	public static readonly ErrorCollection PasswordDigitRequired = new("password.digit.required", "Digit required");
	public static readonly ErrorCollection PasswordMinLength = new("password.minlength", "Password minlength");
	public static readonly ErrorCollection PasswordRequired = new("password.required", "Password required");
}

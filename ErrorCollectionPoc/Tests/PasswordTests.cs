namespace ErrorCollectionPoc.Tests;

using System.Linq;
using Xunit;

public class PasswordTests
{
	private static readonly Error RequiredError = new("password.required", string.Empty);
	private static readonly Error MinLengthError = new("password.minlength", string.Empty);
	private static readonly Error DigitRequiredError = new("password.digit.required", string.Empty);

	[Fact]
	public void CanCreateValidPassword()
	{
		var value = "abcd1234";

		var result = Password.Create(value);

		Assert.True(result.IsSuccess);
		Assert.Equal(value, result.Value);
	}

	[Fact]
	public void PasswordIsRequired()
	{
		var value = string.Empty;

		var result = Password.Create(value);

		Assert.True(result.IsFailure);
		Assert.Single(result.Error);
		Assert.Equal(RequiredError, result.Error.Single());
	}

	[Fact]
	public void PasswordMustHaveMinimumLength()
	{
		var value = "abcd123";

		var result = Password.Create(value);

		Assert.True(result.IsFailure);
		Assert.Single(result.Error);
		Assert.Equal(MinLengthError, result.Error.Single());
	}

	[Fact]
	public void PasswordMustContainDigits()
	{
		var value = "abcdefgh";

		var result = Password.Create(value);

		Assert.True(result.IsFailure);
		Assert.Single(result.Error);
		Assert.Equal(DigitRequiredError, result.Error.Single());
	}

	[Fact]
	public void PasswordMustHaveMinimumLengthAndContainDigits()
	{
		var value = "abcd";

		var result = Password.Create(value);

		Assert.True(result.IsFailure);
		Assert.Equal(2, result.Error.Count);
		Assert.Contains(MinLengthError, result.Error);
		Assert.Contains(DigitRequiredError, result.Error);
	}
}
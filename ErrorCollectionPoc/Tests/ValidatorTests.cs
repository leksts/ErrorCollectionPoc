namespace ErrorCollectionPoc.Tests;

using ErrorCollectionPoc.Consumer;
using System.Linq;
using Xunit;

public class ValidatorTests
{
	[Fact]
	public void ValidatesAComplexInvalidCommand()
	{
		var command = new UpdatePasswordCommand
		{
			Password = "abcd"
		};

		var sut = new UpdatePasswordCommandValidator();

		var result = sut.Validate(command);

		Assert.NotNull(result);
		Assert.False(result.IsValid);
		Assert.Equal(2, result.Errors.Count);
		Assert.Contains("Password minlength", result.Errors.Select(x => x.ErrorMessage));
		Assert.Contains("Digit required", result.Errors.Select(x => x.ErrorMessage));
		Assert.True(result.Errors.All(x => x.PropertyName == "Password"));
	}

	[Fact]
	public void ValidatesAValidCommand()
	{
		var command = new UpdatePasswordCommand
		{
			Password = "abcd1234"
		};

		var sut = new UpdatePasswordCommandValidator();

		var result = sut.Validate(command);

		Assert.NotNull(result);
		Assert.True(result.IsValid);
	}
}
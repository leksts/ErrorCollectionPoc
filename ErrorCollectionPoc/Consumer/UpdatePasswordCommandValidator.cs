namespace ErrorCollectionPoc.Consumer;

using FluentValidation;

public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
{
	public UpdatePasswordCommandValidator()
	{
		RuleFor(x => x.Password)
			.MustSucceed(Password.Create);
	}
}
namespace ErrorCollectionPoc.Consumer;

using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;

public static class ValidatorExtensions
{
	public static IRuleBuilderOptions<T, string?> MustSucceed<T, TSuccess>(
		this IRuleBuilder<T, string?> ruleBuilder,
		Func<string?, Result<TSuccess, ErrorCollection>> factoryMethod,
		IStringLocalizer? localizer = null)
	{
		return (IRuleBuilderOptions<T, string>)ruleBuilder.Custom((value, context) =>
		{
			var result = factoryMethod(value);
			if (result.IsFailure)
			{
				foreach (var error in result.Error)
				{
					AddErrorToContext(error, context, localizer);
				}
			}
		});
	}

	private static void AddErrorToContext<T>(Error error, ValidationContext<T> context, IStringLocalizer? localizer)
	{
		var message = localizer is null ? error.Message : localizer[error.Code, error.MessageArguments];
		context.AddFailure(message);
	}
}
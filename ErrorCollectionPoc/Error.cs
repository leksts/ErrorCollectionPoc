namespace ErrorCollectionPoc;

using CSharpFunctionalExtensions;
using System.Collections.Generic;

public class Error : ValueObject
{
	public Error(string code, string messageTemplate, params object[] messageArguments)
	{
		Code = code;
		MessageTemplate = messageTemplate;
		MessageArguments = messageArguments;
	}

	public string Code { get; }
	public string Message => string.Format(MessageTemplate, MessageArguments);
	public object[] MessageArguments { get; }
	public string MessageTemplate { get; }

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Code;
	}
}
namespace ErrorCollectionPoc;

using System.Collections;
using System.Collections.Generic;

public class ErrorCollection : IReadOnlyCollection<Error>
{
	public static readonly ErrorCollection Empty = new();
	private readonly List<Error> _errors;

	public ErrorCollection(string code, string messageTemplate, params object[] messageArguments) : this()
	{
		_errors.Add(new Error(code, messageTemplate, messageArguments));
	}

	public ErrorCollection(IEnumerable<Error> errors) : this()
	{
		_errors.AddRange(errors);
	}

	private ErrorCollection()
	{
		_errors = new List<Error>();
	}

	public int Count => _errors.Count;

	public bool HasErrors => Count > 0;

	public IEnumerator<Error> GetEnumerator() => _errors.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
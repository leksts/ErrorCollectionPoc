namespace ErrorCollectionPoc;

using System.Linq;

public static class ErrorCollectionExtensions
{
	public static ErrorCollection Append(this ErrorCollection collection, ErrorCollection errors)
	{
		return new(collection.Union(errors));
	}
}
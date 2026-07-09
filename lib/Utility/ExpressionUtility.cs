using No1.Commons.Exceptions;
using System.Linq.Expressions;

namespace No1.Commons.Utility;

public static class ExpressionUtility
{
	public static string GetPropertyPath<TEntity>(
		Expression<Func<TEntity, object>> expression
	) {
		ArgumentNullException.ThrowIfNull(expression);
		Expression body = expression.Body;

		// Remove boxing conversion for value types
		if (body is UnaryExpression unary &&
			unary.NodeType == ExpressionType.Convert) {
			body = unary.Operand;
		}

		var members = new Stack<string>();

		while (body is MemberExpression memberExpression) {
			members.Push(memberExpression.Member.Name);
			body = NullExpressionException.Exec(() => memberExpression.Expression);
		}

		return string.Join(".", members);
	}
}
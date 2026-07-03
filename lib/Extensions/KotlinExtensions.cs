namespace No1.Commons.Extensions;

public static class KotlinExtensions
{
	public static TOutput? If<TOutput, TInput>(this TInput? value, Func<TInput, TOutput> func)
	where TOutput : notnull
	where TInput : notnull {
		ArgumentNullException.ThrowIfNull(func);
		return value.IsUsable() ? func(value) : default;
	}
}
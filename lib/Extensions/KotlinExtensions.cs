namespace No1.Commons.Extensions;

public static class KotlinExtensions
{
	public static TOutput? If<TOutput, TInput>(this TInput? value, Func<TInput, TOutput> func)
	where TOutput : notnull
	where TInput : notnull {
		ArgumentNullException.ThrowIfNull(func);
		return value.IsUsable() ? func(value) : default;
	}

	public static T Init<T>(this T value, Action<T> action)
	where T : notnull {
		ArgumentNullException.ThrowIfNull(action);
		action(value);
		return value;
	}

	public static Task<T> InitAsync<T>(this T value, Action<T> action)
	where T : notnull {
		ArgumentNullException.ThrowIfNull(action);
		action(value);
		return Task.FromResult(value);
	}
}
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

	public static async Task<T> InitAsync<T>(this T value, Func<T, Task> action)
	where T : notnull {
		ArgumentNullException.ThrowIfNull(action);
		await action(value).ConfigureAwait(true);
		return value;
	}
}
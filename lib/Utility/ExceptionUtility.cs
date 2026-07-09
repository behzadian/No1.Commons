namespace No1.Commons.Utility;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Skip")]
public static class ExceptionUtility
{
	public static T ExecExceptionless<T>(Func<T> func, T defaultValue)
		where T : notnull {
		ArgumentNullException.ThrowIfNull(func);
		try {
			return func();
		} catch (Exception) {
			return defaultValue;
		}
	}

	public static T TryCatch<T>(Func<T> func, Func<Exception, T> catcher)
		where T : notnull {
		ArgumentNullException.ThrowIfNull(func);
		ArgumentNullException.ThrowIfNull(catcher);
		try {
			return func();
		} catch (Exception ex) {
			return catcher(ex);
		}
	}

	public static T TryThrow<T>(Func<T> func, Action<Exception> catcher)
		where T : notnull {
		ArgumentNullException.ThrowIfNull(func);
		ArgumentNullException.ThrowIfNull(catcher);
		try {
			return func();
		} catch (Exception ex) {
			catcher(ex);
			throw new InvalidOperationException("Exception while executing TryThrow", ex);
		}
	}
}
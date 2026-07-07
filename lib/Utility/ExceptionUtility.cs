namespace No1.Commons.Utility;

public static class ExceptionUtility
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Skip")]
	public static T ExecExceptionless<T>(Func<T> func, T defaultValue)
		where T : notnull {
		ArgumentNullException.ThrowIfNull(func);
		try {
			return func();
		} catch (Exception) {
			return defaultValue;
		}
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Skip")]
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
}
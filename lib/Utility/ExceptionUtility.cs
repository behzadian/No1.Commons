using System;
using System.Collections.Generic;
using System.Text;

namespace No1.Commons.Utility;

public static class ExceptionUtility
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
	public static T ExecExceptionless<T>(this Func<T> func, T defaultValue) where T : notnull {
		try {
			ArgumentNullException.ThrowIfNull(func);
			return func();
		} catch (Exception) {
			return defaultValue;
		}
	}
}
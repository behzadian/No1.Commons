using System.Net;

namespace No1.Commons.Utility;

public static class ParseUtility
{
	public static T? ParseAs<T>(this string value) where T : struct, IParsable<T> {
		return T.TryParse(value, null, out var parsed) ? parsed : null;
	}

	public static Uri? ParseAsUri(this string value) {
		return Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out var parsed) ? parsed : null;
	}

	public static Version? ParseAsVersion(this string value) {
		return Version.TryParse(value, out var parsed) ? parsed : null;
	}

	public static IPAddress? ParseAsIPAddress(this string value) {
		return IPAddress.TryParse(value, out var parsed) ? parsed : null;
	}

	public static IPEndPoint? ParseAsIPEndPoint(this string value) {
		return IPEndPoint.TryParse(value, out var parsed) ? parsed : null;
	}
}
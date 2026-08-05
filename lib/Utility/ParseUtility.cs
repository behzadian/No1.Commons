namespace No1.Commons.Utility;

public static class ParseUtility
{
	public static short? GetShort(this string value) {
		if (short.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static int? GetInt32(this string value) {
		if (int.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static long? GetLong(this string value) {
		if (long.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static double? GetDouble(this string value) {
		if (double.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static Int128? GetInt128(this string value) {
		if (Int128.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static bool? GetBoolean(this string value) {
		if (bool.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static char? GetChar(this string value) {
		if (char.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static byte? GetByte(this string value) {
		if (byte.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static sbyte? GetSignedByte(this string value) {
		if (sbyte.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static decimal? GetDecimal(this string value) {
		if (decimal.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static float? GetFloat(this string value) {
		if (float.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static uint? GetUnsignedInt(this string value) {
		if (uint.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static nint? GetNint(this string value) {
		if (nint.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static nuint? GetNuint(this string value) {
		if (nuint.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static ulong? GetUnsignedLong(this string value) {
		if (ulong.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}

	public static ushort? GetUnsignedShort(this string value) {
		if (ushort.TryParse(value, out var parsed)) {
			return parsed;
		} else {
			return null;
		}
	}
}
namespace No1.Commons.Extensions;

public static class TypeExtensionMethods
{
	/// <summary>
	/// Returns name of Type with valid tags for generic parameters.
	/// </summary>
	/// <param name="type">input.</param>
	/// <returns>Friendly name of input type.</returns>
	public static string FriendlyName(this Type type) {
		ArgumentNullException.ThrowIfNull(type);
		return Format(type);

		static string Format(Type t) {
			if (t.IsByRef) {
				return Format(t.GetElementType()!) + "&";
			}

			if (t.IsArray) {
				var element = Format(t.GetElementType()!);
				var rank = t.GetArrayRank();
				return rank == 1 ? $"{element}[]" : $"{element}[{new string(',', rank - 1)}]";
			}

			if (Nullable.GetUnderlyingType(t) is Type underlying) {
				return Format(underlying) + "?";
			}

			if (t.IsGenericType) {
				var name = t.Name;
				var tick = name.IndexOf('`', StringComparison.InvariantCultureIgnoreCase);
				if (tick >= 0) {
					name = name[..tick];
				}

				var args = string.Join(", ", Array.ConvertAll(t.GetGenericArguments(), Format));
				return $"{name}<{args}>";
			}

			if (t.IsNested) {
				return $"{Format(t.DeclaringType!)}.{t.Name}";
			}

			return t.Name;
		}
	}
}
namespace No1.Commons.Exceptions;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Not Needed")]
public class UnsupportedEnumException<TEnum>(TEnum enumValue) : Exception($"Value {typeof(TEnum).Name}.{enumValue} is not supported.")
	where TEnum : Enum
{
}
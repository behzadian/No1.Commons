namespace No1.Commons.Exceptions;

/// <summary>
/// Use this exception to simplify unhandled enum switch.
/// Imagine there an enum type with below definition:
/// <code>
/// public enum Vals
/// {
///    A,
///    B,
///    C
/// }
/// </code>
/// Then you can use this exception in default case:
/// <code>
/// Vals v = Vals.C;
/// switch(v)
/// {
///     case A:
///     // do something
///        break;
///     case B:
///     // do some other thiung
///        break;
///     default:
///         throw new UnsupportedEnumException&lt;Vals&gt;(v)
/// }
/// </code>
/// The exception's message will be `Value Vals.C is not supported.`.
/// </summary>
/// <typeparam name="TEnum">Type of enum.</typeparam>
/// <param name="enumValue">Value that is subject of throwing this exception.</param>
[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Not Needed")]
public class UnsupportedEnumException<TEnum>(TEnum enumValue) : Exception($"Value {typeof(TEnum).Name}.{enumValue} is not supported.")
	where TEnum : Enum
{
}
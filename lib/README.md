# No1.Commons

This package contains several helper classes and methods that made developing a little bit easier!

Here is list of them:

## NullExpressionException

If you expect the result of an expression be not null and also do not want to check the result manually by using `?? throw ..` syntax and with a meaningful message, or by appending `!` at the end of expression and facing with meaningless error message, you can use this exception class and its static method like below:

```csharp
// Imagegine result of following expression must be not not,
// but you are want to see meaningful error message in case 
// of null result:
// a.b().c["d"] ? g
// Then you can use below expressin:

var result = NullExpressionException.Exec(()=>a.b().c["d"] ? g);

// also you can use strongly typed, like:
string result = NullExpressionException.Exec(()=>a.b().c["d"] ? g);

// because the definition of method is:
// `T Exec<T>(Func<T> func` so below expression is also applicable:
string result = NullExpressionException.Exec<string>(()=>a.b().c["d"] ? g);

// what if the result was null? Then you will see exception of type:
// NullExpressionException with below message:
// `()=>a.b().c["d"] ? g` returned NULL
```

## UnsupportedEnumException

Used specifically on switching over an enum like below:

```csharp
enum Values 
{
	A,
	B,
	C
}

Values e = Values.C;

switch(e)
{
	case A:
		// do something
		break;
	case B:
		// do some other thing
		break;
	default:
		throw new UnsupportedEnumException(e);
		// throws a UnsupportedEnumException with below message:
		// Value Values.C is not supported.
}
```

## CollectionExtensionMethods

### IEnumerable<T>.IsUsable()
This extension method returns true if IEnumerable<T> is not null and contains at least one value.
Also, if returns true, compiler knows that the passed IEnumerable<T> is not null.

### IEnumerable<T>.IsUseless()
This extension method, does opposite of `IsUsable()` method and returns true if IEnumerable<T> is null or empty.


## GeneralExtensionMethods

### Object.HasValue()
This extension method reut
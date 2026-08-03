using No1.Commons.Extensions;

namespace tests;

public class HasValueTests
{
	[SetUp]
	public void Setup() {
		Clean();
	}

	[TearDown]
	public void Stop() {
		Clean();
	}

	private static void Clean() {
	}

	[Test]
	public void WhenNullObjectPostedThenReturnFalse() {
		// Arrange
		object? @null = null;

		// Act
		var hasValue = @null.HasValue();

		// Assert
		Assert.False(hasValue);
	}

	[Test]
	public void WhenNonNullObjectPostedThenReturnTrue() {
		// Arrange
		object? obj = new object();

		// Act
		var hasValue = obj.HasValue();

		// Assert
		Assert.True(hasValue);
	}

	[Test]
	public void WhenDefaultObjectPostedThenReturnFalse() {
		// Arrange
		DateTime @default = default;

		// Act
		var hasValue = @default.HasValue();

		// Assert
		Assert.False(hasValue);
	}

	[Test]
	public void WhenNonDefaultObjectPostedThenReturnTrue() {
		// Arrange
		DateTime value = DateTime.Now;

		// Act
		var hasValue = value.HasValue();

		// Assert
		Assert.True(hasValue);
	}

	[Test]
	public void WhenEmptyEnumerablePostedThenReturnFalse() {
		// Arrange
		List<object> list = [];

		// Act
		var hasValue = list.HasValue();

		// Assert
		Assert.False(hasValue);
	}

	[Test]
	public void WhenFilledEnumerablePostedThenReturnFalse() {
		// Arrange
		List<object> list = [new object()];

		// Act
		var hasValue = list.HasValue();

		// Assert
		Assert.True(hasValue);
	}

	[Test]
	public void WhenEmptyStringPostedThenReturnFalse() {
		// Arrange

		// Act
		var hasValue = string.Empty.HasValue();

		// Assert
		Assert.False(hasValue);
	}

	[Test]
	public void WhenFilledStringPostedThenReturnFalse() {
		// Arrange

		// Act
		var hasValue = "|".HasValue();

		// Assert
		Assert.True(hasValue);
	}
}
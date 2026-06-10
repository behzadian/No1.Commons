using No1.Commons.Utility;

namespace nest;

public class EnvUtilityTests
{
	private const string DOTENV_FILE_PATH = "../.env";

	[SetUp]
	public void Setup() {
		Clean();
	}

	[TearDown]
	public void Stop() {
		Clean();
	}

	private static void Clean() {
		EnvUtility.envFileKeyValues.Clear();
		if (File.Exists(DOTENV_FILE_PATH)) {
			File.Delete(DOTENV_FILE_PATH);
		}
	}

	[Test]
	public void WhenTheEnvFileDoesNotExistThenThrowsException() {
		// Arrange

		// Act
		var exception = Assert.Throws<FileNotFoundException>(() => EnvUtility.GetEnvFileKey("key"));

		// Assert
		Assert.That(exception.Message, Does.StartWith("No .env file found in any of below paths:"));
	}

	[Test]
	public void WhenTheEnvFileExistsButNotTheKeyThenReturnNull() {
		// Arrange
		File.AppendAllLines(DOTENV_FILE_PATH, ["key=value"]);

		// Act
		var value = EnvUtility.GetEnvFileKey("other");

		// Assert
		Assert.That(value, Is.Null);
	}

	[Test]
	public void WhenBothTheEnvFileAndTheKeyExistThenReturnCorrectValue() {
		// Arrange
		File.AppendAllLines(DOTENV_FILE_PATH, ["key=value"]);

		// Act
		var value = EnvUtility.GetEnvFileKey("key");

		// Assert
		Assert.That(value, Is.EqualTo("value"));
	}

	[Test]
	public void WhenEnvFileAndKeyExistAndValueSurroundedBySingleQuotationThenReturnCorrectValue() {
		// Arrange
		File.AppendAllLines(DOTENV_FILE_PATH, ["key='value'"]);

		// Act
		var value = EnvUtility.GetEnvFileKey("key");

		// Assert
		Assert.That(value, Is.EqualTo("value"));
	}

	[Test]
	public void WhenEnvFileAndKeyExistAndValueSurroundedByDoubleQuotationThenReturnCorrectValue() {
		// Arrange
		File.AppendAllLines(DOTENV_FILE_PATH, ["key=\"value\""]);

		// Act
		var value = EnvUtility.GetEnvFileKey("key");

		// Assert
		Assert.That(value, Is.EqualTo("value"));
	}
}

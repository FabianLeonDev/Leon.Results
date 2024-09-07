# Leon.Results

**Leon.Results** is a .NET library that provides a simple and intuitive way to handle operation results, making it easier to manage success and failure cases, especially in scenarios involving validation, error handling, and return values.

## Installation

You can install the **Leon.Results** package via NuGet Package Manager Console:

```bash
Install-Package Leon.Results
```

Or by adding it to your `.csproj` file:

```xml
<PackageReference Include="Leon.Results" Version="1.0.0" />
```

## Usage

### Basic Result Handling

The `Result` class is designed to indicate the outcome of an operation, whether it was successful or failed.

```csharp
using Leon.Results;

// Creating a success result
Result successResult = Result.Success();

// Creating a failure result with error messages
Result failureResult = Result.Failure(new List<string> { "Error 1", "Error 2" });

if (successResult.IsSuccess)
{
    // Handle success
}
else
{
    // Handle failure and access error messages
    IEnumerable<string> errors = failureResult.Errors;
}
```

### Result with Value

For operations that return a value upon success, you can use the `Result<T>` class.

```csharp
using Leon.Results;

// Creating a success result with a value
Result<int> successWithValue = Result<int>.Success(42);

// Creating a failure result with error messages and no value
Result<int> failureWithValue = Result<int>.Failure(new List<string> { "Failed to compute value" });

if (successWithValue.IsSuccess)
{
    int value = successWithValue.Value;
    // Use the value
}
else
{
    // Handle failure and access error messages
    IEnumerable<string> errors = failureWithValue.Errors;
}
```

## License

This project is licensed under the MIT License.
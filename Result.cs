namespace Leon.Results
{
    /// <summary>
    /// Represents the result of an operation, indicating whether it was successful or failed.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets a value indicating whether the operation was successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets a collection of error messages associated with the failed operation.
        /// </summary>
        public IEnumerable<string> Errors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">Indicates whether the operation was successful.</param>
        /// <param name="errors">A collection of error messages.</param>
        protected Result(bool isSuccess, IEnumerable<string> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        /// <summary>
        /// Creates a new successful result with no errors.
        /// </summary>
        /// <returns>A successful result.</returns>
        public static Result Success() => new(true, new List<string>());

        /// <summary>
        /// Creates a new failed result with the specified errors.
        /// </summary>
        /// <param name="errors">A collection of error messages.</param>
        /// <returns>A failed result.</returns>
        public static Result Failure(IEnumerable<string> errors) => new(false, errors);
    }

    /// <summary>
    /// Represents the result of an operation that may also contain a value.
    /// </summary>
    /// <typeparam name="T">The type of the value included in the result.</typeparam>
    public class Result<T> : Result
    {
        /// <summary>
        /// Gets the value associated with the successful result.
        /// </summary>
        public T? Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="isSuccess">Indicates whether the operation was successful.</param>
        /// <param name="value">The value associated with the successful result.</param>
        /// <param name="errors">A collection of error messages.</param>
        private Result(bool isSuccess, T? value, IEnumerable<string> errors)
            : base(isSuccess, errors)
        {
            Value = value;
        }

        /// <summary>
        /// Creates a new successful result with the specified value.
        /// </summary>
        /// <param name="value">The value associated with the successful result.</param>
        /// <returns>A successful result with the included value.</returns>
        public static Result<T> Success(T value) => new(true, value, new List<string>());

        /// <summary>
        /// Creates a new failed result with the specified errors.
        /// </summary>
        /// <param name="errors">A collection of error messages.</param>
        /// <returns>A failed result without a value.</returns>
        public static new Result<T> Failure(IEnumerable<string> errors) => new(false, default, errors);
    }
}

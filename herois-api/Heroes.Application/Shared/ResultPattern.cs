using System;

namespace Heroes.Application.Shared
{
    public class ErrorDetail
    {
        public string Message { get; set; } = string.Empty;
    }

    public class ResultPattern<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; }
        public ErrorDetail? Error { get; }

        private ResultPattern(bool isSuccess, T? value, ErrorDetail? error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public static ResultPattern<T> Success(T value) => new ResultPattern<T>(true, value, null);

        public static ResultPattern<T> Failure(string message) =>
            new ResultPattern<T>(false, default, new ErrorDetail { Message = message});
    }

    public class ResultPattern
    {
        public bool IsSuccess { get; }
        public ErrorDetail? Error { get; }

        private ResultPattern(bool isSuccess, ErrorDetail? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static ResultPattern Success() => new ResultPattern(true, null);

        public static ResultPattern Failure(string message) =>
            new ResultPattern(false, new ErrorDetail { Message = message });
    }
}

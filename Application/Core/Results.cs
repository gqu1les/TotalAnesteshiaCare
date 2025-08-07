using System;

namespace Application.Core;

public class Results<T>
{
    public bool IsSuccess { get; set; }
    public T? Value { get; set; }
    public string? Error { get; set; }
    public int Code { get; set; }

    public static Results<T> Success(T Value) => new() { IsSuccess = true, Value = Value };
    public static Results<T> Failure(string error, int code) => new()
    {
        IsSuccess = false,
        Error = error,
        Code = code
    };
}

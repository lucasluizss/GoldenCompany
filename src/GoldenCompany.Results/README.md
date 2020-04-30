# GoldenCompany

Nuget Packages

-## Results

For use Resultsyou must import __GoldenCompany.Results__.

```csharp
public interface IResult
{
    public bool Successed { get; }
    public bool Failed { get; }
    public string Message { get; }
}

public interface IResult<out T> : IResult
{
    public T Data { get; }
}
```

## Samples syncronous

```csharp
public class Samples
{
    public IResult SuccessSyncronousMethod() => Result.Success();

    public IResult SuccessWithMessageSyncronousMethod(string message) => Result.Success(message);

    public IResult<T> SuccessTypedSyncronousMethod<T>() => Result<T>.Success();

    public IResult<T> SuccessTypedWithObjectSyncronousMethod<T>(T data) => Result<T>.Success(data);

    public IResult<T> SuccessTypedWithObjectAndMessageSyncronousMethod<T>(T data, string message) => Result<T>.Success(data, message);

    public IResult<T> SuccessTypedWithMessageSyncronousMethod<T>(string message) => Result<T>.Success(message);

    public IResult FailWithMessageSyncronousMethod(string message) => Result.Fail(message);
        
    public IResult<T> FailTypedWithMessageSyncronousMethod<T>(string message) => Result<T>.Fail(message);
}
```

## Samples asyncronous

```csharp
public class Samples
{
    public Task<IResult> SuccessSyncronousMethod() => Result.SuccessAsync();

    public Task<IResult> SuccessWithMessageAsyncronousMethod(string message) => Result.SuccessAsync(message);

    public Task<IResult<T>> SuccessTypedAsyncronousMethod<T>() => Result<T>.SuccessAsync();

    public Task<IResult<T>> SuccessTypedWithObjectAsyncronousMethod<T>(T data) => Result<T>.SuccessAsync(data);
        
    public Task<IResult<T>> SuccessTypedWithObjectAndMessageAsyncronousMethod<T>(T data, string message) => Result<T>.SuccessAsync(data, message);

    public Task<IResult<T>> SuccessTypedWithMessageAsyncronousMethod<T>(string message) => Result<T>.SuccessAsync(message);
                
    public Task<IResult> FailWithMessageAsyncronousMethod(string message) => Result.FailAsync(message);
        
    public Task<IResult<T>> FailTypedWithMessageAsyncronousMethod<T>(string message) => Result<T>.FailAsync(message);
}
```

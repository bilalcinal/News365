namespace News365.Core.Utilities.Result;
public class ErrorDataResult<T> : DataResult<T>
{
	public ErrorDataResult(T data, string message)
		: base(data, success: false, message)
	{
	}

	public ErrorDataResult(T data)
		: base(data, success: false)
	{
	}

	public ErrorDataResult(string message)
		: base(default(T), success: false, message)
	{
	}

	public ErrorDataResult()
		: base(default(T), success: false)
	{
	}
}

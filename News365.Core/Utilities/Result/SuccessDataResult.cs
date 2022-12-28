namespace News365.Core.Utilities.Result;
public class SuccessDataResult<T> : DataResult<T>
{
	public SuccessDataResult(T data, string message)
		: base(data, success: true, message)
	{
	}

	public SuccessDataResult(T data)
		: base(data, success: true)
	{
	}

	public SuccessDataResult(string message)
		: base(default(T), success: true, message)
	{
	}

	public SuccessDataResult()
		: base(default(T), success: true)
	{
	}
}
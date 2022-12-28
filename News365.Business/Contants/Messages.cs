namespace News365.Business.Contants;
public static class Messages
{
	private static string addMessage = "Your save is successful.";
	private static string deleteMessage = "Your deletion is successful.";
	private static string updateMessage = "Your update process is complete.";
	private static string recordMessage = "No record";
	private static string imageSizeMessage = "The file must be a maximum of 1MB in size!";
	private static string errorMessage = "An unexpected error occurred";
	private static string userNotFound = "Email is not available in the system. Please try again";
	private static string succesfulLogin = "Sisteme giriş başarılı...";
	public static string AddMessage
	{
		get
		{
			return addMessage;
		}
		set
		{
			addMessage = value;
		}
	}

	public static string DeleteMessage
	{
		get
		{
			return deleteMessage;
		}
		set
		{
			deleteMessage = value;
		}
	}

	public static string UpdateMessage
	{
		get
		{
			return updateMessage;
		}
		set
		{
			updateMessage = value;
		}
	}
	public static string RecordMessage { get { return recordMessage; } set { recordMessage = value; } }
	public static string ImageSizeMessage { get { return imageSizeMessage; } set { imageSizeMessage = value; } }
	public static string ErrorMessage { get { return errorMessage; } set { errorMessage = value; } }
	public static string UserNotFound { get { return userNotFound; } set { userNotFound = value; } }
	public static string SuccesfulLogin { get { return succesfulLogin; } set { succesfulLogin = value; } }
}
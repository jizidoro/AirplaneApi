namespace AirplaneProject.CrossCutting.Security
{
	public class SecurityResult
	{
		public SecurityResult(User user)
		{
			this.User = user;
			this.Success = true;
		}

		public SecurityResult(int errorCode, string errorMessage)
		{
			this.ErrorCode = errorCode;
			this.ErrorMessage = errorMessage;
			this.Success = false;
		}

		public User User { get; set; }
		public bool Success { get; set; }
		public int ErrorCode { get; set; }
		public string ErrorMessage { get; set; }
	}
}

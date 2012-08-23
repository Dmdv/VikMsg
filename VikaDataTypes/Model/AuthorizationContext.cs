namespace Vk.Model
{
	public class AuthorizationContext : IEntity
	{
		public string CurrentUserId { get; set; }
		public string AccessToken { get; set; }
		//public int ExpiresInSeconds { get; set; }
		//public DateTime AuthroizationTime { get; set; }
		public string ApplicationId { get; set; }
	}
}
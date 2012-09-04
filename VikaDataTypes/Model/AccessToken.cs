using System.Runtime.Serialization;

namespace Vk.Model
{
	[DataContract(Name = "message")]
	public class AccessToken
	{
		[DataMember(Name = "access_token")]
		public string Token { get; set; }

		[DataMember(Name = "expires_in")]
		public long ExpiresIn { get; set; }

		[DataMember(Name = "user_id")]
		public long UserId { get; set; }
	}
}
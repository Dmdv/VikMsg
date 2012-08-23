using System.Runtime.Serialization;
using Vk.Interfaces;

namespace Vk.Serializables
{
	[DataContract]
	public class GetFriends : IServiceResult
	{
		[DataMember(Name = "response")]
		public string[] Result { get; set; }

		public string Error { get; set; }

		public bool ResponseIsSuccess()
		{
			return Result != null;
		}
	}
}
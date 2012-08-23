using System.Runtime.Serialization;
using Vk.Interfaces;

namespace Vk.Model
{
	[DataContract]
	public class ErrorResponse : IServiceResult
	{
		public string Error { get; set; }

		[DataMember(Name = "error")]
		public Error ErrorResult { get; set; }

		public bool ResponseIsSuccess()
		{
			return ErrorResult != null;
		}
	}
}
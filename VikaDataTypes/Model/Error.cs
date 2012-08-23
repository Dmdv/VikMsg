using System;
using System.Runtime.Serialization;

namespace Vk.Model
{
	[DataContract(Name = "error")]
	public class Error
	{
		[DataMember(Name = "error_code")]
		public string ErrorCode { get; set; }

		[DataMember(Name = "error_msg")]
		public string ErrorMsg { get; set; }

		[IgnoreDataMember]
		public Exception Exception { get; set; }
	}
}
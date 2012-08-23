using System;

namespace Vk.Exceptions
{
	public class VikaException : Exception
	{
		public VikaException()
		{
		}

		public VikaException(string message) : base(message)
		{
		}

		public VikaException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
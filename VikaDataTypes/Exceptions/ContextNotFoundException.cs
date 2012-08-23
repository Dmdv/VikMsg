using System;

namespace Vk.Exceptions
{
	public class ContextNotFoundException : VikaException
	{
		public ContextNotFoundException()
		{
		}

		public ContextNotFoundException(string message) : base(message)
		{
		}

		public ContextNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
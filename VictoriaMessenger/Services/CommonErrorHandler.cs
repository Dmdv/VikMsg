using Vk.Exceptions;
using Vk.Model;

namespace VictoriaMessenger.Services
{
	internal class CommonErrorHandler : ICommonErrorHandler
	{
		public bool HandleError(Error error)
		{
			if (error.Exception is ContextNotFoundException)
				NavigationService.GoToAuthorizationPage();
			return true;
		}
	}
}
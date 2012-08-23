using VictoriaMessenger.ViewModel;

namespace VictoriaMessenger
{
	public class VmLocator
	{
		private static AuthorizationVm _authorizationVm;

		public static AuthorizationVm AuthorizationVm
		{
			set { _authorizationVm = value; }
			get { return _authorizationVm ?? (_authorizationVm = new AuthorizationVm()); }
		}
	}
}
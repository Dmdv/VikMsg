using System;
using System.Windows;
using Microsoft.Phone.Controls;
using VictoriaMessenger.Commands;
using VikaApi;
using Vk.Model;

namespace VictoriaMessenger.ViewModel
{
	public class AuthorizationVm : BaseViewModel
	{
		// private const string AppId = "2416563";
		private DelegateCommand<string> _executeLogin;
		private string _login;
		private string _password;

		public AuthorizationVm()
		{
			_executeLogin = new DelegateCommand<string>(DoLogin, CanLogin);
			Login = "dimos-d@yandex.ru";
			Password = "167390080$Perple$";
		}

		public string Login
		{
			get { return _login; }
			set
			{
				_login = value;
				OnPropertyChanged("Login");
			}
		}

		public string Password
		{
			get { return _password; }
			set
			{
				_password = value;
				OnPropertyChanged("Password");
			}
		}

		[Obsolete]
		public Uri GetUri()
		{
			return new Uri(AuthorizationHelper.GetAuthorizationUrl("2416563"));
		}

		public static void ParseUri(Uri uri)
		{
			AuthorizationResult result = AuthorizationHelper.ParseNavigatedUrl(uri.ToString());
			if (result.Status == AuthorizationStatus.Success)
			{
				AuthorizationManager.SaveContext(result.Context);

				//(Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
				((PhoneApplicationFrame) Application.Current.RootVisual).GoBack();
			}
		}

		private void DoLogin(string obj)
		{
			var query = Authorization.Query(Login, Password);
		}

		private bool CanLogin(string arg)
		{
			return
				!string.IsNullOrEmpty(Login) &&
				!string.IsNullOrWhiteSpace(Login) &&
				!string.IsNullOrEmpty(Password) &&
				!string.IsNullOrWhiteSpace(Password);
		}
	}
}
using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Newtonsoft.Json;
using VictoriaMessenger.Commands;
using VictoriaMessenger.Networking;
using VikaApi;
using VikaApi.Storage;
using Vk.Model;

namespace VictoriaMessenger.ViewModel
{
	public class AuthorizationVm : BaseViewModel
	{
		private string _login;
		private string _password;

		public AuthorizationVm()
		{
			ExecuteLogin = new DelegateCommand<string>(DoLogin, CanLogin);
			Login = "dimos-d@yandex.ru";
			Password = "167390080$Perple";
		}

		public DelegateCommand<string> ExecuteLogin { get; set; }

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
			var client = new HttpClient(query);
			client.DownloadStringCompleted += OnDownloadStringCompleted;
			client.BeginDownloadString();
		}

		private void OnDownloadStringCompleted(object sender, DownloadEventArg e)
		{
			if (!e.Success)
			{
				Dispatcher.BeginInvoke(
					() => MessageBox.Show("Неправильный логин или пароль", "Ошибка авторизации", MessageBoxButton.OK));
				//((PhoneApplicationFrame)Application.Current.RootVisual).GoBack();
				return;
			}

			var token = JsonConvert.DeserializeObject<AccessToken>(e.Result);
			ITypedDataStorage<AccessToken> storage = new TypedStorage<AccessToken>();
			storage.SaveEntity(token);
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
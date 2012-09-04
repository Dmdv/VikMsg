using System;
using System.IO;
using System.Net;

namespace VictoriaMessenger.Networking
{
	public class HttpClient
	{
		private HttpWebRequest _httpWebRequest;

		public HttpClient(string uri)
		{
			CreateRequest(uri);
		}

		public HttpClient(Uri uri)
		{
			CreateRequest(uri);
		}

		public event EventHandler<DownloadEventArg> DownloadStringCompleted;

		public void OnDownloadStringCompleted(DownloadEventArg e)
		{
			var handler = DownloadStringCompleted;
			if (handler != null) handler(this, e);
		}

		public void BeginDownloadString()
		{
			_httpWebRequest.BeginGetResponse(OnRequestCompleted, _httpWebRequest);
		}

		private void CreateRequest(string uri)
		{
			_httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
			InitRequest();
		}

		private void CreateRequest(Uri uri)
		{
			_httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
			InitRequest();
		}

		private void InitRequest()
		{
			_httpWebRequest.Method = "GET";
			_httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;*/*";
			_httpWebRequest.UserAgent = "Vkontakte messenger/1.0";
		}

		private void OnRequestCompleted(IAsyncResult ar)
		{
			var httpWebRequest = (HttpWebRequest) ar.AsyncState;
			WebResponse response;
			try
			{
				response = httpWebRequest.EndGetResponse(ar);
			}
			catch (Exception ex)
			{
				OnDownloadStringCompleted(new DownloadEventArg(ex.Message, false));
				return;
			}

			using (var reader = new StreamReader(response.GetResponseStream()))
			{
				OnDownloadStringCompleted(new DownloadEventArg(reader.ReadToEnd()));
			}
		}
	}
}
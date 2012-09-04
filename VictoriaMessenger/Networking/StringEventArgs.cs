using System;

namespace VictoriaMessenger.Networking
{
	public class DownloadEventArg : EventArgs
	{
		public DownloadEventArg(string result, bool success = true)
		{
			Result = result;
			Success = success;
		}

		public string Result { get; set; }

		public bool Success { get; set; }
	}
}
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VikaApi
{
	public static class Authorization
	{
		private const string Path = "https://api.vk.com/oauth/token?";
		private static readonly Dictionary<string, string> _params;

		static Authorization()
		{
			_params = new Dictionary<string, string>
			{
			    {"grant_type", "password"},
			    {"client_id", "3071350"},
			    {"client_secret", "ESudqlw1ZLBed6NRuI1N"},
			    {"username", string.Empty},
			    {"password", "string.Empty"},
			    {"scope", "notify,friends,photos,audio,video,docs,notes,pages,wall,messages,notifications"}
			};
		}

		public static string Query(string username, string password)
		{
			_params["username"] = username;
			_params["password"] = password;

			return _params.Aggregate(new StringBuilder(Path),
			                         (res, pair) => res.AppendFormat(@"{0}={1}&", pair.Key, pair.Value),
			                         x => x.Remove(x.Length - 1, 1).ToString());
		}
	}
}
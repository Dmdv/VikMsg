using System;
using System.Collections.Generic;
using System.Linq;
using Vk.Model;

namespace VikaApi
{
	public static class AuthorizationHelper
    {
        private const string RedirectUrl = "http://api.vkontakte.ru/blank.html";

		[Obsolete]
        public static string GetAuthorizationUrl(string applicationId)
        {

            const string Url = "http://api.vkontakte.ru/oauth/authorize?client_id={0}&" + "scope=notify,friends,photos,audio,video,docs,notes,pages,offers,questions,wall,messages&" + "redirect_uri={1}&" + "display=touch&" + "response_type=token";
            return String.Format(Url, applicationId, RedirectUrl);
        }

        public static AuthorizationResult ParseNavigatedUrl(string url)
        {
            if (url.StartsWith(RedirectUrl) && url.Length > RedirectUrl.Length)
            {
                string tokenData = GetToken(url);
                Dictionary<string, string> tokenArray = GetTokenArray(tokenData);

                AuthorizationResult authorizationResult = GetAuthResult(tokenArray);
                return authorizationResult;
            }

            return new AuthorizationResult {Status = AuthorizationStatus.Unknown};
        }

        private static AuthorizationResult GetAuthResult(Dictionary<string, string> tokenArray)
        {
            var authorizationResult = new AuthorizationResult();

            if (tokenArray.ContainsKey("error"))
            {
                authorizationResult.Status = AuthorizationStatus.Error;
                authorizationResult.Description = tokenArray[tokenArray["error"]];
            }
            else
            {
                authorizationResult.Status = AuthorizationStatus.Success;
                authorizationResult.Description = "success";
                authorizationResult.Context = new AuthorizationContext
                                                  {
                                                      AccessToken = tokenArray["access_token"],
                                                      CurrentUserId = tokenArray["user_id"],
                                                  };
            }
            return authorizationResult;
        }

        private static string GetToken(string url)
        {
            return url.Substring(RedirectUrl.Length + 1);
        }

        private static Dictionary<string, string> GetTokenArray(string tokenData)
        {
            var result = new Dictionary<string, string>();
            string[] keyValuePairs = tokenData.Split(new[] {'&'}, StringSplitOptions.RemoveEmptyEntries);

            List<string[]> splitedKeyValuePairs =
                keyValuePairs.Select(i => i.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries)).ToList();

            splitedKeyValuePairs.ForEach(j => result.Add(j[0], j[1]));

            return result;
        }
    }
}
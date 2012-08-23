using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Vk.Interfaces;
using Vk.Model;
using VkontakteServiceLayer.Tools;

namespace VikaApi
{
    internal class RequestBuilder
    {
        private readonly AuthorizationContext _context;
        private readonly Dictionary<string, string> _keyValuePair;
        private string _apiMethodName;

        public RequestBuilder(AuthorizationContext context)
        {
            _context = context;
            _keyValuePair = new Dictionary<string, string>();
            _apiMethodName = String.Empty;
        }

        public void SetMethod(string methodName)
        {
            _apiMethodName = methodName;
        }

        public void AddParam(string key, string value)
        {
            _keyValuePair.Add(key, value);
        }

        private string GetRequestUrl()
        {
            _keyValuePair.Add("access_token", _context.AccessToken);

            var sb = new StringBuilder();
            bool firstKey = true;
            foreach (string key in _keyValuePair.Keys)
            {
                if (firstKey)
                {
                    sb.Append("?");
                    firstKey = false;
                }
                else
                {
                    sb.Append("&");
                }

                sb.Append(key);
                sb.Append("=");
                sb.Append(_keyValuePair[key]);
            }

            const string Template = "https://api.vkontakte.ru/method/{0}{1}";
            string url = String.Format(Template, _apiMethodName, sb);
            return url;
        }

        public void SendRequest<T>(Action<T> actionResult, Action<Error> errorAction) where T : IServiceResult, new()
        {
            var client = new WebClient();
            client.OpenReadCompleted += (sender, e) =>
                                            {
                                                T response = new JsonSerializer<T>().Deserialize(e.Result);
                                                if (!response.ResponseIsSuccess())
                                                {
                                                    e.Result.Position = 0;
                                                    ErrorResponse errorResponse =
                                                        new JsonSerializer<ErrorResponse>().Deserialize(e.Result);
                                                    if (errorResponse.ResponseIsSuccess())
                                                    {
                                                        errorAction.Invoke(errorResponse.ErrorResult);
                                                    }
                                                    errorAction.Invoke(new Error {ErrorMsg = "Unknown error"});
                                                }
                                                else
                                                {
                                                    actionResult.Invoke(response);
                                                }
                                            };

            client.OpenReadAsync(new Uri(GetRequestUrl()));
        }
    }
}
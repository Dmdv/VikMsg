using System;
using System.Collections.Generic;
using System.Linq;
using Vk.Model;
using Vk.Serializables;
using Message = Vk.Model.Message;

namespace VikaApi
{
	/// <summary>
	/// Api service proxy.
	/// </summary>
	public static class ServiceProxy //: IVkontakteApi
	{
		public static void GetFriends(Action<List<User>> getFriendsAction, Action<Error> errorAction)
		{
			var requestBuilder = new RequestBuilder(Context);
			requestBuilder.SetMethod("friends.get");
			requestBuilder.AddParam("uid", Context.CurrentUserId);
			requestBuilder.SendRequest<GetFriends>(
				getFriendsResponse => GetProfiles(getFriendsResponse.Result, getFriendsAction, errorAction), errorAction);
		}

		public static void GetCurrentUserProfile(Action<User> getUser, Action<Error> errorAction)
		{
			GetProfiles(new[] { Context.CurrentUserId }, listResult => getUser.Invoke(listResult.First()), errorAction);
		}

		public static void GetUserProfile(string uid, Action<User> getUser, Action<Error> errorAction)
		{
			GetProfiles(new[] {uid}, resultList => getUser.Invoke(resultList.First()), errorAction);
		}

		public static void GetUserProfiles(List<string> uids, Action<List<User>> getUsers, Action<Error> errorAction)
		{
			GetProfiles(uids.ToArray(), getUsers, errorAction);
		}

		public static void GetProfiles(string[] profileUids, Action<List<User>> getProfilesAction, Action<Error> errorAction)
		{
			var requestBuilder = new RequestBuilder(Context);
			requestBuilder.SetMethod("getProfiles");
			requestBuilder.AddParam("uids", String.Join(",", profileUids));
			requestBuilder.AddParam("fields",
			                        "uid, first_name, last_name, nickname, domain, sex, " +
			                        "bdate, city, country, timezone, photo, photo_medium, " +
			                        "photo_big, has_mobile, rate, contacts, education, online");

			requestBuilder.SendRequest<GetProfiles>(
				getProfilesResponse => getProfilesAction.Invoke(getProfilesResponse.Result.GetUserItems()), errorAction);
		}

		public static void GetMessages(Action<List<Message>> getMessagesAction, Action<Error> errorAction)
		{
			var requestBuilder = new RequestBuilder(Context);
			requestBuilder.SetMethod("messages.getDialogs");
			requestBuilder.AddParam("count", "100");
			requestBuilder.SendRequest<GetMessages>(
				getMessagesResult => getMessagesAction.Invoke(getMessagesResult.Messages.ToList().GetMessageItems()), errorAction);
		}

		public static void GetMessageConversation(string uid, Action<List<Message>> getMessagesAction, Action<Error> errorAction)
		{
			var requestBuilder = new RequestBuilder(Context);
			requestBuilder.SetMethod("messages.getHistory");
			requestBuilder.AddParam("uid", uid);
			requestBuilder.SendRequest<GetMessagesHistory>(
				getMessagesResult =>
				getMessagesAction.Invoke(getMessagesResult.Messages.ToList().GetMessageItems(Context.CurrentUserId)),
				errorAction);
		}

		public static void SendMessage(string uid, string textmessage, Action sendMessageCompleteAction,
		                        Action<Error> errorAction)
		{
			var requestBuilder = new RequestBuilder(Context);
			requestBuilder.SetMethod("messages.send");
			requestBuilder.AddParam("uid", uid);
			requestBuilder.AddParam("message", textmessage);
			requestBuilder.SendRequest<SendMessageResult>(result => sendMessageCompleteAction.Invoke(), errorAction);
		}

		private static AuthorizationContext Context
		{
			get { return AuthorizationManager.Context; }
		}
	}
}
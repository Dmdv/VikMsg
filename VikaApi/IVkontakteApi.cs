using System;
using System.Collections.Generic;
using Vk.Model;

namespace VikaApi
{
	/// <summary>
	/// Api interface.
	/// </summary>
	public interface IVkontakteApi
    {
		/// <summary>
		/// Returns friends.
		/// </summary>
		/// <param name="getFriendsAction"></param>
		/// <param name="errorAction"></param>
        void GetFriends(Action<List<User>> getFriendsAction, Action<Error> errorAction);

		/// <summary>
		/// Returns current user.
		/// </summary>
		/// <param name="getUser"></param>
		/// <param name="errorAction"></param>
        void GetCurrentUserProfile(Action<User> getUser, Action<Error> errorAction);

		/// <summary>
		/// Return user by id.
		/// </summary>
		/// <param name="uid"></param>
		/// <param name="getUser"></param>
		/// <param name="errorAction"></param>
        void GetUserProfile(string uid, Action<User> getUser, Action<Error> errorAction);

		/// <summary>
		/// Returns users by ids.
		/// </summary>
		/// <param name="uids"></param>
		/// <param name="getUsers"></param>
		/// <param name="errorAction"></param>
        void GetUserProfiles(List<String> uids, Action<List<User>> getUsers, Action<Error> errorAction);

		/// <summary>
		/// Returns messages.
		/// </summary>
		/// <param name="getListMessagesAction"></param>
		/// <param name="errorAction"></param>
        void GetMessages(Action<List<Message>> getListMessagesAction, Action<Error> errorAction);

		/// <summary>
		/// Returns conversations.
		/// </summary>
		/// <param name="uid"></param>
		/// <param name="messages"></param>
		/// <param name="errorAction"></param>
        void GetMessageConversation(string uid, Action<List<Message>> messages, Action<Error> errorAction);

		/// <summary>
		/// Send messages.
		/// </summary>
		/// <param name="uid"></param>
		/// <param name="textmessage"></param>
		/// <param name="sendMessageCompleteAction"></param>
		/// <param name="errorAction"></param>
        void SendMessage(string uid, string textmessage, Action sendMessageCompleteAction, Action<Error> errorAction);
    }
}
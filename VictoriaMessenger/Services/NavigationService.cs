using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace VictoriaMessenger.Services
{
    public static class NavigationService
    {
        private static PhoneApplicationFrame PhoneApplicationFrame
        {
            get { return (Application.Current.RootVisual as PhoneApplicationFrame); }
        }

        public static void GoToAuthorizationPage()
        {
            NavigateTo("/AuthorizationPage.xaml");
        }

        public static void GoToProfilePage(string uid)
        {
            NavigateTo("/ProfilePage.xaml?uid=" + uid);
        }

        public static void GoToHomePage()
        {
            NavigateTo("/HomePage.xaml");
        }

        public static void NavigateToMessageConversationPage(string uid)
        {
            NavigateTo(String.Format("/MessageConversationPage.xaml?uid={0}", uid));
        }

        public static void NavigateToMessagesPage()
        {
            NavigateTo("/MessagesPage.xaml");
        }

        public static void NavigateToFriendsPage()
        {
            NavigateTo("/FriendsPage.xaml");
        }

        private static void NavigateTo(string urlTemplate, params object[] values)
        {
            var url = String.Format(urlTemplate, values);
            PhoneApplicationFrame.Navigate(new Uri(url, UriKind.Relative));
        }
    }
}
using System.ComponentModel;
using VictoriaMessenger.Resources;

namespace VictoriaMessenger.Helpers
{
	public class Resource
	{
		public static string Messages
		{
			get { return IsInDesignMode ? "Сообщения" : AppResource.Messages; }
		}

		public static string Password
		{
			get { return IsInDesignMode ? "Пароль" : AppResource.Password; }
		}

		public static string Login1
		{
			get { return IsInDesignMode ? "Номер телефона, логин или email" : AppResource.Login1; }
		}

		private static bool IsInDesignMode
		{
			get { return DesignerProperties.IsInDesignTool; }
		}
	}
}
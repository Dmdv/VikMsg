using VikaApi.Storage;
using Vk.Exceptions;
using Vk.Model;

namespace VikaApi
{
	/// <summary>
	/// Manages authorization.
	/// </summary>
	public static class AuthorizationManager
	{
		// TODO: Синхронизация при сохранении и чтении.
		private static readonly ITypedDataStorage<AuthorizationContext> _storage =
			new TypedStorage<AuthorizationContext>();

		private static AuthorizationContext _context;

		public static bool IsAuthorized
		{
			get { return _storage.LoadEntity() != null; }
		}

		public static AuthorizationContext Context
		{
			get { return _context ?? (_context = _storage.LoadEntity()); }
		}

		public static string CurrentUid
		{
			get { return Context.CurrentUserId; }
		}

		public static void SaveContext(AuthorizationContext context)
		{
			_context = context;
			_storage.SaveEntity(context);
		}

		public static void DeleteContext()
		{
			_context = null;
			_storage.DeleteEntity();
		}

		public static void Reload()
		{
			_context = _storage.LoadEntity();
		}
	}
}
using VictoriaMessenger.Services;
using VikaApi.Storage;

namespace VictoriaMessenger.Helpers
{
	/// <summary>
	/// Factory for appication services. A substitute for heavy IoC containers.
	/// </summary>
	public static class Factory
	{
		private static readonly IEntityDataStorage _entityStorage = new EntityStorage();

		public static IEntityDataStorage Storage
		{
			get { return _entityStorage; }
		}

		public static ICommonErrorHandler CreateCommonErrorHandler()
		{
			return new CommonErrorHandler();
		}
	}
}
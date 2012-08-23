namespace VikaApi.Storage
{
	/// <summary>
	/// Storage.
	/// </summary>
	public interface IEntityDataStorage
	{
		void SaveEntity<T>(T entity);

		T LoadEntity<T>();

		void DeleteEntity<T1>();
	}
}
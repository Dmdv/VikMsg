namespace VikaApi.Storage
{
	/// <summary>
	/// Storage.
	/// </summary>
	public interface ITypedDataStorage<T>
	{
		void SaveEntity(T entity);

		T LoadEntity();

		void DeleteEntity();
	}
}
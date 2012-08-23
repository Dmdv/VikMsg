using System.IO.IsolatedStorage;

namespace VikaApi.Storage
{
	/// <summary>
	/// Generic storage that is created many times and per the only T.
	/// </summary>
	/// <typeparam name="T">Type of persistent object.</typeparam>
	public sealed class TypedStorage<T> : ITypedDataStorage<T>
	{
		private readonly string _fullkey = typeof (T).FullName;

		void ITypedDataStorage<T>.SaveEntity(T item)
		{
			IsolatedStorageSettings.ApplicationSettings[_fullkey] = item;
			IsolatedStorageSettings.ApplicationSettings.Save();
		}

		T ITypedDataStorage<T>.LoadEntity()
		{
			if (IsolatedStorageSettings.ApplicationSettings.Contains(_fullkey))
			{
				return (T) IsolatedStorageSettings.ApplicationSettings[_fullkey];
			}
			return default(T);
		}

		void ITypedDataStorage<T>.DeleteEntity()
		{
			if (IsolatedStorageSettings.ApplicationSettings.Contains(_fullkey))
			{
				IsolatedStorageSettings.ApplicationSettings.Remove(_fullkey);
			}
		}
	}
}
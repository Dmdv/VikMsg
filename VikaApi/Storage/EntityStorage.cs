using System;
using System.IO.IsolatedStorage;
using System.Reflection;

namespace VikaApi.Storage
{
	public class EntityStorage : IEntityDataStorage
	{
		private readonly string _key;

		public EntityStorage()
		{
			_key = String.Empty;
		}

		public EntityStorage(string key)
		{
			_key = key;
		}

		public void SaveEntity<T>(T item)
		{
			var fullKey = GetFullKey(typeof (T));
			IsolatedStorageSettings.ApplicationSettings[fullKey] = item;
			IsolatedStorageSettings.ApplicationSettings.Save();
		}

		public T LoadEntity<T>()
		{
			var fullKey = GetFullKey(typeof (T));

			if (IsolatedStorageSettings.ApplicationSettings.Contains(fullKey))
			{
				return (T) IsolatedStorageSettings.ApplicationSettings[fullKey];
			}
			return default(T);
		}

		public void DeleteEntity<T>()
		{
			var fullKey = GetFullKey(typeof (T));
			if (IsolatedStorageSettings.ApplicationSettings.Contains(fullKey))
			{
				IsolatedStorageSettings.ApplicationSettings.Remove(fullKey);
			}
		}

		private string GetFullKey(MemberInfo t)
		{
			return t.Name + "_key_" + _key;
		}
	}
}
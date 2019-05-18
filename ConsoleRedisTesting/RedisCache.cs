using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace ConsoleRedisTesting
{
	public class RedisCache : BaseConnectionRedis, ICache
	{
		private readonly IDatabase _db;

		public RedisCache()
		{
			_db = Connection.GetDatabase();
		}

		public void Delete(string key)
		=> _db.KeyDelete(key);

		public bool Exists(string key)
		=> _db.KeyExists(key);

		public T Get<T>(string key)
		=> _db.StringGet(key).HasValue ? JsonConvert.DeserializeObject<T>(_db.StringGet(key)) : Activator.CreateInstance<T>();

		public bool Rename(string oldKey, string newKey)
		=> _db.KeyRename(oldKey, newKey);

		public void Set<T>(string key, T obj, DateTime expireDate)
		=> _db.StringSet(key, JsonConvert.SerializeObject(obj), expireDate.Subtract(DateTime.Now));

		public long SetLeftList<T>(string key, List<T> keys)
		{
			foreach (T item in keys)
				_db.ListLeftPush(key, JsonConvert.SerializeObject(item));
			return 0;
		}

	}
}

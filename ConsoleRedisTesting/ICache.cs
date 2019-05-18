using System;
using System.Collections.Generic;

namespace ConsoleRedisTesting
{
	public interface ICache
	{
		T Get<T>(string key);
		void Set<T>(string key, T obj, DateTime expireDate);
		long SetLeftList<T>(string key, List<T> keys);
		void Delete(string key);
		bool Exists(string key);
		bool Rename(string oldKey, string newKey);
		// And Other Properties...
	}
}

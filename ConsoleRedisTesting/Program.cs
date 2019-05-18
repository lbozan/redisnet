using System;
using System.Collections.Generic;

namespace ConsoleRedisTesting
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("World Hello  <:<>");

			ICache cacheDb = new RedisCache();
			string key = "key";

			var person = new PersonModel()
			{
				FullName = "Dev Labs",
				Age = 25,
				Email = "dev@labs.com"
			};
			cacheDb.Set(key, person, DateTime.Now.AddMinutes(2));

			if (cacheDb.Exists(key))
				Console.WriteLine(cacheDb.Get<PersonModel>(key).ToString());

			// update cache
			person.Age = 30;
			cacheDb.Set(key, person, DateTime.Now.AddMinutes(3));

			Console.WriteLine(cacheDb.Get<PersonModel>(key).ToString());

			string newKey = "keyN";
			cacheDb.Rename(key, newKey);
			Console.WriteLine(cacheDb.Get<PersonModel>(newKey).ToString());

			var perList = new List<PersonModel>()
			{
				new PersonModel() { FullName = "First Name" },
				new PersonModel() { FullName = "Secondy Name" }
			};
			//var perFirst = new PersonModel() { FullName = "First Name" };
			string listkey = "list_key";
			cacheDb.SetLeftList(listkey, perList);


			Console.ReadLine();
		}
	}
}

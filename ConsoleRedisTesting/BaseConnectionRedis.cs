using StackExchange.Redis;
using System;

namespace ConsoleRedisTesting
{
	public abstract class BaseConnectionRedis
	{
		static readonly Lazy<ConnectionMultiplexer> cnn;
		static BaseConnectionRedis()
		{
			cnn = new Lazy<ConnectionMultiplexer>(() =>
			{
				return ConnectionMultiplexer.Connect("localhost:6379");
			});
		}
		public static ConnectionMultiplexer Connection => cnn.Value;

		public static void DisposeConnection()
		{
			if (cnn.Value.IsConnected)
				cnn.Value.Dispose();
		}
	}
}

namespace ConsoleRedisTesting
{
	public class PersonModel
	{
		public string FullName { get; set; }
		public int Age { get; set; }
		public string Email { get; set; }

		public override string ToString()
		=> $"Full Name: {FullName} - Email: {Email} - Age: {Age}";
	}
}

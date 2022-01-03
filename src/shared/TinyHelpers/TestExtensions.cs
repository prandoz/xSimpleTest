using Bogus;

namespace TinyHelpers;

public static class TestExtensions
{
	public static T GetRandomData<T>(this T data) where T : new()
	{
		var faker = new Faker();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
		data.GetType().GetProperties().ToList().ForEach(p => data.GetType().GetProperty(p.Name).SetValue(data, _GetValue(p.PropertyType)));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

		return data;
	}

	public static T GetRandomDataOnlyRequired<T>(this T data) where T : new()
	{
		var faker = new Faker();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
		data.GetType().GetProperties().Where(p => !p.PropertyType.Name.Contains("Nullable")).ToList()
			.ForEach(p => data.GetType().GetProperty(p.Name).SetValue(data, _GetValue(p.PropertyType)));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

		return data;
	}

	private static object _GetValue(Type type)
	{
		var faker = new Faker();

		return type == typeof(bool) || type == typeof(bool?) ? faker.Random.Bool()
			: type == typeof(decimal) || type == typeof(decimal?) ? faker.Random.Decimal()
			: type == typeof(float) || type == typeof(float?) ? faker.Random.Float()
			: type == typeof(int) || type == typeof(int?) ? faker.Random.Int()
			: type == typeof(string) ? faker.Random.String()
			: new object();
	}
}

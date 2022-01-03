namespace TinyHelpers;
public static class ModelExtensions
{
	public static T GetWithoutNotRequiredValue<T>(this T data) where T : new()
	{
		var result = new T();

		result.GetType().GetProperties().Where(p => !p.PropertyType.Name.Contains("Nullable")).ToList()
#pragma warning disable CS8602 // Dereference of a possibly null reference.
				.ForEach(p => result.GetType().GetProperty(p.Name).SetValue(result, p.GetValue(data)));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

		return result;
	}

	public static bool AreEquals<T, L>(this T data, L compareData) where T : new()
	{
		var result = true;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

		var propertiesToCompare = compareData.GetType().GetProperties();

		foreach (var property in data.GetType().GetProperties())
		{
			if (propertiesToCompare.Any(p => p.Name == property.Name && p.PropertyType.Name == property.PropertyType.Name))
			{
				var dataValue = data.GetType().GetProperty(property.Name).GetValue(data, null);
				var compareDataValue = compareData.GetType().GetProperty(property.Name).GetValue(compareData, null);

				result = (dataValue == null && compareDataValue == null)
						|| data.GetType().GetProperty(property.Name).GetValue(data, null).Equals(compareData.GetType().GetProperty(property.Name).GetValue(compareData, null));
			}
			else
			{
				result = false;
			}

			if (!result)
			{
				break;
			}
		}

#pragma warning restore CS8602 // Dereference of a possibly null reference.

		return result;
	}
}

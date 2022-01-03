using System.Linq;
using Applications.Models;
using TinyHelpers;
using Xunit;

namespace Tests;

public class UnitTest
{
	[Fact]
	public void TestReturnWithoutNotRequiredValue()
	{
		var inputData = new ModelData().GetRandomData();
		var result = Applications.Functions.ReturnWithoutNotRequiredValue(inputData);

		Assert.NotNull(result);
		Assert.True(result.AreEquals(_GetWithoutNotRequiredValue(inputData)));
	}

	private static ModelData _GetWithoutNotRequiredValue(ModelData modelData)
	{
		var resultModelData = new ModelData();

		resultModelData.GetType().GetProperties().Where(p => !p.Name.Contains("NotRequired")).ToList()
#pragma warning disable CS8602 // Dereference of a possibly null reference.
				.ForEach(p => resultModelData.GetType().GetProperty(p.Name).SetValue(resultModelData, p.GetValue(modelData)));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

		return resultModelData;
	}

	[Fact]
	public void TestReturnWithNotRequiredValue()
	{
		var inputData = new ModelData().GetRandomData();
		var result = Applications.Functions.ReturnWithNotRequiredValue(inputData);

		Assert.NotNull(result);
		Assert.True(result.AreEquals(inputData));
	}
}
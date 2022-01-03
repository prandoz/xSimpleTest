using Applications.Models;
using TinyHelpers;

namespace Applications;
public class Functions
{
	public static ModelData ReturnWithoutNotRequiredValue(ModelData inputModel)
	{
		return inputModel.GetWithoutNotRequiredValue();
	}

	public static ModelData ReturnWithNotRequiredValue(ModelData inputModel)
	{
		return inputModel;
	}
}

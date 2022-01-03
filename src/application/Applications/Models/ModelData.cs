namespace Applications.Models;

public class ModelData
{
	public bool boolValueRequired { get; set; }
	public bool? boolValueNotRequired { get; set; }
	public decimal decimalValueRequired { get; set; }
	public decimal? decimalValueNotRequired { get; set; }
	public float floatValueRequired { get; set; }
	public float? floatValueNotRequired { get; set; }
	public int intValueRequired { get; set; }
	public int? intValueNotRequired { get; set; }
	public string stringValueRequired { get; set; } = string.Empty;
}

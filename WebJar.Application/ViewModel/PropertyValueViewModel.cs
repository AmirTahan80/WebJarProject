namespace WebJar.Application.ViewModel
{
    public record class PropertyValueViewModel(string Value, float Price,
        string PriceType = "CONSTANT");
}

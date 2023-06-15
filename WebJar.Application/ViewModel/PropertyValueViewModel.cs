namespace WebJar.Application.ViewModel
{
    public record class PropertyValueViewModel(string Value, decimal Price,
        string PriceType = "CONSTANT");
}

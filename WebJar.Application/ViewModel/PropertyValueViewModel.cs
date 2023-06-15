namespace WebJar.Application.ViewModel
{
    public record class PropertyValueViewModel(string Value, long Price,
        string PriceType = "CONSTANT");
}

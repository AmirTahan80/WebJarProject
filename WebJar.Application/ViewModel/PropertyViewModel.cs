namespace WebJar.Application.ViewModel
{
    public record class PropertyViewModel(string Name,
        IEnumerable<PropertyValueViewModel> PropertyValueViewModels);
}

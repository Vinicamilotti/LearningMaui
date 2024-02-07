using HelloWorld.ViewModels;

namespace HelloWorld;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
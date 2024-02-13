
using HelloTux.ViewModel;
namespace HelloTux;


public partial class  Details: ContentPage
{

	public Details(DetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}


}


using HelloTux.Model;

namespace HelloTux.ViewModel;

[QueryProperty(nameof(Monkey), "Monkey")]
public partial class DetailsViewModel : BaseViewModel
{
    public DetailsViewModel()
    {

    }
    Monkey monkey;
    public Monkey Monkey { 
        get => monkey; 
        set 
        { 
            monkey = value; 
            OnPropertyChanged();
        }
    }
}
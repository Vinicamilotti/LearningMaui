using System.Diagnostics;
using HelloTux.Model;

namespace HelloTux.ViewModel;

[QueryProperty(nameof(Monkey), "Monkey")]
public partial class DetailsViewModel : BaseViewModel
{
    IMap map;
    public Command OpenMapCommand { get; }
    public DetailsViewModel(IMap map)
    {
        this.map = map;
        OpenMapCommand = new Command(async () => await OpenMap());
    }
    Monkey monkey;
    public Monkey Monkey
    {
        get => monkey;
        set
        {
            monkey = value;
            OnPropertyChanged();
        }
    }

    async Task OpenMap()
    {
        try
        {
            await map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions
            {
                Name = Monkey.Name,
                NavigationMode = NavigationMode.None
            }
            );

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to launch maps: {ex.Message}");
            await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
        }

    }
}


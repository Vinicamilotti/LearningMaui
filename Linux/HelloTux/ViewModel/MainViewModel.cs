
using System.Collections.ObjectModel;
using System.Diagnostics;
using HelloTux.Model;
using HelloTux.Services;
namespace HelloTux.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    bool isRefreshing;

    MonkeyService monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public bool IsRefreshing
    {
        get => isRefreshing;
        set
        {
            isRefreshing = value;
            OnPropertyChanged();
        }

    }
    IConnectivity conn;
    IGeolocation geolocation;

    public Command GetMonkeysCommand { get; }
    public Command GoToDetailsCommand { get; }

    public Command GetClosetsMonkeyCommand { get; }

    public MainViewModel(MonkeyService monkeyService, IConnectivity conn, IGeolocation geolocation)
    {
        Title = "Monkey";
        this.monkeyService = monkeyService;
        GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
        GoToDetailsCommand = new Command<Monkey>(async (monkey) => await GoToDetailsAsync(monkey));
        GetClosetsMonkeyCommand = new Command(async () => await GetClosetsMonkey());
        this.conn = conn;
        this.geolocation = geolocation;

    }
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();
            if (conn.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Missing Connection", $"Please check your connection and try again", "Ok");
                return;
            }
            if (Monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }
    async Task GoToDetailsAsync(Monkey monkey)
    {
        await Shell.Current.GoToAsync(nameof(Details), true, new Dictionary<string, object>
              {
                {"Monkey", monkey},
              }
      );
    }
    async Task GetClosetsMonkey()
    {
        if (IsBusy || Monkeys.Count == 0) return;

        try
        {
            var location = await geolocation.GetLastKnownLocationAsync();

            if (location == null)
            {
                location = await geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)

                });
            }
            var first = Monkeys.OrderBy(m =>
                location.CalculateDistance(new Location(m.Latitude, m.Longitude), DistanceUnits.Kilometers)).FirstOrDefault();
            await Shell.Current.GoToAsync(nameof(Details), new Dictionary<string, object>
            {
                { "Monkey", first }
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to query location: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }


    }

}



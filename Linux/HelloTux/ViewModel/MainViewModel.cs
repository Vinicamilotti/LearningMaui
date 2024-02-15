
using System.Collections.ObjectModel;
using System.Diagnostics;
using HelloTux.Model;
using HelloTux.Services;
namespace HelloTux.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    public ObservableCollection<Monkey> Monkeys { get; } = new();


    public Command GetMonkeysCommand { get; }
    public Command GoToDetailsCommand { get; }
    MonkeyService monkeyService;

    public MainViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey";
        this.monkeyService = monkeyService;
        GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
        GoToDetailsCommand = new Command<Monkey>(async (monkey) => await GoToDetailsAsync(monkey));
    }
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();

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

}


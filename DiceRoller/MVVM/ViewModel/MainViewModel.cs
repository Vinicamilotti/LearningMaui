using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiceRoller.MVVM.Model;

namespace DiceRoller.MVVM.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        DicePool pool;
        [ObservableProperty]
        int diceQnt;
        [ObservableProperty]
        int diceType;
        [ObservableProperty]
        string modType = "";
        [ObservableProperty]
        string modValue = "";
        [ObservableProperty]
        int result;


        [RelayCommand]
        public void Roll()
        {
            int parseMod;
            try
            {
                parseMod = Int32.Parse(ModValue);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                parseMod = 0;
            }
            Pool = new();
            Pool.DiceQnt = DiceQnt;
            Pool.DiceType = DiceType;
            Pool.ModType = ModType;
            Pool.ModValue = parseMod;
            Pool.RollPool();
            Result = (int)Pool.Results.FinalResult;

        }
        [RelayCommand]
        public void AddDice()
        {
            DiceQnt++;
        }
        [RelayCommand]
        public void RemoveDice()
        {
            if (DiceQnt <= 1)
            {
                return;
            }
            DiceQnt--;
        }
        [RelayCommand]
        async Task GoToRolls()
        {
            if (Pool.Results.Rolls.Count < 1)
            { return; }
            await Shell.Current.GoToAsync(nameof(Details), new Dictionary<string, object>
            {
                {"Pool", Pool },
            });
        }
    }
}

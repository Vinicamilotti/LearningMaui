using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiceRoller.Model;

namespace DiceRoller.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Roll> rolls;
        [ObservableProperty]
        int diceQnt;
        [ObservableProperty]
        int diceType;
        [ObservableProperty]
        string modType;
        [ObservableProperty]
        string modValue;
        [ObservableProperty]
        int result;



        public MainViewModel()
        {
            diceType = 20;
            diceQnt = 1;
            modType = "+";
            modValue = "0";
        }

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
            DicePool pool = new(DiceType, DiceQnt, ModType, parseMod);
            pool.RollPool();
            Result = (int)pool.Results.FinalResult;
            Rolls = pool.Results.Rolls;

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
            if (Rolls.Count < 1)
            { return; }
            await Shell.Current.GoToAsync($"{nameof(Details)}?rollList={Rolls}");
        }
    }
}

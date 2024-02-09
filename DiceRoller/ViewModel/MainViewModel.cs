using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DiceRoller.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Roll> rolls = [];
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
            DicePool pool = new(DiceType, DiceQnt, ModType, parseMod);
            pool.RollPool();
            Result = (int)pool.Results.FinalResult;
            Rolls = new(pool.Results.Rolls);

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
            await Shell.Current.GoToAsync(nameof(Details), new Dictionary<string, object>
            {
                {"RollList", Rolls },
                {"Result", Result},
                {"DiceType",DiceType},
                {"DiceQnt", DiceQnt},
                {"ModType", ModType },
                {"ModValue", ModValue},
            });
        }
    }
}

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DiceRoller.ViewModel
{

    [QueryProperty("RollList", "RollList")]
    [QueryProperty("Result", "Result")]
    [QueryProperty("DiceType", "DiceType")]
    [QueryProperty("DiceQnt", "DiceQnt")]
    [QueryProperty("ModType", "ModType")]
    [QueryProperty("ModValue", "ModValue")]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Roll> rollList = [];

        [ObservableProperty]
        int result;

        [ObservableProperty]
        int diceType;
        [ObservableProperty]
        int diceQnt;
        [ObservableProperty]
        string modType = "";
        [ObservableProperty]
        string modValue = "";

        [RelayCommand]
        async static Task GoBack() => await Shell.Current.GoToAsync("..");

    }
}

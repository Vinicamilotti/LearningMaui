using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiceRoller.Model;

namespace DiceRoller.ViewModel
{

    [QueryProperty("rollList", "RollList")]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Roll[] rollList;

        [RelayCommand]
        async Task GoBack() => await Shell.Current.GoToAsync("..");

    }
}

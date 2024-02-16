using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiceRoller.MVVM.Model;

namespace DiceRoller.MVVM.ViewModel
{

    [QueryProperty("Pool", "Pool")]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        DicePool pool;
        [RelayCommand]
        async static Task GoBack() => await Shell.Current.GoToAsync("..");

    }
}

using System.Collections.ObjectModel;
using DiceRoller.MVVM.ViewModel;

namespace DiceRoller;

public partial class Details : ContentPage
{
    ObservableCollection<MVVM.Model.Roll> RollList { get; set; }

    public Details(DetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        RollList = vm.Rolls;
    }
}
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HelloWorld.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;
        public MainViewModel(IConnectivity connectivity)
        {
            Text = string.Empty;
            Items = new ObservableCollection<string>();

            this.connectivity = connectivity;
        }

        [RelayCommand]
        async void Add()
        {

            if (string.IsNullOrEmpty(Text))
            {
                return;
            }

            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Error", "Check your internet", "Exit");
                return;
            }

            Items.Add(Text);
            Text = string.Empty;


        }
        [RelayCommand]
        void Delete(string s)
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
            }
        }
        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?Text={s}");
        }
    }
}

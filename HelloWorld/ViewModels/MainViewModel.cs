using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HelloWorld.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        public MainViewModel()
        {
            Text = string.Empty;
            Items = new ObservableCollection<string>();
        }

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(Text))
            {
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
    }
}

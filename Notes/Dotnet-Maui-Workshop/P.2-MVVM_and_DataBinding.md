# MVVM & Data Binding
## Implementing INotifyPropertyChange
- The INotifyPropertyChange interface lets views kown about changes to the model. We can implement the Interface once and than inherit from that implementantio for every ViewModel

- `ViewModel/BaseViewModel.cs`
```cs
public class BaseViewModel : INotifyPropertyChanged
{

}
```
- In order to implement the `INotifyPropertyChanged` interface a event of `PropertyChangendEventHandler` type is needed

```cs
public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
}
```

Now a method that handle this event can be added
```cs
public void OnPropertyChanged([CallerMemberName] string name = null) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
```
For a cleaner code, one can also add  `Title` and `isBusy` properties to the base class
```cs
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Java.Util;

namespace HelloTux.ViewModel;

public class BaseViewModel : INotifyPropertyChanged
{
    bool isBusy;
    string title;

    public bool IsBusy 
    {
        get => isBusy; 
        set {
                if(isBusy == value) {
                    return;
                } 
                isBusy = value;
                OnPropertyChanged();
            } 
    }

    public string Title
    {
        get => title;
        set 
        {
            if(title == value) 
            {
                return;
            }
            title = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;


    public void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
```

## Create a service to read data
- Create a new namespace namad `Services`
```cs
using HelloTux.Model;
using System.Net.Http.Json;

namespace HelloTux.Services;

public class MonkeyService 
{
    List<Monkey> monkeyList = new();
    HttpClient httpClient;

    public MonkeyService() 
    {
        this.httpClient = new HttpClient();

    }
    public async Task<List<Monkey>> GetMonkeys()
    {
        var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");

        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);
        }

        return monkeyList;

    }
}
```
This service returns a json list of monkeys from the internet

now one can create the ViewModel
## Creating the ViewModel with the BaseViewModel
- Create a new partial class extending from the BaseViewModel
- Using the already known pattern
  - Register the class as a Singleton or Transient Service
  - Alter the code-behind of the view to recive the ViewModel as a paramenter in the constructor (Dependency injection)
  - Register the service as a Service in the builder
  - Alter the XAML file



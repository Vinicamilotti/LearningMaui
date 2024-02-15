# Accessing Plataform Features
- Plataform features are features like Geolocation, Connectivity, Camera, etc

## Using plataform features
In order to use plataform features first one should register the plataform interfaces as services
- `MauiProgram.cs`
```cs 
builder.Services.AddSingleton<IFeature>();
```

## Check for internet
Regestering some plataform features
- `MauiProgram.cs`
```cs
builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
builder.Services.AddSingleton<IGeolocatrion>(Geolocation.Default);
builder.Services.AddSingleton<IMap>(Map.Default);
```

Verifying internet connection before fetch monkeys
- `MainViewModel.cs`
```cs
// ...
IConnectivity conn;

public MainViewModel(MonkeyService monkeyService, IConnectivity conn)
{
    // ...
    this.conn = conn
}

// ...

async Task GetMonkeysAsync()
{
    //...
    if(conn.NetworkAccess != NetworkAccess.Internet)
    {
        await Shell.Current.DisplayAlert("Missing Connection", $"Please check your connection and try again", "Ok")
    }
}
```



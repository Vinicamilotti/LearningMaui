# Navigation
Using the Shell navigation one can create a behavior similar to web one page apps. One page can pass data to anotherusing query parameter such as a string or a full object

## Passing data: 
- Passing data with URI-like sintax
```cs
await Shell.Current.GoToAsync("SomePage?someProperty=someValue")
```
- Passing data with `Dictionary<string, object>`
```cs
await Shell.Current.GoToAsync("SomePage", new Dictionary<string, object>
{
    {"ParamName", SomeObject},
}
```

## Reciving Data
- In some other Page one should add a `[QueryProperty(string, string)]` decorator
```cs
[QueryProperty(nameof(SomeProperty), "ParamName")]
public partial class  SomePage: ContentPage
{
    string someProperty;
    public string SomeProperty
    {
        get => someProperty;
        set => someProperty = value;
    }
}
```
## Adding a Selected Event (HelloTux Project)


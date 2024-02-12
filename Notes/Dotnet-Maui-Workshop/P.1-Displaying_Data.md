# Displaying Data
- Creating a model
- `./Model/Monkey`
```cs
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace HelloTux.Model;
public class Monkey
{        
    public string Name { get; set; } 
    public string Location { get; set; } 
    public string Details { get; set; } 
    public string Image { get; set; } 
    public int Population { get; set; } 
    public double Latitude { get; set; } 
    public double Longitude { get; set; }

   
}
[JsonSerializable(typeof(List<Monkey>))]
internal sealed partial class MonkeyContext : JsonSerializerContext
{
    protected override JsonSerializerOptions? GeneratedSerializerOptions => throw new NotImplementedException();

    public override JsonTypeInfo? GetTypeInfo(Type type)
    {
            throw new NotImplementedException();
    }
}
```
Adding a raw json data to the Resources folder
## Displaying Data
Using the model
- In the page set the `xmlns:model` property to some model namespace
```xaml
xmlns:model="clr-namespace:HelloTux.Model"
```

- The full page code 
```cs
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="HelloTux.MainPage"
             xmlns:model="clr-namespace:HelloTux.Model">

    <CollectionView>
        <CollectionView.ItemsSource>
            <x:Array Type="{x:Type model:Monkey}">
                <model:Monkey
                    Name="Baboon"
                    Image="https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg"
                    Location="Africa and Asia" />
                <model:Monkey
                    Name="Capuchin Monkey"
                    Image="https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg"
                    Location="Central and South America" />
                <model:Monkey
                    Name="Red-shanked douc"
                    Image="https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg"
                    Location="Vietnam" />
            </x:Array>
        </CollectionView.ItemsSource>
        <CollectionView.ItemTemplate>
            <DataTemplate x:DataType="model:Monkey">
            <HorizontalStackLayout>
                <Image
                Aspect="AspectFill"
                HeightRequest="100"
                Source="{Binding Image}"
                WidthRequest="100" />
            <Label VerticalOptions="Center" TextColor="Gray">
                <Label.Text>
                    <MultiBinding StringFormat="{}{0} | {1}">
                        <Binding Path="Name" />
                        <Binding Path="Location" />
                    </MultiBinding>
                </Label.Text>
            </Label>
            </HorizontalStackLayout>
        </DataTemplate>
        </CollectionView.ItemTemplate>
    </CollectionView>

</ContentPage>

```

### XAML overview
1) Defining model namespace in `xmlns:model="clr-namespace:HelloTux.Model"`
2) Creating a collection view
3) Setting a hardcoded data model
  - Be aware, for now, the binding is not on the item it-self. However is important to notice: one `x:Array` is delcared, the `Type` property is setted to `x:Type model:Monkey` and then the itens are defined in code for now. Notice that the `Name` and `Image` properties are properties defined in the [Monkey model](../Model/Monkey.cs)
4) The `ItemTemplate` declares to the components how he should render the items source data
  - The `Type` of the DataTemplate is difined by `x:DataType="model:Monkey". This tells the .NET compiler that he should look at the Class Monkey to create the databindings
  - On Image there's a simple databinding to the Image property so one is telling the compiler that the `Source` property should be equal to the `Image` property of the Monkey model
  - Label and Multibinding Context: Here one is telling the compiler that more then one property will be binded to something. In this case is the StringFormat property of the `Label.Text` class. 

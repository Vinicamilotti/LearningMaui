# App Themes
Maui has the concept of reusable Application Resources, and resources that can automatically adapt to the theme of the device

## Reusable Resources
In the `App.xaml` are defined some `ResourceDictionary` for styles and colors.
These were configured ahead by the MAUI boilerplate, and defines the global styles to be applied in the app

```xml
<Color x:Key="LightBackgroud">#FAF9F8</Color>
```
This snippet defines the color of background when the app is light themed

Resources defined like This can be referenced in the code later. Ex:
```xaml
<Style x:Key="ButtonOutline" TargetType="Button">
    <Setter Property="Background" Value="{StaticResource LightBackground}" />
    <Setter Property="TextColor" Value="{StaticResource Primary}" />
    <Setter Property="BorderColor" Value="{StaticResource Primary}" />
    <Setter Property="BorderWidth" Value="2" />
    <Setter Property="HeightRequest" Value="40" />
    <Setter Property="CornerRadius" Value="20" />
</Style>
```

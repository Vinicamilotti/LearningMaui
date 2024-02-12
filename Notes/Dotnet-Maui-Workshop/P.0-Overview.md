# Part 0 - Overview
- This notes are attached to the [MonkeyFinder](../../Linux/HelloTux) project

## Understanding the .NET MAUI single project
- .NET MAUI Single project provides a simplified and consistent cross-plataform dev. exp.
  - Single shared project that cant target Android, iOS, macOS an Windoes
    - Obs: I'm working on a Linux machine, so the project file is setted to compile only for Android
  - A simplified debug target selection (Not at all)
  - Shared source files
  - Access to plataform-specific APIs and tools when required
  - Single cross-plataform app entry point

### Resource files
- Each plataform has his own approach to managin resources. For example: each plataform has differing image requirements that typically involves creating multiple versions of each images at different resolutions. MAUI single project enables resource files to be stored in a single locations while being consumed on each plataform. This includes fonts, inmages, icons, splash screen an raw assests.
  - **IMPORTANT**: Each image resource file is used as source image, from wich images of the required resolution are generated for each platafor at **build time**
- Resource files should be placed in the Resource Folder and must have ther build action set correctly.
|   Resource    |   Build action   |
|---------------|------------------|
| App Icon      | MauiIcon         |
| Fonts         | MauiFont         |
| Images        | Maui Image       |
| Splash screen | MauiSplashScreen |
| Raw Assets    | MauiAsset        |

## Understanding the .NET MAIU app startup
- MAUI apps are bootstrapped using the [.NET Generic Host mode](https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host?tabs=appbuilder)

Each plataform entrypoint calls a `CreateMauiApp` method ond the static `MauiProgram` class, that creates and returns a `MauiApp`

- `MauiProgram` minimal

```cs
namespace MyMauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>();

        return builder.Build();
    }
}
```
The `App` class derives from the `Application` class
- `App` class

```cs
namespace MyMauiApp;

public class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
```




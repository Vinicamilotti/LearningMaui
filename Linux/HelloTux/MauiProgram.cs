﻿using Microsoft.Extensions.Logging;
using HelloTux.Services;
using HelloTux.ViewModel;

namespace HelloTux;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<MonkeyService>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();  
		builder.Services.AddTransient<DetailsViewModel>();
		builder.Services.AddTransient<Details>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
} 

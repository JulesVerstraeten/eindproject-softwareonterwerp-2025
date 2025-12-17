using Microsoft.Extensions.Logging;
using WishList.Maui.Interfaces;
using WishList.Maui.Pages;
using WishList.Maui.Services;
using WishList.Maui.ViewModels;

namespace WishList.Maui;

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

		Routing.RegisterRoute(nameof(WishListPage), typeof(WishListPage));
		Routing.RegisterRoute(nameof(WishDetailPage), typeof(WishDetailPage));
		Routing.RegisterRoute(nameof(ChristmasListPage), typeof(ChristmasListPage));
		
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<WishListPage>();
		builder.Services.AddTransient<WishDetailPage>();
		
		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<WishListViewModel>();
		builder.Services.AddTransient<WishDetailViewModel>();
		
		builder.Services.AddTransient<INavigationService, NavigationService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

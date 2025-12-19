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

		Routing.RegisterRoute(NavigationRoutes.WishListPage, typeof(WishListPage));
		Routing.RegisterRoute(NavigationRoutes.WishDetailPage, typeof(WishDetailPage));
		Routing.RegisterRoute(NavigationRoutes.ChristmasListPage, typeof(ChristmasListPage));
		Routing.RegisterRoute(NavigationRoutes.ChristmasDetailPage, typeof(ChristmasDetailPage));
		Routing.RegisterRoute(NavigationRoutes.PeopleListPage, typeof(PeopleListPage));
		Routing.RegisterRoute(NavigationRoutes.PersonDetailPage, typeof(PersonDetailPage));
		
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<WishListPage>();
		builder.Services.AddTransient<ChristmasListPage>();
		builder.Services.AddTransient<WishDetailPage>();
		builder.Services.AddTransient<ChristmasDetailPage>();
		builder.Services.AddTransient<PeopleListPage>();
		builder.Services.AddTransient<PersonDetailPage>();
		
		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<WishListViewModel>();
		builder.Services.AddTransient<ChristmasListViewModel>();
		builder.Services.AddTransient<WishDetailViewModel>();
		builder.Services.AddTransient<ChristmasDetailViewModel>();
		builder.Services.AddTransient<PeopleListViewModel>();
		builder.Services.AddTransient<PersonDetailViewModel>();
		
		builder.Services.AddTransient<INavigationService, NavigationService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

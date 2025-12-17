using WishList.Maui.Interfaces;
using WishList.Maui.Pages;

namespace WishList.Maui.Services;

public class NavigationService : INavigationService
{
    private async Task GoToAsync(string routeName, ShellNavigationQueryParameters? parameters = null)
    {
        parameters ??= new ShellNavigationQueryParameters();
        await Shell.Current.GoToAsync(routeName, parameters);
    }
    
    public async Task NavigateToWishListPageAsync()
    {
        await GoToAsync(nameof(WishListPage));
    }

    public async Task NavigateToAddWishPageAsync()
    {
        await GoToAsync(nameof(WishDetailPage));
    }

    public async Task NavigateToChristmasListPageAsync()
    {        
        await GoToAsync(nameof(ChristmasListPage));
    }

    public async Task GoBackAsync()
    {
        await Shell.Current.Navigation.PopAsync();
    }
}
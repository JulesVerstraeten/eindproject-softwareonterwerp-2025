using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.Pages;

namespace WishList.Maui.Services;

public class NavigationService : INavigationService
{
    private static Task GoToAsync(string routeName, IDictionary<string, object?>? parameters = null)
    {
        return Shell.Current.GoToAsync(routeName, parameters ?? new Dictionary<string, object?>());
    }
    
    public Task NavigateToWishListPageAsync()
    {
        return GoToAsync(nameof(WishListPage));
    }

    public Task NavigateToDetailWishPageAsync(WishItemUiModel? wishItem = null)
    {
        return GoToAsync(NavigationRoutes.WishDetailPage, new Dictionary<string, object?>
        {
            [NavigationParameters.WishItem] = wishItem
        });
    }
    
    public Task NavigateToChristmasDetailPageAsync(ChristmasItemUiModel? christmasItem = null)
    {
        return GoToAsync(NavigationRoutes.ChristmasDetailPage, new Dictionary<string, object?>
        {
            [NavigationParameters.ChristmasItem] = christmasItem
        });
    }

    public Task NavigateToPeopleListPageAsync()
    {
        return GoToAsync(NavigationRoutes.PeopleListPage);
    }

    public Task NavigateToPersonDetailPageAsync(PersonUiModel? person = null)
    {
        return GoToAsync(NavigationRoutes.PersonDetailPage, new Dictionary<string, object?>
        {
            [NavigationParameters.Person] = person
        });
    }

    public Task NavigateToChristmasListPageAsync()
    {        
        return GoToAsync(nameof(ChristmasListPage));
    }

    public async Task GoBackAsync()
    {
        await Shell.Current.Navigation.PopAsync();
    }
    
}

public static class NavigationRoutes
{
    public const string MainPage = nameof(MainPage); 
    public const string WishListPage = nameof(WishListPage); 
    public const string WishDetailPage = nameof(WishDetailPage); 
    public const string ChristmasListPage = nameof(ChristmasListPage); 
    public const string ChristmasDetailPage = nameof(ChristmasDetailPage);
    public const string PeopleListPage = nameof(PeopleListPage);
    public const string PersonDetailPage = nameof(PersonDetailPage);
}

public static class NavigationParameters
{
    public const string WishItem =  "WishItem";
    public const string ChristmasItem =  "ChristmasItem";
    public const string Person =  "Person";
}
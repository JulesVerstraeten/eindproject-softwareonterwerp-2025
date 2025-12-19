using WishList.Maui.Models;

namespace WishList.Maui.Interfaces;

public interface INavigationService
{
    Task NavigateToWishListPageAsync();
    Task NavigateToDetailWishPageAsync(WishItem? wishItem = null);
    Task NavigateToChristmasListPageAsync();
    Task NavigateToChristmasDetailPageAsync(ChristmasItem? christmasItem = null);
    Task NavigateToPeopleListPageAsync();
    Task NavigateToPersonDetailPageAsync(Person? person = null);
    Task GoBackAsync();
}
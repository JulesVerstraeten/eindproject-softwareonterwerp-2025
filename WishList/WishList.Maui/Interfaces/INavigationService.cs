using WishList.Maui.Models;

namespace WishList.Maui.Interfaces;

public interface INavigationService
{
    Task NavigateToWishListPageAsync();
    Task NavigateToDetailWishPageAsync(WishItemViewModel? wishItem = null);
    Task NavigateToChristmasListPageAsync();
    Task NavigateToChristmasDetailPageAsync(ChristmasItemViewModel? christmasItem = null);
    Task NavigateToPeopleListPageAsync();
    Task NavigateToPersonDetailPageAsync(PersonViewModel? person = null);
    Task GoBackAsync();
}
using WishList.Maui.Models;

namespace WishList.Maui.Interfaces;

public interface INavigationService
{
    Task NavigateToWishListPageAsync();
    Task NavigateToDetailWishPageAsync(WishItemUiModel? wishItem = null);
    Task NavigateToChristmasListPageAsync();
    Task NavigateToChristmasDetailPageAsync(ChristmasItemUiModel? christmasItem = null);
    Task NavigateToPeopleListPageAsync();
    Task NavigateToPersonDetailPageAsync(PersonUiModel? person = null);
    Task GoBackAsync();
}
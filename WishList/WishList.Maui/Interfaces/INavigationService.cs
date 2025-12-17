namespace WishList.Maui.Interfaces;

public interface INavigationService
{
    Task NavigateToWishListPageAsync();
    Task NavigateToAddWishPageAsync();
    Task NavigateToChristmasListPageAsync();
    Task GoBackAsync();
}
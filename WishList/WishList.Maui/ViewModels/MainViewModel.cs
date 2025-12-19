using System.Diagnostics;
using System.Windows.Input;
using WishList.Maui.Interfaces;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class MainViewModel : ViewModel
{
    private INavigationService _navigationService;
    public ICommand GoToWishListPageCommand { get; }
    public ICommand GoToChristmasListPageCommand { get; }
    
    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
        GoToWishListPageCommand = new Command(async () =>
        {
            await _navigationService.NavigateToWishListPageAsync();
        });
        
        GoToChristmasListPageCommand = new Command(async () =>
        {
            await _navigationService.NavigateToChristmasListPageAsync();
        });
    }


}
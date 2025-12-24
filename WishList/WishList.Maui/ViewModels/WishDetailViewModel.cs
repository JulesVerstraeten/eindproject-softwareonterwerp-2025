using System.Diagnostics;
using System.Windows.Input;
using WishList.BL.Interfaces;
using WishList.Maui.Extensions;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.Services;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class WishDetailViewModel : ViewModel, IQueryAttributable
{
    private INavigationService _navigationService;
    private IWishItemService _wishItemService;
    
    public WishDetailViewModel(INavigationService navigationService, IWishItemService wishItemService)
    {
        _navigationService = navigationService;
        _wishItemService = wishItemService;
        
        CancelCommand = new Command(Cancel);
        SaveWishCommand = new Command( async void () =>
        {
            await SaveWish();
        });

        WishItem = new WishItemViewModel();
    }
    
    // PROPERTIES FOR WISH FORM
    
    private WishItemViewModel _wishItem;
    public WishItemViewModel WishItem
    {
        get => _wishItem;
        set => SetProperty(ref _wishItem, value);
    }

    private string _wishItemError;
    public string WishItemError
    {
        get => _wishItemError;
        set => SetProperty(ref _wishItemError, value);
    }
    
    // COMMANDS
    
    public ICommand CancelCommand { get; }
    public ICommand SaveWishCommand { get; }

    private void Cancel()
    {
        _navigationService.GoBackAsync();
    } 

    private async Task SaveWish()
    {
        bool isValid = true;

        if (string.IsNullOrEmpty(WishItem.Title))
        {
            WishItemError = "Title is required";
            isValid = false;
        } 
        else if (string.IsNullOrEmpty(WishItem.WebsiteUrl))
        {
            WishItemError = "WebsiteUrl is required";
            isValid = false;
        } 
        else if (!Uri.TryCreate(WishItem.WebsiteUrl, UriKind.Absolute, out var uri) ||
                 (uri.Scheme == Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            WishItemError = "Invalid website url (https://www.site.nl or http://www.site.nl)";
        }
        else
        {
            WishItemError = string.Empty;
        }
        
        if (!isValid) return;
        
        await _wishItemService.SaveWishItemAsync(WishItem.AsModel());
        await _navigationService.GoBackAsync();
    }
    
    // PARAMETERS CHECKER
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue(NavigationParameters.WishItem, out var wishItem) && wishItem is WishItemViewModel wish)
        {
            WishItem = wish;
        }
    }
}
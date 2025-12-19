using System.Diagnostics;
using System.Windows.Input;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.Services;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class WishDetailViewModel : ViewModel, IQueryAttributable
{
    private INavigationService _navigationService;
    
    public WishDetailViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
        CancelCommand = new Command(Cancel);
        SaveWishCommand = new Command(SaveWish);

        WishItem = new WishItemUiModel();
    }
    
    // PROPERTIES FOR WISH FORM
    
    private WishItemUiModel _wishItem;
    public WishItemUiModel WishItem
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

    private void SaveWish()
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
        
        Debugger.Log(0, "WishList", WishItem.ToString());
    }
    
    // PARAMETERS CHECKER
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue(NavigationParameters.WishItem, out var wishItem) && wishItem is WishItemUiModel wish)
        {
            WishItem = wish;
        }
    }
}
using System.Diagnostics;
using System.Windows.Input;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class WishDetailViewModel : ViewModel
{
    private INavigationService _navigationService;
    
    public WishDetailViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
        CancelCommand = new Command(async () => await Cancel());
        SaveWishCommand = new Command(async () => await SaveWish());
    }
    
    // PROPERTIES FOR WISH FORM
    
    private string _title = string.Empty;
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
    
    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    private string _pictureUrl = string.Empty;
    public string PictureUrl
    {
        get => _pictureUrl;
        set => SetProperty(ref _pictureUrl, value);
    }
    
    private string _websiteUrl = string.Empty;
    public string WebsiteUrl
    {
        get => _websiteUrl;
        set => SetProperty(ref _websiteUrl, value);
    }
    
    // COMMANDS
    
    public ICommand CancelCommand { get; }
    public ICommand SaveWishCommand { get; }

    private async Task Cancel()
    {
        await _navigationService.GoBackAsync();
    }

    private async Task SaveWish()
    {
        var newWish = new WishItem
        (
            Title: Title,
            Description: Description,
            PictureUrl: PictureUrl,
            WebsiteUrl: WebsiteUrl
        );
    }
}
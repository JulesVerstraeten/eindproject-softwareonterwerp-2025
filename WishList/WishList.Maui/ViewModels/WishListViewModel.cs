using System.Collections.ObjectModel;
using System.Windows.Input;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class WishListViewModel : ViewModel
{
    private readonly INavigationService _navigationService;

    public WishListViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
        GoToDetailWishPage = new Command( () =>
        {
            _navigationService.NavigateToDetailWishPageAsync();
        });
    }
    
    // PROPERTIES
    
    private WishItemUiModel? _selectedWishItem =  null;
    public WishItemUiModel? SelectedWishItem
    {
        get => _selectedWishItem;
        set
        {
            SetProperty(ref _selectedWishItem, value);
            _navigationService.NavigateToDetailWishPageAsync(_selectedWishItem);
        }
    }

    private ObservableCollection<WishItemUiModel> _wishItems =
    [
        new WishItemUiModel
        {
            Id = 1,
            PictureUrl =
                "https://i5.walmartimages.com/seo/Nerf-N-Series-Sprinter-Motorized-Blaster-16-Nerf-N1-Darts-Compatible-Only-with-Nerf-N-Series_5744fbc4-2103-4028-8292-7e020123101a.c1bd7364d9fe1cc91b23a48215b434c5.jpeg?odnHeight=573&odnWidth=573&odnBg=FFFFFF",
            Title = "Nerf",
            Description = "Coole gun",
            WebsiteUrl = "Site",
        }
    ];
    public ObservableCollection<WishItemUiModel> WishItems
    {
        get => _wishItems;
        set => SetProperty(ref _wishItems, value);
    }
    
    // COMMANDS
    
    public ICommand GoToDetailWishPage { get; }
}

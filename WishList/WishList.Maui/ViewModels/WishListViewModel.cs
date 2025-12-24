using System.Collections.ObjectModel;
using System.Windows.Input;
using WishList.BL.Interfaces;
using WishList.Maui.Extensions;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class WishListViewModel : ViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IWishItemService _wishItemService;

    public WishListViewModel(INavigationService navigationService, IWishItemService wishItemService)
    {
        _navigationService = navigationService;
        _wishItemService = wishItemService;
        
        GoToDetailWishPage = new Command( () =>
        {
            _navigationService.NavigateToDetailWishPageAsync();
        });

        WishItems = [];
    }
    
    // INITIALISER

    public async Task InitializeAsync()
    {
        var results = await _wishItemService.GetAllWishItemsAsync();
        WishItems.Clear();
        foreach (var result in results)
        {
            WishItems.Add(
                result.AsViewModel()    
            );
        }
    }
    
    // PROPERTIES
    
    private WishItemViewModel? _selectedWishItem;
    public WishItemViewModel? SelectedWishItem
    {
        get => _selectedWishItem;
        set
        {
            SetProperty(ref _selectedWishItem, value);
            _navigationService.NavigateToDetailWishPageAsync(_selectedWishItem);
        }
    }

    private ObservableCollection<WishItemViewModel> _wishItems;
    public ObservableCollection<WishItemViewModel> WishItems
    {
        get => _wishItems;
        set => SetProperty(ref _wishItems, value);
    }
    
    // COMMANDS
    
    public ICommand GoToDetailWishPage { get; }
}

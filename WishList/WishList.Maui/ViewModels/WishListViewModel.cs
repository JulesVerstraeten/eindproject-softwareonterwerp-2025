using System.Collections.ObjectModel;
using System.Windows.Input;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class WishListViewModel : ViewModel
{
    private INavigationService _navigationService;
    public ICommand GoToAddWishPage { get; }

    public WishListViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
        GoToAddWishPage = new Command( async () =>
        {
            await _navigationService.NavigateToAddWishPageAsync();
        });
    }

    private ObservableCollection<WishItem> _wishItems = new ObservableCollection<WishItem>
    {
        new WishItem(1, "https://i5.walmartimages.com/seo/Nerf-N-Series-Sprinter-Motorized-Blaster-16-Nerf-N1-Darts-Compatible-Only-with-Nerf-N-Series_5744fbc4-2103-4028-8292-7e020123101a.c1bd7364d9fe1cc91b23a48215b434c5.jpeg?odnHeight=573&odnWidth=573&odnBg=FFFFFF", "Nerf", "www.shop.nl", "Gekke geweer"),
        new WishItem(2, "https://www.swissenduroteam.com/wp-content/uploads/2024/04/fluffy-pantoffels-595akg-1-600x600.jpg", "Pantoffels", "www.yolo.nl", "Lekker warm")
    };
    public ObservableCollection<WishItem> WishItems
    {
        get => _wishItems;
        set
        {
            if (value == null) return;
            _wishItems = value;
            OnPropertyChanged(nameof(WishItems));
        }
    }
}
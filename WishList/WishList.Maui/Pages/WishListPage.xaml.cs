using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Maui.ViewModels;

namespace WishList.Maui.Pages;

public partial class WishListPage : ContentPage
{
    private readonly WishListViewModel _wishListViewModel;
    public WishListPage(WishListViewModel wishListViewModel)
    {
        InitializeComponent();
        _wishListViewModel = wishListViewModel;
        BindingContext = _wishListViewModel;
        _ = _wishListViewModel.InitializeAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = _wishListViewModel.InitializeAsync();
    }
}
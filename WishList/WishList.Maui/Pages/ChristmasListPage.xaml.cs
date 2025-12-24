using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Maui.ViewModels;

namespace WishList.Maui.Pages;

public partial class ChristmasListPage : ContentPage
{
    private readonly ChristmasListViewModel _christmasListViewModel;
    public ChristmasListPage(ChristmasListViewModel christmasListViewModel)
    {
        InitializeComponent();
        _christmasListViewModel = christmasListViewModel;
        BindingContext = _christmasListViewModel;
        _ = _christmasListViewModel.InitializeAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = _christmasListViewModel.InitializeAsync();
    }
}
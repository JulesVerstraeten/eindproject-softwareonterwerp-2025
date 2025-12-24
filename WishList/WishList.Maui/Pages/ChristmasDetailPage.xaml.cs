using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Maui.ViewModels;

namespace WishList.Maui.Pages;

public partial class ChristmasDetailPage : ContentPage
{
    private readonly ChristmasDetailViewModel _christmasDetailViewModel;
    public ChristmasDetailPage(ChristmasDetailViewModel christmasDetailViewModel)
    {
        InitializeComponent();
        _christmasDetailViewModel = christmasDetailViewModel;
        BindingContext = _christmasDetailViewModel;
        _ = _christmasDetailViewModel.InitializeAsync();
    }
}
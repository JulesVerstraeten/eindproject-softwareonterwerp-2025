using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Maui.ViewModels;

namespace WishList.Maui.Pages;

public partial class PeopleListPage : ContentPage
{
    private readonly PersonListViewModel _viewModel;
    
    public PeopleListPage(PersonListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
        _ = _viewModel.InitializeAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = _viewModel.InitializeAsync();
    }
}
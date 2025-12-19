using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Maui.ViewModels;

namespace WishList.Maui.Pages;

public partial class ChristmasDetailPage : ContentPage
{
    public ChristmasDetailPage(ChristmasDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using WishList.BL.Interfaces;
using WishList.Maui.Extensions;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class ChristmasListViewModel : ViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IChristmasItemService _christmasItemService;
    
    // CONSTRUCTOR

    public ChristmasListViewModel(INavigationService navigationService, IChristmasItemService christmasItemService)
    {
        _navigationService = navigationService;
        _christmasItemService = christmasItemService;

        GoToChristmasDetailPageCommand = new Command(_goToChristmasDetailPage);
        GoToPeopleListPageCommand = new Command(_goToPeoplePage);

        ChristmasItems = [];
    }
    
    // INITIALIZER
    
    public async Task InitializeAsync()
    {
        var results = await _christmasItemService.GetAllChristmasItemsAsync();
        ChristmasItems.Clear();
        foreach (var result in results)
        {
            ChristmasItems.Add(result.AsViewModel());
        }
    }
    
    // PROPERTIES

    private List<PersonViewModel> _people;
    public List<PersonViewModel> People
    {
        get => _people;
        set => SetProperty(ref _people, value);
    }
    
    private ChristmasItemViewModel? _selectedChristmasItem;
    public ChristmasItemViewModel? SelectedChristmasItem
    {
        get => _selectedChristmasItem;
        set
        {
            if (!SetProperty(ref _selectedChristmasItem, value)) return;
            if (_selectedChristmasItem == null) return;
            _navigationService.NavigateToChristmasDetailPageAsync(_selectedChristmasItem);
            SelectedChristmasItem = null; // reset voor volgende selectie
        }
    }

    private ObservableCollection<ChristmasItemViewModel> _christmasItems = new ObservableCollection<ChristmasItemViewModel>();
    public ObservableCollection<ChristmasItemViewModel> ChristmasItems
    {
        get => _christmasItems;
        set => SetProperty(ref _christmasItems, value);
    }
    
    // COMMANDS
    
    public ICommand GoToChristmasDetailPageCommand { get; }
    public ICommand GoToPeopleListPageCommand { get; }
    
    private void _goToChristmasDetailPage()
    {
        _navigationService.NavigateToChristmasDetailPageAsync();
    }

    private void _goToPeoplePage()
    {
        _navigationService.NavigateToPeopleListPageAsync();
    }

}

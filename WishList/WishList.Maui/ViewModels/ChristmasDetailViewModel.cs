using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using WishList.BL.Interfaces;
using WishList.Maui.Extensions;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.Services;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class ChristmasDetailViewModel : ViewModel, IQueryAttributable
{
    private readonly INavigationService _navigationService;
    private readonly IChristmasItemService _christmasItemService;
    private readonly IPersonService _personService;
    
    public ChristmasDetailViewModel(INavigationService navigationService, IPersonService personService, IChristmasItemService christmasItemService)
    {
        _navigationService = navigationService;
        _christmasItemService = christmasItemService;
        _personService = personService;
        
        CancelCommand = new Command(Cancel);
        SaveChristmasItemCommand = new Command(async void () => await SaveChristmasItem());

        ChristmasItem = new ChristmasItemViewModel();
        People = [];
    }
    
    // INITIALIZER

    public async Task InitializeAsync()
    {
        var results = await _personService.GetAllPersonsAsync();
        People.Clear();
        foreach (var result in results)
        {
            People.Add(result.AsViewModel());
        }
    }
    
    // PROPERTIES

    private ObservableCollection<PersonViewModel> _people;
    public ObservableCollection<PersonViewModel> People
    {
        get => _people;
        set => SetProperty(ref _people, value);
    }
    
    private ChristmasItemViewModel _christmasItem;
    public ChristmasItemViewModel ChristmasItem
    {
        get => _christmasItem;
        set => SetProperty(ref _christmasItem, value);
    }

    private string _priceInput;
    public string PriceInput
    {
        get => _priceInput;
        set => SetProperty(ref _priceInput, value);
    }

    private string _christmasItemError;
    public string ChristmasItemError
    {
        get => _christmasItemError;
        set => SetProperty(ref _christmasItemError, value);
    }
    
    // COMMANDS
    
    public ICommand CancelCommand { get; }
    public ICommand SaveChristmasItemCommand { get; }

    private void Cancel()
    {
        _navigationService.GoBackAsync();
    } 

    private async Task SaveChristmasItem()
    {
        bool isValid = true;

        if (string.IsNullOrEmpty(ChristmasItem.Title))
        {
            ChristmasItemError = "Title is required";
            isValid = false;
        } else if (!double.TryParse(PriceInput, out var price) && !string.IsNullOrWhiteSpace(PriceInput))
        {
            ChristmasItemError = "Price must be a floating-point number";
            isValid = false;
        }
        else
        {
            ChristmasItemError = string.Empty;
        }
        
        if (!isValid) return;
        
        ChristmasItem.Price = string.IsNullOrWhiteSpace(PriceInput) ? null : double.Parse(PriceInput) ;
        
        await _christmasItemService.SaveChristmasItemAsync(ChristmasItem.AsModel());
        await _navigationService.GoBackAsync();
    }
    
    // PARAMETERS CHECKER
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue(NavigationParameters.ChristmasItem, out var christmasItem) ||
            christmasItem is not ChristmasItemViewModel item) return;
        
        ChristmasItem = item;
        PriceInput = item.Price.ToString() ?? string.Empty;

        if (item.ForPerson == null) return;
        var matchedPerson = People.FirstOrDefault(p => p.Id == item.ForPerson.Id);
        if (matchedPerson != null)
            ChristmasItem.ForPerson = matchedPerson;
    }
}